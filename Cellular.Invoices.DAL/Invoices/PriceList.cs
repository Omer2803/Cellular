using Cellular.Common.Invoices;
using Cellular.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.Invoices.DAL.Invoices
{
    public class PriceList : IPriceList
    {
        public double GetCallMinuetPrice(ClientTypeEnum clientType)
        {
            throw new NotImplementedException();
        }

        public double GetSMSPrice(ClientTypeEnum clientType)
        {
            throw new NotImplementedException();
        }
    }
}
