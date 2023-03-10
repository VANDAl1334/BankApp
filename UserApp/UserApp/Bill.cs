using MySql.Data.MySqlClient;
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
        private string number;
        private string numberc;
        public bool Frozen { get; set; }
        public string Balance { get; set; }
        public string NumberBill
        {
            get
            {
                return number;
            }
        }
        public string NumberCard
        {
            get
            {
                return numberc;
            }
        }
        public Bill(string number, string numberc, bool frozen, string balance)
        {
            //this.number = number;
            this.numberc = numberc;
            Frozen = frozen;
            Balance = balance;
            Random rnd = new();
            string num1 = rnd.Next(100000, 999999).ToString();
            string num2 = rnd.Next(10000000, 99999999).ToString();
            string num3 = rnd.Next(100000, 999999).ToString();
            number = num1 + num2 + num3;
            Random rnd1 = new();
            string num11 = rnd1.Next(10000000, 99999999).ToString();
            string num22 = rnd1.Next(10000000, 99999999).ToString();
            numberc = num11 + num22;
        }
        public void IsNumberBillExists()
        {
            DB.OpenConnection();
            DataTable table = new();
            MySqlDataAdapter adapter = new();
            DB.cmd = new("SELECT * FROM `bill` WHERE `Number` = @uN", DB.GetConnection());
            DB.cmd.Parameters.Add("@uN", MySqlDbType.VarChar).Value = number;
            adapter.SelectCommand = DB.cmd;
            adapter.Fill(table);
        }
        public Bill() { }
    }
}
