using System.Collections.Generic;
using Cellular.Common.Models;

namespace Cellular.Common.CRM
{
    public interface IClientsManager
    {
        /// <summary>
        /// Add new Client
        /// </summary>
        /// <param name="client">
        /// The client should be added to database.
        /// </param>
        void AddClient(Client client);
        /// <summary>
        /// Edit Client Details
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        Client EditClient(Client client);
        /// <summary>
        /// Get client details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Client GetClientById(int id);
        /// <summary>
        /// Get all clients
        /// </summary>
        /// <returns></returns>
        List<Client> GetAllClients();
    }
}
