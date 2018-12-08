using Cellular.Common.BI;
using Cellular.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.BI.BL
{
    public class BIStatistics : IBIStatistics
    {
        private readonly IBIRepository _bIRepository;

        public BIStatistics(IBIRepository bIRepository)
        {
            this._bIRepository = bIRepository;
        }

        public Dictionary<int, int> BestSellers()
        {
            return _bIRepository.BestSellers();
        }

        public Dictionary<string, int> MostCallingToServiceCenter()
        {
            return _bIRepository.MostCallingToServiceCenter();
        }

        public Dictionary<Client, double> MostProfitableClients()
        {
            return _bIRepository.MostProfitableClients();
        }

        public Client[] PotentialFriendsGroups()
        {
            return _bIRepository.PotentialFriendsGroups();
        }
    }
}
