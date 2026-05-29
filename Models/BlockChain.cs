using System.Collections.Generic;
using System.Linq;
using Bai1.Interfaces;

namespace Bai1.Models
{
    public class BlockChain : IBlockChain
    {
        public List<Block> Blocks { get; private set; }
        public Block Current => Blocks.Count == 0 ? null : Blocks.Last();
        public List<string> Errors { get; private set; }

        public BlockChain()
        {
            Blocks = new List<Block>();
            Errors = new List<string>();
        }

        public void AddBlock(Block block)
        {
            string previousHash = Current == null ? null : Current.Hash;
            block.Seal(previousHash);
            Blocks.Add(block);
        }

        public void LoadBlocks(List<Block> blocks)
        {
            Blocks = blocks ?? new List<Block>();
        }

        public bool Verify()
        {
            Errors.Clear();

            bool ok = true;
            string prevHash = null;

            for (int i = 0; i < Blocks.Count; i++)
            {
                Block block = Blocks[i];

                if (!block.Verify(prevHash, Errors))
                    ok = false;

                prevHash = block.Hash;
            }

            return ok && Errors.Count == 0;
        }
    }
}