using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cellular.Common.Models
{
    public class SMS
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Sender))]
        public string SenderNumber { get; set; }
        public Line Sender { get; set; }

        [ForeignKey(nameof(Dest))]
        public string DestinationNumber { get; set; }
        public Line Dest { get; set; }

        public DateTime SendingTime { get; set; }
    }
}
