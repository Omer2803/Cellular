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

        [HttpPost]
        [Route("AddNewLine")]
        public IHttpActionResult AddLine(Line line)
        {
            try
            {
                _linesManager.AddLine(line);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddNewPackage")]
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

        [HttpPut]
        [Route("EditPackage")]
        public IHttpActionResult EditPackage([FromBody]Package package)
        {
            try
            {
                var packagEdited = _linesManager.EditPackage(package);
                return Ok(packagEdited);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetPackageOfLine")]
        public IHttpActionResult GetPackageOfLine(string lineNumber)
        {
            try
            {
                var packageOfLine = _linesManager.GetPackageOfLine(lineNumber);
                return Ok(packageOfLine);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
