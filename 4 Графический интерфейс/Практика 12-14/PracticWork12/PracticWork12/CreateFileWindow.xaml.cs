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

namespace PracticWork12
{
    /// <summary>
    /// Логика взаимодействия для CreateFileWindow.xaml
    /// </summary
    public partial class CreateFileWindow : Window
    { 
         private MainWindow window;
         private string text;
    
        public CreateFileWindow(MainWindow window, string text)
        {
            InitializeComponent();
            this.window = window;
            this.text = text;
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            var path = "data\\" + fileNameBox.Text;
            if (!Directory.Exists("data")) Directory.CreateDirectory("data");
            if (File.Exists(path)) MessageBox.Show("Такой файл уже существует");
            else
            {
                File.WriteAllText(path, text);
                window.OpenFileDialog(path);
                window.Show();
                this.Close();
            }
        }
        public string FileName
        {
            get { return fileNameBox.Text; }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            window.Show();
            this.Close();
        }
    }
}
