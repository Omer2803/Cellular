using System;
using System.Collections.Generic;
using System.Text;

namespace Cellular.Common.Invoices
{
    public interface IInvoicesProducer
    {
        invoice Createinvoice(int clientId, DateTime from, DateTime until);
    }
}
