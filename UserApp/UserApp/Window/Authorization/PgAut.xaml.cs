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

namespace UserApp.Window.Authorization
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class PgAut : Page
    {
        private WndAut wndAut;
        string log;
        string pass;
        public PgAut(WndAut wndaut)
        {
            InitializeComponent();
            LogAut.Focus();
            wndAut = wndaut;
        }
        private void LogAut_LostFocus(object sender, RoutedEventArgs e)
        {
            if (LogAut.Text == string.Empty)
                TipLog.Visibility = Visibility.Visible;
            else
                TipLog.Visibility = Visibility.Collapsed;
        }
        private void PassAut_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PassAut.Password == string.Empty)
                TipPass.Visibility = Visibility.Visible;
            else
                TipPass.Visibility = Visibility.Collapsed;
        }
        private void Authorization()
        {
            if (DB.stateConnection)
            {
                log = LogAut.Text;
                pass = PassAut.Password;
                User user = LibUser.GetUserByLogIn(log, pass);
                if (user != null)
                {
                    User.CurrentUser = user;
                    WndMain main = new();
                    main.Show();
                    wndAut.Close();
                }
                else
                    ErrLP.Visibility = Visibility.Visible;
            }
            else
                MessageBox.Show("Связи с сервером нет");
        }
        private void BtnAut_Click(object sender, RoutedEventArgs e) => Authorization();
        private void ChkPass_Click(object sender, RoutedEventArgs e)
        {
            if (ChkPass.IsChecked == false)
            {
                PassAut.Password = PassText.Text;
                PassText.Visibility = Visibility.Collapsed;
                PassAut.Visibility = Visibility.Visible;
            }
            else
            {
                PassText.Text = PassAut.Password;
                PassAut.Visibility = Visibility.Collapsed;
                PassText.Visibility = Visibility.Visible;
            }
        }
        private void BtnRec_Click(object sender, RoutedEventArgs e)
        {
            if (DB.stateConnection)
                NavigationService.Navigate(new PgRec());
            else
                MessageBox.Show("Связи с сервером нет");
        }
        private void Border_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
                Authorization();
        }
    }
}
