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

        public bool HasWarning
        {
            get
            {
                return (bool)GetValue(HasWarningProperty);
            }
            set
            {
                SetValue(HasWarningProperty, value);
            }
        }

        public static readonly DependencyProperty HasWarningProperty = DependencyProperty.Register(
            "HasWarning", typeof(bool), typeof(AlphanumericTextBox));

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

            //Trace.WriteLine(DateTime.Now.ToShortTimeString() + ": " + e.Property.Name);

            if ("Text" == e.Property.Name || "Errors" == e.Property.Name)
            {
                var errors = Validation.GetErrors(this);
                if (errors.Count > 0)
                {
                    var error = errors.First();

                    this.HasWarning = error.ErrorContent.ToString().StartsWith("warning:");
                }
            }
        }
    }
}
