﻿using DomainModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BlockChainMaster
    {
        static BlockChainMaster()
        {
            //two account exist in block one of blockchain
            Block bc1 = new Block();
            bc1.EncryptedTransactions = new List<Transaction>();
            bc1.EncryptedTransactions.Add(new Transaction() { Amount = 15000, ID = Guid.NewGuid(), ReceiverAccount = new Account() { ID = 1, HolderName = "Pallav", TotalAmount = 15000 }, SenderAccount = new Account() { ID = 1, HolderName = "Pallav", TotalAmount = 10000 }, TimeStamp = DateTimeOffset.UtcNow });
            bc1.ProofOfWork = "DadixJ72LcerXouFPg3EJdpEVdbZAo+A5bUEeIin/c+ZtMZE6";
            bc1.TimeStamp = DateTimeOffset.UtcNow;
            bc1.Threshhold = 1000;

            bc1.EncryptedTransactions.Add(new Transaction() { Amount = 10000, ID = Guid.NewGuid(), ReceiverAccount = new Account() { ID = 2, HolderName = "Saanvi", TotalAmount = 10000 }, SenderAccount = new Account() { ID = 2, HolderName = "Saanvi", TotalAmount = 1000 }, TimeStamp = DateTimeOffset.UtcNow });
            bc1.TimeStamp = DateTimeOffset.UtcNow;

            bc1.EncryptedTransactions.Add(new Transaction()
            {
                Amount = 12000,
                ID = Guid.NewGuid(),
                ReceiverAccount = new Account() {ID = 3, HolderName = "Pankaj", TotalAmount = 12000, TransferAmount = 0},
                SenderAccount = new Account() {HolderName = "Pankaj", ID = 3, TotalAmount = 12000, TransferAmount = 0}
            });

            BlockChain = new BlockChain();
            BlockChain.Blocks = new Hashtable();
            BlockChain.Blocks.Add(bc1.ProofOfWork, bc1);

        }
        public static BlockChain BlockChain { get; set; }

        public static Block GetLatestBlock()
        {
            return BlockChain.Blocks.Values.OfType<Block>().OrderByDescending(a => a.TimeStamp).FirstOrDefault();
        }

    }
}
