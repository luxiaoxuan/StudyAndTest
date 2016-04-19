using LXXTestSite.Tests;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace WpfApplicationTrial
{
    /// <summary>
    /// WebUnitTestWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class WebUnitTestWindow : Window
    {
        private string _inputFilePath;


        public WebUnitTestWindow()
        {
            InitializeComponent();
        }

        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            var result = dlg.ShowDialog();
            if (result.HasValue && result.Value)
            {
                this._inputFilePath = dlg.FileName;
                this.txtFile.Text = new FileInfo(this._inputFilePath).Name;
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            new SeleniumTest().InputForm(this._inputFilePath);

            MessageBox.Show("テストが完了しました。");
        }
    }
}
