using Cellular.Common.Invoices;
using Cellular.Common.Invoices.Models;
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

        public Invoice CreateInvoice(int clientId, DateTime from, DateTime until)
        {
            var usageDetails = repository.GetClientUsageDetails(clientId, from, until);

            var invoices = new SingeLineInvoice[usageDetails.Length];

            for (int i = 0; i < usageDetails.Length; i++)
            {
                var pack = usageDetails[i].Package;
                bool hasMinuets = pack != null ? pack.IncludesMinuets : false;
                bool hasSMSes = pack != null ? pack.IncludesSMSes : false;

                double mins = MinuetsWithoutFriends(usageDetails[i], out double? friendsMinuets);
                int smses = usageDetails[i].SMSes.Length;

                double minuetsDiff = pack != null ? pack.IncludesMinuets ? mins - pack.MaxMinuets.Value : mins : mins;
                int smsesDiff = pack != null ? pack.IncludesSMSes ? smses - pack.MaxSMSes.Value : smses : smses;

                var packInfo = new PackageInfo
                {
                    MinuetsLeft = hasMinuets ? minuetsDiff > 0 ? (double?)null : -minuetsDiff : null,
                    MinuetsUsagePercentage = hasMinuets ? minuetsDiff > 0 ? 100 : mins / pack.MaxMinuets * 100 : null,
                    FriendsMinuets = friendsMinuets,
                    SMSesLeft = hasSMSes ? smsesDiff > 0 ? (int?)null : -smsesDiff : null,
                    SMSesUsagePercentage = hasSMSes ? smsesDiff > 0 ? 100 : smses / pack.MaxSMSes * 100 : null,
                };

                var outOfPack = new OutOfPackage();
                outOfPack.AdditionalMinuets = minuetsDiff > 0 ? minuetsDiff : 0;
                outOfPack.AdditionalSMSes = smsesDiff > 0 ? smsesDiff : 0;
                outOfPack.TotalAdditionalPrice =
                    outOfPack.AdditionalMinuets * priceList.GetCallMinuetPrice(usageDetails[i].ClientType) +
                    outOfPack.AdditionalSMSes * priceList.GetSMSPrice(usageDetails[i].ClientType);

                invoices[i] = new SingeLineInvoice
                {
                    UsageDetails = usageDetails[i],
                    PackageInfo = packInfo,
                    OutOfPackage = outOfPack,
                    TotalPrice = (pack?.TotalPrice ?? 0) + outOfPack.TotalAdditionalPrice
                };
            }

            return new Invoice
            {
                StartDate = from,
                EndDate = until,
                LineInvoices = invoices,
                TotalPrice = invoices.Sum(i => i.TotalPrice),
                AdditionalPrice = invoices.Sum(i => i.OutOfPackage.TotalAdditionalPrice)
            };
        }

        private double MinuetsWithoutFriends(SingleLineUsageDetails usageDetails, out double? friendsMinuets)
        {
            var pack = usageDetails.Package;

            var friends = pack != null ?
                pack.IncludesFriends ?
                    new string[] { pack.Number1, pack.Number2, pack.Number3 } : new string[0]
                    : new string[0];

            var friendsCalls = usageDetails.Calls
                .Where(c => friends.Contains(c.DestinationNumber))
                .ToArray();

            friendsMinuets = friendsCalls.Sum(c => c.Duration.TotalMinutes);

            return usageDetails.Calls
                .Except(friendsCalls)
                .Sum(c => c.Duration.TotalMinutes);
        }
    }
}
