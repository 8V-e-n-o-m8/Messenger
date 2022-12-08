using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Messenger
{
    /// Логика взаимодействия для MainWindow.xaml
    public partial class MainWindow : Window
    {
        // Ссылка на класс ApplicationContext
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
        }


        // Логика работы кнопки "Войти"
        private void Button_Regist_Click(object sender, RoutedEventArgs e)
        {
            // Получение данных с полей "логин" и "пароль"
            string login = Text_login.Text;
            string password = Text_password.Password;
            string password_2 = Text_password_2.Password;

            // Проверка номера и пароля на элемент ошибки
            if (login.Length < 5)
            {
                Text_login.ToolTip = "Логин введён некорректно";
                Text_login.Background = Brushes.Red;
            }
            else if (password.Length < 7)
            {
                Text_password.ToolTip = "Пароль введён некорректно";
                Text_password.Background = Brushes.Red;
            }
            else if (password != password_2)
            {
                Text_password_2.ToolTip = "Повторный пароль введён некорректно";
                Text_password_2.Background = Brushes.Red;
            }
            else
            {
                Text_login.ToolTip = "";
                Text_password.Background = Brushes.Transparent;
                Text_password.ToolTip = "";
                Text_password.Background = Brushes.Transparent;
                Text_password_2.ToolTip = "";
                Text_password_2.Background = Brushes.Transparent;

                MessageBox.Show("Вы зарегистрировались!");

                // Создание объекта и выделение под него памяти
                User user = new User(login, password);

                // Добавление в БД
                db.Users.Add(user);
                // Сохраннение в БД
                db.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide();
            }
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }
    }
}
