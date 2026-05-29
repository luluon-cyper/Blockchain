using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai1.Crypto;
using Bai1.Models;
    
namespace Bai1
{
    public partial class Form1 : Form
    {
        private List<Transaction> pending = new List<Transaction>();
        private List<Block> chain = new List<Block>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshBlockGrid();
        }

        private string GetDisplayMerkleRoot(Block block)
        {
            if (block == null) return string.Empty;
            return string.IsNullOrWhiteSpace(block.MerkleRoot) ? block.CalculateMerkleRoot() : block.MerkleRoot;
        }

        private void RefreshBlockGrid()
        {
            dataGridView2.Rows.Clear();

            foreach (var block in chain)
            {
                dataGridView2.Rows.Add(
                    block.Index,
                    block.PrevHash,
                    GetDisplayMerkleRoot(block),
                    block.Hash
                );
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtSoChungNhan.Text == "" || txtMaSoThue.Text == "" || txtTenCongTy.Text == "" || txtLoaiSanPham.Text == "")
            {
                MessageBox.Show("Thiếu dữ liệu");
                return;
            }

            Transaction tx = new Transaction
            {
                SoChungNhan = txtSoChungNhan.Text,
                MaSoThue = txtMaSoThue.Text,
                TenCongTy = txtTenCongTy.Text,
                LoaiSanPham = txtLoaiSanPham.Text,
                NgayCap = dtNgayCap.Value,
                NgayHetHan = dtNgayHetHan.Value,
            };

            tx.Sign();
            pending.Add(tx);

            dgvTransaction.Rows.Add(
                tx.SoChungNhan,
                tx.MaSoThue,
                tx.TenCongTy,
                tx.LoaiSanPham,
                tx.NgayCap.ToString("dd/MM/yyyy"),
                tx.NgayHetHan.ToString("dd/MM/yyyy")
            );

            txtSoChungNhan.Clear();
            txtMaSoThue.Clear();
            txtTenCongTy.Clear();
            txtLoaiSanPham.Clear();

            if (pending.Count == 2)
                CreateBlock();
        }

        private void CreateBlock()
        {
            if (pending.Count == 0)
                return;

            Block block = new Block(chain.Count);

            foreach (var tx in pending)
            {
                block.AddTransaction(tx);
            }

            string prevHash = chain.Count == 0 ? "0" : chain.Last().Hash;

            block.Seal(prevHash);
            chain.Add(block);

            dataGridView2.Rows.Add(
                block.Index,
                block.PrevHash,
                block.MerkleRoot,
                block.Hash
            );

            pending.Clear();
            dgvTransaction.Rows.Clear();
        }

        private void btnSaveBlock_Click(object sender, EventArgs e)
        {
            string folder = Path.Combine(Application.StartupPath, "..\\..\\data");
            Directory.CreateDirectory(folder);

            string path = Path.Combine(folder, "Blockchain.json");

            File.WriteAllText(path,
                JsonSerializer.Serialize(chain, new JsonSerializerOptions
                {
                    WriteIndented = true
                })
            );

            MessageBox.Show("Đã lưu");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "..\\..\\data\\Blockchain.json");

            if (!File.Exists(path))
            {
                MessageBox.Show("Không có file");
                return;
            }

            string json = File.ReadAllText(path);

            if (string.IsNullOrWhiteSpace(json))
            {
                MessageBox.Show("File rỗng");
                return;
            }

            chain = JsonSerializer.Deserialize<List<Block>>(json) ?? new List<Block>();

            dataGridView2.Rows.Clear();
            foreach (var block in chain)
            {
                dataGridView2.Rows.Add(
                    block.Index,
                    block.PrevHash,
                    GetDisplayMerkleRoot(block),
                    block.Hash
                );
            }
        }

        private void btnCheckBlock_Click(object sender, EventArgs e)
        {
            List<string> errors = new List<string>();
            bool ok = true;
            string prevHash = "0";

            for (int i = 0; i < chain.Count; i++)
            {
                Block block = chain[i];
                if (block == null || !block.Verify(prevHash, errors))
                    ok = false;

                prevHash = block?.Hash;
            }

            if (ok && errors.Count == 0)
            {
                MessageBox.Show("Blockchain hợp lệ");
            }
            else
            {
                MessageBox.Show(string.Join(Environment.NewLine, errors));
            }
        }

        private void btnDetailBlock_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null)
            {
                MessageBox.Show("Chọn một block trước");
                return;
            }

            string chiSoStr = dataGridView2.CurrentRow.Cells["colIndex"].Value?.ToString();
            if (!int.TryParse(chiSoStr, out int chiSo))
            {
                MessageBox.Show("Không đọc được chỉ số block");
                return;
            }

            Block bl = chain.FirstOrDefault(b => b.Index == chiSo);
            if (bl == null)
            {
                MessageBox.Show("Không tìm thấy block");
                return;
            }

            string info = $"Block {bl.Index}\nPrevHash: {bl.PrevHash}\nHash: {bl.Hash}\nTransactions:\n";

            foreach (Transaction tx in bl.Transactions)
            {
                info += $" * {tx.SoChungNhan} | {tx.MaSoThue} | {tx.TenCongTy} | {tx.LoaiSanPham} | {tx.NgayCap:dd/MM/yyyy} | {tx.NgayHetHan:dd/MM/yyyy} | \nHash: {tx.TransactionHash} | \nSig: {tx.Signature}\n\n";
            }

            MessageBox.Show(info);
        }
    }
}