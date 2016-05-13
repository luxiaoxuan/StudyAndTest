﻿using System;
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
        private int _age;

        private string _name;


        [Range(18, 100, ErrorMessage = "年齢が18歳から100歳の間でなければなりません。")]
        public int Age
        {
            get
            {
                return this._age;
            }
            set
            {
                this._age = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Age"));
                }
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

                var vc = new ValidationContext(this);
                vc.MemberName = columnName;
                var results = new List<ValidationResult>();
                if (Validator.TryValidateProperty(property.GetValue(this, null), vc, results))
                {
                    return string.Empty;
                }
                return string.Join(Environment.NewLine, results.Select(r => r.ErrorMessage).ToArray());
            }
        }

    }
}
