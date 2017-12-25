namespace StaxiMan
{
    partial class Company_Form
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_Origin = new DevExpress.XtraGrid.GridControl();
            this.gridView_Origin = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnXNCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnDeployDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column5Hotline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Origin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Origin)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(777, 76);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(253, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(273, 33);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Company Management";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 57);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(207, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Use \"Del\" key to delete records in gridview!";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridControl_Origin);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 76);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(777, 376);
            this.panelControl2.TabIndex = 1;
            // 
            // gridControl_Origin
            // 
            this.gridControl_Origin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Origin.Location = new System.Drawing.Point(2, 2);
            this.gridControl_Origin.MainView = this.gridView_Origin;
            this.gridControl_Origin.Name = "gridControl_Origin";
            this.gridControl_Origin.Size = new System.Drawing.Size(773, 372);
            this.gridControl_Origin.TabIndex = 2;
            this.gridControl_Origin.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Origin});
            // 
            // gridView_Origin
            // 
            this.gridView_Origin.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.ColumnXNCode,
            this.gridColumn9,
            this.ColumnName,
            this.ColumnDeployDate,
            this.Column5Hotline,
            this.ColumnCreatedDate,
            this.ColumnUpdatedDate});
            this.gridView_Origin.GridControl = this.gridControl_Origin;
            this.gridView_Origin.IndicatorWidth = 30;
            this.gridView_Origin.LevelIndent = 1;
            this.gridView_Origin.Name = "gridView_Origin";
            this.gridView_Origin.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Origin.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Origin.OptionsDetail.ShowEmbeddedDetailIndent = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Origin.OptionsView.ColumnAutoWidth = false;
            this.gridView_Origin.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView_Origin.OptionsView.ShowGroupPanel = false;
            this.gridView_Origin.RowDeleting += new DevExpress.Data.RowDeletingEventHandler(this.gridView_Origin_RowDeleting);
            this.gridView_Origin.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView_Origin_RowUpdated);
            this.gridView_Origin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_Origin_KeyDown);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Width = 43;
            // 
            // ColumnXNCode
            // 
            this.ColumnXNCode.Caption = "XN Code";
            this.ColumnXNCode.FieldName = "XNCode";
            this.ColumnXNCode.Name = "ColumnXNCode";
            this.ColumnXNCode.Visible = true;
            this.ColumnXNCode.VisibleIndex = 1;
            this.ColumnXNCode.Width = 64;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Company ID";
            this.gridColumn9.FieldName = "CompanyId";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // ColumnName
            // 
            this.ColumnName.Caption = "Name";
            this.ColumnName.FieldName = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Visible = true;
            this.ColumnName.VisibleIndex = 0;
            this.ColumnName.Width = 193;
            // 
            // ColumnDeployDate
            // 
            this.ColumnDeployDate.Caption = "Deploy Date";
            this.ColumnDeployDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.ColumnDeployDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.ColumnDeployDate.FieldName = "DeployDate";
            this.ColumnDeployDate.Name = "ColumnDeployDate";
            this.ColumnDeployDate.Visible = true;
            this.ColumnDeployDate.VisibleIndex = 3;
            this.ColumnDeployDate.Width = 107;
            // 
            // Column5Hotline
            // 
            this.Column5Hotline.Caption = "Hotline";
            this.Column5Hotline.FieldName = "Hotline";
            this.Column5Hotline.Name = "Column5Hotline";
            this.Column5Hotline.Visible = true;
            this.Column5Hotline.VisibleIndex = 2;
            this.Column5Hotline.Width = 88;
            // 
            // ColumnCreatedDate
            // 
            this.ColumnCreatedDate.Caption = "Created Date";
            this.ColumnCreatedDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.ColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.ColumnCreatedDate.FieldName = "CreatedDate";
            this.ColumnCreatedDate.Name = "ColumnCreatedDate";
            this.ColumnCreatedDate.OptionsColumn.AllowEdit = false;
            this.ColumnCreatedDate.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.ColumnCreatedDate.Visible = true;
            this.ColumnCreatedDate.VisibleIndex = 4;
            this.ColumnCreatedDate.Width = 101;
            // 
            // ColumnUpdatedDate
            // 
            this.ColumnUpdatedDate.Caption = "Updated Date";
            this.ColumnUpdatedDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.ColumnUpdatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.ColumnUpdatedDate.FieldName = "UpdatedDate";
            this.ColumnUpdatedDate.Name = "ColumnUpdatedDate";
            this.ColumnUpdatedDate.OptionsColumn.AllowEdit = false;
            this.ColumnUpdatedDate.Visible = true;
            this.ColumnUpdatedDate.VisibleIndex = 5;
            this.ColumnUpdatedDate.Width = 108;
            // 
            // Company_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 452);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "Company_Form";
            this.Text = "Company Management";
            this.Load += new System.EventHandler(this.Company_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Origin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Origin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControl_Origin;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView_Origin;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnXNCode;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnDeployDate;
        private DevExpress.XtraGrid.Columns.GridColumn Column5Hotline;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnUpdatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}