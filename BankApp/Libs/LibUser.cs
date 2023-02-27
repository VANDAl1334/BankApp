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

        public static uint FindUserByLogopas(string login, string password)
        {
            DB.OpenConnection();
            DB.Command.CommandText = "SELECT * FROM `user` WHERE `login` = @uL AND `password` = MD5(@uP)";
            DB.Command.Connection = DB.GetConnection();
            DB.Command.Parameters.Clear();

            DB.Command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
            DB.Command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;

            
            DB.Adapter.SelectCommand = DB.Command;
            DB.Adapter.Fill(DB.Table);

            DataRow[] rows = DB.Table.Select();
            uint id = 0;
            if (DB.Table.Rows.Count > 0)
                id = (uint)rows[0].ItemArray[0];

            DB.CloseConnection();
            return id;
        }
        
    }
}
