namespace Cellular.Common.Invoices.Models
{
    public class Invoice
    {
        public SingeLineInvoice[] LineInvoices { get; set; }

        public double AdditionalPrice { get; set; }

        public double TotalPrice { get; set; }
    }
}

