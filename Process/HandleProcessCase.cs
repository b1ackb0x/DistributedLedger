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

            }
        }

    }
}
