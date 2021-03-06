﻿namespace Taxi.GUI
{
    partial class frmDanhBaCongTyTimKiem
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhBaCongTyTimKiem));
            this.radDiaChi = new System.Windows.Forms.RadioButton();
            this.radDienThoai = new System.Windows.Forms.RadioButton();
            this.radTen = new System.Windows.Forms.RadioButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.editThongTinTimKiem = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editThongTinTimKiem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // radDiaChi
            // 
            this.radDiaChi.AutoSize = true;
            this.radDiaChi.Checked = true;
            this.radDiaChi.Location = new System.Drawing.Point(239, 51);
            this.radDiaChi.Name = "radDiaChi";
            this.radDiaChi.Size = new System.Drawing.Size(57, 17);
            this.radDiaChi.TabIndex = 11;
            this.radDiaChi.TabStop = true;
            this.radDiaChi.Text = "Địa chỉ";
            this.radDiaChi.UseVisualStyleBackColor = true;
            // 
            // radDienThoai
            // 
            this.radDienThoai.AutoSize = true;
            this.radDienThoai.Location = new System.Drawing.Point(74, 51);
            this.radDienThoai.Name = "radDienThoai";
            this.radDienThoai.Size = new System.Drawing.Size(74, 17);
            this.radDienThoai.TabIndex = 10;
            this.radDienThoai.Text = "Điện thoại";
            this.radDienThoai.UseVisualStyleBackColor = true;
            // 
            // radTen
            // 
            this.radTen.AutoSize = true;
            this.radTen.Location = new System.Drawing.Point(153, 51);
            this.radTen.Name = "radTen";
            this.radTen.Size = new System.Drawing.Size(78, 17);
            this.radTen.TabIndex = 9;
            this.radTen.Text = "Tên đối tác";
            this.radTen.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnThoat);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 137);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(397, 39);
            this.panelControl1.TabIndex = 5;
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::Taxi.Controls.Properties.Resources.exit_icon;
            this.btnThoat.Location = new System.Drawing.Point(178, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(97, 30);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát (Esc)";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Taxi.Controls.Properties.Resources.ic_add_01;
            this.btnSave.Location = new System.Drawing.Point(73, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Tìm kiếm (F2)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.radDiaChi);
            this.groupControl1.Controls.Add(this.editThongTinTimKiem);
            this.groupControl1.Controls.Add(this.radDienThoai);
            this.groupControl1.Controls.Add(this.radTen);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(397, 176);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Thông tin danh bạ công ty";
            // 
            // editThongTinTimKiem
            // 
            this.editThongTinTimKiem.Location = new System.Drawing.Point(130, 91);
            this.editThongTinTimKiem.Name = "editThongTinTimKiem";
            this.editThongTinTimKiem.Size = new System.Drawing.Size(255, 20);
            this.editThongTinTimKiem.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Thông tin tìm kiếm";
            // 
            // frmDanhBaCongTyTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 176);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.groupControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmDanhBaCongTyTimKiem";
            this.Text = "Tìm kiếm danh bạ công ty";
            this.Load += new System.EventHandler(this.frmDanhBaCongTyTimKiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editThongTinTimKiem.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.RadioButton radDienThoai;
        private System.Windows.Forms.RadioButton radTen;
        private System.Windows.Forms.RadioButton radDiaChi;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit editThongTinTimKiem;
        private System.Windows.Forms.Label label1;
    }
}