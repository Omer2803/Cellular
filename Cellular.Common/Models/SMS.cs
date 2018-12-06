using System;

namespace Cellular.Common.Models
{
    public class SMS
    {
        public int Id { get; set; }

        public string SenderNumber { get; set; }
        public Line Sender { get; set; }

        public string DestinationNumber { get; set; }
        public Line Dest { get; set; }

        public DateTime SendingTime { get; set; }
    }
}
