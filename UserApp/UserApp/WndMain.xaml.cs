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

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    
    public partial class WndMain : Window
    {
        DispatcherTimer timer;
        bool hidden = true;
        public WndMain()
        {
            InitializeComponent();
            timer = new();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;
            fullname.Text = User.CurrentUser.FullName;
            login.Text = User.CurrentUser.login_user;
            NmCard.Text = Bill.CurrentNumcard.NumberCard;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hidden)
            {
                Menu.Width += 5;
                if (Menu.Width >= 200)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                Menu.Width -= 5;
                if (Menu.Width <= 47)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }
        private void BtnPanel_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
        private void background_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        //WndSupport WndSupport;
        private void BtnSupport_Click(object sender, RoutedEventArgs e)
        {
            WndSupport support = new();
            support.Show();
        }
        private void BtnHystory_Click(object sender, RoutedEventArgs e)
        {
            WndHystory hystory = new();
            hystory.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BtnTransf.Visibility = Visibility.Collapsed;
            BtnMy.Visibility = Visibility.Visible;
            BtnYour.Visibility = Visibility.Visible;
        }
        private void BtnMy1(object sender, RoutedEventArgs e)
        {
            WndMy wndmy = new();
            wndmy.Show();
        }
        private void BtnYour1(object sender, RoutedEventArgs e)
        {
            WndYour wndyour = new();
            wndyour.Show();
        }
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ListView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
