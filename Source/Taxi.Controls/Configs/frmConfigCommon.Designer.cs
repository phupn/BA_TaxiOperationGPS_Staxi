namespace Taxi.Controls.Configs
{
    partial class frmConfigCommon
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
            this.panelBottom = new Taxi.Controls.BanCo.MyPanelControl();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.panelTop = new Taxi.Controls.BanCo.MyPanelControl();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.shGroupBox = new Taxi.Controls.Base.Controls.ShGroupBox();
            this.gridConfig = new DevExpress.XtraGrid.GridControl();
            this.gridViewConfig = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ConfigName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Value = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Notify = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DateCreated = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shGroupBox)).BeginInit();
            this.shGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.shLabel1);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 499);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(639, 51);
            this.panelBottom.TabIndex = 7;
            // 
            // shLabel1
            // 
            this.shLabel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.shLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.shLabel1.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.shLabel1.Location = new System.Drawing.Point(249, 20);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(378, 19);
            this.shLabel1.TabIndex = 2;
            this.shLabel1.Text = "Lưu ý: Thay đổi sẽ làm ảnh hưởng toàn bộ hệ thống.";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.shLabel2);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(639, 46);
            this.panelTop.TabIndex = 6;
            // 
            // shLabel2
            // 
            this.shLabel2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.shLabel2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.shLabel2.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.shLabel2.Location = new System.Drawing.Point(78, 12);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(472, 19);
            this.shLabel2.TabIndex = 3;
            this.shLabel2.Text = "Thông tin cấu hình chung cho toàn hệ thống phần mềm điều hành";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.shGroupBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 453);
            this.panel1.TabIndex = 8;
            // 
            // shGroupBox
            // 
            this.shGroupBox.Controls.Add(this.gridConfig);
            this.shGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shGroupBox.Location = new System.Drawing.Point(0, 0);
            this.shGroupBox.Name = "shGroupBox";
            this.shGroupBox.Size = new System.Drawing.Size(639, 453);
            this.shGroupBox.TabIndex = 0;
            this.shGroupBox.Text = "Cấu hình chung cho toàn hệ thống";
            // 
            // gridConfig
            // 
            this.gridConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridConfig.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridConfig.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridConfig.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridConfig.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridConfig.EmbeddedNavigator.Buttons.First.Hint = "Dòng đầu tiên";
            this.gridConfig.EmbeddedNavigator.Buttons.Last.Hint = "Dòng cuối cùng";
            this.gridConfig.EmbeddedNavigator.Buttons.Next.Hint = "Dòng tiếp theo";
            this.gridConfig.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp theo";
            this.gridConfig.EmbeddedNavigator.Buttons.Prev.Hint = "Dòng trước";
            this.gridConfig.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.gridConfig.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridConfig.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0} / {1}";
            this.gridConfig.Location = new System.Drawing.Point(2, 22);
            this.gridConfig.MainView = this.gridViewConfig;
            this.gridConfig.Name = "gridConfig";
            this.gridConfig.Size = new System.Drawing.Size(635, 429);
            this.gridConfig.TabIndex = 1;
            this.gridConfig.UseEmbeddedNavigator = true;
            this.gridConfig.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewConfig});
            // 
            // gridViewConfig
            // 
            this.gridViewConfig.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.ConfigName,
            this.Value,
            this.Notify,
            this.DateCreated});
            this.gridViewConfig.GridControl = this.gridConfig;
            this.gridViewConfig.Name = "gridViewConfig";
            this.gridViewConfig.NewItemRowText = "Bấm vào đây để thêm cấu hình cảnh báo mới";
            this.gridViewConfig.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewConfig.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewConfig.OptionsSelection.MultiSelect = true;
            this.gridViewConfig.OptionsView.ShowGroupPanel = false;            
            this.gridViewConfig.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridViewConfig_RowUpdated);
            this.gridViewConfig.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewConfig_KeyDown);
            // 
            // ID
            // 
            this.ID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ID.AppearanceHeader.Options.UseFont = true;
            this.ID.AppearanceHeader.Options.UseTextOptions = true;
            this.ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ID.Caption = "ID";
            this.ID.FieldName = "Id";
            this.ID.Name = "ID";
            this.ID.OptionsColumn.AllowEdit = false;
            this.ID.OptionsColumn.FixedWidth = true;
            this.ID.Visible = true;
            this.ID.VisibleIndex = 0;
            this.ID.Width = 40;
            // 
            // ConfigName
            // 
            this.ConfigName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ConfigName.AppearanceHeader.Options.UseFont = true;
            this.ConfigName.AppearanceHeader.Options.UseTextOptions = true;
            this.ConfigName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ConfigName.Caption = "Tên cấu hình";
            this.ConfigName.FieldName = "Name";
            this.ConfigName.Name = "ConfigName";
            this.ConfigName.OptionsColumn.FixedWidth = true;
            this.ConfigName.OptionsFilter.AllowFilter = false;
            this.ConfigName.Visible = true;
            this.ConfigName.VisibleIndex = 1;
            this.ConfigName.Width = 180;
            // 
            // Value
            // 
            this.Value.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Value.AppearanceHeader.Options.UseFont = true;
            this.Value.AppearanceHeader.Options.UseTextOptions = true;
            this.Value.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Value.Caption = "Giá trị";
            this.Value.FieldName = "HasValue";
            this.Value.Name = "Value";
            this.Value.OptionsColumn.FixedWidth = true;
            this.Value.OptionsFilter.AllowFilter = false;
            this.Value.Visible = true;
            this.Value.VisibleIndex = 2;
            this.Value.Width = 60;
            // 
            // Notify
            // 
            this.Notify.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Notify.AppearanceHeader.Options.UseFont = true;
            this.Notify.AppearanceHeader.Options.UseTextOptions = true;
            this.Notify.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Notify.Caption = "Mô tả";
            this.Notify.FieldName = "Description";
            this.Notify.Name = "Notify";
            this.Notify.OptionsColumn.FixedWidth = true;
            this.Notify.OptionsFilter.AllowFilter = false;
            this.Notify.Visible = true;
            this.Notify.VisibleIndex = 3;
            this.Notify.Width = 230;
            // 
            // DateCreated
            // 
            this.DateCreated.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.DateCreated.AppearanceHeader.Options.UseFont = true;
            this.DateCreated.AppearanceHeader.Options.UseTextOptions = true;
            this.DateCreated.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DateCreated.Caption = "Thời gian";
            this.DateCreated.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.DateCreated.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateCreated.FieldName = "LastUpdate";
            this.DateCreated.Name = "DateCreated";
            this.DateCreated.OptionsColumn.FixedWidth = true;
            this.DateCreated.OptionsFilter.AllowFilter = false;
            this.DateCreated.Visible = true;
            this.DateCreated.VisibleIndex = 4;
            this.DateCreated.Width = 100;
            // 
            // frmConfigCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 550);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "frmConfigCommon";
            this.Text = "Cấu hình hệ thống";
            this.Load += new System.EventHandler(this.frmConfigCommon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shGroupBox)).EndInit();
            this.shGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewConfig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BanCo.MyPanelControl panelBottom;
        private BanCo.MyPanelControl panelTop;
        private System.Windows.Forms.Panel panel1;
        private Base.Controls.ShGroupBox shGroupBox;
        private Base.Controls.ShLabel shLabel1;
        private Base.Controls.ShLabel shLabel2;
        private DevExpress.XtraGrid.GridControl gridConfig;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewConfig;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn ConfigName;
        private DevExpress.XtraGrid.Columns.GridColumn Value;
        private DevExpress.XtraGrid.Columns.GridColumn Notify;
        private DevExpress.XtraGrid.Columns.GridColumn DateCreated;

    }
}