using System;

namespace Cellular.Common.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
    }
}
