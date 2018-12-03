using Cellular.Common.Models;

namespace Cellular.Common.Invoices
{
    public interface IOptimalPackageCalculator
    {
        Package[] GetOptimalPackagesFor(string lineNumber);
    }
}
