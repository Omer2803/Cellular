using Cellular.Common.CRM;
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
        private readonly ILinesManager linesManager;

        public LinesController(ILinesManager linesManager)
        {
            this.linesManager = linesManager;
        }
    }
}
