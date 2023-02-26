using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class WndReg : Window
    {
        public WndReg()
        {
            InitializeComponent();
            UpdateLayout();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow back= new();
            back.Show();
            this.Close();
        }

        private void checkpass_Click(object sender, RoutedEventArgs e)
        {
            
            if(checkpass.IsChecked == false)
            {
                pass.Password = text.Text;
                text.Visibility = Visibility.Collapsed;
                pass.Visibility = Visibility.Visible;
            }
            else 
            {
                text.Text = pass.Password;
                text.Visibility = Visibility.Visible;
                pass.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {

            char[] list = new[] {'#', '|', '!', '#', '$', '%', '&', '/', '@', '{', '}' };
            if (NmUs.Text == string.Empty && NmUs.Text == " ")
            {
                TipNmUs.Visibility = Visibility.Visible;
            }
            else if (LogIn.Text == string.Empty && LogIn.Text == " ")
            {
                
                TipLogIn.Visibility = Visibility.Visible;
                return;
            }
            else if (pass.Password == string.Empty && pass.Password == " ")
            {
                TipPass.Visibility = Visibility.Visible;
                return;
            }
            else if (passpod.Password == string.Empty && passpod.Password == " ")
            {
                TipPassPod.Visibility = Visibility.Visible;
                return;
            }
            else if (pass.Password != passpod.Password)
            {
                TipPassChk.Visibility = Visibility.Visible;
                return;
            }
            bool ContainChar = false;
            foreach(char i in list)
            {
                if (pass.Password.Contains(i))
                {
                    ContainChar = true;
                    break;
                }
            }
            if(ContainChar == false)
            {
                TipPassSpSim.Visibility = Visibility.Visible;
            }
            else
            {
                pass.Password = Client.Hash(pass.Password);
                Client.SqlRequest(NmUs.Text, LogIn.Text, pass.Password);
                WndAut wndAut = new();
                wndAut.Show();
                this.Close();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
