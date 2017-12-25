namespace OneTaxi.Settings
{
    partial class FrmSettings
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
            this.panelInput1 = new OneTaxi.Controls.Base.Controls.PanelInput();
            this.label6 = new OneTaxi.Controls.Base.Controls.Label();
            this.label5 = new OneTaxi.Controls.Base.Controls.Label();
            this.label4 = new OneTaxi.Controls.Base.Controls.Label();
            this.label3 = new OneTaxi.Controls.Base.Controls.Label();
            this.label2 = new OneTaxi.Controls.Base.Controls.Label();
            this.label1 = new OneTaxi.Controls.Base.Controls.Label();
            this.lupModule = new OneTaxi.Controls.Base.Common.Enums.InputLookUps.InputEnumLookUp_Module();
            this.txtPass = new OneTaxi.Controls.Base.Inputs.InputText();
            this.txtUser = new OneTaxi.Controls.Base.Inputs.InputText();
            this.txtDatabase = new OneTaxi.Controls.Base.Inputs.InputText();
            this.txtSoure = new OneTaxi.Controls.Base.Inputs.InputText();
            this.txtIPAddress = new OneTaxi.Controls.Base.Inputs.InputText();
            this.panelControl1 = new OneTaxi.Controls.Base.Controls.PanelControl();
            this.lblMsg = new OneTaxi.Controls.Base.Controls.Label();
            this.btnThoat = new OneTaxi.Controls.Base.Controls.Button();
            this.btnKiemTra = new OneTaxi.Controls.Base.Controls.Button();
            this.btnKetNoi = new OneTaxi.Controls.Base.Controls.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelInput1)).BeginInit();
            this.panelInput1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lupModule.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoure.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIPAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Size = new System.Drawing.Size(269, 27);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // panelInput1
            // 
            this.panelInput1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelInput1.Controls.Add(this.label6);
            this.panelInput1.Controls.Add(this.label5);
            this.panelInput1.Controls.Add(this.label4);
            this.panelInput1.Controls.Add(this.label3);
            this.panelInput1.Controls.Add(this.label2);
            this.panelInput1.Controls.Add(this.label1);
            this.panelInput1.Controls.Add(this.lupModule);
            this.panelInput1.Controls.Add(this.txtPass);
            this.panelInput1.Controls.Add(this.txtUser);
            this.panelInput1.Controls.Add(this.txtDatabase);
            this.panelInput1.Controls.Add(this.txtSoure);
            this.panelInput1.Controls.Add(this.txtIPAddress);
            this.panelInput1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInput1.LabelMessage = null;
            this.panelInput1.Location = new System.Drawing.Point(0, 27);
            this.panelInput1.Name = "panelInput1";
            this.panelInput1.Size = new System.Drawing.Size(269, 172);
            this.panelInput1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(34, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 2;
            this.label6.TagLanguage = null;
            this.label6.Text = "Mật khẩu";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(32, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 2;
            this.label5.TagLanguage = null;
            this.label5.Text = "Tài khoản";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(32, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 2;
            this.label4.TagLanguage = null;
            this.label4.Text = "Tên CSDL";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(17, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.TagLanguage = null;
            this.label3.Text = "Tên máy chủ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(47, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.TagLanguage = null;
            this.label2.Text = "Vai trò";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(33, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.TagLanguage = null;
            this.label1.Text = "Địa chỉ IP";
            // 
            // lupModule
            // 
            this.lupModule.DefaultSelectFirstRow = true;
            this.lupModule.IsAddAll = false;
            this.lupModule.IsChangeText = false;
            this.lupModule.IsFocus = false;
            this.lupModule.Location = new System.Drawing.Point(83, 37);
            this.lupModule.MenuManager = this.ribbonControl1;
            this.lupModule.Name = "lupModule";
            this.lupModule.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupModule.Properties.NullText = "";
            this.lupModule.Size = new System.Drawing.Size(169, 20);
            this.lupModule.TabIndex = 1;
            this.lupModule.Tag = "ModuleId";
            // 
            // txtPass
            // 
            this.txtPass.IsChangeText = false;
            this.txtPass.IsFocus = false;
            this.txtPass.Location = new System.Drawing.Point(83, 141);
            this.txtPass.Name = "txtPass";
            this.txtPass.Properties.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(169, 20);
            this.txtPass.TabIndex = 5;
            this.txtPass.Tag = "Password";
            // 
            // txtUser
            // 
            this.txtUser.IsChangeText = false;
            this.txtUser.IsFocus = false;
            this.txtUser.Location = new System.Drawing.Point(84, 115);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(169, 20);
            this.txtUser.TabIndex = 4;
            this.txtUser.Tag = "UserID";
            // 
            // txtDatabase
            // 
            this.txtDatabase.IsChangeText = false;
            this.txtDatabase.IsFocus = false;
            this.txtDatabase.Location = new System.Drawing.Point(83, 89);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(169, 20);
            this.txtDatabase.TabIndex = 3;
            this.txtDatabase.Tag = "InitialCatalog";
            // 
            // txtSoure
            // 
            this.txtSoure.IsChangeText = false;
            this.txtSoure.IsFocus = false;
            this.txtSoure.Location = new System.Drawing.Point(83, 63);
            this.txtSoure.Name = "txtSoure";
            this.txtSoure.Size = new System.Drawing.Size(169, 20);
            this.txtSoure.TabIndex = 2;
            this.txtSoure.Tag = "DataSource";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.IsChangeText = false;
            this.txtIPAddress.IsFocus = false;
            this.txtIPAddress.Location = new System.Drawing.Point(83, 11);
            this.txtIPAddress.MenuManager = this.ribbonControl1;
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(169, 20);
            this.txtIPAddress.TabIndex = 0;
            this.txtIPAddress.Tag = "IPAddress";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.lblMsg);
            this.panelControl1.Controls.Add(this.btnThoat);
            this.panelControl1.Controls.Add(this.btnKiemTra);
            this.panelControl1.Controls.Add(this.btnKetNoi);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 199);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(269, 53);
            this.panelControl1.TabIndex = 2;
            // 
            // lblMsg
            // 
            this.lblMsg.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(44, 5);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(112, 13);
            this.lblMsg.TabIndex = 2;
            this.lblMsg.TagLanguage = null;
            this.lblMsg.Text = "Lỗi kết nối đến máy chủ";
            // 
            // btnThoat
            // 
            this.btnThoat.KeyCommand = System.Windows.Forms.Keys.None;
            this.btnThoat.Location = new System.Drawing.Point(169, 23);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(58, 23);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.TagLanguage = null;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.KeyCommand = System.Windows.Forms.Keys.None;
            this.btnKiemTra.Location = new System.Drawing.Point(105, 23);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(58, 23);
            this.btnKiemTra.TabIndex = 1;
            this.btnKiemTra.TagLanguage = null;
            this.btnKiemTra.Text = "Kiểm tra";
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.KeyCommand = System.Windows.Forms.Keys.None;
            this.btnKetNoi.Location = new System.Drawing.Point(41, 23);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(58, 23);
            this.btnKetNoi.TabIndex = 0;
            this.btnKetNoi.TagLanguage = null;
            this.btnKetNoi.Text = "Kết nối";
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 252);
            this.Controls.Add(this.panelInput1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSettings";
            this.Text = "Cấu hình hệ thống";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.panelInput1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelInput1)).EndInit();
            this.panelInput1.ResumeLayout(false);
            this.panelInput1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lupModule.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoure.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIPAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Base.Controls.PanelInput panelInput1;
        private Controls.Base.Controls.PanelControl panelControl1;
        private Controls.Base.Controls.Button btnKetNoi;
        private Controls.Base.Controls.Button btnThoat;
        private Controls.Base.Controls.Button btnKiemTra;
        private Controls.Base.Inputs.InputText txtIPAddress;
        private Controls.Base.Common.Enums.InputLookUps.InputEnumLookUp_Module lupModule;
        private Controls.Base.Inputs.InputText txtUser;
        private Controls.Base.Inputs.InputText txtDatabase;
        private Controls.Base.Inputs.InputText txtSoure;
        private Controls.Base.Controls.Label label1;
        private Controls.Base.Controls.Label label2;
        private Controls.Base.Controls.Label label5;
        private Controls.Base.Controls.Label label4;
        private Controls.Base.Controls.Label label3;
        private Controls.Base.Controls.Label label6;
        private Controls.Base.Inputs.InputText txtPass;
        private Controls.Base.Controls.Label lblMsg;
    }
}