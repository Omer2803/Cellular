namespace Cellular.Common.Invoices.Models
{
    /// <summary>
    /// Represents an invoice for a single specific line.  
    /// Serves as a DTO to be sent to a client side.
    /// </summary>
    public class SingeLineInvoice
    {
        public SingleLineUsageDetails UsageDetails { get; set; }

        public PackageUsage PackageInfo { get; set; }

        public OutOfPackage OutOfPackage { get; set; }

        public double TotalPrice { get; set; }
    }
}
