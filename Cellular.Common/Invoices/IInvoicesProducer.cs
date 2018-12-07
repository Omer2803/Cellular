using Cellular.Common.Invoices.Models;
using System;

namespace Cellular.Common.Invoices
{
    public interface IInvoicesProducer
    {
        Invoice CreateInvoice(int clientId, DateTime from, DateTime until);
    }
}
