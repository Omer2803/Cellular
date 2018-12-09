using Cellular.Common.BI.Models;
using Cellular.Common.Models;
using System.Collections.Generic;

namespace Cellular.Common.BI
{
    public interface IBIStatistics
    {
        List<MostValue> MostProfitableClients();

        MostCallingToCenter[] MostCallingToServiceCenter();

        BestSeller[] BestSellers();

        Client[] PotentialFriendsGroups();
    }
}
