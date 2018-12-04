using Cellular.Common.Models;
using Cellular.Simulator.Client.HttpClients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Cellular.Simulator.Client.ViewModels
{
    public class SimulatorViewModel : INotifyPropertyChanged
    {
        //private readonly INavigateable view;
        private readonly SimulatorHttpClient httpClient;

        public SimulatorViewModel(/*INavigateable view*/)
        {
            //this.view = view;
            httpClient = new SimulatorHttpClient();
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


        public void Simulate()
        {
            switch (isCall)
            {
                case true:
                    httpClient.PostCall(new Call
                    {
                        CallerNumber =
                    });
                    
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        enum Mode
        {
            SMS,
            Call
        }
    }
}
