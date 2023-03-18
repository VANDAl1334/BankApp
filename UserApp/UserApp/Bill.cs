using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp
{
    class Bill
    {
        public static Bill CurrentNumcard = new();
        public bool Frozen 
        {
            get
            {
                return Frozen;
            }
            set
            {
                value = Frozen;
            }
        }
        public string Balance 
        {
            get
            {
                return Balance;
            }
            set
            {
                value = Balance;
            }
        }               
        public string NumberCard
        {
            set
            {
                value = NumberCard;
            }
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
            NumberCard = numcard;
            Frozen = frozen;
            Balance = balance;
        }
        Bill() { }
    }
}
