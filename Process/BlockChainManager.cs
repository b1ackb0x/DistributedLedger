using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace Process
{
    public static class BlockChainManager
    {
        public static BlockChain GetBlockChain()
        {
           return Repository.BlockChainMaster.BlockChain;
        }
    }
}
