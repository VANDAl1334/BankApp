using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp
{
    class Bill
    {

        public bool Frozen { get; set; }
        public string Balance { get; set; }
        public string Numcard { get; }
        public string NumberCard
        {
            get
            {
                Random rnd = new();
                string num1 = rnd.Next(10000000, 99999999).ToString();
                string num2 = rnd.Next(10000000, 99999999).ToString();
                string numcard = num1 + num2;
                return numcard;
            }
        }
        public Bill(string numcard, bool frozen, string balance)
        {
            Numcard = numcard;
            Frozen = frozen;
            Balance = balance;
        }
    }
}
