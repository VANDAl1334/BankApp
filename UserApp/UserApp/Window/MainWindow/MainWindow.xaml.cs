using System;
using System.IO;
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
using UserApp.Window.Registration;
using UserApp.Classes;
using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;

namespace UserApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DB.GetConnectionHosts();
            ManagerPg.MainWindow = this;
            BackgroundWorker worker = new();
            worker.DoWork += DoWork;
            worker.RunWorkerAsync();
        }
        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            WndReg reg = new();
            reg.Show();
            Close();
        }
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                DB.GetConnectionHosts();
                UpdateStatus();
                Thread.Sleep(2000);
            }
        }
        private void UpdateStatus()
        {
            if (DB.stateConnection == false)
                Dispatcher.Invoke(() => StatusInternet.Source = new BitmapImage(new Uri(Path.GetFullPath("../../../Resources/no-internet.png"))));
            else
                Dispatcher.Invoke(() => StatusInternet.Source = new BitmapImage(new Uri(Path.GetFullPath("../../../Resources/internet.png"))));
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e) => Close();
        private void BtnAut_Click(object sender, RoutedEventArgs e)
        {
            WndAut aut = new();
            aut.Show();
            Close();
        }
        private void BtnMin_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) => UpdateStatus();
    }
}
