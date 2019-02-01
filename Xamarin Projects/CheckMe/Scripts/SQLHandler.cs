using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CheckMeFinal
{
    public class SQLHandler
    {
        public bool AddUserToTable(User user)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.SQL_PATH))
            {
                conn.CreateTable<User>();

                var numberOfRows = conn.Insert(user);

                if (numberOfRows > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void DeleteUserFromTable(User user)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.SQL_PATH))
            {
                conn.CreateTable<User>();
                conn.Delete(user);
            }
        }

        public void GetListViewFromTable(ListView view)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.SQL_PATH))
            {
                conn.CreateTable<User>();

                var users = conn.Table<User>().ToList();

                view.ItemsSource = users;
            }
        }
    }
}
