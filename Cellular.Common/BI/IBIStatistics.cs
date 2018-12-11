using Cellular.Common.BI.Models;
using Cellular.Common.Models;
using System.Collections.Generic;

namespace Cellular.Common.BI
{
    public interface IBIStatistics
    {
        List<MostValue> MostProfitableClients(int count);

        MostCallingToCenter[] MostCallingToServiceCenter(int count);

        BestSeller[] BestSellers(int count);

    }
}
