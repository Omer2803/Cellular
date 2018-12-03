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
        private readonly IClientsRepository _clientsRepository;

        public ClientsManager(IClientsRepository clientsRepository)
        {
            this._clientsRepository = clientsRepository;
        }

        public void AddClient(Client client)
        {
            _clientsRepository.AddClient(client);
        }

        public void DeleteClient(int clientId)
        {
            _clientsRepository.DeleteClient(clientId);
        }

        public void EditClient(Client client)
        {
            _clientsRepository.EditClient(client);
        }
    }
}
