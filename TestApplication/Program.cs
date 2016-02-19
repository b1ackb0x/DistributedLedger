using DomainModel;
using Process;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockChain bc = BlockChainMaster.BlockChain;

            //Case 1 -- A transfer amount to B
            Account a1 = new Account();
            a1.ID = 1;
            a1.TotalAmount = 100;

            Account a2 = new Account();
            a2.ID = 2;
            a2.TotalAmount = 101;

            HandleSetCase htc = new HandleSetCase(a1, a2, 10);
            htc.SetBlockChain();

            //Case 2 -- A wants to know the current 


            //case 3 -- Server processing 
        }
    }
}
