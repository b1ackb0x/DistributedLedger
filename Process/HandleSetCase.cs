﻿using DomainModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Process
{
    public class HandleSetCase
    {
        public Transaction transaction { get; set; }

        public HandleSetCase(Account senderAccount, Account receiverAccount, double transactionAmount)
        {
            transaction = new Transaction();
            transaction.ID = Guid.NewGuid();
            transaction.Amount = transactionAmount;
            transaction.ReceiverAccount = receiverAccount;
            transaction.SenderAccount = senderAccount;
            transaction.TimeStamp = DateTimeOffset.UtcNow;
        }

        public void SetBlockChain()
        {
            BlockChain bc = Repository.BlockChainMaster.BlockChain;

            Block latestBlock = Repository.BlockChainMaster.GetLatestBlock();

            //Determine the size of encrypt transaction + Size of Existing block,
            if (GetSize(transaction) + GetSize(latestBlock) < latestBlock.Threshhold)
            {
                //Add in existing
                latestBlock.EncryptedTransactions.Add(transaction);
            }
            else
            {
                //create new
                latestBlock = CreateNewBlock(latestBlock);
                bc.Blocks.Add(latestBlock.ProofOfWork, (latestBlock));
            }
        }


        public Block CreateNewBlock(Block latestBlock)
        {
            Block newBlock = new Block();
            newBlock.TimeStamp = DateTimeOffset.UtcNow;
            newBlock.ProofOfWork = CustomHash.ComputeHash(transaction.Amount.ToString(), "SHA256", null);
            newBlock.PreviousBlock = latestBlock.PreviousBlock;
            newBlock.EncryptedTransactions = new List<Transaction>();
            newBlock.EncryptedTransactions.Add(transaction);

            return newBlock;
        }


        private long GetSize(object o)
        {
            long size = 0;
            using (Stream s = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(s, o);
                size = s.Length;
            }

            return size;
        }
    }
}
