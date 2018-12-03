using Cellular.Common.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cellular.Server.Controllers
{
    public class ClientsController : ApiController
    {
        private readonly IClientsManager clientsManager;
        private readonly IAuthenticator _authenticator;

        public ClientsController(IClientsManager clientsManager, IAuthenticator authenticator)
        {
            this.clientsManager = clientsManager;
            this._authenticator = authenticator;
        }

        public IHttpActionResult LoginEmployee(int Id, string password)
        {
            try
            {
                var employee = _authenticator.Login(Id, password);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
