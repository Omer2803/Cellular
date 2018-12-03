using Cellular.Common.Invoices;
using Cellular.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.Invoices.BL.OptimalPackage
{
    public class OptimalPackageCalculator : IOptimalPackageCalculator
    {
        private readonly IOptimalPackageRepository repository;
        private readonly IPriceList priceList;

        public OptimalPackageCalculator(IOptimalPackageRepository repository, IPriceList priceList)
        {
            this.repository = repository;
            this.priceList = priceList;
        }

        public Package[] GetOptimalPackagesFor(string lineNumber)
        {
            throw new NotImplementedException();
        }
    }
}
