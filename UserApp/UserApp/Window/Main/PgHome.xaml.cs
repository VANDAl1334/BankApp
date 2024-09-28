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
        int indexNumBill;
        bool blockUpdate;
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
                if (NmBill.SelectedIndex != -1)
                    indexNumBill = NmBill.SelectedIndex;
                if (NmBill.Items.Count != 0)
                    NmBill.Items.Clear();
                try { NmBill.SelectedIndex = indexNumBill; }
                catch { NmBill.SelectedIndex = 0; }
                if (User.CurrentUser.Bills != null)
                    User.CurrentUser.Bills.Clear();
                foreach (Bill bill in LibUser.GetBillsByUser(User.CurrentUser))
                {
                    blockUpdate = false;
                    NmBill.Items.Add(bill);
                    User.CurrentUser.Bills.Add(bill);
                }
                Balance.Text = (NmBill.SelectedItem as Bill).Balance.ToString();
                User.CurrentUser.Count = User.CurrentUser.Bills.Count;
                if (Bill.CurrentBill.NumberCard != null)
                {
                    DataCard.Visibility = Visibility.Visible;
                    NoDataCard.Visibility = Visibility.Collapsed;
                    LibCard.GetCard();
                    fullname.Text = User.CurrentUser.FullName;
                    if (Card.CurrentCard?.Number != null && Bill.CurrentBill.NumberCard?.ToString() == Card.CurrentCard?.Number)
                    {                        
                        NmCard.Text = Card.CurrentCard.Number;
                        CVV.Text = Card.CurrentCard.CVV.ToString();
                        Validity.Text = Card.CurrentCard.Validity;
                        BtnLinkCard.IsEnabled = false;
                    }
                }
                else
                {
                    DataCard.Visibility = Visibility.Collapsed;
                    NoDataCard.Visibility = Visibility.Visible;
                }
            }
            else
            {
                Balance.Text = null;
                NmBill.Items.Clear();
                BtnLinkCard.IsEnabled = false;
                DataCard.Visibility = Visibility.Collapsed;
                NoDataCard.Visibility = Visibility.Visible;
            }
            blockUpdate = true;
        }
        private void BtnCreateBill_Click(object sender, RoutedEventArgs e)
        {
            LibBill.AddBill(User.CurrentUser);
            Updates();
        }
        private void BtnCreateCard_Click(object sender, RoutedEventArgs e)
        {
            LibCard.AddCard();
            LibCard.GetCard();
            LibUser.GetBillsByUser(User.CurrentUser);
            Updates();
        }
        private void NmBill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NmBill.SelectedIndex != -1)
                Bill.CurrentBill = NmBill.SelectedItem as Bill;
            if (blockUpdate == true)
            {
                if (NmBill.SelectedIndex >= 0 && Bill.CurrentBill.NumberBill != null)
                    Updates();
            }
        }
        private void BtnUpdate_Click(object sender, RoutedEventArgs e) => Updates();
    }
}
