﻿using System;
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
        bool LogInValid = false;
        bool MailValid = false;
        bool PassValid = false;
        bool PodPassValid = false;
        bool ContainVoid;
        string PassHash;
        char[] Spec = new[] { '!', '"', '#', '$', '%', '/', '&', '(', ')', '*', '+', ',', '-', '.', ':', ';', '<', '=', '>', '?', '@', '[', ']', '^', '_', '`', '{', '|', '}', '~' };
        bool ContainChar = false;
        public PgLogPass()
        {
            InitializeComponent();
            LogIn.Focus();
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
            if (!DB.stateConnection)
            { MessageBox.Show("Нет соединения с Аллахам"); return; }
            if (!(Pass.Password == string.Empty || Email.Text == string.Empty || LogIn.Text == string.Empty))
            {
                chkdata.Visibility = Visibility.Collapsed;
                chkdatalogmail.Visibility = Visibility.Collapsed;
                if (LibUser.IsUserExistsLogin(LogIn.Text) || LibUser.IsUserExistsEmail(Email.Text))
                {

                    chkdatalogmail.Visibility = Visibility.Visible;
                    chkdata.Visibility = Visibility.Collapsed;
                    MailValid = false;
                    LogInValid = false;
                }
                else
                {
                    LogInValid = true;
                    MailValid = true;
                }
            }
            else
                chkdata.Visibility = Visibility.Visible;
            if (MailValid == true && ContainChar == true && LogInValid == true && PassValid == true && PodPassValid == true)
            {
                PassHash = LibUser.Hash(Pass.Password);
                User user = new()
                {
                    name_user = NmUs,
                    surname_user = SrNmUs,
                    patronymic_user = PtNmUs,
                    login_user = LogIn.Text,
                    password_user = PassHash.Trim(),
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
                MailValid = false;
            }
            else if (Email.Text != string.Empty)
            {
                if (LibUser.PatternEmail(Email.Text))
                {
                    TipEmForm.Visibility = Visibility.Collapsed;
                    ChkEm.Visibility = Visibility.Collapsed;
                    MailValid = true;
                }
                else
                {
                    ChkEm.Visibility = Visibility.Collapsed;
                    TipEmForm.Visibility = Visibility.Visible;
                    MailValid = false;
                }
            }
        }
        private void Pass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Pass.Password.Contains(' '))
                ContainVoid = true;
            if (Pass.Password == string.Empty || ContainVoid == true)
            {
                passlen.Visibility = Visibility.Collapsed;
                TipPassSpSim.Visibility = Visibility.Collapsed;
                TipPass.Visibility = Visibility.Visible;
                PassValid = false;
                ContainVoid = false;
            }
            else if (Pass.Password != string.Empty)
            {
                TipPass.Visibility = Visibility.Collapsed;
                if (Pass.Password.Length <= 8)
                {
                    TipPassSpSim.Visibility = Visibility.Collapsed;
                    passlen.Visibility = Visibility.Visible;
                    PassValid = false;
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
                        PassValid = false;
                    }
                    if (ContainChar == false)
                    {
                        TipPass.Visibility = Visibility.Collapsed;
                        passlen.Visibility = Visibility.Collapsed;
                        TipPassSpSim.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        TipPassSpSim.Visibility = Visibility.Collapsed;
                        PassValid = true;
                    }
                }
                if (Passpod.Password != string.Empty)
                {
                    if (Pass.Password != Passpod.Password)
                    {
                        TipPassPod.Visibility = Visibility.Visible;
                        PodPassValid = false;
                    }
                    else
                    {
                        TipPassPod.Visibility = Visibility.Collapsed;
                        PodPassValid = true;
                    }
                }
            }
        }
        private void Passpod_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Passpod.Password != string.Empty)
            {
                TipPassChk.Visibility = Visibility.Collapsed;
                if (Pass.Password != Passpod.Password)
                {
                    TipPassPod.Visibility = Visibility.Visible;
                    PodPassValid = false;
                }
                else
                {
                    TipPassPod.Visibility = Visibility.Collapsed;
                    PodPassValid = true;
                }
            }
            else
            {
                TipPassPod.Visibility = Visibility.Collapsed;
                TipPassChk.Visibility = Visibility.Visible;
                PodPassValid = false;
            }
        }
        private void LogIn_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LogIn.Text != string.Empty)
            {
                TipLogIn.Visibility = Visibility.Collapsed;
                LogInValid = true;
            }
            else
            {
                TipLogIn.Visibility = Visibility.Visible;
                LogInValid = false;
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Pass.Password = Password;
            Passpod.Password = PasswordPod;
        }
    }
}
