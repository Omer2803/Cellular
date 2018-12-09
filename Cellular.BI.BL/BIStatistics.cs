using Cellular.Common.BI;
using Cellular.Common.BI.Models;
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
        /// <summary>
        /// jjjjjjj
        /// </summary>
        /// <returns>
        /// jhgh
        /// </returns>
        public BestSeller[] BestSellers()
        {
            return _bIRepository.BestSellers();
        }

        public MostCallingToCenter[] MostCallingToServiceCenter()
        {
            return _bIRepository.MostCallingToServiceCenter();
        }

        public List<MostValue> MostProfitableClients()
        {
            return _bIRepository.MostProfitableClients();
        }

        public Client[] PotentialFriendsGroups()
        {
            return _bIRepository.PotentialFriendsGroups();
        }
    }
}
