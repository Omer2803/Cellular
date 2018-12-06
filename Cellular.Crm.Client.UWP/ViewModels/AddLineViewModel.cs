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

        #region PackageAndLine

        private List<Line> _lines;
        public List<Line> Lines
        {
            get { _lines = _crmBlClient.GetLinesByClientId(ClientId); return _lines; }
            set {  _lines = value; Notify(nameof(Lines)); }
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

        private int? _maxMinutes;
        public int? MaxMinutes
        {
            get { return _maxMinutes; }
            set { _maxMinutes = value; Notify(nameof(MaxMinutes)); }
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

        private int? _maxSms;
        public int? MaxSms
        {
            get { return _maxSms; }
            set { _maxSms = value; Notify(nameof(MaxSms)); }
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
            // Lines = _crmBlClient.GetLinesByClientId(ClientId);
        }

        public void AddLine(object sender, RoutedEventArgs e)
        {
            Package package = null;
            if (IncludesPackage)
            {
                package = AddPackageToLine();
            }
            _crmBlClient.AddNewLine(PhoneNumber, ClientId, package);

        }

        private Package AddPackageToLine()
        {
            Package newPackage = new Package();
            if (IncludesMiutes)
            {
                newPackage.MaxMinutes = MaxMinutes;
            }
            if (IncludesSms)
            {
                newPackage.MaxSMS = MaxSms;
            }
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

        private void CalculateTotalPrice(int? maxMinutes, int? maxSms, bool includesFriends)
        {
            var priceMinutes = (double)MaxMinutes / 2;
            TotalPrice += priceMinutes;
            var priceSms = (double)MaxSms / 2;
            TotalPrice += priceSms;
            if (IncludesFriends)
            {
                TotalPrice += 20;
            }
            else
            {
                TotalPrice -= 20;
            }
        }
    }
}
