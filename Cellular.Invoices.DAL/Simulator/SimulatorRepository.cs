using Cellular.Common.Invoices;
using Cellular.Common.Models;
using Cellular.MainDal;
using System.Linq;

namespace Cellular.Invoices.DAL.Simulator
{
    public class SimulatorRepository : ISimulatorRepository
    {
        public void AddCall(Call call)
        {
            using (var context = new CellularDbContext())
            {
                context.Calls.Add(call);
                context.SaveChanges();
            }
        }

        public void AddSMS(SMS sms)
        {
            using (var context = new CellularDbContext())
            {
                context.SMSes.Add(sms);
                context.SaveChanges();
            }
        }

        public string[] NumbersOf(int clientId)
        {
            using (var context = new CellularDbContext())
            {
                return context.Lines
                    .Where(l => l.ClientId == clientId)
                    .Select(l => l.PhoneNumber)
                    .ToArray();
            }
        }
    }
}
