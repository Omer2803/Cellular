using Cellular.Common.Models;
using Cellular.CRM.Client.UWP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
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

        #region PackageAndLineProperties

        private List<Line> _lines;
        public List<Line> Lines
        {
            get { _lines = _crmBlClient.GetLinesByClientId(ClientId); return _lines; }
            set { _lines = value; Notify(nameof(Lines)); }
        }

        private bool _includesPackage;
        public bool IncludesPackage
        {
            get { return _includesPackage; }
            set { _includesPackage = value; Notify(nameof(IncludesPackage)); }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; Notify(nameof(PhoneNumber)); }
        }

        private double _totalPrice;
        public double TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; Notify(nameof(TotalPrice)); }
        }

        private int _maxMinutes;
        public int MaxMinutes
        {
            get { return _maxMinutes; }
            set
            {
                if (!int.TryParse(value.ToString(), out _maxMinutes))
                {
                    _maxMinutes = 0;
                };
                CalculateTotalPrice();
                Notify(nameof(MaxMinutes));
            }
        }

        private int _maxSms;
        public int MaxSms
        {
            get { return _maxSms; }
            set
            {
                if (!int.TryParse(value.ToString(), out _maxSms))
                {
                    _maxSms = 0;
                };
                CalculateTotalPrice();
                Notify(nameof(MaxSms));
            }
        }

        private bool _includesMiutes;
        public bool IncludesMiutes
        {
            get { return _includesMiutes; }
            set { _includesMiutes = value; Notify(nameof(IncludesMiutes)); }
        }

        private bool _includesSms;
        public bool IncludesSms
        {
            get { return _includesSms; }
            set { _includesSms = value; Notify(nameof(IncludesSms)); }
        }

        public int PackageId { get; set; }

        private string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; Notify(nameof(Error)); }
        }

        private bool _includesFriends;
        public bool IncludesFriends
        {
            get { return _includesFriends; }
            set { _includesFriends = value; Notify(nameof(IncludesFriends)); }
        }

        private string _number1;
        public string Number1
        {
            get { return _number1; }
            set { _number1 = value; Notify(nameof(Number1)); }
        }

        private string _number2;
        public string Number2
        {
            get { return _number2; }
            set { _number2 = value; Notify(nameof(Number2)); }
        }

        private string _number3;
        public string Number3
        {
            get { return _number3; }
            set { _number3 = value; Notify(nameof(Number3)); }
        }

        private void Notify(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #endregion

        public AddLineViewModel(Page page)
        {
            this._page = page;
            _crmBlClient = new CrmBlClient();
        }

        public void AddLine(object sender, RoutedEventArgs e)
        {
            Package package = null;
            Line lineSelected = (Line)((Button)sender).CommandParameter;
            if (lineSelected == null)
            {
                lineSelected = new Line()
                {
                    PhoneNumber = PhoneNumber,
                    ClientId = ClientId
                };
            }
            if (IncludesPackage)
            {
                package = AddPackageToLine();
            }
            try
            {
                _crmBlClient.AddNewLinePlusPackage(lineSelected, package);
                InitSuccussMessage();
                _page.Frame.Navigate(typeof(ClientsView));
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }

        }

        private async void InitSuccussMessage()
        {
            MessageDialog messageDialog = new MessageDialog("The line and package added successfully");
            await messageDialog.ShowAsync();
            //Lines =_crmBlClient.GetLinesByClientId(ClientId);

        }

        public void GetPackageOfLine(object sender, SelectionChangedEventArgs e)
        {
            Line line = (Line)((ComboBox)sender).SelectedItem;
            PhoneNumber = line.PhoneNumber;
            Package package = _crmBlClient.GetPackageOfLine(PhoneNumber);
            SetPropertiesDefault();
            if (package != null)
            {
                PackageId = package.Id;
                IncludesMiutes = package.IncludesMinuets;
                if (IncludesMiutes)
                {
                    MaxMinutes = (int)package.MaxMinuets;
                }
                IncludesSms = package.IncludesSMSes;
                if (IncludesSms)
                {
                    MaxSms = (int)package.MaxSMSes;
                }
                IncludesFriends = package.IncludesFriends;
                if (IncludesFriends)
                {
                    Number1 = package.Number1;
                    Number2 = package.Number2;
                    Number3 = package.Number3;
                }
                TotalPrice = package.TotalPrice;
            }
        }

        private void SetPropertiesDefault()
        {
            IncludesFriends = default(bool);
            IncludesMiutes = default(bool);
            IncludesSms = default(bool);
            IncludesPackage = default(bool);
            Number1 = string.Empty;
            Number2 = string.Empty;
            Number3 = string.Empty;
            MaxMinutes = 0;
            MaxSms = 0;
            TotalPrice = 0;
        }

        public void ClearProperties(object sender, RoutedEventArgs e)
        {
            SetPropertiesDefault();
        }

        public void RaiseFriendsPriceToTotalPrice(object sender, RoutedEventArgs e)
        {
            TotalPrice += 20;
        }

        public void DecraseFriendsPriceToTotalPrice(object sender, RoutedEventArgs e)
        {
            TotalPrice -= 20;
        }

        private Package AddPackageToLine()
        {
            Package newPackage = new Package();
            newPackage.Id = PackageId;
            newPackage.IncludesMinuets = IncludesMiutes;
            if (IncludesMiutes)
            {
                newPackage.MaxMinuets = MaxMinutes;
            }
            newPackage.IncludesSMSes = IncludesSms;
            if (IncludesSms)
            {
                newPackage.MaxSMSes = MaxSms;
            }
            newPackage.IncludesFriends = IncludesFriends;
            if (IncludesFriends)
            {
                newPackage.Number1 = Number1;
                newPackage.Number2 = Number2;
                newPackage.Number3 = Number3;
            }
            newPackage.LineNumber = PhoneNumber;
            newPackage.TotalPrice = TotalPrice;
            return newPackage;
        }

        private void CalculateTotalPrice()
        {
            TotalPrice = 0;
            if (MaxMinutes != 0)
            {
                double priceMinutes = 0;
                priceMinutes = (double)MaxMinutes / 2;
                TotalPrice += priceMinutes;
            }
            if (MaxSms != 0)
            {
                double priceSms = 0;
                priceSms = (double)MaxSms / 2;
                TotalPrice += priceSms;
            }
        }

        public void SavePackageChanges(object sender, RoutedEventArgs e)
        {
            try
            {
                Line lineSelected = (Line)((Button)sender).CommandParameter;
                PhoneNumber = lineSelected.PhoneNumber;
                var packageEdited = AddPackageToLine();
                packageEdited = _crmBlClient.SavePackageChanges(packageEdited);
                if (packageEdited != null)
                {
                    InitSuccussMessage();
                }
                else
                {
                    Error = "Cannot update this package";
                }

            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }

        }

        public void NavigateToClientsView(object sender, RoutedEventArgs e)
        {
            _page.Frame.Navigate(typeof(ClientsView));
        }

    }
}
