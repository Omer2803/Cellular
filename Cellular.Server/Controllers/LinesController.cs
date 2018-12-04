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
    public class LinesController : ApiController
    {
        private readonly ILinesManager _linesManager;

        public LinesController(ILinesManager linesManager)
        {
            this._linesManager = linesManager;
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

        public IHttpActionResult AddPackage(Package package)
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

        public IHttpActionResult EditPackage(Package package)
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


    }
}
