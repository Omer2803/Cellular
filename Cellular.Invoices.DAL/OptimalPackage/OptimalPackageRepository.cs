using Cellular.Common.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.Invoices.DAL.OptimalPackage
{
    public class OptimalPackageRepository : IOptimalPackageRepository
    {
        public SingleLineInvoiceData GetDataOfLine(string lineNumber, DateTime from, DateTime until)
        {
            throw new NotImplementedException();
        }
    }
}
