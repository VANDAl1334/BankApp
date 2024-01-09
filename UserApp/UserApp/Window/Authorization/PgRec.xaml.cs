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
using UserApp.Classes;
using UserApp.Window.Authorization;

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для PgRec.xaml
    /// </summary>
    public partial class PgRec : Page
    {        
        public PgRec()
        {
            InitializeComponent();
        }        
        private void BtnBack_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();
        private void BtnRec_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new PgCodeRec());
    }
}
