namespace Cellular.Common.Invoices.Models
{
    public class PackageInfo
    {
        public double? MinuetsLeft { get; set; }

        public int? SMSesLeft { get; set; }

        public double? MinuetsUsagePercentage { get; set; }

        public double? SMSesUsagePercentage { get; set; }

        public double? MinutesToFriends { get; set; }
    }
}
