using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BankApp.Libs;

namespace BankApp.UI
{
    /// <summary>
    /// Логика взаимодействия для ucTransaction.xaml
    /// </summary>
    public partial class ucTransaction : UserControl
    {
        public string Client { get; set; }
        public string Bill { get; set; }
        public string Transaction { get; set; }
        public string DateTime { get; set; }
        public ucTransaction()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
