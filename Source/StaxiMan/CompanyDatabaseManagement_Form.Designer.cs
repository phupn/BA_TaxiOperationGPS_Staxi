namespace StaxiMan
{
    partial class CompanyDatabaseManagement_Form
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
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTruncate = new DevExpress.XtraEditors.SimpleButton();
            this.btnShrinkDB = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_SystemInfo = new DevExpress.XtraGrid.GridControl();
            this.gridView_SystemInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_DB = new DevExpress.XtraGrid.GridControl();
            this.gridView_DB = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Disk = new DevExpress.XtraGrid.GridControl();
            this.gridView_Disk = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl4 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_RowCount = new DevExpress.XtraGrid.GridControl();
            this.gridView_RowCount = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_SystemInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_SystemInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Disk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Disk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_RowCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_RowCount)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.btnTruncate);
            this.panelTop.Controls.Add(this.btnShrinkDB);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1045, 78);
            this.panelTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(275, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(427, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server Information Management";
            // 
            // btnTruncate
            // 
            this.btnTruncate.Location = new System.Drawing.Point(954, 50);
            this.btnTruncate.Name = "btnTruncate";
            this.btnTruncate.Size = new System.Drawing.Size(86, 23);
            this.btnTruncate.TabIndex = 1;
            this.btnTruncate.Text = "Truncate table";
            this.btnTruncate.ToolTip = "Xóa toàn bộ dữ liệu của 1 bảng";
            this.btnTruncate.Click += new System.EventHandler(this.btnTruncate_Click);
            // 
            // btnShrinkDB
            // 
            this.btnShrinkDB.Location = new System.Drawing.Point(6, 50);
            this.btnShrinkDB.Name = "btnShrinkDB";
            this.btnShrinkDB.Size = new System.Drawing.Size(75, 23);
            this.btnShrinkDB.TabIndex = 0;
            this.btnShrinkDB.Text = "Shrink DB";
            this.btnShrinkDB.ToolTip = "Xóa cache file log db";
            this.btnShrinkDB.Click += new System.EventHandler(this.btnShrinkDB_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl_SystemInfo);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(667, 301);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "System Info";
            // 
            // gridControl_SystemInfo
            // 
            this.gridControl_SystemInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_SystemInfo.Location = new System.Drawing.Point(2, 20);
            this.gridControl_SystemInfo.MainView = this.gridView_SystemInfo;
            this.gridControl_SystemInfo.Name = "gridControl_SystemInfo";
            this.gridControl_SystemInfo.Size = new System.Drawing.Size(663, 279);
            this.gridControl_SystemInfo.TabIndex = 1;
            this.gridControl_SystemInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_SystemInfo});
            // 
            // gridView_SystemInfo
            // 
            this.gridView_SystemInfo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView_SystemInfo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView_SystemInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.gridView_SystemInfo.GridControl = this.gridControl_SystemInfo;
            this.gridView_SystemInfo.Name = "gridView_SystemInfo";
            this.gridView_SystemInfo.OptionsBehavior.Editable = false;
            this.gridView_SystemInfo.OptionsView.ColumnAutoWidth = false;
            this.gridView_SystemInfo.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_SystemInfo.OptionsView.ShowGroupPanel = false;
            this.gridView_SystemInfo.DoubleClick += new System.EventHandler(this.gridView_SystemInfo_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Company";
            this.gridColumn1.FieldName = "Company";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.ToolTip = "Tên công ty";
            this.gridColumn1.Width = 106;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Host name";
            this.gridColumn2.FieldName = "HostName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.ToolTip = "Tên máy chủ";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "OS";
            this.gridColumn3.FieldName = "OS";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 253;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Orginal Install Date";
            this.gridColumn4.FieldName = "InstallDate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.ToolTip = "Thời điểm cài win";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 113;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "System Boot Time";
            this.gridColumn5.FieldName = "BootTime";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.ToolTip = "Thời điểm khởi động gần đây";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 104;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "System Type";
            this.gridColumn6.FieldName = "SystemType";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.ToolTip = "x86 or x64";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Time Zone";
            this.gridColumn7.FieldName = "TimeZone";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 76;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Total Memory";
            this.gridColumn8.FieldName = "TotalMemory";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Available Memory";
            this.gridColumn9.FieldName = "AvailableMemory";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "WAN IP";
            this.gridColumn10.FieldName = "WANIP";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 110;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "LAN IP";
            this.gridColumn11.FieldName = "LANIP";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            this.gridColumn11.Width = 110;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.groupControl1);
            this.panelControl3.Controls.Add(this.panelControl2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 78);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(671, 449);
            this.panelControl3.TabIndex = 3;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.groupControl3);
            this.panelControl2.Controls.Add(this.groupControl2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(2, 303);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(667, 144);
            this.panelControl2.TabIndex = 4;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.gridControl_DB);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(158, 2);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(507, 140);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Database";
            // 
            // gridControl_DB
            // 
            this.gridControl_DB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_DB.Location = new System.Drawing.Point(2, 20);
            this.gridControl_DB.MainView = this.gridView_DB;
            this.gridControl_DB.Name = "gridControl_DB";
            this.gridControl_DB.Size = new System.Drawing.Size(503, 118);
            this.gridControl_DB.TabIndex = 0;
            this.gridControl_DB.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_DB});
            // 
            // gridView_DB
            // 
            this.gridView_DB.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18});
            this.gridView_DB.GridControl = this.gridControl_DB;
            this.gridView_DB.Name = "gridView_DB";
            this.gridView_DB.OptionsView.ColumnAutoWidth = false;
            this.gridView_DB.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "DB";
            this.gridColumn14.FieldName = "DB";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.ReadOnly = true;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 0;
            this.gridColumn14.Width = 150;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "File Name";
            this.gridColumn15.FieldName = "FileLogicalName";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.ReadOnly = true;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 1;
            this.gridColumn15.Width = 170;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "File Name Path";
            this.gridColumn16.FieldName = "FilePhysicalName";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.ReadOnly = true;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 2;
            this.gridColumn16.Width = 240;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Used_MB";
            this.gridColumn17.FieldName = "Used_MB";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.ReadOnly = true;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 3;
            this.gridColumn17.Width = 70;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "File Group";
            this.gridColumn18.FieldName = "FileGroup";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.ReadOnly = true;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 4;
            this.gridColumn18.Width = 70;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControl_Disk);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl2.Location = new System.Drawing.Point(2, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(156, 140);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Disk";
            // 
            // gridControl_Disk
            // 
            this.gridControl_Disk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Disk.Location = new System.Drawing.Point(2, 20);
            this.gridControl_Disk.MainView = this.gridView_Disk;
            this.gridControl_Disk.Name = "gridControl_Disk";
            this.gridControl_Disk.Size = new System.Drawing.Size(152, 118);
            this.gridControl_Disk.TabIndex = 0;
            this.gridControl_Disk.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Disk});
            // 
            // gridView_Disk
            // 
            this.gridView_Disk.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12,
            this.gridColumn13});
            this.gridView_Disk.GridControl = this.gridControl_Disk;
            this.gridView_Disk.Name = "gridView_Disk";
            this.gridView_Disk.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Drive";
            this.gridColumn12.FieldName = "Drive";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 70;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn13.Caption = "GB Free";
            this.gridColumn13.DisplayFormat.FormatString = "###,##0.##";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn13.FieldName = "GB Free";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 1;
            this.gridColumn13.Width = 106;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.gridControl_RowCount);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl4.Location = new System.Drawing.Point(671, 78);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(374, 449);
            this.panelControl4.TabIndex = 0;
            this.panelControl4.Text = "Table Row Count";
            // 
            // gridControl_RowCount
            // 
            this.gridControl_RowCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_RowCount.Location = new System.Drawing.Point(2, 20);
            this.gridControl_RowCount.MainView = this.gridView_RowCount;
            this.gridControl_RowCount.Name = "gridControl_RowCount";
            this.gridControl_RowCount.Size = new System.Drawing.Size(370, 427);
            this.gridControl_RowCount.TabIndex = 1;
            this.gridControl_RowCount.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_RowCount});
            // 
            // gridView_RowCount
            // 
            this.gridView_RowCount.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn19,
            this.gridColumn20});
            this.gridView_RowCount.GridControl = this.gridControl_RowCount;
            this.gridView_RowCount.Name = "gridView_RowCount";
            this.gridView_RowCount.OptionsView.ColumnAutoWidth = false;
            this.gridView_RowCount.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Table Name";
            this.gridColumn19.FieldName = "TableName";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.ReadOnly = true;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 0;
            this.gridColumn19.Width = 247;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Total Row";
            this.gridColumn20.DisplayFormat.FormatString = "###,##0.##";
            this.gridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn20.FieldName = "TotalRow";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.OptionsColumn.ReadOnly = true;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 1;
            this.gridColumn20.Width = 74;
            // 
            // CompanyDatabaseManagement_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 527);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.panelTop);
            this.Name = "CompanyDatabaseManagement_Form";
            this.Text = "Server Information Management";
            this.Load += new System.EventHandler(this.CompanyDatabaseManagement_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_SystemInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_SystemInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Disk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Disk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_RowCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_RowCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl_SystemInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_SystemInfo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControl_Disk;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Disk;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl gridControl_DB;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_DB;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GroupControl panelControl4;
        private DevExpress.XtraGrid.GridControl gridControl_RowCount;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_RowCount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraEditors.SimpleButton btnShrinkDB;
        private DevExpress.XtraEditors.SimpleButton btnTruncate;
        private System.Windows.Forms.Label label1;
    }
}