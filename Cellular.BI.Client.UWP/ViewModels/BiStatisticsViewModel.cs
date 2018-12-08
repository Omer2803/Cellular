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

        private BiBLClient _biBlClient = new BiBLClient();

        public models.Client[] MostProfitableClients
        {
            get
            {
                return MostProfitableClients = _biBlClient.MostProfitableClients();
            }
            set
            {

            }
        }

        public models.Client[] MostCallingToServiceCenter
        {
            get
            {
                return MostCallingToServiceCenter = _biBlClient.MostCallingToServiceCenter();
            }
            set
            {

            }
        }

        public models.Client[] PotentialFriendsGroups
        {
            get
            {
                return PotentialFriendsGroups = _biBlClient.PotentialFriendsGroups();
            }
            set
            {

            }
        }

        public models.Employee[] BestSellers
        {
            get
            {
                return BestSellers = _biBlClient.BestSellers();
            }
            set
            {

            }
        }







    }
}
