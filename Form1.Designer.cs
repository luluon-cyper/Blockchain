namespace Bai1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtNgayHetHan = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtLoaiSanPham = new System.Windows.Forms.TextBox();
            this.txtMaSoThue = new System.Windows.Forms.TextBox();
            this.txtTenCongTy = new System.Windows.Forms.TextBox();
            this.txtSoChungNhan = new System.Windows.Forms.TextBox();
            this.dtNgayCap = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTransaction = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnDetailBlock = new System.Windows.Forms.Button();
            this.btnSaveBlock = new System.Windows.Forms.Button();
            this.btnCheckBlock = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrevHash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoChungNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaSoThue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenCongTy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayhetHan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtNgayHetHan);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtLoaiSanPham);
            this.groupBox1.Controls.Add(this.txtMaSoThue);
            this.groupBox1.Controls.Add(this.txtTenCongTy);
            this.groupBox1.Controls.Add(this.txtSoChungNhan);
            this.groupBox1.Controls.Add(this.dtNgayCap);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(19, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(470, 225);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dtNgayHetHan
            // 
            this.dtNgayHetHan.Location = new System.Drawing.Point(103, 148);
            this.dtNgayHetHan.Margin = new System.Windows.Forms.Padding(2);
            this.dtNgayHetHan.Name = "dtNgayHetHan";
            this.dtNgayHetHan.Size = new System.Drawing.Size(258, 20);
            this.dtNgayHetHan.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 152);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Ngày hết hạn";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(192, 179);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 32);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Lưu";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtLoaiSanPham
            // 
            this.txtLoaiSanPham.Location = new System.Drawing.Point(336, 66);
            this.txtLoaiSanPham.Margin = new System.Windows.Forms.Padding(2);
            this.txtLoaiSanPham.Name = "txtLoaiSanPham";
            this.txtLoaiSanPham.Size = new System.Drawing.Size(118, 20);
            this.txtLoaiSanPham.TabIndex = 9;
            // 
            // txtMaSoThue
            // 
            this.txtMaSoThue.Location = new System.Drawing.Point(336, 29);
            this.txtMaSoThue.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaSoThue.Name = "txtMaSoThue";
            this.txtMaSoThue.Size = new System.Drawing.Size(118, 20);
            this.txtMaSoThue.TabIndex = 8;
            // 
            // txtTenCongTy
            // 
            this.txtTenCongTy.Location = new System.Drawing.Point(126, 63);
            this.txtTenCongTy.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenCongTy.Name = "txtTenCongTy";
            this.txtTenCongTy.Size = new System.Drawing.Size(109, 20);
            this.txtTenCongTy.TabIndex = 7;
            // 
            // txtSoChungNhan
            // 
            this.txtSoChungNhan.Location = new System.Drawing.Point(126, 27);
            this.txtSoChungNhan.Margin = new System.Windows.Forms.Padding(2);
            this.txtSoChungNhan.Name = "txtSoChungNhan";
            this.txtSoChungNhan.Size = new System.Drawing.Size(109, 20);
            this.txtSoChungNhan.TabIndex = 6;
            // 
            // dtNgayCap
            // 
            this.dtNgayCap.Location = new System.Drawing.Point(103, 107);
            this.dtNgayCap.Margin = new System.Windows.Forms.Padding(2);
            this.dtNgayCap.Name = "dtNgayCap";
            this.dtNgayCap.Size = new System.Drawing.Size(258, 20);
            this.dtNgayCap.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "loại sản phẩm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mã số thuế ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 107);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày cấp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên công ty";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "số giấy chứng nhận";
            // 
            // dgvTransaction
            // 
            this.dgvTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransaction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSoChungNhan,
            this.colMaSoThue,
            this.colTenCongTy,
            this.colLoaiSanPham,
            this.colNgayCap,
            this.colNgayhetHan});
            this.dgvTransaction.Location = new System.Drawing.Point(19, 348);
            this.dgvTransaction.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTransaction.Name = "dgvTransaction";
            this.dgvTransaction.RowHeadersWidth = 51;
            this.dgvTransaction.RowTemplate.Height = 24;
            this.dgvTransaction.Size = new System.Drawing.Size(947, 222);
            this.dgvTransaction.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndex,
            this.colPrevHash,
            this.colHash});
            this.dataGridView2.Location = new System.Drawing.Point(538, 28);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(428, 225);
            this.dataGridView2.TabIndex = 2;
            // 
            // btnDetailBlock
            // 
            this.btnDetailBlock.Location = new System.Drawing.Point(19, 273);
            this.btnDetailBlock.Margin = new System.Windows.Forms.Padding(2);
            this.btnDetailBlock.Name = "btnDetailBlock";
            this.btnDetailBlock.Size = new System.Drawing.Size(98, 34);
            this.btnDetailBlock.TabIndex = 11;
            this.btnDetailBlock.Text = "Xem chi tiết";
            this.btnDetailBlock.UseVisualStyleBackColor = true;
            this.btnDetailBlock.Click += new System.EventHandler(this.btnDetailBlock_Click);
            // 
            // btnSaveBlock
            // 
            this.btnSaveBlock.Location = new System.Drawing.Point(159, 273);
            this.btnSaveBlock.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveBlock.Name = "btnSaveBlock";
            this.btnSaveBlock.Size = new System.Drawing.Size(98, 34);
            this.btnSaveBlock.TabIndex = 12;
            this.btnSaveBlock.Text = "Lưu Block";
            this.btnSaveBlock.UseVisualStyleBackColor = true;
            this.btnSaveBlock.Click += new System.EventHandler(this.btnSaveBlock_Click);
            // 
            // btnCheckBlock
            // 
            this.btnCheckBlock.Location = new System.Drawing.Point(440, 273);
            this.btnCheckBlock.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheckBlock.Name = "btnCheckBlock";
            this.btnCheckBlock.Size = new System.Drawing.Size(98, 34);
            this.btnCheckBlock.TabIndex = 13;
            this.btnCheckBlock.Text = "Xác thực";
            this.btnCheckBlock.UseVisualStyleBackColor = true;
            this.btnCheckBlock.Click += new System.EventHandler(this.btnCheckBlock_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(298, 273);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(98, 34);
            this.btnLoad.TabIndex = 14;
            this.btnLoad.Text = "Tải file";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // colIndex
            // 
            this.colIndex.HeaderText = "Block";
            this.colIndex.MinimumWidth = 6;
            this.colIndex.Name = "colIndex";
            this.colIndex.Width = 125;
            // 
            // colPrevHash
            // 
            this.colPrevHash.HeaderText = "PreHash";
            this.colPrevHash.MinimumWidth = 6;
            this.colPrevHash.Name = "colPrevHash";
            this.colPrevHash.Width = 125;
            // 
            // colHash
            // 
            this.colHash.HeaderText = "Hash";
            this.colHash.MinimumWidth = 6;
            this.colHash.Name = "colHash";
            this.colHash.Width = 125;
            // 
            // colSoChungNhan
            // 
            this.colSoChungNhan.HeaderText = "Số giấy chứng nhận";
            this.colSoChungNhan.MinimumWidth = 6;
            this.colSoChungNhan.Name = "colSoChungNhan";
            this.colSoChungNhan.Width = 175;
            // 
            // colMaSoThue
            // 
            this.colMaSoThue.HeaderText = "Mã số thuế";
            this.colMaSoThue.MinimumWidth = 6;
            this.colMaSoThue.Name = "colMaSoThue";
            this.colMaSoThue.Width = 125;
            // 
            // colTenCongTy
            // 
            this.colTenCongTy.HeaderText = "Tên công ty";
            this.colTenCongTy.MinimumWidth = 6;
            this.colTenCongTy.Name = "colTenCongTy";
            this.colTenCongTy.Width = 125;
            // 
            // colLoaiSanPham
            // 
            this.colLoaiSanPham.HeaderText = "Loại sản phẩm";
            this.colLoaiSanPham.MinimumWidth = 6;
            this.colLoaiSanPham.Name = "colLoaiSanPham";
            this.colLoaiSanPham.Width = 125;
            // 
            // colNgayCap
            // 
            this.colNgayCap.HeaderText = "Ngày cấp";
            this.colNgayCap.MinimumWidth = 6;
            this.colNgayCap.Name = "colNgayCap";
            this.colNgayCap.Width = 125;
            // 
            // colNgayhetHan
            // 
            this.colNgayhetHan.HeaderText = "Ngày hết hạn";
            this.colNgayhetHan.MinimumWidth = 6;
            this.colNgayhetHan.Name = "colNgayhetHan";
            this.colNgayhetHan.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 581);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnCheckBlock);
            this.Controls.Add(this.btnSaveBlock);
            this.Controls.Add(this.btnDetailBlock);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dgvTransaction);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtLoaiSanPham;
        private System.Windows.Forms.TextBox txtMaSoThue;
        private System.Windows.Forms.TextBox txtTenCongTy;
        private System.Windows.Forms.TextBox txtSoChungNhan;
        private System.Windows.Forms.DateTimePicker dtNgayCap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTransaction;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnDetailBlock;
        private System.Windows.Forms.Button btnSaveBlock;
        private System.Windows.Forms.Button btnCheckBlock;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DateTimePicker dtNgayHetHan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrevHash;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHash;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoChungNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSoThue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenCongTy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayhetHan;
    }
}

