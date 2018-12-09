using System;
using System.Linq;
using Cellular.MainDal;
using Cellular.Common.Invoices;
using Cellular.Common.Invoices.Models;

namespace Cellular.Invoices.DAL.Invoices
{
    public class InvoicesRepository : IInvoicesRepository
    {
        public SingleLineUsageDetails[] GetClientUsageDetails(int clintId, DateTime from, DateTime until)
        {
            using (var context = new CellularDbContext())
            {
                var clientType = context.Clients.Find(clintId).ClientTypeId;

                return context.Lines
                    .Where(l => l.ClientId == clintId)
                    .Select(l => l.PhoneNumber)
                    .GroupJoin(context.Packages,
                          number => number,
                          pack => pack.LineNumber,
                          (number, pack) => new { Number = number, Package = pack.FirstOrDefault() })
                    .GroupJoin(context.Calls.Where(c => c.StartTime >= from && c.StartTime <= until),
                               np => np.Number,
                               c => c.CallerNumber,
                               (np, calls) => new { NP = np, Calls = calls })
                    .GroupJoin(context.SMSes.Where(s => s.SendingTime >= from && s.SendingTime <= until),
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
