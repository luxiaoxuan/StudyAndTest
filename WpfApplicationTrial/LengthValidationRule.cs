using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApplicationTrial
{
    public class LengthValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;
            if (string.IsNullOrEmpty(str))
            {
                return ValidationResult.ValidResult;
            }

            return str.Length > 10 ?
                new ValidationResult(false, "Too long!") :
                ValidationResult.ValidResult;
        }
    }
}
