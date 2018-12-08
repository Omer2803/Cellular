using Cellular.Common.Invoices;
using Cellular.Common.Invoices.Models;
using System;
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
        [Route("api/simulator/NumbersOf/{clientId}")]
        public IHttpActionResult NumbersOf(int clientId)
        {
            try
            {
                var numbers = simulator.NumbersOf(clientId);
                if (numbers == null || numbers.Length == 0)
                    return BadRequest("The given client does not have lines. ");
                return Ok(numbers);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("api/Simulator/SimulateCalls")]
        public IHttpActionResult SimulateCalls([FromBody] SimulatorCalls calls)
        {
            try
            {
                simulator.SimulateCalls(calls);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("api/Simulator/SimulateSMSes")]
        public IHttpActionResult SimulateSMSes([FromBody] SimulatorSMSes smses)
        {
            try
            {
                simulator.SimulateSMSes(smses);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
