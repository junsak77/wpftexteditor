using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

namespace TextEditor
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        // 保存用のファイルパスを保持する変数
        string filePath = @"C:\Users\佐久間 潤\Documents\text\editor.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // ファイルに書き込む
                writer.WriteLine(editArea.Text);
            }
        }

        private void SaveFileAs(object sender, RoutedEventArgs e)
        {
            // Configure save file dialog box
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "text"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "テキストファイル|*.txt"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                string fileName = dlg.FileName;
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    // ファイルに書き込む
                    writer.WriteLine(editArea.Text);
                }
            }
        }

        private void NewFile(object sender, RoutedEventArgs e)
        {
            editArea.Text = "";
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            // Configure save file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "text.txt"; // Default file name
            dlg.Filter = "テキストファイル|*.txt"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                string fileName = dlg.FileName;
                using (StreamReader reader = new StreamReader(fileName))
                {
                    // ファイルを読み込む
                    editArea.Text = reader.ReadToEnd();
                }

            }
        }

        private void Replace(object sender, RoutedEventArgs e)
        {
            Replace rpl = new Replace(this);
            rpl.Show();
        }
    }
}
