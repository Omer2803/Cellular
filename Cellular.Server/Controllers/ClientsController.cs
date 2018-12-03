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
    public class ClientsController : ApiController
    {
        private readonly IClientsManager _clientsManager;
        private readonly IAuthenticator _authenticator;

        public ClientsController(IClientsManager clientsManager, IAuthenticator authenticator)
        {
            this._clientsManager = clientsManager;
            this._authenticator = authenticator;
        }

        public IHttpActionResult LoginEmployee(int id, string password)
        {
            try
            {
                var employee = _authenticator.Login(id, password);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IHttpActionResult AddClient([FromBody]Client client)
        {
            try
            {
                _clientsManager.AddClient(client);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
