using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BankApp.UI
{
    /// <summary>
    /// Логика взаимодействия для wndHome.xaml
    /// </summary>
    public partial class wndHome : Window
    {
        public wndHome()
        {
            InitializeComponent();
            frmMain.Navigate(new pgTransfer());
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new pgTransfer());
        }

        private void btnRefill_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new pgRefill());
        }

        private void btnWithdrawal_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new pgWithdrawal());
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new pgHistory());
        }
    }
}
