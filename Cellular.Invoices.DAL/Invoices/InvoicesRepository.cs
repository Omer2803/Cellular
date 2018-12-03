using Cellular.Common.Invoices;
using Cellular.MainDal;
using System;
using System.Linq;

namespace Cellular.Invoices.DAL.Invoices
{
    public class InvoicesRepository : IInvoicesRepository
    {
        public SingleLineInvoiceData[] GetClientData(int clintId, DateTime from, DateTime until)
        {
            using (var context = new CellularDbContext())
            {
                return context.Lines
                    .Where(l => l.ClientId == clintId)
                    .Select(l => l.PhoneNumber)
                    .Join(context.Packages,
                          number => number,
                          pack => pack.LineNumber,
                          (number, pack) => new { Number = number, Package = pack })
                    .GroupJoin(context.Calls.Where(c => c.StartTime >= from && c.StartTime <= until),
                               np => np.Number,
                               c => c.CallerNumber,
                               (np, calls) => new { NP = np, Calls = calls })
                    .GroupJoin(context.SMSes.Where(s => s.SendingTime >= from && s.SendingTime <= until),
                               npc => npc.NP.Number,
                               s => s.SenderNumber,
                               (nps, smses) => new SingleLineInvoiceData
                               {
                                   LineNumber = nps.NP.Number,
                                   Package = nps.NP.Package,
                                   Calls = nps.Calls.ToArray(),
                                   SMSes = smses.ToArray()
                               })
                    .ToArray();
            }
        }
    }
}
