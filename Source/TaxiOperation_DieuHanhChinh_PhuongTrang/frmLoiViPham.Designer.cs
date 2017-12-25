namespace TaxiOperation_DieuHanhChinh
{
    partial class frmLoiViPham
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoXe = new Taxi.Controls.Base.Inputs.InputText();
            this.deEnd = new Taxi.Controls.Base.Inputs.InputDate();
            this.deStart = new Taxi.Controls.Base.Inputs.InputDate();
            this.btnTimKiem = new Taxi.Controls.Base.Controls.ShButton();
            this.btnXoa = new Taxi.Controls.Base.Controls.ShButton();
            this.btnSua = new Taxi.Controls.Base.Controls.ShButton();
            this.btnThem = new Taxi.Controls.Base.Controls.ShButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grdLoiViPham = new Taxi.Controls.Base.Controls.ShGridControl();
            this.grvLoiViPham = new Taxi.Controls.Base.Controls.ShGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoiViPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLoiViPham)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSoXe);
            this.panel1.Controls.Add(this.deEnd);
            this.panel1.Controls.Add(this.deStart);
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(707, 86);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Đến ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Số xe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Từ ngày";
            // 
            // txtSoXe
            // 
            this.txtSoXe.IsChangeText = false;
            this.txtSoXe.IsFocus = false;
            this.txtSoXe.Location = new System.Drawing.Point(235, 33);
            this.txtSoXe.Name = "txtSoXe";
            this.txtSoXe.Properties.MaxLength = 50;
            this.txtSoXe.Size = new System.Drawing.Size(115, 20);
            this.txtSoXe.TabIndex = 4;
            // 
            // deEnd
            // 
            this.deEnd.DateNowWhenLoad = true;
            this.deEnd.EditValue = new System.DateTime(2015, 8, 13, 17, 20, 43, 848);
            this.deEnd.IsChangeText = false;
            this.deEnd.IsFocus = false;
            this.deEnd.Location = new System.Drawing.Point(412, 7);
            this.deEnd.Name = "deEnd";
            this.deEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEnd.Properties.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.deEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deEnd.Properties.EditFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.deEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deEnd.Properties.Mask.EditMask = "HH:mm dd/MM/yyyy";
            this.deEnd.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.deEnd.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
            this.deEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deEnd.Properties.VistaTimeProperties.DisplayFormat.FormatString = "HH:mm";
            this.deEnd.Properties.VistaTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deEnd.Properties.VistaTimeProperties.EditFormat.FormatString = "HH:mm";
            this.deEnd.Properties.VistaTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deEnd.Properties.VistaTimeProperties.Mask.EditMask = "HH:mm";
            this.deEnd.Size = new System.Drawing.Size(112, 20);
            this.deEnd.TabIndex = 3;
            // 
            // deStart
            // 
            this.deStart.DateNowWhenLoad = true;
            this.deStart.EditValue = new System.DateTime(2015, 8, 13, 16, 43, 26, 853);
            this.deStart.IsChangeText = false;
            this.deStart.IsFocus = false;
            this.deStart.Location = new System.Drawing.Point(235, 7);
            this.deStart.Name = "deStart";
            this.deStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deStart.Properties.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.deStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deStart.Properties.EditFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.deStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deStart.Properties.Mask.EditMask = "HH:mm dd/MM/yyyy";
            this.deStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deStart.Properties.VistaTimeProperties.DisplayFormat.FormatString = "HH:mm";
            this.deStart.Properties.VistaTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deStart.Properties.VistaTimeProperties.EditFormat.FormatString = "HH:mm";
            this.deStart.Properties.VistaTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deStart.Properties.VistaTimeProperties.Mask.EditMask = "HH:mm";
            this.deStart.Size = new System.Drawing.Size(115, 20);
            this.deStart.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(437, 60);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(356, 60);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(275, 60);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 0;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(194, 60);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdLoiViPham);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(707, 456);
            this.panel2.TabIndex = 1;
            // 
            // grdLoiViPham
            // 
            this.grdLoiViPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLoiViPham.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.grdLoiViPham.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.grdLoiViPham.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.grdLoiViPham.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.grdLoiViPham.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.grdLoiViPham.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.grdLoiViPham.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.grdLoiViPham.Location = new System.Drawing.Point(0, 0);
            this.grdLoiViPham.MainView = this.grvLoiViPham;
            this.grdLoiViPham.Name = "grdLoiViPham";
            this.grdLoiViPham.Size = new System.Drawing.Size(707, 456);
            this.grdLoiViPham.TabIndex = 0;
            this.grdLoiViPham.UseEmbeddedNavigator = true;
            this.grdLoiViPham.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLoiViPham});
            this.grdLoiViPham.DoubleClick += new System.EventHandler(this.grdLoiViPham_DoubleClick);
            // 
            // grvLoiViPham
            // 
            this.grvLoiViPham.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvLoiViPham.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvLoiViPham.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvLoiViPham.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvLoiViPham.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvLoiViPham.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn2,
            this.gridColumn3});
            this.grvLoiViPham.GridControl = this.grdLoiViPham;
            this.grvLoiViPham.IndicatorWidth = 35;
            this.grvLoiViPham.Name = "grvLoiViPham";
            this.grvLoiViPham.OptionsBehavior.Editable = false;
            this.grvLoiViPham.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "Số xe";
            this.gridColumn1.FieldName = "SoXe";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 70;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Áp dụng từ ngày";
            this.gridColumn4.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn4.FieldName = "TuNgay";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 150;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Đến ngày";
            this.gridColumn5.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn5.FieldName = "DenNgay";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 150;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Loại lỗi vi phạm";
            this.gridColumn2.FieldName = "TenLoaiLoiViPham";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 150;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Ghi chú";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 150;
            // 
            // frmLoiViPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 542);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmLoiViPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách lỗi vi phạm";
            this.Load += new System.EventHandler(this.frmLoiViPham_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLoiViPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLoiViPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Taxi.Controls.Base.Controls.ShGridControl grdLoiViPham;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private Taxi.Controls.Base.Inputs.InputDate deEnd;
        private Taxi.Controls.Base.Inputs.InputDate deStart;
        private Taxi.Controls.Base.Controls.ShButton btnTimKiem;
        private Taxi.Controls.Base.Controls.ShButton btnXoa;
        private Taxi.Controls.Base.Controls.ShButton btnSua;
        private Taxi.Controls.Base.Controls.ShButton btnThem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Taxi.Controls.Base.Inputs.InputText txtSoXe;
        private Taxi.Controls.Base.Controls.ShGridView grvLoiViPham;
    }
}