using System;
using Windows.UI.Xaml.Data;

namespace Cellular.Invoices.Client.UWP.Converters
{
    class DateTimeToShortStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language) => ((DateTime)value).Date.ToShortDateString();

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
