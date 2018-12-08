using Cellular.Simulator.Client.ViewModels;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Cellular.Simulator.Client.UWP.Views
{
    public sealed partial class SimulatorView : Page
    {
        public SimulatorViewModel ViewModel { get; set; }

        public SimulatorView()
        {
            ViewModel = new SimulatorViewModel();
            ViewModel.ServiceNotAvilable += () =>
            {
                messagetbl.Foreground = new SolidColorBrush(Colors.Red);
                messagetbl.Text = "The service is not avilable";
            };

            this.InitializeComponent();
        }
    }
}
