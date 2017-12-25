namespace StaxiMan
{
    partial class CompanyLicense_Form
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FK_CompanyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.lblCpuId = new DevExpress.XtraEditors.LabelControl();
            this.lblMacAddress = new DevExpress.XtraEditors.LabelControl();
            this.lblPhone = new DevExpress.XtraEditors.LabelControl();
            this.lblCompanyName = new DevExpress.XtraEditors.LabelControl();
            this.txtNote = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblMsg = new DevExpress.XtraEditors.LabelControl();
            this.groupBuildLicense = new DevExpress.XtraEditors.GroupControl();
            this.inputLookUp_Company = new Taxi.Controls.Base.Common.License.InputLookUp_Company();
            this.date_ExpDate = new DevExpress.XtraEditors.DateEdit();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            this.btnActive = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnBuildLicense = new DevExpress.XtraEditors.SimpleButton();
            this.txtLicenseCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtAPIKey = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtLicenseKey = new DevExpress.XtraEditors.TextEdit();
            this.txtAPICode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBuildLicense)).BeginInit();
            this.groupBuildLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputLookUp_Company.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_ExpDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_ExpDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLicenseCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAPIKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLicenseKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAPICode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridControl);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 196);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(988, 297);
            this.panelControl2.TabIndex = 2;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(2, 2);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(984, 293);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.FK_CompanyID,
            this.gridColumn10,
            this.gridColumn11});
            this.gridView.GridControl = this.gridControl;
            this.gridView.IndicatorWidth = 30;
            this.gridView.LevelIndent = 1;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsDetail.ShowEmbeddedDetailIndent = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn11, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView_RowClick);
            this.gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 43;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "License Code";
            this.gridColumn2.FieldName = "LicenseCode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 141;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "License Key";
            this.gridColumn3.FieldName = "LicenseKey";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 99;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Taxi API Code";
            this.gridColumn4.FieldName = "LicenseTaxiAPI_Code";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 136;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "License Taxi API Key";
            this.gridColumn5.FieldName = "LicenseTaxiAPI";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 138;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Active";
            this.gridColumn6.FieldName = "IsActive";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 39;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Note";
            this.gridColumn7.FieldName = "Notes";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 118;
            // 
            // FK_CompanyID
            // 
            this.FK_CompanyID.Caption = "Company";
            this.FK_CompanyID.FieldName = "FK_CompanyID";
            this.FK_CompanyID.Name = "FK_CompanyID";
            this.FK_CompanyID.Visible = true;
            this.FK_CompanyID.VisibleIndex = 9;
            this.FK_CompanyID.Width = 118;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Create Date";
            this.gridColumn10.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn10.FieldName = "CreateDate";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 7;
            this.gridColumn10.Width = 86;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Exp Date";
            this.gridColumn11.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn11.FieldName = "ExpDate";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 8;
            this.gridColumn11.Width = 85;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.groupBuildLicense);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(988, 196);
            this.panelControl1.TabIndex = 3;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.lblCpuId);
            this.panelControl3.Controls.Add(this.lblMacAddress);
            this.panelControl3.Controls.Add(this.lblPhone);
            this.panelControl3.Controls.Add(this.lblCompanyName);
            this.panelControl3.Controls.Add(this.txtNote);
            this.panelControl3.Controls.Add(this.labelControl6);
            this.panelControl3.Controls.Add(this.lblMsg);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(394, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(592, 192);
            this.panelControl3.TabIndex = 2;
            // 
            // lblCpuId
            // 
            this.lblCpuId.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCpuId.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblCpuId.Appearance.Options.UseFont = true;
            this.lblCpuId.Appearance.Options.UseForeColor = true;
            this.lblCpuId.Location = new System.Drawing.Point(5, 66);
            this.lblCpuId.Name = "lblCpuId";
            this.lblCpuId.Size = new System.Drawing.Size(42, 14);
            this.lblCpuId.TabIndex = 2;
            this.lblCpuId.Text = "CPU ID";
            // 
            // lblMacAddress
            // 
            this.lblMacAddress.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMacAddress.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblMacAddress.Appearance.Options.UseFont = true;
            this.lblMacAddress.Appearance.Options.UseForeColor = true;
            this.lblMacAddress.Location = new System.Drawing.Point(6, 46);
            this.lblMacAddress.Name = "lblMacAddress";
            this.lblMacAddress.Size = new System.Drawing.Size(77, 14);
            this.lblMacAddress.TabIndex = 2;
            this.lblMacAddress.Text = "Mac Address";
            // 
            // lblPhone
            // 
            this.lblPhone.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblPhone.Appearance.Options.UseFont = true;
            this.lblPhone.Appearance.Options.UseForeColor = true;
            this.lblPhone.Location = new System.Drawing.Point(6, 26);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(90, 14);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Phone Number";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblCompanyName.Appearance.Options.UseFont = true;
            this.lblCompanyName.Appearance.Options.UseForeColor = true;
            this.lblCompanyName.Location = new System.Drawing.Point(6, 5);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(94, 14);
            this.lblCompanyName.TabIndex = 2;
            this.lblCompanyName.Text = "Company Name";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(63, 104);
            this.txtNote.Name = "txtNote";
            this.txtNote.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Properties.Appearance.Options.UseFont = true;
            this.txtNote.Size = new System.Drawing.Size(495, 22);
            this.txtNote.TabIndex = 4;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(8, 107);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(23, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Note";
            // 
            // lblMsg
            // 
            this.lblMsg.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Appearance.Options.UseFont = true;
            this.lblMsg.Appearance.Options.UseForeColor = true;
            this.lblMsg.Location = new System.Drawing.Point(8, 168);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 13);
            this.lblMsg.TabIndex = 1;
            // 
            // groupBuildLicense
            // 
            this.groupBuildLicense.Controls.Add(this.inputLookUp_Company);
            this.groupBuildLicense.Controls.Add(this.date_ExpDate);
            this.groupBuildLicense.Controls.Add(this.btnCopy);
            this.groupBuildLicense.Controls.Add(this.btnActive);
            this.groupBuildLicense.Controls.Add(this.btnSave);
            this.groupBuildLicense.Controls.Add(this.btnBuildLicense);
            this.groupBuildLicense.Controls.Add(this.txtLicenseCode);
            this.groupBuildLicense.Controls.Add(this.labelControl3);
            this.groupBuildLicense.Controls.Add(this.txtAPIKey);
            this.groupBuildLicense.Controls.Add(this.labelControl4);
            this.groupBuildLicense.Controls.Add(this.txtLicenseKey);
            this.groupBuildLicense.Controls.Add(this.txtAPICode);
            this.groupBuildLicense.Controls.Add(this.labelControl2);
            this.groupBuildLicense.Controls.Add(this.labelControl1);
            this.groupBuildLicense.Controls.Add(this.labelControl5);
            this.groupBuildLicense.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBuildLicense.Location = new System.Drawing.Point(2, 2);
            this.groupBuildLicense.Name = "groupBuildLicense";
            this.groupBuildLicense.Size = new System.Drawing.Size(392, 192);
            this.groupBuildLicense.TabIndex = 4;
            this.groupBuildLicense.Text = "Build License";
            // 
            // inputLookUp_Company
            // 
            this.inputLookUp_Company.DefaultSelectFirstRow = false;
            this.inputLookUp_Company.Enabled = false;
            this.inputLookUp_Company.IsChangeText = false;
            this.inputLookUp_Company.IsFocus = false;
            this.inputLookUp_Company.IsShowTextNull = true;
            this.inputLookUp_Company.Location = new System.Drawing.Point(181, 20);
            this.inputLookUp_Company.Name = "inputLookUp_Company";
            this.inputLookUp_Company.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.inputLookUp_Company.Properties.NullText = "";
            this.inputLookUp_Company.Size = new System.Drawing.Size(181, 20);
            this.inputLookUp_Company.TabIndex = 8;
            // 
            // date_ExpDate
            // 
            this.date_ExpDate.EditValue = null;
            this.date_ExpDate.Location = new System.Drawing.Point(62, 20);
            this.date_ExpDate.Name = "date_ExpDate";
            this.date_ExpDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.date_ExpDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_ExpDate.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.False;
            this.date_ExpDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_ExpDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.date_ExpDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.date_ExpDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.date_ExpDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.date_ExpDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.date_ExpDate.Size = new System.Drawing.Size(113, 20);
            this.date_ExpDate.TabIndex = 0;
            this.date_ExpDate.ToolTip = "Ngày còn hiệu lực";
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.Location = new System.Drawing.Point(224, 163);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(47, 23);
            this.btnCopy.TabIndex = 7;
            this.btnCopy.Text = "Copy";
            this.btnCopy.ToolTip = "Copy License trên giao diện";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnActive
            // 
            this.btnActive.Enabled = false;
            this.btnActive.Location = new System.Drawing.Point(143, 163);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(75, 23);
            this.btnActive.TabIndex = 6;
            this.btnActive.Text = "Deactive";
            this.btnActive.ToolTip = "Xóa thông tin trên form nhập";
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(62, 163);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.ToolTip = "Lưu thông tin License, Sử dụng license này cho hãng";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBuildLicense
            // 
            this.btnBuildLicense.Enabled = false;
            this.btnBuildLicense.Location = new System.Drawing.Point(286, 45);
            this.btnBuildLicense.Name = "btnBuildLicense";
            this.btnBuildLicense.Size = new System.Drawing.Size(75, 23);
            this.btnBuildLicense.TabIndex = 3;
            this.btnBuildLicense.Text = "Rebuild";
            this.btnBuildLicense.ToolTip = "Tạo license cho Hãng";
            this.btnBuildLicense.Click += new System.EventHandler(this.btnBuildLicense_Click);
            // 
            // txtLicenseCode
            // 
            this.txtLicenseCode.Location = new System.Drawing.Point(62, 74);
            this.txtLicenseCode.Name = "txtLicenseCode";
            this.txtLicenseCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicenseCode.Properties.Appearance.Options.UseFont = true;
            this.txtLicenseCode.Properties.ReadOnly = true;
            this.txtLicenseCode.Size = new System.Drawing.Size(304, 22);
            this.txtLicenseCode.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(7, 82);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(25, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Code";
            // 
            // txtAPIKey
            // 
            this.txtAPIKey.Location = new System.Drawing.Point(62, 135);
            this.txtAPIKey.Name = "txtAPIKey";
            this.txtAPIKey.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAPIKey.Properties.Appearance.Options.UseFont = true;
            this.txtAPIKey.Properties.ReadOnly = true;
            this.txtAPIKey.Size = new System.Drawing.Size(304, 22);
            this.txtAPIKey.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(7, 107);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(18, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Key";
            // 
            // txtLicenseKey
            // 
            this.txtLicenseKey.Location = new System.Drawing.Point(62, 104);
            this.txtLicenseKey.Name = "txtLicenseKey";
            this.txtLicenseKey.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicenseKey.Properties.Appearance.Options.UseFont = true;
            this.txtLicenseKey.Properties.ReadOnly = true;
            this.txtLicenseKey.Size = new System.Drawing.Size(304, 22);
            this.txtLicenseKey.TabIndex = 5;
            // 
            // txtAPICode
            // 
            this.txtAPICode.Location = new System.Drawing.Point(62, 46);
            this.txtAPICode.Name = "txtAPICode";
            this.txtAPICode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAPICode.Properties.Appearance.Options.UseFont = true;
            this.txtAPICode.Size = new System.Drawing.Size(218, 22);
            this.txtAPICode.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(7, 138);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "API Key";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 49);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "API code";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(7, 23);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(45, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Exp.Date";
            this.labelControl5.ToolTip = "Expiry date";
            // 
            // CompanyLicense_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 493);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "CompanyLicense_Form";
            this.Text = "License";
            this.Load += new System.EventHandler(this.CompanyLicense_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBuildLicense)).EndInit();
            this.groupBuildLicense.ResumeLayout(false);
            this.groupBuildLicense.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputLookUp_Company.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_ExpDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_ExpDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLicenseCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAPIKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLicenseKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAPICode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControl;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn FK_CompanyID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.GroupControl groupBuildLicense;
        private Taxi.Controls.Base.Common.License.InputLookUp_Company inputLookUp_Company;
        private DevExpress.XtraEditors.DateEdit date_ExpDate;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
        private DevExpress.XtraEditors.SimpleButton btnActive;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnBuildLicense;
        private DevExpress.XtraEditors.TextEdit txtLicenseCode;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtAPIKey;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lblMsg;
        private DevExpress.XtraEditors.TextEdit txtLicenseKey;
        private DevExpress.XtraEditors.TextEdit txtNote;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtAPICode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl lblPhone;
        private DevExpress.XtraEditors.LabelControl lblCompanyName;
        private DevExpress.XtraEditors.LabelControl lblCpuId;
        private DevExpress.XtraEditors.LabelControl lblMacAddress;
    }
}