using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplicationTrial
{
    public class CCompareAttribute : CompareAttribute, IValidationLevel
    {
        public ValidationLevel ValidationLevel { get; set; }


        public CCompareAttribute(string otherProperty) : base(otherProperty) { }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var result = new CValidationResult(base.IsValid(value, validationContext));
            result.ValidationLevel = this.ValidationLevel;

            return result;
        }
    }
}
