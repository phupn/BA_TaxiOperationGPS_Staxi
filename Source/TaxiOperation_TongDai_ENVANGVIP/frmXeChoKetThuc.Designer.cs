namespace TaxiOperation_TongDai_ENVANGVIP
{
    partial class frmXeChoKetThuc
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
            this.shgXe = new Taxi.Controls.Base.Controls.ShGridControl();
            this.gridXe = new Taxi.Controls.Base.Controls.ShGridView();
            this.SoHieuXe = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.shgXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridXe)).BeginInit();
            this.SuspendLayout();
            // 
            // shgXe
            // 
            this.shgXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shgXe.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.shgXe.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.shgXe.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.shgXe.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.shgXe.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.shgXe.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.shgXe.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.shgXe.Location = new System.Drawing.Point(0, 0);
            this.shgXe.MainView = this.gridXe;
            this.shgXe.Name = "shgXe";
            this.shgXe.Size = new System.Drawing.Size(284, 261);
            this.shgXe.TabIndex = 2;
            this.shgXe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridXe});
            // 
            // gridXe
            // 
            this.gridXe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SoHieuXe});
            this.gridXe.GridControl = this.shgXe;
            this.gridXe.IndicatorWidth = 35;
            this.gridXe.Name = "gridXe";
            this.gridXe.OptionsFind.AllowFindPanel = false;
            this.gridXe.OptionsNavigation.UseOfficePageNavigation = false;
            this.gridXe.OptionsView.ShowGroupPanel = false;
            this.gridXe.OptionsView.ShowIndicator = false;
            // 
            // SoHieuXe
            // 
            this.SoHieuXe.Caption = "Xe";
            this.SoHieuXe.FieldName = "SoHieuXe";
            this.SoHieuXe.Name = "SoHieuXe";
            this.SoHieuXe.OptionsColumn.AllowEdit = false;
            this.SoHieuXe.Visible = true;
            this.SoHieuXe.VisibleIndex = 0;
            // 
            // frmXeChoKetThuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.shgXe);
            this.Name = "frmXeChoKetThuc";
            this.Text = "Xe chờ kết thúc";
            ((System.ComponentModel.ISupportInitialize)(this.shgXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridXe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.Base.Controls.ShGridControl shgXe;
        private Taxi.Controls.Base.Controls.ShGridView gridXe;
        private DevExpress.XtraGrid.Columns.GridColumn SoHieuXe;
    }
}