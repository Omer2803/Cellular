using Cellular.Common.CRM;
using Cellular.Common.Models;
using Cellular.MainDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.CRM.DAL
{
    public class LoginDal : ILoginDal
    {
        public Employee Login(int Id, string password)
        {
            using (var db = new CellularDbContext())
            {
                return db.Employees.FirstOrDefault(e => e.Id == Id && e.Password == password);
            }
        }
    }
}
