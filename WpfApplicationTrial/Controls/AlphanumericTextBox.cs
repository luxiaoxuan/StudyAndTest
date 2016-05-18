using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApplicationTrial.Controls
{
    public class AlphanumericTextBox : TextBox
    {
        public string InputRule { get; set; }

        public bool HasWarning { get; set; }


        public AlphanumericTextBox() : base()
        {
            Validation.AddErrorHandler(this, (object sender, ValidationErrorEventArgs e) => {
                e.Error.ErrorContent += "～♡";
            });
        }

        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, this.InputRule))
            {
                e.Handled = true;
                return;
            }

            base.OnTextInput(e);
        }


        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if ("Errors" == e.Property.Name)
            {
                var errors = Validation.GetErrors(this);
            }
        }
    }
}
