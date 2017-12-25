namespace Taxi.GUI
{
    partial class frmNhapThongTinKiemSoatXe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhapThongTinKiemSoatXe));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.editSoHieuXe = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label3 = new System.Windows.Forms.Label();
            this.editTenLaiXe = new Janus.Windows.GridEX.EditControls.EditBox();
            this.chkTongDaiGoi = new Janus.Windows.EditControls.UICheckBox();
            this.editViTriBao = new Janus.Windows.GridEX.EditControls.EditBox();
            this.editThoiDiemBao = new Janus.Windows.GridEX.EditControls.EditBox();
            this.editViTriDen = new Janus.Windows.GridEX.EditControls.EditBox();
            this.chkSanBay = new Janus.Windows.EditControls.UICheckBox();
            this.chkDuongDai = new Janus.Windows.EditControls.UICheckBox();
            this.lblViTriBaoDen = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.editGhiChu = new Janus.Windows.GridEX.EditControls.EditBox();
            this.btnSave = new Janus.Windows.EditControls.UIButton();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.grpLaiXeBao1 = new System.Windows.Forms.GroupBox();
            this.rdiBaoHoatDong = new Janus.Windows.EditControls.UIRadioButton();
            this.rdiBaoVe = new Janus.Windows.EditControls.UIRadioButton();
            this.grpLaiXeBao2 = new System.Windows.Forms.GroupBox();
            this.rdiBaoNghi = new Janus.Windows.EditControls.UIRadioButton();
            this.rdiBaoSuCoTaiNan = new Janus.Windows.EditControls.UIRadioButton();
            this.rdiBaoDonKhach = new Janus.Windows.EditControls.UIRadioButton();
            this.radBaoDiem = new Janus.Windows.EditControls.UIRadioButton();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.editSoTheLaiXe = new Janus.Windows.GridEX.EditControls.EditBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.grpLaiXeBao1.SuspendLayout();
            this.grpLaiXeBao2.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số hiệu xe";
            // 
            // editSoHieuXe
            // 
            this.editSoHieuXe.Location = new System.Drawing.Point(119, 35);
            this.editSoHieuXe.MaxLength = 4;
            this.editSoHieuXe.Name = "editSoHieuXe";
            this.editSoHieuXe.Size = new System.Drawing.Size(47, 20);
            this.editSoHieuXe.TabIndex = 0;
            this.editSoHieuXe.Text = "123";
            this.editSoHieuXe.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.editSoHieuXe.TextChanged += new System.EventHandler(this.editSoHieuXe_TextChanged);
            this.editSoHieuXe.Leave += new System.EventHandler(this.editSoHieuXe_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lái xe";
            // 
            // editTenLaiXe
            // 
            this.editTenLaiXe.Location = new System.Drawing.Point(116, 97);
            this.editTenLaiXe.Name = "editTenLaiXe";
            this.editTenLaiXe.Size = new System.Drawing.Size(282, 20);
            this.editTenLaiXe.TabIndex = 2;
            // 
            // chkTongDaiGoi
            // 
            this.chkTongDaiGoi.Location = new System.Drawing.Point(116, 121);
            this.chkTongDaiGoi.Name = "chkTongDaiGoi";
            this.chkTongDaiGoi.Size = new System.Drawing.Size(111, 19);
            this.chkTongDaiGoi.TabIndex = 3;
            this.chkTongDaiGoi.Text = "Tổng dài đã gọi";
            this.chkTongDaiGoi.CheckedChanged += new System.EventHandler(this.chkTongDaiGoi_CheckedChanged);
            // 
            // editViTriBao
            // 
            this.editViTriBao.Location = new System.Drawing.Point(110, 249);
            this.editViTriBao.MaxLength = 50;
            this.editViTriBao.Name = "editViTriBao";
            this.editViTriBao.Size = new System.Drawing.Size(288, 20);
            this.editViTriBao.TabIndex = 4;
            // 
            // editThoiDiemBao
            // 
            this.editThoiDiemBao.Enabled = false;
            this.editThoiDiemBao.Location = new System.Drawing.Point(284, 37);
            this.editThoiDiemBao.MaxLength = 3;
            this.editThoiDiemBao.Name = "editThoiDiemBao";
            this.editThoiDiemBao.Size = new System.Drawing.Size(115, 20);
            this.editThoiDiemBao.TabIndex = 1;
            this.editThoiDiemBao.Text = "12:12:12 02/10/2008";
            // 
            // editViTriDen
            // 
            this.editViTriDen.Location = new System.Drawing.Point(110, 275);
            this.editViTriDen.MaxLength = 50;
            this.editViTriDen.Name = "editViTriDen";
            this.editViTriDen.Size = new System.Drawing.Size(288, 20);
            this.editViTriDen.TabIndex = 5;
            // 
            // chkSanBay
            // 
            this.chkSanBay.Location = new System.Drawing.Point(113, 301);
            this.chkSanBay.Name = "chkSanBay";
            this.chkSanBay.Size = new System.Drawing.Size(68, 23);
            this.chkSanBay.TabIndex = 6;
            this.chkSanBay.Text = "Sân bay";
            this.chkSanBay.CheckedChanged += new System.EventHandler(this.chkSanBay_CheckedChanged);
            // 
            // chkDuongDai
            // 
            this.chkDuongDai.Location = new System.Drawing.Point(201, 301);
            this.chkDuongDai.Name = "chkDuongDai";
            this.chkDuongDai.Size = new System.Drawing.Size(77, 23);
            this.chkDuongDai.TabIndex = 7;
            this.chkDuongDai.Text = "Đường dài";
            this.chkDuongDai.CheckedChanged += new System.EventHandler(this.chkDuongDai_CheckedChanged);
            // 
            // lblViTriBaoDen
            // 
            this.lblViTriBaoDen.AutoSize = true;
            this.lblViTriBaoDen.Location = new System.Drawing.Point(37, 277);
            this.lblViTriBaoDen.Name = "lblViTriBaoDen";
            this.lblViTriBaoDen.Size = new System.Drawing.Size(72, 13);
            this.lblViTriBaoDen.TabIndex = 78;
            this.lblViTriBaoDen.Text = "Vị trí báo đến";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Thời điểm báo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Vị trí báo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 334);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 79;
            this.label6.Text = "Ghi chú";
            // 
            // editGhiChu
            // 
            this.editGhiChu.Location = new System.Drawing.Point(110, 330);
            this.editGhiChu.MaxLength = 50;
            this.editGhiChu.Multiline = true;
            this.editGhiChu.Name = "editGhiChu";
            this.editGhiChu.Size = new System.Drawing.Size(288, 62);
            this.editGhiChu.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(154, 401);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 26);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = " &Cập nhật";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Close;
            this.btnCancel.Location = new System.Drawing.Point(253, 401);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 26);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "&Hủy bỏ";
            // 
            // grpLaiXeBao1
            // 
            this.grpLaiXeBao1.Controls.Add(this.rdiBaoHoatDong);
            this.grpLaiXeBao1.Controls.Add(this.rdiBaoVe);
            this.grpLaiXeBao1.Location = new System.Drawing.Point(58, 146);
            this.grpLaiXeBao1.Name = "grpLaiXeBao1";
            this.grpLaiXeBao1.Size = new System.Drawing.Size(435, 44);
            this.grpLaiXeBao1.TabIndex = 3;
            this.grpLaiXeBao1.TabStop = false;
            // 
            // rdiBaoHoatDong
            // 
            this.rdiBaoHoatDong.Location = new System.Drawing.Point(9, 15);
            this.rdiBaoHoatDong.Name = "rdiBaoHoatDong";
            this.rdiBaoHoatDong.Size = new System.Drawing.Size(99, 23);
            this.rdiBaoHoatDong.TabIndex = 0;
            this.rdiBaoHoatDong.Text = "Báo ra hoạt động";
            // 
            // rdiBaoVe
            // 
            this.rdiBaoVe.Location = new System.Drawing.Point(122, 15);
            this.rdiBaoVe.Name = "rdiBaoVe";
            this.rdiBaoVe.Size = new System.Drawing.Size(74, 23);
            this.rdiBaoVe.TabIndex = 1;
            this.rdiBaoVe.Text = "Báo về";
            // 
            // grpLaiXeBao2
            // 
            this.grpLaiXeBao2.Controls.Add(this.rdiBaoNghi);
            this.grpLaiXeBao2.Controls.Add(this.rdiBaoSuCoTaiNan);
            this.grpLaiXeBao2.Controls.Add(this.rdiBaoDonKhach);
            this.grpLaiXeBao2.Controls.Add(this.radBaoDiem);
            this.grpLaiXeBao2.Location = new System.Drawing.Point(58, 185);
            this.grpLaiXeBao2.Name = "grpLaiXeBao2";
            this.grpLaiXeBao2.Size = new System.Drawing.Size(435, 44);
            this.grpLaiXeBao2.TabIndex = 2;
            this.grpLaiXeBao2.TabStop = false;
            // 
            // rdiBaoNghi
            // 
            this.rdiBaoNghi.Location = new System.Drawing.Point(205, 13);
            this.rdiBaoNghi.Name = "rdiBaoNghi";
            this.rdiBaoNghi.Size = new System.Drawing.Size(74, 23);
            this.rdiBaoNghi.TabIndex = 2;
            this.rdiBaoNghi.Text = "Báo &nghỉ";
            // 
            // rdiBaoSuCoTaiNan
            // 
            this.rdiBaoSuCoTaiNan.Location = new System.Drawing.Point(285, 13);
            this.rdiBaoSuCoTaiNan.Name = "rdiBaoSuCoTaiNan";
            this.rdiBaoSuCoTaiNan.Size = new System.Drawing.Size(128, 23);
            this.rdiBaoSuCoTaiNan.TabIndex = 3;
            this.rdiBaoSuCoTaiNan.Text = "Báo &sự cố, tai nạn,khác";
            this.rdiBaoSuCoTaiNan.Visible = false;
            // 
            // rdiBaoDonKhach
            // 
            this.rdiBaoDonKhach.Location = new System.Drawing.Point(97, 13);
            this.rdiBaoDonKhach.Name = "rdiBaoDonKhach";
            this.rdiBaoDonKhach.Size = new System.Drawing.Size(99, 23);
            this.rdiBaoDonKhach.TabIndex = 1;
            this.rdiBaoDonKhach.Text = "Báo đón &khách";
            this.rdiBaoDonKhach.CheckedChanged += new System.EventHandler(this.rdiBaoDonKhach_CheckedChanged);
            // 
            // radBaoDiem
            // 
            this.radBaoDiem.Location = new System.Drawing.Point(9, 13);
            this.radBaoDiem.Name = "radBaoDiem";
            this.radBaoDiem.Size = new System.Drawing.Size(74, 23);
            this.radBaoDiem.TabIndex = 0;
            this.radBaoDiem.Text = "Báo &điểm";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Blue;
            this.lblMessage.Location = new System.Drawing.Point(170, 8);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(144, 16);
            this.lblMessage.TabIndex = 80;
            this.lblMessage.Text = "Thông tin lái xe báo";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 82;
            this.label5.Text = "Mã thẻ lái xe";
            // 
            // editSoTheLaiXe
            // 
            this.editSoTheLaiXe.Location = new System.Drawing.Point(116, 70);
            this.editSoTheLaiXe.Name = "editSoTheLaiXe";
            this.editSoTheLaiXe.Size = new System.Drawing.Size(138, 20);
            this.editSoTheLaiXe.TabIndex = 1;
            this.editSoTheLaiXe.TextChanged += new System.EventHandler(this.editSoTheLaiXe_TextChanged);
            this.editSoTheLaiXe.Leave += new System.EventHandler(this.editSoTheLaiXe_Leave);
            this.editSoTheLaiXe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editSoTheLaiXe_KeyDown);
            // 
            // frmNhapThongTinKiemSoatXe
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(510, 433);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.editSoTheLaiXe);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.grpLaiXeBao1);
            this.Controls.Add(this.grpLaiXeBao2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editSoHieuXe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.editTenLaiXe);
            this.Controls.Add(this.chkTongDaiGoi);
            this.Controls.Add(this.editViTriBao);
            this.Controls.Add(this.editThoiDiemBao);
            this.Controls.Add(this.editViTriDen);
            this.Controls.Add(this.chkSanBay);
            this.Controls.Add(this.chkDuongDai);
            this.Controls.Add(this.lblViTriBaoDen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.editGhiChu);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNhapThongTinKiemSoatXe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiếm soát xe";
            this.Load += new System.EventHandler(this.frmNhapThongTinKiemSoatXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.grpLaiXeBao1.ResumeLayout(false);
            this.grpLaiXeBao2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.EditControls.EditBox editSoHieuXe;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.GridEX.EditControls.EditBox editTenLaiXe;
        private Janus.Windows.EditControls.UICheckBox chkTongDaiGoi;
        private Janus.Windows.GridEX.EditControls.EditBox editViTriBao;
        private Janus.Windows.GridEX.EditControls.EditBox editThoiDiemBao;
        private Janus.Windows.GridEX.EditControls.EditBox editViTriDen;
        private Janus.Windows.EditControls.UICheckBox chkSanBay;
        private Janus.Windows.EditControls.UICheckBox chkDuongDai;
        private System.Windows.Forms.Label lblViTriBaoDen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private Janus.Windows.GridEX.EditControls.EditBox editGhiChu;
        private Janus.Windows.EditControls.UIButton btnSave;
        private Janus.Windows.EditControls.UIButton btnCancel;
        private System.Windows.Forms.GroupBox grpLaiXeBao1;
        private Janus.Windows.EditControls.UIRadioButton rdiBaoHoatDong;
        private Janus.Windows.EditControls.UIRadioButton rdiBaoVe;
        private System.Windows.Forms.GroupBox grpLaiXeBao2;
        private Janus.Windows.EditControls.UIRadioButton rdiBaoNghi;
        private Janus.Windows.EditControls.UIRadioButton rdiBaoSuCoTaiNan;
        private Janus.Windows.EditControls.UIRadioButton rdiBaoDonKhach;
        private Janus.Windows.EditControls.UIRadioButton radBaoDiem;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label5;
        private Janus.Windows.GridEX.EditControls.EditBox editSoTheLaiXe;
    }
}