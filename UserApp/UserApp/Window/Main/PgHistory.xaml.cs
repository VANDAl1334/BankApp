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
            countTranz.Items.Add("25");
            countTranz.Items.Add("50");
            countTranz.Items.Add("100");
            countTranz.Items.Add("Все");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (LibBill.GetListTransactionByUser(User.CurrentUser) == null)
            {
                NonHistory.Visibility = Visibility.Visible;
                countTranz.Visibility = Visibility.Collapsed;
                return;
            }
            else
            {
                NonHistory.Visibility = Visibility.Collapsed;
                countTranz.Visibility = Visibility.Visible;
                countTranz.SelectedIndex = 0;
            }
        }

        private void countTranz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (countTranz.SelectedIndex == 0)
            {
                if (Transaction.Transactions.Count < 24)
                    foreach (Transaction transaction in Transaction.Transactions)
                    {
                        UCTransaction uCTransaction = new(transaction);
                        listPanel.Children.Add(uCTransaction);
                    }
                else
                    for (int i = 0; i <= 24; i++)
                    {
                        Transaction? transaction = Transaction.Transactions?[i];
                        UCTransaction uCTransaction = new(transaction);
                        listPanel.Children.Add(uCTransaction);
                    }
            }
            else if (countTranz.SelectedIndex == 1)
            {
                for (int i = 0; i <= 49; i++)
                {
                    Transaction? transaction = Transaction.Transactions?[i];
                    UCTransaction uCTransaction = new(transaction);
                    listPanel.Children.Add(uCTransaction);
                }
            }
            else if (countTranz.SelectedIndex == 2)
            {
                for (int i = 0; i <= 99; i++)
                {
                    Transaction? transaction = Transaction.Transactions?[i];
                    UCTransaction uCTransaction = new(transaction);
                    listPanel.Children.Add(uCTransaction);
                }
            }
            else
            {
                foreach (Transaction transaction in Transaction.Transactions)
                {
                    UCTransaction uCTransaction = new(transaction);
                    listPanel.Children.Add(uCTransaction);
                }
            }
        }
    }
}
