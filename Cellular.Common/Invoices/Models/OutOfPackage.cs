namespace Cellular.Common.Invoices.Models
{ 
    /// <summary>
    /// Encapsulates data about a deviation from a specific package. 
    /// This DTO properties are meant to be calculated on an external business logic operation on a server side. 
    /// </summary>
    public class OutOfPackage
    {
        public double AdditionalMinuets { get; set; }

        public int AdditionalSMSes { get; set; }

        public double TotalAdditionalPrice { get; set; }
    }
}
