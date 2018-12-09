using System;

namespace Cellular.Common.Invoices.Models
{
    public class Invoice
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public SingeLineInvoice[] LineInvoices { get; set; }

        public double AdditionalPrice { get; set; }

        public double TotalPrice { get; set; }
    }
}

