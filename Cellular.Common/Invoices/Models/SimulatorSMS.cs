namespace Cellular.Common.Invoices.Models
{
    /// <summary>
    ///  Serves as a DTO to be sent from a client side to a server, which
    ///  encapsulates needed data for starting the process of SMSes simulation. 
    /// </summary>
    public class SimulatorSMSes
    {
        public string SenderNumber { get; set; }

        public int Simulations { get; set; }

        public DestinationOption DestinationOption { get; set; }
    }
}
