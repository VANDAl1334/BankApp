using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.Libs
{
    public class LibCard
    {
        public static void AddCard()
        {
            string NumberSenderCard = GenCard();
            DB.OpenConnection();
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("INSERT INTO `card` (`NumberSender`, `CVV`, `Validity`) VALUES (@bN, @bC, @bV); UPDATE bill SET Card_NumberSender = @bN WHERE bill.NumberSender = @bNb", DB.GetConnection());
            DB.cmd.Parameters.Add("@bN", MySqlDbType.VarChar).Value = NumberSenderCard;
            DB.cmd.Parameters.Add("@bC", MySqlDbType.UInt16).Value = GenCVV();
            DB.cmd.Parameters.Add("@bV", MySqlDbType.VarChar).Value = GetValidity();
            DB.cmd.Parameters.Add("@bNb", MySqlDbType.VarChar).Value = Bill.CurrentBill.NumberBill;
            adapter.SelectCommand = DB.cmd;
            adapter.Fill(table);
            Card.CurrentCard.NumberSender = NumberSenderCard;
        }
        /*public static void GetCardByBill()
        {
            DB.OpenConnection();
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("SELECT `NumberSender` FROM `bill` WHERE `Card_NumberSender` = @bN", DB.GetConnection());
            DB.cmd.Parameters.Add("@bN", MySqlDbType.VarChar).Value = ;
            adapter.SelectCommand = DB.cmd;
            adapter.Fill(table);
        }*/
        public static Card GetCard()
        {
            DB.OpenConnection();
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("SELECT * FROM `card` INNER JOIN `bill` on card.NumberSender = bill.Card_NumberSender WHERE bill.NumberSender = @bNb", DB.GetConnection());
            DB.cmd.Parameters.Add("@bNb", MySqlDbType.VarChar).Value = Bill.CurrentBill.NumberBill;
            adapter.SelectCommand = DB.cmd;
            DB.TryConnection(adapter, table);
            DataRow[] rows = table.Select();
            if (table.Rows.Count > 0)
            {
                Card card = new()
                {
                    NumberSender = DB.ConvertFromDBVal<string>(rows[0].ItemArray[0]),
                    CVV = DB.ConvertFromDBVal<UInt16>(rows[0].ItemArray[1]),
                    Validity = DB.ConvertFromDBVal<string>(rows[0].ItemArray[2])
                };
                Card.CurrentCard = card;
                return card;
            }
            return null;
        }
        public static string GenCard()
        {
            string numcard;
            Random rnd = new();
            string num1 = rnd.Next(1000, 9999).ToString();
            string num2 = rnd.Next(1000, 9999).ToString();
            string num3 = rnd.Next(1000, 9999).ToString();
            string num4 = rnd.Next(1000, 9999).ToString();
            numcard = num1 + " " + num2 + " " + num3 + " " + num4;
            return numcard;
        }
        public static UInt16 GenCVV()
        {
            UInt16 cvv;
            Random rnd = new();
            cvv = (UInt16)rnd.Next(100, 999);
            return cvv;
        }
        public static string GetValidity()
        {
            string monthDate = DateTime.Now.Month.ToString();
            string yearDate = DateTime.Now.Year.ToString();
            string validity = monthDate + "/" + yearDate;
            return validity;
        }
    }
}
