using Cellular.CRM.Client.UWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Cellular.CRM.Client.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClientsView : Page
    {
        private int _employeeId;
        public ClientsViewModel ClientsViewModel;

        public ClientsView()
        {
            this.InitializeComponent();
            ClientsViewModel = new ClientsViewModel(this);
            ClientsViewModel.EmployeeId = _employeeId;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _employeeId = (int)e.Parameter;
        }
    }
}
