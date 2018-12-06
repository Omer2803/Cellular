using Cellular.Common.Invoices.Models;
using Cellular.Simulator.Client.HttpClients;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Cellular.Simulator.Client.ViewModels
{
    public class SimulatorViewModel : INotifyPropertyChanged
    {
        private readonly SimulatorHttpClient httpClient;

        public SimulatorViewModel()
        {
            httpClient = new SimulatorHttpClient();
            numbers = new string[0];
            SendToOptions = Enum.GetNames(typeof(DestinationOption));

            isCall = true;
            isSMS = false;
        }

        private int clientId;
        public int ClientId
        {
            get => clientId;
            set
            {
                SetClientId(value);
                Notify();
            }
        }
        private async void SetClientId(int value)
        {
            clientId = value;
            Numbers = await httpClient.NumbersOf(value);
        }

        private string[] numbers;
        public string[] Numbers
        {
            get => numbers;
            set
            {
                numbers = value;
                Notify(nameof(Numbers));
            }
        }

        private bool isCall;
        public bool IsCall
        {
            get { return isCall; }
            set
            {
                isCall = value;
                isSMS = !value;
                Notify(nameof(IsSMS));
                Notify(nameof(IsCall));
            }
        }
        private bool isSMS;
        public bool IsSMS
        {
            get { return isSMS; }
            set
            {
                isSMS = value;
                isCall = !value;
                Notify(nameof(IsCall));
                Notify(nameof(IsSMS));
            }
        }

        private string selectedNumber;
        public string SelectedNumber
        {
            get => selectedNumber;
            set
            {
                selectedNumber = value;
                Notify(nameof(CanSimulate));
            }
        }

        private double minDuration;
        public double MinDuration
        {
            get => minDuration;
            set
            {
                minDuration = value;
                Notify();
            }
        }
        private double maxDuration;
        public double MaxDuration
        {
            get => maxDuration; set
            {
                maxDuration = value;
                Notify();
            }
        }

        private DestinationOption sendTo;

        public string SendTo
        {
            get => sendTo.ToString();
            set
            {
                sendTo = (DestinationOption)Enum.Parse(typeof(DestinationOption), value);
                Notify(nameof(CanSimulate));
            }
        }

        public string[] SendToOptions { get; }

        private int simulations;
        public int Simulations
        {
            get => simulations; set
            {
                simulations = value;
                Notify();
            }
        }

        public async Task Simulate()
        {
            if (!CanSimulate) return;
            switch (isCall)
            {
                case true:
                    await httpClient.SimulateCalls(new SimulatorCalls
                    {
                        CallerNumber = SelectedNumber,
                        DestinationOption = sendTo,
                        MinDuration = TimeSpan.FromMinutes(MinDuration),
                        MaxDuration = TimeSpan.FromMinutes(MaxDuration),
                        Simulations = Simulations
                    });
                    return;
                case false:
                    await httpClient.SimulateSMSes(new SimulatorSMSes
                    {
                        SenderNumber = SelectedNumber,
                        DestinationOption = sendTo,
                        Simulations = Simulations
                    });
                    return;
                default: throw new Exception();
            }
        }

        public bool CanSimulate
        {
            get
            {
                return SelectedNumber != null
                    && sendTo != 0
                    && clientId != 0
                    && simulations > 0
                    && (isCall ? (minDuration > 0 && maxDuration > minDuration) : true);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify([CallerMemberName] string propertyName = null)
        {
            if(propertyName != nameof(CanSimulate))Notify(nameof(CanSimulate));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
