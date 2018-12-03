using Cellular.Common.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cellular.Server.Controllers
{
    public class SimulatorController : ApiController
    {
        private readonly ISimulator simulator;

        public SimulatorController(ISimulator simulator)
        {
            this.simulator = simulator;
        }
    }
}
