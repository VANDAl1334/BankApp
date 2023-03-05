using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserApp
{
    class Client
    {
        static public void SqlRequest(string NameUs, string SurNameUs, string PatronymicUs, string LogClient, string PassClient)
        {
            string UserRole = "1";
            DB.OpenConnection();
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("INSERT INTO `user` (`name_user`, `surname_user`, `patronymic_user`,`login_user`, `password_user`) VALUES (@cN, @cL, @cP)", DB.GetConnection());
            DB.cmd = new("SELECT * FROM `role` WHERE `id` = @cI", DB.GetConnection());
            DB.cmd.Parameters.Add("@cI", MySqlDbType.VarChar).Value = UserRole;
            DB.cmd.Parameters.Add("@cN", MySqlDbType.VarChar).Value = NameUs;
            DB.cmd.Parameters.Add("@cN", MySqlDbType.VarChar).Value = SurNameUs;
            DB.cmd.Parameters.Add("@cN", MySqlDbType.VarChar).Value = PatronymicUs;
            DB.cmd.Parameters.Add("@cL", MySqlDbType.VarChar).Value = LogClient;
            DB.cmd.Parameters.Add("@cP", MySqlDbType.VarChar).Value = PassClient;
            adapter.SelectCommand = DB.cmd;
            adapter.Fill(table);
        }
        static public string Hash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }
    }
}
