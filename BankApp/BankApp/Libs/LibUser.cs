using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Libs
{
    class LibUser
    {
        public string Login { get; set; }
        

        public LibUser(string login)
        {
            Login = login;
        }

        public static bool FindUserByLogopas(string login, string password)
        {
            DB.OpenConnection();
            DB.Command.CommandText = "SELECT * FROM `user` WHERE `login` = @uL AND `password` = MD5(@uP)";
            DB.Command.Connection = DB.GetConnection();
            DB.Command.Parameters.Clear();

            DB.Command.Parameters.Add("@uL", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = login;
            DB.Command.Parameters.Add("@uP", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = password;

            
            DB.Adapter.SelectCommand = DB.Command;
            DB.Adapter.Fill(DB.Table);

            DataRow[] rows = DB.Table.Select();
            string? column;
            for(int i = 0; i < rows[0].ItemArray.Length; i++)
            {
                column = (string)rows[0].ItemArray[i];
            }

            DB.CloseConnection();

            if (DB.Table.Rows.Count > 0)
                return true;

            return false;
        }
        
    }
}
