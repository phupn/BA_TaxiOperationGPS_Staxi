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
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.btnSave = new Janus.Windows.EditControls.UIButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.tabDiaChi = new Janus.Windows.UI.Tab.UITabPage();
            this.editDiaChi = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label10 = new System.Windows.Forms.Label();
            this.editTen = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editSoDienThoai = new Janus.Windows.GridEX.EditControls.EditBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.tabDiaChi.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::TaxiApplication.Properties.Resources.Close;
            this.btnCancel.Location = new System.Drawing.Point(189, 79);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 26);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Thoát";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Image = global::TaxiApplication.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(102, 79);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 26);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = " &Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // uiTab1
            // 
            this.uiTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTab1.Location = new System.Drawing.Point(0, 0);
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.Size = new System.Drawing.Size(458, 140);
            this.uiTab1.TabIndex = 0;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.tabDiaChi});
            this.uiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2003;
            // 
            // tabDiaChi
            // 
            this.tabDiaChi.Controls.Add(this.btnCancel);
            this.tabDiaChi.Controls.Add(this.btnSave);
            this.tabDiaChi.Controls.Add(this.editDiaChi);
            this.tabDiaChi.Controls.Add(this.label10);
            this.tabDiaChi.Controls.Add(this.editTen);
            this.tabDiaChi.Controls.Add(this.label2);
            this.tabDiaChi.Controls.Add(this.label1);
            this.tabDiaChi.Controls.Add(this.editSoDienThoai);
            this.tabDiaChi.Location = new System.Drawing.Point(1, 21);
            this.tabDiaChi.Name = "tabDiaChi";
            this.tabDiaChi.Size = new System.Drawing.Size(456, 118);
            this.tabDiaChi.TabStop = true;
            this.tabDiaChi.Text = "Thông tin khách ảo";
            // 
            // editDiaChi
            // 
            this.editDiaChi.Location = new System.Drawing.Point(102, 55);
            this.editDiaChi.Margin = new System.Windows.Forms.Padding(2);
            this.editDiaChi.MaxLength = 255;
            this.editDiaChi.Name = "editDiaChi";
            this.editDiaChi.Size = new System.Drawing.Size(343, 20);
            this.editDiaChi.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(46, 56);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Địa chỉ (*)";
            // 
            // editTen
            // 
            this.editTen.Location = new System.Drawing.Point(102, 29);
            this.editTen.Margin = new System.Windows.Forms.Padding(2);
            this.editTen.MaxLength = 50;
            this.editTen.Name = "editTen";
            this.editTen.Size = new System.Drawing.Size(343, 20);
            this.editTen.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(56, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Tên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(15, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Số điện thoại (*)";
            // 
            // editSoDienThoai
            // 
            this.editSoDienThoai.Location = new System.Drawing.Point(102, 2);
            this.editSoDienThoai.Margin = new System.Windows.Forms.Padding(2);
            this.editSoDienThoai.MaxLength = 11;
            this.editSoDienThoai.Name = "editSoDienThoai";
            this.editSoDienThoai.Size = new System.Drawing.Size(118, 20);
            this.editSoDienThoai.TabIndex = 0;
            this.editSoDienThoai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editSoHieuXe_KeyPress);
            // 
            // frmDanhBaCongTy
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(458, 140);
            this.ControlBox = false;
            this.Controls.Add(this.uiTab1);
            this.Icon = TaxiApplication.Properties.Resources.Telephone_01;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmDanhBaCongTy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm/Sửa khách ảo";
            this.Load += new System.EventHandler(this.frmDoiTac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.tabDiaChi.ResumeLayout(false);
            this.tabDiaChi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIButton btnCancel;
        private Janus.Windows.EditControls.UIButton btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage tabDiaChi;
        private Janus.Windows.GridEX.EditControls.EditBox editDiaChi;
        private System.Windows.Forms.Label label10;
        private Janus.Windows.GridEX.EditControls.EditBox editTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.EditControls.EditBox editSoDienThoai;
    }
}