﻿using MySql.Data.MySqlClient;
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
        public bool Card
        {
            get { return Card; }
            set { Card = value; }
        }
        static public void SqlRequest(string NameUs, string LogClient, string PassClient)
        {
            DB.OpenConnection();
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("INSERT INTO `client` (`name_client`,`login`, `password_client`) VALUES (@cN, @cL, @cP)", DB.GetConnection());
            DB.cmd.Parameters.Add("@cN", MySqlDbType.VarChar).Value = NameUs;
            DB.cmd.Parameters.Add("@cL", MySqlDbType.VarChar).Value = LogClient;
            DB.cmd.Parameters.Add("@cP", MySqlDbType.VarChar).Value = PassClient;
            adapter.SelectCommand = DB.cmd;
            adapter.Fill(table);           

        }
        static public string Hash(string input)
        {
            var md5 = SHA256.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }
    }
}
