using Cellular.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.MainDal
{
    class CellularDbContextInitializer : DropCreateDatabaseIfModelChanges<CellularDbContext>
    {
        protected override void Seed(CellularDbContext context)
        {
            var emp = new Employee()
            {
                Id = 3121,
                FirstName = "Omer",
                LastName = "Cohen",
                Password = "1",
                Rank = EmployeeRank.Manager
            };
            var client1 = new Client()
            {
                FirstName = "Yarin",
                Id = 12,
                LastName = "Dolev",
                Password = "1",
                RegisteredBy = 3121,
                RegisterationDate = DateTime.Now
            };
            var client2 = new Client()
            {
                FirstName = "Avi",
                Id = 15,
                LastName = "Hadad",
                Password = "1",
                RegisteredBy = 3121,
                RegisterationDate = DateTime.Now

            };
            context.Employees.Add(emp);
            context.Clients.Add(client1);
            context.Clients.Add(client2);
            context.SaveChanges();
        }
    }
}
