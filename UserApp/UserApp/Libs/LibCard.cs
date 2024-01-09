using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.Libs
{
    public class LibCard
    {
        public static string GenCard()
        {
            string numcard;
            Random rnd = new();
            string num1 = rnd.Next(0001, 9999).ToString();
            string num2 = rnd.Next(0001, 9999).ToString();
            string num3 = rnd.Next(0001, 9999).ToString();
            string num4 = rnd.Next(0001, 9999).ToString();
            numcard = num1 + " " + num2 + " " + num3 + " " + num4;
            return numcard;
        }
    }
}
