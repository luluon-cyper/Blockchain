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
        public string PublicKey { get; set; }

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

        public string CalculateHash()
        {
            string raw = $"{this.SoChungNhan}|{this.MaSoThue}|{this.TenCongTy}|{this.LoaiSanPham}|{this.NgayCap}|{this.NgayHetHan}";
            return HashData.Hash(raw);
        }

        public void Seal()
        {
            TransactionHash = CalculateHash();
        }
        public void Sign()
        {
            string data = $"{this.SoChungNhan}|{this.MaSoThue}|{this.TenCongTy}|{this.LoaiSanPham}|{this.NgayCap}|{this.NgayHetHan}";
            (Signature, PublicKey) = HashData.Sign(data);
        }
    }
}