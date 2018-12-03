using Cellular.Common.Invoices;
using Cellular.Common.Models;
using Cellular.MainDal;

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
    }
}
