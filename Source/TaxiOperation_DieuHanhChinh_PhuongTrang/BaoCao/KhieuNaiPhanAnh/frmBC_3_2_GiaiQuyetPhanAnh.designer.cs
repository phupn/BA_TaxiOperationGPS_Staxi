namespace Taxi.GUI
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportExcelNew = new Janus.Windows.EditControls.UIButton();
            this.chkDaGiaiQuyet = new System.Windows.Forms.CheckBox();
            this.chkChuaGiaiQuyet = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSoDT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaoCaoGiaiQuyet)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(349, 11);
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
            this.grdBaoCaoGiaiQuyet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBaoCaoGiaiQuyet.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.grdBaoCaoGiaiQuyet.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdBaoCaoGiaiQuyet.GroupByBoxVisible = false;
            this.grdBaoCaoGiaiQuyet.Location = new System.Drawing.Point(0, 0);
            this.grdBaoCaoGiaiQuyet.Name = "grdBaoCaoGiaiQuyet";
            this.grdBaoCaoGiaiQuyet.SaveSettings = false;
            this.grdBaoCaoGiaiQuyet.Size = new System.Drawing.Size(1194, 382);
            this.grdBaoCaoGiaiQuyet.TabIndex = 2;
            this.grdBaoCaoGiaiQuyet.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdBaoCaoGiaiQuyet_FormattingRow);
            // 
            // calTuNgay
            // 
            this.calTuNgay.CustomFormat = "dd/MM/yyyy";
            this.calTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2011, 5, 1, 0, 0, 0, 0);
            this.calTuNgay.DropDownCalendar.Name = "";
            this.calTuNgay.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calTuNgay.Location = new System.Drawing.Point(393, 41);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(110, 23);
            this.calTuNgay.TabIndex = 4;
            this.calTuNgay.ValueChanged += new System.EventHandler(this.calTuNgay_ValueChanged);
            // 
            // calDenNgay
            // 
            this.calDenNgay.CustomFormat = "dd/MM/yyyy";
            this.calDenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calDenNgay.DropDownCalendar.FirstMonth = new System.DateTime(2011, 5, 1, 0, 0, 0, 0);
            this.calDenNgay.DropDownCalendar.Name = "";
            this.calDenNgay.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calDenNgay.Location = new System.Drawing.Point(665, 41);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(110, 23);
            this.calDenNgay.TabIndex = 5;
            this.calDenNgay.ValueChanged += new System.EventHandler(this.calDenNgay_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(326, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Từ ngày ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(590, 44);
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
            this.btnExportExcel.Location = new System.Drawing.Point(665, 128);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(98, 26);
            this.btnExportExcel.TabIndex = 9;
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(565, 128);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 26);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExportExcelNew);
            this.panel1.Controls.Add(this.chkDaGiaiQuyet);
            this.panel1.Controls.Add(this.chkChuaGiaiQuyet);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtSoDT);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtDiaChi);
            this.panel1.Controls.Add(this.txtTenKH);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Controls.Add(this.calTuNgay);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.calDenNgay);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1194, 158);
            this.panel1.TabIndex = 10;
            // 
            // btnExportExcelNew
            // 
            this.btnExportExcelNew.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcelNew.Location = new System.Drawing.Point(769, 128);
            this.btnExportExcelNew.Name = "btnExportExcelNew";
            this.btnExportExcelNew.Size = new System.Drawing.Size(98, 26);
            this.btnExportExcelNew.TabIndex = 10;
            this.btnExportExcelNew.Text = "Xuất Biên Bản";
            this.btnExportExcelNew.Click += new System.EventHandler(this.btnExportExcelNew_Click);
            // 
            // chkDaGiaiQuyet
            // 
            this.chkDaGiaiQuyet.AutoSize = true;
            this.chkDaGiaiQuyet.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDaGiaiQuyet.Location = new System.Drawing.Point(393, 126);
            this.chkDaGiaiQuyet.Name = "chkDaGiaiQuyet";
            this.chkDaGiaiQuyet.Size = new System.Drawing.Size(105, 21);
            this.chkDaGiaiQuyet.TabIndex = 29;
            this.chkDaGiaiQuyet.Text = "Đã giải quyết";
            this.chkDaGiaiQuyet.UseVisualStyleBackColor = true;
            // 
            // chkChuaGiaiQuyet
            // 
            this.chkChuaGiaiQuyet.AutoSize = true;
            this.chkChuaGiaiQuyet.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChuaGiaiQuyet.Location = new System.Drawing.Point(393, 99);
            this.chkChuaGiaiQuyet.Name = "chkChuaGiaiQuyet";
            this.chkChuaGiaiQuyet.Size = new System.Drawing.Size(119, 21);
            this.chkChuaGiaiQuyet.TabIndex = 28;
            this.chkChuaGiaiQuyet.Text = "Chưa giải quyết";
            this.chkChuaGiaiQuyet.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(320, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 16);
            this.label7.TabIndex = 27;
            this.label7.Text = "Trạng thái";
            // 
            // txtSoDT
            // 
            this.txtSoDT.Location = new System.Drawing.Point(393, 70);
            this.txtSoDT.MaxLength = 14;
            this.txtSoDT.Name = "txtSoDT";
            this.txtSoDT.Size = new System.Drawing.Size(131, 23);
            this.txtSoDT.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(302, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "Số điện thoại";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(554, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tên &khách hàng";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(606, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "&Địa chỉ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(665, 99);
            this.txtDiaChi.MaxLength = 500;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(432, 23);
            this.txtDiaChi.TabIndex = 22;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(665, 70);
            this.txtTenKH.MaxLength = 100;
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(285, 23);
            this.txtTenKH.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdBaoCaoGiaiQuyet);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 158);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1194, 382);
            this.panel2.TabIndex = 11;
            // 
            // frmBC_3_2_GiaiQuyetPhanAnh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 540);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBC_3_2_GiaiQuyetPhanAnh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BÁO CÁO KHÁCH HÀNG PHẢN ÁNH";
            this.Load += new System.EventHandler(this.frmBC_3_2_GiaiQuyetPhanAnh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBaoCaoGiaiQuyet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtSoDT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkChuaGiaiQuyet;
        private System.Windows.Forms.CheckBox chkDaGiaiQuyet;
        private Janus.Windows.EditControls.UIButton btnExportExcelNew;
    }
}