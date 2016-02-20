using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DomainModel;

namespace Process
{
    // This case handle the transactions with the bank.
    public class HandleProcessCase
    {
        private static DateTimeOffset _lastProcessedDate = DateTimeOffset.MinValue;
        public void SettleTransactions()
        {
            List<Block> blocksToProcess = new List<Block>(BlockChainMaster.BlockChain.Blocks.Values.OfType<Block>());
            if (_lastProcessedDate > DateTimeOffset.MinValue)
            {
                blocksToProcess = blocksToProcess.Where(b => b.TimeStamp > _lastProcessedDate).OrderBy(b => b.TimeStamp).ToList();
            }
            _lastProcessedDate = DateTimeOffset.Now;
            foreach (Block block in blocksToProcess)
            {   
                foreach (var trans in block.EncryptedTransactions)
                {
                    if (trans.SenderAccount.ID == trans.ReceiverAccount.ID)
                    {
                        continue;
                    }
                    Account senderAccount = HandleGetCase.GetAccount(trans.SenderAccount.ID);
                    Process.HandleSetCase obj = new HandleSetCase(trans.SenderAccount, trans.SenderAccount, senderAccount.TotalAmount - trans.Amount);
                    obj.SetBlockChain();
                    Thread.Sleep(1000);
                    Account receiverAccount = HandleGetCase.GetAccount(trans.ReceiverAccount.ID);
                    obj = new HandleSetCase(trans.ReceiverAccount, trans.ReceiverAccount, receiverAccount.TotalAmount + trans.Amount);
                    obj.SetBlockChain();
                }
            }
        }

    }
}
