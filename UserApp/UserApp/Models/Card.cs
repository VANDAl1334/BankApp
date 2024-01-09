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
        public string Number { get; set; }
        public int CVV { get; set; }
        public string Validity { get; set; }
    }
}
