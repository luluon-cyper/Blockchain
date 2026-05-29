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
        public string MerkleRoot { get; set; }
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

        public string CalculateMerkleRoot()
        {
            if (Transactions == null || Transactions.Count == 0)
            {
                return HashData.Hash(string.Empty);
            }

            List<string> layer = Transactions
                .Select(t => string.IsNullOrWhiteSpace(t.TransactionHash) ? t.CalculateHash() : t.TransactionHash)
                .ToList();

            while (layer.Count > 1)
            {
                if (layer.Count % 2 == 1)
                {
                    layer.Add(layer[layer.Count - 1]);
                }

                List<string> nextLayer = new List<string>();
                for (int i = 0; i < layer.Count; i += 2)
                {
                    nextLayer.Add(HashData.Hash($"{layer[i]}|{layer[i + 1]}"));
                }

                layer = nextLayer;
            }

            return layer[0];
        }

        private string CalculateLegacyHash(string previousHash)
        {
            string txHashes = string.Join("|", Transactions.Select(t => t.TransactionHash ?? t.CalculateHash()));
            string raw = $"{Index}|{previousHash}|{txHashes}";
            return HashData.Hash(raw);
        }

        public string CalculateHash(string previousHash)
        {
            MerkleRoot = CalculateMerkleRoot();
            string raw = $"{Index}|{previousHash}|{MerkleRoot}";
            return HashData.Hash(raw);
        }

        public void Seal(string previousHash)
        {
            PrevHash = previousHash;
            MerkleRoot = CalculateMerkleRoot();
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
                    errors.Add($"Block {Index} - Transaction {i + 1} bị sửa.");
                }
            }

            string recalculatedMerkleRoot = CalculateMerkleRoot();

            if (!string.IsNullOrWhiteSpace(MerkleRoot) &&
                !string.Equals(MerkleRoot, recalculatedMerkleRoot, StringComparison.Ordinal))
            {
                ok = false;
                errors.Add($"Block {Index} bị sai Merkle root.");
            }

            string recalculatedBlockHash = HashData.Hash($"{Index}|{expectedPrevHash}|{recalculatedMerkleRoot}");
            string legacyHash = CalculateLegacyHash(expectedPrevHash);

            if (!string.Equals(Hash, recalculatedBlockHash, StringComparison.Ordinal) &&
                !string.Equals(Hash, legacyHash, StringComparison.Ordinal))
            {
                ok = false;
                errors.Add($"Block {Index} bị sửa (Hash không hợp lệ).");
            }

            return ok;
        }
    }
}
