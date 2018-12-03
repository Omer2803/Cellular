using Cellular.Common.BI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cellular.Server.Controllers
{
    public class BIController : ApiController
    {
        private readonly IBIStatistics bIStatistics;

        public BIController(IBIStatistics bIStatistics)
        {
            this.bIStatistics = bIStatistics;
        }
    }
}
