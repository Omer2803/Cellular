using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cellular.Common.Models
{
    public class Call
    {
        [Key]
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
