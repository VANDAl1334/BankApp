using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Data;
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
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow back = new();
            back.Show();
            Close();
        }
        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void BtnClose_Click (object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
        private void Checkpass_Click(object sender, RoutedEventArgs e)
        {

            if (checkpass.IsChecked == false)
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
        bool ContainNumber = true;
        bool ContainChar = false;
        char[] number = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ' };
        char[] Spec = new[] { '!', '"', '#', '$', '%', '/', '&', '(', ')', '*', '+', ',', '-', '.', ':', ';', '<', '=', '>', '?', '@', '[', ']', '^', '_', '`', '{', '|', '}', '~' };
        public void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            if (pass.Password != passpod.Password)
            {
                TipPassChk.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                TipNmUs.Visibility = Visibility.Collapsed;
                pass.Password = User.Hash(pass.Password);
                User.AddUser(NmUs.Text, SrNmUs.Text, PtNmUs.Text, LogIn.Text, pass.Password, Phone.Text);
                WndAut wndAut = new();
                wndAut.Show();
                Close();
            }            
        }
        private void StackPanel_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NmUs.Text == string.Empty)
            {
                TipNmUs.Visibility = Visibility.Visible;
                BtnReg.IsEnabled = false;
                return;
            }
            else
            {
                BtnReg.IsEnabled = true;
                TipNmUs.Visibility = Visibility.Collapsed;
            }
            foreach (char o in number)
            {
                if (NmUs.Text.Contains(o))
                {
                    ContainNumber = false;
                    break;
                }
            }
            if (ContainNumber == false)
            {
                chkNm.Visibility = Visibility.Visible;
                BtnReg.IsEnabled = false;
                return;
            }
            else
            {
                BtnReg.IsEnabled = true;
                TipNmUs.Visibility = Visibility.Collapsed;
            }
            if (SrNmUs.Text == string.Empty)
            {
                TipNmUs.Visibility = Visibility.Visible;
                BtnReg.IsEnabled = false;
                return;
            }
            else
            {
                BtnReg.IsEnabled = true;
                TipNmUs.Visibility = Visibility.Collapsed;
            }
            if (PtNmUs.Text == string.Empty)
            {
                TipNmUs.Visibility = Visibility.Visible;
                BtnReg.IsEnabled = false;
                return;
            }
            else
            {
                BtnReg.IsEnabled = true;
                TipNmUs.Visibility = Visibility.Collapsed;
            }
        }
        private void LogIn_LostFocus(object sender, RoutedEventArgs e)
        {
            if (LogIn.Text == string.Empty)
            {
                TipLogIn.Visibility = Visibility.Visible;
                BtnReg.IsEnabled = false;
                return;
            }
            else
            {
                BtnReg.IsEnabled = true;
                TipLogIn.Visibility = Visibility.Collapsed;
            }
            if (User.IsUserExists(LogIn.Text))
            {
                chkLog.Visibility = Visibility.Visible;
                BtnReg.IsEnabled = false;               
                return;
            }
            else
            {
                BtnReg.IsEnabled = true;
                chkLog.Visibility = Visibility.Collapsed;
            }
        }
        private void Pass_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pass.Password == string.Empty)
            {
                TipPass.Visibility = Visibility.Visible;
                BtnReg.IsEnabled = false;
                return;
            }
            else
            {
                BtnReg.IsEnabled = true;
                TipPass.Visibility = Visibility.Collapsed;
            }
            if (pass.Password.Length <= 8)
            {
                passlen.Visibility = Visibility.Visible;
                BtnReg.IsEnabled = false;
                return;
            }
            else
            {
                BtnReg.IsEnabled = true;
                passlen.Visibility = Visibility.Collapsed;
            }
            foreach (char i in Spec)
            {
                if (pass.Password.Contains(i))
                {
                    ContainChar = true;
                    break;
                }
            }
            if (ContainChar == false)
            {
                TipPassSpSim.Visibility = Visibility.Visible;
                BtnReg.IsEnabled = false;
                return;
            }
            else
            {
                BtnReg.IsEnabled = true;
                TipPassSpSim.Visibility = Visibility.Collapsed;
            }
        }
        private void Passpod_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passpod.Password == string.Empty)
            {
                TipPassPod.Visibility = Visibility.Visible;
                BtnReg.IsEnabled = false;
                return;
            }
            else
            {
                BtnReg.IsEnabled = true;
                TipPassPod.Visibility = Visibility.Collapsed;
            }
        }
        private void Phone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Phone.Text == string.Empty)
            {
                ChkPh.Visibility = Visibility.Visible;
                BtnReg.IsEnabled = false;
                return;
            }
            else
            {
                BtnReg.IsEnabled = true;
                ChkPh.Visibility = Visibility.Collapsed;
            }
        }


    }
}
