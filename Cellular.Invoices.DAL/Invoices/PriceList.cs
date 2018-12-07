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

            if (prices[(clientType, ServiceType.Call)] == null)
            {
                using (var context = new CellularDbContext())
                    return context.ClientTypes.Find(clientType).CallMinutesPrice;
            }
            return prices[(clientType, ServiceType.Call)].Value;
        }

        public double GetSMSPrice(ClientTypeEnum clientType)
        {
            if (prices[(clientType, ServiceType.SMS)] == null)
            {
                using (var context = new CellularDbContext())
                    return context.ClientTypes.Find(clientType).SmsPrice;
            }
            return prices[(clientType, ServiceType.Call)].Value;
        }

        private static readonly Dictionary<(ClientTypeEnum, ServiceType), double?> prices
            = new Dictionary<(ClientTypeEnum, ServiceType), double?>();

        private enum ServiceType
        {
            Call,
            SMS
        }
    }
}
