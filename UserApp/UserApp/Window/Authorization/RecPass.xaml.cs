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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }
        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            //WindowState = WindowState.Minimized;
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            //Close();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow back = new();
            back.Show();
            //Close();
        }
        private void BtnRecPass_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
