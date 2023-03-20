using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Security.Cryptography;
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
using UserApp.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class WndAut : Window
    {
        public WndAut()
        {
            InitializeComponent();
            ManagerPg.RecFrame = RecFrame;
        }
        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow back = new();
            back.Show();
            this.Close();
        }
        private void BtnAut_Click(object sender, RoutedEventArgs e)
        {
            if (LogAut.Text == string.Empty)
            {
                TipLog.Visibility = Visibility.Visible;
            }
            else if(PassAut.Password == string.Empty)
            {
                TipPass.Visibility = Visibility.Visible;
            }
            else if(User.CurrentUser != null)
            {
                User.CurrentUser = User.GetUserByLogIn(LogAut.Text);
                WndMain main = new();
                main.Show();
                Close();
            }
            else
            {
                ErrLP.Visibility = Visibility.Visible;
            }
        }

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
            ManagerPg.RecFrame.Navigate(new PgRec());
        }
    }
}
