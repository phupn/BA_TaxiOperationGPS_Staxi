namespace Taxi.Controls.DanhMuc
{
    partial class frmDanhMucKhachDungThe
    {
        public frmDanhMucKhachDungThe()
        {
            InitializeComponent();
        }
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deDenNgay = new Taxi.Controls.Base.Inputs.InputDate();
            this.deTuNgay = new Taxi.Controls.Base.Inputs.InputDate();
            this.shLabel7 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel6 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel3 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtMaThe = new Taxi.Controls.Base.Inputs.InputText();
            this.txtDiaChi = new Taxi.Controls.Base.Inputs.InputText();
            this.txtSDT = new Taxi.Controls.Base.Inputs.InputText();
            this.txtTenKH = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel5 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel4 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtMaKH = new Taxi.Controls.Base.Inputs.InputText();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblmsg = new System.Windows.Forms.Label();
            this.btnXoa = new Taxi.Controls.Base.Controls.ShButton();
            this.Sua = new Taxi.Controls.Base.Controls.ShButton();
            this.btnThem = new Taxi.Controls.Base.Controls.ShButton();
            this.btnTimKiem = new Taxi.Controls.Base.Controls.ShButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grdData = new Taxi.Controls.Base.Controls.ShGridControl();
            this.grvData = new Taxi.Controls.Base.Controls.ShGridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deDenNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTuNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaThe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKH.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 123);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deDenNgay);
            this.groupBox1.Controls.Add(this.deTuNgay);
            this.groupBox1.Controls.Add(this.shLabel7);
            this.groupBox1.Controls.Add(this.shLabel6);
            this.groupBox1.Controls.Add(this.shLabel2);
            this.groupBox1.Controls.Add(this.shLabel3);
            this.groupBox1.Controls.Add(this.txtMaThe);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.txtSDT);
            this.groupBox1.Controls.Add(this.txtTenKH);
            this.groupBox1.Controls.Add(this.shLabel5);
            this.groupBox1.Controls.Add(this.shLabel4);
            this.groupBox1.Controls.Add(this.shLabel1);
            this.groupBox1.Controls.Add(this.txtMaKH);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 123);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // deDenNgay
            // 
            this.deDenNgay.DateNowWhenLoad = true;
            this.deDenNgay.EditValue = null;
            this.deDenNgay.IsChangeText = false;
            this.deDenNgay.IsFocus = false;
            this.deDenNgay.Location = new System.Drawing.Point(403, 27);
            this.deDenNgay.Name = "deDenNgay";
            this.deDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDenNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.deDenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDenNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.deDenNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deDenNgay.Size = new System.Drawing.Size(100, 20);
            this.deDenNgay.TabIndex = 1;
            // 
            // deTuNgay
            // 
            this.deTuNgay.DateNowWhenLoad = true;
            this.deTuNgay.EditValue = null;
            this.deTuNgay.IsChangeText = false;
            this.deTuNgay.IsFocus = false;
            this.deTuNgay.Location = new System.Drawing.Point(239, 27);
            this.deTuNgay.Name = "deTuNgay";
            this.deTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTuNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.deTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deTuNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.deTuNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deTuNgay.Size = new System.Drawing.Size(100, 20);
            this.deTuNgay.TabIndex = 0;
            // 
            // shLabel7
            // 
            this.shLabel7.Location = new System.Drawing.Point(350, 80);
            this.shLabel7.Name = "shLabel7";
            this.shLabel7.Size = new System.Drawing.Size(32, 13);
            this.shLabel7.TabIndex = 1;
            this.shLabel7.Text = "Địa chỉ";
            // 
            // shLabel6
            // 
            this.shLabel6.Location = new System.Drawing.Point(186, 84);
            this.shLabel6.Name = "shLabel6";
            this.shLabel6.Size = new System.Drawing.Size(20, 13);
            this.shLabel6.TabIndex = 1;
            this.shLabel6.Text = "SĐT";
            // 
            // shLabel2
            // 
            this.shLabel2.Location = new System.Drawing.Point(350, 54);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(34, 13);
            this.shLabel2.TabIndex = 1;
            this.shLabel2.Text = "Tên KH";
            // 
            // shLabel3
            // 
            this.shLabel3.Location = new System.Drawing.Point(186, 59);
            this.shLabel3.Name = "shLabel3";
            this.shLabel3.Size = new System.Drawing.Size(30, 13);
            this.shLabel3.TabIndex = 1;
            this.shLabel3.Text = "Mã KH";
            // 
            // txtMaThe
            // 
            this.txtMaThe.IsChangeText = false;
            this.txtMaThe.IsFocus = false;
            this.txtMaThe.Location = new System.Drawing.Point(624, 54);
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.Properties.MaxLength = 50;
            this.txtMaThe.Size = new System.Drawing.Size(100, 20);
            this.txtMaThe.TabIndex = 2;
            this.txtMaThe.Visible = false;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.IsChangeText = false;
            this.txtDiaChi.IsFocus = false;
            this.txtDiaChi.Location = new System.Drawing.Point(403, 77);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Properties.MaxLength = 20;
            this.txtDiaChi.Size = new System.Drawing.Size(100, 20);
            this.txtDiaChi.TabIndex = 5;
            // 
            // txtSDT
            // 
            this.txtSDT.IsChangeText = false;
            this.txtSDT.IsFocus = false;
            this.txtSDT.Location = new System.Drawing.Point(239, 81);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Properties.MaxLength = 20;
            this.txtSDT.Size = new System.Drawing.Size(100, 20);
            this.txtSDT.TabIndex = 4;
            // 
            // txtTenKH
            // 
            this.txtTenKH.IsChangeText = false;
            this.txtTenKH.IsFocus = false;
            this.txtTenKH.Location = new System.Drawing.Point(403, 51);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Properties.MaxLength = 255;
            this.txtTenKH.Size = new System.Drawing.Size(100, 20);
            this.txtTenKH.TabIndex = 3;
            // 
            // shLabel5
            // 
            this.shLabel5.Location = new System.Drawing.Point(350, 30);
            this.shLabel5.Name = "shLabel5";
            this.shLabel5.Size = new System.Drawing.Size(47, 13);
            this.shLabel5.TabIndex = 1;
            this.shLabel5.Text = "Đến ngày";
            // 
            // shLabel4
            // 
            this.shLabel4.Location = new System.Drawing.Point(186, 30);
            this.shLabel4.Name = "shLabel4";
            this.shLabel4.Size = new System.Drawing.Size(40, 13);
            this.shLabel4.TabIndex = 1;
            this.shLabel4.Text = "Từ ngày";
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(571, 58);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(33, 13);
            this.shLabel1.TabIndex = 1;
            this.shLabel1.Text = "Mã thẻ";
            this.shLabel1.Visible = false;
            // 
            // txtMaKH
            // 
            this.txtMaKH.IsChangeText = false;
            this.txtMaKH.IsFocus = false;
            this.txtMaKH.Location = new System.Drawing.Point(239, 55);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Properties.MaxLength = 50;
            this.txtMaKH.Size = new System.Drawing.Size(100, 20);
            this.txtMaKH.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblmsg);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.Sua);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Controls.Add(this.btnTimKiem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(730, 56);
            this.panel2.TabIndex = 0;
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.ForeColor = System.Drawing.Color.Red;
            this.lblmsg.Location = new System.Drawing.Point(206, 37);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(0, 13);
            this.lblmsg.TabIndex = 4;
            // 
            // btnXoa
            // 
            this.btnXoa.KeyCommand = System.Windows.Forms.Keys.F7;
            this.btnXoa.Location = new System.Drawing.Point(449, 7);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa (F7)";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // Sua
            // 
            this.Sua.KeyCommand = System.Windows.Forms.Keys.F5;
            this.Sua.Location = new System.Drawing.Point(368, 7);
            this.Sua.Name = "Sua";
            this.Sua.Size = new System.Drawing.Size(75, 23);
            this.Sua.TabIndex = 2;
            this.Sua.Text = "Sửa (F5)";
            this.Sua.Click += new System.EventHandler(this.Sua_Click);
            // 
            // btnThem
            // 
            this.btnThem.KeyCommand = System.Windows.Forms.Keys.F1;
            this.btnThem.Location = new System.Drawing.Point(287, 7);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm (F1)";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.KeyCommand = System.Windows.Forms.Keys.F3;
            this.btnTimKiem.Location = new System.Drawing.Point(206, 7);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 0;
            this.btnTimKiem.Text = "Tìm kiếm (F3)";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grdData);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 179);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(730, 351);
            this.panel3.TabIndex = 2;
            // 
            // grdData
            // 
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.grdData.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.grdData.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.grdData.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.grdData.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.grdData.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.grdData.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.grdData.Location = new System.Drawing.Point(0, 0);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(730, 351);
            this.grdData.TabIndex = 0;
            this.grdData.UseEmbeddedNavigator = true;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // grvData
            // 
            this.grvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvData.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn5,
            this.gridColumn4,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn7});
            this.grvData.GridControl = this.grdData;
            this.grvData.IndicatorWidth = 35;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.Editable = false;
            this.grvData.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Mã thẻ";
            this.gridColumn6.FieldName = "MaThe";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Width = 95;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Từ ngày";
            this.gridColumn5.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn5.FieldName = "TuNgay";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 92;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Đến ngày";
            this.gridColumn4.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "DenNgay";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 95;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã khách hàng";
            this.gridColumn1.FieldName = "MaKhachHang";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 101;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên khách hàng";
            this.gridColumn2.FieldName = "TenKhachHang";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 144;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Số điện thoại";
            this.gridColumn3.FieldName = "SoDienThoai";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 166;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Địa chỉ";
            this.gridColumn7.FieldName = "DiaChi";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // frmDanhMucKhachDungThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 530);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmDanhMucKhachDungThe";
            this.Text = "Danh mục khách dùng thẻ";
            this.Load += new System.EventHandler(this.frmDanhMucKhachDungThe_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deDenNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTuNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaThe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKH.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Base.Controls.ShGridControl grdData;
        private Base.Controls.ShGridView grvData;
        private Base.Controls.ShButton btnXoa;
        private Base.Controls.ShButton Sua;
        private Base.Controls.ShButton btnThem;
        private Base.Controls.ShButton btnTimKiem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private Base.Controls.ShLabel shLabel3;
        private Base.Controls.ShLabel shLabel2;
        private Base.Controls.ShLabel shLabel1;
        private Base.Inputs.InputText txtMaKH;
        private Base.Inputs.InputText txtTenKH;
        private Base.Inputs.InputText txtMaThe;
        private System.Windows.Forms.GroupBox groupBox1;
        private Base.Inputs.InputDate deDenNgay;
        private Base.Inputs.InputDate deTuNgay;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private Base.Controls.ShLabel shLabel6;
        private Base.Inputs.InputText txtSDT;
        private Base.Controls.ShLabel shLabel5;
        private Base.Controls.ShLabel shLabel4;
        private System.Windows.Forms.Label lblmsg;
        private Base.Controls.ShLabel shLabel7;
        private Base.Inputs.InputText txtDiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
    }
}