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
    public class User
    {
        public static User CurrentUser = new();
        public string name_user { get; set; }
        public string surname_user { get; set; }
        public string patronymic_user { get; set; }
        public string login_user { get; set; }
        public string password_user { get; set; }
        public string FullName
        {
            get
            {
                return name_user + " " + surname_user + " " + patronymic_user;
            }
        }
        //public static string List<Bill> { get; set; }
        
            
        
        public User(string name_user, string surname_user, string patronymic_user, string login_user, string password_user)
        {
            this.name_user = name_user;
            this.surname_user = surname_user;
            this.patronymic_user = patronymic_user;
            this.login_user = login_user;
            this.password_user = password_user;
        }
        public User(){}
        static public void AddUser(string NameUs, string SurNameUs, string PatronymicUs, string LogUs, string PassUs, string Phone)
        {
            string UserRole = "1";
            DB.OpenConnection();
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("INSERT INTO `user` (`name_user`, `surname_user`, `patronymic_user`,`login_user`, `password_user`, `Role_id`, Phone) VALUES (@uN, @uS, @uPt, @uL, @uP, @uR, @uPh)", DB.GetConnection());
            DB.cmd.Parameters.Add("@uN", MySqlDbType.VarChar).Value = NameUs;
            DB.cmd.Parameters.Add("@uS", MySqlDbType.VarChar).Value = SurNameUs;
            DB.cmd.Parameters.Add("@uPt", MySqlDbType.VarChar).Value = PatronymicUs;
            DB.cmd.Parameters.Add("@uL", MySqlDbType.VarChar).Value = LogUs;
            DB.cmd.Parameters.Add("@uP", MySqlDbType.VarChar).Value = PassUs;
            DB.cmd.Parameters.Add("@uR", MySqlDbType.VarChar).Value = UserRole;
            DB.cmd.Parameters.Add("@uPh", MySqlDbType.VarChar).Value = Phone;
            adapter.SelectCommand = DB.cmd;
            adapter.Fill(table);
        }
        public static User GetUserByLogIn(string LogIn)
        {
            DB.OpenConnection();
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("SELECT * FROM `user` WHERE `login_user` = @uL", DB.GetConnection());
            DB.cmd.Parameters.Add("@uL", MySqlDbType.VarChar).Value = LogIn;
            adapter.SelectCommand = DB.cmd;
            adapter.Fill(table);
            DataRow[] rows = table.Select();
            User us = new(DB.ConvertFromDBVal<string>(rows[0].ItemArray[1]), 
                DB.ConvertFromDBVal<string>(rows[0].ItemArray[2]),
                DB.ConvertFromDBVal<string>(rows[0].ItemArray[3]),
                DB.ConvertFromDBVal<string>(rows[0].ItemArray[4]),
                DB.ConvertFromDBVal<string>(rows[0].ItemArray[5]));
            return us;
        }
        static public string Hash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }
    }
}
