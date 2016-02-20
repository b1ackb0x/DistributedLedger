﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Serializable]
    public class Block
    {
        public string ProofOfWork { get; set; }

        public DateTimeOffset TimeStamp { get; set; }

        public List<Transaction> EncryptedTransactions { get; set; }

        public string PreviousBlockHash { get; set; }

        public long Threshhold { get; set; }
    }
}
