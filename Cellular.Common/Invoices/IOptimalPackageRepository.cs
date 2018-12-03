using System;

namespace Cellular.Common.Invoices
{
    public interface IOptimalPackageRepository
    {
        SingleLineInvoiceData GetDataOfLine(string lineNumber, DateTime from, DateTime until);
    }
}
