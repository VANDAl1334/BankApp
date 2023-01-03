using BankApp.UI;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace BankApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> accounts = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            downloadAccounts();
        }

        private void downloadAccounts()
        {
            StreamReader stream = new StreamReader(@"..\..\..\Data\Accounts.txt", true);
            while (!stream.EndOfStream)
            {
                accounts.Add(stream.ReadLine());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            authorize();
        }

        private void authorize()
        {
            for(int i = 0; i < accounts.Count; i++)
            {
                if(tboxLogin.Text == accounts[i])
                {
                    if (pwbxPassword.Password == accounts[i + 1])
                    {
                        wndHome Home = new wndHome();
                        Home.Show();
                    }
                }
            }
        }
    }
}
