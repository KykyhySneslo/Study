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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PracticWork12
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isSave = false;
        private string currentFile;

        public MainWindow()
        {
            InitializeComponent();
            var files = new DirectoryInfo("data").GetFiles();
            foreach (var f in files)
            {
                ListBox.Items.Add("data\\" + f.Name);
            }
        }

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                var text = File.ReadAllText(dialog.FileName);
                textBox.Text = text;

                isSave = false;
                setStatusBar();
            }
        }
        private async void MenuSave_Click(object sender, RoutedEventArgs e)
        {
                Save();  
        }
        private void MenuDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteFile();
        }
        public void OpenFileDialog(string path)
        {
            var text = File.ReadAllText(path);
            textBox.Text = text;
            currentFile = path;

            ListBox.Items.Add(path);
            isSave = false;
            setStatusBar();
        }
        public async void Save()
        {
            var text = textBox.Text;
            if (currentFile == null) MessageBox.Show("Требутся сохранить файл");
            else
            {
                File.WriteAllText(currentFile, text);
                isSave = false;
                setStatusBar();
            }
        }
        void DeleteFile()
        {
            var file = ListBox.SelectedItem as string;
            File.Delete(file);
            ListBox.Items.Remove(file);
        }
        private void newFileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CreateFileWindow(this, textBox.Text);
            dialog.Show();
            Hide();
        }
        private void textBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

            int row = textBox.GetLineIndexFromCharacterIndex(textBox.CaretIndex);
            int col = textBox.CaretIndex - textBox.GetCharacterIndexFromLineIndex(row);
        }
        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var path = ListBox.SelectedItem as string;
            var text = File.ReadAllText(path);
            textBox.Text = text;
            currentFile = path;
        }
        private void setStatusBar()
        {
            int row = textBox.GetLineIndexFromCharacterIndex(textBox.CaretIndex);
            int col = textBox.CaretIndex - textBox.GetCharacterIndexFromLineIndex(row);
            tb_status.Text = "Line " + (row + 1) + ", Char " + (col + 1);
            if (isSave)
            {
                NeedSave.Text = "Требуется сохранение";
            }
            else NeedSave.Text = "Сохранено";
            if (currentFile != null)
            {
                var fileInfo = new FileInfo(currentFile);
                tb_date.Text = fileInfo.LastWriteTime.ToString("dd.MM.yyyy hh.mm");
                tb_size.Text = string.Format("{0} Kb", fileInfo.Length);
            }
        }

        private void ItalicButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.FontStyle != FontStyles.Italic) textBox.FontStyle = FontStyles.Italic;
            else textBox.FontStyle = FontStyles.Normal;
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.FontWeight != FontWeights.Bold) textBox.FontWeight = FontWeights.Bold;
            else textBox.FontWeight = FontWeights.Normal;
        }

        private void UnderlineButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.TextDecorations != TextDecorations.Underline) textBox.TextDecorations = TextDecorations.Underline;
            else textBox.TextDecorations = null;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isSave = true;
            setStatusBar();
        }
    }
}
