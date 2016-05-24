using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApplicationTrial.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    public class ValidationError2Display : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                var msg = value.ToString();
                if (msg.StartsWith("error:"))
                {
                    return msg.Substring(8);
                }
                else if (msg.StartsWith("warning:"))
                {
                    return msg.Substring(10);
                }
                else
                {
                    return msg;
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
