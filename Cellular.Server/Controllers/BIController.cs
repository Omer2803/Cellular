using Cellular.Common.BI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cellular.Server.Controllers
{
    [RoutePrefix("api/BI")]
    public class BIController : ApiController
    {
        private readonly IBIStatistics _bIStatistics;

        public BIController(IBIStatistics bIStatistics)
        {
            this._bIStatistics = bIStatistics;
        }

        [HttpGet]
        [Route("GetBestSellers")]
        public IHttpActionResult GetBestSellers(int count)
        {
            try
            {
               var employees =  _bIStatistics.BestSellers(count);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetMostCallingToServiceCenter")]
        public IHttpActionResult GetMostCallingToServiceCenter(int count)
        {
            try
            {
                var clients = _bIStatistics.MostCallingToServiceCenter(count);
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetMostProfitableClients")]
        public IHttpActionResult GetMostProfitableClients(int count)
        {
            try
            {
                var clients = _bIStatistics.MostProfitableClients(count);
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
    }
}
