using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cellular.Common.Models
{
    public class Call
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Caller))]
        public string CallerNumber { get; set; }
        public Line Caller { get; set; }
        [ForeignKey(nameof(Dest))]
        public string DestinationNumber { get; set; }
        public Line Dest { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration  { get; set; }
    }
}
