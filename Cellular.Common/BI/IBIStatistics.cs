using Cellular.Common.Models;

namespace Cellular.Common.BI
{
    public interface IBIStatistics
    {
        Client[] MostProfitableClients();

        Client[] MostCallingToServiceCenter();

        Employee[] BestSellers();

        Client[] PotentialFriendsGroups();
    }
}
