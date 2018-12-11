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
       
        public BestSeller[] BestSellers(int count)
        {
            return _bIRepository.BestSellers(count);
        }

        public MostCallingToCenter[] MostCallingToServiceCenter(int count)
        {
            return _bIRepository.MostCallingToServiceCenter(count);
        }

        public List<MostValue> MostProfitableClients(int count)
        {
            return _bIRepository.MostProfitableClients(count);
        }

       
    }
}
