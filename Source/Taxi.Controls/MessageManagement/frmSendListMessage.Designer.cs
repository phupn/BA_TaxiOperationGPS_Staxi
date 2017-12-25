namespace Taxi.Controls.MessageManagement
{
    partial class frmSendListMessage
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
            this.myPanelControl1 = new Taxi.Controls.BanCo.MyPanelControl();
            this.myPanelControl3 = new Taxi.Controls.BanCo.MyPanelControl();
            this.gridMessage = new Taxi.Controls.Base.Controls.ShGridControl();
            this.gridViewMessage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkChon = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryCheckLapLai = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.statusBar1 = new Taxi.Controls.Base.Controls.Ribbons.StatusBar();
            this.barStatusSendMsg = new DevExpress.XtraBars.BarStaticItem();
            this.myPanelControl2 = new Taxi.Controls.BanCo.MyPanelControl();
            this.btnExit = new Taxi.Controls.Base.Controls.ShButton();
            this.btnSendMessage = new Taxi.Controls.Base.Controls.ShButton();
            this.btnImportByExcel = new Taxi.Controls.Base.Controls.ShButton();
            this.btnExcelSample = new Taxi.Controls.Base.Controls.ShButton();
            this.cboChonNguoiNhan = new Taxi.Controls.Base.Inputs.InputLookUp();
            this.chkAll = new Taxi.Controls.Base.Inputs.InputCheckbox();
            this.txtNoiDung = new Taxi.Controls.Base.Inputs.InputMemoEdit();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myPanelControl1)).BeginInit();
            this.myPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myPanelControl3)).BeginInit();
            this.myPanelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryCheckLapLai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myPanelControl2)).BeginInit();
            this.myPanelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboChonNguoiNhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            // 
            // 
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStatusSendMsg});
            this.ribbon.MaxItemId = 3;
            this.ribbon.Size = new System.Drawing.Size(733, 27);
            this.ribbon.StatusBar = this.statusBar1;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // myPanelControl1
            // 
            this.myPanelControl1.Controls.Add(this.myPanelControl3);
            this.myPanelControl1.Controls.Add(this.myPanelControl2);
            this.myPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myPanelControl1.Location = new System.Drawing.Point(0, 27);
            this.myPanelControl1.Name = "myPanelControl1";
            this.myPanelControl1.Size = new System.Drawing.Size(733, 505);
            this.myPanelControl1.TabIndex = 1;
            // 
            // myPanelControl3
            // 
            this.myPanelControl3.Controls.Add(this.gridMessage);
            this.myPanelControl3.Controls.Add(this.statusBar1);
            this.myPanelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myPanelControl3.Location = new System.Drawing.Point(2, 132);
            this.myPanelControl3.Name = "myPanelControl3";
            this.myPanelControl3.Size = new System.Drawing.Size(729, 371);
            this.myPanelControl3.TabIndex = 2;
            // 
            // gridMessage
            // 
            this.gridMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMessage.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridMessage.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridMessage.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridMessage.EmbeddedNavigator.Buttons.EnabledAutoRepeat = false;
            this.gridMessage.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridMessage.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.gridMessage.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gridMessage.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.gridMessage.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gridMessage.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.gridMessage.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.gridMessage.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.gridMessage.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.gridMessage.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridMessage.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.gridMessage.Location = new System.Drawing.Point(2, 2);
            this.gridMessage.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridMessage.MainView = this.gridViewMessage;
            this.gridMessage.Name = "gridMessage";
            this.gridMessage.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryCheckLapLai,
            this.chkChon});
            this.gridMessage.Size = new System.Drawing.Size(725, 340);
            this.gridMessage.TabIndex = 55;
            this.gridMessage.UseEmbeddedNavigator = true;
            this.gridMessage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMessage});
            // 
            // gridViewMessage
            // 
            this.gridViewMessage.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewMessage.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewMessage.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridViewMessage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridViewMessage.GridControl = this.gridMessage;
            this.gridViewMessage.Name = "gridViewMessage";
            this.gridViewMessage.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Chọn";
            this.gridColumn2.ColumnEdit = this.chkChon;
            this.gridColumn2.FieldName = "Chon";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Tag = "";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // chkChon
            // 
            this.chkChon.AutoHeight = false;
            this.chkChon.Name = "chkChon";
            this.chkChon.CheckedChanged += new System.EventHandler(this.chkChon_CheckedChanged);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "SĐT";
            this.gridColumn3.FieldName = "SoDienThoai";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tên người nhận";
            this.gridColumn4.FieldName = "TenNhanVien";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Thông tin thêm";
            this.gridColumn5.FieldName = "ThongTinThem";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // repositoryCheckLapLai
            // 
            this.repositoryCheckLapLai.AutoHeight = false;
            this.repositoryCheckLapLai.Name = "repositoryCheckLapLai";
            // 
            // statusBar1
            // 
            this.statusBar1.ItemLinks.Add(this.barStatusSendMsg);
            this.statusBar1.Location = new System.Drawing.Point(2, 342);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Ribbon = this.ribbon;
            this.statusBar1.Size = new System.Drawing.Size(725, 27);
            // 
            // barStatusSendMsg
            // 
            this.barStatusSendMsg.Caption = "Trạng thái";
            this.barStatusSendMsg.Glyph = global::Taxi.Controls.Properties.Resources.icon_dot_green;
            this.barStatusSendMsg.GlyphDisabled = global::Taxi.Controls.Properties.Resources.legendIcon;
            this.barStatusSendMsg.Id = 2;
            this.barStatusSendMsg.Name = "barStatusSendMsg";
            this.barStatusSendMsg.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // myPanelControl2
            // 
            this.myPanelControl2.Controls.Add(this.btnExit);
            this.myPanelControl2.Controls.Add(this.btnSendMessage);
            this.myPanelControl2.Controls.Add(this.btnImportByExcel);
            this.myPanelControl2.Controls.Add(this.btnExcelSample);
            this.myPanelControl2.Controls.Add(this.cboChonNguoiNhan);
            this.myPanelControl2.Controls.Add(this.chkAll);
            this.myPanelControl2.Controls.Add(this.txtNoiDung);
            this.myPanelControl2.Controls.Add(this.shLabel1);
            this.myPanelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.myPanelControl2.Location = new System.Drawing.Point(2, 2);
            this.myPanelControl2.Name = "myPanelControl2";
            this.myPanelControl2.Size = new System.Drawing.Size(729, 130);
            this.myPanelControl2.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(493, 85);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(97, 27);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(407, 85);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(80, 27);
            this.btnSendMessage.TabIndex = 4;
            this.btnSendMessage.Text = "Gửi tin";
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // btnImportByExcel
            // 
            this.btnImportByExcel.Location = new System.Drawing.Point(493, 52);
            this.btnImportByExcel.Name = "btnImportByExcel";
            this.btnImportByExcel.Size = new System.Drawing.Size(97, 27);
            this.btnImportByExcel.TabIndex = 7;
            this.btnImportByExcel.Text = "Nhập từ Excel";
            this.btnImportByExcel.Click += new System.EventHandler(this.btnImportByExcel_Click);
            // 
            // btnExcelSample
            // 
            this.btnExcelSample.Location = new System.Drawing.Point(407, 52);
            this.btnExcelSample.Name = "btnExcelSample";
            this.btnExcelSample.Size = new System.Drawing.Size(80, 27);
            this.btnExcelSample.TabIndex = 6;
            this.btnExcelSample.Text = "Mẫu Excel";
            this.btnExcelSample.Click += new System.EventHandler(this.btnExcelSample_Click);
            // 
            // cboChonNguoiNhan
            // 
            this.cboChonNguoiNhan.IsChangeText = false;
            this.cboChonNguoiNhan.IsFocus = false;
            this.cboChonNguoiNhan.Location = new System.Drawing.Point(407, 12);
            this.cboChonNguoiNhan.MenuManager = this.ribbon;
            this.cboChonNguoiNhan.Name = "cboChonNguoiNhan";
            this.cboChonNguoiNhan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboChonNguoiNhan.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Display", 30, "Danh sách người nhận"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Giá trị")});
            this.cboChonNguoiNhan.Properties.NullText = "";
            this.cboChonNguoiNhan.Size = new System.Drawing.Size(301, 20);
            this.cboChonNguoiNhan.TabIndex = 2;
            this.cboChonNguoiNhan.Tag = "Chọn danh sách người nhận";
            this.cboChonNguoiNhan.ToolTipTitle = "Chọn danh sách người nhận";
            this.cboChonNguoiNhan.EditValueChanged += new System.EventHandler(this.cboChonNguoiNhan_EditValueChanged);
            // 
            // chkAll
            // 
            this.chkAll.IsChangeText = false;
            this.chkAll.IsFocus = false;
            this.chkAll.KeyCommand = System.Windows.Forms.Keys.None;
            this.chkAll.Location = new System.Drawing.Point(3, 106);
            this.chkAll.MenuManager = this.ribbon;
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "Chọn tất cả";
            this.chkAll.Size = new System.Drawing.Size(92, 19);
            this.chkAll.TabIndex = 3;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.EditValue = "";
            this.txtNoiDung.IsChangeText = false;
            this.txtNoiDung.IsFocus = false;
            this.txtNoiDung.Location = new System.Drawing.Point(108, 12);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(293, 112);
            this.txtNoiDung.TabIndex = 1;
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(5, 15);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(88, 13);
            this.shLabel1.TabIndex = 1;
            this.shLabel1.Text = "Nội dung tin nhắn:";
            // 
            // frmSendListMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 532);
            this.Controls.Add(this.myPanelControl1);
            this.Name = "frmSendListMessage";
            this.StatusBar = this.statusBar1;
            this.Text = "Gửi tin nhắn";
            this.Load += new System.EventHandler(this.frmSendListMessage_Load);
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.myPanelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myPanelControl1)).EndInit();
            this.myPanelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myPanelControl3)).EndInit();
            this.myPanelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryCheckLapLai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myPanelControl2)).EndInit();
            this.myPanelControl2.ResumeLayout(false);
            this.myPanelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboChonNguoiNhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Controls.Ribbons.StatusBar statusBar1;
        private BanCo.MyPanelControl myPanelControl1;
        private BanCo.MyPanelControl myPanelControl3;
        private BanCo.MyPanelControl myPanelControl2;
        private Base.Controls.ShLabel shLabel1;
        private Base.Inputs.InputCheckbox chkAll;
        private Base.Inputs.InputMemoEdit txtNoiDung;
        private Base.Controls.ShButton btnExit;
        private Base.Controls.ShButton btnSendMessage;
        private Base.Controls.ShButton btnImportByExcel;
        private Base.Controls.ShButton btnExcelSample;
        private Base.Inputs.InputLookUp cboChonNguoiNhan;
        private Base.Controls.ShGridControl gridMessage;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMessage;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryCheckLapLai;
        private DevExpress.XtraBars.BarStaticItem barStatusSendMsg;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkChon;
    }
}