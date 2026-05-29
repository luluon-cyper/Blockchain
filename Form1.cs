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
                NgayHetHan = dtNgayCap.Value,
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
            Block block = new Block();
            block.Index = chain.Count;

            string prevHash = chain.Count == 0 ? "0" : chain.Last().Hash;

            block.PrevHash = prevHash;

            foreach (var tx in pending)
            {
                block.Transactions.Add(tx);
            }

            string data = block.Index + prevHash;

            foreach (var t in block.Transactions)
                data += t.TransactionHash;

            block.Hash = HashData.Hash(data);

            chain.Add(block);
            dataGridView2.Rows.Add(
                block.Index,
                block.PrevHash,
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

            chain = JsonSerializer.Deserialize<List<Block>>(json);

            dataGridView2.Rows.Clear();
            foreach (var block in chain)
            {
                dataGridView2.Rows.Add(
                    block.Index,
                    block.PrevHash,
                    block.Hash
                );
            }
        }

        private void btnCheckBlock_Click(object sender, EventArgs e)
        {
            List<string> errors = new List<string>();

            string prevHash = "0";
            bool ok = true;

            for (int i = 0; i < chain.Count; i++)
            {
                var block = chain[i];

                for (int j = 0; j < block.Transactions.Count; j++)
                {
                    var tx = block.Transactions[j];

                    if (!tx.Verify())
                    {
                        ok = false;
                        errors.Add($"Block {block.Index} - transaction thứ {j + 1} không hợp lệ (hash/chữ ký).");
                    }
                }

                string data = block.Index + prevHash;

                foreach (var tx in block.Transactions)
                    data += tx.TransactionHash;

                string recalculatedBlockHash = HashData.Hash(data);

                if (block.Hash != recalculatedBlockHash)
                {
                    ok = false;
                    errors.Add($"Block {block.Index} bị sửa");
                }

                prevHash = block.Hash;
            }
            if (ok)
            {
                MessageBox.Show("Blockchain hợp lệ");
            }
            else
            {
                MessageBox.Show(string.Join("\n", errors));
            }
        }

        private void btnDetailBlock_Click(object sender, EventArgs e)
        {
            string chiSoStr = dataGridView2.CurrentRow.Cells["colIndex"].Value?.ToString();

            int ChiSo = int.Parse(chiSoStr);
            Block bl= chain.FirstOrDefault(b => b.Index == ChiSo);
            if (bl != null)
            {
                string info = $"Block {bl.Index}\nPrevHash: {bl.PrevHash}\nHash: {bl.Hash}\nTransactions:\n";
                foreach (var tx in bl.Transactions)
                {
                    info += $" * {tx.SoChungNhan} | {tx.MaSoThue} | {tx.TenCongTy} | {tx.LoaiSanPham} | {tx.NgayCap} | {tx.NgayHetHan} | {tx.Signature}\n";
                }
            }
        }
    }
}