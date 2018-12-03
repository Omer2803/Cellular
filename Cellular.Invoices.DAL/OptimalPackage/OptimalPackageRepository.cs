using Cellular.Common.Invoices;
using Cellular.MainDal;
using System;
using System.Linq;

namespace Cellular.Invoices.DAL.OptimalPackage
{
    public class OptimalPackageRepository : IOptimalPackageRepository
    {
        public SingleLineInvoiceData GetDataOfLine(string lineNumber, DateTime from, DateTime until)
        {
            using (var context = new CellularDbContext())
            {
                var package = context.Packages.FirstOrDefault(p => p.LineNumber == lineNumber);

                var calls = context.Calls
                    .Where(c => c.CallerNumber == lineNumber && c.StartTime >= from && c.StartTime <= until)
                    .ToArray();

                var smses = context.SMSes
                    .Where(s => s.SenderNumber == lineNumber && s.SendingTime >= from && s.SendingTime <= until)
                    .ToArray();

                return new SingleLineInvoiceData
                {
                    LineNumber = lineNumber,
                    Package = package,
                    Calls = calls,
                    SMSes = smses
                };
            }
        }
    }
}
