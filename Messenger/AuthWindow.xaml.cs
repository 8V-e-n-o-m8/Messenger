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

namespace Messenger
{   
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            // Получение данных с полей "логин" и "пароль"
            string login = Text_login.Text;
            string password = Text_password.Password;

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
            else
            {
                Text_login.ToolTip = "";
                Text_password.Background = Brushes.Transparent;
                Text_password.ToolTip = "";
                Text_password.Background = Brushes.Transparent;

                User authUser = null;

                //Создание закрытого окружения, внутри которого будет выполняться подключение к нужной БД
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Password == password).FirstOrDefault();
                }

                if (authUser != null)
                {
                    MessageBox.Show("Вы вошли в кабинет!");
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Логин или пароль введены некорректно");
                }
            }
        }

        private void Button_Window_Regist_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
