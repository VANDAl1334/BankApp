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
    /// Логика взаимодействия для PgUser.xaml
    /// </summary>
    public partial class PgUser : Page
    {
        public PgUser()
        {
            InitializeComponent();
            FullName.Text = User.CurrentUser.FullName;
            LogIn.Text = User.CurrentUser.login_user;
            Mail.Text = User.CurrentUser.Email;
        }
        
    }
}
