using Cellular.Common.CRM;
using Cellular.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.CRM.BL
{
    public class ClientsManager : IClientsManager
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
        
        public Client EditClient(Client client)
        {
             return _clientsRepository.EditClient(client);
        }
        
        public List<Client> GetAllClients()
        {
            return _clientsRepository.GetAllClients();
        }
        
        public Client GetClientById(int id)
        {
            return _clientsRepository.GetClientById(id);
        }
    }
}
