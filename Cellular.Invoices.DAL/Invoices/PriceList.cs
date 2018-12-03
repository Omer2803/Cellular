using Cellular.Common.Invoices;
using Cellular.Common.Models;
using Cellular.MainDal;

namespace Cellular.Invoices.DAL.Invoices
{
    public class PriceList : IPriceList
    {
        public double GetCallMinuetPrice(ClientTypeEnum clientType)
        {
            using (var context = new CellularDbContext())
                return context.ClientTypes.Find(clientType).CallMinutesPrice;
        }

        public double GetSMSPrice(ClientTypeEnum clientType)
        {
            using (var context = new CellularDbContext())
                return context.ClientTypes.Find(clientType).SmsPrice;
        }
    }
}
