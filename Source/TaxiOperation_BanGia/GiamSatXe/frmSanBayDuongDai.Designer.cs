namespace Taxi.GUI 
{
    partial class frmSanBayDuongDai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSanBayDuongDai));
            this.label1 = new System.Windows.Forms.Label();
            this.editSoHieuXe = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lblTenLaiXe = new System.Windows.Forms.Label();
            this.editThoiDiemBao = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new Janus.Windows.EditControls.UIButton();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.editViTriTra = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lblViTriBao = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtViTriDon = new Janus.Windows.GridEX.EditControls.EditBox();
            this.txtCo = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lblCo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rad3 = new System.Windows.Forms.RadioButton();
            this.rad4 = new System.Windows.Forms.RadioButton();
            this.rad2 = new System.Windows.Forms.RadioButton();
            this.rad1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radDuongDai = new System.Windows.Forms.RadioButton();
            this.radSanBay = new System.Windows.Forms.RadioButton();
            this.txtCoVe = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Số hiệu xe (*)";
            // 
            // editSoHieuXe
            // 
            this.editSoHieuXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editSoHieuXe.Location = new System.Drawing.Point(83, 33);
            this.editSoHieuXe.MaxLength = 4;
            this.editSoHieuXe.Name = "editSoHieuXe";
            this.editSoHieuXe.Size = new System.Drawing.Size(63, 26);
            this.editSoHieuXe.TabIndex = 0;
            this.editSoHieuXe.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.editSoHieuXe.TextChanged += new System.EventHandler(this.editSoHieuXe_TextChanged);
            this.editSoHieuXe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editSoHieuXe_KeyDown);
            // 
            // lblTenLaiXe
            // 
            this.lblTenLaiXe.AutoSize = true;
            this.lblTenLaiXe.Location = new System.Drawing.Point(17, 103);
            this.lblTenLaiXe.Name = "lblTenLaiXe";
            this.lblTenLaiXe.Size = new System.Drawing.Size(66, 13);
            this.lblTenLaiXe.TabIndex = 9;
            this.lblTenLaiXe.Text = "Điểm đón (*)";
            // 
            // editThoiDiemBao
            // 
            this.editThoiDiemBao.Enabled = false;
            this.editThoiDiemBao.Location = new System.Drawing.Point(250, 32);
            this.editThoiDiemBao.MaxLength = 3;
            this.editThoiDiemBao.Name = "editThoiDiemBao";
            this.editThoiDiemBao.ReadOnly = true;
            this.editThoiDiemBao.Size = new System.Drawing.Size(115, 20);
            this.editThoiDiemBao.TabIndex = 1;
            this.editThoiDiemBao.Text = "12:12:12 02/10/2008";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Thời điểm báo";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::TaxiOperation_TongDai.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(78, 391);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 26);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Lư&u và Đóng";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::TaxiOperation_TongDai.Properties.Resources.Close;
            this.btnCancel.Location = new System.Drawing.Point(172, 391);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 26);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this.editSoHieuXe;
            // 
            // editViTriTra
            // 
            this.editViTriTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editViTriTra.Location = new System.Drawing.Point(81, 128);
            this.editViTriTra.MaxLength = 50;
            this.editViTriTra.Name = "editViTriTra";
            this.editViTriTra.Size = new System.Drawing.Size(282, 26);
            this.editViTriTra.TabIndex = 3;
            this.editViTriTra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editViTriBao_KeyDown);
            // 
            // lblViTriBao
            // 
            this.lblViTriBao.AutoSize = true;
            this.lblViTriBao.Location = new System.Drawing.Point(18, 134);
            this.lblViTriBao.Name = "lblViTriBao";
            this.lblViTriBao.Size = new System.Drawing.Size(62, 13);
            this.lblViTriBao.TabIndex = 10;
            this.lblViTriBao.Text = "Điểm trả  (*)";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(80, 373);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 11;
            // 
            // txtViTriDon
            // 
            this.txtViTriDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtViTriDon.Location = new System.Drawing.Point(83, 96);
            this.txtViTriDon.Name = "txtViTriDon";
            this.txtViTriDon.Size = new System.Drawing.Size(282, 26);
            this.txtViTriDon.TabIndex = 2;
            // 
            // txtCo
            // 
            this.txtCo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCo.Location = new System.Drawing.Point(82, 162);
            this.txtCo.MaxLength = 50;
            this.txtCo.Name = "txtCo";
            this.txtCo.Size = new System.Drawing.Size(109, 26);
            this.txtCo.TabIndex = 4;
            this.txtCo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
            this.txtCo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCo_KeyDown);
            // 
            // lblCo
            // 
            this.lblCo.AutoSize = true;
            this.lblCo.Location = new System.Drawing.Point(21, 166);
            this.lblCo.Name = "lblCo";
            this.lblCo.Size = new System.Drawing.Size(45, 13);
            this.lblCo.TabIndex = 16;
            this.lblCo.Text = "Cơ đi (*)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rad3);
            this.panel1.Controls.Add(this.rad4);
            this.panel1.Controls.Add(this.rad2);
            this.panel1.Controls.Add(this.rad1);
            this.panel1.Location = new System.Drawing.Point(80, 194);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 36);
            this.panel1.TabIndex = 5;
            // 
            // rad3
            // 
            this.rad3.AutoSize = true;
            this.rad3.Location = new System.Drawing.Point(146, 10);
            this.rad3.Name = "rad3";
            this.rad3.Size = new System.Drawing.Size(75, 17);
            this.rad3.TabIndex = 3;
            this.rad3.Text = "1 ch ở tỉnh";
            this.rad3.UseVisualStyleBackColor = true;
            // 
            // rad4
            // 
            this.rad4.AutoSize = true;
            this.rad4.Location = new System.Drawing.Point(221, 10);
            this.rad4.Name = "rad4";
            this.rad4.Size = new System.Drawing.Size(60, 17);
            this.rad4.TabIndex = 2;
            this.rad4.Text = "2 chiều";
            this.rad4.UseVisualStyleBackColor = true;
            // 
            // rad2
            // 
            this.rad2.AutoSize = true;
            this.rad2.Location = new System.Drawing.Point(68, 10);
            this.rad2.Name = "rad2";
            this.rad2.Size = new System.Drawing.Size(91, 17);
            this.rad2.TabIndex = 1;
            this.rad2.Text = "1ch có khách";
            this.rad2.UseVisualStyleBackColor = true;
            // 
            // rad1
            // 
            this.rad1.AutoSize = true;
            this.rad1.Checked = true;
            this.rad1.Location = new System.Drawing.Point(2, 10);
            this.rad1.Name = "rad1";
            this.rad1.Size = new System.Drawing.Size(60, 17);
            this.rad1.TabIndex = 0;
            this.rad1.TabStop = true;
            this.rad1.Text = "1 chiều";
            this.rad1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Chiều (*)";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radDuongDai);
            this.panel2.Controls.Add(this.radSanBay);
            this.panel2.Location = new System.Drawing.Point(82, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(283, 36);
            this.panel2.TabIndex = 1;
            // 
            // radDuongDai
            // 
            this.radDuongDai.AutoSize = true;
            this.radDuongDai.Location = new System.Drawing.Point(66, 10);
            this.radDuongDai.Name = "radDuongDai";
            this.radDuongDai.Size = new System.Drawing.Size(74, 17);
            this.radDuongDai.TabIndex = 1;
            this.radDuongDai.Text = "Đường &dài";
            this.radDuongDai.UseVisualStyleBackColor = true;
            this.radDuongDai.CheckedChanged += new System.EventHandler(this.radDuongDai_CheckedChanged);
            // 
            // radSanBay
            // 
            this.radSanBay.AutoSize = true;
            this.radSanBay.Checked = true;
            this.radSanBay.Location = new System.Drawing.Point(2, 10);
            this.radSanBay.Name = "radSanBay";
            this.radSanBay.Size = new System.Drawing.Size(64, 17);
            this.radSanBay.TabIndex = 0;
            this.radSanBay.TabStop = true;
            this.radSanBay.Text = "&Sân bay";
            this.radSanBay.UseVisualStyleBackColor = true;
            this.radSanBay.CheckedChanged += new System.EventHandler(this.radSanBay_CheckedChanged);
            // 
            // txtCoVe
            // 
            this.txtCoVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoVe.Location = new System.Drawing.Point(80, 331);
            this.txtCoVe.MaxLength = 50;
            this.txtCoVe.Name = "txtCoVe";
            this.txtCoVe.Size = new System.Drawing.Size(109, 26);
            this.txtCoVe.TabIndex = 7;
            this.txtCoVe.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 336);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Cơ về";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(80, 236);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(283, 89);
            this.txtGhiChu.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Ghi chú";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle.Location = new System.Drawing.Point(11, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 20);
            this.lblTitle.TabIndex = 24;
            // 
            // frmSanBayDuongDai
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 424);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtCoVe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCo);
            this.Controls.Add(this.lblCo);
            this.Controls.Add(this.txtViTriDon);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.editViTriTra);
            this.Controls.Add(this.lblViTriBao);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editSoHieuXe);
            this.Controls.Add(this.lblTenLaiXe);
            this.Controls.Add(this.editThoiDiemBao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSanBayDuongDai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lai xe bao san bay-duong dai (F9 : Nhap, ESC : thoát)";
            this.Load += new System.EventHandler(this.frmRaHoatDong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.EditControls.EditBox editSoHieuXe;
        private System.Windows.Forms.Label lblTenLaiXe;
        private Janus.Windows.GridEX.EditControls.EditBox editThoiDiemBao;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.EditControls.UIButton btnSave;
        private Janus.Windows.EditControls.UIButton btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Janus.Windows.GridEX.EditControls.EditBox editViTriTra;
        private System.Windows.Forms.Label lblViTriBao;
        private System.Windows.Forms.Label lblMessage;
        private Janus.Windows.GridEX.EditControls.EditBox txtViTriDon;
        private Janus.Windows.GridEX.EditControls.EditBox txtCo;
        private System.Windows.Forms.Label lblCo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rad4;
        private System.Windows.Forms.RadioButton rad2;
        private System.Windows.Forms.RadioButton rad1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rad3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radDuongDai;
        private System.Windows.Forms.RadioButton radSanBay;
        private Janus.Windows.GridEX.EditControls.EditBox txtCoVe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblTitle;
    }
}