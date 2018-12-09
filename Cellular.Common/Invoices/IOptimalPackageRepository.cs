using Cellular.Common.Invoices.Models;
using System;

namespace Cellular.Common.Invoices
{
    public interface IOptimalPackageRepository
    {
        SingleLineUsageDetails GetDataOfLine(string lineNumber, DateTime from, DateTime until);
    }
}
