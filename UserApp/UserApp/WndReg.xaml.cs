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
            UpdateLayout();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow back= new();
            back.Show();
            this.Close();
        }
        public Boolean IsUserExists(string LogClient)
        {
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("SELECT * FROM `user` WHERE `login_user` = @cL", DB.GetConnection());
            DB.cmd.Parameters.Add("@cL", MySqlDbType.VarChar).Value = LogClient;
            adapter.SelectCommand = DB.cmd;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                chkLog.Visibility = Visibility.Visible;
                return true;
            }
            else
                return false;
        }
        private void Checkpass_Click(object sender, RoutedEventArgs e)
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

        bool ContainNumber = true;
        bool ContainChar = false;
        char[] number = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ' };
        char[] Spec = new[] { '!', '"', '#', '$', '%', '&', '(', ')', '*', '+', ',', '-', '.', ':', ';', '<', '=', '>', '?', '@', '[', ']', '^', '_', '`', '{', '|', '}', '~' };
        public void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            
            if (NmUs.Text == string.Empty)
                TipNmUs.Visibility = Visibility.Visible;
            if (SrNmUs.Text == string.Empty)
                TipNmUs.Visibility = Visibility.Visible;
            if (PtNmUs.Text == string.Empty)
                TipNmUs.Visibility = Visibility.Visible;
            if (LogIn.Text == string.Empty)
                 TipLogIn.Visibility = Visibility.Visible;
            if (pass.Password.Length >= 8)
                 passlen.Visibility = Visibility.Visible;
            if (pass.Password == string.Empty)
                TipPass.Visibility = Visibility.Visible;
            if (passpod.Password == string.Empty)
                TipPassPod.Visibility = Visibility.Visible;
            if (pass.Password != passpod.Password)
                TipPassChk.Visibility = Visibility.Visible;
            foreach (char o in number)
            {
                if (NmUs.Text.Contains(o))
                {
                    ContainNumber = false;
                    break;
                }
            }
            if (ContainNumber == false)
                chkNm.Visibility = Visibility.Visible;
            if (IsUserExists(LogIn.Text))
                return;
            foreach (char i in Spec)
            {
                if (pass.Password.Contains(i))
                {
                    ContainChar = true;
                    break;
                }
            }
            if (ContainChar == false)
                TipPassSpSim.Visibility = Visibility.Visible;
            else
            {
                pass.Password = Client.Hash(pass.Password);
                Client.SqlRequest(NmUs.Text, SrNmUs.Text, PtNmUs.Text, LogIn.Text, pass.Password);
                WndAut wndAut = new();
                wndAut.Show();
                Close();
            }
        }
        public void Window_Activated(object sender, EventArgs a)
        {
           
        }
    }
}
