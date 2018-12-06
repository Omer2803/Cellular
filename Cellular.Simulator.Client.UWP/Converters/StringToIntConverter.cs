using System;
using Windows.UI.Xaml.Data;

namespace Cellular.Simulator.Client.UWP.Converters
{
    class StringToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            int.TryParse((string)value, out int i);
            return  i;
        }
    }
}
