namespace Taxi.GUI
{
    partial class frmChenMoiMotCuocDienThoai
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDiaChiTraKhach = new System.Windows.Forms.TextBox();
            this.txtCuocGoiKoThanhCong = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbkGoiLai = new Taxi.Controls.Base.Inputs.InputCheckbox();
            this.editPhoneNumber = new Taxi.Controls.Base.Inputs.InputText();
            this.txtDiaChiDonKhach = new Femiani.Forms.UI.Input.CoolTextBox();
            this.timer_LoadDiaChi = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCapNhat = new Taxi.Controls.Base.Controls.ShButton();
            this.btnHuy = new Taxi.Controls.Base.Controls.ShButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbkGoiLai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPhoneNumber.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // txtDiaChiTraKhach
            // 
            this.txtDiaChiTraKhach.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDiaChiTraKhach.Enabled = false;
            this.txtDiaChiTraKhach.Location = new System.Drawing.Point(151, 121);
            this.txtDiaChiTraKhach.Name = "txtDiaChiTraKhach";
            this.txtDiaChiTraKhach.ReadOnly = true;
            this.txtDiaChiTraKhach.Size = new System.Drawing.Size(642, 20);
            this.txtDiaChiTraKhach.TabIndex = 0;
            // 
            // txtCuocGoiKoThanhCong
            // 
            this.txtCuocGoiKoThanhCong.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCuocGoiKoThanhCong.Enabled = false;
            this.txtCuocGoiKoThanhCong.Location = new System.Drawing.Point(199, 152);
            this.txtCuocGoiKoThanhCong.MaxLength = 1;
            this.txtCuocGoiKoThanhCong.Name = "txtCuocGoiKoThanhCong";
            this.txtCuocGoiKoThanhCong.ReadOnly = true;
            this.txtCuocGoiKoThanhCong.Size = new System.Drawing.Size(50, 20);
            this.txtCuocGoiKoThanhCong.TabIndex = 1;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(115, 23);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(58, 13);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "Line  Gio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Địa chỉ đó&n khách";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số điện thoại";
            // 
            // cbkGoiLai
            // 
            this.cbkGoiLai.IsChangeText = false;
            this.cbkGoiLai.IsFocus = false;
            this.cbkGoiLai.KeyCommand = System.Windows.Forms.Keys.None;
            this.cbkGoiLai.Location = new System.Drawing.Point(287, 47);
            this.cbkGoiLai.Name = "cbkGoiLai";
            this.cbkGoiLai.Properties.Caption = "Cuốc gọi lại";
            this.cbkGoiLai.Size = new System.Drawing.Size(87, 19);
            this.cbkGoiLai.TabIndex = 6;
            this.cbkGoiLai.CheckedChanged += new System.EventHandler(this.cbkGoiLai_CheckedChanged);
            // 
            // editPhoneNumber
            // 
            this.editPhoneNumber.IsChangeText = false;
            this.editPhoneNumber.IsFocus = false;
            this.editPhoneNumber.Location = new System.Drawing.Point(118, 48);
            this.editPhoneNumber.Name = "editPhoneNumber";
            this.editPhoneNumber.Properties.Mask.EditMask = "\\d+";
            this.editPhoneNumber.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.editPhoneNumber.Properties.MaxLength = 15;
            this.editPhoneNumber.Size = new System.Drawing.Size(145, 20);
            this.editPhoneNumber.TabIndex = 0;
            this.editPhoneNumber.EditValueChanged += new System.EventHandler(this.editPhoneNumber_EditValueChanged);
            this.editPhoneNumber.TextChanged += new System.EventHandler(this.editPhoneNumber_TextChanged);
            // 
            // txtDiaChiDonKhach
            // 
            this.txtDiaChiDonKhach.BackColor = System.Drawing.SystemColors.Window;
            this.txtDiaChiDonKhach.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txtDiaChiDonKhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChiDonKhach.IntTextLengthTrigger = 3;
            this.txtDiaChiDonKhach.IsAuto = false;
            this.txtDiaChiDonKhach.KinhDo = 0F;
            this.txtDiaChiDonKhach.Location = new System.Drawing.Point(118, 74);
            this.txtDiaChiDonKhach.MaxLength = 32767;
            this.txtDiaChiDonKhach.Name = "txtDiaChiDonKhach";
            this.txtDiaChiDonKhach.Padding = new System.Windows.Forms.Padding(4);
            this.txtDiaChiDonKhach.PopupWidth = 220;
            this.txtDiaChiDonKhach.SelectedItemBackColor = System.Drawing.SystemColors.Highlight;
            this.txtDiaChiDonKhach.SelectedItemForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtDiaChiDonKhach.Size = new System.Drawing.Size(316, 24);
            this.txtDiaChiDonKhach.TabIndex = 5;
            this.txtDiaChiDonKhach.TextReturn = "";
            this.txtDiaChiDonKhach.ViDo = 0F;
            this.txtDiaChiDonKhach.Load += new System.EventHandler(this.txtDiaChiDonKhach_Load);
            // 
            // timer_LoadDiaChi
            // 
            this.timer_LoadDiaChi.Enabled = true;
            this.timer_LoadDiaChi.Interval = 1000;
            this.timer_LoadDiaChi.Tick += new System.EventHandler(this.timer_LoadDiaChi_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbkGoiLai);
            this.groupBox1.Controls.Add(this.txtDiaChiDonKhach);
            this.groupBox1.Controls.Add(this.editPhoneNumber);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblInfo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 109);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chèn mới một cuộc điện thoại";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Image = global::TaxiApplication.Properties.Resources.ic_success_01;
            this.btnCapNhat.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.btnCapNhat.Location = new System.Drawing.Point(140, 122);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(89, 33);
            this.btnCapNhat.TabIndex = 3;
            this.btnCapNhat.Text = "&Cập nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Image = global::TaxiApplication.Properties.Resources.ic_delete_06_01_Red;
            this.btnHuy.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.btnHuy.Location = new System.Drawing.Point(232, 122);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(82, 33);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "&Hủy bỏ";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmChenMoiMotCuocDienThoai
            // 
            this.AcceptButton = this.btnCapNhat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(458, 158);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::TaxiApplication.Properties.Resources.Telephone_01;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChenMoiMotCuocDienThoai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điều hành điện thoại";
            this.Load += new System.EventHandler(this.frmBoDamInputData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbkGoiLai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPhoneNumber.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox txtDiaChiTraKhach;
        private System.Windows.Forms.TextBox txtCuocGoiKoThanhCong;
        //private Janus.Windows.GridEX.EditControls.EditBox txtDiaChiTraKhach;
        //private Janus.Windows.GridEX.EditControls.EditBox txtCuocGoiKoThanhCong;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private Femiani.Forms.UI.Input.CoolTextBox txtDiaChiDonKhach;
        private Controls.Base.Inputs.InputText editPhoneNumber;
        private Controls.Base.Inputs.InputCheckbox cbkGoiLai;
        private System.Windows.Forms.Timer timer_LoadDiaChi;
        private Controls.Base.Controls.ShButton btnHuy;
        private Controls.Base.Controls.ShButton btnCapNhat;
        private System.Windows.Forms.GroupBox groupBox1;


    }
}