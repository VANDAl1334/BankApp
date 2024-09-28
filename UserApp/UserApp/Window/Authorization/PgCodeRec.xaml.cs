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

namespace UserApp.Window.Authorization
{
    /// <summary>
    /// Логика взаимодействия для PgCodeRec.xaml
    /// </summary>
    public partial class PgCodeRec : Page
    {
        public PgCodeRec()
        {
            InitializeComponent();
            Code.MaxLength = 9;
            Code.Focus();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();
        private void BtnRec_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new PgRecPass());
        private void Code_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Code.Text.Length == 4)
                Code.Text += "-";
            if (Code.Text.Length == 9)
            {
                TipCode.Visibility = Visibility.Collapsed;
                BtnRec.IsEnabled = true;
            }
            else
                TipCode.Visibility = Visibility.Visible;            
            Code.SelectionStart = Code.Text.Length;
            Code.Text = Code.Text.ToUpper();
        }
    }
}
