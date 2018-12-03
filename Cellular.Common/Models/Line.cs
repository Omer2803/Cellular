using System.ComponentModel.DataAnnotations;

namespace Cellular.Common.Models
{
    public class Line
    {
        public string PhoneNumber { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
}
