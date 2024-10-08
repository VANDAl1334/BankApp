﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using UserApp.Window.Authorization;
using System.Text.RegularExpressions;
using Google.Protobuf.WellKnownTypes;
using System.Windows;

namespace UserApp.Models
{
    public class LibUser
    {
        static public void AddUser(User user)
        {
            DB.OpenConnection();
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("INSERT INTO `user` (`name_user`, `surname_user`, `patronymic_user`,`login_user`, `password_user`, `Role_id`, Email) VALUES (@uN, @uS, @uPt, @uL, @uP, @uR, @uE)", DB.GetConnection());
            DB.cmd.Parameters.Add("@uN", MySqlDbType.VarChar).Value = user.name_user;
            DB.cmd.Parameters.Add("@uS", MySqlDbType.VarChar).Value = user.surname_user;
            DB.cmd.Parameters.Add("@uPt", MySqlDbType.VarChar).Value = user.patronymic_user;
            DB.cmd.Parameters.Add("@uL", MySqlDbType.VarChar).Value = user.login_user;
            DB.cmd.Parameters.Add("@uP", MySqlDbType.VarChar).Value = user.password_user;
            DB.cmd.Parameters.Add("@uR", MySqlDbType.VarChar).Value = user.Role_id;
            DB.cmd.Parameters.Add("@uE", MySqlDbType.VarChar).Value = user.Email;
            adapter.SelectCommand = DB.cmd;
            DB.TryConnection(adapter, table);
        }
        public static Boolean IsUserExistsEmail(string Email)
        {
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("SELECT * FROM `user` WHERE `Email` = @cE", DB.GetConnection());
            DB.cmd.Parameters.Add("@cE", MySqlDbType.VarChar).Value = Email;
            adapter.SelectCommand = DB.cmd;
            if (DB.TryConnection(adapter, table))
            {
                if (table.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public static List<Bill?> GetBillsByUser(User user)
        {
            List<Bill?> bills = new();
            DB.OpenConnection();
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("SELECT * FROM `bill` inner join `user` on user.id = bill.bill_owner WHERE `bill_owner` = @bo", DB.GetConnection());
            DB.cmd.Parameters.Add("@bo", MySqlDbType.VarChar).Value = user.id;
            adapter.SelectCommand = DB.cmd;
            if (DB.TryConnection(adapter, table))
            {
                DataRow[] rows = table.Select();
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        Bill bill = new()
                        {
                            NumberBill = DB.ConvertFromDBVal<string>(row.ItemArray[0]),
                            Frozen = DB.ConvertFromDBVal<Boolean>(row.ItemArray[1]),
                            Balance = DB.ConvertFromDBVal<float>(row.ItemArray[2]),
                            NumberCard = DB.ConvertFromDBVal<string>(row.ItemArray[3]),
                            bill_owner = DB.ConvertFromDBVal<uint>(row.ItemArray[4])
                        };
                        bills.Add(bill);
                    }
                    return bills;
                }
            }
            return null;
        }
        public static Boolean IsUserExistsLogin(string Login)
        {
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("SELECT * FROM `user` WHERE `login_user` = @cL", DB.GetConnection());
            DB.cmd.Parameters.Add("@cL", MySqlDbType.VarChar).Value = Login;
            adapter.SelectCommand = DB.cmd;
            if (DB.TryConnection(adapter, table))
            {
                if (table.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            return true;
        }
        static public string Hash(string input)
        {
            var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }
        public static bool PatternFullName(string fullName)
        {
            for (int i = 0; i < fullName.Length; i++)
            {
                if (!Regex.Match(fullName, "^[а-яА-Яa-zA-Z]*$").Success)
                    return true;
            }
            return false;
        }
        public static bool PatternNumber(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!Regex.Match(number, "^[0-9]*$").Success)
                    return true;
            }
            return false;
        }
        public static bool PatternEmail(string email)
        {
            string patternEmail = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            for (int i = 0; i < email.Length; i++)
            {
                if (Regex.IsMatch(email, patternEmail, RegexOptions.IgnoreCase))
                    return true;
            }
            return false;
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
            DB.TryConnection(adapter, table);
            DataRow[] rows = table.Select();
            if (table.Rows.Count > 0)
            {
                User us = new()
                {
                    id = DB.ConvertFromDBVal<uint>(rows[0].ItemArray[0]),
                    name_user = DB.ConvertFromDBVal<string>(rows[0].ItemArray[1]),
                    surname_user = DB.ConvertFromDBVal<string>(rows[0].ItemArray[2]),
                    patronymic_user = DB.ConvertFromDBVal<string>(rows[0].ItemArray[3]),
                    login_user = DB.ConvertFromDBVal<string>(rows[0].ItemArray[4]),
                    password_user = DB.ConvertFromDBVal<string>(rows[0].ItemArray[5]),
                    Role_id = DB.ConvertFromDBVal<string>(rows[0].ItemArray[6]),
                    Email = DB.ConvertFromDBVal<string>(rows[0].ItemArray[7])
                };
                return us;
            }
            return null;
        }
    }
}
