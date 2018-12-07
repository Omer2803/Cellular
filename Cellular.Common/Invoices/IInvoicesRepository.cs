using Cellular.Common.Invoices.Models;
using System;

namespace Cellular.Common.Invoices
{
    public interface IInvoicesRepository
    {
        SingleLineUsageDetails[] GetClientUsageDetails(int clintId, DateTime from, DateTime until);
    }
}
