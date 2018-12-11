using System;
using System.Linq;
using Cellular.MainDal;
using Cellular.Common.Invoices;
using Cellular.Common.Invoices.Models;

namespace Cellular.Invoices.DAL.Invoices
{
    public class InvoicesRepository : IInvoicesRepository
    {
        /// <summary>
        /// Gets the usage detail of a specific client for all of his line. 
        /// </summary>
        /// <param name="clintId">The id of the client</param>
        /// <param name="year">The year of usage details</param>
        /// <param name="month">The month of usage details</param>
        /// <returns></returns>
        public SingleLineUsageDetails[] GetClientUsageDetails(int clintId, int year, int month)
        {
            using (var context = new CellularDbContext())
            {
                DateTime start = new DateTime(year, month, 1), end = start.AddMonths(1);

                var clientType = context.Clients.Find(clintId).ClientTypeId;

                return context.Lines
                    .Where(l => l.ClientId == clintId)
                    .Select(l => l.PhoneNumber)
                    .GroupJoin(context.Packages,
                          number => number,
                          pack => pack.LineNumber,
                          (number, pack) => new { Number = number, Package = pack.FirstOrDefault() })
                    .GroupJoin(context.Calls.Where(c => c.StartTime >= start && c.StartTime <= end),
                               np => np.Number,
                               c => c.CallerNumber,
                               (np, calls) => new { NP = np, Calls = calls })
                    .GroupJoin(context.SMSes.Where(s => s.SendingTime >= start && s.SendingTime <= end),
                               npc => npc.NP.Number,
                               s => s.SenderNumber,
                               (nps, smses) => new /*SingleLineUsageDetails*/
                               {
                                   LineNumber = nps.NP.Number,
                                   ClientType = clientType,
                                   Package = nps.NP.Package,
                                   SMSes = smses/*.ToArray()*/,
                                   Calls = nps.Calls/*.ToArray()*/,
                               })
                    .ToArray()
                    .Select(a => new SingleLineUsageDetails
                    {
                        LineNumber = a.LineNumber,
                        ClientType = a.ClientType,
                        Package = a.Package,
                        SMSes = a.SMSes.ToArray(),
                        Calls = a.Calls.ToArray(),
                    })
                    .ToArray();
            }
        }
    }
}
