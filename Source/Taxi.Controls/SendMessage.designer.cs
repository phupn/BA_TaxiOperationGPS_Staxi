namespace Taxi.Controls
{
    partial class SendMessage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendMessage));
            this.lblThongBao = new System.Windows.Forms.Label();
            this.txtNoiDung1 = new System.Windows.Forms.RichTextBox();
            this.cbCapDo = new System.Windows.Forms.ComboBox();
            this.btnGui = new Taxi.Controls.Base.Controls.ShButton();
            this.btnTinMau = new Taxi.Controls.Base.Controls.ShButton();
            this.myGroupBox1 = new Taxi.Controls.Base.Controls.ShGroupBox();
            this.chkIsActiveUser = new System.Windows.Forms.CheckBox();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.txtTieuDe = new System.Windows.Forms.TextBox();
            this.dateTime_ThoiGianGui = new Taxi.Controls.Base.Inputs.InputDate();
            this.chkChonNgay = new Taxi.Controls.Base.Inputs.InputCheckbox();
            this.rbDTV = new System.Windows.Forms.RadioButton();
            this.rbDHV = new System.Windows.Forms.RadioButton();
            this.rbTatCa = new System.Windows.Forms.RadioButton();
            this.txtTaiKhoan1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.myGroupBox1)).BeginInit();
            this.myGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTime_ThoiGianGui.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTime_ThoiGianGui.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChonNgay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.ForeColor = System.Drawing.Color.Red;
            this.lblThongBao.Location = new System.Drawing.Point(6, 292);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(76, 13);
            this.lblThongBao.TabIndex = 11;
            this.lblThongBao.Text = "[Thông báo]";
            // 
            // txtNoiDung1
            // 
            this.txtNoiDung1.Location = new System.Drawing.Point(9, 173);
            this.txtNoiDung1.MaxLength = 1000;
            this.txtNoiDung1.Name = "txtNoiDung1";
            this.txtNoiDung1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtNoiDung1.Size = new System.Drawing.Size(484, 110);
            this.txtNoiDung1.TabIndex = 10;
            this.txtNoiDung1.Text = "";
            // 
            // cbCapDo
            // 
            this.cbCapDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCapDo.FormattingEnabled = true;
            this.cbCapDo.Items.AddRange(new object[] {
            "Thấp",
            "Trung bình",
            "Cao"});
            this.cbCapDo.Location = new System.Drawing.Point(4, 103);
            this.cbCapDo.Name = "cbCapDo";
            this.cbCapDo.Size = new System.Drawing.Size(97, 21);
            this.cbCapDo.TabIndex = 13;
            // 
            // btnGui
            // 
            this.btnGui.Image = ((System.Drawing.Image)(resources.GetObject("btnGui.Image")));
            this.btnGui.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnGui.Location = new System.Drawing.Point(4, 3);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(96, 66);
            this.btnGui.TabIndex = 11;
            this.btnGui.Text = "&Gửi (Ctrl+S)";
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // btnTinMau
            // 
            this.btnTinMau.Image = ((System.Drawing.Image)(resources.GetObject("btnTinMau.Image")));
            this.btnTinMau.Location = new System.Drawing.Point(4, 75);
            this.btnTinMau.Name = "btnTinMau";
            this.btnTinMau.Size = new System.Drawing.Size(96, 23);
            this.btnTinMau.TabIndex = 12;
            this.btnTinMau.Text = "Tin &mẫu";
            this.btnTinMau.Click += new System.EventHandler(this.btnTinMau_Click_1);
            // 
            // myGroupBox1
            // 
            this.myGroupBox1.Controls.Add(this.chkIsActiveUser);
            this.myGroupBox1.Controls.Add(this.btnTaiKhoan);
            this.myGroupBox1.Controls.Add(this.txtTieuDe);
            this.myGroupBox1.Controls.Add(this.dateTime_ThoiGianGui);
            this.myGroupBox1.Controls.Add(this.chkChonNgay);
            this.myGroupBox1.Controls.Add(this.rbDTV);
            this.myGroupBox1.Controls.Add(this.rbDHV);
            this.myGroupBox1.Controls.Add(this.rbTatCa);
            this.myGroupBox1.Controls.Add(this.txtTaiKhoan1);
            this.myGroupBox1.Controls.Add(this.label3);
            this.myGroupBox1.Controls.Add(this.label4);
            this.myGroupBox1.Location = new System.Drawing.Point(105, 3);
            this.myGroupBox1.Name = "myGroupBox1";
            this.myGroupBox1.Size = new System.Drawing.Size(388, 164);
            this.myGroupBox1.TabIndex = 12;
            this.myGroupBox1.Text = "Thông tin người nhận";
            // 
            // chkIsActiveUser
            // 
            this.chkIsActiveUser.AutoSize = true;
            this.chkIsActiveUser.Checked = true;
            this.chkIsActiveUser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActiveUser.Location = new System.Drawing.Point(147, 61);
            this.chkIsActiveUser.Name = "chkIsActiveUser";
            this.chkIsActiveUser.Size = new System.Drawing.Size(111, 17);
            this.chkIsActiveUser.TabIndex = 6;
            this.chkIsActiveUser.Text = "N&V đang làm việc";
            this.chkIsActiveUser.UseVisualStyleBackColor = true;
            this.chkIsActiveUser.CheckedChanged += new System.EventHandler(this.chkIsActiveUser_CheckedChanged);
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Image = ((System.Drawing.Image)(resources.GetObject("btnTaiKhoan.Image")));
            this.btnTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.Location = new System.Drawing.Point(260, 25);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(116, 69);
            this.btnTaiKhoan.TabIndex = 7;
            this.btnTaiKhoan.Text = "&Tài khoản";
            this.btnTaiKhoan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTaiKhoan.UseVisualStyleBackColor = true;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click_2);
            // 
            // txtTieuDe
            // 
            this.txtTieuDe.Location = new System.Drawing.Point(66, 139);
            this.txtTieuDe.Name = "txtTieuDe";
            this.txtTieuDe.Size = new System.Drawing.Size(310, 20);
            this.txtTieuDe.TabIndex = 9;
            // 
            // dateTime_ThoiGianGui
            // 
            this.dateTime_ThoiGianGui.DateNowWhenLoad = true;
            this.dateTime_ThoiGianGui.EditValue = new System.DateTime(2016, 7, 12, 14, 33, 22, 907);
            this.dateTime_ThoiGianGui.Enabled = false;
            this.dateTime_ThoiGianGui.IsChangeText = false;
            this.dateTime_ThoiGianGui.IsFocus = false;
            this.dateTime_ThoiGianGui.Location = new System.Drawing.Point(27, 59);
            this.dateTime_ThoiGianGui.Name = "dateTime_ThoiGianGui";
            this.dateTime_ThoiGianGui.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTime_ThoiGianGui.Properties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.dateTime_ThoiGianGui.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTime_ThoiGianGui.Properties.Mask.EditMask = "HH:mm:ss dd/MM/yyyy";
            this.dateTime_ThoiGianGui.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateTime_ThoiGianGui.Size = new System.Drawing.Size(114, 20);
            this.dateTime_ThoiGianGui.TabIndex = 5;
            // 
            // chkChonNgay
            // 
            this.chkChonNgay.IsChangeText = false;
            this.chkChonNgay.IsFocus = false;
            this.chkChonNgay.KeyCommand = System.Windows.Forms.Keys.None;
            this.chkChonNgay.Location = new System.Drawing.Point(4, 59);
            this.chkChonNgay.Name = "chkChonNgay";
            this.chkChonNgay.Properties.Caption = "";
            this.chkChonNgay.Size = new System.Drawing.Size(26, 19);
            this.chkChonNgay.TabIndex = 4;
            this.chkChonNgay.CheckedChanged += new System.EventHandler(this.chkChonNgay_CheckedChanged_1);
            // 
            // rbDTV
            // 
            this.rbDTV.AutoSize = true;
            this.rbDTV.Location = new System.Drawing.Point(196, 27);
            this.rbDTV.Name = "rbDTV";
            this.rbDTV.Size = new System.Drawing.Size(59, 17);
            this.rbDTV.TabIndex = 3;
            this.rbDTV.TabStop = true;
            this.rbDTV.Text = "&3. ĐTV";
            this.rbDTV.UseVisualStyleBackColor = true;
            this.rbDTV.CheckedChanged += new System.EventHandler(this.rbDTV_CheckedChanged_1);
            // 
            // rbDHV
            // 
            this.rbDHV.AutoSize = true;
            this.rbDHV.Location = new System.Drawing.Point(120, 27);
            this.rbDHV.Name = "rbDHV";
            this.rbDHV.Size = new System.Drawing.Size(60, 17);
            this.rbDHV.TabIndex = 2;
            this.rbDHV.TabStop = true;
            this.rbDHV.Text = "&2. ĐHV";
            this.rbDHV.UseVisualStyleBackColor = true;
            this.rbDHV.CheckedChanged += new System.EventHandler(this.rbDHV_CheckedChanged_1);
            // 
            // rbTatCa
            // 
            this.rbTatCa.AutoSize = true;
            this.rbTatCa.Location = new System.Drawing.Point(27, 27);
            this.rbTatCa.Name = "rbTatCa";
            this.rbTatCa.Size = new System.Drawing.Size(68, 17);
            this.rbTatCa.TabIndex = 1;
            this.rbTatCa.TabStop = true;
            this.rbTatCa.Text = "&1. Tất cả";
            this.rbTatCa.UseVisualStyleBackColor = true;
            this.rbTatCa.CheckedChanged += new System.EventHandler(this.rbTatCa_CheckedChanged_1);
            // 
            // txtTaiKhoan1
            // 
            this.txtTaiKhoan1.Location = new System.Drawing.Point(66, 100);
            this.txtTaiKhoan1.MaxLength = 1000;
            this.txtTaiKhoan1.Name = "txtTaiKhoan1";
            this.txtTaiKhoan1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtTaiKhoan1.Size = new System.Drawing.Size(310, 37);
            this.txtTaiKhoan1.TabIndex = 8;
            this.txtTaiKhoan1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tài khoản";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tiêu đề";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nội dung";
            // 
            // SendMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbCapDo);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.btnTinMau);
            this.Controls.Add(this.myGroupBox1);
            this.Controls.Add(this.txtNoiDung1);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.label1);
            this.Name = "SendMessage";
            this.Size = new System.Drawing.Size(498, 309);
            this.Load += new System.EventHandler(this.SendMessage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myGroupBox1)).EndInit();
            this.myGroupBox1.ResumeLayout(false);
            this.myGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTime_ThoiGianGui.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTime_ThoiGianGui.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChonNgay.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblThongBao;
        public System.Windows.Forms.RichTextBox txtNoiDung1;
        private Base.Controls.ShGroupBox myGroupBox1;
        public System.Windows.Forms.RichTextBox txtTaiKhoan1;
        public System.Windows.Forms.TextBox txtTieuDe;
        public System.Windows.Forms.Button btnTaiKhoan;
        public System.Windows.Forms.RadioButton rbDTV;
        public Base.Inputs.InputDate dateTime_ThoiGianGui;
        public Base.Inputs.InputCheckbox chkChonNgay;
        public System.Windows.Forms.RadioButton rbDHV;
        public System.Windows.Forms.RadioButton rbTatCa;
        public System.Windows.Forms.CheckBox chkIsActiveUser;
        private Base.Controls.ShButton btnTinMau;
        private Base.Controls.ShButton btnGui;
        private System.Windows.Forms.ComboBox cbCapDo;
        private System.Windows.Forms.Label label1;
    }
}
