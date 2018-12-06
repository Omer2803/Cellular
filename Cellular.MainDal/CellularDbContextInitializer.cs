using Cellular.Common.Models;
using System;
using System.Data.Entity;

namespace Cellular.MainDal
{
    class CellularDbContextInitializer : DropCreateDatabaseIfModelChanges<CellularDbContext>
    {
        protected override void Seed(CellularDbContext context)
        {
            context.ClientTypes.AddRange(new[]
            {
                new ClientType
                {
                    Id = ClientTypeEnum.Private,
                    CallMinutesPrice = 0.3,
                    SmsPrice = 0.2
                },
                new ClientType
                {
                    Id = ClientTypeEnum.Business,
                    CallMinutesPrice = 0.2,
                    SmsPrice = 0.13
                },
                new ClientType
                {
                    Id = ClientTypeEnum.VIP,
                    CallMinutesPrice = 0.15,
                    SmsPrice = 0.08
                }
            });

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
                ClientTypeId = ClientTypeEnum.Private,
                LastName = "Dolev",
                Password = "1",
                RegisteredBy = 3121,
                RegisterationDate = DateTime.Now
            };
            var client2 = new Client()
            {
                FirstName = "Avi",
                Id = 15,
                ClientTypeId = ClientTypeEnum.Business,
                LastName = "Hadad",
                Password = "1",
                RegisteredBy = 3121,
                RegisterationDate = DateTime.Now

            };
            context.Lines.AddRange(new[]
            {
                new Line
                {
                    Client = client1,
                     PhoneNumber = "051234567"
                },
                new Line
                {
                    Client = client1,
                    PhoneNumber = "057654321"
                },
                new Line
                {
                    Client = client1,
                    PhoneNumber = "053214321"
                },
                new Line
                {
                    Client = client2,
                    PhoneNumber = "051425367"
                },
                new Line
                {
                    Client = client2,
                    PhoneNumber = "056352417"
                }
            });
            context.Employees.Add(emp);
            context.Clients.Add(client1);
            context.Clients.Add(client2);
            context.SaveChanges();
        }
    }
}
