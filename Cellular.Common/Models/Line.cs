using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cellular.Common.Models
{
    public class Line
    {
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
}
