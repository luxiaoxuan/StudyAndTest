using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplicationTrial
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public InputData Data { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            this.Data = new InputData
            {
                Name = "Daibobo",
                BaselineAge = 25,
            };
            this.Data.Dic = new Dictionary<string, string>();
            this.Data.Dic.Add("rai", "RAI");
            this.Data.Dic.Add("cnc", "CNC");

            this.DataContext = this.Data;
            //this.txtName.SetBinding(TextBox.TextProperty, new Binding("Name") { Source = this.Data, });
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Data.Name = "Bode!";
            MessageBox.Show(this.Data["Age"]);
        }

        private void txtAge_Error(object sender, ValidationErrorEventArgs e)
        {

        }
    }
}
