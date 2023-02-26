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

namespace BankApp.UI.Client.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ucTransactionBlock.xaml
    /// </summary>
    public partial class ucTransactionBlock : UserControl
    {
        public string TransactionType { get; set; }
        public string BillTo { get; set; }
        public string BillFrom { get; set; }
        public string FullName { get; set; }    
        public string Amount { get; set; }
        public string TransactionID { get; set; }
        public string Data { get; set; }
        public string Status { get; set; }
        
        public ucTransactionBlock()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
