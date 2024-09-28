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
 
namespace UserApp.Window.Main 
{ 
    /// <summary> 
    /// Логика взаимодействия для PgExit.xaml 
    /// </summary> 
    public partial class PgExit : Page 
    { 
        public readonly WndMain wndMain; 
 
        public PgExit(WndMain wndMain) 
        { 
            InitializeComponent(); 
            this.wndMain = wndMain; 
        }      
        private void Button_ClickCancel(object sender, RoutedEventArgs e) 
        {             
            wndMain.MainFrame.Navigate(new PgHome()); 
        }         
        private void Button_ClickYes(object sender, RoutedEventArgs e) 
        { 
            MainWindow mainWindow = new(); 
            wndMain.Close(); 
            mainWindow.Show();             
        } 
    } 
}
