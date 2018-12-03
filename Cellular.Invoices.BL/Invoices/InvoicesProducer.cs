using Cellular.Common.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.Invoices.BL.Invoices
{
    public class InvoicesProducer : IInvoicesProducer
    {
        private readonly IInvoicesRepository repository;

        public InvoicesProducer(IInvoicesRepository repository)
        {
            this.repository = repository;
        }

        public IInvoice Createinvoice(int clientId, DateTime from, DateTime until)
        {
            throw new NotImplementedException();
        }
    }
}
