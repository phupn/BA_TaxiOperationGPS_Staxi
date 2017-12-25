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
            this.lblDH = new System.Windows.Forms.Label();
            this.editDongHo = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.lblSoPhutNghi_dvt = new System.Windows.Forms.Label();
            this.editSoPhutNghi = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.rbAnCa = new System.Windows.Forms.RadioButton();
            this.rbRoiXe = new System.Windows.Forms.RadioButton();
            this.rbKhac = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaThe
            // 
            this.lblMaThe.AutoSize = true;
            this.lblMaThe.Location = new System.Drawing.Point(171, 66);
            this.lblMaThe.Name = "lblMaThe";
            this.lblMaThe.Size = new System.Drawing.Size(70, 13);
            this.lblMaThe.TabIndex = 8;
            this.lblMaThe.Text = "Mã thẻ lái xe ";
            // 
            // editSoTheLaiXe
            // 
            this.editSoTheLaiXe.Location = new System.Drawing.Point(251, 64);
            this.editSoTheLaiXe.Name = "editSoTheLaiXe";
            this.editSoTheLaiXe.Size = new System.Drawing.Size(107, 20);
            this.editSoTheLaiXe.TabIndex = 7;
            this.editSoTheLaiXe.TextChanged += new System.EventHandler(this.editSoTheLaiXe_TextChanged);
            this.editSoTheLaiXe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editSoTheLaiXe_KeyDown);
            this.editSoTheLaiXe.Leave += new System.EventHandler(this.editSoTheLaiXe_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Số hiệu xe (*)";
            // 
            // editSoHieuXe
            // 
            this.editSoHieuXe.Location = new System.Drawing.Point(82, 38);
            this.editSoHieuXe.MaxLength = 4;
            this.editSoHieuXe.Name = "editSoHieuXe";
            this.editSoHieuXe.Size = new System.Drawing.Size(83, 20);
            this.editSoHieuXe.TabIndex = 1;
            this.editSoHieuXe.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.editSoHieuXe.TextChanged += new System.EventHandler(this.editSoHieuXe_TextChanged);
            this.editSoHieuXe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editSoHieuXe_KeyDown);
            this.editSoHieuXe.Leave += new System.EventHandler(this.editSoHieuXe_Leave);
            // 
            // lblTenLaiXe
            // 
            this.lblTenLaiXe.AutoSize = true;
            this.lblTenLaiXe.Location = new System.Drawing.Point(16, 95);
            this.lblTenLaiXe.Name = "lblTenLaiXe";
            this.lblTenLaiXe.Size = new System.Drawing.Size(66, 13);
            this.lblTenLaiXe.TabIndex = 9;
            this.lblTenLaiXe.Text = "Tên lái xe (*)";
            // 
            // editTenLaiXe
            // 
            this.editTenLaiXe.Location = new System.Drawing.Point(83, 92);
            this.editTenLaiXe.Name = "editTenLaiXe";
            this.editTenLaiXe.Size = new System.Drawing.Size(282, 20);
            this.editTenLaiXe.TabIndex = 2;
            this.editTenLaiXe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editTenLaiXe_KeyDown);
            // 
            // editThoiDiemBao
            // 
            this.editThoiDiemBao.Enabled = false;
            this.editThoiDiemBao.Location = new System.Drawing.Point(82, 12);
            this.editThoiDiemBao.MaxLength = 3;
            this.editThoiDiemBao.Name = "editThoiDiemBao";
            this.editThoiDiemBao.Size = new System.Drawing.Size(115, 20);
            this.editThoiDiemBao.TabIndex = 0;
            this.editThoiDiemBao.Text = "12:12:12 02/10/2008";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Thời điểm báo";
            // 
            // btnCapNhatKhongDong
            // 
            this.btnCapNhatKhongDong.Image = global::TaxiOperation_TongDai_ENVANGVIP.Properties.Resources.disk;
            this.btnCapNhatKhongDong.Location = new System.Drawing.Point(82, 166);
            this.btnCapNhatKhongDong.Margin = new System.Windows.Forms.Padding(2);
            this.btnCapNhatKhongDong.Name = "btnCapNhatKhongDong";
            this.btnCapNhatKhongDong.Size = new System.Drawing.Size(89, 26);
            this.btnCapNhatKhongDong.TabIndex = 10;
            this.btnCapNhatKhongDong.Text = "&Lưu  và Tiếp";
            this.btnCapNhatKhongDong.Click += new System.EventHandler(this.btnCapNhatKhongDong_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::TaxiOperation_TongDai_ENVANGVIP.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(175, 166);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 26);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Lư&u và Đóng";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::TaxiOperation_TongDai_ENVANGVIP.Properties.Resources.Close;
            this.btnCancel.Location = new System.Drawing.Point(269, 166);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 26);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "&Hủy bỏ";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // editViTriBao
            // 
            this.editViTriBao.Location = new System.Drawing.Point(83, 118);
            this.editViTriBao.MaxLength = 50;
            this.editViTriBao.Name = "editViTriBao";
            this.editViTriBao.Size = new System.Drawing.Size(282, 20);
            this.editViTriBao.TabIndex = 9;
            this.editViTriBao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editViTriBao_KeyDown);
            // 
            // lblViTriBao
            // 
            this.lblViTriBao.AutoSize = true;
            this.lblViTriBao.Location = new System.Drawing.Point(19, 122);
            this.lblViTriBao.Name = "lblViTriBao";
            this.lblViTriBao.Size = new System.Drawing.Size(50, 13);
            this.lblViTriBao.TabIndex = 10;
            this.lblViTriBao.Text = "Vị trí báo";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(83, 147);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 13;
            // 
            // chkSanBay
            // 
            this.chkSanBay.Location = new System.Drawing.Point(83, 65);
            this.chkSanBay.Name = "chkSanBay";
            this.chkSanBay.Size = new System.Drawing.Size(66, 23);
            this.chkSanBay.TabIndex = 1;
            this.chkSanBay.Text = "&Sân bay";
            this.chkSanBay.CheckedChanged += new System.EventHandler(this.chkSanBay_CheckedChanged);
            // 
            // chkDuongDai
            // 
            this.chkDuongDai.Location = new System.Drawing.Point(155, 65);
            this.chkDuongDai.Name = "chkDuongDai";
            this.chkDuongDai.Size = new System.Drawing.Size(66, 23);
            this.chkDuongDai.TabIndex = 2;
            this.chkDuongDai.Text = "Đường &dài";
            this.chkDuongDai.CheckedChanged += new System.EventHandler(this.chkDuongDai_CheckedChanged);
            // 
            // txtViTriBao1
            // 
            this.txtViTriBao1.Location = new System.Drawing.Point(82, 94);
            this.txtViTriBao1.Name = "txtViTriBao1";
            this.txtViTriBao1.Size = new System.Drawing.Size(282, 20);
            this.txtViTriBao1.TabIndex = 8;
            this.txtViTriBao1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtViTriBao1_KeyDown);
            // 
            // chkTongDaiGoi
            // 
            this.chkTongDaiGoi.Location = new System.Drawing.Point(239, 64);
            this.chkTongDaiGoi.Name = "chkTongDaiGoi";
            this.chkTongDaiGoi.Size = new System.Drawing.Size(96, 23);
            this.chkTongDaiGoi.TabIndex = 14;
            this.chkTongDaiGoi.Text = "Tổng đài đã gọi";
            this.chkTongDaiGoi.CheckedChanged += new System.EventHandler(this.chkTongDaiGoi_CheckedChanged);
            // 
            // lblDH
            // 
            this.lblDH.AutoSize = true;
            this.lblDH.Location = new System.Drawing.Point(28, 69);
            this.lblDH.Name = "lblDH";
            this.lblDH.Size = new System.Drawing.Size(48, 13);
            this.lblDH.TabIndex = 16;
            this.lblDH.Text = "Đồng hồ";
            // 
            // editDongHo
            // 
            this.editDongHo.Location = new System.Drawing.Point(82, 64);
            this.editDongHo.Name = "editDongHo";
            this.editDongHo.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
            this.editDongHo.Size = new System.Drawing.Size(83, 20);
            this.editDongHo.TabIndex = 6;
            this.editDongHo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editDongHo_KeyDown);
            // 
            // lblSoPhutNghi_dvt
            // 
            this.lblSoPhutNghi_dvt.AutoSize = true;
            this.lblSoPhutNghi_dvt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoPhutNghi_dvt.Location = new System.Drawing.Point(172, 69);
            this.lblSoPhutNghi_dvt.Name = "lblSoPhutNghi_dvt";
            this.lblSoPhutNghi_dvt.Size = new System.Drawing.Size(34, 13);
            this.lblSoPhutNghi_dvt.TabIndex = 17;
            this.lblSoPhutNghi_dvt.Text = "(phút)";
            // 
            // editSoPhutNghi
            // 
            this.editSoPhutNghi.Enabled = false;
            this.editSoPhutNghi.Location = new System.Drawing.Point(82, 64);
            this.editSoPhutNghi.Name = "editSoPhutNghi";
            this.editSoPhutNghi.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
            this.editSoPhutNghi.Size = new System.Drawing.Size(83, 20);
            this.editSoPhutNghi.TabIndex = 5;
            this.editSoPhutNghi.Click += new System.EventHandler(this.editSoPhutNghi_Click);
            this.editSoPhutNghi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editDongHo_KeyDown);
            // 
            // rbAnCa
            // 
            this.rbAnCa.AutoSize = true;
            this.rbAnCa.Checked = true;
            this.rbAnCa.Location = new System.Drawing.Point(199, 39);
            this.rbAnCa.Name = "rbAnCa";
            this.rbAnCa.Size = new System.Drawing.Size(53, 17);
            this.rbAnCa.TabIndex = 2;
            this.rbAnCa.TabStop = true;
            this.rbAnCa.Text = "&Ăn ca";
            this.rbAnCa.UseVisualStyleBackColor = true;
            this.rbAnCa.CheckedChanged += new System.EventHandler(this.rbAnCa_CheckedChanged);
            // 
            // rbRoiXe
            // 
            this.rbRoiXe.AutoSize = true;
            this.rbRoiXe.Location = new System.Drawing.Point(258, 39);
            this.rbRoiXe.Name = "rbRoiXe";
            this.rbRoiXe.Size = new System.Drawing.Size(55, 17);
            this.rbRoiXe.TabIndex = 3;
            this.rbRoiXe.Text = "&Rời xe";
            this.rbRoiXe.UseVisualStyleBackColor = true;
            this.rbRoiXe.CheckedChanged += new System.EventHandler(this.rbRoiXe_CheckedChanged);
            // 
            // rbKhac
            // 
            this.rbKhac.AutoSize = true;
            this.rbKhac.Location = new System.Drawing.Point(319, 39);
            this.rbKhac.Name = "rbKhac";
            this.rbKhac.Size = new System.Drawing.Size(50, 17);
            this.rbKhac.TabIndex = 4;
            this.rbKhac.Text = "&Khác";
            this.rbKhac.UseVisualStyleBackColor = true;
            this.rbKhac.CheckedChanged += new System.EventHandler(this.rbKhac_CheckedChanged);
            // 
            // frmRaHoatDong
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 207);
            this.Controls.Add(this.rbKhac);
            this.Controls.Add(this.rbRoiXe);
            this.Controls.Add(this.rbAnCa);
            this.Controls.Add(this.editSoPhutNghi);
            this.Controls.Add(this.lblSoPhutNghi_dvt);
            this.Controls.Add(this.editDongHo);
            this.Controls.Add(this.lblDH);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRaHoatDong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lái xe báo ra hoạt động (ESC : thoát)";
            this.Load += new System.EventHandler(this.frmRaHoatDong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
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
        private System.Windows.Forms.Label lblDH;
        private Janus.Windows.GridEX.EditControls.NumericEditBox editDongHo;
        private System.Windows.Forms.Label lblSoPhutNghi_dvt;
        private Janus.Windows.GridEX.EditControls.NumericEditBox editSoPhutNghi;
        private System.Windows.Forms.RadioButton rbRoiXe;
        private System.Windows.Forms.RadioButton rbAnCa;
        private System.Windows.Forms.RadioButton rbKhac;
    }
}