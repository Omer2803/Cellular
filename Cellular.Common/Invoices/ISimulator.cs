using Cellular.Common.Invoices.Models;

namespace Cellular.Common.Invoices
{
    public interface ISimulator
    {
        void SimulateCalls(SimulatorCalls calls);

        void SimulateSMSes(SimulatorSMSes smses);

        string[] NumbersOf(int clientId);
    }
}
