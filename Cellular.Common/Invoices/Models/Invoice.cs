using System;

namespace Cellular.Common.Invoices.Models
{
    /// <summary>
    /// Serves as a DTO that contains all the data needed for an invoice. 
    /// The properties of an instance of this type are meant to be calculated and set by 
    /// a business logic operation on a server side. 
    /// </summary>
    public class Invoice
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public SingeLineInvoice[] LineInvoices { get; set; }

        public double AdditionalPrice { get; set; }

        public double TotalPrice { get; set; }
    }
}

