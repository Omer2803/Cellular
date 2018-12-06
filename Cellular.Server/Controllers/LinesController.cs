using Cellular.Common.CRM;
using Cellular.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cellular.Server.Controllers
{
    [RoutePrefix("api/Lines")]
    public class LinesController : ApiController
    {
        private readonly ILinesManager _linesManager;

        public LinesController(ILinesManager linesManager)
        {
            this._linesManager = linesManager;
        }

        [HttpGet]
        [Route("GetLinesByClientId")]
        public IHttpActionResult GetLinesByClientId(int clientId)
        {
            try
            {
               List<Line> lines= _linesManager.GetLinesByClientId(clientId);
                return Ok(lines);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult AddLine(int clientId, Line line)
        {
            try
            {
                _linesManager.AddLine(clientId, line);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route(Name = "AddPackage")]
        public IHttpActionResult AddPackage([FromBody]Package package)
        {
            try
            {
                _linesManager.AddPackage(package);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route(Name = "EditPackage")]
        public IHttpActionResult EditPackage([FromBody]Package package)
        {
            try
            {
                var packagEdited = _linesManager.EditPackage(package);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
