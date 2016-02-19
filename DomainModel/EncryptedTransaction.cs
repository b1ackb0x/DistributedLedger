using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class EncryptedTransaction
    {
        public Byte[] TransactionBytes { get; set; }
        public Transaction  Transaction { get; set; }
    }
}
