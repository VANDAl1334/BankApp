using System;
using System.Collections.Generic;
using System.Linq;
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
            WndMain back = new();
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
            //char[] list.IndexOf = new[]{ '^', '|', '!', '#', '$', '%', '&', '/', '@', '{', '}' };
            if (NmUs.Text == string.Empty)
            {
                TipNmUs.Visibility = Visibility.Visible;
            }
            else if (LogIn.Text == string.Empty)
            {
                TipLogIn.Visibility = Visibility.Visible;
            }
            else if (pass.Password == string.Empty)
            {
                TipPass.Visibility = Visibility.Visible;
            }
            else if (passpod.Password == string.Empty)
            {
                TipPassPod.Visibility = Visibility.Visible;
            }
            else if (pass.Password != passpod.Password)
            {
                TipPassChk.Visibility = Visibility.Visible;
            }
            
            /*else if (!pass.Password.Contains(list.ToString()))
            {
                TipPassSpSim.Visibility = Visibility.Visible;
            }*/
            else
            {
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
