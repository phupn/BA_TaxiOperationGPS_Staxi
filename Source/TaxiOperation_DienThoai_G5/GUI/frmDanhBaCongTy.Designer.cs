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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.editDiaChi = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.editTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editSoDienThoai = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rb_CongTy = new System.Windows.Forms.RadioButton();
            this.rb_KhachAo = new System.Windows.Forms.RadioButton();
            this.rb_KhachHang = new System.Windows.Forms.RadioButton();
            this.pnlType = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlType.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::TaxiApplication.Properties.Resources.Close;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(184, 110);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 26);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Thoát (ESC)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Image = global::TaxiApplication.Properties.Resources.disk;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(97, 110);
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
            // editDiaChi
            // 
            this.editDiaChi.Location = new System.Drawing.Point(97, 55);
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
            this.label10.Location = new System.Drawing.Point(41, 58);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "&Địa chỉ (*)";
            // 
            // editTen
            // 
            this.editTen.Location = new System.Drawing.Point(97, 31);
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
            this.label2.Location = new System.Drawing.Point(67, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "&Tên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "&Số điện thoại (*)";
            // 
            // editSoDienThoai
            // 
            this.editSoDienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editSoDienThoai.Location = new System.Drawing.Point(97, 5);
            this.editSoDienThoai.Margin = new System.Windows.Forms.Padding(2);
            this.editSoDienThoai.MaxLength = 11;
            this.editSoDienThoai.Name = "editSoDienThoai";
            this.editSoDienThoai.Size = new System.Drawing.Size(194, 22);
            this.editSoDienThoai.TabIndex = 0;
            this.editSoDienThoai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editSoHieuXe_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlType);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.editSoDienThoai);
            this.panel1.Controls.Add(this.editDiaChi);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.editTen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 140);
            this.panel1.TabIndex = 7;
            // 
            // rb_CongTy
            // 
            this.rb_CongTy.AutoSize = true;
            this.rb_CongTy.Checked = true;
            this.rb_CongTy.Location = new System.Drawing.Point(3, 3);
            this.rb_CongTy.Name = "rb_CongTy";
            this.rb_CongTy.Size = new System.Drawing.Size(74, 17);
            this.rb_CongTy.TabIndex = 0;
            this.rb_CongTy.Text = "&1.Công Ty";
            this.rb_CongTy.UseVisualStyleBackColor = true;
            this.rb_CongTy.CheckedChanged += new System.EventHandler(this.rb_CongTy_CheckedChanged);
            // 
            // rb_KhachAo
            // 
            this.rb_KhachAo.AutoSize = true;
            this.rb_KhachAo.Location = new System.Drawing.Point(101, 4);
            this.rb_KhachAo.Name = "rb_KhachAo";
            this.rb_KhachAo.Size = new System.Drawing.Size(80, 17);
            this.rb_KhachAo.TabIndex = 1;
            this.rb_KhachAo.Text = "&2.Khách ảo";
            this.rb_KhachAo.UseVisualStyleBackColor = true;
            this.rb_KhachAo.CheckedChanged += new System.EventHandler(this.rb_KhachAo_CheckedChanged);
            // 
            // rb_KhachHang
            // 
            this.rb_KhachHang.AutoSize = true;
            this.rb_KhachHang.Location = new System.Drawing.Point(202, 4);
            this.rb_KhachHang.Name = "rb_KhachHang";
            this.rb_KhachHang.Size = new System.Drawing.Size(94, 17);
            this.rb_KhachHang.TabIndex = 2;
            this.rb_KhachHang.Text = "&3.Khách Hàng";
            this.rb_KhachHang.UseVisualStyleBackColor = true;
            this.rb_KhachHang.CheckedChanged += new System.EventHandler(this.rb_KhachHang_CheckedChanged);
            // 
            // pnlType
            // 
            this.pnlType.Controls.Add(this.rb_CongTy);
            this.pnlType.Controls.Add(this.rb_KhachHang);
            this.pnlType.Controls.Add(this.rb_KhachAo);
            this.pnlType.Location = new System.Drawing.Point(97, 80);
            this.pnlType.Name = "pnlType";
            this.pnlType.Size = new System.Drawing.Size(343, 25);
            this.pnlType.TabIndex = 36;
            this.pnlType.Visible = false;
            // 
            // frmDanhBaCongTy
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(458, 140);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Icon = global::TaxiApplication.Properties.Resources.Telephone_01;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmDanhBaCongTy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm/Sửa khách ảo";
            this.Load += new System.EventHandler(this.frmDoiTac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlType.ResumeLayout(false);
            this.pnlType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox editDiaChi;
        private System.Windows.Forms.TextBox editTen;
        private System.Windows.Forms.TextBox editSoDienThoai;
        //private Janus.Windows.EditControls.UIButton btnCancel;
        //private Janus.Windows.EditControls.UIButton btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider;
        //private Janus.Windows.UI.Tab.UITab uiTab1;
        //private Janus.Windows.UI.Tab.UITabPage tabDiaChi;
        //private Janus.Windows.GridEX.EditControls.EditBox editDiaChi;
        private System.Windows.Forms.Label label10;
        //private Janus.Windows.GridEX.EditControls.EditBox editTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rb_KhachHang;
        private System.Windows.Forms.RadioButton rb_KhachAo;
        private System.Windows.Forms.RadioButton rb_CongTy;
        private System.Windows.Forms.Panel pnlType;
        //private Janus.Windows.GridEX.EditControls.EditBox editSoDienThoai;
    }
}