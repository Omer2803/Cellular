using System;
using Windows.UI.Xaml.Data;

namespace Cellular.Invoices.Client.UWP.Converters
{
    class StringToNullableIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var val = (int?)value;
            return val.HasValue ? val.Value.ToString() : string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (int.TryParse(value as string, out int result))
                return new int?(result);
            return null;
        }
    }
}

