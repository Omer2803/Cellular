namespace Cellular.Common.Invoices.Models
{
    /// <summary>
    /// Serves as a DTO to be sent form a client side to a server,
    /// which contains data needed for getting an invoice. 
    /// </summary>
    public class GetInvoiceModel
    {
        public int ClientId { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }
    }
}
