using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using UserApp.Classes;
using UserApp.Window.Authorization;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;
using System.Threading;

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class WndAut : System.Windows.Window
    {
        public WndAut()
        {
            InitializeComponent();           
            RecFrame.Navigate(new PgAut(this));
            BackgroundWorker worker = new();
            worker.DoWork += DoWork;
            worker.RunWorkerAsync();
        }
        public void UpdateStatus()
        {
            if (DB.stateConnection == false)
                Dispatcher.Invoke(() => StatusInternet.Source = new BitmapImage(new Uri(Path.GetFullPath("../../../Resources/no-internet.png"))));
            else
                Dispatcher.Invoke(() => StatusInternet.Source = new BitmapImage(new Uri(Path.GetFullPath("../../../Resources/internet.png"))));
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
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow back = new();
            back.Show();
            Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
        private void BtnMin_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void BtnClose_Click(object sender, RoutedEventArgs e) => Close();
        private void Window_Loaded(object sender, RoutedEventArgs e) => UpdateStatus();
    }
}
