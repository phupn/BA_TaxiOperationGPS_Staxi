namespace Taxi.Controls.Commands
{
    partial class ctrlListCommandHistory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlText = new Taxi.Controls.Base.Controls.ShPanel();
            this.lblInfo = new Taxi.Controls.Base.Controls.ShLabel();
            this.pnlGrid = new Taxi.Controls.Base.Controls.ShPanel();
            this.GridHistory = new Taxi.Controls.Base.Controls.ShGridControl();
            this.gvHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnIdCuocGoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBookId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCommandText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCommandId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPrivateCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlText)).BeginInit();
            this.pnlText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlText
            // 
            this.pnlText.Controls.Add(this.lblInfo);
            this.pnlText.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlText.LabelMessage = null;
            this.pnlText.Location = new System.Drawing.Point(0, 0);
            this.pnlText.Name = "pnlText";
            this.pnlText.Size = new System.Drawing.Size(437, 25);
            this.pnlText.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblInfo.Location = new System.Drawing.Point(5, 5);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(148, 16);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Lịch sử gửi lệnh cho lái xe";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.GridHistory);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.LabelMessage = null;
            this.pnlGrid.Location = new System.Drawing.Point(0, 25);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(437, 277);
            this.pnlGrid.TabIndex = 1;
            // 
            // GridHistory
            // 
            this.GridHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridHistory.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.GridHistory.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.GridHistory.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.GridHistory.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.GridHistory.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.GridHistory.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.GridHistory.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.GridHistory.Location = new System.Drawing.Point(2, 2);
            this.GridHistory.MainView = this.gvHistory;
            this.GridHistory.Name = "GridHistory";
            this.GridHistory.Size = new System.Drawing.Size(433, 273);
            this.GridHistory.TabIndex = 0;
            this.GridHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHistory});
            // 
            // gvHistory
            // 
            this.gvHistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnIdCuocGoi,
            this.gridColumnBookId,
            this.gridColumnCommandText,
            this.gridColumnCommandId,
            this.gridColumnPrivateCode,
            this.gridColumnResult,
            this.gridColumnCreatedDate,
            this.gridColumnCreatedBy});
            this.gvHistory.GridControl = this.GridHistory;
            this.gvHistory.Name = "gvHistory";
            this.gvHistory.OptionsBehavior.Editable = false;
            this.gvHistory.OptionsView.ColumnAutoWidth = false;
            this.gvHistory.OptionsView.ShowGroupPanel = false;
            this.gvHistory.OptionsView.ShowIndicator = false;
            this.gvHistory.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumnCreatedDate, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // gridColumnIdCuocGoi
            // 
            this.gridColumnIdCuocGoi.Caption = "Id cuộc gọi";
            this.gridColumnIdCuocGoi.FieldName = "IdCuocGoi";
            this.gridColumnIdCuocGoi.Name = "gridColumnIdCuocGoi";
            // 
            // gridColumnBookId
            // 
            this.gridColumnBookId.Caption = "BookId";
            this.gridColumnBookId.FieldName = "BookId";
            this.gridColumnBookId.Name = "gridColumnBookId";
            // 
            // gridColumnCommandText
            // 
            this.gridColumnCommandText.Caption = "Lệnh";
            this.gridColumnCommandText.FieldName = "CommandText";
            this.gridColumnCommandText.Name = "gridColumnCommandText";
            this.gridColumnCommandText.Visible = true;
            this.gridColumnCommandText.VisibleIndex = 1;
            this.gridColumnCommandText.Width = 154;
            // 
            // gridColumnCommandId
            // 
            this.gridColumnCommandId.Caption = "CommandId";
            this.gridColumnCommandId.FieldName = "CommandId";
            this.gridColumnCommandId.Name = "gridColumnCommandId";
            // 
            // gridColumnPrivateCode
            // 
            this.gridColumnPrivateCode.Caption = "Số xe";
            this.gridColumnPrivateCode.FieldName = "PrivateCode";
            this.gridColumnPrivateCode.Name = "gridColumnPrivateCode";
            this.gridColumnPrivateCode.Visible = true;
            this.gridColumnPrivateCode.VisibleIndex = 2;
            this.gridColumnPrivateCode.Width = 51;
            // 
            // gridColumnResult
            // 
            this.gridColumnResult.Caption = "Trạng thái";
            this.gridColumnResult.FieldName = "Result";
            this.gridColumnResult.Name = "gridColumnResult";
            this.gridColumnResult.Visible = true;
            this.gridColumnResult.VisibleIndex = 3;
            this.gridColumnResult.Width = 72;
            // 
            // gridColumnCreatedDate
            // 
            this.gridColumnCreatedDate.Caption = "Thời điểm";
            this.gridColumnCreatedDate.DisplayFormat.FormatString = "HH:mm:ss";
            this.gridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumnCreatedDate.FieldName = "CreatedDate";
            this.gridColumnCreatedDate.Name = "gridColumnCreatedDate";
            this.gridColumnCreatedDate.Visible = true;
            this.gridColumnCreatedDate.VisibleIndex = 0;
            this.gridColumnCreatedDate.Width = 71;
            // 
            // gridColumnCreatedBy
            // 
            this.gridColumnCreatedBy.Caption = "Người gửi";
            this.gridColumnCreatedBy.FieldName = "CreatedBy";
            this.gridColumnCreatedBy.Name = "gridColumnCreatedBy";
            this.gridColumnCreatedBy.Visible = true;
            this.gridColumnCreatedBy.VisibleIndex = 4;
            this.gridColumnCreatedBy.Width = 486;
            // 
            // ctrlListCommandHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlText);
            this.Name = "ctrlListCommandHistory";
            this.Size = new System.Drawing.Size(437, 302);
            this.Load += new System.EventHandler(this.ctrlListCommandHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlText)).EndInit();
            this.pnlText.ResumeLayout(false);
            this.pnlText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Controls.ShPanel pnlText;
        private Base.Controls.ShLabel lblInfo;
        private Base.Controls.ShPanel pnlGrid;
        private Base.Controls.ShGridControl GridHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHistory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnIdCuocGoi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBookId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCommandText;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCommandId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPrivateCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnResult;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCreatedBy;
    }
}
