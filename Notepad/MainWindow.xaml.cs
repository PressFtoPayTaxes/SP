using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
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
using System.Windows.Forms;

namespace Notepad
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    [Synchronization]
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if(File.Exists(_defaultFilePath))
            {
                using (var reader = new StreamReader(_defaultFilePath))
                {
                    string fileText = reader.ReadToEnd();
                    if (fileText.Length >= 1)
                        text.Text = fileText;
                }
            }

            _autoSaveTimer = new System.Threading.Timer(AutoSave, null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(10));

        }

        private int _scale = 0;
        private int _shownScale = 100;
        private string _defaultFilePath = @"C:\Безымянный.txt";
        private string _filePath = @"C:\Безымянный.txt";
        private System.Threading.Timer _autoSaveTimer;

        private void AutoSave(object path)
        {
            string stringText = null;
            Dispatcher.Invoke(() => stringText = text.Text);

            if (stringText == null || stringText == string.Empty)
                return;

            var filePath = path as string;

            using (var writer = new StreamWriter(_filePath))
            {
                writer.WriteLine(stringText);
            }
        }

        private void ChangeFilePath()
        {
            Microsoft.Win32.SaveFileDialog dialogBox = new Microsoft.Win32.SaveFileDialog();
            dialogBox.AddExtension = true;
            dialogBox.DefaultExt = "*.txt";
            dialogBox.ShowDialog();
            File.Delete(_filePath);
            _filePath = dialogBox.FileName;
        }

        private void SaveMessageBoxShow()
        {
            var result = System.Windows.MessageBox.Show($"Вы хотите сохранить изменения в файле {_filePath}?", "Блокнот", MessageBoxButton.YesNoCancel);

            switch (result)
            {
                case MessageBoxResult.None:
                    break;
                case MessageBoxResult.OK:
                    break;
                case MessageBoxResult.Cancel:
                    break;
                case MessageBoxResult.Yes:
                    if (_filePath == _defaultFilePath)
                        ChangeFilePath();

                    AutoSave(null);
                    text.Clear();
                    _filePath = _defaultFilePath;
                    break;
                case MessageBoxResult.No:
                    text.Clear();
                    _filePath = _defaultFilePath;
                    break;
                default:
                    break;
            }
        }

        private void StatusBarCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            statusBar.Visibility = Visibility.Visible;
        }

        private void StatusBarCheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            statusBar.Visibility = Visibility.Collapsed;
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            if ((text.Text == null || text.Text == string.Empty) && _filePath == _defaultFilePath)
                return;

            SaveMessageBoxShow();
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _autoSaveTimer.Dispose();
        }

        private void WrapCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            text.TextWrapping = TextWrapping.Wrap;
        }

        private void WrapCheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            text.TextWrapping = TextWrapping.NoWrap;
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            SaveMessageBoxShow();

            Microsoft.Win32.OpenFileDialog dialogBox = new Microsoft.Win32.OpenFileDialog();
            dialogBox.ShowDialog();
            _filePath = dialogBox.FileName;

            using (var reader = new StreamReader(_filePath))
            {
                text.Text = reader.ReadToEnd();
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            AutoSave(null);
        }

        private void SaveAs(object sender, RoutedEventArgs e)
        {
            ChangeFilePath();
            AutoSave(null);
        }

        private void Print(object sender, RoutedEventArgs e)
        {
            SaveMessageBoxShow();
            var dialogBox = new System.Windows.Controls.PrintDialog();
            dialogBox.ShowDialog();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            SaveMessageBoxShow();
            Environment.Exit(0);
        }

        private void ChangeFont(object sender, RoutedEventArgs e)
        {
            FontDialog dialogBox = new FontDialog();
            dialogBox.ShowDialog();

            FontFamilyConverter converter = new FontFamilyConverter();
            text.FontFamily = converter.ConvertFromString(dialogBox.Font.Name) as FontFamily;
            if (dialogBox.Font.Size + _scale > 0)
                text.FontSize = dialogBox.Font.Size + _scale;
            else
                text.FontSize = 1;
        }

        private void IncreaseScale(object sender, RoutedEventArgs e)
        {
            if(_shownScale <= 200)
            {
                _scale += 2;
                _shownScale += 10;
                scaleTextBlock.Text = "%" + _shownScale;
                text.FontSize += 2;
            }
        }

        private void DecreaseScale(object sender, RoutedEventArgs e)
        {
            if(_shownScale >= 10)
            {
                _scale -= 2;
                _shownScale -= 10;
                scaleTextBlock.Text = "%" + _shownScale;
                if (text.FontSize - 2 >= 1)
                    text.FontSize += 2;
                else
                    text.FontSize = 1;
            }
        }

        private void SetDefaultScale(object sender, RoutedEventArgs e)
        {
            _shownScale = 100;
            scaleTextBlock.Text = "%100";
            if (text.FontSize - _scale >= 1)
                text.FontSize -= _scale;
            else
                text.FontSize = 1;
            _scale = 0;
        }

        private void ShowProgramInfo(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Данное приложение сделано на WPF просто по преколу.", "Блокнот");
        }
    }
}
