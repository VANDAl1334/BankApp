﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.Libs
{
    public class LibBill
    {
        public static void AddBill(User user)
        {
            DB.OpenConnection();
            DataTable table = new();
            string numbill = GenBill();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("INSERT INTO `bill` (`Number`, `Frozen`, `Balance`, bill_owner) VALUES (@N, @F, @B, @BO)", DB.GetConnection());
            DB.cmd.Parameters.Add("@N", MySqlDbType.VarChar).Value = numbill;
            DB.cmd.Parameters.Add("@F", MySqlDbType.VarChar).Value = 0;
            DB.cmd.Parameters.Add("@B", MySqlDbType.Float).Value = 0.0;
            DB.cmd.Parameters.Add("@BO", MySqlDbType.Int32).Value = user.id;
            adapter.SelectCommand = DB.cmd;
            adapter.Fill(table);
        }
        public static void GetBillByUser(string numbill)
        {
            DB.OpenConnection();
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("SELECT `Number` FROM `bill` WHERE `Number` = @bN", DB.GetConnection());
            DB.cmd.Parameters.Add("@bN", MySqlDbType.VarChar).Value = numbill;
            adapter.SelectCommand = DB.cmd;
            adapter.Fill(table);
            DataRow[] rows = table.Select();
            if (table.Rows.Count > 0)
            {
                GenBill();
            }
            else
            {
                Bill bill = new()
                {
                    NumberBill = DB.ConvertFromDBVal<string>(rows[0].ItemArray[0]),
                    Frozen = DB.ConvertFromDBVal<bool>(rows[0].ItemArray[1]),
                    Balance = DB.ConvertFromDBVal<string>(rows[0].ItemArray[2]),
                    NumberCard = DB.ConvertFromDBVal<string>(rows[0].ItemArray[3])
                };
            }
        }
        public static string GenBill()
        {
            string numbill;
            Random rnd = new((int)DateTime.Now.Ticks);
            string num1 = rnd.Next(000001, 999999).ToString();
            string num2 = rnd.Next(0000001, 9999999).ToString();
            string num3 = rnd.Next(0000001, 9999999).ToString();
            numbill = num1 + num2 + num3;
            GetBillByUser(numbill);
            return numbill;
        }
    }
}
