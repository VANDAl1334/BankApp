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
            foreach (Transaction transaction in LibBill.GetListTransactionByUser(User.CurrentUser))
            {
                Border border = new();
                border.Visibility = Visibility.Visible;
                border.Height = 380;
                border.Width = 600;
                border.HorizontalAlignment = HorizontalAlignment.Center;
                border.VerticalAlignment = VerticalAlignment.Center;
                border.BorderBrush = Brushes.Red;
                border.BorderThickness = new(2);
                StackPanel stack = new();                
                stack.HorizontalAlignment = HorizontalAlignment.Center;
                TextBlock blockId = new();
                blockId.Margin = new(0, 0, 0, 5);
                TextBlock blockDate = new();
                blockDate.Margin = new(0, 0, 0, 15);
                TextBlock blockType = new();
                blockType.Margin = new(0, 0, 0, 15);
                TextBlock blockRecipient = new();
                blockRecipient.Margin = new(0, 0, 0, 15);
                TextBlock blockSender = new();
                blockSender.Margin = new(0, 0, 0, 15);
                TextBlock blockAmount = new();
                blockAmount.Margin = new(0, 0, 0, 15);
                TextBlock blockStatus = new();
                blockStatus.Margin = new(0, 0, 0, 15);
                stack.Children.Add(blockId);
                stack.Children.Add(blockDate);
                stack.Children.Add(blockType);
                stack.Children.Add(blockRecipient);
                stack.Children.Add(blockSender);
                stack.Children.Add(blockAmount);
                stack.Children.Add(blockStatus);
                blockId.Text = transaction.Id.ToString();
                blockDate.Text = transaction.Date.ToString();
                blockType.Text = transaction.Type_transaction;
                blockRecipient.Text = transaction.Recipient;
                blockSender.Text = transaction.Sender;
                blockAmount.Text = transaction.Amount.ToString();
                blockStatus.Text = transaction.Status;
            }
        }
    }
}
