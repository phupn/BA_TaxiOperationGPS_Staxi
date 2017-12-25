namespace TaxiOperation_BanCo.Config
{
    partial class frmConfigDHBanCo_AddStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigDHBanCo_AddStatus));
            this.gridControl_ColorOfStatus1 = new DevExpress.XtraGrid.GridControl();
            this.gvColorOfStatus = new DevExpress.XtraGrid.Views.Grid.GridView();
            this._Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ConfigName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pkColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemColorPicker = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlInput = new DevExpress.XtraEditors.PanelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.pnlGrid = new DevExpress.XtraEditors.PanelControl();
            this.control_Config_ColorOfStatus1 = new TaxiOperation_BanCo.Controls.Config.Control_Config_ColorOfStatus();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ColorOfStatus1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvColorOfStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemColorPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInput)).BeginInit();
            this.pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl_ColorOfStatus1
            // 
            this.gridControl_ColorOfStatus1.Location = new System.Drawing.Point(2, 254);
            this.gridControl_ColorOfStatus1.MainView = this.gvColorOfStatus;
            this.gridControl_ColorOfStatus1.Name = "gridControl_ColorOfStatus1";
            this.gridControl_ColorOfStatus1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemColorPicker});
            this.gridControl_ColorOfStatus1.Size = new System.Drawing.Size(504, 117);
            this.gridControl_ColorOfStatus1.TabIndex = 1;
            this.gridControl_ColorOfStatus1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvColorOfStatus});
            this.gridControl_ColorOfStatus1.Visible = false;
            // 
            // gvColorOfStatus
            // 
            this.gvColorOfStatus.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvColorOfStatus.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvColorOfStatus.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this._Id,
            this.ConfigName,
            this.pkColor,
            this.Description});
            this.gvColorOfStatus.GridControl = this.gridControl_ColorOfStatus1;
            this.gvColorOfStatus.Name = "gvColorOfStatus";
            this.gvColorOfStatus.NewItemRowText = "Bấm vào đây để thêm mới dữ liệu";
            this.gvColorOfStatus.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvColorOfStatus.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvColorOfStatus.OptionsView.ShowGroupPanel = false;
            this.gvColorOfStatus.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gvColorOfStatus_SelectionChanged);
            this.gvColorOfStatus.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvColorOfStatus_InitNewRow);
            this.gvColorOfStatus.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvColorOfStatus_CellValueChanged);
            this.gvColorOfStatus.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvColorOfStatus_CellValueChanging);
            this.gvColorOfStatus.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gvColorOfStatus_RowUpdated);
            this.gvColorOfStatus.Layout += new System.EventHandler(this.gvColorOfStatus_Layout);
            // 
            // _Id
            // 
            this._Id.Caption = "Id";
            this._Id.FieldName = "Id";
            this._Id.Name = "_Id";
            // 
            // ConfigName
            // 
            this.ConfigName.Caption = "Trạng thái";
            this.ConfigName.FieldName = "StatusName";
            this.ConfigName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.ConfigName.Name = "ConfigName";
            this.ConfigName.Visible = true;
            this.ConfigName.VisibleIndex = 0;
            this.ConfigName.Width = 80;
            // 
            // pkColor
            // 
            this.pkColor.Caption = "Màu sắc";
            this.pkColor.ColumnEdit = this.ItemColorPicker;
            this.pkColor.FieldName = "Color";
            this.pkColor.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.pkColor.Name = "pkColor";
            this.pkColor.Visible = true;
            this.pkColor.VisibleIndex = 1;
            this.pkColor.Width = 90;
            // 
            // ItemColorPicker
            // 
            this.ItemColorPicker.AutoHeight = false;
            this.ItemColorPicker.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemColorPicker.Name = "ItemColorPicker";
            this.ItemColorPicker.ShowCustomColors = false;
            this.ItemColorPicker.ShowSystemColors = false;
            // 
            // Description
            // 
            this.Description.Caption = "Mô tả";
            this.Description.FieldName = "Description";
            this.Description.Name = "Description";
            this.Description.Visible = true;
            this.Description.VisibleIndex = 2;
            this.Description.Width = 318;
            // 
            // pnlInput
            // 
            this.pnlInput.Controls.Add(this.textEdit1);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInput.Location = new System.Drawing.Point(0, 0);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(508, 43);
            this.pnlInput.TabIndex = 3;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(12, 5);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(100, 20);
            this.textEdit1.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.control_Config_ColorOfStatus1);
            this.pnlGrid.Controls.Add(this.gridControl_ColorOfStatus1);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 43);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(508, 373);
            this.pnlGrid.TabIndex = 4;
            // 
            // control_Config_ColorOfStatus1
            // 
            this.control_Config_ColorOfStatus1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.control_Config_ColorOfStatus1.Location = new System.Drawing.Point(2, 2);
            this.control_Config_ColorOfStatus1.Name = "control_Config_ColorOfStatus1";
            this.control_Config_ColorOfStatus1.Size = new System.Drawing.Size(504, 369);
            this.control_Config_ColorOfStatus1.TabIndex = 2;
            // 
            // frmConfigDHBanCo_AddStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 416);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfigDHBanCo_AddStatus";
            this.Text = "Thêm trạng thái màu của xe";
            this.Load += new System.EventHandler(this.frmConfigDHBanCo_AddStatus_Load);
            this.Controls.SetChildIndex(this.pnlInput, 0);
            this.Controls.SetChildIndex(this.pnlGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ColorOfStatus1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvColorOfStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemColorPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInput)).EndInit();
            this.pnlInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_ColorOfStatus1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvColorOfStatus;
        private DevExpress.XtraGrid.Columns.GridColumn pkColor;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit ItemColorPicker;
        private DevExpress.XtraGrid.Columns.GridColumn Description;
        private DevExpress.XtraEditors.PanelControl pnlInput;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.PanelControl pnlGrid;
        private DevExpress.XtraGrid.Columns.GridColumn _Id;
        private DevExpress.XtraGrid.Columns.GridColumn ConfigName;
        private Controls.Config.Control_Config_ColorOfStatus control_Config_ColorOfStatus1;
    }
}