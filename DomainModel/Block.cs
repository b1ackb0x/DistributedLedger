using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Block
    {
        public string Hash { get; set; }
        public string EncryptedTimeStamp { get; set; }
        public List<EncryptedTransaction> EncryptedTransactions { get; set; }
        public Block  PreviousBlock{ get; set; }
    }
}
