﻿using System;
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
using System.ComponentModel;
using System.Windows.Xps.Serialization;
using System.Windows.Threading;
using Google.Protobuf.WellKnownTypes;
using System.Windows.Media.Animation;
using UserApp.Window.Authorization;
using UserApp.Window.Main;

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    
    public partial class WndMain : System.Windows.Window
    {
        DispatcherTimer timer;
        bool hidden = true;
        private bool Frozen;
        private string Balance;
        private WndMain wndMain;

        public WndMain()
        {
            InitializeComponent();
            MainFrame.Navigate(new PgHome());
            timer = new();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;            
            login.Text = User.CurrentUser.login_user;                        
            Frozen = Bill.CurrentNumcard.Frozen;
            Balance = Bill.CurrentNumcard.Balance;
        }
        private void BtnMin_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void BtnClose_Click(object sender, RoutedEventArgs e) => Close();
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hidden)
            {
                Menu.Width += 8;
                if (Menu.Width >= 200)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                Menu.Width -= 8;
                if (Menu.Width <= 47)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }        
        private void BtnPanel_Click(object sender, RoutedEventArgs e) => timer.Start();       
        private void ListView_Home(object sender, MouseButtonEventArgs e) => MainFrame.Navigate(new PgHome());
        private void ListView_Transfer(object sender, RoutedEventArgs e) => MainFrame.Navigate(new Pgtranzact());
        private void ListView_Support(object sender, RoutedEventArgs e) => MainFrame.Navigate(new PgSupport());
        private void ListView_History(object sender, RoutedEventArgs e) => MainFrame.Navigate(new PgHistory());
        private void ListView_Settings(object sender, RoutedEventArgs e) => MainFrame.Navigate(new PgOptions());
        private void ListView_Exit(object sender, MouseButtonEventArgs e)
        => MainFrame.Navigate(new PgExit(this));

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
