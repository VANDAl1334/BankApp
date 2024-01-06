using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using UserApp.Window.Authorization;
namespace UserApp.Models
{
    public class LibUser
    {
        public User user;
        static public void AddUser(User user)
        {
            DB.OpenConnection();
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("INSERT INTO `user` (`name_user`, `surname_user`, `patronymic_user`,`login_user`, `password_user`, `Role_id`, Phone) VALUES (@uN, @uS, @uPt, @uL, @uP, @uR, @uPh)", DB.GetConnection());
            DB.cmd.Parameters.Add("@uN", MySqlDbType.VarChar).Value = user.name_user;
            DB.cmd.Parameters.Add("@uS", MySqlDbType.VarChar).Value = user.surname_user;
            DB.cmd.Parameters.Add("@uPt", MySqlDbType.VarChar).Value = user.patronymic_user;
            DB.cmd.Parameters.Add("@uL", MySqlDbType.VarChar).Value = user.login_user;
            DB.cmd.Parameters.Add("@uP", MySqlDbType.VarChar).Value = user.password_user;
            DB.cmd.Parameters.Add("@uR", MySqlDbType.VarChar).Value = user.Role_id;
            DB.cmd.Parameters.Add("@uPh", MySqlDbType.VarChar).Value = user.Phone;
            adapter.SelectCommand = DB.cmd;
            adapter.Fill(table);

        }
        public static void UpdateBills(User user)
        {
            DB.OpenConnection();
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("SELECT * FROM `user` INNER JOIN `bill` on user.id = bill.bill_owner WHERE user.login_user = @uL", DB.GetConnection());
            DB.cmd.Parameters.Add("@uL", MySqlDbType.VarChar).Value = user.login_user;
            adapter.SelectCommand = DB.cmd;
            adapter.Fill(table);
        }
        public static User GetUserByLogIn(User user)
        {
            DB.OpenConnection();
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            user.password_user = Hash(user.password_user);
            DB.cmd = new("SELECT * FROM `user` WHERE `login_user` = @uL AND `password_user` = @uP", DB.GetConnection());
            DB.cmd.Parameters.Add("@uL", MySqlDbType.VarChar).Value = user.login_user;
            DB.cmd.Parameters.Add("@uP", MySqlDbType.VarChar).Value = user.password_user;
            adapter.SelectCommand = DB.cmd;
            adapter.Fill(table);
            DataRow[] rows = table.Select();
            if (table.Rows.Count > 0)
            {
                User us = new User { name_user = DB.ConvertFromDBVal<string>(rows[0].ItemArray[1]),
                    surname_user = DB.ConvertFromDBVal<string>(rows[0].ItemArray[2]),
                    patronymic_user = DB.ConvertFromDBVal<string>(rows[0].ItemArray[3]),
                    login_user = DB.ConvertFromDBVal<string>(rows[0].ItemArray[4]),
                    password_user = DB.ConvertFromDBVal<string>(rows[0].ItemArray[5]),
                    Role_id = DB.ConvertFromDBVal<string>(rows[0].ItemArray[6]),
                    Phone = DB.ConvertFromDBVal<string>(rows[0].ItemArray[7])};
                return us;
            }
            return null;
        }
        public static Boolean IsUserExists(string LogClient)
        {
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("SELECT * FROM `user` WHERE `login_user` = @cL", DB.GetConnection());
            DB.cmd.Parameters.Add("@cL", MySqlDbType.VarChar).Value = LogClient;
            adapter.SelectCommand = DB.cmd;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }
        static public string Hash(string input)
        {
            var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }

        public static User GetUserByLogIn(string login, string password)
        {
            DB.OpenConnection();
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            password = Hash(password);
            DB.cmd = new("SELECT * FROM `user` WHERE `login_user` = @uL AND `password_user` = @uP", DB.GetConnection());
            DB.cmd.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
            DB.cmd.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;
            adapter.SelectCommand = DB.cmd;
            adapter.Fill(table);
            DataRow[] rows = table.Select();
             if (table.Rows.Count > 0)
            {
                User us = new()
                {
                    name_user = DB.ConvertFromDBVal<string>(rows[0].ItemArray[1]),
                    surname_user = DB.ConvertFromDBVal<string>(rows[0].ItemArray[2]),
                    patronymic_user = DB.ConvertFromDBVal<string>(rows[0].ItemArray[3]),
                    login_user = DB.ConvertFromDBVal<string>(rows[0].ItemArray[4]),
                    password_user = DB.ConvertFromDBVal<string>(rows[0].ItemArray[5]),
                    Role_id = DB.ConvertFromDBVal<string>(rows[0].ItemArray[6]),
                    Phone = DB.ConvertFromDBVal<string>(rows[0].ItemArray[7])
                };
                return us;
            }
            return null;
        }
    }
}
