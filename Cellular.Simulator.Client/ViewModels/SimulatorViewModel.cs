using Cellular.Common.Models;
using Cellular.Simulator.Client.HttpClients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.Simulator.Client.ViewModels
{
    public class SimulatorViewModel : INotifyPropertyChanged
    {
        //private readonly INavigateable view;
        private readonly SimulatorHttpClient httpClient;
        private readonly Random durationGenerator;

        public SimulatorViewModel(/*INavigateable view*/)
        {
            //this.view = view;
            httpClient = new SimulatorHttpClient();
            durationGenerator = new Random();
        }

        private int _clientId;
        public int ClientId
        {
            get => _clientId;
            set
            {
                _clientId = value;
                Numbers.Clear();
                httpClient.NumbersOf(value)
                    .ContinueWith(t =>
                    {
                        foreach (var num in t.Result)
                            Numbers.Add(num);
                        Notify();
                    });
            }
        }

        public ObservableCollection<string> Numbers { get; set; }

        private bool isCall;
        public bool IsCall
        {
            get { return isCall; }
            set
            {
                isCall = value;
                Notify();
            }
        }


        private string selectedNumber;
        public string SelectedNumber
        {
            get { return selectedNumber; }
            set { selectedNumber = value; }
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
            get => maxDuration;
            set
            {
                maxDuration = value;
                Notify();
            }
        }


        public async Task Simulate()
        {
            switch (isCall)
            {
                case true:
                    await httpClient.PostCall(new Call
                    {
                        CallerNumber = SelectedNumber,
                        Duration = TimeSpan.FromMinutes((durationGenerator.Next() / (double)int.MaxValue) * (maxDuration - minDuration) + minDuration),
                        StartTime = DateTime.Now
                    });
                    return;
                case false:
                    await httpClient.PostSMS(new SMS
                    {
                        SenderNumber = selectedNumber,
                        SendingTime = DateTime.Now,                        
                    });
                    return;
                default: throw new Exception();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
