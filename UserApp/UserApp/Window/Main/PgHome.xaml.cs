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
using static System.Net.Mime.MediaTypeNames;
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
            Updates();
        }
        public void Updates()
        {
            if (LibBill.GetBill(User.CurrentUser) != null)
            {
                BtnLinkCard.IsEnabled = true;
                if (Bill.CurrentBill.NumberCard != null)
                {
                    DataCard.Visibility = Visibility.Visible;
                    NoDataCard.Visibility = Visibility.Collapsed;
                    LibCard.GetCard();
                    fullname.Text = User.CurrentUser.FullName;
                }
                else
                {
                    DataCard.Visibility = Visibility.Collapsed;
                    NoDataCard.Visibility = Visibility.Visible;
                }
                if (Bill.CurrentBill.NumberBill != null)
                {
                    NmBill.SelectedIndex = 0;
                    foreach (Bill bill in LibUser.GetBillsByUser(User.CurrentUser))
                    {
                        NmBill.Items.Add(bill);
                        if (Card.CurrentCard?.Number != null && bill.NumberCard?.ToString() == Card.CurrentCard?.Number)
                        {
                            NmCard.Text = Card.CurrentCard.Number;
                            CVV.Text = Card.CurrentCard.CVV.ToString();
                            Validity.Text = Card.CurrentCard.Validity;
                            BtnLinkCard.IsEnabled = false;
                        }
                    }
                    Balance.Text = (NmBill.SelectedItem as Bill).Balance.ToString();
                }
            }
            else
            {
                BtnLinkCard.IsEnabled = false;
                DataCard.Visibility = Visibility.Collapsed;
                NoDataCard.Visibility = Visibility.Visible;
            }
        }
        private void BtnCreateBill_Click(object sender, RoutedEventArgs e)
        {
            LibBill.AddBill(User.CurrentUser);
            NmBill.Items.Clear();
            Updates();
        }
        private void BtnCreateCard_Click(object sender, RoutedEventArgs e)
        {
            LibCard.AddCard();
            LibCard.GetCard();
            Bill.CurrentBill.NumberCard = Card.CurrentCard.Number;
            LibUser.GetBillsByUser(User.CurrentUser);
            NmBill.Items.Clear();
            Updates();
        }
        private void NmBill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NmBill.SelectedIndex > 0)
                Balance.Text = (NmBill.SelectedItem as Bill).Balance.ToString();
        }
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            NmBill.Items.Clear();
            Updates();
        }
    }
}
