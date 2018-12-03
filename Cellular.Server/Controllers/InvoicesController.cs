using Cellular.Common.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cellular.Server.Controllers
{
    public class InvoicesController : ApiController
    {
        private readonly IInvoicesProducer invoicesProducer;

        public InvoicesController(IInvoicesProducer invoicesProducer)
        {
            this.invoicesProducer = invoicesProducer;
        }
    }
}
