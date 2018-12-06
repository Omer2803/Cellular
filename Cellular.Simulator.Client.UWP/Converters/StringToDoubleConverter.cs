using System;
using Windows.UI.Xaml.Data;

namespace Cellular.Simulator.Client.UWP.Converters
{
    class StringToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            double.TryParse((string)value, out double i);
            return i;
        }
    }
}
