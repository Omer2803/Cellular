using System;

namespace Cellular.Common.Invoices
{
    public interface IInvoicesProducer
    {
        IInvoice Createinvoice(int clientId, DateTime from, DateTime until);
    }
}
