using System;

namespace Cellular.Common.Invoices.Models
{
    /// <summary>
    /// Serves as a DTO to be sent from a client side to a server, which
    /// encapsulates needed data for starting the process of calls simulation. 
    /// </summary>
    public class SimulatorCalls
    {
        public string CallerNumber { get; set; }

        public DestinationOption DestinationOption { get; set; }

        public TimeSpan MaxDuration { get; set; }

        public TimeSpan MinDuration { get; set; }

        public int Simulations { get; set; }
    }
}
