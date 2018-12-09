namespace Cellular.Common.Invoices.Models
{
    public class SingeLineInvoice
    {
        public SingleLineUsageDetails UsageDetails { get; set; }

        public PackageInfo PackageInfo { get; set; }

        public OutOfPackage OutOfPackage { get; set; }

        public double TotalPrice { get; set; }
    }
}
