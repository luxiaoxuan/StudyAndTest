using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplicationTrial
{
    public class InputData : INotifyPropertyChanged, IDataErrorInfo//, INotifyDataErrorInfo
    {
        private Dictionary<string, string> _dic;


        private int _age;

        private string _name;

        private string _rai;


        public Dictionary<string, string> Dic
        {
            get
            {
                return _dic;
            }
            set
            {
                _dic = value;
            }
        }

        [Display(Name = "基準年齢")]
        public int BaselineAge { get; set; } = 32;

        [Display(Name = "年齢")]
        [CRange(18, 100, ErrorMessage = "{0}が{1}歳から{2}歳の間でなければなりません。", ValidationLevel = ValidationLevel.Error)]
        [CCompare("BaselineAge", ErrorMessage = "{0}が{1}と一致していません。", ValidationLevel = ValidationLevel.Warning)]
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                InvokePropertyChange(nameof(Age));
            }
        }

        [MaxLength(10, ErrorMessage = "長過ぎるよ！")]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                InvokePropertyChange(nameof(Name));
            }
        }

        [MaxLength(20, ErrorMessage = "長過ぎるよ！")]
        [CCompare("BaselineAge", ErrorMessage = "{0}が{1}と一致していません。", ValidationLevel = ValidationLevel.Error)]
        public string Rai
        {
            get
            {
                return _rai;
            }
            set
            {
                _rai = value;
                InvokePropertyChange(nameof(Rai));
            }
        }


        public string Error
        {
            get
            {
                return null;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public string this[string columnName]
        {
            get
            {
                var property = this.GetType().GetProperty(columnName);
                var value = property.GetValue(this, null);
                var results = new List<ValidationResult>();
                var vc = new ValidationContext(this);

                vc.MemberName = columnName;

                #region Method 2

                var vAttrs = property.GetCustomAttributes(true).Where(a => a is IValidationLevel).Cast<IValidationLevel>();
                var errorAttr = vAttrs.Where(a => a.ValidationLevel == ValidationLevel.Error).Cast<ValidationAttribute>();
                var warningAttr = vAttrs.Where(a => a.ValidationLevel == ValidationLevel.Warning).Cast<ValidationAttribute>();

                if (Validator.TryValidateValue(value, vc, results, errorAttr))
                {
                    if (Validator.TryValidateValue(value, vc, results, warningAttr))
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return "warning:" + Environment.NewLine + string.Join(Environment.NewLine, results.Select(r => r.ErrorMessage).ToArray());
                    }
                }
                else
                {
                    return "error:" + Environment.NewLine + string.Join(Environment.NewLine, results.Select(r => r.ErrorMessage).ToArray());
                }

                #endregion

                #region Method 1

                if (Validator.TryValidateProperty(value, vc, results))
                {
                    return string.Empty;
                }

                var errors = new List<ValidationResult>();
                results.ForEach((ValidationResult r) => {
                    if (!(r is CValidationResult) || ((CValidationResult)r).ValidationLevel == ValidationLevel.Error)
                    {
                        errors.Add(r);
                    }
                });

                var warnings = new List<ValidationResult>();
                results.ForEach((ValidationResult r) => {
                    if (r is CValidationResult && ((CValidationResult)r).ValidationLevel == ValidationLevel.Warning)
                    {
                        warnings.Add(r);
                    }
                });

                return errors.Count > 0 ?
                    "error:" + Environment.NewLine + string.Join(Environment.NewLine, errors.Select(r => r.ErrorMessage).ToArray()) :
                    "warning:" + Environment.NewLine + string.Join(Environment.NewLine, warnings.Select(r => r.ErrorMessage).ToArray());

                #endregion
            }
        }
    }
}
