using System;
using System.Collections.Generic;
using System.Text;

namespace Cellular.Common.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime Date { get; set; }
    }
}
