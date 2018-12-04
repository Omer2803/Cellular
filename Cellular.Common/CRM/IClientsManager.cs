using System.Collections.Generic;
using Cellular.Common.Models;

namespace Cellular.Common.CRM
{
    public interface IClientsManager
    {
        void AddClient(Client client);

        void EditClient(Client client);

        void DeleteClient(int ClientId);
        Client GetClientById(int id);
        List<Client> GetAllClients();
    }
}
