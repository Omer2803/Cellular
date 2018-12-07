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

        public Invoice CreateInvoice(int clientId, DateTime from, DateTime until)
        {
            var data = repository.GetClientUsageDetails(clientId, from, until);

            var invoices = new SingeLineInvoice[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                var pack = data[i].Package;

                var minuetsDiff = MinuetsDifferece(data[i]);

                int smsesDiff = pack.IncludesSMS ? data[i].SMSes.Length - pack.MaxSMS.Value : 0;

                var minuetsLeft = minuetsDiff > 0 ? 0 : -minuetsDiff;

                var packInfo = new PackageInfo
                {
                    MinuetsLeft = minuetsLeft,
                    MinuetsUsagePercentage =,
                    MinutesToFriends =,
                    SMSesLeft =,
                    SMSesUsagePercentage =,
                };

                var additionalMinuets = minuetsDiff > 0 ? minuetsDiff : 0;
                var additionalSMSes = smsesDiff > 0 ? smsesDiff : 0;

                var outOfPack = new OutOfPackage
                {
                    AdditionalMinuets = additionalMinuets,
                    AdditionalSMSes = additionalSMSes
                };
                outOfPack.TotalAdditionalPrice =
                    outOfPack.AdditionalMinuets * priceList.GetCallMinuetPrice(data[i].ClientType) +
                    outOfPack.AdditionalSMSes * priceList.GetSMSPrice(data[i].ClientType);

                invoices[i] = new SingeLineInvoice
                {
                    UsageDetails = data[i],
                    PackageInfo = packInfo,
                    OutOfPackage = outOfPack,
                    TotalPrice = pack.TotalPrice + outOfPack.TotalAdditionalPrice
                };
            }

            return new Invoice
            {
                LineInvoices = invoices,
                TotalPrice = invoices.Sum(i => i.TotalPrice),
                AdditionalPrice = invoices.Sum(i => i.OutOfPackage.TotalAdditionalPrice)
            };
        }

        private double MinuetsDifferece(SingleLineUsageDetails usageDetails)
        {
            var pack = usageDetails.Package;

            var friends = pack.IncludesFriends ?
                    new string[] { pack.Number1, pack.Number2, pack.Number3 }
                    : new string[0];

            return pack.InculdesMiutes ?
                usageDetails.Calls
                .Where(c => !friends.Contains(c.DestinationNumber))
                .Sum(c => c.Duration.TotalMinutes)
                - pack.MaxMinutes.Value
                : 0;
        }
    }
}
