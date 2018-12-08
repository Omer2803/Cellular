using Cellular.Common.CRM;
using Cellular.Common.Models;
using Cellular.MainDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.CRM.DAL
{
    class ClientsRepository : IClientsRepository
    {
        public void AddClient(Client client)
        {
            using (var db = new CellularDbContext())
            {
                db.Clients.Add(client);
                db.SaveChanges();
            }
        }

        public void DeleteClient(int clientId)
        {
            using (var db = new CellularDbContext())
            {
                var clientRemoved = db.Clients.FirstOrDefault(c => c.Id == clientId);
                db.Clients.Remove(clientRemoved);
                db.SaveChanges();
            }
        }

        public Client EditClient(Client client)
        {
            using (var db = new CellularDbContext())
            {
                var clientEdited = db.Clients.FirstOrDefault(c => c.Id == client.Id);
                clientEdited.FirstName = client.FirstName;
                clientEdited.LastName = client.LastName;
                clientEdited.Password = client.Password;
                clientEdited.ClientTypeId = client.ClientTypeId;
                db.SaveChanges();
                return clientEdited;
            }
        }

        public List<Client> GetAllClients()
        {
            using (var db = new CellularDbContext())
            {
                return db.Clients.ToList();
            }
        }

        public Client GetClientById(int clientId)
        {
            using (var db = new CellularDbContext())
            {
                return db.Clients.FirstOrDefault(c => c.Id == clientId);
            }
        }
    }
}
