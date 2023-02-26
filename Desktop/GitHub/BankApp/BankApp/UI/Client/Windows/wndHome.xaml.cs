using BankApp.UI.Client.Pages;
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

namespace BankApp.UI.Client.Windows
{
    /// <summary>
    /// Логика взаимодействия для wndHome.xaml
    /// </summary>
    public partial class wndHome : Window
    {
        object pageType;
        const string classNamePrefix = "BankApp.UI.Client.Pages.";
        public wndHome()
        {
            InitializeComponent();
            pgHome page = new pgHome();
            frame.Navigate(page);
            pageType = page.GetType();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            if(pageType.ToString() != classNamePrefix + "pgHome")
            {
                pgHome page = new pgHome();
                frame.Navigate(page);
                pageType = page.GetType();
            }            
        }

        private void btnTransfer_Click(object sender, RoutedEventArgs e)
        {
            if(pageType.ToString() != classNamePrefix + "pgTransfer")
            {
                pgTransfer page = new pgTransfer();
                frame.Navigate(page);
                pageType = page.GetType();
            }
        }

        private void btnTranferBtwBills_Click(object sender, RoutedEventArgs e)
        {
            if (pageType.ToString() != classNamePrefix + "pgTransferBtwBills")
            {               
                string type = pageType.ToString();  
                pgTransferBtwBills page = new pgTransferBtwBills();
                frame.Navigate(page);
                pageType = page.GetType();
            }
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            if (pageType.ToString() != classNamePrefix + "pgHistory")
            {
                pgHistory page = new pgHistory();
                frame.Navigate(page);
                pageType = page.GetType();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Owner.Show();
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
