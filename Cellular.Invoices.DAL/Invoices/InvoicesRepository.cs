using Cellular.Common.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.Invoices.DAL.Invoices
{
    public class InvoicesRepository : IInvoicesRepository
    {
        public SingleLineInvoiceData[] GetClientData(int clintId, DateTime from, DateTime until)
        {
            throw new NotImplementedException();
        }
    }
}
