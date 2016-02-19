using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Transaction
    {
        public Guid ID { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public double Amount { get; set; }
        public Account SenderAccount { get; set; }
        public Account ReceiverAccount { get; set; }

    }
}
