using Cellular.Common.Invoices;
using Cellular.Common.Models;
using Cellular.MainDal;
using System.Collections.Generic;

namespace Cellular.Invoices.DAL.Invoices
{
    public class PriceList : IPriceList
    {
        public double GetCallMinuetPrice(ClientTypeEnum clientType)
        {
            if (!prices.ContainsKey((clientType, ServiceType.Call)))
            {
                using (var context = new CellularDbContext())
                {
                    var price = context.ClientTypes.Find(clientType).CallMinutesPrice;
                    prices[(clientType, ServiceType.Call)] = price;
                    return price;
                }
            }
            return prices[(clientType, ServiceType.Call)];
        }

        public double GetSMSPrice(ClientTypeEnum clientType)
        {
            if (!prices.ContainsKey((clientType, ServiceType.SMS)))
            {
                using (var context = new CellularDbContext())
                {
                    var price = context.ClientTypes.Find(clientType).SmsPrice;
                    prices[(clientType, ServiceType.SMS)] = price;
                    return price;
                }
            }
            return prices[(clientType, ServiceType.Call)];
        }

        private static readonly Dictionary<(ClientTypeEnum, ServiceType), double> prices
            = new Dictionary<(ClientTypeEnum, ServiceType), double>();

        private enum ServiceType
        {
            Call,
            SMS
        }
    }
}
