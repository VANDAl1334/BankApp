using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.Models
{
    public class Transaction
    {
        public UInt64 Id { get; set; }
        public string Type_transaction { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Status { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
