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
using UserApp.Models;

namespace UserApp.Window.Registration
{
    /// <summary>
    /// Логика взаимодействия для PgFNm.xaml
    /// </summary>
    public partial class PgFNm : Page
    {
        private PgLogPass LogPass;
        public PgFNm(WndReg wndReg)
        {
            InitializeComponent();
        }
        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            if (NmUs.Text == string.Empty || SrNmUs.Text == string.Empty || PtNmUs.Text == string.Empty)
            {
                chkdata.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                LogPass ??= new();
                PgLogPass.NmUs = NmUs.Text;
                PgLogPass.SrNmUs = SrNmUs.Text;
                PgLogPass.PtNmUs = PtNmUs.Text;
                NavigationService.Navigate(LogPass);
            }
        }
        private void SrNmUs_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SrNmUs.Text != string.Empty)
            {
                TipSr.Visibility = Visibility.Collapsed;
                chkSr.Visibility = Visibility.Collapsed;
                BtnReg.IsEnabled = false;

                if (LibUser.PatternFullName(SrNmUs.Text))
                {
                    chkSr.Visibility = Visibility.Visible;
                    BtnReg.IsEnabled = false;
                    return;
                }
                else
                {
                    chkSr.Visibility = Visibility.Collapsed;
                    BtnReg.IsEnabled = true;
                }
            }
            else
            {
                chkSr.Visibility = Visibility.Collapsed;
                TipSr.Visibility = Visibility.Visible;
                BtnReg.IsEnabled = false;
            }
        }
        private void NmUs_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NmUs.Text != string.Empty)
            {
                TipNm.Visibility = Visibility.Collapsed;
                chkNm.Visibility = Visibility.Collapsed;
                BtnReg.IsEnabled = false;

                if (LibUser.PatternFullName(NmUs.Text))
                {
                    chkNm.Visibility = Visibility.Visible;
                    BtnReg.IsEnabled = false;
                    return;
                }
                else
                {
                    chkNm.Visibility = Visibility.Collapsed;
                    BtnReg.IsEnabled = true;
                }
            }
            else
            {
                chkNm.Visibility = Visibility.Collapsed;
                TipNm.Visibility = Visibility.Visible;
                BtnReg.IsEnabled = false;
            }
        }

        private void PtNmUs_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PtNmUs.Text != string.Empty)
            {
                TipPt.Visibility = Visibility.Collapsed;
                chkPt.Visibility = Visibility.Collapsed;
                BtnReg.IsEnabled = false;

                if (LibUser.PatternFullName(PtNmUs.Text))
                {
                    chkPt.Visibility = Visibility.Visible;
                    BtnReg.IsEnabled = false;
                    return;
                }
                else
                {
                    chkPt.Visibility = Visibility.Collapsed;
                    BtnReg.IsEnabled = true;
                }
            }
            else
            {
                chkPt.Visibility = Visibility.Collapsed;
                TipPt.Visibility = Visibility.Visible;
                BtnReg.IsEnabled = false;
            }
        }
    }
}

