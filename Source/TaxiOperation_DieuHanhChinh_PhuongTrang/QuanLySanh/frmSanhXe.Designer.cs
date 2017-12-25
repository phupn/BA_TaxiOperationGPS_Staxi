namespace Taxi.GUI
{
    partial class frmSanhXe
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
            this.lstSanh = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkThemSanh = new System.Windows.Forms.LinkLabel();
            this.lnkSuaSanh = new System.Windows.Forms.LinkLabel();
            this.lnkXoa = new System.Windows.Forms.LinkLabel();
            this.lstXeThuocSanh = new System.Windows.Forms.ListBox();
            this.lstXeKhongThuocSanhNao = new System.Windows.Forms.ListBox();
            this.btnRemoveOne = new System.Windows.Forms.Button();
            this.btnAddOne = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstSanh
            // 
            this.lstSanh.FormattingEnabled = true;
            this.lstSanh.Location = new System.Drawing.Point(12, 38);
            this.lstSanh.Name = "lstSanh";
            this.lstSanh.Size = new System.Drawing.Size(205, 394);
            this.lstSanh.TabIndex = 0;
            this.lstSanh.SelectedIndexChanged += new System.EventHandler(this.lstSanh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh sách sảnh";
            // 
            // lnkThemSanh
            // 
            this.lnkThemSanh.AutoSize = true;
            this.lnkThemSanh.Location = new System.Drawing.Point(17, 442);
            this.lnkThemSanh.Name = "lnkThemSanh";
            this.lnkThemSanh.Size = new System.Drawing.Size(53, 13);
            this.lnkThemSanh.TabIndex = 2;
            this.lnkThemSanh.TabStop = true;
            this.lnkThemSanh.Text = "Thêm mới";
            this.lnkThemSanh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkThemSanh_LinkClicked);
            // 
            // lnkSuaSanh
            // 
            this.lnkSuaSanh.AutoSize = true;
            this.lnkSuaSanh.Location = new System.Drawing.Point(74, 442);
            this.lnkSuaSanh.Name = "lnkSuaSanh";
            this.lnkSuaSanh.Size = new System.Drawing.Size(26, 13);
            this.lnkSuaSanh.TabIndex = 3;
            this.lnkSuaSanh.TabStop = true;
            this.lnkSuaSanh.Text = "Sửa";
            this.lnkSuaSanh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSuaSanh_LinkClicked);
            // 
            // lnkXoa
            // 
            this.lnkXoa.AutoSize = true;
            this.lnkXoa.Location = new System.Drawing.Point(105, 442);
            this.lnkXoa.Name = "lnkXoa";
            this.lnkXoa.Size = new System.Drawing.Size(26, 13);
            this.lnkXoa.TabIndex = 4;
            this.lnkXoa.TabStop = true;
            this.lnkXoa.Text = "Xóa";
            this.lnkXoa.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkXoa_LinkClicked);
            // 
            // lstXeThuocSanh
            // 
            this.lstXeThuocSanh.FormattingEnabled = true;
            this.lstXeThuocSanh.Location = new System.Drawing.Point(223, 38);
            this.lstXeThuocSanh.Name = "lstXeThuocSanh";
            this.lstXeThuocSanh.Size = new System.Drawing.Size(227, 394);
            this.lstXeThuocSanh.TabIndex = 5;
            // 
            // lstXeKhongThuocSanhNao
            // 
            this.lstXeKhongThuocSanhNao.FormattingEnabled = true;
            this.lstXeKhongThuocSanhNao.Location = new System.Drawing.Point(514, 38);
            this.lstXeKhongThuocSanhNao.Name = "lstXeKhongThuocSanhNao";
            this.lstXeKhongThuocSanhNao.Size = new System.Drawing.Size(227, 394);
            this.lstXeKhongThuocSanhNao.TabIndex = 6;
            // 
            // btnRemoveOne
            // 
            this.btnRemoveOne.Location = new System.Drawing.Point(456, 174);
            this.btnRemoveOne.Name = "btnRemoveOne";
            this.btnRemoveOne.Size = new System.Drawing.Size(52, 23);
            this.btnRemoveOne.TabIndex = 8;
            this.btnRemoveOne.Text = ">";
            this.btnRemoveOne.UseVisualStyleBackColor = true;
            this.btnRemoveOne.Click += new System.EventHandler(this.btnRemoveOne_Click);
            // 
            // btnAddOne
            // 
            this.btnAddOne.Location = new System.Drawing.Point(456, 203);
            this.btnAddOne.Name = "btnAddOne";
            this.btnAddOne.Size = new System.Drawing.Size(52, 23);
            this.btnAddOne.TabIndex = 10;
            this.btnAddOne.Text = "<";
            this.btnAddOne.UseVisualStyleBackColor = true;
            this.btnAddOne.Click += new System.EventHandler(this.btnAddOne_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Danh sách xe thuộc sảnh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(511, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Danh sách xe không thuộc sảnh nào";
            // 
            // frmSanhXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 471);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddOne);
            this.Controls.Add(this.btnRemoveOne);
            this.Controls.Add(this.lstXeKhongThuocSanhNao);
            this.Controls.Add(this.lstXeThuocSanh);
            this.Controls.Add(this.lnkXoa);
            this.Controls.Add(this.lnkSuaSanh);
            this.Controls.Add(this.lnkThemSanh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstSanh);
            this.Name = "frmSanhXe";
            this.Text = "Quản lý xe thuộc sảnh";
            this.Load += new System.EventHandler(this.frmSanhXe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstSanh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkThemSanh;
        private System.Windows.Forms.LinkLabel lnkSuaSanh;
        private System.Windows.Forms.LinkLabel lnkXoa;
        private System.Windows.Forms.ListBox lstXeThuocSanh;
        private System.Windows.Forms.ListBox lstXeKhongThuocSanhNao;
        private System.Windows.Forms.Button btnRemoveOne;
        private System.Windows.Forms.Button btnAddOne;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}