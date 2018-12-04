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
        //[HttpGet]
        [Route(Name = "GetBestSellers")]
        public IHttpActionResult GetBestSellers()
        {
            try
            {
               var employees =  _bIStatistics.BestSellers();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpGet]
        [Route(Name = "GetMostCallingToServiceCenter")]
        public IHttpActionResult GetMostCallingToServiceCenter()
        {
            try
            {
                var clients = _bIStatistics.MostCallingToServiceCenter();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpGet]
        [Route(Name = "GetMostProfitableClients")]
        public IHttpActionResult GetMostProfitableClients()
        {
            try
            {
                var clients = _bIStatistics.MostProfitableClients();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpGet]
        [Route(Name = "GetPotentialFriendsGroups")]
        public IHttpActionResult GetPotentialFriendsGroups()
        {
            try
            {
                var clients = _bIStatistics.PotentialFriendsGroups();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
