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
using UserApp.Classes;
using UserApp.Models;
using UserApp.Window.Authorization;

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для PgRec.xaml
    /// </summary>
    public partial class PgRec : Page
    {
        private bool emailValid = false;
        public PgRec()
        {
            InitializeComponent();
            email.Focus();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();
        private void BtnRec_Click(object sender, RoutedEventArgs e)
        {
            if (emailValid)
                NavigationService.Navigate(new PgCodeRec());
        }
        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (email.Text == string.Empty)
            {
                TipEmailPattern.Visibility = Visibility.Collapsed;
                TipEmail.Visibility = Visibility.Visible;
                emailValid = false;
            }
            else
            {
                TipEmail.Visibility = Visibility.Collapsed;
                if (LibUser.PatternEmail(email.Text))
                {
                    TipEmailPattern.Visibility = Visibility.Collapsed;
                    emailValid = true;
                }
                else
                {
                    TipEmailPattern.Visibility = Visibility.Visible;
                    emailValid = false;
                }
            }
        }
    }
}
