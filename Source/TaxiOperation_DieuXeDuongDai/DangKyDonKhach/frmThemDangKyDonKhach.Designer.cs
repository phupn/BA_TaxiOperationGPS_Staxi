namespace TaxiOperation_DieuXeDuongDai.DangKyDonKhach
{
    partial class frmThemDangKyDonKhach
    {
        public frmThemDangKyDonKhach()
        {
            InitializeComponent();
        }
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
            this.lblMsg = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblThoiGianGoi = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGhiChu = new Taxi.Controls.Base.Inputs.InputMemoEdit();
            this.deThoiGianDon = new Taxi.Controls.Base.Inputs.InputDate();
            this.txtDiemDo = new Taxi.Controls.Base.Inputs.InputText();
            this.txtSoXe = new Taxi.Controls.Base.Inputs.InputText();
            this.txtDienThoai = new Taxi.Controls.Base.Inputs.InputText();
            this.btnXoa = new Taxi.Controls.Base.Controls.ShButton();
            this.btnLamMoi = new Taxi.Controls.Base.Controls.ShButton();
            this.btnLuuThoat = new Taxi.Controls.Base.Controls.ShButton();
            this.btnLuu = new Taxi.Controls.Base.Controls.ShButton();
            this.btnLichSu = new Taxi.Controls.Base.Controls.ShButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deThoiGianDon.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deThoiGianDon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiemDo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienThoai.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(89, 211);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 13);
            this.lblMsg.TabIndex = 35;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(33, 132);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "Ghi &chú";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Thời &gian đón *";
            // 
            // lblThoiGianGoi
            // 
            this.lblThoiGianGoi.AutoSize = true;
            this.lblThoiGianGoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianGoi.Location = new System.Drawing.Point(117, 12);
            this.lblThoiGianGoi.Name = "lblThoiGianGoi";
            this.lblThoiGianGoi.Size = new System.Drawing.Size(83, 13);
            this.lblThoiGianGoi.TabIndex = 28;
            this.lblThoiGianGoi.Text = "Thời gian Gọi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "&Điểm đỗ *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Số &xe *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Thời gian gọi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "&Số ĐT *";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.txtGhiChu.Location = new System.Drawing.Point(118, 132);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Properties.MaxLength = 255;
            this.txtGhiChu.Size = new System.Drawing.Size(201, 70);
            this.txtGhiChu.TabIndex = 22;
            // 
            // deThoiGianDon
            // 
            this.deThoiGianDon.DateNowWhenLoad = true;
            this.deThoiGianDon.EditValue = null;
            this.deThoiGianDon.EnterMoveNextControl = true;
            this.deThoiGianDon.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.deThoiGianDon.Location = new System.Drawing.Point(118, 82);
            this.deThoiGianDon.Name = "deThoiGianDon";
            this.deThoiGianDon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deThoiGianDon.Properties.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.deThoiGianDon.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deThoiGianDon.Properties.EditFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.deThoiGianDon.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deThoiGianDon.Properties.Mask.EditMask = "HH:mm dd/MM/yyyy";
            this.deThoiGianDon.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deThoiGianDon.Size = new System.Drawing.Size(199, 20);
            this.deThoiGianDon.TabIndex = 20;
            // 
            // txtDiemDo
            // 
            this.txtDiemDo.EnterMoveNextControl = true;
            this.txtDiemDo.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.txtDiemDo.Location = new System.Drawing.Point(118, 106);
            this.txtDiemDo.Name = "txtDiemDo";
            this.txtDiemDo.Properties.MaxLength = 199;
            this.txtDiemDo.Size = new System.Drawing.Size(199, 20);
            this.txtDiemDo.TabIndex = 21;
            // 
            // txtSoXe
            // 
            this.txtSoXe.EnterMoveNextControl = true;
            this.txtSoXe.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.txtSoXe.Location = new System.Drawing.Point(118, 56);
            this.txtSoXe.Name = "txtSoXe";
            this.txtSoXe.Properties.MaxLength = 49;
            this.txtSoXe.Size = new System.Drawing.Size(199, 20);
            this.txtSoXe.TabIndex = 19;
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.EnterMoveNextControl = true;
            this.txtDienThoai.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.txtDienThoai.Location = new System.Drawing.Point(118, 30);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Properties.MaxLength = 49;
            this.txtDienThoai.Size = new System.Drawing.Size(199, 20);
            this.txtDienThoai.TabIndex = 18;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(340, 243);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(68, 23);
            this.btnXoa.TabIndex = 27;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Visible = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(270, 243);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(68, 23);
            this.btnLamMoi.TabIndex = 26;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnLuuThoat
            // 
            this.btnLuuThoat.KeyCommand = System.Windows.Forms.Keys.F2;
            this.btnLuuThoat.Location = new System.Drawing.Point(167, 243);
            this.btnLuuThoat.Name = "btnLuuThoat";
            this.btnLuuThoat.Size = new System.Drawing.Size(99, 23);
            this.btnLuuThoat.TabIndex = 25;
            this.btnLuuThoat.Text = "Lưu && thoát (F2)";
            this.btnLuuThoat.Click += new System.EventHandler(this.btnLuuThoat_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.KeyCommand = System.Windows.Forms.Keys.F1;
            this.btnLuu.Location = new System.Drawing.Point(88, 243);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 24;
            this.btnLuu.Text = "Lưu (F1)";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnLichSu
            // 
            this.btnLichSu.Location = new System.Drawing.Point(9, 243);
            this.btnLichSu.Name = "btnLichSu";
            this.btnLichSu.Size = new System.Drawing.Size(75, 23);
            this.btnLichSu.TabIndex = 23;
            this.btnLichSu.Text = "Lịch sử";
            this.btnLichSu.Visible = false;
            this.btnLichSu.Click += new System.EventHandler(this.btnLichSu_Click);
            // 
            // frmThemDangKyDonKhach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 278);
            this.CloseByKeyEsc = true;
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.deThoiGianDon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDiemDo);
            this.Controls.Add(this.txtSoXe);
            this.Controls.Add(this.txtDienThoai);
            this.Controls.Add(this.lblThoiGianGoi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnLuuThoat);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnLichSu);
            this.KeyPreview = true;
            this.Name = "frmThemDangKyDonKhach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký đón khách";
            this.Load += new System.EventHandler(this.frmThemDangKyDonKhach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deThoiGianDon.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deThoiGianDon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiemDo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienThoai.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private Taxi.Controls.Base.Inputs.InputMemoEdit txtGhiChu;
        private System.Windows.Forms.Label label13;
        private Taxi.Controls.Base.Inputs.InputDate deThoiGianDon;
        private System.Windows.Forms.Label label5;
        private Taxi.Controls.Base.Inputs.InputText txtDiemDo;
        private Taxi.Controls.Base.Inputs.InputText txtSoXe;
        private Taxi.Controls.Base.Inputs.InputText txtDienThoai;
        private System.Windows.Forms.Label lblThoiGianGoi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Taxi.Controls.Base.Controls.ShButton btnXoa;
        private Taxi.Controls.Base.Controls.ShButton btnLamMoi;
        private Taxi.Controls.Base.Controls.ShButton btnLuuThoat;
        private Taxi.Controls.Base.Controls.ShButton btnLuu;
        private Taxi.Controls.Base.Controls.ShButton btnLichSu;

    }
}