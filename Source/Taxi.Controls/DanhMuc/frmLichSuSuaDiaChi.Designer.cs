namespace Taxi.Controls.DanhMuc
{
    partial class frmLichSuSuaDiaChi
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.gridControlLichSu = new Taxi.Controls.Base.Controls.Grids.GridControl();
            this.gridViewLichSu = new Taxi.Controls.Base.Controls.Grids.GridView();
            this.gridColumn12 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn1 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn2 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn8 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn3 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn5 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn4 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn6 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn7 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn9 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn10 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.gridColumn11 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.btnDuyet = new Taxi.Controls.Base.Controls.ShButton();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtMaDoiTac = new Taxi.Controls.Base.Inputs.InputText();
            this.txtSDT = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pnInputs)).BeginInit();
            this.pnInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnButtons)).BeginInit();
            this.pnButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnOutput)).BeginInit();
            this.pnOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnTitle)).BeginInit();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLichSu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLichSu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDoiTac.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnInputs
            // 
            this.pnInputs.Controls.Add(this.txtSDT);
            this.pnInputs.Controls.Add(this.shLabel2);
            this.pnInputs.Controls.Add(this.txtMaDoiTac);
            this.pnInputs.Controls.Add(this.shLabel1);
            this.pnInputs.Size = new System.Drawing.Size(850, 75);
            this.pnInputs.Controls.SetChildIndex(this.ipFromDate, 0);
            this.pnInputs.Controls.SetChildIndex(this.labelControl1, 0);
            this.pnInputs.Controls.SetChildIndex(this.ipToDate, 0);
            this.pnInputs.Controls.SetChildIndex(this.labelControl2, 0);
            this.pnInputs.Controls.SetChildIndex(this.shLabel1, 0);
            this.pnInputs.Controls.SetChildIndex(this.txtMaDoiTac, 0);
            this.pnInputs.Controls.SetChildIndex(this.shLabel2, 0);
            this.pnInputs.Controls.SetChildIndex(this.txtSDT, 0);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(395, 6);
            // 
            // ipToDate
            // 
            this.ipToDate.EditValue = null;
            this.ipToDate.Location = new System.Drawing.Point(446, 3);
            this.ipToDate.Properties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.ipToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.ipToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.Mask.EditMask = "HH:mm:ss dd/MM/yyyy";
            this.ipToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.ipToDate.Size = new System.Drawing.Size(164, 20);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(164, 6);
            // 
            // ipFromDate
            // 
            this.ipFromDate.EditValue = null;
            this.ipFromDate.Location = new System.Drawing.Point(210, 3);
            this.ipFromDate.Properties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.ipFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.ipFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.Mask.EditMask = "HH:mm:ss dd/MM/yyyy";
            this.ipFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.ipFromDate.Size = new System.Drawing.Size(150, 20);
            // 
            // pnButtons
            // 
            this.pnButtons.Controls.Add(this.btnDuyet);
            this.pnButtons.Location = new System.Drawing.Point(0, 109);
            this.pnButtons.Size = new System.Drawing.Size(850, 60);
            this.pnButtons.Controls.SetChildIndex(this.btnTim, 0);
            this.pnButtons.Controls.SetChildIndex(this.btnThoat, 0);
            this.pnButtons.Controls.SetChildIndex(this.btnExportExcel, 0);
            this.pnButtons.Controls.SetChildIndex(this.lbMessage, 0);
            this.pnButtons.Controls.SetChildIndex(this.btnDuyet, 0);
            // 
            // lbMessage
            // 
            this.lbMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbMessage.Appearance.Options.UseForeColor = true;
            this.lbMessage.Location = new System.Drawing.Point(403, 41);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnExportExcel.Appearance.Options.UseFont = true;
            this.btnExportExcel.Location = new System.Drawing.Point(323, 6);
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.Location = new System.Drawing.Point(446, 6);
            // 
            // btnTim
            // 
            this.btnTim.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnTim.Appearance.Options.UseFont = true;
            this.btnTim.Location = new System.Drawing.Point(207, 6);
            // 
            // pnOutput
            // 
            this.pnOutput.Controls.Add(this.gridControlLichSu);
            this.pnOutput.Location = new System.Drawing.Point(0, 169);
            this.pnOutput.Size = new System.Drawing.Size(850, 421);
            // 
            // pnTitle
            // 
            this.pnTitle.Size = new System.Drawing.Size(850, 34);
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.Options.UseFont = true;
            // 
            // gridControlLichSu
            // 
            this.gridControlLichSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlLichSu.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.gridControlLichSu.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.gridControlLichSu.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.gridControlLichSu.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.gridControlLichSu.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.gridControlLichSu.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.gridControlLichSu.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.gridControlLichSu.Location = new System.Drawing.Point(0, 0);
            this.gridControlLichSu.MainView = this.gridViewLichSu;
            this.gridControlLichSu.Name = "gridControlLichSu";
            this.gridControlLichSu.Size = new System.Drawing.Size(850, 421);
            this.gridControlLichSu.TabIndex = 2;
            this.gridControlLichSu.UseEmbeddedNavigator = true;
            this.gridControlLichSu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLichSu});
            // 
            // gridViewLichSu
            // 
            this.gridViewLichSu.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridViewLichSu.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewLichSu.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewLichSu.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewLichSu.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridViewLichSu.Appearance.Row.Options.UseTextOptions = true;
            this.gridViewLichSu.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewLichSu.ColumnPanelRowHeight = 30;
            this.gridViewLichSu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn8,
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.gridViewLichSu.GridControl = this.gridControlLichSu;
            this.gridViewLichSu.GroupCount = 1;
            this.gridViewLichSu.GroupPanelText = "Kéo cột muốn nhóm vào đây";
            this.gridViewLichSu.IndicatorWidth = 35;
            this.gridViewLichSu.Name = "gridViewLichSu";
            this.gridViewLichSu.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewLichSu.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.gridViewLichSu.OptionsBehavior.Editable = false;
            this.gridViewLichSu.OptionsCustomization.AllowFilter = false;
            this.gridViewLichSu.OptionsCustomization.AllowGroup = false;
            this.gridViewLichSu.OptionsMenu.EnableColumnMenu = false;
            this.gridViewLichSu.OptionsMenu.EnableFooterMenu = false;
            this.gridViewLichSu.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewLichSu.OptionsSelection.MultiSelect = true;
            this.gridViewLichSu.OptionsView.ColumnAutoWidth = false;
            this.gridViewLichSu.OptionsView.ShowGroupPanel = false;
            this.gridViewLichSu.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn12, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewLichSu.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewLichSu_RowStyle);
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn12.Caption = "Đối tác";
            this.gridColumn12.FieldName = "GroupInfo";
            this.gridColumn12.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.TagLanguage = null;
            this.gridColumn12.Width = 150;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số điện thoại";
            this.gridColumn1.FieldName = "PhoneNumber";
            this.gridColumn1.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.TagLanguage = null;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 110;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Thời điểm gọi";
            this.gridColumn2.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn2.FieldName = "ThoiDiemGoi";
            this.gridColumn2.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.TagLanguage = null;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 120;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn8.Caption = "Địa chỉ đối tác";
            this.gridColumn8.FieldName = "Address";
            this.gridColumn8.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.TagLanguage = null;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 2;
            this.gridColumn8.Width = 200;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn3.Caption = "Thay đổi địa chỉ";
            this.gridColumn3.FieldName = "ThayDoiDiaChi";
            this.gridColumn3.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.TagLanguage = null;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 300;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Xe đón";
            this.gridColumn5.FieldName = "XeDon";
            this.gridColumn5.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.TagLanguage = null;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 50;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn4.Caption = "Ghi chú điện thoại";
            this.gridColumn4.FieldName = "GhiChuDienThoai";
            this.gridColumn4.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.TagLanguage = null;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 110;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn6.Caption = "Ghi chú tổng đài";
            this.gridColumn6.FieldName = "GhiChuTongDai";
            this.gridColumn6.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.TagLanguage = null;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 110;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn7.Caption = "Ghi chú lái xe";
            this.gridColumn7.FieldName = "GhiChuLaiXe";
            this.gridColumn7.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.TagLanguage = null;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 110;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Thời gian sửa";
            this.gridColumn9.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn9.FieldName = "UpdatedTime";
            this.gridColumn9.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.TagLanguage = null;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 120;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Nhân viên sửa";
            this.gridColumn10.FieldName = "UpdatedBy";
            this.gridColumn10.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.TagLanguage = null;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 100;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Đã duyệt";
            this.gridColumn11.FieldName = "DaDuyet";
            this.gridColumn11.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.TagLanguage = null;
            // 
            // btnDuyet
            // 
            this.btnDuyet.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDuyet.Appearance.Options.UseFont = true;
            this.btnDuyet.Location = new System.Drawing.Point(542, 6);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(98, 25);
            this.btnDuyet.TabIndex = 11;
            this.btnDuyet.Text = "&Duyệt địa chỉ";
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(155, 36);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(49, 13);
            this.shLabel1.TabIndex = 4;
            this.shLabel1.Text = "Mã đối tác";
            // 
            // txtMaDoiTac
            // 
            this.txtMaDoiTac.EditValue = "";
            this.txtMaDoiTac.IsChangeText = false;
            this.txtMaDoiTac.IsFocus = false;
            this.txtMaDoiTac.Location = new System.Drawing.Point(210, 33);
            this.txtMaDoiTac.Name = "txtMaDoiTac";
            this.txtMaDoiTac.Size = new System.Drawing.Size(150, 20);
            this.txtMaDoiTac.TabIndex = 5;
            // 
            // txtSDT
            // 
            this.txtSDT.EditValue = "";
            this.txtSDT.IsChangeText = false;
            this.txtSDT.IsFocus = false;
            this.txtSDT.Location = new System.Drawing.Point(446, 33);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(164, 20);
            this.txtSDT.TabIndex = 7;
            // 
            // shLabel2
            // 
            this.shLabel2.Location = new System.Drawing.Point(380, 36);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(62, 13);
            this.shLabel2.TabIndex = 6;
            this.shLabel2.Text = "Số điện thoại";
            // 
            // frmLichSuSuaDiaChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 590);
            this.Name = "frmLichSuSuaDiaChi";
            this.Text = "Chi tiết lịch sử sửa địa chỉ đối tác";
            ((System.ComponentModel.ISupportInitialize)(this.pnInputs)).EndInit();
            this.pnInputs.ResumeLayout(false);
            this.pnInputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnButtons)).EndInit();
            this.pnButtons.ResumeLayout(false);
            this.pnButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnOutput)).EndInit();
            this.pnOutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnTitle)).EndInit();
            this.pnTitle.ResumeLayout(false);
            this.pnTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLichSu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLichSu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDoiTac.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Controls.Grids.GridControl gridControlLichSu;
        private Base.Controls.Grids.GridView gridViewLichSu;
        private Base.Controls.ShButton btnDuyet;
        private Base.Inputs.InputText txtSDT;
        private Base.Controls.ShLabel shLabel2;
        private Base.Inputs.InputText txtMaDoiTac;
        private Base.Controls.ShLabel shLabel1;
        private Base.Controls.Grids.GridColumn gridColumn1;
        private Base.Controls.Grids.GridColumn gridColumn2;
        private Base.Controls.Grids.GridColumn gridColumn3;
        private Base.Controls.Grids.GridColumn gridColumn5;
        private Base.Controls.Grids.GridColumn gridColumn4;
        private Base.Controls.Grids.GridColumn gridColumn6;
        private Base.Controls.Grids.GridColumn gridColumn7;
        private Base.Controls.Grids.GridColumn gridColumn8;
        private Base.Controls.Grids.GridColumn gridColumn9;
        private Base.Controls.Grids.GridColumn gridColumn10;
        private Base.Controls.Grids.GridColumn gridColumn12;
        private Base.Controls.Grids.GridColumn gridColumn11;
    }
}