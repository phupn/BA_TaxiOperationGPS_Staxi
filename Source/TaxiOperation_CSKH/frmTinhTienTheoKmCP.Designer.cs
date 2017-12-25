namespace Taxi.GUI
{
    partial class frmTinhTienTheoKmCP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTinhTienTheoKmCP));
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.cboDiaDanh = new System.Windows.Forms.ComboBox();
            this.chkDiaDanh = new System.Windows.Forms.CheckBox();
            this.editTienChieuVe = new Janus.Windows.GridEX.EditControls.EditBox();
            this.editTienChieuDi = new Janus.Windows.GridEX.EditControls.EditBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.rad4Cho = new System.Windows.Forms.RadioButton();
            this.lblThanhTien2Chieu = new System.Windows.Forms.Label();
            this.lblMessage4 = new System.Windows.Forms.Label();
            this.lblMessage3 = new System.Windows.Forms.Label();
            this.lblMessage2 = new System.Windows.Forms.Label();
            this.lblMessage1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editKm = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.btnThoai = new Janus.Windows.EditControls.UIButton();
            this.btnTinhTien = new Janus.Windows.EditControls.UIButton();
            this.lblKm2Chieu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.lblKm2Chieu);
            this.uiGroupBox1.Controls.Add(this.cboDiaDanh);
            this.uiGroupBox1.Controls.Add(this.chkDiaDanh);
            this.uiGroupBox1.Controls.Add(this.editTienChieuVe);
            this.uiGroupBox1.Controls.Add(this.editTienChieuDi);
            this.uiGroupBox1.Controls.Add(this.radioButton2);
            this.uiGroupBox1.Controls.Add(this.rad4Cho);
            this.uiGroupBox1.Controls.Add(this.lblThanhTien2Chieu);
            this.uiGroupBox1.Controls.Add(this.lblMessage4);
            this.uiGroupBox1.Controls.Add(this.lblMessage3);
            this.uiGroupBox1.Controls.Add(this.lblMessage2);
            this.uiGroupBox1.Controls.Add(this.lblMessage1);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Controls.Add(this.editKm);
            this.uiGroupBox1.Location = new System.Drawing.Point(9, 10);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(381, 288);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "Tính tiền theo km";
            // 
            // cboDiaDanh
            // 
            this.cboDiaDanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiaDanh.FormattingEnabled = true;
            this.cboDiaDanh.Location = new System.Drawing.Point(107, 167);
            this.cboDiaDanh.Name = "cboDiaDanh";
            this.cboDiaDanh.Size = new System.Drawing.Size(268, 21);
            this.cboDiaDanh.TabIndex = 23;
            this.cboDiaDanh.SelectedValueChanged += new System.EventHandler(this.cboDiaDanh_SelectedValueChanged);
            // 
            // chkDiaDanh
            // 
            this.chkDiaDanh.AutoSize = true;
            this.chkDiaDanh.Location = new System.Drawing.Point(33, 171);
            this.chkDiaDanh.Name = "chkDiaDanh";
            this.chkDiaDanh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDiaDanh.Size = new System.Drawing.Size(69, 17);
            this.chkDiaDanh.TabIndex = 22;
            this.chkDiaDanh.Text = "Địa danh";
            this.chkDiaDanh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkDiaDanh.UseVisualStyleBackColor = true;
            this.chkDiaDanh.CheckedChanged += new System.EventHandler(this.chkDiaDanh_CheckedChanged);
            // 
            // editTienChieuVe
            // 
            this.editTienChieuVe.BackColor = System.Drawing.SystemColors.InfoText;
            this.editTienChieuVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTienChieuVe.ForeColor = System.Drawing.Color.Yellow;
            this.editTienChieuVe.Location = new System.Drawing.Point(253, 225);
            this.editTienChieuVe.Name = "editTienChieuVe";
            this.editTienChieuVe.Size = new System.Drawing.Size(122, 23);
            this.editTienChieuVe.TabIndex = 20;
            this.editTienChieuVe.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
            // 
            // editTienChieuDi
            // 
            this.editTienChieuDi.BackColor = System.Drawing.SystemColors.InfoText;
            this.editTienChieuDi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTienChieuDi.ForeColor = System.Drawing.Color.Yellow;
            this.editTienChieuDi.Location = new System.Drawing.Point(253, 199);
            this.editTienChieuDi.Name = "editTienChieuDi";
            this.editTienChieuDi.Size = new System.Drawing.Size(122, 23);
            this.editTienChieuDi.TabIndex = 19;
            this.editTienChieuDi.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(181, 30);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(68, 17);
            this.radioButton2.TabIndex = 18;
            this.radioButton2.Text = "Xe 7 chỗ";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rad4Cho
            // 
            this.rad4Cho.AutoSize = true;
            this.rad4Cho.Checked = true;
            this.rad4Cho.Location = new System.Drawing.Point(87, 30);
            this.rad4Cho.Name = "rad4Cho";
            this.rad4Cho.Size = new System.Drawing.Size(68, 17);
            this.rad4Cho.TabIndex = 17;
            this.rad4Cho.TabStop = true;
            this.rad4Cho.Text = "Xe 4 chỗ";
            this.rad4Cho.UseVisualStyleBackColor = true;
            this.rad4Cho.CheckedChanged += new System.EventHandler(this.rad4Cho_CheckedChanged);
            // 
            // lblThanhTien2Chieu
            // 
            this.lblThanhTien2Chieu.AutoSize = true;
            this.lblThanhTien2Chieu.Location = new System.Drawing.Point(108, 230);
            this.lblThanhTien2Chieu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblThanhTien2Chieu.Name = "lblThanhTien2Chieu";
            this.lblThanhTien2Chieu.Size = new System.Drawing.Size(99, 13);
            this.lblThanhTien2Chieu.TabIndex = 10;
            this.lblThanhTien2Chieu.Text = "Thành tiền 2 chiều ";
            // 
            // lblMessage4
            // 
            this.lblMessage4.AutoSize = true;
            this.lblMessage4.Location = new System.Drawing.Point(22, 136);
            this.lblMessage4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMessage4.Name = "lblMessage4";
            this.lblMessage4.Size = new System.Drawing.Size(341, 13);
            this.lblMessage4.TabIndex = 9;
            this.lblMessage4.Text = "Khách đi 2 chiều mà lớn hơn bằng 30 Km, chiều về bằng 30% chiều đi";
            // 
            // lblMessage3
            // 
            this.lblMessage3.AutoSize = true;
            this.lblMessage3.Location = new System.Drawing.Point(108, 110);
            this.lblMessage3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMessage3.Name = "lblMessage3";
            this.lblMessage3.Size = new System.Drawing.Size(97, 13);
            this.lblMessage3.TabIndex = 8;
            this.lblMessage3.Text = "Từ Km 31 trở  lên : ";
            // 
            // lblMessage2
            // 
            this.lblMessage2.AutoSize = true;
            this.lblMessage2.Location = new System.Drawing.Point(107, 92);
            this.lblMessage2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMessage2.Name = "lblMessage2";
            this.lblMessage2.Size = new System.Drawing.Size(123, 13);
            this.lblMessage2.TabIndex = 7;
            this.lblMessage2.Text = "1,2 --> 30 Km tiếp theo : ";
            // 
            // lblMessage1
            // 
            this.lblMessage1.AutoSize = true;
            this.lblMessage1.Location = new System.Drawing.Point(107, 72);
            this.lblMessage1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMessage1.Name = "lblMessage1";
            this.lblMessage1.Size = new System.Drawing.Size(91, 13);
            this.lblMessage1.TabIndex = 6;
            this.lblMessage1.Text = "1,2 Km đầu tiên : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 201);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Thành tiền chiều đi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 201);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nhập &Km";
            // 
            // editKm
            // 
            this.editKm.Location = new System.Drawing.Point(88, 198);
            this.editKm.Margin = new System.Windows.Forms.Padding(2);
            this.editKm.MaxLength = 4;
            this.editKm.Name = "editKm";
            this.editKm.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
            this.editKm.Size = new System.Drawing.Size(57, 20);
            this.editKm.TabIndex = 2;
            this.editKm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editKm_KeyDown);
            // 
            // btnThoai
            // 
            this.btnThoai.Location = new System.Drawing.Point(316, 302);
            this.btnThoai.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoai.Name = "btnThoai";
            this.btnThoai.Size = new System.Drawing.Size(72, 28);
            this.btnThoai.TabIndex = 7;
            this.btnThoai.Text = "&Thoát";
            this.btnThoai.Click += new System.EventHandler(this.btnThoai_Click);
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.Location = new System.Drawing.Point(238, 302);
            this.btnTinhTien.Margin = new System.Windows.Forms.Padding(2);
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.Size = new System.Drawing.Size(74, 28);
            this.btnTinhTien.TabIndex = 4;
            this.btnTinhTien.Text = "Tí&nh tiền";
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // lblKm2Chieu
            // 
            this.lblKm2Chieu.AutoSize = true;
            this.lblKm2Chieu.Location = new System.Drawing.Point(203, 231);
            this.lblKm2Chieu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKm2Chieu.Name = "lblKm2Chieu";
            this.lblKm2Chieu.Size = new System.Drawing.Size(0, 13);
            this.lblKm2Chieu.TabIndex = 24;
            // 
            // frmTinhTienTheoKmCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 341);
            this.Controls.Add(this.btnThoai);
            this.Controls.Add(this.btnTinhTien);
            this.Controls.Add(this.uiGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmTinhTienTheoKmCP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tính tiền theo Km";
            this.Load += new System.EventHandler(this.frmTinhTienTheoKm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.EditControls.NumericEditBox editKm;
        private Janus.Windows.EditControls.UIButton btnThoai;
        private Janus.Windows.EditControls.UIButton btnTinhTien;
        private System.Windows.Forms.Label lblMessage2;
        private System.Windows.Forms.Label lblMessage1;
        private System.Windows.Forms.Label lblMessage3;
        private System.Windows.Forms.Label lblThanhTien2Chieu;
        private System.Windows.Forms.Label lblMessage4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton rad4Cho;
        private Janus.Windows.GridEX.EditControls.EditBox editTienChieuDi;
        private Janus.Windows.GridEX.EditControls.EditBox editTienChieuVe;
        private System.Windows.Forms.CheckBox chkDiaDanh;
        private System.Windows.Forms.ComboBox cboDiaDanh;
        private System.Windows.Forms.Label lblKm2Chieu;
    }
}