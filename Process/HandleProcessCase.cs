using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            List<Block> blocksToProcess = new List<Block>(BlockChainMaster.BlockChain.Blocks.OfType<Block>());
            if (_lastProcessedDate > DateTimeOffset.MinValue)
            {
                blocksToProcess = blocksToProcess.Where(b => b.TimeStamp > _lastProcessedDate).OrderBy(b => b.TimeStamp).ToList();
            }
            _lastProcessedDate = DateTimeOffset.Now;
            foreach (Block block in blocksToProcess)
            {
                HandleGetCase objHandleGetCase = new HandleGetCase();
                foreach (var trans in block.EncryptedTransactions)
                {
                    Account senderAccount = objHandleGetCase.GetAccount(trans.SenderAccount.ID);
                    Account receiverAccount = objHandleGetCase.GetAccount(trans.ReceiverAccount.ID);
                    Process.HandleSetCase obj = new HandleSetCase(trans.SenderAccount, trans.SenderAccount, senderAccount.TotalAmount - trans.Amount);
                    obj.SetBlockChain();
                    obj = new HandleSetCase(trans.ReceiverAccount, trans.ReceiverAccount, receiverAccount.TotalAmount + trans.Amount);
                    obj.SetBlockChain();
                }
            }
        }

    }
}
