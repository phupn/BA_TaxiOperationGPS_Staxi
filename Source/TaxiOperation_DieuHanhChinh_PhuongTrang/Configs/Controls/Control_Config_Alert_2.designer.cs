namespace TaxiOperation_BanCo.Controls.Config
{
    partial class Control_Config_Alert_2
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.grcAlert = new DevExpress.XtraGrid.GridControl();
            this.grvAlert = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ConfigName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Value = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Notify = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DateCreated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mainCTMN = new System.Windows.Forms.ContextMenu();
            this.miXoa = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grcAlert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAlert)).BeginInit();
            this.SuspendLayout();
            // 
            // grcAlert
            // 
            this.grcAlert.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcAlert.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcAlert.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcAlert.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcAlert.EmbeddedNavigator.Buttons.First.Hint = "Dòng đầu tiên";
            this.grcAlert.EmbeddedNavigator.Buttons.Last.Hint = "Dòng cuối cùng";
            this.grcAlert.EmbeddedNavigator.Buttons.Next.Hint = "Dòng tiếp theo";
            this.grcAlert.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp theo";
            this.grcAlert.EmbeddedNavigator.Buttons.Prev.Hint = "Dòng trước";
            this.grcAlert.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.grcAlert.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcAlert.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0} / {1}";
            gridLevelNode1.RelationName = "Level1";
            this.grcAlert.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grcAlert.Location = new System.Drawing.Point(0, 0);
            this.grcAlert.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.grcAlert.MainView = this.grvAlert;
            this.grcAlert.Name = "grcAlert";
            this.grcAlert.Size = new System.Drawing.Size(513, 325);
            this.grcAlert.TabIndex = 0;
            this.grcAlert.UseEmbeddedNavigator = true;
            this.grcAlert.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAlert});
            // 
            // grvAlert
            // 
            this.grvAlert.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ConfigName,
            this.Value,
            this.Notify,
            this.DateCreated,
            this.Description,
            this.Type});
            this.grvAlert.GridControl = this.grcAlert;
            this.grvAlert.Name = "grvAlert";
            this.grvAlert.NewItemRowText = "Bấm vào đây để thêm cấu hình cảnh báo mới";
            this.grvAlert.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvAlert.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvAlert.OptionsSelection.MultiSelect = true;
            this.grvAlert.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grvAlert.OptionsView.ShowGroupPanel = false;
            this.grvAlert.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.grvAlert_RowUpdated);
            // 
            // ConfigName
            // 
            this.ConfigName.Caption = "Tên cấu hình";
            this.ConfigName.FieldName = "Name";
            this.ConfigName.Name = "ConfigName";
            this.ConfigName.OptionsColumn.FixedWidth = true;
            this.ConfigName.OptionsFilter.AllowFilter = false;
            this.ConfigName.Visible = true;
            this.ConfigName.VisibleIndex = 0;
            this.ConfigName.Width = 150;
            // 
            // Value
            // 
            this.Value.Caption = "Giá trị";
            this.Value.FieldName = "Value";
            this.Value.Name = "Value";
            this.Value.OptionsColumn.FixedWidth = true;
            this.Value.OptionsFilter.AllowFilter = false;
            this.Value.Visible = true;
            this.Value.VisibleIndex = 1;
            this.Value.Width = 60;
            // 
            // Notify
            // 
            this.Notify.Caption = "Hiển thị";
            this.Notify.FieldName = "Notify";
            this.Notify.Name = "Notify";
            this.Notify.OptionsColumn.FixedWidth = true;
            this.Notify.OptionsFilter.AllowFilter = false;
            this.Notify.Visible = true;
            this.Notify.VisibleIndex = 2;
            this.Notify.Width = 60;
            // 
            // DateCreated
            // 
            this.DateCreated.Caption = "Thời gian";
            this.DateCreated.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.DateCreated.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateCreated.FieldName = "DateCreated";
            this.DateCreated.Name = "DateCreated";
            this.DateCreated.OptionsColumn.FixedWidth = true;
            this.DateCreated.OptionsFilter.AllowFilter = false;
            this.DateCreated.Visible = true;
            this.DateCreated.VisibleIndex = 3;
            this.DateCreated.Width = 100;
            // 
            // Description
            // 
            this.Description.Caption = "Ghi chú";
            this.Description.FieldName = "Description";
            this.Description.Name = "Description";
            this.Description.OptionsColumn.FixedWidth = true;
            this.Description.OptionsFilter.AllowFilter = false;
            this.Description.Visible = true;
            this.Description.VisibleIndex = 4;
            this.Description.Width = 125;
            // 
            // Type
            // 
            this.Type.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.Type.AppearanceCell.BackColor2 = System.Drawing.Color.White;
            this.Type.AppearanceCell.BorderColor = System.Drawing.Color.DarkBlue;
            this.Type.AppearanceCell.Options.UseBackColor = true;
            this.Type.AppearanceCell.Options.UseBorderColor = true;
            this.Type.Caption = "Loại xe";
            this.Type.FieldName = "Type";
            this.Type.Name = "Type";
            this.Type.Visible = true;
            this.Type.VisibleIndex = 5;
            // 
            // mainCTMN
            // 
            this.mainCTMN.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miXoa});
            // 
            // miXoa
            // 
            this.miXoa.Index = 0;
            this.miXoa.Text = "Xoá";
            this.miXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // Control_Config_Alert_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcAlert);
            this.Name = "Control_Config_Alert_2";
            this.Size = new System.Drawing.Size(513, 325);
            this.Load += new System.EventHandler(this.ControlConfigAlert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grcAlert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAlert)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcAlert;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAlert;
        private DevExpress.XtraGrid.Columns.GridColumn Value;
        private DevExpress.XtraGrid.Columns.GridColumn Notify;
        private DevExpress.XtraGrid.Columns.GridColumn DateCreated;
        private DevExpress.XtraGrid.Columns.GridColumn Description;
        private DevExpress.XtraGrid.Columns.GridColumn ConfigName;
        private System.Windows.Forms.ContextMenu mainCTMN;
        private System.Windows.Forms.MenuItem miXoa;
        private DevExpress.XtraGrid.Columns.GridColumn Type;
    }
}
