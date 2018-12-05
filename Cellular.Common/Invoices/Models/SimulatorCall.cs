using System;
using System.Collections.Generic;
using System.Text;

namespace Cellular.Common.Invoices.Models
{
    public class SimulatorCalls
    {
        public string CallerNumber { get; set; }

        public DestinationOption DestinationOption { get; set; }

        public TimeSpan MaxDuration { get; set; }

        public TimeSpan MinDuration { get; set; }

        public int Simulations { get; set; }
    }
}
