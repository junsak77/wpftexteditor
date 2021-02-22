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
using System.Windows.Shapes;

namespace TextEditor
{
    /// <summary>
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    public partial class Replace : Window
    {
        private MainWindow _main = null;

        public Replace(MainWindow main)
        {
            InitializeComponent();
            _main = main;
        }

        private void ExecReplace(object sender, RoutedEventArgs e)
        {
            string before = this.before.Text;
            string after = this.after.Text;

            _main.editArea.Text = _main.editArea.Text.Replace(before, after);
            
        }
    }
}
