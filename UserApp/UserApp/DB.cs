using MySql.Data.MySqlClient;
using Mysqlx.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UserApp
{
    static class DB
    {
        static MySqlConnection connection = new("server=localhost;port=3306;username=root;password=789456123;database=bank");
        static public DataTable table = new();
        static public MySqlDataAdapter adapter = new();
        static public MySqlCommand cmd = new();
        static public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        static public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }   
        }
        static public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
