using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X500;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp
{
    public class Bill
    {
        public static Bill CurrentNumcard = new();
        Bill() { }
        public string NumberBill { get; set; }
        public bool Frozen { get; set; }
        public string Balance { get; set; }
        public string NumberCard { get; set; }
        public Bill(string numbill, string numcard, bool frozen, string balance)
        {
            NumberBill = numbill;
            NumberCard = numcard;
            Frozen = frozen;
            Balance = balance;
        }
        public static void AddBill(User user)
        {
            DB.OpenConnection();
            DataTable table = new();
            string numbill = GenBill();
            string numcard = GenCard();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("INSERT INTO `bill` (`Number`, `Frozen`, `Balance`, `Card_number`) SELECT @N, @F, @B, @Cn FROM `user` INNER JOIN `bill` ON user.id = bill.bill_owner WHERE user.login_user = @uL", DB.GetConnection());
            DB.cmd.Parameters.Add("@uL", MySqlDbType.VarChar).Value = user;
            DB.cmd.Parameters.Add("@N", MySqlDbType.VarChar).Value = numbill;
            DB.cmd.Parameters.Add("@F", MySqlDbType.Int16).Value = 0;
            DB.cmd.Parameters.Add("@B", MySqlDbType.Float).Value = 0.0;
            DB.cmd.Parameters.Add("@Cn", MySqlDbType.VarChar).Value = numcard;
            adapter.SelectCommand = DB.cmd;
            adapter.Fill(table);
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
        public static string GenBill()
        {
            string numbill;
            Random rnd = new();
            string num1 = rnd.Next(100000, 999999).ToString();
            string num2 = rnd.Next(1000000, 9999999).ToString();
            string num3 = rnd.Next(1000000, 9999999).ToString();
            numbill = num1 + num2 + num3;
            return numbill;
        }
    }
}
