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
        private readonly IBIRepository bIRepository;

        public BIStatistics(IBIRepository bIRepository)
        {
            this.bIRepository = bIRepository;
        }

        public Employee[] BestSellers()
        {
            throw new NotImplementedException();
        }

        public Client[] MostCallingToServiceCenter()
        {
            throw new NotImplementedException();
        }

        public Client[] MostProfitableClients()
        {
            throw new NotImplementedException();
        }

        public Client[] PotentialFriendsGroups()
        {
            throw new NotImplementedException();
        }
    }
}
