namespace Cellular.Common.Models
{
    public class Package
    {
        public int Id { get; set; }

        public string LineNumber { get; set; }
        public Line Line { get; set; }

        public double TotalPrice { get; set; }

        public bool InculdesMiutes { get; set; }
        public int? MaxMinutes { get; set; }

        public bool IncludesSMS { get; set; }
        public int? MaxSMS { get; set; }

        public bool IncludesFriends { get; set; }
        public string Number1 { get; set; }
        public string Number2 { get; set; }
        public string Number3 { get; set; }
    }
}
