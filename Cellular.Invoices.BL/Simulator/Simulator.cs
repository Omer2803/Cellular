using Cellular.Common.Invoices;
using Cellular.Common.Models;

namespace Cellular.Invoices.BL.Simulator
{
    public class Simulator : ISimulator
    {
        private readonly ISimulatorRepository repository;

        public Simulator(ISimulatorRepository repository)
        {
            this.repository = repository;
        }

        public void AddCall(Call call)
        {
            repository.AddCall(call);
        }

        public void AddSMS(SMS sms)
        {
            repository.AddSMS(sms);
        }

        public string[] NumbersOf(int clientId)
        {
            return repository.NumbersOf(clientId);
        }
    }
}
