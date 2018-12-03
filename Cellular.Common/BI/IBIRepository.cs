using Cellular.Common.Models;

namespace Cellular.Common.BI
{
    public interface IBIRepository
    {
        Client[] MostProfitableClients();

        Client[] MostCallingToServiceCenter();

        Employee[] BestSellers();

        Client[] PotentialFriendsGroups();
    }
}
