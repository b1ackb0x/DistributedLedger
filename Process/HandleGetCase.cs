using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Repository;

namespace Process
{
    public class HandleGetCase
    {
        public Account GetAccount(int accountID, Block latestBlock)
        {
            Account account = null;

            if (latestBlock != null)
            {
                IEnumerable<Transaction> t = latestBlock.EncryptedTransactions.Where(o => o.ReceiverAccount == o.SenderAccount && o.ReceiverAccount.ID == accountID);
                if (t != null && t.Count() > 0)
                {
                    account = t.Select(o => o.ReceiverAccount).FirstOrDefault();
                }
                else
                {
                    account = GetAccount(accountID, latestBlock.PreviousBlock);
                }
            }

            return account;
        }
    }
}
