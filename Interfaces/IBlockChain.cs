using System.Collections.Generic;
using Bai1.Models;

namespace Bai1.Interfaces
{
    public interface IBlockChain
    {
        List<Block> Blocks { get; }
        Block Current { get; }
        List<string> Errors { get; }

        void AddBlock(Block block);
        void LoadBlocks(List<Block> blocks);
        bool Verify();
    }
}