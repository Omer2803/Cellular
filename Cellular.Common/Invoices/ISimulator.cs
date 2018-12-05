using Cellular.Common.Models;

namespace Cellular.Common.Invoices
{
    public interface ISimulator
    {
        void AddCall(Call call);

        void AddSMS(SMS sms);

        string[] NumbersOf(int clientId);
    }
}
