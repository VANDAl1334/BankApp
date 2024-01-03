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
        public static User CurrentUser = new();
        public string name_user { get; set; }
        public string surname_user { get; set; }
        public string patronymic_user { get; set; }
        public string login_user { get; set; }
        public string password_user { get; set; }
        public string Role_id { get; set; }
        public string Phone { get; set; }
        public string FullName
        {
            get
            {
                return surname_user + " " + name_user + " " + patronymic_user;
            }
        }
        
        /*public User(string name_user, string surname_user, string patronymic_user, string login_user, string password_user)
        {
            this.name_user = name_user;
            this.surname_user = surname_user;
            this.patronymic_user = patronymic_user;
            this.login_user = login_user;
            this.password_user = password_user;
        }*/
        public User() { }
        
        public List<Bill> Bills;
        
        
        
    }
}
