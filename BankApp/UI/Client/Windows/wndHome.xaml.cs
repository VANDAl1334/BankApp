using BankApp.UI.Client.Pages;
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

namespace BankApp.UI.Client.Windows
{
    /// <summary>
    /// Логика взаимодействия для wndHome.xaml
    /// </summary>
    public partial class WndHome : Window
    {
        object pageType;                                                    //  Тип открытой страницы
        const string classNamePrefix = "BankApp.UI.Client.Pages.";          //  Префикс названия класса

        /// <summary>
        /// Конструктор. Инициализирует элементы формы и запускает страницу по умолчанию.
        /// </summary>
        public WndHome()
        {
            InitializeComponent();
            PgHome page = new PgHome();
            frame.Navigate(page);
            pageType = page.GetType();
        }

        /// <summary>
        /// Обработчик кнопки "Главная"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            // Если тип страницы не PgHome 
            if(pageType.ToString() != classNamePrefix + "pgHome")
            {
                // Открывается страница PgHome
                PgHome page = new PgHome();
                frame.Navigate(page);
                pageType = page.GetType();
            }            
        }

        /// <summary>
        /// Обработчик кнопки "Перевод"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransfer_Click(object sender, RoutedEventArgs e)
        {
            if(pageType.ToString() != classNamePrefix + "pgTransfer")
            {
                pgTransfer page = new pgTransfer();
                frame.Navigate(page);
                pageType = page.GetType();
            }
        }

        /// <summary>
        /// Обработчик кнопки "Перевод между своими"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTranferBtwBills_Click(object sender, RoutedEventArgs e)
        {
            if (pageType.ToString() != classNamePrefix + "pgTransferBtwBills")
            {               
                string type = pageType.ToString();  
                pgTransferBtwBills page = new pgTransferBtwBills();
                frame.Navigate(page);
                pageType = page.GetType();
            }
        }

        /// <summary>
        /// Обработчик кнопки "История"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            if (pageType.ToString() != classNamePrefix + "pgHistory")
            {
                PgHistory page = new PgHistory();
                frame.Navigate(page);
                pageType = page.GetType();
            }
        }

        /// <summary>
        /// Обработчик кнопки "Выход"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Owner.Show();
            Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
