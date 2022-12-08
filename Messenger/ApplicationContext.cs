using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Messenger
{
    // Класс, чтобы подключится к БД и как-то манипулировать с ней
    internal class ApplicationContext : DbContext
    {
        // Список, который будет вытягивать какие-то элементы из таблицы
        public DbSet<User> Users { get; set; }

        public ApplicationContext() : base("DefaultConnection") {}
    }
}
