﻿using Cellular.Common.CRM;
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

        public ClientsController(IClientsManager clientsManager)
        {
            this.clientsManager = clientsManager;
        }
    }
}
