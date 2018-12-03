using System;

namespace Cellular.Common.Invoices
{
    public interface IInvoicesRepository
    {
        SingleLineInvoiceData[] GetClientData(int clintId, DateTime from, DateTime until);
    }
}
