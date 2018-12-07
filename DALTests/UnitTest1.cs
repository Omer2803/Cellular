using System;
using Cellular.Common.Models;
using Cellular.MainDal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DALTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateDB()
        {
            using (var context = new CellularDbContext())
            {
                //context.Database.Delete();
                context.Database.Create();
            }
        }

        [TestMethod]
        public void InitDB()
        {
            using (var context = new CellularDbContext())
            {
                context.Database.Initialize(true);
            }
        }

        [TestMethod]
        public void AddingData()
        {
            using (var context = new CellularDbContext())
            {
                Employee olegEmp = new Employee
                {
                    Id = 1234,
                    FirstName = "Oleg",
                    LastName = "Firumianz",
                    Password = "12345",
                    Rank = EmployeeRank.CustomerRepresentative
                },
                ItamarEmp = new Employee
                {
                    Id = 4444,
                    FirstName = "Itamar",
                    LastName = "Daisy",
                    Password = "2222",
                    Rank = EmployeeRank.Manager
                };

                Client nirCli = new Client
                {
                    ClientTypeId = ClientTypeEnum.VIP,
                    Id = 3133,
                    FirstName = "Nir",
                    LastName = "London",
                    Password = "1",
                    Registrator = olegEmp,
                    RegisterationDate = DateTime.Now.AddDays(-40)
                },
                shahafCli = new Client
                {
                    Id = 1111,
                    Registrator = ItamarEmp,
                    FirstName = "Shahaf",
                    LastName = "Dahan",
                    ClientTypeId = ClientTypeEnum.Business,
                    Password = "333",
                    RegisterationDate = DateTime.Now.AddDays(-60)
                };

                Line nirLine1; 

                //context.Clients

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void AddingClientWithEmployyeId()
        {
            using (var context = new CellularDbContext())
            {
                var OdedEmp = new Employee
                {
                    FirstName = "Oded",
                    LastName = "Bartov",
                    Id = 8888,
                    Password = "22",
                    Rank = EmployeeRank.CustomerRepresentative
                };

                var ilanCli = new Client
                {
                    RegisteredBy = OdedEmp.Id,
                    Id = 4646,
                    FirstName = "Ilan",
                    LastName = "Rozenfeld",
                    ClientTypeId = ClientTypeEnum.VIP,
                    Password = "aaa",
                    RegisterationDate = DateTime.Now.AddDays(-600)
                };

                context.Employees.Add(OdedEmp);
                context.Clients.Add(ilanCli);

                context.SaveChanges();
            }
        }
    }
}
