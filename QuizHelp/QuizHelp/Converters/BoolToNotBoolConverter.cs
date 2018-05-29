using System;
using System.Globalization;
using Xamarin.Forms;

namespace QuizHelp.Converters
{
    public class BoolToNotBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = value as bool?;
            return result != null && result.HasValue ? !result.Value : result.Value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
