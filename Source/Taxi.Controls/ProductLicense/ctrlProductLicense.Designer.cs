namespace Taxi.Controls.ProductLicense
{
    partial class ctrlProductLicense
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtAPIKey = new Taxi.Controls.Base.Inputs.InputText();
            this.txtCodeLicense = new Taxi.Controls.Base.Inputs.InputText();
            this.lblMsg = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtKeyLicense = new Taxi.Controls.Base.Inputs.InputMemoEdit();
            this.shLabel5 = new Taxi.Controls.Base.Controls.ShLabel();
            this.btnConfirmLicense = new Taxi.Controls.Base.Controls.ShButton();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shGroupBox1 = new Taxi.Controls.Base.Controls.ShGroupBox();
            this.shLabel6 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel4 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel3 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtPassword = new Taxi.Controls.Base.Inputs.InputText();
            this.txtUserName = new Taxi.Controls.Base.Inputs.InputText();
            this.btnGetLicenseCode = new Taxi.Controls.Base.Controls.ShButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAPIKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodeLicense.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyLicense.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shGroupBox1)).BeginInit();
            this.shGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtAPIKey);
            this.groupControl1.Controls.Add(this.txtCodeLicense);
            this.groupControl1.Controls.Add(this.lblMsg);
            this.groupControl1.Controls.Add(this.txtKeyLicense);
            this.groupControl1.Controls.Add(this.shLabel5);
            this.groupControl1.Controls.Add(this.btnConfirmLicense);
            this.groupControl1.Controls.Add(this.shLabel1);
            this.groupControl1.Controls.Add(this.shLabel2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 104);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(469, 225);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "Thông tin bản quyền";
            // 
            // txtAPIKey
            // 
            this.txtAPIKey.IsChangeText = false;
            this.txtAPIKey.IsFocus = false;
            this.txtAPIKey.Location = new System.Drawing.Point(116, 151);
            this.txtAPIKey.Name = "txtAPIKey";
            this.txtAPIKey.Size = new System.Drawing.Size(279, 20);
            this.txtAPIKey.TabIndex = 3;
            // 
            // txtCodeLicense
            // 
            this.txtCodeLicense.IsChangeText = false;
            this.txtCodeLicense.IsFocus = false;
            this.txtCodeLicense.Location = new System.Drawing.Point(116, 23);
            this.txtCodeLicense.Name = "txtCodeLicense";
            this.txtCodeLicense.Size = new System.Drawing.Size(279, 20);
            this.txtCodeLicense.TabIndex = 3;
            // 
            // lblMsg
            // 
            this.lblMsg.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Appearance.Options.UseForeColor = true;
            this.lblMsg.Location = new System.Drawing.Point(6, 205);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(66, 13);
            this.lblMsg.TabIndex = 8;
            this.lblMsg.Text = "--Thông tin lỗi";
            this.lblMsg.Visible = false;
            // 
            // txtKeyLicense
            // 
            this.txtKeyLicense.IsChangeText = false;
            this.txtKeyLicense.IsFocus = false;
            this.txtKeyLicense.Location = new System.Drawing.Point(116, 49);
            this.txtKeyLicense.Name = "txtKeyLicense";
            this.txtKeyLicense.Size = new System.Drawing.Size(279, 96);
            this.txtKeyLicense.TabIndex = 4;
            // 
            // shLabel5
            // 
            this.shLabel5.Location = new System.Drawing.Point(42, 154);
            this.shLabel5.Name = "shLabel5";
            this.shLabel5.Size = new System.Drawing.Size(38, 13);
            this.shLabel5.TabIndex = 5;
            this.shLabel5.Text = "API Key";
            // 
            // btnConfirmLicense
            // 
            this.btnConfirmLicense.Location = new System.Drawing.Point(116, 177);
            this.btnConfirmLicense.Name = "btnConfirmLicense";
            this.btnConfirmLicense.Size = new System.Drawing.Size(72, 23);
            this.btnConfirmLicense.TabIndex = 5;
            this.btnConfirmLicense.Text = "Chứng thực";
            this.btnConfirmLicense.Click += new System.EventHandler(this.btnConfirmLicense_Click);
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(42, 26);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(63, 13);
            this.shLabel1.TabIndex = 5;
            this.shLabel1.Text = "License Code";
            // 
            // shLabel2
            // 
            this.shLabel2.Location = new System.Drawing.Point(42, 51);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(56, 13);
            this.shLabel2.TabIndex = 6;
            this.shLabel2.Text = "License Key";
            // 
            // shGroupBox1
            // 
            this.shGroupBox1.Controls.Add(this.shLabel6);
            this.shGroupBox1.Controls.Add(this.shLabel4);
            this.shGroupBox1.Controls.Add(this.shLabel3);
            this.shGroupBox1.Controls.Add(this.txtPassword);
            this.shGroupBox1.Controls.Add(this.txtUserName);
            this.shGroupBox1.Controls.Add(this.btnGetLicenseCode);
            this.shGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.shGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.shGroupBox1.Name = "shGroupBox1";
            this.shGroupBox1.Size = new System.Drawing.Size(469, 104);
            this.shGroupBox1.TabIndex = 2;
            this.shGroupBox1.Text = "Gửi yêu cầu";
            // 
            // shLabel6
            // 
            this.shLabel6.Appearance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shLabel6.Appearance.Options.UseFont = true;
            this.shLabel6.Location = new System.Drawing.Point(14, 79);
            this.shLabel6.Name = "shLabel6";
            this.shLabel6.Size = new System.Drawing.Size(433, 14);
            this.shLabel6.TabIndex = 5;
            this.shLabel6.Text = "Mọi thắc mắc xin vui lòng liên hệ SĐT: 1900 6085 - Email: cskh.staxi.binhanh.com";
            // 
            // shLabel4
            // 
            this.shLabel4.Location = new System.Drawing.Point(42, 53);
            this.shLabel4.Name = "shLabel4";
            this.shLabel4.Size = new System.Drawing.Size(44, 13);
            this.shLabel4.TabIndex = 5;
            this.shLabel4.Text = "Mật khẩu";
            // 
            // shLabel3
            // 
            this.shLabel3.Location = new System.Drawing.Point(42, 27);
            this.shLabel3.Name = "shLabel3";
            this.shLabel3.Size = new System.Drawing.Size(46, 13);
            this.shLabel3.TabIndex = 5;
            this.shLabel3.Text = "Tài khoản";
            // 
            // txtPassword
            // 
            this.txtPassword.IsChangeText = false;
            this.txtPassword.IsFocus = false;
            this.txtPassword.Location = new System.Drawing.Point(116, 50);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(152, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUserName
            // 
            this.txtUserName.IsChangeText = false;
            this.txtUserName.IsFocus = false;
            this.txtUserName.Location = new System.Drawing.Point(116, 24);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(152, 20);
            this.txtUserName.TabIndex = 0;
            // 
            // btnGetLicenseCode
            // 
            this.btnGetLicenseCode.Location = new System.Drawing.Point(274, 48);
            this.btnGetLicenseCode.Name = "btnGetLicenseCode";
            this.btnGetLicenseCode.Size = new System.Drawing.Size(121, 23);
            this.btnGetLicenseCode.TabIndex = 2;
            this.btnGetLicenseCode.Text = "Gửi yêu cầu bản quyền";
            this.btnGetLicenseCode.Click += new System.EventHandler(this.btnGetLicenseCode_Click);
            // 
            // ctrlProductLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.shGroupBox1);
            this.Name = "ctrlProductLicense";
            this.Size = new System.Drawing.Size(469, 329);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAPIKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodeLicense.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyLicense.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shGroupBox1)).EndInit();
            this.shGroupBox1.ResumeLayout(false);
            this.shGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Controls.ShGroupBox shGroupBox1;
        private Base.Controls.ShLabel lblMsg;
        private Base.Controls.ShButton btnConfirmLicense;
        private Base.Controls.ShLabel shLabel2;
        private Base.Controls.ShLabel shLabel1;
        private Base.Inputs.InputMemoEdit txtKeyLicense;
        private Base.Inputs.InputText txtCodeLicense;
        private Base.Controls.ShButton btnGetLicenseCode;
        private Base.Controls.ShLabel shLabel4;
        private Base.Controls.ShLabel shLabel3;
        private Base.Inputs.InputText txtPassword;
        private Base.Inputs.InputText txtUserName;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private Base.Inputs.InputText txtAPIKey;
        private Base.Controls.ShLabel shLabel5;
        private Base.Controls.ShLabel shLabel6;
    }
}
