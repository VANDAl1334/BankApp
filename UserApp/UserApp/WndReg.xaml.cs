using System;
using System.Collections.Generic;
using System.Dynamic;
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
            WndWelc back= new();
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
        private void checkpass1_Click(object sender, RoutedEventArgs e)
        {
            if (checkpass1.IsChecked == false)
            {
                passpod.Password = textpod.Text;
                textpod.Visibility = Visibility.Collapsed;
                passpod.Visibility = Visibility.Visible;
            }
            else
            {
                textpod.Text = passpod.Password;
                textpod.Visibility = Visibility.Visible;
                passpod.Visibility = Visibility.Collapsed;
            }
        }
        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            Regex sampleRegex = new Regex(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{2,})$");
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
            else if (!pass.Password.Contains(sampleRegex.ToString()))
            {
                TipPassSpSim.Visibility = Visibility.Visible;
            }
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
