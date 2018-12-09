using Cellular.Common.BI.Models;
using Cellular.Common.Models;
using System.Collections.Generic;

namespace Cellular.Common.BI
{
    public interface IBIRepository
    {
        List<MostValue> MostProfitableClients();

        MostCallingToCenter[] MostCallingToServiceCenter();

        BestSeller[] BestSellers();

        Client[] PotentialFriendsGroups();
    }
}
