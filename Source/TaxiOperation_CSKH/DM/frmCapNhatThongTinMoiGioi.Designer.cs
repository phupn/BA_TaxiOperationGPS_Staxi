﻿namespace Taxi.GUI
{
    partial class frmCapNhatThongTinMoiGioi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapNhatThongTinMoiGioi));
            this.listMoiGioi = new System.Windows.Forms.ListBox();
            this.listMoiGioiChon = new System.Windows.Forms.ListBox();
            this.btnTroLai1 = new System.Windows.Forms.Button();
            this.btnCapNhatThongtinMoiGioi = new System.Windows.Forms.Button();
            this.btnTroLaiHet = new System.Windows.Forms.Button();
            this.btnChon1 = new System.Windows.Forms.Button();
            this.btnnChonHet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listMoiGioi
            // 
            this.listMoiGioi.FormattingEnabled = true;
            this.listMoiGioi.Location = new System.Drawing.Point(24, 38);
            this.listMoiGioi.Name = "listMoiGioi";
            this.listMoiGioi.ScrollAlwaysVisible = true;
            this.listMoiGioi.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listMoiGioi.Size = new System.Drawing.Size(399, 498);
            this.listMoiGioi.TabIndex = 0;
            // 
            // listMoiGioiChon
            // 
            this.listMoiGioiChon.FormattingEnabled = true;
            this.listMoiGioiChon.Location = new System.Drawing.Point(482, 38);
            this.listMoiGioiChon.Name = "listMoiGioiChon";
            this.listMoiGioiChon.ScrollAlwaysVisible = true;
            this.listMoiGioiChon.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listMoiGioiChon.Size = new System.Drawing.Size(399, 498);
            this.listMoiGioiChon.TabIndex = 1;
            // 
            // btnTroLai1
            // 
            this.btnTroLai1.Location = new System.Drawing.Point(436, 278);
            this.btnTroLai1.Name = "btnTroLai1";
            this.btnTroLai1.Size = new System.Drawing.Size(31, 23);
            this.btnTroLai1.TabIndex = 2;
            this.btnTroLai1.Text = "<";
            this.btnTroLai1.UseVisualStyleBackColor = true;
            this.btnTroLai1.Click += new System.EventHandler(this.btnTroLai1_Click);
            // 
            // btnCapNhatThongtinMoiGioi
            // 
            this.btnCapNhatThongtinMoiGioi.Location = new System.Drawing.Point(753, 543);
            this.btnCapNhatThongtinMoiGioi.Name = "btnCapNhatThongtinMoiGioi";
            this.btnCapNhatThongtinMoiGioi.Size = new System.Drawing.Size(128, 23);
            this.btnCapNhatThongtinMoiGioi.TabIndex = 3;
            this.btnCapNhatThongtinMoiGioi.Text = "Cập nhật cuộc môi giới";
            this.btnCapNhatThongtinMoiGioi.UseVisualStyleBackColor = true;
            this.btnCapNhatThongtinMoiGioi.Click += new System.EventHandler(this.btnCapNhatThongtinMoiGioi_Click);
            // 
            // btnTroLaiHet
            // 
            this.btnTroLaiHet.Location = new System.Drawing.Point(436, 309);
            this.btnTroLaiHet.Name = "btnTroLaiHet";
            this.btnTroLaiHet.Size = new System.Drawing.Size(31, 23);
            this.btnTroLaiHet.TabIndex = 4;
            this.btnTroLaiHet.Text = "<<";
            this.btnTroLaiHet.UseVisualStyleBackColor = true;
            this.btnTroLaiHet.Click += new System.EventHandler(this.btnTroLaiHet_Click);
            // 
            // btnChon1
            // 
            this.btnChon1.Location = new System.Drawing.Point(436, 247);
            this.btnChon1.Name = "btnChon1";
            this.btnChon1.Size = new System.Drawing.Size(31, 23);
            this.btnChon1.TabIndex = 5;
            this.btnChon1.Text = ">";
            this.btnChon1.UseVisualStyleBackColor = true;
            this.btnChon1.Click += new System.EventHandler(this.btnChon1_Click);
            // 
            // btnnChonHet
            // 
            this.btnnChonHet.Location = new System.Drawing.Point(436, 216);
            this.btnnChonHet.Name = "btnnChonHet";
            this.btnnChonHet.Size = new System.Drawing.Size(31, 23);
            this.btnnChonHet.TabIndex = 6;
            this.btnnChonHet.Text = ">>";
            this.btnnChonHet.UseVisualStyleBackColor = true;
            this.btnnChonHet.Click += new System.EventHandler(this.btnnChonHet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Danh sách môi giới";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(479, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Danh sách môi giới cập nhật lại thông tin cuộc gọi";
            // 
            // frmCapNhatThongTinMoiGioi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 578);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnnChonHet);
            this.Controls.Add(this.btnChon1);
            this.Controls.Add(this.btnTroLaiHet);
            this.Controls.Add(this.btnCapNhatThongtinMoiGioi);
            this.Controls.Add(this.btnTroLai1);
            this.Controls.Add(this.listMoiGioiChon);
            this.Controls.Add(this.listMoiGioi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCapNhatThongTinMoiGioi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật lại cuộc gọi môi giới";
            this.Load += new System.EventHandler(this.frmCapNhatThongTinMoiGioi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listMoiGioi;
        private System.Windows.Forms.ListBox listMoiGioiChon;
        private System.Windows.Forms.Button btnTroLai1;
        private System.Windows.Forms.Button btnCapNhatThongtinMoiGioi;
        private System.Windows.Forms.Button btnTroLaiHet;
        private System.Windows.Forms.Button btnChon1;
        private System.Windows.Forms.Button btnnChonHet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}