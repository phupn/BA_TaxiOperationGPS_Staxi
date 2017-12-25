namespace Taxi.GUI
{
    partial class frmKhachAo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhachAo));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.editDiaChi = new DevExpress.XtraEditors.MemoEdit();
            this.editTen = new DevExpress.XtraEditors.TextEdit();
            this.editSoDienThoai = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSoDienThoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.editDiaChi);
            this.groupControl1.Controls.Add(this.editTen);
            this.groupControl1.Controls.Add(this.editSoDienThoai);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(333, 213);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Thông tin khách ảo";
            // 
            // editDiaChi
            // 
            this.editDiaChi.Location = new System.Drawing.Point(91, 94);
            this.editDiaChi.Name = "editDiaChi";
            this.editDiaChi.Size = new System.Drawing.Size(224, 57);
            this.editDiaChi.TabIndex = 9;
            // 
            // editTen
            // 
            this.editTen.Location = new System.Drawing.Point(91, 64);
            this.editTen.Name = "editTen";
            this.editTen.Size = new System.Drawing.Size(224, 20);
            this.editTen.TabIndex = 7;
            // 
            // editSoDienThoai
            // 
            this.editSoDienThoai.Location = new System.Drawing.Point(91, 32);
            this.editSoDienThoai.Name = "editSoDienThoai";
            this.editSoDienThoai.Size = new System.Drawing.Size(224, 20);
            this.editSoDienThoai.TabIndex = 5;
            this.editSoDienThoai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editSoHieuXe_KeyPress);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(36, 96);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Địa chỉ (*)";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(4, 67);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(81, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Tên khách ảo (*)";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Số điện thoại (*)";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnThoat);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 174);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(333, 39);
            this.panelControl1.TabIndex = 3;
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::Taxi.Controls.Properties.Resources.exit_icon;
            this.btnThoat.Location = new System.Drawing.Point(157, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(97, 30);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát (Esc)";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Taxi.Controls.Properties.Resources.ic_add_01;
            this.btnSave.Location = new System.Drawing.Point(71, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu (F2)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmKhachAo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 213);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.groupControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmKhachAo";
            this.Text = "Thêm/Sửa khách ảo";
            this.Load += new System.EventHandler(this.frmDoiTac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSoDienThoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.MemoEdit editDiaChi;
        private DevExpress.XtraEditors.TextEdit editTen;
        private DevExpress.XtraEditors.TextEdit editSoDienThoai;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}