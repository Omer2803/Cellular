namespace Cellular.Common.Invoices.Models
{
    /// <summary>
    /// Encapsulates data about the usage of a specific package. 
    /// This DTO properties are ment to be calculated on an external business logic operation on a server side. 
    /// </summary>
    public class PackageUsage
    {
        public double? MinuetsLeft { get; set; }

        public int? SMSesLeft { get; set; }

        public double? MinuetsUsagePercentage { get; set; }

        public double? SMSesUsagePercentage { get; set; }

        public double? FriendsMinuets { get; set; }
    }
}
