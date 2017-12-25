namespace StaxiMan
{
    partial class StaxiManagement
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButton_BuildLicense = new DevExpress.XtraBars.BarButtonItem();
            this.barButton_Account = new DevExpress.XtraBars.BarButtonItem();
            this.barButton_Request = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonAPILicense = new DevExpress.XtraBars.BarButtonItem();
            this.barButton_Company = new DevExpress.XtraBars.BarButtonItem();
            this.barButton_License = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem_ServerInfo = new DevExpress.XtraBars.BarStaticItem();
            this.barToggleSwitchItem1 = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.barAccountInfo = new DevExpress.XtraBars.BarHeaderItem();
            this.barStaticVersion = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonServerMan = new DevExpress.XtraBars.BarButtonItem();
            this.btnConnectMan = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonMiniToolbar1 = new DevExpress.XtraBars.Ribbon.RibbonMiniToolbar(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.panelMain = new DevExpress.XtraEditors.PanelControl();
            this.panelControl_Login = new DevExpress.XtraEditors.PanelControl();
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Login)).BeginInit();
            this.panelControl_Login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.Enabled = false;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barButton_BuildLicense,
            this.barButton_Account,
            this.barButton_Request,
            this.barButtonAPILicense,
            this.barButton_Company,
            this.barButton_License,
            this.barStaticItem_ServerInfo,
            this.barToggleSwitchItem1,
            this.barAccountInfo,
            this.barStaticVersion,
            this.barButtonServerMan,
            this.btnConnectMan});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 13;
            this.ribbon.MiniToolbars.Add(this.ribbonMiniToolbar1);
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.Size = new System.Drawing.Size(679, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.TransparentEditors = true;
            // 
            // barButton_BuildLicense
            // 
            this.barButton_BuildLicense.Caption = "Build License";
            this.barButton_BuildLicense.Id = 1;
            this.barButton_BuildLicense.ImageOptions.LargeImage = global::StaxiMan.Properties.Resources._1487933329_button_check_basic_blue;
            this.barButton_BuildLicense.Name = "barButton_BuildLicense";
            this.barButton_BuildLicense.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButton_BuildLicense.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButton_BuildLicense_ItemClick);
            // 
            // barButton_Account
            // 
            this.barButton_Account.Caption = "Account";
            this.barButton_Account.Id = 2;
            this.barButton_Account.ImageOptions.LargeImage = global::StaxiMan.Properties.Resources.AccountPersone_48;
            this.barButton_Account.Name = "barButton_Account";
            this.barButton_Account.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButton_Account.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButton_Account_ItemClick);
            // 
            // barButton_Request
            // 
            this.barButton_Request.Caption = "Request history";
            this.barButton_Request.Id = 3;
            this.barButton_Request.ImageOptions.LargeImage = global::StaxiMan.Properties.Resources.Mail;
            this.barButton_Request.Name = "barButton_Request";
            this.barButton_Request.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButton_Request.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButton_Request_ItemClick);
            // 
            // barButtonAPILicense
            // 
            this.barButtonAPILicense.Caption = "API License";
            this.barButtonAPILicense.Id = 4;
            this.barButtonAPILicense.ImageOptions.LargeImage = global::StaxiMan.Properties.Resources.Location;
            this.barButtonAPILicense.Name = "barButtonAPILicense";
            this.barButtonAPILicense.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonAPILicense.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonAPILicense_ItemClick);
            // 
            // barButton_Company
            // 
            this.barButton_Company.Caption = "Company";
            this.barButton_Company.Id = 5;
            this.barButton_Company.ImageOptions.Image = global::StaxiMan.Properties.Resources._1487933273_home_basic_blue;
            this.barButton_Company.Name = "barButton_Company";
            this.barButton_Company.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButton_Company.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButton_Company_ItemClick);
            // 
            // barButton_License
            // 
            this.barButton_License.Caption = "License";
            this.barButton_License.Id = 6;
            this.barButton_License.ImageOptions.Image = global::StaxiMan.Properties.Resources.licence;
            this.barButton_License.Name = "barButton_License";
            this.barButton_License.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButton_License.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButton_License_ItemClick);
            // 
            // barStaticItem_ServerInfo
            // 
            this.barStaticItem_ServerInfo.Caption = "Server Info";
            this.barStaticItem_ServerInfo.Id = 7;
            this.barStaticItem_ServerInfo.Name = "barStaticItem_ServerInfo";
            this.barStaticItem_ServerInfo.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barToggleSwitchItem1
            // 
            this.barToggleSwitchItem1.Caption = "barToggleSwitchItem1";
            this.barToggleSwitchItem1.Id = 8;
            this.barToggleSwitchItem1.Name = "barToggleSwitchItem1";
            // 
            // barAccountInfo
            // 
            this.barAccountInfo.Caption = "Account Info";
            this.barAccountInfo.Id = 9;
            this.barAccountInfo.Name = "barAccountInfo";
            // 
            // barStaticVersion
            // 
            this.barStaticVersion.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticVersion.Caption = "Version";
            this.barStaticVersion.Id = 10;
            this.barStaticVersion.Name = "barStaticVersion";
            this.barStaticVersion.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonServerMan
            // 
            this.barButtonServerMan.Caption = "Server";
            this.barButtonServerMan.Id = 11;
            this.barButtonServerMan.ImageOptions.LargeImage = global::StaxiMan.Properties.Resources._1489227204_system_monitor;
            this.barButtonServerMan.Name = "barButtonServerMan";
            this.barButtonServerMan.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonServerMan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonServerMan_ItemClick);
            // 
            // btnConnectMan
            // 
            this.btnConnectMan.Caption = "Connection Management";
            this.btnConnectMan.Id = 12;
            this.btnConnectMan.ImageOptions.Image = global::StaxiMan.Properties.Resources._1489227204_system_monitor;
            this.btnConnectMan.ImageOptions.LargeImage = global::StaxiMan.Properties.Resources._1489227204_system_monitor;
            this.btnConnectMan.Name = "btnConnectMan";
            this.btnConnectMan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConnectMan_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Management";
            // 
            // ribbonPageGroup
            // 
            this.ribbonPageGroup.ItemLinks.Add(this.barButton_BuildLicense);
            this.ribbonPageGroup.ItemLinks.Add(this.barButton_Account);
            this.ribbonPageGroup.ItemLinks.Add(this.barButton_Request);
            this.ribbonPageGroup.ItemLinks.Add(this.barButtonAPILicense);
            this.ribbonPageGroup.ItemLinks.Add(this.barButton_Company);
            this.ribbonPageGroup.ItemLinks.Add(this.barButton_License);
            this.ribbonPageGroup.ItemLinks.Add(this.barButtonServerMan);
            this.ribbonPageGroup.ItemLinks.Add(this.btnConnectMan);
            this.ribbonPageGroup.Name = "ribbonPageGroup";
            this.ribbonPageGroup.ShowCaptionButton = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem_ServerInfo);
            this.ribbonStatusBar.ItemLinks.Add(this.barAccountInfo);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticVersion);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 418);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(679, 31);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.FloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabbedMdiManager1.FloatOnDrag = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelControl_Login);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 143);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(679, 275);
            this.panelMain.TabIndex = 3;
            // 
            // panelControl_Login
            // 
            this.panelControl_Login.Controls.Add(this.lblMessage);
            this.panelControl_Login.Controls.Add(this.btnLogin);
            this.panelControl_Login.Controls.Add(this.txtPassword);
            this.panelControl_Login.Controls.Add(this.txtUserName);
            this.panelControl_Login.Controls.Add(this.labelControl2);
            this.panelControl_Login.Controls.Add(this.labelControl1);
            this.panelControl_Login.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.panelControl_Login.Location = new System.Drawing.Point(12, 6);
            this.panelControl_Login.Name = "panelControl_Login";
            this.panelControl_Login.Size = new System.Drawing.Size(260, 110);
            this.panelControl_Login.TabIndex = 0;
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Appearance.Options.UseForeColor = true;
            this.lblMessage.Location = new System.Drawing.Point(9, 91);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(19, 13);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "msg";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(68, 56);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(68, 29);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '#';
            this.txtPassword.Size = new System.Drawing.Size(188, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(68, 3);
            this.txtUserName.MenuManager = this.ribbon;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(188, 20);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 25);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Password";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "User Name";
            // 
            // StaxiManagement
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(679, 449);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "StaxiManagement";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Staxi Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StaxiManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Login)).EndInit();
            this.panelControl_Login.ResumeLayout(false);
            this.panelControl_Login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem barButton_BuildLicense;
        private DevExpress.XtraBars.BarButtonItem barButton_Account;
        private DevExpress.XtraBars.BarButtonItem barButton_Request;
        private DevExpress.XtraBars.BarButtonItem barButtonAPILicense;
        private DevExpress.XtraBars.BarButtonItem barButton_Company;
        private DevExpress.XtraBars.BarButtonItem barButton_License;
        private DevExpress.XtraBars.Ribbon.RibbonMiniToolbar ribbonMiniToolbar1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem_ServerInfo;
        private DevExpress.XtraEditors.PanelControl panelMain;
        private DevExpress.XtraEditors.PanelControl panelControl_Login;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblMessage;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraBars.BarToggleSwitchItem barToggleSwitchItem1;
        private DevExpress.XtraBars.BarHeaderItem barAccountInfo;
        private DevExpress.XtraBars.BarStaticItem barStaticVersion;
        private DevExpress.XtraBars.BarButtonItem barButtonServerMan;
        private DevExpress.XtraBars.BarButtonItem btnConnectMan;
    }
}