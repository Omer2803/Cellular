using Cellular.Common.Invoices;
using Cellular.Common.Invoices.Models;
using Cellular.Common.Models;
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

        [HttpGet]
        public IHttpActionResult NumbersOf(int clientId)
        {
            var numbers = simulator.NumbersOf(clientId);
            if (numbers == null || numbers.Length == 0)
                BadRequest();
            return Ok(numbers);
        }

        [HttpPost]
        public IHttpActionResult AddCalls(SimulatorCalls calls)
        {
            try
            {
                simulator.SimulateCalls(calls);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddSMSes(SimulatorSMSes smses)
        {
            try
            {
                simulator.SimulateSMSes(smses);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
