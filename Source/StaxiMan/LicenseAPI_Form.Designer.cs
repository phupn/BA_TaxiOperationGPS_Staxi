namespace StaxiMan
{
    partial class LicenseAPI_Form
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
            this.gridData = new Taxi.Controls.Base.Controls.ShGridControl();
            this.gridViewCompany = new Taxi.Controls.Base.Controls.ShGridView();
            this.gridColumn3 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn1 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn2 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridCompany = new DevExpress.XtraEditors.GroupControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtAPICode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboCompany = new Taxi.Controls.Base.Common.License.InputLookUp_Company();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCompany)).BeginInit();
            this.gridCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAPICode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridData
            // 
            this.gridData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridData.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.gridData.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.gridData.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.gridData.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.gridData.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.gridData.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.gridData.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.gridData.Location = new System.Drawing.Point(0, 143);
            this.gridData.MainView = this.gridViewCompany;
            this.gridData.Name = "gridData";
            this.gridData.Size = new System.Drawing.Size(572, 255);
            this.gridData.TabIndex = 1;
            this.gridData.UseEmbeddedNavigator = true;
            this.gridData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCompany});
            // 
            // gridViewCompany
            // 
            this.gridViewCompany.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewCompany.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewCompany.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridViewCompany.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn2});
            this.gridViewCompany.GridControl = this.gridData;
            this.gridViewCompany.IndicatorWidth = 35;
            this.gridViewCompany.Name = "gridViewCompany";
            this.gridViewCompany.OptionsBehavior.Editable = false;
            this.gridViewCompany.OptionsView.ShowGroupPanel = false;
            this.gridViewCompany.DoubleClick += new System.EventHandler(this.gridViewCompany_DoubleClick);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Company Name";
            this.gridColumn3.FieldName = "FK_CompanyID";
            this.gridColumn3.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.TagLanguage = null;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "API Code";
            this.gridColumn1.FieldName = "APICode";
            this.gridColumn1.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.TagLanguage = null;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "API Key";
            this.gridColumn2.FieldName = "APIKey";
            this.gridColumn2.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.TagLanguage = null;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridCompany
            // 
            this.gridCompany.Controls.Add(this.btnDelete);
            this.gridCompany.Controls.Add(this.btnRefresh);
            this.gridCompany.Controls.Add(this.btnExit);
            this.gridCompany.Controls.Add(this.btnSave);
            this.gridCompany.Controls.Add(this.txtAPICode);
            this.gridCompany.Controls.Add(this.labelControl2);
            this.gridCompany.Controls.Add(this.labelControl1);
            this.gridCompany.Controls.Add(this.cboCompany);
            this.gridCompany.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridCompany.Location = new System.Drawing.Point(0, 0);
            this.gridCompany.Name = "gridCompany";
            this.gridCompany.Size = new System.Drawing.Size(572, 143);
            this.gridCompany.TabIndex = 2;
            this.gridCompany.Text = "License API Management";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(322, 112);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 24);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(403, 112);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 24);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(160, 112);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAPICode
            // 
            this.txtAPICode.Location = new System.Drawing.Point(82, 45);
            this.txtAPICode.Name = "txtAPICode";
            this.txtAPICode.Size = new System.Drawing.Size(234, 20);
            this.txtAPICode.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(26, 76);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Company:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(26, 45);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(49, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "API Code:";
            // 
            // cboCompany
            // 
            this.cboCompany.DefaultSelectFirstRow = false;
            this.cboCompany.IsChangeText = false;
            this.cboCompany.IsFocus = false;
            this.cboCompany.IsShowTextNull = true;
            this.cboCompany.Location = new System.Drawing.Point(81, 73);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCompany.Properties.NullText = "Chọn tên công ty";
            this.cboCompany.Size = new System.Drawing.Size(235, 20);
            this.cboCompany.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(241, 112);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 24);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // LicenseAPI_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 398);
            this.Controls.Add(this.gridData);
            this.Controls.Add(this.gridCompany);
            this.Name = "LicenseAPI_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License API Management";
            this.Load += new System.EventHandler(this.LicenseAPI_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCompany)).EndInit();
            this.gridCompany.ResumeLayout(false);
            this.gridCompany.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAPICode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.Base.Controls.ShGridControl gridData;
        private Taxi.Controls.Base.Controls.ShGridView gridViewCompany;
        private DevExpress.XtraEditors.GroupControl gridCompany;
        private Taxi.Controls.Base.Common.License.InputLookUp_Company cboCompany;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtAPICode;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn3;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn1;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn2;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
    }
}