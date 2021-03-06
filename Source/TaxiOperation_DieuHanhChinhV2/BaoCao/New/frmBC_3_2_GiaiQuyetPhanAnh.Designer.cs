namespace TaxiOperation_DieuHanhChinh
{
    partial class frmBC_3_2_GiaiQuyetPhanAnh
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
            this.components = new System.ComponentModel.Container();
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_3_2_GiaiQuyetPhanAnh));
            this.label1 = new System.Windows.Forms.Label();
            this.grdBaoCaoGiaiQuyet = new Janus.Windows.GridEX.GridEX();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.txtMaThongTin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbLoaiPhanAnh = new Janus.Windows.EditControls.UIComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboCongTy = new Janus.Windows.EditControls.UIComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaoCaoGiaiQuyet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(337, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO GIẢI QUYẾT THÔNG TIN KHÁCH HÀNG PHẢN ÁNH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdBaoCaoGiaiQuyet
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdBaoCaoGiaiQuyet.DesignTimeLayout = gridEXLayout1;
            this.grdBaoCaoGiaiQuyet.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.grdBaoCaoGiaiQuyet.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdBaoCaoGiaiQuyet.GroupByBoxVisible = false;
            this.grdBaoCaoGiaiQuyet.Location = new System.Drawing.Point(1, 197);
            this.grdBaoCaoGiaiQuyet.Name = "grdBaoCaoGiaiQuyet";
            this.grdBaoCaoGiaiQuyet.SaveSettings = false;
            this.grdBaoCaoGiaiQuyet.Size = new System.Drawing.Size(1175, 485);
            this.grdBaoCaoGiaiQuyet.TabIndex = 2;
            this.grdBaoCaoGiaiQuyet.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdBaoCaoGiaiQuyet_FormattingRow);
            // 
            // calTuNgay
            // 
            this.calTuNgay.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.calTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2011, 5, 1, 0, 0, 0, 0);
            this.calTuNgay.DropDownCalendar.Name = "";
            this.calTuNgay.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calTuNgay.Location = new System.Drawing.Point(385, 39);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(148, 23);
            this.calTuNgay.TabIndex = 0;
            this.calTuNgay.ValueChanged += new System.EventHandler(this.calTuNgay_ValueChanged);
            // 
            // calDenNgay
            // 
            this.calDenNgay.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.calDenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calDenNgay.DropDownCalendar.FirstMonth = new System.DateTime(2011, 5, 1, 0, 0, 0, 0);
            this.calDenNgay.DropDownCalendar.Name = "";
            this.calDenNgay.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calDenNgay.Location = new System.Drawing.Point(610, 39);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(150, 23);
            this.calDenNgay.TabIndex = 1;
            this.calDenNgay.ValueChanged += new System.EventHandler(this.calDenNgay_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(321, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Từ ngày ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(543, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Đến ngày ";
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.grdBaoCaoGiaiQuyet;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.gridEXPrintDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // gridEXPrintDocument1
            // 
            this.gridEXPrintDocument1.GridEX = this.grdBaoCaoGiaiQuyet;
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.gridEXPrintDocument1;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Enabled = false;
            this.btnExportExcel.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(559, 156);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(98, 26);
            this.btnExportExcel.TabIndex = 6;
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(459, 156);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 26);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(309, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Điện thoại";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(539, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tên KH";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(294, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Mã thông tin";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDienThoai.Location = new System.Drawing.Point(385, 68);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(148, 23);
            this.txtDienThoai.TabIndex = 2;
            this.txtDienThoai.TextChanged += new System.EventHandler(this.txtDienThoai_TextChanged);
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKhachHang.Location = new System.Drawing.Point(610, 68);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(203, 23);
            this.txtTenKhachHang.TabIndex = 3;
            this.txtTenKhachHang.TextChanged += new System.EventHandler(this.txtTenKhachHang_TextChanged);
            // 
            // txtMaThongTin
            // 
            this.txtMaThongTin.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaThongTin.Location = new System.Drawing.Point(385, 95);
            this.txtMaThongTin.Name = "txtMaThongTin";
            this.txtMaThongTin.Size = new System.Drawing.Size(148, 23);
            this.txtMaThongTin.TabIndex = 4;
            this.txtMaThongTin.TextChanged += new System.EventHandler(this.txtMaThongTin_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(543, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(261, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "(Nhập \'*\' tìm tất cả bản ghi có mã thông tin)";
            // 
            // cbLoaiPhanAnh
            // 
            this.cbLoaiPhanAnh.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cbLoaiPhanAnh.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoaiPhanAnh.Location = new System.Drawing.Point(385, 124);
            this.cbLoaiPhanAnh.Name = "cbLoaiPhanAnh";
            this.cbLoaiPhanAnh.Size = new System.Drawing.Size(150, 23);
            this.cbLoaiPhanAnh.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(273, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "&Loại phản ánh(*) ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboCongTy
            // 
            this.cboCongTy.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboCongTy.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCongTy.Location = new System.Drawing.Point(610, 124);
            this.cboCongTy.Name = "cboCongTy";
            this.cboCongTy.Size = new System.Drawing.Size(203, 23);
            this.cboCongTy.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(540, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "Công ty";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmBC_3_2_GiaiQuyetPhanAnh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 685);
            this.Controls.Add(this.cboCongTy);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbLoaiPhanAnh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMaThongTin);
            this.Controls.Add(this.txtTenKhachHang);
            this.Controls.Add(this.txtDienThoai);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calDenNgay);
            this.Controls.Add(this.calTuNgay);
            this.Controls.Add(this.grdBaoCaoGiaiQuyet);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_3_2_GiaiQuyetPhanAnh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo cáo giải quyết thông tin khách hàng phản ánh";
            this.Load += new System.EventHandler(this.frmBC_3_2_GiaiQuyetPhanAnh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBaoCaoGiaiQuyet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo calDenNgay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.GridEX.GridEX grdBaoCaoGiaiQuyet;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.TextBox txtMaThongTin;
        private System.Windows.Forms.Label label7;
        private Janus.Windows.EditControls.UIComboBox cbLoaiPhanAnh;
        private System.Windows.Forms.Label label8;
        private Janus.Windows.EditControls.UIComboBox cboCongTy;
        private System.Windows.Forms.Label label9;
    }
}