﻿namespace TaxiOperation_DieuXeDuongDai.DangKyDonKhach
{
    partial class frmDanhSachDangKyDonKhach
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoXe = new Taxi.Controls.Base.Inputs.InputText();
            this.lupTrangThai = new Taxi.Controls.Base.Inputs.InputLookUp();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLichSu = new Taxi.Controls.Base.Controls.ShButton();
            this.btnThemMoi = new Taxi.Controls.Base.Controls.ShButton();
            this.btnTimKiem = new Taxi.Controls.Base.Controls.ShButton();
            this.txtSDT = new Taxi.Controls.Base.Inputs.InputText();
            this.deEnd = new Taxi.Controls.Base.Inputs.InputDate();
            this.deStart = new Taxi.Controls.Base.Inputs.InputDate();
            this.panel2 = new System.Windows.Forms.Panel();
            this.shGridControl1 = new Taxi.Controls.Base.Controls.ShGridControl();
            this.gridView1 = new Taxi.Controls.Base.Controls.ShGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reLichSu = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupTrangThai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reLichSu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtSoXe);
            this.panel1.Controls.Add(this.lupTrangThai);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnLichSu);
            this.panel1.Controls.Add(this.btnThemMoi);
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.txtSDT);
            this.panel1.Controls.Add(this.deEnd);
            this.panel1.Controls.Add(this.deStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 65);
            this.panel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(545, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Số Xe";
            // 
            // txtSoXe
            // 
            this.txtSoXe.Location = new System.Drawing.Point(589, 9);
            this.txtSoXe.Name = "txtSoXe";
            this.txtSoXe.Properties.MaxLength = 50;
            this.txtSoXe.Size = new System.Drawing.Size(67, 20);
            this.txtSoXe.TabIndex = 3;
            // 
            // lupTrangThai
            // 
            this.lupTrangThai.Location = new System.Drawing.Point(727, 9);
            this.lupTrangThai.Name = "lupTrangThai";
            this.lupTrangThai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupTrangThai.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TrangThai", "  ")});
            this.lupTrangThai.Properties.DisplayMember = "TrangThai";
            this.lupTrangThai.Properties.NullText = "";
            this.lupTrangThai.Properties.ValueMember = "GiaTri";
            this.lupTrangThai.Size = new System.Drawing.Size(112, 20);
            this.lupTrangThai.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(664, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Trạng thái";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Số ĐT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Đến ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Từ ngày";
            // 
            // btnLichSu
            // 
            this.btnLichSu.KeyCommand = System.Windows.Forms.Keys.F3;
            this.btnLichSu.Location = new System.Drawing.Point(372, 35);
            this.btnLichSu.Name = "btnLichSu";
            this.btnLichSu.Size = new System.Drawing.Size(85, 23);
            this.btnLichSu.TabIndex = 7;
            this.btnLichSu.Text = "Lịch sử (F3)";
            this.btnLichSu.Click += new System.EventHandler(this.btnLichSu_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.KeyCommand = System.Windows.Forms.Keys.F1;
            this.btnThemMoi.Location = new System.Drawing.Point(275, 35);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(85, 23);
            this.btnThemMoi.TabIndex = 6;
            this.btnThemMoi.Text = "Thêm mới (F1)";
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.KeyCommand = System.Windows.Forms.Keys.F5;
            this.btnTimKiem.Location = new System.Drawing.Point(178, 35);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(85, 23);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Text = "Tìm (F5)";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(406, 9);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Properties.MaxLength = 50;
            this.txtSDT.Size = new System.Drawing.Size(131, 20);
            this.txtSDT.TabIndex = 2;
            // 
            // deEnd
            // 
            this.deEnd.DateNowWhenLoad = false;
            this.deEnd.EditValue = new System.DateTime(2015, 3, 3, 15, 3, 50, 601);
            this.deEnd.Location = new System.Drawing.Point(243, 9);
            this.deEnd.Name = "deEnd";
            this.deEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEnd.Properties.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.deEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deEnd.Properties.EditFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.deEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deEnd.Properties.Mask.EditMask = "HH:mm dd/MM/yyyy";
            this.deEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deEnd.Size = new System.Drawing.Size(109, 20);
            this.deEnd.TabIndex = 1;
            // 
            // deStart
            // 
            this.deStart.DateNowWhenLoad = false;
            this.deStart.EditValue = new System.DateTime(2015, 3, 3, 15, 3, 20, 236);
            this.deStart.Location = new System.Drawing.Point(65, 9);
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
            this.deStart.Size = new System.Drawing.Size(109, 20);
            this.deStart.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.shGridControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(856, 434);
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
            this.shGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reLichSu});
            this.shGridControl1.Size = new System.Drawing.Size(856, 434);
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
            this.gridColumn9,
            this.gridColumn7,
            this.gridColumn8});
            this.gridView1.GridControl = this.shGridControl1;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "TG đón khách";
            this.gridColumn1.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn1.FieldName = "ThoiDiemDon";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 116;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "Số xe";
            this.gridColumn2.FieldName = "SoXe";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 70;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tên lái xe";
            this.gridColumn3.FieldName = "TenLaiXe";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Width = 100;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.Caption = "Số điện thoại";
            this.gridColumn4.FieldName = "DienThoai";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 92;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Điểm đỗ";
            this.gridColumn5.FieldName = "DiemDo";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 130;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Ghi chú";
            this.gridColumn6.FieldName = "GhiChu";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 133;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn9.Caption = "Thời gian gọi";
            this.gridColumn9.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn9.FieldName = "ThoiDiemGoi";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            this.gridColumn9.Width = 105;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn7.Caption = "Người nhập";
            this.gridColumn7.FieldName = "NguoiNhap";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 84;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Lịch sử";
            this.gridColumn8.ColumnEdit = this.reLichSu;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 92;
            // 
            // reLichSu
            // 
            this.reLichSu.AutoHeight = false;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            serializableAppearanceObject1.Options.UseFont = true;
            this.reLichSu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Xem", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.reLichSu.Name = "reLichSu";
            this.reLichSu.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.reLichSu.Click += new System.EventHandler(this.reLichSu_Click);
            // 
            // frmDanhSachDangKyDonKhach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 499);
            this.CloseByKeyEsc = true;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmDanhSachDangKyDonKhach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách đăng ký đón khách";
            this.Load += new System.EventHandler(this.frmDanhSachDangKyDonKhach_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupTrangThai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reLichSu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Taxi.Controls.Base.Controls.ShGridControl shGridControl1;
        private Taxi.Controls.Base.Controls.ShGridView gridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Taxi.Controls.Base.Controls.ShButton btnThemMoi;
        private Taxi.Controls.Base.Controls.ShButton btnTimKiem;
        private Taxi.Controls.Base.Inputs.InputText txtSDT;
        private Taxi.Controls.Base.Inputs.InputDate deEnd;
        private Taxi.Controls.Base.Inputs.InputDate deStart;
        private Taxi.Controls.Base.Inputs.InputLookUp lupTrangThai;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit reLichSu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private System.Windows.Forms.Label label5;
        private Taxi.Controls.Base.Inputs.InputText txtSoXe;
        private Taxi.Controls.Base.Controls.ShButton btnLichSu;
    }
}