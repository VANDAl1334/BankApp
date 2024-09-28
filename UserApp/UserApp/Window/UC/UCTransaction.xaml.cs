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
namespace UserApp.Window.UC
{
    /// <summary>
    /// Логика взаимодействия для UCTransaction.xaml
    /// </summary>
    public partial class UCTransaction : UserControl
    {
        public Transaction? transaction;
        public UCTransaction(Transaction? transaction)
        {
            this.transaction = transaction;
            InitializeComponent();
            DataContext = transaction;
        }
    }
}
