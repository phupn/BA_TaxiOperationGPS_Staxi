namespace TaxiOperation_DieuHanhChinh.BaoCao.New
{
    partial class frmBC_1_9_TongHopThongKeSoLieuDuongPho
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
            this.gridControlBaoCao = new Taxi.Controls.Base.Controls.Grids.GridControl();
            this.gridView1 = new Taxi.Controls.Base.Controls.Grids.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnInputs)).BeginInit();
            this.pnInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnButtons)).BeginInit();
            this.pnButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnOutput)).BeginInit();
            this.pnOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnTitle)).BeginInit();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBaoCao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnInputs
            // 
            this.pnInputs.Size = new System.Drawing.Size(811, 97);
            // 
            // ipToDate
            // 
            this.ipToDate.EditValue = null;
            this.ipToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.ipToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.ipToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.ipToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            // 
            // ipFromDate
            // 
            this.ipFromDate.EditValue = null;
            this.ipFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.ipFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.ipFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.ipFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            // 
            // pnButtons
            // 
            this.pnButtons.Size = new System.Drawing.Size(811, 52);
            // 
            // lbMessage
            // 
            this.lbMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnExportExcel.Appearance.Options.UseFont = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnThoat.Appearance.Options.UseFont = true;
            // 
            // btnTim
            // 
            this.btnTim.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnTim.Appearance.Options.UseFont = true;
            // 
            // pnOutput
            // 
            this.pnOutput.Controls.Add(this.gridControlBaoCao);
            this.pnOutput.Size = new System.Drawing.Size(811, 337);
            // 
            // pnTitle
            // 
            this.pnTitle.Size = new System.Drawing.Size(811, 34);
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            // 
            // gridControlBaoCao
            // 
            this.gridControlBaoCao.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.gridControlBaoCao.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.gridControlBaoCao.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.gridControlBaoCao.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.gridControlBaoCao.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.gridControlBaoCao.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.gridControlBaoCao.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.gridControlBaoCao.Location = new System.Drawing.Point(188, 32);
            this.gridControlBaoCao.MainView = this.gridView1;
            this.gridControlBaoCao.Name = "gridControlBaoCao";
            this.gridControlBaoCao.Size = new System.Drawing.Size(400, 200);
            this.gridControlBaoCao.TabIndex = 0;
            this.gridControlBaoCao.UseEmbeddedNavigator = true;
            this.gridControlBaoCao.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControlBaoCao;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsPrint.AutoWidth = false;
            // 
            // frmBC_1_9_TongHopThongKeSoLieuDuongPho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 520);
            this.Name = "frmBC_1_9_TongHopThongKeSoLieuDuongPho";
            ((System.ComponentModel.ISupportInitialize)(this.pnInputs)).EndInit();
            this.pnInputs.ResumeLayout(false);
            this.pnInputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnButtons)).EndInit();
            this.pnButtons.ResumeLayout(false);
            this.pnButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnOutput)).EndInit();
            this.pnOutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnTitle)).EndInit();
            this.pnTitle.ResumeLayout(false);
            this.pnTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBaoCao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.Base.Controls.Grids.GridControl gridControlBaoCao;
        private Taxi.Controls.Base.Controls.Grids.GridView gridView1;
    }
}