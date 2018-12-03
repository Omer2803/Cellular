using Cellular.Common.Models;

namespace Cellular.Common.Invoices
{
    public class SingleLineInvoiceData
    {
        public string LineNumber { get; set; }

        public Package Package { get; set; }

        public Call[] Calls { get; set; }

        public SMS[] SMSes { get; set; }
    }
}
