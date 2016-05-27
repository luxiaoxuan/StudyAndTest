using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplicationTrial
{
    public class CRangeAttribute : RangeAttribute, IValidationLevel
    {
        public ValidationLevel ValidationLevel { get; set; }


        public CRangeAttribute(int minimum, int maximum) : base(minimum, maximum) { }

        public CRangeAttribute(double minimum, double maximum) : base(minimum, maximum) { }

        public CRangeAttribute(Type type, string minimum, string maximum) : base(type, minimum, maximum) { }


        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    return base.IsValid(value) ?
        //        ValidationResult.Success :
        //        new CValidationResult(base.FormatErrorMessage(validationContext.DisplayName)) { ValidationLevel = this.ValidationLevel };
        //}
    }
}
