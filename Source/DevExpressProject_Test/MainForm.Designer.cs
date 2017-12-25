namespace DevExpressProject_Test
{
    partial class MainForm
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
            this.inputCheckbox1 = new OneTaxi.Controls.Base.Inputs.InputCheckbox();
            this.myGroupBox1 = new Taxi.Controls.Base.Controls.ShGroupBox();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.inputSpin1 = new Taxi.Controls.Base.Inputs.InputSpin();
            this.inputDate2 = new Taxi.Controls.Base.Inputs.InputDate();
            this.inputDate1 = new Taxi.Controls.Base.Inputs.InputDate();
            this.gridKhachHen = new Taxi.Controls.Base.Controls.ShGridControl();
            this.gridDSDatHen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colThoiDiemTiepNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenKhachHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoDienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryCheckLapLai = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ucPanelCommand1 = new Taxi.Controls.Configs.UCPanelCommand();
            this.shButton1 = new Taxi.Controls.Base.Controls.ShButton();
            this.shButton2 = new Taxi.Controls.Base.Controls.ShButton();
            ((System.ComponentModel.ISupportInitialize)(this.inputCheckbox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputSpin1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputDate2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputDate2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputDate1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputDate1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridKhachHen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSDatHen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryCheckLapLai)).BeginInit();
            this.SuspendLayout();
            // 
            // inputCheckbox1
            // 
            this.inputCheckbox1.IsChangeText = false;
            this.inputCheckbox1.IsFocus = false;
            this.inputCheckbox1.KeyCommand = System.Windows.Forms.Keys.None;
            this.inputCheckbox1.Location = new System.Drawing.Point(12, 109);
            this.inputCheckbox1.Name = "inputCheckbox1";
            this.inputCheckbox1.Properties.Caption = "Thứ 2";
            this.inputCheckbox1.Size = new System.Drawing.Size(75, 19);
            this.inputCheckbox1.TabIndex = 5;
            // 
            // myGroupBox1
            // 
            this.myGroupBox1.Location = new System.Drawing.Point(14, 134);
            this.myGroupBox1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.myGroupBox1.Name = "myGroupBox1";
            this.myGroupBox1.Size = new System.Drawing.Size(167, 150);
            this.myGroupBox1.TabIndex = 53;
            this.myGroupBox1.Text = "Thông tin khách hàng";
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(31, 2);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(146, 13);
            this.shLabel1.TabIndex = 6;
            this.shLabel1.Text = "Không xóa các điều khiển này!";
            // 
            // inputSpin1
            // 
            this.inputSpin1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.inputSpin1.KeyCommand = System.Windows.Forms.Keys.None;
            this.inputSpin1.Location = new System.Drawing.Point(12, 34);
            this.inputSpin1.Name = "inputSpin1";
            this.inputSpin1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.inputSpin1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.inputSpin1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.inputSpin1.Properties.Mask.EditMask = "d";
            this.inputSpin1.Size = new System.Drawing.Size(54, 20);
            this.inputSpin1.TabIndex = 4;
            // 
            // inputDate2
            // 
            this.inputDate2.DateNowWhenLoad = true;
            this.inputDate2.EditValue = new System.DateTime(2016, 6, 4, 0, 0, 0, 0);
            this.inputDate2.IsChangeText = false;
            this.inputDate2.IsFocus = false;
            this.inputDate2.Location = new System.Drawing.Point(12, 83);
            this.inputDate2.Name = "inputDate2";
            this.inputDate2.Properties.DisplayFormat.FormatString = "HH:mm";
            this.inputDate2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.inputDate2.Properties.EditFormat.FormatString = "HH:mm";
            this.inputDate2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.inputDate2.Properties.Mask.EditMask = "HH:mm";
            this.inputDate2.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.inputDate2.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.inputDate2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.inputDate2.Properties.VistaTimeProperties.Mask.EditMask = "HH:mm";
            this.inputDate2.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = true;
            this.inputDate2.Size = new System.Drawing.Size(126, 20);
            this.inputDate2.TabIndex = 3;
            // 
            // inputDate1
            // 
            this.inputDate1.DateNowWhenLoad = true;
            this.inputDate1.EditValue = new System.DateTime(2016, 6, 17, 0, 0, 0, 0);
            this.inputDate1.IsChangeText = false;
            this.inputDate1.IsFocus = false;
            this.inputDate1.Location = new System.Drawing.Point(12, 57);
            this.inputDate1.Name = "inputDate1";
            this.inputDate1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.inputDate1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.inputDate1.Size = new System.Drawing.Size(126, 20);
            this.inputDate1.TabIndex = 2;
            // 
            // gridKhachHen
            // 
            this.gridKhachHen.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridKhachHen.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridKhachHen.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridKhachHen.EmbeddedNavigator.Buttons.EnabledAutoRepeat = false;
            this.gridKhachHen.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridKhachHen.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.gridKhachHen.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gridKhachHen.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.gridKhachHen.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gridKhachHen.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.gridKhachHen.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.gridKhachHen.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.gridKhachHen.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.gridKhachHen.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridKhachHen.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.gridKhachHen.Location = new System.Drawing.Point(200, 9);
            this.gridKhachHen.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridKhachHen.MainView = this.gridDSDatHen;
            this.gridKhachHen.Name = "gridKhachHen";
            this.gridKhachHen.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryCheckLapLai});
            this.gridKhachHen.Size = new System.Drawing.Size(624, 275);
            this.gridKhachHen.TabIndex = 54;
            this.gridKhachHen.UseEmbeddedNavigator = true;
            this.gridKhachHen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridDSDatHen});
            // 
            // gridDSDatHen
            // 
            this.gridDSDatHen.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridDSDatHen.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridDSDatHen.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridDSDatHen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colThoiDiemTiepNhan,
            this.colTenKhachHang,
            this.colDiaChi,
            this.colSoDienThoai});
            this.gridDSDatHen.GridControl = this.gridKhachHen;
            this.gridDSDatHen.IndicatorWidth = 32;
            this.gridDSDatHen.Name = "gridDSDatHen";
            this.gridDSDatHen.OptionsBehavior.Editable = false;
            this.gridDSDatHen.OptionsView.ShowGroupPanel = false;
            // 
            // colThoiDiemTiepNhan
            // 
            this.colThoiDiemTiepNhan.Caption = "Thời điểm tiếp nhận";
            this.colThoiDiemTiepNhan.FieldName = "ThoiDiem";
            this.colThoiDiemTiepNhan.Name = "colThoiDiemTiepNhan";
            this.colThoiDiemTiepNhan.OptionsColumn.AllowEdit = false;
            this.colThoiDiemTiepNhan.OptionsColumn.AllowFocus = false;
            this.colThoiDiemTiepNhan.OptionsFilter.AllowFilter = false;
            this.colThoiDiemTiepNhan.Visible = true;
            this.colThoiDiemTiepNhan.VisibleIndex = 0;
            this.colThoiDiemTiepNhan.Width = 53;
            // 
            // colTenKhachHang
            // 
            this.colTenKhachHang.Caption = "Tên khách hàng";
            this.colTenKhachHang.FieldName = "KhachHang";
            this.colTenKhachHang.Name = "colTenKhachHang";
            this.colTenKhachHang.OptionsColumn.AllowEdit = false;
            this.colTenKhachHang.OptionsColumn.AllowFocus = false;
            this.colTenKhachHang.OptionsFilter.AllowFilter = false;
            this.colTenKhachHang.Visible = true;
            this.colTenKhachHang.VisibleIndex = 1;
            this.colTenKhachHang.Width = 61;
            // 
            // colDiaChi
            // 
            this.colDiaChi.Caption = "Địa chỉ đón";
            this.colDiaChi.FieldName = "DiaChi";
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.OptionsColumn.AllowEdit = false;
            this.colDiaChi.OptionsColumn.AllowFocus = false;
            this.colDiaChi.OptionsFilter.AllowFilter = false;
            this.colDiaChi.Visible = true;
            this.colDiaChi.VisibleIndex = 2;
            this.colDiaChi.Width = 52;
            // 
            // colSoDienThoai
            // 
            this.colSoDienThoai.Caption = "Số điện thoại";
            this.colSoDienThoai.FieldName = "SoDienThoai";
            this.colSoDienThoai.Name = "colSoDienThoai";
            this.colSoDienThoai.OptionsColumn.AllowEdit = false;
            this.colSoDienThoai.OptionsColumn.AllowFocus = false;
            this.colSoDienThoai.OptionsFilter.AllowFilter = false;
            this.colSoDienThoai.Visible = true;
            this.colSoDienThoai.VisibleIndex = 3;
            this.colSoDienThoai.Width = 37;
            // 
            // repositoryCheckLapLai
            // 
            this.repositoryCheckLapLai.AutoHeight = false;
            this.repositoryCheckLapLai.Name = "repositoryCheckLapLai";
            // 
            // ucPanelCommand1
            // 
            this.ucPanelCommand1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ucPanelCommand1.Appearance.Options.UseBackColor = true;
            this.ucPanelCommand1.Location = new System.Drawing.Point(14, 331);
            this.ucPanelCommand1.Name = "ucPanelCommand1";
            this.ucPanelCommand1.Size = new System.Drawing.Size(810, 110);
            this.ucPanelCommand1.TabIndex = 55;
            // 
            // shButton1
            // 
            this.shButton1.Location = new System.Drawing.Point(431, 290);
            this.shButton1.Name = "shButton1";
            this.shButton1.Size = new System.Drawing.Size(78, 23);
            this.shButton1.TabIndex = 56;
            this.shButton1.Text = "Thay đổi Data";
            this.shButton1.Click += new System.EventHandler(this.shButton1_Click);
            // 
            // shButton2
            // 
            this.shButton2.Location = new System.Drawing.Point(515, 290);
            this.shButton2.Name = "shButton2";
            this.shButton2.Size = new System.Drawing.Size(78, 23);
            this.shButton2.TabIndex = 57;
            this.shButton2.Text = "Xóa Data";
            this.shButton2.Click += new System.EventHandler(this.shButton2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 646);
            this.Controls.Add(this.shButton2);
            this.Controls.Add(this.shButton1);
            this.Controls.Add(this.ucPanelCommand1);
            this.Controls.Add(this.gridKhachHen);
            this.Controls.Add(this.myGroupBox1);
            this.Controls.Add(this.shLabel1);
            this.Controls.Add(this.inputCheckbox1);
            this.Controls.Add(this.inputSpin1);
            this.Controls.Add(this.inputDate2);
            this.Controls.Add(this.inputDate1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inputCheckbox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myGroupBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputSpin1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputDate2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputDate2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputDate1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputDate1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridKhachHen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSDatHen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryCheckLapLai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Taxi.Controls.Base.Inputs.InputDate inputDate1;
        private Taxi.Controls.Base.Inputs.InputSpin inputSpin1;
        private Taxi.Controls.Base.Inputs.InputDate inputDate2;
        private OneTaxi.Controls.Base.Inputs.InputCheckbox inputCheckbox1;
        private Taxi.Controls.Base.Controls.ShLabel shLabel1;
        private Taxi.Controls.Base.Controls.ShGroupBox myGroupBox1;
        private Taxi.Controls.Base.Controls.ShGridControl gridKhachHen;
        private DevExpress.XtraGrid.Columns.GridColumn colThoiDiemTiepNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colTenKhachHang;
        private DevExpress.XtraGrid.Views.Grid.GridView gridDSDatHen;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn colSoDienThoai;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryCheckLapLai;
        private Taxi.Controls.Configs.UCPanelCommand ucPanelCommand1;
        private Taxi.Controls.Base.Controls.ShButton shButton1;
        private Taxi.Controls.Base.Controls.ShButton shButton2;
        
    }
}