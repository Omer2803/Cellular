using Cellular.Common.Models;

namespace Cellular.Common.Invoices
{
    public interface ISimulatorRepository
    {
        void AddCall(Call call);

        void AddSMS(SMS sms);
    }
}
