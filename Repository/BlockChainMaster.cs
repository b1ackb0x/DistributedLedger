using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BlockChainMaster
    {
        public static BlockChain BlockChain { get; set; }

        public static Block GetLatestBlockOfBlockChain()
        {
            return BlockChain.Blocks[0];
        }

        public static void SetBlockChain(List<Block> bc)
        {
            BlockChain.Blocks = bc;
        }
    }
}
