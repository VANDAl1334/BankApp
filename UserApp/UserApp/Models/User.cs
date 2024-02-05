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
        public List<Bill> Bills;
        public string FullName
        {
            get
            {
                return surname_user + " " + name_user + " " + patronymic_user;
            }
        }        
                 
    }
}
