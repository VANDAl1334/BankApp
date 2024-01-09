using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Text.RegularExpressions;
namespace UserApp.Window.Registration
{
    /// <summary>
    /// Логика взаимодействия для PgLogPass.xaml
    /// </summary>
    public partial class PgLogPass : Page
    {
        public static string NmUs;
        public static string SrNmUs;
        public static string PtNmUs;
        public string Password;
        public string PasswordPod;

        char[] Spec = new[] { '!', '"', '#', '$', '%', '/', '&', '(', ')', '*', '+', ',', '-', '.', ':', ';', '<', '=', '>', '?', '@', '[', ']', '^', '_', '`', '{', '|', '}', '~' };
        bool ContainChar = false;
        public PgLogPass()
        {
            InitializeComponent();
        }
        private void BtnRegLPback_Click(object sender, RoutedEventArgs e)
        {
            Password = Pass.Password;
            PasswordPod = Passpod.Password;
            NavigationService.GoBack();
        }
        private void Checkpass_Click(object sender, RoutedEventArgs e)
        {

            if (checkpass.IsChecked == false)
            {
                Pass.Password = text.Text;
                text.Visibility = Visibility.Collapsed;
                Pass.Visibility = Visibility.Visible;
            }
            else
            {
                text.Text = Pass.Password;
                text.Visibility = Visibility.Visible;
                Pass.Visibility = Visibility.Collapsed;
            }
        }       
        public void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            if (Pass.Password == string.Empty || Email.Text == string.Empty || LogIn.Text == string.Empty)
            {
                chkdata.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                Pass.Password = LibUser.Hash(Pass.Password);
                User user = new()
                {
                    name_user = NmUs,
                    surname_user = SrNmUs,
                    patronymic_user = PtNmUs,
                    login_user = LogIn.Text,
                    password_user = Pass.Password.Trim(),
                    Role_id = "1",
                    Email = Email.Text
                };
                LibUser.AddUser(user);
                WndAut wndAut = new();
                wndAut.Show();
                ManagerPg.WndReg.Close();
            }
        }
        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Email.Text == string.Empty)
            {
                TipEmForm.Visibility = Visibility.Collapsed;
                ChkEm.Visibility = Visibility.Visible;
                BtnReg.IsEnabled = false;
            }
            else if (Email.Text != string.Empty)
            {
                if (LibUser.PatternEmail(Email.Text))
                {
                    TipEmForm.Visibility = Visibility.Collapsed;
                    ChkEm.Visibility = Visibility.Collapsed;
                    if (LibUser.IsUserExistsEmail(Email.Text))
                    {
                        TipEmail.Visibility = Visibility.Visible;
                        BtnReg.IsEnabled = false;
                    }
                    else
                    {
                        TipEmail.Visibility = Visibility.Collapsed;
                        BtnReg.IsEnabled = true;
                    }
                }
                else
                {
                    ChkEm.Visibility = Visibility.Collapsed;
                    TipEmForm.Visibility = Visibility.Visible;
                    BtnReg.IsEnabled = false;
                }
            }
        }
        private void Pass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Pass.Password == string.Empty)
            {
                passlen.Visibility = Visibility.Collapsed;
                TipPass.Visibility = Visibility.Visible;
                BtnReg.IsEnabled = false;

            }
            else if (Pass.Password != string.Empty)
            {
                TipPass.Visibility = Visibility.Collapsed;
                if (Pass.Password.Length <= 8)
                {
                    TipPassSpSim.Visibility = Visibility.Collapsed;
                    passlen.Visibility = Visibility.Visible;
                    BtnReg.IsEnabled = false;
                }
                else
                {
                    passlen.Visibility = Visibility.Collapsed;
                    foreach (char i in Spec)
                    {
                        if (Pass.Password.Contains(i))
                        {
                            ContainChar = true;
                            break;
                        }
                        ContainChar = false;
                    }
                    if (ContainChar == false)
                    {
                        passlen.Visibility = Visibility.Collapsed;
                        TipPassSpSim.Visibility = Visibility.Visible;
                        BtnReg.IsEnabled = false;
                    }
                    else
                    {
                        BtnReg.IsEnabled = true;
                        TipPassSpSim.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }
        private void Passpod_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Passpod.Password != string.Empty)
            {
                TipPassChk.Visibility = Visibility.Collapsed;
                BtnReg.IsEnabled = false;
                if (Pass.Password != Passpod.Password)
                {
                    TipPassPod.Visibility = Visibility.Visible;
                    BtnReg.IsEnabled = false;
                }
                else
                {
                    TipPassPod.Visibility = Visibility.Collapsed;
                    BtnReg.IsEnabled = true;

                }
            }
            else
            {
                TipPassPod.Visibility = Visibility.Collapsed;
                TipPassChk.Visibility = Visibility.Visible;
            }
        }

        private void LogIn_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LogIn.Text != string.Empty)
            {
                TipLogIn.Visibility = Visibility.Collapsed;
                BtnReg.IsEnabled = false;
                if (LibUser.IsUserExistsLogin(LogIn.Text))
                {
                    chkLog.Visibility = Visibility.Visible;
                    BtnReg.IsEnabled = false;
                }
                else
                {
                    chkLog.Visibility = Visibility.Collapsed;
                    BtnReg.IsEnabled = true;
                }
            }
            else
            {
                chkLog.Visibility = Visibility.Collapsed;
                TipLogIn.Visibility = Visibility.Visible;
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Pass.Password = Password;
            Passpod.Password = PasswordPod;
        }
    }
}
