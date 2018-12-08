using Cellular.Common.Models;
using System.Collections.Generic;

namespace Cellular.Common.BI
{
    public interface IBIRepository
    {
        Dictionary<Client, double> MostProfitableClients();

        Dictionary<string, int> MostCallingToServiceCenter();

        Dictionary<int, int> BestSellers();

        Client[] PotentialFriendsGroups();
    }
}
