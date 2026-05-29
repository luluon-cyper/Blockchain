using System.Collections.Generic;
using Bai1.Models;

namespace Bai1.Interfaces
{
    public interface IBlock
    {
        int Index { get; set; }
        string PrevHash { get; set; }
        string Hash { get; set; }
        List<Transaction> Transactions { get; set; }
        void AddTransaction(Transaction transaction);
        string CalculateMerkleRoot();
        string CalculateHash(string previousHash);
        void Seal(string previousHash);
        bool Verify(string expectedPrevHash, List<string> errors);  
    }
}