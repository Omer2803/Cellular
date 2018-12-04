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

        public void EditClient(Client client)
        {
            using (var db = new CellularDbContext())
            {
                var clientEdited = db.Clients.FirstOrDefault(c => c.Id == client.Id);
                clientEdited = client;
                db.Entry(client).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
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
