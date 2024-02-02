using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X500;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp
{
    public class Bill
    {
        public static Bill CurrentBill = new();
        public string NumberBill { get; set; }
        public string Frozen { get; set; }
        public float Balance { get; set; }
        public string? NumberCard { get; set; }
        public uint bill_owner { get; set; }
        
    }
}
