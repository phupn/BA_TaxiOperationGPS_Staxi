namespace Taxi.GUI
{
    partial class frmDanhBaCongTy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhBaCongTy));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupTop = new DevExpress.XtraEditors.GroupControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.groupTop)).BeginInit();
            this.groupTop.SuspendLayout();
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
            // groupTop
            // 
            this.groupTop.Controls.Add(this.editDiaChi);
            this.groupTop.Controls.Add(this.editTen);
            this.groupTop.Controls.Add(this.editSoDienThoai);
            this.groupTop.Controls.Add(this.labelControl3);
            this.groupTop.Controls.Add(this.labelControl2);
            this.groupTop.Controls.Add(this.labelControl1);
            this.groupTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupTop.Location = new System.Drawing.Point(0, 0);
            this.groupTop.Name = "groupTop";
            this.groupTop.Size = new System.Drawing.Size(334, 237);
            this.groupTop.TabIndex = 2;
            this.groupTop.Text = "Thông tin công ty";
            // 
            // editDiaChi
            // 
            this.editDiaChi.Location = new System.Drawing.Point(94, 106);
            this.editDiaChi.Name = "editDiaChi";
            this.editDiaChi.Size = new System.Drawing.Size(224, 57);
            this.editDiaChi.TabIndex = 3;
            // 
            // editTen
            // 
            this.editTen.Location = new System.Drawing.Point(94, 76);
            this.editTen.Name = "editTen";
            this.editTen.Size = new System.Drawing.Size(224, 20);
            this.editTen.TabIndex = 2;
            // 
            // editSoDienThoai
            // 
            this.editSoDienThoai.Location = new System.Drawing.Point(94, 44);
            this.editSoDienThoai.Name = "editSoDienThoai";
            this.editSoDienThoai.Size = new System.Drawing.Size(224, 20);
            this.editSoDienThoai.TabIndex = 1;
            this.editSoDienThoai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editSoHieuXe_KeyPress);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(39, 107);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Địa chỉ (*)";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 79);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tên công ty (*)";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 47);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Số điện thoại (*)";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnThoat);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 198);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(334, 39);
            this.panelControl1.TabIndex = 3;
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::Taxi.Controls.Properties.Resources.exit_icon;
            this.btnThoat.Location = new System.Drawing.Point(166, 5);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(97, 30);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát (Esc)";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Taxi.Controls.Properties.Resources.ic_add_01;
            this.btnSave.Location = new System.Drawing.Point(80, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu (F2)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmDanhBaCongTy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 237);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.groupTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmDanhBaCongTy";
            this.Text = "Thêm/Sửa công ty";
            this.Load += new System.EventHandler(this.frmDoiTac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupTop)).EndInit();
            this.groupTop.ResumeLayout(false);
            this.groupTop.PerformLayout();
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
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.GroupControl groupTop;
        private DevExpress.XtraEditors.MemoEdit editDiaChi;
        private DevExpress.XtraEditors.TextEdit editTen;
        private DevExpress.XtraEditors.TextEdit editSoDienThoai;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}