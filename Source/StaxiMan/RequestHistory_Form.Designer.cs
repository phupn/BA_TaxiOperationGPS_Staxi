namespace StaxiMan
{
    partial class RequestHistory_Form
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
            this.gridColumn1 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn2 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn3 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn4 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn5 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn6 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn7 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn8 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn9 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn10 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridCompany = new DevExpress.XtraEditors.GroupControl();
            this.txtCompanyName = new DevExpress.XtraEditors.TextEdit();
            this.txtPhoneNumber = new DevExpress.XtraEditors.TextEdit();
            this.toDate = new DevExpress.XtraEditors.DateEdit();
            this.fromDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCompany)).BeginInit();
            this.gridCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate.Properties)).BeginInit();
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
            this.gridData.Size = new System.Drawing.Size(682, 236);
            this.gridData.TabIndex = 3;
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
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.gridViewCompany.GridControl = this.gridData;
            this.gridViewCompany.IndicatorWidth = 35;
            this.gridViewCompany.Name = "gridViewCompany";
            this.gridViewCompany.OptionsBehavior.Editable = false;
            this.gridViewCompany.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.TagLanguage = null;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mac Address";
            this.gridColumn2.FieldName = "MacAddress";
            this.gridColumn2.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.TagLanguage = null;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 67;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "CPUID";
            this.gridColumn3.FieldName = "CPUID";
            this.gridColumn3.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.TagLanguage = null;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 60;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Phone Number";
            this.gridColumn4.FieldName = "PhoneNumber";
            this.gridColumn4.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.TagLanguage = null;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 94;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Company Name";
            this.gridColumn5.FieldName = "CompName";
            this.gridColumn5.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.TagLanguage = null;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 124;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "User Name";
            this.gridColumn6.FieldName = "UserName";
            this.gridColumn6.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.TagLanguage = null;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 79;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "PassWord";
            this.gridColumn7.FieldName = "PassWord";
            this.gridColumn7.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.TagLanguage = null;
            this.gridColumn7.Width = 61;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Request Date";
            this.gridColumn8.FieldName = "RequestDate";
            this.gridColumn8.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.TagLanguage = null;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 109;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Responsed";
            this.gridColumn9.FieldName = "Responsed";
            this.gridColumn9.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.TagLanguage = null;
            this.gridColumn9.Width = 97;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Responsed Date";
            this.gridColumn10.FieldName = "ResponsedDate";
            this.gridColumn10.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.TagLanguage = null;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 6;
            this.gridColumn10.Width = 112;
            // 
            // gridCompany
            // 
            this.gridCompany.Controls.Add(this.txtCompanyName);
            this.gridCompany.Controls.Add(this.txtPhoneNumber);
            this.gridCompany.Controls.Add(this.toDate);
            this.gridCompany.Controls.Add(this.fromDate);
            this.gridCompany.Controls.Add(this.labelControl5);
            this.gridCompany.Controls.Add(this.labelControl6);
            this.gridCompany.Controls.Add(this.labelControl3);
            this.gridCompany.Controls.Add(this.labelControl2);
            this.gridCompany.Controls.Add(this.btnExit);
            this.gridCompany.Controls.Add(this.btnSearch);
            this.gridCompany.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridCompany.Location = new System.Drawing.Point(0, 0);
            this.gridCompany.Name = "gridCompany";
            this.gridCompany.Size = new System.Drawing.Size(682, 143);
            this.gridCompany.TabIndex = 4;
            this.gridCompany.Text = "Request History";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(109, 77);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(148, 20);
            this.txtCompanyName.TabIndex = 4;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(108, 51);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(148, 20);
            this.txtPhoneNumber.TabIndex = 3;
            // 
            // toDate
            // 
            this.toDate.EditValue = null;
            this.toDate.Location = new System.Drawing.Point(316, 23);
            this.toDate.Name = "toDate";
            this.toDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.toDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.toDate.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.False;
            this.toDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.toDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.toDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.toDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.toDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.toDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.toDate.Size = new System.Drawing.Size(134, 20);
            this.toDate.TabIndex = 2;
            this.toDate.ToolTip = "Ngày còn hiệu lực";
            // 
            // fromDate
            // 
            this.fromDate.EditValue = null;
            this.fromDate.Location = new System.Drawing.Point(107, 23);
            this.fromDate.Name = "fromDate";
            this.fromDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.fromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fromDate.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.False;
            this.fromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.fromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.fromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.fromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.fromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.fromDate.Size = new System.Drawing.Size(149, 20);
            this.fromDate.TabIndex = 1;
            this.fromDate.ToolTip = "Ngày còn hiệu lực";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(272, 26);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(42, 13);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "To Date:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(49, 26);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(54, 13);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "From Date:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(24, 80);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(79, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Company Name:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(30, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Phone Number:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(272, 112);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(181, 112);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // RequestHistory_Form
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 379);
            this.Controls.Add(this.gridData);
            this.Controls.Add(this.gridCompany);
            this.Name = "RequestHistory_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Request History";
            this.Load += new System.EventHandler(this.RequestHistory_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCompany)).EndInit();
            this.gridCompany.ResumeLayout(false);
            this.gridCompany.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.Base.Controls.ShGridControl gridData;
        private Taxi.Controls.Base.Controls.ShGridView gridViewCompany;
        private DevExpress.XtraEditors.GroupControl gridCompany;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn1;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn2;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn3;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn4;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn5;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn6;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn7;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn8;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn9;
        private Taxi.Controls.Base.Controls.Grids.GridColumn gridColumn10;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit toDate;
        private DevExpress.XtraEditors.DateEdit fromDate;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtCompanyName;
        private DevExpress.XtraEditors.TextEdit txtPhoneNumber;
    }
}