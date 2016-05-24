using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplicationTrial
{
    public class InputData : INotifyPropertyChanged, IDataErrorInfo
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
        public int BaselineAge { get; set; }

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
                InvokePropertyChange("Age");
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
                InvokePropertyChange("Name");
            }
        }

        [MaxLength(20, ErrorMessage = "長過ぎるよ！")]
        [CCompare("BaselineAge", ErrorMessage = "{0}が{1}と一致していません。", ValidationLevel = ValidationLevel.Error)]
        public string Rai
        {
            get
            {
                return this._rai;
            }
            set
            {
                this._rai = value;
                InvokePropertyChange("Rai");
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
            }
        }
    }
}
