using System;
using System.Collections.Generic;
using System.Linq;
using Bai1.Crypto;
using Bai1.Interfaces;

namespace Bai1.Models
{
    public class Block : IBlock
    {
        public int Index { get; set; }
        public string PrevHash { get; set; }
        public string Hash { get; set; }

        public List<Transaction> Transactions { get; set; }

        public Block()
        {
            Transactions = new List<Transaction>();
        }

        public Block(int index) : this()
        {
            Index = index;
        }

        public void AddTransaction(Transaction transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction));

            if (string.IsNullOrWhiteSpace(transaction.TransactionHash))
                transaction.Seal();

            Transactions.Add(transaction);
        }

        public string CalculateHash(string previousHash)
        {
            string txHashes = string.Join("|", Transactions.Select(t => t.TransactionHash ?? t.CalculateHash()));
            string raw = $"{Index}|{previousHash}|{txHashes}";
            return HashData.Hash(raw);
        }

        public void Seal(string previousHash)
        {
            PrevHash = previousHash;
            Hash = CalculateHash(previousHash);
        }

        public bool Verify(string expectedPrevHash, List<string> errors)
        {
            bool ok = true;

            if (PrevHash != expectedPrevHash)
            {
                ok = false;
                errors.Add($"Block {Index} bị sai liên kết PrevHash.");
            }

            for (int i = 0; i < Transactions.Count; i++)
            {
                Transaction tx = Transactions[i];
                string recalculatedTxHash = tx.CalculateHash();

                if (tx.TransactionHash != recalculatedTxHash)
                {
                    ok = false;
                    errors.Add(
                        $"Block {Index} - Transaction {i + 1} bị sửa "
                    );
                }
            }

            string recalculatedBlockHash = CalculateHash(expectedPrevHash);
            if (Hash != recalculatedBlockHash)
            {
                ok = false;
                errors.Add($"Block {Index} bị sửa (Hash không hợp lệ).");
            }

            return ok;
        }
    }
}