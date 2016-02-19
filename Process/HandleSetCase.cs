using DomainModel;
using System;
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
        public Account SenderAccount { get; set; }
        public Account ReceiverAccount { get; set; }
        public double TransactionAmount { get; set; }

        public HandleSetCase(Account senderAccount, Account receiverAccount, double transactionAmount)
        {
            SenderAccount = senderAccount;
            ReceiverAccount = receiverAccount;
            TransactionAmount = transactionAmount;

            Transaction traction = new Transaction();
            traction.ID = Guid.NewGuid();
            traction.Amount = TransactionAmount;
            traction.ReceiverAccount = ReceiverAccount;
            traction.SenderAccount = SenderAccount;
            traction.TimeStamp = DateTimeOffset.UtcNow;
        }

        public void SetBlockChain()
        {
            BlockChain bc = Repository.BlockChainMaster.BlockChain;

            Block latestBlock = bc.Blocks[bc.Blocks.Count - 1];
            
            //Determine the size of encrypt transaction + Size of Existing block,
            // if is greater than block threshhold, create new block, in the new block, add the reference of previous block , encrypted block, proof of work  
            // else add encrypt transacton in block and update time stamp , proof of work  

        }

        public void CreateBlock()
        {
            //Block.EncryptedTimeStamp = DateTime.UtcNow.ToLongDateString();
            //Block.ProofOfWork = PrepareHash();
            ////Block.EncryptedTransactions=
            //Block.PreviousBlock = PreviousBlock;
        }

        string PrepareHash()
        {
            string hash = string.Empty;
            return hash;
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

        private void EncryptTransaction()
        {

        }

        public void AddToBlock()
        {

        }

        public void AddBlockToBlockChain()
        {

        }

    }
}
