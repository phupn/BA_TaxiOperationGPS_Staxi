namespace TaxiOperation_BanCo.Controls.Config
{
    partial class Control_Config_ColorOfStatus
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
            this.gridControl_ColorOfStatus = new DevExpress.XtraGrid.GridControl();
            this.gvColorOfStatus = new DevExpress.XtraGrid.Views.Grid.GridView();
            this._Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SttName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Value = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemColorPicker = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BgColor = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ColorOfStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvColorOfStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemColorPicker)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_ColorOfStatus
            // 
            this.gridControl_ColorOfStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_ColorOfStatus.Location = new System.Drawing.Point(0, 0);
            this.gridControl_ColorOfStatus.MainView = this.gvColorOfStatus;
            this.gridControl_ColorOfStatus.Name = "gridControl_ColorOfStatus";
            this.gridControl_ColorOfStatus.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemColorPicker});
            this.gridControl_ColorOfStatus.Size = new System.Drawing.Size(297, 305);
            this.gridControl_ColorOfStatus.TabIndex = 0;
            this.gridControl_ColorOfStatus.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvColorOfStatus});
            this.gridControl_ColorOfStatus.Load += new System.EventHandler(this.gridControl_ColorOfStatus_Load);
            // 
            // gvColorOfStatus
            // 
            this.gvColorOfStatus.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvColorOfStatus.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvColorOfStatus.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this._Id,
            this.SttName,
            this.Value,
            this.Description,
            this.BgColor});
            this.gvColorOfStatus.GridControl = this.gridControl_ColorOfStatus;
            this.gvColorOfStatus.IndicatorWidth = 20;
            this.gvColorOfStatus.Name = "gvColorOfStatus";
            this.gvColorOfStatus.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvColorOfStatus.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvColorOfStatus.OptionsView.ShowGroupPanel = false;
            this.gvColorOfStatus.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvColorOfStatus_CustomDrawRowIndicator);
            this.gvColorOfStatus.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvColorOfStatus_RowCellStyle);
            this.gvColorOfStatus.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gvColorOfStatus_RowUpdated);
            // 
            // _Id
            // 
            this._Id.Caption = "Id";
            this._Id.FieldName = "Id";
            this._Id.Name = "_Id";
            this._Id.OptionsFilter.AllowFilter = false;
            // 
            // SttName
            // 
            this.SttName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SttName.AppearanceCell.Options.UseFont = true;
            this.SttName.Caption = "Trạng thái";
            this.SttName.FieldName = "StatusName";
            this.SttName.Name = "SttName";
            this.SttName.OptionsFilter.AllowFilter = false;
            this.SttName.Visible = true;
            this.SttName.VisibleIndex = 0;
            this.SttName.Width = 70;
            // 
            // Value
            // 
            this.Value.Caption = "Màu sắc";
            this.Value.ColumnEdit = this.ItemColorPicker;
            this.Value.FieldName = "Color";
            this.Value.Name = "Value";
            this.Value.OptionsFilter.AllowFilter = false;
            this.Value.Visible = true;
            this.Value.VisibleIndex = 1;
            this.Value.Width = 80;
            // 
            // ItemColorPicker
            // 
            this.ItemColorPicker.AutoHeight = false;
            this.ItemColorPicker.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemColorPicker.Name = "ItemColorPicker";
            this.ItemColorPicker.ShowCustomColors = false;
            this.ItemColorPicker.ShowSystemColors = false;
            this.ItemColorPicker.StoreColorAsInteger = true;
            // 
            // Description
            // 
            this.Description.Caption = "Mô tả";
            this.Description.FieldName = "Description";
            this.Description.Name = "Description";
            this.Description.OptionsFilter.AllowFilter = false;
            this.Description.Visible = true;
            this.Description.VisibleIndex = 3;
            this.Description.Width = 120;
            // 
            // BgColor
            // 
            this.BgColor.Caption = "Màu nền";
            this.BgColor.ColumnEdit = this.ItemColorPicker;
            this.BgColor.FieldName = "BackColor";
            this.BgColor.Name = "BgColor";
            this.BgColor.OptionsFilter.AllowFilter = false;
            this.BgColor.Visible = true;
            this.BgColor.VisibleIndex = 2;
            // 
            // Control_Config_ColorOfStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl_ColorOfStatus);
            this.Name = "Control_Config_ColorOfStatus";
            this.Size = new System.Drawing.Size(297, 305);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ColorOfStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvColorOfStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemColorPicker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_ColorOfStatus;
        private DevExpress.XtraGrid.Views.Grid.GridView gvColorOfStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit ItemColorPicker;
        private DevExpress.XtraGrid.Columns.GridColumn Description;
        private DevExpress.XtraGrid.Columns.GridColumn SttName;
        private DevExpress.XtraGrid.Columns.GridColumn Value;
        private DevExpress.XtraGrid.Columns.GridColumn _Id;
        private DevExpress.XtraGrid.Columns.GridColumn BgColor;
    }
}
