using System;
using System.Text.Json.Serialization;
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

        public Transaction()
        {
        }

        public Transaction(string SoChungNhan, string MaSoThue, string TenCongTy, string LoaiSanPham, DateTime NgayCap, DateTime NgayHetHan)
        {
            this.SoChungNhan = SoChungNhan;
            this.MaSoThue = MaSoThue;
            this.TenCongTy = TenCongTy;
            this.LoaiSanPham = LoaiSanPham;
            this.NgayCap = NgayCap;
            this.NgayHetHan = NgayHetHan;
            Seal();
            Sign();
        }

        private string GetRawData()
        {
            return $"{SoChungNhan}|{MaSoThue}|{TenCongTy}|{LoaiSanPham}|{NgayCap:O}|{NgayHetHan:O}";
        }

        public string CalculateHash()
        {
            return HashData.Hash(GetRawData());
        }

        public void Seal()
        {
            TransactionHash = CalculateHash();
        }

        public void Sign()
        {
            if (string.IsNullOrWhiteSpace(TransactionHash))
                Seal();

            Signature = HashData.Sign(GetRawData());
        }

        public bool VerifySignature()
        {
            return HashData.Verify(GetRawData(), Signature);
        }

        public bool Verify()
        {
            return TransactionHash == CalculateHash() && VerifySignature();
        }
    }
}