using Cellular.Common.Invoices.Models;
using Cellular.Common.Models;

namespace Cellular.Common.Invoices
{
    public interface ISimulatorRepository
    {
        void AddCall(Call call);

        void AddSMS(SMS sms);

        string[] NumbersOf(int clientId);

        string[] FriendsOf(string lineNumber);

        string[] GetRandomNumbersFor(string number, DestinationOption destinationOption, int amount);
    }
}
