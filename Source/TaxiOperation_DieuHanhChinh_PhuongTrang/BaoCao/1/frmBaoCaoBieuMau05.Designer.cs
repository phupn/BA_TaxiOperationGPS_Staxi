namespace Taxi.GUI.BaoCao
{
    partial class frmBaoCaoBieuMau5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCaoBieuMau5));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnPrint = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.gridDienThoai = new Janus.Windows.GridEX.GridEX();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.editVung = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.editDienThoai = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label12 = new System.Windows.Forms.Label();
            this.timeThoiGianDieuXe = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.timeThoiGianDonKhach = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.timeThoiGianChuyenTongDai = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.chkMoiGioi = new Janus.Windows.EditControls.UICheckBox();
            this.chkVangLai = new Janus.Windows.EditControls.UICheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridDienThoai)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(313, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO CUỘC GỌI ĐÓN ĐƯỢC KHÁCH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Từ ngày";
            // 
            // calTuNgay
            // 
            this.calTuNgay.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.calTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.calTuNgay.DropDownCalendar.Name = "";
            this.calTuNgay.Location = new System.Drawing.Point(328, 43);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(141, 20);
            this.calTuNgay.TabIndex = 2;
            this.calTuNgay.ValueChanged += new System.EventHandler(this.calTuNgay_ValueChanged);
            // 
            // calDenNgay
            // 
            this.calDenNgay.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.calDenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calDenNgay.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.calDenNgay.DropDownCalendar.Name = "";
            this.calDenNgay.Location = new System.Drawing.Point(565, 41);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(141, 20);
            this.calDenNgay.TabIndex = 4;
            this.calDenNgay.ValueChanged += new System.EventHandler(this.calDenNgay_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(504, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Đến ngày";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(549, 188);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 8;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Printer;
            this.btnPrint.Location = new System.Drawing.Point(485, 188);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(62, 26);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "&In";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(404, 188);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.gridDienThoai;
            // 
            // gridDienThoai
            // 
            this.gridDienThoai.AllowColumnDrag = false;
            this.gridDienThoai.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridDienThoai.AutomaticSort = false;
            this.gridDienThoai.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
            this.gridDienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.gridDienThoai.GroupByBoxVisible = false;
            this.gridDienThoai.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            gridEXLayout1.IsCurrentLayout = true;
            gridEXLayout1.Key = "1";
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridDienThoai.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gridEXLayout1});
            this.gridDienThoai.Location = new System.Drawing.Point(0, 221);
            this.gridDienThoai.Margin = new System.Windows.Forms.Padding(2);
            this.gridDienThoai.Name = "gridDienThoai";
            this.gridDienThoai.PreviewRowFormatStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridDienThoai.RowFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.RaisedLight;
            this.gridDienThoai.RowFormatStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridDienThoai.RowFormatStyle.FontSize = 9F;
            this.gridDienThoai.RowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Empty;
            this.gridDienThoai.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridDienThoai.RowHeaderFormatStyle.Font = new System.Drawing.Font("Tahoma", 6F);
            this.gridDienThoai.RowHeaderFormatStyle.FontSize = 10F;
            this.gridDienThoai.RowHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridDienThoai.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridDienThoai.SaveSettings = false;
            this.gridDienThoai.Size = new System.Drawing.Size(1032, 493);
            this.gridDienThoai.TabIndex = 24;
            this.gridDienThoai.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.gridDienThoai.TableSpacing = 8;
            this.gridDienThoai.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.gridEXPrintDocument1;
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
            // editVung
            // 
            this.editVung.Location = new System.Drawing.Point(413, 68);
            this.editVung.MaxLength = 10;
            this.editVung.Name = "editVung";
            this.editVung.Size = new System.Drawing.Size(101, 20);
            this.editVung.TabIndex = 16;
            this.editVung.Text = "1";
            this.editVung.TextChanged += new System.EventHandler(this.editVung_TextChanged);
            this.editVung.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editSoChuong_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Cuộc gọi vùng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(297, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Thời gian điều xe trên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(504, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Thời gian đón khách trên";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(520, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(174, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "(1;3;4 - dấu chấm phẩu phân cách)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(255, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(152, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Thời gian chuyển tổng đài trên";
            // 
            // editDienThoai
            // 
            this.editDienThoai.Location = new System.Drawing.Point(413, 94);
            this.editDienThoai.MaxLength = 11;
            this.editDienThoai.Name = "editDienThoai";
            this.editDienThoai.Size = new System.Drawing.Size(101, 20);
            this.editDienThoai.TabIndex = 32;
            this.editDienThoai.TextChanged += new System.EventHandler(this.editDienThoai_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(338, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Điện thoại số";
            // 
            // timeThoiGianDieuXe
            // 
            this.timeThoiGianDieuXe.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            this.timeThoiGianDieuXe.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Time;
            // 
            // 
            // 
            this.timeThoiGianDieuXe.DropDownCalendar.FirstMonth = new System.DateTime(2008, 11, 1, 0, 0, 0, 0);
            this.timeThoiGianDieuXe.DropDownCalendar.Name = "";
            this.timeThoiGianDieuXe.Location = new System.Drawing.Point(413, 152);
            this.timeThoiGianDieuXe.MinuteIncrement = 1;
            this.timeThoiGianDieuXe.Name = "timeThoiGianDieuXe";
            this.timeThoiGianDieuXe.SecondIncrement = 1;
            this.timeThoiGianDieuXe.ShowDropDown = false;
            this.timeThoiGianDieuXe.ShowUpDown = true;
            this.timeThoiGianDieuXe.Size = new System.Drawing.Size(69, 20);
            this.timeThoiGianDieuXe.TabIndex = 33;
            this.timeThoiGianDieuXe.TextChanged += new System.EventHandler(this.timeThoiGianDieuXe_TextChanged);
            // 
            // timeThoiGianDonKhach
            // 
            this.timeThoiGianDonKhach.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            this.timeThoiGianDonKhach.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Time;
            // 
            // 
            // 
            this.timeThoiGianDonKhach.DropDownCalendar.FirstMonth = new System.DateTime(2008, 11, 1, 0, 0, 0, 0);
            this.timeThoiGianDonKhach.DropDownCalendar.Name = "";
            this.timeThoiGianDonKhach.Location = new System.Drawing.Point(637, 149);
            this.timeThoiGianDonKhach.MinuteIncrement = 1;
            this.timeThoiGianDonKhach.Name = "timeThoiGianDonKhach";
            this.timeThoiGianDonKhach.SecondIncrement = 1;
            this.timeThoiGianDonKhach.ShowDropDown = false;
            this.timeThoiGianDonKhach.ShowUpDown = true;
            this.timeThoiGianDonKhach.Size = new System.Drawing.Size(69, 20);
            this.timeThoiGianDonKhach.TabIndex = 34;
            this.timeThoiGianDonKhach.TextChanged += new System.EventHandler(this.timeThoiGianDonKhach_TextChanged);
            // 
            // timeThoiGianChuyenTongDai
            // 
            this.timeThoiGianChuyenTongDai.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            this.timeThoiGianChuyenTongDai.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Time;
            // 
            // 
            // 
            this.timeThoiGianChuyenTongDai.DropDownCalendar.FirstMonth = new System.DateTime(2008, 11, 1, 0, 0, 0, 0);
            this.timeThoiGianChuyenTongDai.DropDownCalendar.Name = "";
            this.timeThoiGianChuyenTongDai.Location = new System.Drawing.Point(413, 124);
            this.timeThoiGianChuyenTongDai.MinuteIncrement = 1;
            this.timeThoiGianChuyenTongDai.Name = "timeThoiGianChuyenTongDai";
            this.timeThoiGianChuyenTongDai.SecondIncrement = 1;
            this.timeThoiGianChuyenTongDai.ShowDropDown = false;
            this.timeThoiGianChuyenTongDai.ShowUpDown = true;
            this.timeThoiGianChuyenTongDai.Size = new System.Drawing.Size(69, 20);
            this.timeThoiGianChuyenTongDai.TabIndex = 35;
            this.timeThoiGianChuyenTongDai.TextChanged += new System.EventHandler(this.timeThoiGianChuyenTongDai_TextChanged);
            // 
            // chkMoiGioi
            // 
            this.chkMoiGioi.Location = new System.Drawing.Point(565, 91);
            this.chkMoiGioi.Name = "chkMoiGioi";
            this.chkMoiGioi.Size = new System.Drawing.Size(68, 23);
            this.chkMoiGioi.TabIndex = 36;
            this.chkMoiGioi.Text = "Môi giới";
            this.chkMoiGioi.CheckedChanged += new System.EventHandler(this.chkMoiGioi_CheckedChanged);
            // 
            // chkVangLai
            // 
            this.chkVangLai.Location = new System.Drawing.Point(646, 91);
            this.chkVangLai.Name = "chkVangLai";
            this.chkVangLai.Size = new System.Drawing.Size(68, 23);
            this.chkVangLai.TabIndex = 37;
            this.chkVangLai.Text = "Vãng lai";
            this.chkVangLai.CheckedChanged += new System.EventHandler(this.chkVangLai_CheckedChanged);
            // 
            // frmBaoCaoBieuMau5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 725);
            this.Controls.Add(this.chkMoiGioi);
            this.Controls.Add(this.chkVangLai);
            this.Controls.Add(this.timeThoiGianChuyenTongDai);
            this.Controls.Add(this.timeThoiGianDonKhach);
            this.Controls.Add(this.timeThoiGianDieuXe);
            this.Controls.Add(this.editDienThoai);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.gridDienThoai);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.editVung);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.calDenNgay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calTuNgay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCaoBieuMau5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BC 5 - Bao cao cuoc goi  don duoc khach";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuMau5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDienThoai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo calDenNgay;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.EditControls.UIButton btnPrint;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private Janus.Windows.GridEX.EditControls.EditBox editVung;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.GridEX.GridEX gridDienThoai;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private Janus.Windows.GridEX.EditControls.EditBox editDienThoai;
        private System.Windows.Forms.Label label12;
        private Janus.Windows.CalendarCombo.CalendarCombo timeThoiGianDieuXe;
        private Janus.Windows.CalendarCombo.CalendarCombo timeThoiGianDonKhach;
        private Janus.Windows.CalendarCombo.CalendarCombo timeThoiGianChuyenTongDai;
        private Janus.Windows.EditControls.UICheckBox chkMoiGioi;
        private Janus.Windows.EditControls.UICheckBox chkVangLai;
       
    }
}