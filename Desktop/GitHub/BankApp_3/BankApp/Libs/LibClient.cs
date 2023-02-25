using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Libs
{
    class LibClient : LibUser
    {
        public List<LibBill> bills;
        public LibClient(string login) : base(login)
        {
        }
    }
}
