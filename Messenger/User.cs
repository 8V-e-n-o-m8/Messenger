using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger
{
    // Класс-модель
    // Описание поведения какой-то таблицы
    internal class User
    {
        public int id { get; set; }

        private string login, password;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        // Конструктор по умолчанию, без него не обойтись!!!
        public User() { }

        // Конструктор, через который будем устанавливать параметры
        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
    }
}
