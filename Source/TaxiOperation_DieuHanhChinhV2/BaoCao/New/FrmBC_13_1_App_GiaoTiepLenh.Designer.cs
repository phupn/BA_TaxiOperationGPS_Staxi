namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
    partial class FrmBC_13_1_App_GiaoTiepLenh
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
            this.Grid_Command = new Taxi.Controls.Base.Controls.ShGridControl();
            this.gridView_Command = new Taxi.Controls.Base.Controls.ShBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.IDCuocGoi = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.CreatedDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.PrivateCode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.CommandText = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.CreatedBy = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblInfo = new DevExpress.XtraEditors.LabelControl();
            this.grid_CuocGoi = new DevExpress.XtraGrid.GridControl();
            this.gridView_CuocGoi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Command)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Command)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_CuocGoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_CuocGoi)).BeginInit();
            this.SuspendLayout();
            // 
            // pnInputs
            // 
            this.pnInputs.Controls.Add(this.label1);
            this.pnInputs.Controls.Add(this.txtNoiDung);
            this.pnInputs.Size = new System.Drawing.Size(773, 43);
            this.pnInputs.Controls.SetChildIndex(this.ipFromDate, 0);
            this.pnInputs.Controls.SetChildIndex(this.labelControl1, 0);
            this.pnInputs.Controls.SetChildIndex(this.ipToDate, 0);
            this.pnInputs.Controls.SetChildIndex(this.labelControl2, 0);
            this.pnInputs.Controls.SetChildIndex(this.txtNoiDung, 0);
            this.pnInputs.Controls.SetChildIndex(this.label1, 0);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(274, 6);
            // 
            // ipToDate
            // 
            this.ipToDate.EditValue = new System.DateTime(2016, 4, 13, 15, 30, 46, 0);
            this.ipToDate.Location = new System.Drawing.Point(325, 3);
            this.ipToDate.Properties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.ipToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.ipToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.Mask.EditMask = "HH:mm:ss dd/MM/yyyy";
            this.ipToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.ipToDate.Size = new System.Drawing.Size(125, 20);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(46, 6);
            // 
            // ipFromDate
            // 
            this.ipFromDate.EditValue = new System.DateTime(2016, 4, 13, 0, 0, 0, 0);
            this.ipFromDate.Location = new System.Drawing.Point(90, 3);
            this.ipFromDate.Properties.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.ipFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.ipFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.Mask.EditMask = "HH:mm:ss dd/MM/yyyy";
            this.ipFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.ipFromDate.Size = new System.Drawing.Size(127, 20);
            // 
            // pnButtons
            // 
            this.pnButtons.Controls.Add(this.lblInfo);
            this.pnButtons.Location = new System.Drawing.Point(0, 77);
            this.pnButtons.Size = new System.Drawing.Size(773, 71);
            this.pnButtons.Controls.SetChildIndex(this.btnTim, 0);
            this.pnButtons.Controls.SetChildIndex(this.btnThoat, 0);
            this.pnButtons.Controls.SetChildIndex(this.btnExportExcel, 0);
            this.pnButtons.Controls.SetChildIndex(this.lbMessage, 0);
            this.pnButtons.Controls.SetChildIndex(this.lblInfo, 0);
            // 
            // lbMessage
            // 
            this.lbMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbMessage.Appearance.Options.UseForeColor = true;
            this.lbMessage.Location = new System.Drawing.Point(159, 20);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnExportExcel.Appearance.Options.UseFont = true;
            this.btnExportExcel.Location = new System.Drawing.Point(275, 3);
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.Location = new System.Drawing.Point(400, 3);
            // 
            // btnTim
            // 
            this.btnTim.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnTim.Appearance.Options.UseFont = true;
            this.btnTim.Location = new System.Drawing.Point(159, 3);
            // 
            // pnOutput
            // 
            this.pnOutput.Controls.Add(this.labelControl3);
            this.pnOutput.Controls.Add(this.Grid_Command);
            this.pnOutput.Controls.Add(this.grid_CuocGoi);
            this.pnOutput.Location = new System.Drawing.Point(0, 148);
            this.pnOutput.Size = new System.Drawing.Size(773, 585);
            // 
            // pnTitle
            // 
            this.pnTitle.Size = new System.Drawing.Size(773, 34);
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Location = new System.Drawing.Point(291, 7);
            this.lblTitle.Size = new System.Drawing.Size(68, 21);
            this.lblTitle.Text = "Báo cáo";
            // 
            // Grid_Command
            // 
            this.Grid_Command.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_Command.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.Grid_Command.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.Grid_Command.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.Grid_Command.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.Grid_Command.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.Grid_Command.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.Grid_Command.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.Grid_Command.Location = new System.Drawing.Point(0, 63);
            this.Grid_Command.MainView = this.gridView_Command;
            this.Grid_Command.Name = "Grid_Command";
            this.Grid_Command.Size = new System.Drawing.Size(773, 522);
            this.Grid_Command.TabIndex = 0;
            this.Grid_Command.UseEmbeddedNavigator = true;
            this.Grid_Command.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Command,
            this.gridView2});
            // 
            // gridView_Command
            // 
            this.gridView_Command.Appearance.BandPanel.Options.UseTextOptions = true;
            this.gridView_Command.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView_Command.Appearance.BandPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView_Command.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView_Command.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView_Command.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView_Command.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.gridView_Command.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.IDCuocGoi,
            this.CommandText,
            this.PrivateCode,
            this.CreatedDate,
            this.CreatedBy});
            this.gridView_Command.GridControl = this.Grid_Command;
            this.gridView_Command.GroupCount = 1;
            this.gridView_Command.IndicatorWidth = 35;
            this.gridView_Command.Name = "gridView_Command";
            this.gridView_Command.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView_Command.OptionsBehavior.Editable = false;
            this.gridView_Command.OptionsPrint.ExpandAllDetails = true;
            this.gridView_Command.OptionsView.ColumnAutoWidth = false;
            this.gridView_Command.OptionsView.ShowFooter = true;
            this.gridView_Command.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.IDCuocGoi, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView_Command.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridBand1
            // 
            this.gridBand1.Columns.Add(this.IDCuocGoi);
            this.gridBand1.Columns.Add(this.CreatedDate);
            this.gridBand1.Columns.Add(this.PrivateCode);
            this.gridBand1.Columns.Add(this.CommandText);
            this.gridBand1.Columns.Add(this.CreatedBy);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 662;
            // 
            // IDCuocGoi
            // 
            this.IDCuocGoi.Caption = "ID Cuộc Gọi";
            this.IDCuocGoi.FieldName = "IdCuocGoi";
            this.IDCuocGoi.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value;
            this.IDCuocGoi.Name = "IDCuocGoi";
            this.IDCuocGoi.Width = 103;
            // 
            // CreatedDate
            // 
            this.CreatedDate.Caption = "Thời điểm";
            this.CreatedDate.FieldName = "CreatedDate";
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.Visible = true;
            this.CreatedDate.Width = 148;
            // 
            // PrivateCode
            // 
            this.PrivateCode.Caption = "Số Xe";
            this.PrivateCode.FieldName = "PrivateCode";
            this.PrivateCode.Name = "PrivateCode";
            this.PrivateCode.Visible = true;
            this.PrivateCode.Width = 87;
            // 
            // CommandText
            // 
            this.CommandText.Caption = "Nội dung";
            this.CommandText.FieldName = "CommandText";
            this.CommandText.Name = "CommandText";
            this.CommandText.Visible = true;
            this.CommandText.Width = 335;
            // 
            // CreatedBy
            // 
            this.CreatedBy.Caption = "ĐTV";
            this.CreatedBy.FieldName = "CreatedBy";
            this.CreatedBy.Name = "CreatedBy";
            this.CreatedBy.Visible = true;
            this.CreatedBy.Width = 92;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.Grid_Command;
            this.gridView2.Name = "gridView2";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(559, 3);
            this.txtNoiDung.MaxLength = 20;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(152, 21);
            this.txtNoiDung.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(504, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nội dung";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(508, 84);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(255, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "(Click chuột 2 lần trên lưới để xem thông tin cuộc gọi)";
            // 
            // lblInfo
            // 
            this.lblInfo.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblInfo.Appearance.Options.UseFont = true;
            this.lblInfo.Location = new System.Drawing.Point(3, 55);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(102, 13);
            this.lblInfo.TabIndex = 12;
            this.lblInfo.Text = "Thông tin cuộc gọi";
            // 
            // grid_CuocGoi
            // 
            this.grid_CuocGoi.Dock = System.Windows.Forms.DockStyle.Top;
            this.grid_CuocGoi.Location = new System.Drawing.Point(0, 0);
            this.grid_CuocGoi.MainView = this.gridView_CuocGoi;
            this.grid_CuocGoi.Name = "grid_CuocGoi";
            this.grid_CuocGoi.Size = new System.Drawing.Size(773, 63);
            this.grid_CuocGoi.TabIndex = 1;
            this.grid_CuocGoi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_CuocGoi});
            // 
            // gridView_CuocGoi
            // 
            this.gridView_CuocGoi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gridView_CuocGoi.GridControl = this.grid_CuocGoi;
            this.gridView_CuocGoi.Name = "gridView_CuocGoi";
            this.gridView_CuocGoi.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số điện thoại";
            this.gridColumn1.FieldName = "PhoneNumber";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 107;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Thời điểm gọi";
            this.gridColumn2.FieldName = "ThoiDiemGoi";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 96;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Địa chỉ đón khách";
            this.gridColumn3.FieldName = "DiaChiDonKhach";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 149;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Lệnh điện thoại";
            this.gridColumn4.FieldName = "LenhDienThoai";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 122;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Lệnh lái xe";
            this.gridColumn5.FieldName = "LenhLaiXe";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 108;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Xe Nhận";
            this.gridColumn6.FieldName = "XeNhan";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 81;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Xe đón";
            this.gridColumn7.FieldName = "XeDon";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 92;
            // 
            // FrmBC_13_1_App_GiaoTiepLenh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 733);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmBC_13_1_App_GiaoTiepLenh";
            this.Text = "Báo cáo giao tiếp lệnh App";
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
            this.pnOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnTitle)).EndInit();
            this.pnTitle.ResumeLayout(false);
            this.pnTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Command)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Command)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_CuocGoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_CuocGoi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.Base.Controls.ShGridControl Grid_Command;
        private Taxi.Controls.Base.Controls.ShBandedGridView gridView_Command;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn IDCuocGoi;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn CommandText;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn PrivateCode;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn CreatedDate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn CreatedBy;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoiDung;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblInfo;
        private DevExpress.XtraGrid.GridControl grid_CuocGoi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_CuocGoi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
    }
}