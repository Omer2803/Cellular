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
    [RoutePrefix("api/Clients")]
    public class ClientsController : ApiController
    {
        private readonly IClientsManager _clientsManager;
        private readonly IAuthenticator _authenticator;

        public ClientsController(IClientsManager clientsManager, IAuthenticator authenticator)
        {
            this._clientsManager = clientsManager;
            this._authenticator = authenticator;
        }

        [HttpGet]
        [Route("LoginEmployee")]
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
        [Route("AddClient")]
        public IHttpActionResult AddClient([FromBody]Client client)
        {
            try
            {
                _clientsManager.AddClient(client);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpDelete]
        public IHttpActionResult DeleteClient(int clientId)
        {
            try
            {
                _clientsManager.DeleteClient(clientId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        
        [HttpGet]
        [Route("GetClientDetails")]
        public IHttpActionResult GetClientDetails(int clientId)
        {
            try
            {
                Client client =  _clientsManager.GetClientById(clientId);
                return Ok(client);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetAllClients")]
        public IHttpActionResult GetAllClients()
        {
            try
            {
                List<Client> clients = _clientsManager.GetAllClients();
                return Ok(clients);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("EditClient")]
        public IHttpActionResult EditClient([FromBody]Client client)
        {
            try
            {
                 var clientEdited =_clientsManager.EditClient(client);
                return Ok(clientEdited);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





    }
}
