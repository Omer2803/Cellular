using System.Collections.Generic;
using Cellular.Common.Models;

namespace Cellular.Common.CRM
{
    public interface IClientsRepository
    {
        Client GetClientById(int clientId);        

        void AddClient(Client client);

        void DeleteClient(int clientId);

        void EditClient(Client client);
        List<Client> GetAllClients();
    }
}
