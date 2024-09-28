using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UserApp.Models;
namespace UserApp
{
    public class User
    {
        public static User CurrentUser;
        public uint id { get; set; }
        public string name_user { get; set; }
        public string surname_user { get; set; }
        public string? patronymic_user { get; set; }
        public string login_user { get; set; }
        public string password_user { get; set; }
        public string Role_id { get; set; }
        public string Email { get; set; }
        public UInt64 transaction_owner { get; set; }
        public List<Transaction> Transactions;
        public List<Bill> Bills = new();
        public int? Count;
        public string FullName
        {
            get
            {
                return surname_user + " " + name_user + " " + patronymic_user;
            }
        }        
                 
    }
}
