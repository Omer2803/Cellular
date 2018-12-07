using Cellular.Common.Models;

namespace Cellular.Common.Invoices.Models
{
    public class SingleLineUsageDetails
    {
        public string LineNumber { get; set; }

        public ClientTypeEnum ClientType { get; set; }

        public Package Package { get; set; }

        public Call[] Calls { get; set; }

        public SMS[] SMSes { get; set; }
    }
}
