using Cellular.Common.Models;

namespace Cellular.Common.Invoices.Models
{
    /// <summary>
    /// Contains all the the data needed in order to calculate an invoice for a specific line. 
    /// This type is intented to be a DTO that contains a specific line usage details that is needed for 
    /// initializing coresponding PackageInfo and OutOfOpackage DTOs in an other bussines logic opration. 
    /// </summary>
    public class SingleLineUsageDetails
    {
        public string LineNumber { get; set; }

        public ClientTypeEnum ClientType { get; set; }

        public Package Package { get; set; }

        public Call[] Calls { get; set; }

        public SMS[] SMSes { get; set; }
    }
}
