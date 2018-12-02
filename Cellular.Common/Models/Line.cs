using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cellular.Common.Models
{
   public class Line
    {
        [Key]
        public string PhoneNumber { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
}
