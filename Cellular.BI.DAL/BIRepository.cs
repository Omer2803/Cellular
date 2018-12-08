using Cellular.Common.BI;
using Cellular.Common.Models;
using Cellular.MainDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.BI.DAL
{
    public class BIRepository : IBIRepository
    {
        private const string NUMBEROFCENTER = "09";

        public Dictionary<int,int> BestSellers()
        {
            using (var db = new CellularDbContext())
            {
                var dicBestSeller = db.Employees
                    .Join(db.Clients, e => e.Id, c => c.RegisteredBy, (e, c) => new
                    {
                        EmplyeeId = e.Id,
                        c.RegisteredBy
                    })
                    .GroupBy(c => c.RegisteredBy)
                .Select(group => new
                {
                    Id = group.Key,
                    Count = group.Count()
                })
                .OrderByDescending(e => e.Count)
                .Take(10).ToDictionary(x => x.Id, y => y.Count);
                return dicBestSeller;
            }
        }

        public Dictionary<string,int> MostCallingToServiceCenter()
        {
            using (var db = new CellularDbContext())
            {
                var dicCallToService = db.Calls.
                    Where(c => c.DestinationNumber == NUMBEROFCENTER)
                    .GroupBy(c => c.CallerNumber)
                    .Select(group => new
                    {
                        CallerNumber = group.Key,
                        Count = group.Count()
                    }).OrderByDescending(c => c.Count)
                    .Take(10).ToDictionary(x=>x.CallerNumber,y=>y.Count);
                return dicCallToService;
            }
        }

        private double CalculateProfitableClient(int clientId)
        {
            using (var db = new CellularDbContext())
            {
                var countofLines = db.Lines.Count(l => l.ClientId == clientId);
                var countOfCallToCenter = db.Lines.Where(l => l.ClientId == clientId)
                    .Sum(l => db.Calls.
                    Count(c => c.DestinationNumber == NUMBEROFCENTER &&
                    c.CallerNumber == l.PhoneNumber));
               return (countofLines * 0.2) + (countOfCallToCenter * -0.1); // +invoices/1000
            }
        }

        public Dictionary<Client, double> MostProfitableClients()
        {
            using (var db = new CellularDbContext())
            {
                Dictionary<Client, double> dic = new Dictionary<Client, double>();
                foreach (var c in db.Clients)
                {
                    dic.Add(c, CalculateProfitableClient(c.Id));
                }
                var dicClient = dic.OrderByDescending(x => x.Value).Take(10)
                                      .ToDictionary(x => x.Key, x => x.Value);
                return dicClient;

               
            }
        }

        public Client[] PotentialFriendsGroups()
        {
            using (var db = new CellularDbContext())
            {
                var ab = db.Lines.Join(db.Calls, l => l.PhoneNumber, c => c.CallerNumber, (l, c) =>
                 new
                 {
                     PhoneNumber = l.PhoneNumber,
                     DestNumber = c.DestinationNumber
                 }).
                GroupBy(c => c.DestNumber)
                .Select(group => new
                {
                    DestinationNumber = group.Key,
                    Count = group.Count()
                }).OrderByDescending(x => x.Count).Take(3).ToArray();

                return null;
                
            }
        }
    }
}
