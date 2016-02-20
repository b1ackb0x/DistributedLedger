using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Repository;

namespace Process
{
    public static class HandleGetCase
    {
        public static Account GetAccount(int accountID)
        {
            Account account = new Account {ID = accountID, TotalAmount = 0, TransferAmount = 0};
            Block latestBlock = BlockChainMaster.GetLatestBlock();
            while (latestBlock != null)
            {
                IEnumerable<Transaction> t = latestBlock.EncryptedTransactions.Where(o => o.ReceiverAccount.ID == o.SenderAccount.ID && o.ReceiverAccount.ID == accountID);
                if (t != null && t.Count() > 0)
                {
                    Transaction singleT = t.OrderByDescending(o => o.TimeStamp).FirstOrDefault();
                    if (singleT != null)
                    {
                        account.TotalAmount = singleT.Amount;
                        return account;
                    }
                }
                latestBlock = latestBlock.PreviousBlockHash==null? null :  BlockChainMaster.BlockChain.Blocks[latestBlock.PreviousBlockHash] as Block;
            }

            return account;
        }
    }
}
