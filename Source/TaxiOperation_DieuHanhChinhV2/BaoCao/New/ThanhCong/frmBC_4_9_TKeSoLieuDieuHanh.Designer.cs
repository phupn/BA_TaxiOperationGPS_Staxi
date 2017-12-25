namespace TaxiOperation_DieuHanhChinh.BaoCao.New.ThanhCong
{
    partial class frmBC_4_9_TKeSoLieuDieuHanh
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
            this.shGrid = new Taxi.Controls.Base.Controls.ShGridControl();
            this.shBandedView = new Taxi.Controls.Base.Controls.ShBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bgDays = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this.ipYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipMonth.Properties)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.shGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shBandedView)).BeginInit();
            this.SuspendLayout();
            // 
            // ipYear
            // 
            // 
            // ipMonth
            // 
            // 
            // pnInputs
            // 
            this.pnInputs.Location = new System.Drawing.Point(0, 34);
            this.pnInputs.Size = new System.Drawing.Size(964, 45);
            // 
            // ipToDate
            // 
            this.ipToDate.EditValue = new System.DateTime(2014, 8, 31, 23, 59, 59, 0);
            this.ipToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.ipToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.ipToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.ipToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            // 
            // ipFromDate
            // 
            this.ipFromDate.EditValue = new System.DateTime(2014, 8, 1, 0, 0, 0, 0);
            this.ipFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.ipFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.ipFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.ipFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            // 
            // pnButtons
            // 
            this.pnButtons.Location = new System.Drawing.Point(0, 79);
            this.pnButtons.Size = new System.Drawing.Size(964, 52);
            // 
            // lbMessage
            // 
            this.lbMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbMessage.Appearance.Options.UseForeColor = true;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Appearance.Options.UseFont = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            // 
            // btnTim
            // 
            this.btnTim.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Appearance.Options.UseFont = true;
            // 
            // pnOutput
            // 
            this.pnOutput.Controls.Add(this.shGrid);
            this.pnOutput.Location = new System.Drawing.Point(0, 131);
            this.pnOutput.Size = new System.Drawing.Size(964, 380);
            // 
            // pnTitle
            // 
            this.pnTitle.Size = new System.Drawing.Size(964, 34);
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.Options.UseFont = true;
            // 
            // shGrid
            // 
            this.shGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shGrid.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.shGrid.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.shGrid.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.shGrid.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.shGrid.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.shGrid.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.shGrid.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.shGrid.Location = new System.Drawing.Point(0, 0);
            this.shGrid.MainView = this.shBandedView;
            this.shGrid.Name = "shGrid";
            this.shGrid.Size = new System.Drawing.Size(964, 380);
            this.shGrid.TabIndex = 1;
            this.shGrid.UseEmbeddedNavigator = true;
            this.shGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.shBandedView});
            // 
            // shBandedView
            // 
            this.shBandedView.Appearance.BandPanel.Options.UseTextOptions = true;
            this.shBandedView.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.shBandedView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.shBandedView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.shBandedView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.bgDays});
            this.shBandedView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn1,
            this.bandedGridColumn2});
            this.shBandedView.GridControl = this.shGrid;
            this.shBandedView.IndicatorWidth = 30;
            this.shBandedView.Name = "shBandedView";
            this.shBandedView.OptionsBehavior.AutoExpandAllGroups = true;
            this.shBandedView.OptionsCustomization.AllowFilter = false;
            this.shBandedView.OptionsCustomization.AllowSort = false;
            this.shBandedView.OptionsView.ColumnAutoWidth = false;
            this.shBandedView.OptionsView.ShowGroupPanel = false;
            this.shBandedView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.shBandedView_RowStyle);
            // 
            // gridBand1
            // 
            this.gridBand1.Columns.Add(this.bandedGridColumn1);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Visible = false;
            this.gridBand1.VisibleIndex = -1;
            this.gridBand1.Width = 165;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.Caption = "Mục";
            this.bandedGridColumn1.FieldName = "KhoanMuc";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.Width = 165;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Phòng điều hành";
            this.gridBand2.Columns.Add(this.bandedGridColumn2);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 0;
            this.gridBand2.Width = 250;
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.Caption = "Các mục";
            this.bandedGridColumn2.FieldName = "NoiDung";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.Visible = true;
            this.bandedGridColumn2.Width = 250;
            // 
            // bgDays
            // 
            this.bgDays.Caption = "Thống kê số liệu phòng điều hành";
            this.bgDays.Name = "bgDays";
            this.bgDays.VisibleIndex = 1;
            this.bgDays.Width = 489;
            // 
            // frmBC_4_9_TKeSoLieuDieuHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 511);
            this.Name = "frmBC_4_9_TKeSoLieuDieuHanh";
            this.Text = "Báo cáo thống kê phòng điều hành";
            ((System.ComponentModel.ISupportInitialize)(this.ipYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipMonth.Properties)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.shGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shBandedView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.Base.Controls.ShGridControl shGrid;
        private Taxi.Controls.Base.Controls.ShBandedGridView shBandedView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bgDays;


    }
}