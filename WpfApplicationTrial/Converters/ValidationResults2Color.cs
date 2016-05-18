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
    [ValueConversion(typeof(CValidationResult[]), typeof(Brush))]
    public class ValidationResults2Color : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CValidationResult[])
            {
                var results = value as CValidationResult[];

                if (results.Count(r => r.ValidationLevel == ValidationLevel.Error) == 0 &&
                    results.Count(r => r.ValidationLevel == ValidationLevel.Warning) > 0)
                {
                    return Brushes.Yellow;
                }
            }

            return Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
