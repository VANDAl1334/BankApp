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
using UserApp.Window.Registration;
using UserApp.Classes;
namespace UserApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            DB.GetConnectionHosts();            
            if (DB.stateConnection == true)
            {
                WndReg reg = new();
                reg.Show();
                Close();
            }
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e) => Close();
        private void BtnAut_Click(object sender, RoutedEventArgs e)
        {
            WndAut aut = new();            
            aut.Show();
            Close();
        }
        private void BtnMin_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }
}
