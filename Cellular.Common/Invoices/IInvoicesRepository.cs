using Cellular.Common.Invoices.Models;

namespace Cellular.Common.Invoices
{
    public interface IInvoicesRepository
    {
        SingleLineUsageDetails[] GetClientUsageDetails(int clintId, int year, int month);
    }
}
