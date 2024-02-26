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
using UserApp.Libs;
using UserApp.Models;
using UserApp.Window.UC;

namespace UserApp.Window.Main
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class PgHistory : Page
    {
        public PgHistory()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (LibBill.GetListTransactionByUser(User.CurrentUser) == null)
            {
                NonHistory.Visibility = Visibility.Visible;
                return;
            }
            else
                NonHistory.Visibility = Visibility.Collapsed;
            foreach (Transaction? transaction in LibBill.GetListTransactionByUser(User.CurrentUser))
            {

                UCTransaction uCTransaction = new(transaction);
                listPanel.Children.Add(uCTransaction);
            }
        }

    }
}
