namespace TaxiOperation_TongDai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChenMoiMotCuocDienThoai));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer_LoadDiaChi = new System.Windows.Forms.Timer(this.components);
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.editPhoneNumber = new Taxi.Controls.Base.Inputs.InputText();
            this.txtDiaChiDonKhach = new Femiani.Forms.UI.Input.CoolTextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.btnOK = new Janus.Windows.EditControls.UIButton();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.uiTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editPhoneNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // timer_LoadDiaChi
            // 
            this.timer_LoadDiaChi.Enabled = true;
            this.timer_LoadDiaChi.Interval = 1000;
            this.timer_LoadDiaChi.Tick += new System.EventHandler(this.timer_LoadDiaChi_Tick);
            // 
            // uiTab1
            // 
            this.uiTab1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiTab1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTab1.Location = new System.Drawing.Point(0, 0);
            this.uiTab1.Margin = new System.Windows.Forms.Padding(2);
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.Size = new System.Drawing.Size(451, 124);
            this.uiTab1.TabIndex = 1;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage1});
            this.uiTab1.TabStop = false;
            this.uiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2003;
            // 
            // uiTabPage1
            // 
            this.uiTabPage1.Controls.Add(this.editPhoneNumber);
            this.uiTabPage1.Controls.Add(this.txtDiaChiDonKhach);
            this.uiTabPage1.Controls.Add(this.lblInfo);
            this.uiTabPage1.Controls.Add(this.label4);
            this.uiTabPage1.Controls.Add(this.label2);
            this.uiTabPage1.Location = new System.Drawing.Point(1, 21);
            this.uiTabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.uiTabPage1.Name = "uiTabPage1";
            this.uiTabPage1.Size = new System.Drawing.Size(449, 102);
            this.uiTabPage1.TabStop = true;
            this.uiTabPage1.Text = "Chèn mới một cuộc điện thoại";
            // 
            // editPhoneNumber
            // 
            this.editPhoneNumber.IsChangeText = false;
            this.editPhoneNumber.IsFocus = false;
            this.editPhoneNumber.Location = new System.Drawing.Point(101, 30);
            this.editPhoneNumber.Name = "editPhoneNumber";
            this.editPhoneNumber.Properties.Mask.EditMask = "\\d+";
            this.editPhoneNumber.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.editPhoneNumber.Properties.MaxLength = 15;
            this.editPhoneNumber.Size = new System.Drawing.Size(145, 20);
            this.editPhoneNumber.TabIndex = 0;
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
            this.txtDiaChiDonKhach.Location = new System.Drawing.Point(101, 56);
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
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(98, 5);
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
            this.label4.Location = new System.Drawing.Point(1, 56);
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
            this.label2.Location = new System.Drawing.Point(26, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số điện thoại";
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel;
            this.uiGroupBox1.Controls.Add(this.btnOK);
            this.uiGroupBox1.Controls.Add(this.btnCancel);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox1.FrameStyle = Janus.Windows.EditControls.FrameStyle.None;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 124);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(451, 38);
            this.uiGroupBox1.TabIndex = 2;
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003;
            // 
            // btnOK
            // 
            this.btnOK.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Button;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(102, 5);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(79, 26);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&Cập nhật";
            this.btnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::TaxiOperation_TongDai.Properties.Resources.Close;
            this.btnCancel.Location = new System.Drawing.Point(185, 5);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 26);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Hủy bỏ";
            this.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmChenMoiMotCuocDienThoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 166);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.uiTab1);
            this.Name = "frmChenMoiMotCuocDienThoai";
            this.Text = "Điều hành điện thoại - Tổng đài";
            this.Load += new System.EventHandler(this.frmChenMoiMotCuocDienThoai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.uiTabPage1.ResumeLayout(false);
            this.uiTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editPhoneNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Timer timer_LoadDiaChi;
        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
        private Taxi.Controls.Base.Inputs.InputText editPhoneNumber;
        private Femiani.Forms.UI.Input.CoolTextBox txtDiaChiDonKhach;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.EditControls.UIButton btnOK;
        private Janus.Windows.EditControls.UIButton btnCancel;
    }
}