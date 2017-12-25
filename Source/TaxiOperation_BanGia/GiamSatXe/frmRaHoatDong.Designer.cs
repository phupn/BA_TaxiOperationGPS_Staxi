namespace Taxi.GUI 
{
    partial class frmRaHoatDong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRaHoatDong));
            this.lblMaThe = new System.Windows.Forms.Label();
            this.editSoTheLaiXe = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label1 = new System.Windows.Forms.Label();
            this.editSoHieuXe = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lblTenLaiXe = new System.Windows.Forms.Label();
            this.editTenLaiXe = new Janus.Windows.GridEX.EditControls.EditBox();
            this.editThoiDiemBao = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCapNhatKhongDong = new Janus.Windows.EditControls.UIButton();
            this.btnSave = new Janus.Windows.EditControls.UIButton();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.editViTriBao = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lblViTriBao = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.chkSanBay = new Janus.Windows.EditControls.UICheckBox();
            this.chkDuongDai = new Janus.Windows.EditControls.UICheckBox();
            this.txtViTriBao1 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.chkTongDaiGoi = new Janus.Windows.EditControls.UICheckBox();
            this.txtCo = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lblCo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radMoiChieuDonTinh = new System.Windows.Forms.RadioButton();
            this.radMotChieuCoKhach = new System.Windows.Forms.RadioButton();
            this.radMotChieu = new System.Windows.Forms.RadioButton();
            this.radHaiChieu = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGhiChu = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMaThe
            // 
            this.lblMaThe.AutoSize = true;
            this.lblMaThe.Location = new System.Drawing.Point(2, 47);
            this.lblMaThe.Name = "lblMaThe";
            this.lblMaThe.Size = new System.Drawing.Size(77, 13);
            this.lblMaThe.TabIndex = 8;
            this.lblMaThe.Text = "Mã thẻ lái xe(*)";
            // 
            // editSoTheLaiXe
            // 
            this.editSoTheLaiXe.Location = new System.Drawing.Point(82, 45);
            this.editSoTheLaiXe.Name = "editSoTheLaiXe";
            this.editSoTheLaiXe.Size = new System.Drawing.Size(107, 20);
            this.editSoTheLaiXe.TabIndex = 1;
            this.editSoTheLaiXe.TextChanged += new System.EventHandler(this.editSoTheLaiXe_TextChanged);
            this.editSoTheLaiXe.Leave += new System.EventHandler(this.editSoTheLaiXe_Leave);
            this.editSoTheLaiXe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editSoTheLaiXe_KeyPress);
            this.editSoTheLaiXe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editSoTheLaiXe_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Số hiệu xe (*)";
            // 
            // editSoHieuXe
            // 
            this.editSoHieuXe.Location = new System.Drawing.Point(85, 10);
            this.editSoHieuXe.MaxLength = 4;
            this.editSoHieuXe.Name = "editSoHieuXe";
            this.editSoHieuXe.Size = new System.Drawing.Size(36, 20);
            this.editSoHieuXe.TabIndex = 0;
            this.editSoHieuXe.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.editSoHieuXe.TextChanged += new System.EventHandler(this.editSoHieuXe_TextChanged);
            this.editSoHieuXe.Leave += new System.EventHandler(this.editSoHieuXe_Leave);
            this.editSoHieuXe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editSoHieuXe_KeyDown);
            // 
            // lblTenLaiXe
            // 
            this.lblTenLaiXe.AutoSize = true;
            this.lblTenLaiXe.Location = new System.Drawing.Point(15, 75);
            this.lblTenLaiXe.Name = "lblTenLaiXe";
            this.lblTenLaiXe.Size = new System.Drawing.Size(53, 13);
            this.lblTenLaiXe.TabIndex = 9;
            this.lblTenLaiXe.Text = "Tên lái xe";
            // 
            // editTenLaiXe
            // 
            this.editTenLaiXe.Location = new System.Drawing.Point(82, 72);
            this.editTenLaiXe.Name = "editTenLaiXe";
            this.editTenLaiXe.Size = new System.Drawing.Size(282, 20);
            this.editTenLaiXe.TabIndex = 2;
            this.editTenLaiXe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editTenLaiXe_KeyDown);
            // 
            // editThoiDiemBao
            // 
            this.editThoiDiemBao.Enabled = false;
            this.editThoiDiemBao.Location = new System.Drawing.Point(250, 10);
            this.editThoiDiemBao.MaxLength = 3;
            this.editThoiDiemBao.Name = "editThoiDiemBao";
            this.editThoiDiemBao.Size = new System.Drawing.Size(115, 20);
            this.editThoiDiemBao.TabIndex = 1;
            this.editThoiDiemBao.Text = "12:12:12 02/10/2008";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Thời điểm báo";
            // 
            // btnCapNhatKhongDong
            // 
            this.btnCapNhatKhongDong.Image = global::TaxiOperation_TongDai.Properties.Resources.disk;
            this.btnCapNhatKhongDong.Location = new System.Drawing.Point(79, 264);
            this.btnCapNhatKhongDong.Margin = new System.Windows.Forms.Padding(2);
            this.btnCapNhatKhongDong.Name = "btnCapNhatKhongDong";
            this.btnCapNhatKhongDong.Size = new System.Drawing.Size(89, 26);
            this.btnCapNhatKhongDong.TabIndex = 9;
            this.btnCapNhatKhongDong.Text = "&Lưu  và Tiếp";
            this.btnCapNhatKhongDong.Click += new System.EventHandler(this.btnCapNhatKhongDong_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::TaxiOperation_TongDai.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(172, 264);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 26);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Lư&u và Đóng";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::TaxiOperation_TongDai.Properties.Resources.Close;
            this.btnCancel.Location = new System.Drawing.Point(266, 264);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 26);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "&Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // editViTriBao
            // 
            this.editViTriBao.Location = new System.Drawing.Point(82, 98);
            this.editViTriBao.MaxLength = 50;
            this.editViTriBao.Name = "editViTriBao";
            this.editViTriBao.Size = new System.Drawing.Size(282, 20);
            this.editViTriBao.TabIndex = 5;
            this.editViTriBao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editViTriBao_KeyDown);
            // 
            // lblViTriBao
            // 
            this.lblViTriBao.AutoSize = true;
            this.lblViTriBao.Location = new System.Drawing.Point(18, 102);
            this.lblViTriBao.Name = "lblViTriBao";
            this.lblViTriBao.Size = new System.Drawing.Size(63, 13);
            this.lblViTriBao.TabIndex = 10;
            this.lblViTriBao.Text = "Vị trí báo (*)";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(81, 246);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 8;
            // 
            // chkSanBay
            // 
            this.chkSanBay.Location = new System.Drawing.Point(82, 45);
            this.chkSanBay.Name = "chkSanBay";
            this.chkSanBay.Size = new System.Drawing.Size(66, 23);
            this.chkSanBay.TabIndex = 1;
            this.chkSanBay.Text = "&Sân bay";
            this.chkSanBay.CheckedChanged += new System.EventHandler(this.chkSanBay_CheckedChanged);
            // 
            // chkDuongDai
            // 
            this.chkDuongDai.Location = new System.Drawing.Point(154, 45);
            this.chkDuongDai.Name = "chkDuongDai";
            this.chkDuongDai.Size = new System.Drawing.Size(66, 23);
            this.chkDuongDai.TabIndex = 2;
            this.chkDuongDai.Text = "Đường &dài";
            this.chkDuongDai.CheckedChanged += new System.EventHandler(this.chkDuongDai_CheckedChanged);
            // 
            // txtViTriBao1
            // 
            this.txtViTriBao1.Location = new System.Drawing.Point(81, 74);
            this.txtViTriBao1.Name = "txtViTriBao1";
            this.txtViTriBao1.Size = new System.Drawing.Size(282, 20);
            this.txtViTriBao1.TabIndex = 4;
            this.txtViTriBao1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtViTriBao1_KeyDown);
            // 
            // chkTongDaiGoi
            // 
            this.chkTongDaiGoi.Location = new System.Drawing.Point(238, 44);
            this.chkTongDaiGoi.Name = "chkTongDaiGoi";
            this.chkTongDaiGoi.Size = new System.Drawing.Size(96, 23);
            this.chkTongDaiGoi.TabIndex = 3;
            this.chkTongDaiGoi.Text = "Tổng đài đã gọi";
            this.chkTongDaiGoi.CheckedChanged += new System.EventHandler(this.chkTongDaiGoi_CheckedChanged);
            // 
            // txtCo
            // 
            this.txtCo.Location = new System.Drawing.Point(82, 124);
            this.txtCo.MaxLength = 50;
            this.txtCo.Name = "txtCo";
            this.txtCo.Size = new System.Drawing.Size(282, 20);
            this.txtCo.TabIndex = 6;
            this.txtCo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCo_KeyDown);
            // 
            // lblCo
            // 
            this.lblCo.AutoSize = true;
            this.lblCo.Location = new System.Drawing.Point(18, 128);
            this.lblCo.Name = "lblCo";
            this.lblCo.Size = new System.Drawing.Size(20, 13);
            this.lblCo.TabIndex = 16;
            this.lblCo.Text = "Cơ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radMoiChieuDonTinh);
            this.panel1.Controls.Add(this.radMotChieuCoKhach);
            this.panel1.Controls.Add(this.radMotChieu);
            this.panel1.Location = new System.Drawing.Point(81, 142);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 36);
            this.panel1.TabIndex = 7;
            // 
            // radMoiChieuDonTinh
            // 
            this.radMoiChieuDonTinh.AutoSize = true;
            this.radMoiChieuDonTinh.Location = new System.Drawing.Point(146, 10);
            this.radMoiChieuDonTinh.Name = "radMoiChieuDonTinh";
            this.radMoiChieuDonTinh.Size = new System.Drawing.Size(75, 17);
            this.radMoiChieuDonTinh.TabIndex = 3;
            this.radMoiChieuDonTinh.TabStop = true;
            this.radMoiChieuDonTinh.Text = "1 ch ở tỉnh";
            this.radMoiChieuDonTinh.UseVisualStyleBackColor = true;
            // 
            // radMotChieuCoKhach
            // 
            this.radMotChieuCoKhach.AutoSize = true;
            this.radMotChieuCoKhach.Location = new System.Drawing.Point(57, 10);
            this.radMotChieuCoKhach.Name = "radMotChieuCoKhach";
            this.radMotChieuCoKhach.Size = new System.Drawing.Size(91, 17);
            this.radMotChieuCoKhach.TabIndex = 1;
            this.radMotChieuCoKhach.TabStop = true;
            this.radMotChieuCoKhach.Text = "1ch có khách";
            this.radMotChieuCoKhach.UseVisualStyleBackColor = true;
            // 
            // radMotChieu
            // 
            this.radMotChieu.AutoSize = true;
            this.radMotChieu.Location = new System.Drawing.Point(2, 10);
            this.radMotChieu.Name = "radMotChieu";
            this.radMotChieu.Size = new System.Drawing.Size(60, 17);
            this.radMotChieu.TabIndex = 0;
            this.radMotChieu.TabStop = true;
            this.radMotChieu.Text = "1 chiều";
            this.radMotChieu.UseVisualStyleBackColor = true;
            // 
            // radHaiChieu
            // 
            this.radHaiChieu.AutoSize = true;
            this.radHaiChieu.Location = new System.Drawing.Point(301, 152);
            this.radHaiChieu.Name = "radHaiChieu";
            this.radHaiChieu.Size = new System.Drawing.Size(60, 17);
            this.radHaiChieu.TabIndex = 2;
            this.radHaiChieu.TabStop = true;
            this.radHaiChieu.Text = "2 chiều";
            this.radHaiChieu.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Chiều";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(81, 181);
            this.txtGhiChu.MaxLength = 250;
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(286, 60);
            this.txtGhiChu.TabIndex = 19;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(15, 185);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(44, 13);
            this.lblGhiChu.TabIndex = 20;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // frmRaHoatDong
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 295);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radHaiChieu);
            this.Controls.Add(this.txtCo);
            this.Controls.Add(this.lblCo);
            this.Controls.Add(this.chkTongDaiGoi);
            this.Controls.Add(this.txtViTriBao1);
            this.Controls.Add(this.chkDuongDai);
            this.Controls.Add(this.chkSanBay);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.editViTriBao);
            this.Controls.Add(this.lblViTriBao);
            this.Controls.Add(this.btnCapNhatKhongDong);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblMaThe);
            this.Controls.Add(this.editSoTheLaiXe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editSoHieuXe);
            this.Controls.Add(this.lblTenLaiXe);
            this.Controls.Add(this.editTenLaiXe);
            this.Controls.Add(this.editThoiDiemBao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRaHoatDong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lái xe báo ra hoạt động (ESC : thoát)";
            this.Load += new System.EventHandler(this.frmRaHoatDong_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRaHoatDong_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaThe;
        private Janus.Windows.GridEX.EditControls.EditBox editSoTheLaiXe;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.EditControls.EditBox editSoHieuXe;
        private System.Windows.Forms.Label lblTenLaiXe;
        private Janus.Windows.GridEX.EditControls.EditBox editTenLaiXe;
        private Janus.Windows.GridEX.EditControls.EditBox editThoiDiemBao;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.EditControls.UIButton btnCapNhatKhongDong;
        private Janus.Windows.EditControls.UIButton btnSave;
        private Janus.Windows.EditControls.UIButton btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Janus.Windows.GridEX.EditControls.EditBox editViTriBao;
        private System.Windows.Forms.Label lblViTriBao;
        private System.Windows.Forms.Label lblMessage;
        private Janus.Windows.EditControls.UICheckBox chkDuongDai;
        private Janus.Windows.EditControls.UICheckBox chkSanBay;
        private Janus.Windows.GridEX.EditControls.EditBox txtViTriBao1;
        private Janus.Windows.EditControls.UICheckBox chkTongDaiGoi;
        private Janus.Windows.GridEX.EditControls.EditBox txtCo;
        private System.Windows.Forms.Label lblCo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radHaiChieu;
        private System.Windows.Forms.RadioButton radMotChieuCoKhach;
        private System.Windows.Forms.RadioButton radMotChieu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radMoiChieuDonTinh;
        private Janus.Windows.GridEX.EditControls.EditBox txtGhiChu;
        private System.Windows.Forms.Label lblGhiChu;
    }
}