using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using UserApp.Classes;
using UserApp.Models;
using UserApp.Window.Registration;
using System.ComponentModel;

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class WndReg : System.Windows.Window
    {
        public WndReg()
        {
            InitializeComponent();
            RegFrame.Navigate(new PgFNm(this));
            ManagerPg.WndReg = this;
            BackgroundWorker worker = new();
            worker.DoWork += DoWork;
            worker.RunWorkerAsync();
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
        public void UpdateStatus()
        {
            if (DB.stateConnection == false)
                Dispatcher.Invoke(() => StatusInternet.Source = new BitmapImage(new Uri(Path.GetFullPath("../../../Resources/no-internet.png"))));
            else
                Dispatcher.Invoke(() => StatusInternet.Source = new BitmapImage(new Uri(Path.GetFullPath("../../../Resources/internet.png"))));
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow back = new();
            back.Show();
            Close();
        }
        private void BtnMin_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void BtnClose_Click(object sender, RoutedEventArgs e) => Close();
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) => UpdateStatus();
    }
}
