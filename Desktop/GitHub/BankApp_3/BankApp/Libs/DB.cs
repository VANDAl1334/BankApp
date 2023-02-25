using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Libs
{
    static class DB
    {
        static MySqlConnection Connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=bankdb");
        public static DataTable Table = new DataTable();
        public static MySqlDataAdapter Adapter = new MySqlDataAdapter();
        public static MySqlCommand Command = new MySqlCommand();

        static public void OpenConnection()
        {
            if(Connection.State == System.Data.ConnectionState.Closed)
            {
                Connection.Open();
            }
        }

        static public void CloseConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }

        static public MySqlConnection GetConnection()
        {
            return Connection;
        }
    }
}
