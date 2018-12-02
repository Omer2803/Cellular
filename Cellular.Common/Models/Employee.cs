using System;
using System.Collections.Generic;
using System.Text;

namespace Cellular.Common.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmployeeRank Rank { get; set; }
        public string Password { get; set; }
    }
}
