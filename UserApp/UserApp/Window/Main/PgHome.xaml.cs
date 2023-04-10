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

namespace UserApp.Window.Main
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class PgHome : Page
    {
        public PgHome()
        {
            InitializeComponent();
            fullname.Text = User.CurrentUser.FullName;
            NmBill.Text = Bill.CurrentNumcard.NumberBill;
            NmCard.Text = Bill.CurrentNumcard.NumberCard;
        }
        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            Bill.AddBill(User.CurrentUser);
            User.CurrentUser.UpdateBills();
        }
    }
}