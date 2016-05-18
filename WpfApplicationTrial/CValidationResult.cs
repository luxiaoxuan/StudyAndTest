using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplicationTrial
{
    public class CValidationResult : ValidationResult, IValidationLevel
    {
        public ValidationLevel ValidationLevel { get; set; }


        public CValidationResult(string errorMessage) : base(errorMessage) { }

        public CValidationResult(string errorMessage, IEnumerable<string> memberNames) : base(errorMessage, memberNames) { }

        public CValidationResult(ValidationResult validationResult) : base(validationResult) { }
    }
}
