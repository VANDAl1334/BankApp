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
        int AntiReckuriyanahuy = 0;
        int Count;
        public PgHome()
        {
            InitializeComponent();
            LibBill.GetBill(User.CurrentUser);            
            NmBill.Items.Add(Bill.CurrentBill);
            NmBill.SelectedIndex = 0;
            fullname.Text = User.CurrentUser.FullName;
        }
        public void UpdateBills()
        {
           /* if (NmBill.SelectedIndex >= 0)
            {                
                foreach (Bill bill in LibUser.GetBillsByUser(User.CurrentUser))
                {
                    NmBill.Items.Add(bill);
                    Count = NmBill.Items.Count;
                    for (int i = 0; i < Count; i++)
                    {
                        
                    }                    
                }
                Balance.Text = (NmBill.SelectedItem as Bill).Balance.ToString();
            }*/
        }
        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            LibBill.AddBill(User.CurrentUser);
            LibBill.GetBill(User.CurrentUser);
            NmCard.Text = Bill.CurrentBill.NumberCard;
        }
        private void NmBill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AntiReckuriyanahuy == 0)
            {
                AntiReckuriyanahuy = 1;
                UpdateBills();
            }
            else
                AntiReckuriyanahuy--;
        }

        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
