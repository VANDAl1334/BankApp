using BankApp.Libs;
using BankApp.UI.Client.Windows;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class WndAuthorization : Window
    {
        public WndAuthorization()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события. Инициирует процесс авторизации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAuthorize_Click(object sender, RoutedEventArgs e)
        {
            // Если id != 0, то аккаунт найден
            if (authorize() != 0)
            {
                // Открытие рабочего окна
                WndHome wnd = new WndHome();
                wnd.Owner = this;
                wnd.Show();
                Hide();
            }
            // Иначе выводится сообщение о неуспешной авторизации
            else
            {
                MessageBox.Show("Неверно введён логин или пароль, попробуйте снова", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Метод. Осуществялет поиск аккаунта по логину и паролю  
        /// </summary>
        /// <returns>Возвращает id аккаунта. В случае неудачной авторизации возвращает 0</returns>
        private uint authorize()
        {
            uint id;
            // Если чекбокс "Показать пароль" отмечен 
            if (chbxShowPassword.IsChecked == true)
                // Передаём в качестве параметра TextBox 
                id = LibUser.FindUserByLogopas(tbLogin.Text, tbPassword.Text);
            else
                // Передаём в качестве параметра PasswordBox
                id = LibUser.FindUserByLogopas(tbLogin.Text, pwbxPassword.Password);
            return id;
        }

        /// <summary>
        /// Обработчик события
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbxShowPassword_Click(object sender, RoutedEventArgs e)
        {
            // Если "Показать пароль" - истина
            if(chbxShowPassword.IsChecked == true)
            {
                // Копируем данные из PasswordBox в TextBox
                tbPassword.Text = pwbxPassword.Password;
                // Меняем видимость PasswordBox в TextBox
                pwbxPassword.Visibility = Visibility.Collapsed;
                tbPassword.Visibility = Visibility.Visible;
            }
            else
            {
                // Копируем данные из TextBox в PasswordBox
                pwbxPassword.Password = tbPassword.Text;
                // Меняем видимость PasswordBox в TextBox
                pwbxPassword.Visibility = Visibility.Visible;
                tbPassword.Visibility = Visibility.Collapsed;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
