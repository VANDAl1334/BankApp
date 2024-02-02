using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp
{
    public class Card
    {
        public static Card CurrentCard = new();
        public string? Number {  get; set; }
        public UInt16 CVV { get; set; }
        public string Validity { get; set; }
    }
}
