using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Libs
{
    public class Client
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public List<Bill> bills = new List<Bill>();

        public Client(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
