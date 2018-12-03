using Cellular.Common.Models;

namespace Cellular.Common.Invoices
{
    public interface IPriceList
    {
        double GetCallMinuetPrice(ClientTypeEnum clientType);

        double GetSMSPrice(ClientTypeEnum clientType);
    }
}
