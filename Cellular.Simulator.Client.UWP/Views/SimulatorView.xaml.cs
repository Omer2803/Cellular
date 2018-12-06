using Cellular.Simulator.Client.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Cellular.Simulator.Client.UWP.Views
{
    public sealed partial class SimulatorView : Page
    {
        public SimulatorViewModel ViewModel { get; set; }

        public SimulatorView()
        {
            ViewModel = new SimulatorViewModel(); 

            this.InitializeComponent();
        }
    }
}
