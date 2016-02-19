using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Transaction
    {
        public int ID { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public double Ammount { get; set; }
        public Account SenderAccount { get; set; }
        public Account ReceiverAccount { get; set; }

    }
}
