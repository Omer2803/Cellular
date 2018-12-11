using Cellular.Common.BI;
using Cellular.Common.BI.Models;
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

        public BestSeller[] BestSellers(int count)
        {
            using (var db = new CellularDbContext())
            {
                return db.Employees
                    .Join(db.Clients, e => e.Id, c => c.RegisteredBy, (e, c) => new
                    {
                        EmplyeeId = e.Id,
                        c.RegisteredBy
                    })
                    .GroupBy(c => c.RegisteredBy)
                .Select(group => new BestSeller
                {
                    EmployeeId = group.Key,
                    ClientsCount = group.Count()
                })
                .OrderByDescending(e => e.ClientsCount)
                .Take(count)
                .ToArray();
            }
        }

        public MostCallingToCenter[] MostCallingToServiceCenter(int count)
        {
            using (var db = new CellularDbContext())
            {
                var dicCallToService = db.Calls.
                    Where(c => c.DestinationNumber == NUMBEROFCENTER)
                    .GroupBy(c => c.CallerNumber)
                    .Select(group => new MostCallingToCenter
                    {
                        CallerNumber = group.Key,
                        CallToCenterCount = group.Count()
                    }).OrderByDescending(c => c.CallToCenterCount)
                    .Take(count).ToArray();
                return dicCallToService;
            }
        }
        /// <summary>
        /// Formula to calculte the value client.
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        private double CalculateProfitableClient(int clientId)
        {
            using (var db = new CellularDbContext())
            {
                var countofLines = db.Lines.Count(l => l.ClientId == clientId);
                var countOfCallToCenter = db.Lines.Where(l => l.ClientId == clientId).ToArray()
                    .Sum(l => db.Calls.
                    Count(c => c.DestinationNumber == NUMBEROFCENTER &&
                    c.CallerNumber == l.PhoneNumber));
                return (countofLines * 0.2) + (countOfCallToCenter * -0.1);
            }
        }

        public List<MostValue> MostProfitableClients(int count)
        {
            using (var db = new CellularDbContext())
            {
                return db.Clients
                    .ToArray()
                    .Select(c => new MostValue
                    {
                        Client = c,
                        ValueGrade = CalculateProfitableClient(c.Id)
                    })
                    .OrderByDescending(c => c.ValueGrade)
                    .Take(count)
                    .ToList();
            }
        }

    }
}
