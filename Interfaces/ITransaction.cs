using System;

namespace Bai1.Interfaces
{
    public interface ITransaction
    {
        string SoChungNhan { get; set; }
        string MaSoThue { get; set; }
        string TenCongTy { get; set; }
        string LoaiSanPham { get; set; }
        DateTime NgayCap { get; set; }
        DateTime NgayHetHan { get; set; }
        string TransactionHash { get; set; }
        string Signature { get; set; }
        string CalculateHash();
        void Seal();
        void Sign();
    }
}