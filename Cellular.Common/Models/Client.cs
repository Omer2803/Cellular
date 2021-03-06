﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cellular.Common.Models
{
    public class Client
    {
        public int Id { get; set; }

        public ClientTypeEnum ClientTypeId { get; set; }
        public ClientType ClientType { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int RegisteredBy { get; set; }
        public Employee Registrator { get; set; }

        public string Password { get; set; }
        public DateTime RegisterationDate { get; set; }

    }
}
