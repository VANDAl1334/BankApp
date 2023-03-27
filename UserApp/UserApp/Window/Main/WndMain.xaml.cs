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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Xps.Serialization;
using System.Windows.Threading;
using Google.Protobuf.WellKnownTypes;
using System.Windows.Media.Animation;

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    
    public partial class WndMain : System.Windows.Window
    {
        DispatcherTimer timer;
        bool hidden = true;
        private bool Frozen;
        private string Balance;
        public WndMain()
        {
            InitializeComponent();
            timer = new();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;
            fullname.Text = User.CurrentUser.FullName;
            login.Text = User.CurrentUser.login_user;
            NmBill.Text = Bill.CurrentNumcard.NumberBill;
            NmCard.Text = Bill.CurrentNumcard.NumberCard;
            Frozen = Bill.CurrentNumcard.Frozen;
            Balance = Bill.CurrentNumcard.Balance;
        }
        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hidden)
            {
                Menu.Width += 5;
                if (Menu.Width >= 200)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                Menu.Width -= 5;
                if (Menu.Width <= 47)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation da = new() { From = 360, To = 0, Duration = TimeSpan.FromSeconds(1) };
            RotateTransform rt = new() { CenterX = 50, CenterY = 50 };
            brdrotate.RenderTransform = rt;
            rt.BeginAnimation(RotateTransform.AngleProperty, da);
        }
        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            Bill.AddBill(User.CurrentUser);
            User.CurrentUser.UpdateBills();
        }
        private void BtnPanel_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }       
        private void BtnHystory_Click(object sender, RoutedEventArgs e)
        {
            WndHystory hystory = new();
            hystory.Show();
        }
        private void ListView_Home(object sender, MouseButtonEventArgs e)
        {

        }
        private void ListView_Transfer(object sender, RoutedEventArgs e)
        {

        }
        private void ListView_History(object sender, RoutedEventArgs e)
        {

        }
        private void ListView_Settings(object sender, RoutedEventArgs e)
        {

        }
        private void ListView_Exit(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
    }
}
