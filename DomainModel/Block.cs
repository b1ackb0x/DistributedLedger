using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Block
    {
        public string ProofOfWork { get; set; }

        public DateTimeOffset TimeStamp { get; set; }

        public List<Transaction> EncryptedTransactions { get; set; }

        public Block PreviousBlock { get; set; }

        public long Threshhold { get; set; }
    }
}
