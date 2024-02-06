using MySql.Data.MySqlClient;
using Mysqlx.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UserApp
{
    static class DB
    {
        static MySqlConnection connection = new("server=localhost;port=3306;username=root;password=;database=bank");
        static public DataTable table = new();
        static public MySqlDataAdapter adapter = new();
        static public MySqlCommand cmd = new();
        public static bool stateConnection;
        static public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                try { connection.Open(); } catch { MessageBox.Show("OpenConnection"); }
        }
        public static T ConvertFromDBVal<T>(object? obj)
        {
            if (obj == null || obj == DBNull.Value)
                return default(T);
            else
                return (T)obj;
        }
        static public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        public static Boolean TryConnection(MySqlDataAdapter adapter, DataTable table)
        {
            try { adapter.Fill(table); } catch { stateConnection = false; return false; }
            stateConnection = true;
            return true;
        }
        static public MySqlConnection GetConnection()
        {
            try { return connection; } catch { MessageBox.Show("GetConnection"); }
            return null;            
        }
    }
}
