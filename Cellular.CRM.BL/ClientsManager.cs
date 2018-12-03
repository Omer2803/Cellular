using Cellular.Common.CRM;
using Cellular.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.CRM.BL
{
    class ClientsManager : IClientsManager
    {
        private readonly IClientsRepository clientsRepository;

        public ClientsManager(IClientsRepository clientsRepository)
        {
            this.clientsRepository = clientsRepository;
        }

        public void AddClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void DeleteClient(int ClientId)
        {
            throw new NotImplementedException();
        }

        public void EditClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
