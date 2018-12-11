using Cellular.Common.Invoices;
using Cellular.Common.Invoices.Models;
using Cellular.Common.Models;
using System;
using System.Linq;

namespace Cellular.Invoices.BL.Invoices
{
    public class InvoicesProducer : IInvoicesProducer
    {
        private readonly IInvoicesRepository repository;
        private readonly IPriceList priceList;

        public InvoicesProducer(IInvoicesRepository repository, IPriceList priceList)
        {
            this.repository = repository;
            this.priceList = priceList;
        }

        public Invoice CreateInvoice(int clientId, int year, int month)
        {
            var linesInvoices = InvoicesFor(repository.GetClientUsageDetails(clientId, year, month));

            return new Invoice
            {
                StartDate = new DateTime(year, month, 1),
                EndDate = new DateTime(year, month, 1).AddMonths(1),
                LineInvoices = linesInvoices,
                TotalPrice = linesInvoices.Sum(i => i.TotalPrice),
                AdditionalPrice = linesInvoices.Sum(i => i.OutOfPackage.TotalAdditionalPrice)
            };
        }

        private SingeLineInvoice[] InvoicesFor(SingleLineUsageDetails[] usageDetails)
        {
            var result = new SingeLineInvoice[usageDetails.Length];

            for (int i = 0; i < usageDetails.Length; i++)
            {
                Package package = usageDetails[i].Package;

                double minutes = MinutesWithoutFriends(usageDetails[i], out double? friendsMinuets);
                int smses = usageDetails[i].SMSes.Length;

                double minutesDifference = package != null && package.IncludesMinuets ?
                    minutes - package.MaxMinuets.Value 
                    : minutes;

                int smsesDifference = package != null && package.IncludesSMSes ?
                    smses - package.MaxSMSes.Value 
                    : smses;

                PackageUsage packageInfo = GetPackageInfo(package, minutes, minutesDifference, friendsMinuets, smses, smsesDifference);
                OutOfPackage outOfPackage = GetOutOfPackage(minutesDifference, smsesDifference, usageDetails[i].ClientType);

                result[i] = new SingeLineInvoice
                {
                    UsageDetails = usageDetails[i],
                    PackageInfo = packageInfo,
                    OutOfPackage = outOfPackage,
                    TotalPrice = (package?.TotalPrice ?? 0) + outOfPackage.TotalAdditionalPrice
                };
            }

            return result;
        }

        private PackageUsage GetPackageInfo(Package package, double minuets, double minuetsDifference, double? friendsMinuets, int smses, int smsesDifference)
        {
            bool hasMinuets = package != null && package.IncludesMinuets;
            bool hasSMSes = package != null && package.IncludesSMSes;

            return new PackageUsage
            {
                MinuetsLeft = hasMinuets && minuetsDifference < 0 ? -minuetsDifference : (double?)null,
                MinuetsUsagePercentage = hasMinuets ? minuetsDifference > 0 ? 100 : minuets / package.MaxMinuets * 100 : null,
                FriendsMinuets = friendsMinuets,
                SMSesLeft = hasSMSes && smsesDifference < 0 ? -smsesDifference : (int?)null,
                SMSesUsagePercentage = hasSMSes ? smsesDifference > 0 ? 100 : smses / package.MaxSMSes * 100 : null,
            };
        }

        private OutOfPackage GetOutOfPackage(double minuetsDifference, int smsesDifference, ClientTypeEnum clientType)
        {
            var result = new OutOfPackage();

            result.AdditionalMinuets = minuetsDifference > 0 ? minuetsDifference : 0;
            result.AdditionalSMSes = smsesDifference > 0 ? smsesDifference : 0;
            result.TotalAdditionalPrice =
                result.AdditionalMinuets * priceList.GetCallMinuetPrice(clientType) 
                + result.AdditionalSMSes * priceList.GetSMSPrice(clientType);

            return result;
        }

        private double MinutesWithoutFriends(SingleLineUsageDetails usageDetails, out double? friendsMinuets)
        {
            var pack = usageDetails.Package;

            var friendsNumbers = pack != null && pack.IncludesFriends ?
                    new string[] { pack.Number1, pack.Number2, pack.Number3 } : new string[0];

            var friendsCalls = usageDetails.Calls
                .Where(c => friendsNumbers.Contains(c.DestinationNumber))
                .ToArray();

            friendsMinuets = friendsCalls.Sum(c => c.Duration.TotalMinutes);

            return usageDetails.Calls
                .Except(friendsCalls)
                .Sum(c => c.Duration.TotalMinutes);
        }
    }
}
