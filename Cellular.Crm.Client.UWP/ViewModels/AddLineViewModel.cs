using Cellular.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Cellular.CRM.Client.UWP.ViewModels
{
    public class AddLineViewModel : INotifyPropertyChanged
    {
        private readonly Page _page;
        private CrmBlClient _crmBlClient;
        public event PropertyChangedEventHandler PropertyChanged;
        public int ClientId { get; set; }
        private List<Line> _lines;

        public List<Line> Lines
        {
            get { return _lines; }
            set { _lines = value; Notify(nameof(Lines)); }
        }

        private void Notify(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }


        public AddLineViewModel(Page page)
        {
            this._page = page;
            _crmBlClient = new CrmBlClient();
            Lines = _crmBlClient.GetLinesByClientId(ClientId);
        }

        public void AddLine(object sender, RoutedEventArgs e)
        {

        }

        private Package AddPackageToLine(Package package)
        {

        }
    }
}
