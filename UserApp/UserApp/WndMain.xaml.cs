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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Xps.Serialization;

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class WndMain : Window
    {
        public WndMain()
        {
            InitializeComponent();
            fullname.Text = User.CurrentUser.FullName;
            NmCard.Text = Bill.CurrentNumcard.NumberCard;
        }
        WndSupport WndSupport;
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
        private void Window_Activated(object sender, EventArgs e)
        {
            if (WndSupport != null)
            {
                BtSupport.IsEnabled = false;
            }
            else
            {
                BtSupport.IsEnabled = true;
            }
        }
    }
}
