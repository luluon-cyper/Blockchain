using System;
using Bai1.Crypto;
using Bai1.Interfaces;

namespace Bai1.Models
{
    public class Transaction : ITransaction
    {
        public string SoChungNhan { get; set; }
        public string MaSoThue { get; set; }
        public string TenCongTy { get; set; }
        public string LoaiSanPham { get; set; }
        public DateTime NgayCap { get; set; }
        public DateTime NgayHetHan { get; set; }
        public string TransactionHash { get; set; }
        public string Signature { get; set; }

        private string GetRawData()
        {
            return $"{SoChungNhan}|{MaSoThue}|{TenCongTy}|{LoaiSanPham}|{NgayCap:O}|{NgayHetHan:O}";
        }

        public string CalculateHash()
        {
            return HashData.Hash(GetRawData());
        }

        public void Sign()
        {
            TransactionHash = CalculateHash();
            Signature = HashData.Sign(GetRawData());
        }

        public void Seal()
        {
            Sign();
        }

        public bool Verify()
        {
            return TransactionHash == CalculateHash() &&
                   HashData.Verify(GetRawData(), Signature);
        }
    }
}
