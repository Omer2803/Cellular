﻿using Cellular.CRM.Client.UWP.ViewModels;
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
    public sealed partial class AddClientView : Page
    {
        public AddClientViewModel AddClientViewModel;
        private int _employeeId;
        public AddClientView()
        {
            this.InitializeComponent();
            AddClientViewModel = new AddClientViewModel(this);
            AddClientViewModel.EmployeeId = _employeeId;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _employeeId = (int)e.Parameter;
        }
    }
}