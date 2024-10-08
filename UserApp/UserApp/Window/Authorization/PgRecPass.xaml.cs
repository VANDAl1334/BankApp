﻿using Mysqlx.Connection;
using System;
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
using UserApp.Classes;
using UserApp.Window.Authorization;

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class PgRecPass : Page
    {
        public PgRecPass()
        {
            InitializeComponent();
            NewPass.Focus();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();
        private void BtnRecPass_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();
    }
}
