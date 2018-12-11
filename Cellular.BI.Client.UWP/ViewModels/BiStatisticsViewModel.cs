using Cellular.Common.BI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using models = Cellular.Common.Models;

namespace Cellular.BI.Client.UWP.ViewModels
{
    public class BiStatisticsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private const int TOPGROUP = 10;

        private BiBLClient _biBlClient = new BiBLClient();

        public List<MostValue> MostProfitableClients
        {
            get
            {
                return _biBlClient.MostProfitableClients(TOPGROUP);
            }
           
        }

        public MostCallingToCenter[] MostCallingToServiceCenter
        {
            get
            {
                return _biBlClient.MostCallingToServiceCenter(TOPGROUP);
            }
        }

        public BestSeller[] BestSellers
        {
            get
            {
                return _biBlClient.BestSellers(TOPGROUP);
            }
        }
    }
}
