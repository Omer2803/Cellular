using Cellular.Common.Invoices;
using Cellular.Common.Invoices.Models;
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
        private readonly IAuthenticator authenticator;

        public InvoicesController(IInvoicesProducer invoicesProducer, IAuthenticator authenticator)
        {
            this.invoicesProducer = invoicesProducer;
            this.authenticator = authenticator;
        }

        [HttpPost]
        [Route("api/Invoices/Login")]
        public IHttpActionResult TryLogin([FromBody] LoginModel model)
        {
            try
            {
                var result = authenticator.Login(model.Id, model.Password);
                return Json(result);
                //return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest("The service is not avilable. ");
            }
        }

        [HttpPost]
        [Route("api/Invoices/get")]
        public IHttpActionResult GetInvoiceOf([FromBody] GetInvoiceModel model)
        {
            try
            {
                var result = invoicesProducer.CreateInvoice(model.ClientId, model.From, model.Until);
                return Json(result);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
