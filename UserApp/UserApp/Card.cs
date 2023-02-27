using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp
{
    internal class Card
    {
        public bool Number
        {
            get 
            {
                /*Random rnd = new();
                WndMain.Nmbill.Text = rnd.Next();*/
                return Number;
            }
            set 
            {
                
            }
        }
        public bool CVV
        {
            get { return CVV; }
            set { value = CVV; }
        }
        public bool Validity
        {
            get { return Validity; }
            set { value = Validity; }
        }
    }
}
