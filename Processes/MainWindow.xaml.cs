using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace Processes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<ProcessInfo> _processesInfo = new List<ProcessInfo>();

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = _processesInfo;

            var processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                _processesInfo.Add(new ProcessInfo
                {
                    Name = process.ProcessName,
                    Id = process.Id,
                    MachineName = process.MachineName,
                    MemorySize = process.VirtualMemorySize64
                });
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Process[] selectedProcesses;
            try
            {
                selectedProcesses = Process.GetProcessesByName((dataGrid.SelectedItem as ProcessInfo).Name);
            }
            catch (NullReferenceException)
            {
                return;
            }
            catch (ArgumentException)
            {
                return;
            }

            string processName = selectedProcesses[0].ProcessName;

            try
            {
                for (int i = 0; i < selectedProcesses.Count(); i++)
                {
                    selectedProcesses[i].Kill();
                }
                _processesInfo.RemoveAll((process) => process.Name == processName);
                dataGrid.ItemsSource = null;
                dataGrid.Items.Clear();
                dataGrid.ItemsSource = _processesInfo;
            }
            catch (Win32Exception)
            {
                MessageBox.Show("Этот процесс нельзя снять");
            }
        }
    }
}
