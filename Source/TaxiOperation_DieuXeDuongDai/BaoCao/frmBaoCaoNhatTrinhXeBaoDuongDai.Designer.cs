namespace TaxiOperation_DieuXeDuongDai.BaoCao
{
    partial class frmBaoCaoNhatTrinhXeBaoDuongDai
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
            this.btnXuatExcel = new Taxi.Controls.Base.Controls.ShButton();
            this.btnTim = new Taxi.Controls.Base.Controls.ShButton();
            this.lupTrangThai = new Taxi.Controls.Base.Inputs.InputLookUp();
            this.txtSDT = new Taxi.Controls.Base.Inputs.InputText();
            this.txtSoXe = new Taxi.Controls.Base.Inputs.InputText();
            this.deEnd = new Taxi.Controls.Base.Inputs.InputDate();
            this.deStart = new Taxi.Controls.Base.Inputs.InputDate();
            this.shLabel4 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel5 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel3 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.shGridControl1 = new Taxi.Controls.Base.Controls.ShGridControl();
            this.gridView1 = new Taxi.Controls.Base.Controls.ShGridView();
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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lupTrangThai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnXuatExcel);
            this.panel1.Controls.Add(this.btnTim);
            this.panel1.Controls.Add(this.lupTrangThai);
            this.panel1.Controls.Add(this.txtSDT);
            this.panel1.Controls.Add(this.txtSoXe);
            this.panel1.Controls.Add(this.deEnd);
            this.panel1.Controls.Add(this.deStart);
            this.panel1.Controls.Add(this.shLabel4);
            this.panel1.Controls.Add(this.shLabel2);
            this.panel1.Controls.Add(this.shLabel5);
            this.panel1.Controls.Add(this.shLabel3);
            this.panel1.Controls.Add(this.shLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(783, 107);
            this.panel1.TabIndex = 0;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Enabled = false;
            this.btnXuatExcel.Location = new System.Drawing.Point(353, 72);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(75, 23);
            this.btnXuatExcel.TabIndex = 5;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(255, 72);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.TabIndex = 4;
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // lupTrangThai
            // 
            this.lupTrangThai.Location = new System.Drawing.Point(127, 72);
            this.lupTrangThai.Name = "lupTrangThai";
            this.lupTrangThai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupTrangThai.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TrangThai", "  ")});
            this.lupTrangThai.Properties.DisplayMember = "TrangThai";
            this.lupTrangThai.Properties.NullText = "";
            this.lupTrangThai.Properties.ValueMember = "GiaTri";
            this.lupTrangThai.Size = new System.Drawing.Size(100, 20);
            this.lupTrangThai.TabIndex = 3;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(297, 39);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Properties.MaxLength = 50;
            this.txtSDT.Size = new System.Drawing.Size(100, 20);
            this.txtSDT.TabIndex = 2;
            // 
            // txtSoXe
            // 
            this.txtSoXe.Location = new System.Drawing.Point(127, 40);
            this.txtSoXe.Name = "txtSoXe";
            this.txtSoXe.Properties.MaxLength = 50;
            this.txtSoXe.Size = new System.Drawing.Size(100, 20);
            this.txtSoXe.TabIndex = 2;
            // 
            // deEnd
            // 
            this.deEnd.DateNowWhenLoad = true;
            this.deEnd.EditValue = new System.DateTime(2015, 3, 7, 15, 17, 1, 253);
            this.deEnd.Location = new System.Drawing.Point(297, 9);
            this.deEnd.Name = "deEnd";
            this.deEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEnd.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.deEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deEnd.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.deEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deEnd.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.deEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deEnd.Size = new System.Drawing.Size(100, 20);
            this.deEnd.TabIndex = 1;
            // 
            // deStart
            // 
            this.deStart.DateNowWhenLoad = true;
            this.deStart.EditValue = new System.DateTime(2015, 3, 7, 15, 16, 50, 442);
            this.deStart.Location = new System.Drawing.Point(127, 9);
            this.deStart.Name = "deStart";
            this.deStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deStart.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.deStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deStart.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.deStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deStart.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.deStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deStart.Size = new System.Drawing.Size(100, 20);
            this.deStart.TabIndex = 1;
            // 
            // shLabel4
            // 
            this.shLabel4.Location = new System.Drawing.Point(256, 43);
            this.shLabel4.Name = "shLabel4";
            this.shLabel4.Size = new System.Drawing.Size(36, 13);
            this.shLabel4.TabIndex = 0;
            this.shLabel4.Text = "SĐT KH";
            // 
            // shLabel2
            // 
            this.shLabel2.Location = new System.Drawing.Point(252, 12);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(40, 13);
            this.shLabel2.TabIndex = 0;
            this.shLabel2.Text = "Từ ngày";
            // 
            // shLabel5
            // 
            this.shLabel5.Location = new System.Drawing.Point(71, 75);
            this.shLabel5.Name = "shLabel5";
            this.shLabel5.Size = new System.Drawing.Size(49, 13);
            this.shLabel5.TabIndex = 0;
            this.shLabel5.Text = "Trạng thái";
            // 
            // shLabel3
            // 
            this.shLabel3.Location = new System.Drawing.Point(93, 43);
            this.shLabel3.Name = "shLabel3";
            this.shLabel3.Size = new System.Drawing.Size(27, 13);
            this.shLabel3.TabIndex = 0;
            this.shLabel3.Text = "Số xe";
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(80, 12);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(40, 13);
            this.shLabel1.TabIndex = 0;
            this.shLabel1.Text = "Từ ngày";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.shGridControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 107);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(783, 364);
            this.panel2.TabIndex = 1;
            // 
            // shGridControl1
            // 
            this.shGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shGridControl1.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.shGridControl1.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.shGridControl1.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.shGridControl1.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.shGridControl1.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.shGridControl1.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.shGridControl1.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.shGridControl1.Location = new System.Drawing.Point(0, 0);
            this.shGridControl1.MainView = this.gridView1;
            this.shGridControl1.Name = "shGridControl1";
            this.shGridControl1.Size = new System.Drawing.Size(783, 364);
            this.shGridControl1.TabIndex = 0;
            this.shGridControl1.UseEmbeddedNavigator = true;
            this.shGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridView1.GridControl = this.shGridControl1;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "TG gọi về TT";
            this.gridColumn1.DisplayFormat.FormatString = "HH:mm dd/MM/yyy";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn1.FieldName = "ThoiDiemGoi";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 101;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "Số xe";
            this.gridColumn2.FieldName = "SoXe";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 41;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.Caption = "TG khách gọi";
            this.gridColumn3.DisplayFormat.FormatString = "HH:mm dd/MM/yyy";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn3.FieldName = "ThoiDiemGoi";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 106;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.Caption = "SĐT KH";
            this.gridColumn4.FieldName = "DienThoai";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 95;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Địa chỉ đón";
            this.gridColumn5.FieldName = "DiaChiDon";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 112;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Địa chỉ trả";
            this.gridColumn6.FieldName = "DiaChiTra";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 122;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn7.Caption = "Đón được";
            this.gridColumn7.FieldName = "DonDuoc";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 61;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn8.Caption = "Trượt";
            this.gridColumn8.FieldName = "Truot";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 46;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn9.Caption = "Hoãn";
            this.gridColumn9.FieldName = "Hoan";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 48;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn10.Caption = "Không xe";
            this.gridColumn10.FieldName = "KhongXe";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 63;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn11.Caption = "Khách hủy";
            this.gridColumn11.FieldName = "KhachHuy";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            this.gridColumn11.Width = 80;
            // 
            // frmBaoCaoNhatTrinhXeBaoDuongDai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 471);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmBaoCaoNhatTrinhXeBaoDuongDai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BÁO CÁO NHẬT TRÌNH XE ĐÓN KHÁCH ĐƯỜNG DÀI";
            this.Load += new System.EventHandler(this.frmBaoCaoNhatTrinhXeBaoDuongDai_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lupTrangThai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Taxi.Controls.Base.Controls.ShGridControl shGridControl1;
        private Taxi.Controls.Base.Controls.ShGridView gridView1;
        private Taxi.Controls.Base.Inputs.InputText txtSDT;
        private Taxi.Controls.Base.Inputs.InputText txtSoXe;
        private Taxi.Controls.Base.Inputs.InputDate deEnd;
        private Taxi.Controls.Base.Inputs.InputDate deStart;
        private Taxi.Controls.Base.Controls.ShLabel shLabel4;
        private Taxi.Controls.Base.Controls.ShLabel shLabel2;
        private Taxi.Controls.Base.Controls.ShLabel shLabel3;
        private Taxi.Controls.Base.Controls.ShLabel shLabel1;
        private Taxi.Controls.Base.Inputs.InputLookUp lupTrangThai;
        private Taxi.Controls.Base.Controls.ShLabel shLabel5;
        private Taxi.Controls.Base.Controls.ShButton btnXuatExcel;
        private Taxi.Controls.Base.Controls.ShButton btnTim;
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
    }
}