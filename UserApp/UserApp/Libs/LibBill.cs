using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.Models;

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
            DB.cmd.Parameters.Add("@F", MySqlDbType.Byte).Value = 0;
            DB.cmd.Parameters.Add("@B", MySqlDbType.Float).Value = 0.0;
            DB.cmd.Parameters.Add("@BO", MySqlDbType.UInt32).Value = user.id;
            adapter.SelectCommand = DB.cmd;
            DB.TryConnection(adapter, table);
        }

        public static int? GetBill(User user)
        {
            DB.OpenConnection();
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("SELECT * FROM `bill` inner join `user` on user.id = bill.bill_owner WHERE `bill_owner` = @bo", DB.GetConnection());
            DB.cmd.Parameters.Add("@bo", MySqlDbType.VarChar).Value = user.id;
            adapter.SelectCommand = DB.cmd;
            DB.TryConnection(adapter, table);          
            if (table.Rows.Count > 0)
                return table.Rows.Count;
            return null;
        }
        /*        public static Bill UpdateBills(Bill bill)
                {
                    DB.OpenConnection();
                    DataTable table = new();
                    MySqlDataAdapter adapter = new();
                    DB.cmd = new("SELECT * FROM `bill` inner join `user` on user.id = bill.bill_owner WHERE `bill_owner` = @bo", DB.GetConnection());
                    DB.cmd.Parameters.Add("@uL", MySqlDbType.VarChar).Value = bill.bill_owner;
                    adapter.SelectCommand = DB.cmd;
                    adapter.Fill(table);
                    return bill;
                }*/
        /*public static void UpdateBillsByCard()
        {
            DB.OpenConnection();
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("SELECT * FROM `bill` inner join `user` on user.id = bill.bill_owner WHERE `bill_owner` = @bo", DB.GetConnection());
            DB.cmd.Parameters.Add("@uL", MySqlDbType.VarChar).Value = bill.bill_owner;
            adapter.SelectCommand = DB.cmd;
            adapter.Fill(table);
        }*/
        public static List<Transaction?> GetListTransactionByUser(User user)
        {
            List<Transaction> transactions = new();
            DB.OpenConnection();
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("SELECT * FROM `v_transaction` WHERE sender_id = @si", DB.GetConnection());
            DB.cmd.Parameters.Add("@si", MySqlDbType.UInt32).Value = user.id;
            adapter.SelectCommand = DB.cmd;
            DB.TryConnection(adapter, table);
            DataRow[] rows = table.Select();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in rows)
                {
                    Transaction transaction = new()
                    {
                        Id = DB.ConvertFromDBVal<UInt64>(row.ItemArray[0]),
                        Type_transaction = DB.ConvertFromDBVal<string>(row.ItemArray[3]),
                        Sender = DB.ConvertFromDBVal<string>(row.ItemArray[8]),
                        Recipient = DB.ConvertFromDBVal<string>(row.ItemArray[7]),
                        Status = DB.ConvertFromDBVal<string>(row.ItemArray[6]),
                        Amount = DB.ConvertFromDBVal<float>(row.ItemArray[2]),
                        Date = DB.ConvertFromDBVal<DateTime>(row.ItemArray[9])
                    };
                    transactions.Add(transaction);
                }
                return transactions;
            }
            return null;
        }
        public static void GetBillByUser(string numbill)
        {
            DB.OpenConnection();
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("SELECT `Number` FROM `bill` WHERE `Number` = @bN", DB.GetConnection());
            DB.cmd.Parameters.Add("@bN", MySqlDbType.VarChar).Value = numbill;
            adapter.SelectCommand = DB.cmd;
            DB.TryConnection(adapter, table);
            if (table.Rows.Count > 0)            
                GenBill();
        }
        public static void BillTransaction(byte typeTransaction, string nmBillSender, string nmBillRecipient, string amount)
        {
            DB.OpenConnection();
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("INSERT INTO `transaction` (`Type_transfer`, `transfer_recipient`, `transfer_sender`, `status_id`, `amount`, `Date`) VALUES (@bNT, @bNR, @bNS, @bS, @bNa, @bD)", DB.GetConnection());
            DB.cmd.Parameters.Add("@bNT", MySqlDbType.TinyBlob).Value = typeTransaction;
            DB.cmd.Parameters.Add("@bNS", MySqlDbType.VarChar).Value = nmBillSender;
            DB.cmd.Parameters.Add("@bS", MySqlDbType.TinyBlob).Value = 1;
            DB.cmd.Parameters.Add("@bNR", MySqlDbType.VarChar).Value = nmBillRecipient;
            DB.cmd.Parameters.Add("@bNa", MySqlDbType.Float).Value = float.Parse(amount);
            DB.cmd.Parameters.Add("@bD", MySqlDbType.Date).Value = DateTime.Now;
            adapter.SelectCommand = DB.cmd;
            DB.TryConnection(adapter, table);
        }
        public static string GenBill()
        {
            string numbill;
            Random rnd = new((int)DateTime.Now.Ticks);
            string num1 = rnd.Next(100000, 999999).ToString();
            string num2 = rnd.Next(1000000, 9999999).ToString();
            string num3 = rnd.Next(1000000, 9999999).ToString();
            numbill = num1 + num2 + num3;
            GetBillByUser(numbill);
            return numbill;
        }
    }
}
