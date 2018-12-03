using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cellular.Common.Invoices;

namespace Cellular.Server.Controllers
{
    public class OptimalPackageController : ApiController
    {
        private readonly IOptimalPackageCalculator optimalPackageCalculator;

        public OptimalPackageController(IOptimalPackageCalculator optimalPackageCalculator)
        {
            this.optimalPackageCalculator = optimalPackageCalculator;
        }
    }
}
