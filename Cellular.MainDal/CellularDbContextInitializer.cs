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
            context.Employees.Add(emp);
            context.SaveChanges();
        }
    }
}
