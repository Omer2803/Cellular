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
                Id = 1,
                FirstName = "Omer",
                LastName = "Cohen",
                Password = "1",
                Rank = EmployeeRank.Manager
            };
            var emp2 = new Employee()
            {
                Id = 2,
                FirstName = "Tomer",
                LastName = "Zaguri",
                Password = "1",
                Rank = EmployeeRank.Manager
            };
            var client1 = new Client()
            {
                FirstName = "Yarin",
                Id = 1,
                ClientTypeId = ClientTypeEnum.Private,
                LastName = "Dolev",
                Password = "1",
                RegisteredBy = 1,
                Registrator = emp,
                RegisterationDate = DateTime.Now
            };
            var client2 = new Client()
            {
                FirstName = "Yarin",
                Id = 2,
                ClientTypeId = ClientTypeEnum.Private,
                LastName = "Dolev",
                Password = "1",
                RegisteredBy = 1,
                Registrator = emp,
                RegisterationDate = DateTime.Now
            };
            var client3 = new Client()
            {
                FirstName = "Yarin",
                Id = 5,
                ClientTypeId = ClientTypeEnum.Private,
                LastName = "Dolev",
                Password = "1",
                RegisteredBy = 1,
                Registrator = emp,
                RegisterationDate = DateTime.Now
            };
            var client4 = new Client()
            {
                FirstName = "Yarin",
                Id = 3,
                ClientTypeId = ClientTypeEnum.Private,
                LastName = "Dolev",
                Password = "1",
                RegisteredBy = 1,
                Registrator = emp,
                RegisterationDate = DateTime.Now
            };
            var client5 = new Client()
            {
                FirstName = "Avi",
                Id = 4,
                ClientTypeId = ClientTypeEnum.Business,
                LastName = "Hadad",
                Password = "1",
                RegisteredBy = 2,
                Registrator = emp2,
                RegisterationDate = DateTime.Now

            };
            context.Employees.Add(emp);
            context.Employees.Add(emp2);
            context.Clients.Add(client1);
            context.Clients.Add(client2);
            context.Clients.Add(client3);
            context.Clients.Add(client4);
            context.Clients.Add(client5);
            context.Lines.AddRange(new[]
            {
                new Line
                {
                    ClientId = client1.Id,
                     PhoneNumber = "050"
                },
                new Line
                {
                      ClientId = client1.Id,
                    PhoneNumber = "052"
                },
                new Line
                {
                      ClientId = client1.Id,
                    PhoneNumber = "053"
                },
                new Line
                {
                      ClientId = client2.Id,
                    PhoneNumber = "054"
                },
                new Line
                {
                      ClientId = client2.Id,
                    PhoneNumber = "056"
                },
                new Line
                {
                    ClientId = client3.Id,
                    PhoneNumber="09"
                }
            });
            context.Calls.AddRange(new[]
            {
                new Call
                {
                     Id=1,
                     CallerNumber = "054",
                      DestinationNumber = "09",
                       StartTime = DateTime.Now
                },
                new Call
                {
                    Id=2,
                     CallerNumber = "052",
                      DestinationNumber = "09",
                       StartTime = DateTime.Now
                },
                new Call
                {
                    Id=3,
                     CallerNumber = "052",
                      DestinationNumber = "09",
                       StartTime = DateTime.Now
                },
                new Call
                {
                    Id=4,
                     CallerNumber = "052",
                      DestinationNumber = "09",
                       StartTime = DateTime.Now
                },
                new Call
                {
                    Id=5,
                     CallerNumber = "052",
                      DestinationNumber = "09",
                       StartTime = DateTime.Now
                }
            });

            context.SaveChanges();
        }
    }
}
