using System;
using System.Collections.Generic;
using System.Text;

namespace Cellular.Common.Invoices.Models
{
    public class SimulatorSMSes
    {
        public string SenderNumber { get; set; }

        public int Simulations { get; set; }

        public DestinationOption DestinationOption { get; set; }
    }
}
