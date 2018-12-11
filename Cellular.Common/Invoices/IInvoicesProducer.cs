using Cellular.Common.Invoices.Models;

namespace Cellular.Common.Invoices
{
    public interface IInvoicesProducer
    {
        Invoice CreateInvoice(int clientId, int year, int month);
    }
}
