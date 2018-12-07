using System;

namespace Cellular.Common.Invoices.Models
{
    public class GetInvoiceModel
    {
        public int ClientId { get; set; }

        public DateTime From { get; set; }

        public DateTime Until { get; set; }
    }
}
