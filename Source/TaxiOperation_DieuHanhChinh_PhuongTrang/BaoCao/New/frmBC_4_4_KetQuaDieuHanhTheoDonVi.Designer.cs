namespace TaxiOperation_DieuHanhChinh.BaoCao.New
{
    partial class frmBC_4_4_KetQuaDieuHanhTheoDonVi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_4_4_KetQuaDieuHanhTheoDonVi));
            this.label1 = new System.Windows.Forms.Label();
            this.calDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.grdDieuHanhTheoDonVi = new Janus.Windows.GridEX.GridEX();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnVung = new Janus.Windows.EditControls.UIButton();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            this.uiButton3 = new Janus.Windows.EditControls.UIButton();
            this.uiButton4 = new Janus.Windows.EditControls.UIButton();
            this.uiButton5 = new Janus.Windows.EditControls.UIButton();
            this.uiButton6 = new Janus.Windows.EditControls.UIButton();
            this.uiButton7 = new Janus.Windows.EditControls.UIButton();
            this.uiButton8 = new Janus.Windows.EditControls.UIButton();
            this.uiButton9 = new Janus.Windows.EditControls.UIButton();
            this.uiButton10 = new Janus.Windows.EditControls.UIButton();
            this.uiButton11 = new Janus.Windows.EditControls.UIButton();
            this.uiButton12 = new Janus.Windows.EditControls.UIButton();
            this.uiButton13 = new Janus.Windows.EditControls.UIButton();
            this.uiButton14 = new Janus.Windows.EditControls.UIButton();
            this.uiButton15 = new Janus.Windows.EditControls.UIButton();
            this.uiButton16 = new Janus.Windows.EditControls.UIButton();
            this.uiButton17 = new Janus.Windows.EditControls.UIButton();
            this.uiButton18 = new Janus.Windows.EditControls.UIButton();
            this.rbFilter = new System.Windows.Forms.RadioButton();
            this.rbFilter_Tong = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblTuNgayDen = new System.Windows.Forms.Label();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdDieuHanhTheoDonVi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(154, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(434, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO KẾT QUẢ ĐIỀU HÀNH THEO ĐƠN VỊ";
            // 
            // calDenNgay
            // 
            this.calDenNgay.CustomFormat = "dd/MM/yyyy";
            this.calDenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calDenNgay.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.calDenNgay.DropDownCalendar.Name = "";
            this.calDenNgay.Location = new System.Drawing.Point(403, 32);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(90, 20);
            this.calDenNgay.TabIndex = 19;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(348, 35);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(53, 13);
            this.lblDenNgay.TabIndex = 18;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // calTuNgay
            // 
            this.calTuNgay.CustomFormat = "dd/MM/yyyy";
            this.calTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.calTuNgay.DropDownCalendar.Name = "";
            this.calTuNgay.Location = new System.Drawing.Point(241, 31);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(90, 20);
            this.calTuNgay.TabIndex = 17;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(189, 34);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(46, 13);
            this.lblTuNgay.TabIndex = 16;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(356, 82);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 22;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(271, 82);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 21;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grdDieuHanhTheoDonVi
            // 
            this.grdDieuHanhTheoDonVi.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdDieuHanhTheoDonVi.ColumnSetHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdDieuHanhTheoDonVi.DesignTimeLayout = gridEXLayout1;
            this.grdDieuHanhTheoDonVi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdDieuHanhTheoDonVi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdDieuHanhTheoDonVi.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdDieuHanhTheoDonVi.GroupByBoxVisible = false;
            this.grdDieuHanhTheoDonVi.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
            this.grdDieuHanhTheoDonVi.Location = new System.Drawing.Point(0, 191);
            this.grdDieuHanhTheoDonVi.Name = "grdDieuHanhTheoDonVi";
            this.grdDieuHanhTheoDonVi.SaveSettings = false;
            this.grdDieuHanhTheoDonVi.Size = new System.Drawing.Size(800, 317);
            this.grdDieuHanhTheoDonVi.TabIndex = 23;
            this.grdDieuHanhTheoDonVi.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdDieuHanhTheoDonVi_FormattingRow);
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.grdDieuHanhTheoDonVi;
            // 
            // gridEXPrintDocument1
            // 
            this.gridEXPrintDocument1.GridEX = this.grdDieuHanhTheoDonVi;
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
            // btnVung
            // 
            this.btnVung.Appearance = Janus.Windows.UI.Appearance.Empty;
            this.btnVung.CausesValidation = false;
            this.btnVung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVung.Location = new System.Drawing.Point(0, 122);
            this.btnVung.Name = "btnVung";
            this.btnVung.Size = new System.Drawing.Size(97, 70);
            this.btnVung.TabIndex = 25;
            this.btnVung.Text = "Vùng";
            // 
            // uiButton2
            // 
            this.uiButton2.Location = new System.Drawing.Point(97, 142);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(50, 50);
            this.uiButton2.TabIndex = 26;
            this.uiButton2.Text = "Tổng";
            // 
            // uiButton3
            // 
            this.uiButton3.Location = new System.Drawing.Point(147, 162);
            this.uiButton3.Name = "uiButton3";
            this.uiButton3.Size = new System.Drawing.Size(50, 30);
            this.uiButton3.TabIndex = 27;
            this.uiButton3.Text = "Cuốc";
            // 
            // uiButton4
            // 
            this.uiButton4.Location = new System.Drawing.Point(197, 162);
            this.uiButton4.Name = "uiButton4";
            this.uiButton4.Size = new System.Drawing.Size(50, 30);
            this.uiButton4.TabIndex = 28;
            this.uiButton4.Text = "%";
            // 
            // uiButton5
            // 
            this.uiButton5.Location = new System.Drawing.Point(147, 142);
            this.uiButton5.Name = "uiButton5";
            this.uiButton5.Size = new System.Drawing.Size(100, 20);
            this.uiButton5.TabIndex = 29;
            this.uiButton5.Text = "Đón được";
            // 
            // uiButton6
            // 
            this.uiButton6.Location = new System.Drawing.Point(247, 142);
            this.uiButton6.Name = "uiButton6";
            this.uiButton6.Size = new System.Drawing.Size(199, 20);
            this.uiButton6.TabIndex = 32;
            this.uiButton6.Text = "Không đón được";
            // 
            // uiButton7
            // 
            this.uiButton7.Location = new System.Drawing.Point(297, 162);
            this.uiButton7.Name = "uiButton7";
            this.uiButton7.Size = new System.Drawing.Size(50, 30);
            this.uiButton7.TabIndex = 31;
            this.uiButton7.Text = "Không xe";
            // 
            // uiButton8
            // 
            this.uiButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton8.Location = new System.Drawing.Point(247, 162);
            this.uiButton8.Name = "uiButton8";
            this.uiButton8.Size = new System.Drawing.Size(50, 30);
            this.uiButton8.TabIndex = 30;
            this.uiButton8.Text = "Trượt, hoãn";
            // 
            // uiButton9
            // 
            this.uiButton9.Location = new System.Drawing.Point(396, 162);
            this.uiButton9.Name = "uiButton9";
            this.uiButton9.Size = new System.Drawing.Size(50, 30);
            this.uiButton9.TabIndex = 33;
            this.uiButton9.Text = "Tổng";
            // 
            // uiButton10
            // 
            this.uiButton10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton10.Location = new System.Drawing.Point(97, 122);
            this.uiButton10.Name = "uiButton10";
            this.uiButton10.Size = new System.Drawing.Size(349, 20);
            this.uiButton10.TabIndex = 34;
            this.uiButton10.Text = "Cuộc gọi Taxi";
            // 
            // uiButton11
            // 
            this.uiButton11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton11.Location = new System.Drawing.Point(447, 122);
            this.uiButton11.Name = "uiButton11";
            this.uiButton11.Size = new System.Drawing.Size(350, 20);
            this.uiButton11.TabIndex = 36;
            this.uiButton11.Text = "Cuốc đón khách của các đơn vị";
            // 
            // uiButton12
            // 
            this.uiButton12.Location = new System.Drawing.Point(447, 142);
            this.uiButton12.Name = "uiButton12";
            this.uiButton12.Size = new System.Drawing.Size(50, 50);
            this.uiButton12.TabIndex = 35;
            this.uiButton12.Text = "HN";
            // 
            // uiButton13
            // 
            this.uiButton13.Location = new System.Drawing.Point(497, 142);
            this.uiButton13.Name = "uiButton13";
            this.uiButton13.Size = new System.Drawing.Size(50, 50);
            this.uiButton13.TabIndex = 37;
            this.uiButton13.Text = "CP";
            // 
            // uiButton14
            // 
            this.uiButton14.Location = new System.Drawing.Point(597, 142);
            this.uiButton14.Name = "uiButton14";
            this.uiButton14.Size = new System.Drawing.Size(50, 50);
            this.uiButton14.TabIndex = 39;
            this.uiButton14.Text = "3A";
            // 
            // uiButton15
            // 
            this.uiButton15.Location = new System.Drawing.Point(547, 142);
            this.uiButton15.Name = "uiButton15";
            this.uiButton15.Size = new System.Drawing.Size(50, 50);
            this.uiButton15.TabIndex = 38;
            this.uiButton15.Text = "TOU";
            // 
            // uiButton16
            // 
            this.uiButton16.Location = new System.Drawing.Point(747, 142);
            this.uiButton16.Name = "uiButton16";
            this.uiButton16.Size = new System.Drawing.Size(50, 50);
            this.uiButton16.TabIndex = 42;
            this.uiButton16.Text = "Tổng";
            // 
            // uiButton17
            // 
            this.uiButton17.Location = new System.Drawing.Point(697, 142);
            this.uiButton17.Name = "uiButton17";
            this.uiButton17.Size = new System.Drawing.Size(50, 50);
            this.uiButton17.TabIndex = 41;
            this.uiButton17.Text = "TXG";
            // 
            // uiButton18
            // 
            this.uiButton18.Location = new System.Drawing.Point(647, 142);
            this.uiButton18.Name = "uiButton18";
            this.uiButton18.Size = new System.Drawing.Size(50, 50);
            this.uiButton18.TabIndex = 40;
            this.uiButton18.Text = "JAC";
            // 
            // rbFilter
            // 
            this.rbFilter.AutoSize = true;
            this.rbFilter.Checked = true;
            this.rbFilter.Location = new System.Drawing.Point(241, 57);
            this.rbFilter.Name = "rbFilter";
            this.rbFilter.Size = new System.Drawing.Size(107, 17);
            this.rbFilter.TabIndex = 43;
            this.rbFilter.TabStop = true;
            this.rbFilter.Text = "Chi tiết theo ngày";
            this.rbFilter.UseVisualStyleBackColor = true;
            // 
            // rbFilter_Tong
            // 
            this.rbFilter_Tong.AutoSize = true;
            this.rbFilter_Tong.Location = new System.Drawing.Point(354, 57);
            this.rbFilter_Tong.Name = "rbFilter_Tong";
            this.rbFilter_Tong.Size = new System.Drawing.Size(100, 17);
            this.rbFilter_Tong.TabIndex = 44;
            this.rbFilter_Tong.Text = "Tổng theo ngày";
            this.rbFilter_Tong.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Lọc";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblMessage.Location = new System.Drawing.Point(446, 95);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 46;
            this.lblMessage.Visible = false;
            // 
            // lblTuNgayDen
            // 
            this.lblTuNgayDen.AutoSize = true;
            this.lblTuNgayDen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuNgayDen.Location = new System.Drawing.Point(499, 34);
            this.lblTuNgayDen.Name = "lblTuNgayDen";
            this.lblTuNgayDen.Size = new System.Drawing.Size(0, 13);
            this.lblTuNgayDen.TabIndex = 47;
            // 
            // uiButton1
            // 
            this.uiButton1.Location = new System.Drawing.Point(347, 162);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(50, 30);
            this.uiButton1.TabIndex = 48;
            this.uiButton1.Text = "Khác 999";
            // 
            // frmBC_4_4_KetQuaDieuHanhTheoDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 508);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.lblTuNgayDen);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbFilter_Tong);
            this.Controls.Add(this.rbFilter);
            this.Controls.Add(this.uiButton16);
            this.Controls.Add(this.uiButton17);
            this.Controls.Add(this.uiButton18);
            this.Controls.Add(this.uiButton14);
            this.Controls.Add(this.uiButton15);
            this.Controls.Add(this.uiButton13);
            this.Controls.Add(this.uiButton11);
            this.Controls.Add(this.uiButton12);
            this.Controls.Add(this.uiButton10);
            this.Controls.Add(this.uiButton9);
            this.Controls.Add(this.uiButton6);
            this.Controls.Add(this.uiButton7);
            this.Controls.Add(this.uiButton8);
            this.Controls.Add(this.uiButton5);
            this.Controls.Add(this.uiButton4);
            this.Controls.Add(this.uiButton3);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.btnVung);
            this.Controls.Add(this.grdDieuHanhTheoDonVi);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.calDenNgay);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.calTuNgay);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_4_4_KetQuaDieuHanhTheoDonVi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "4.4 Báo cáo kết quả điều hành theo đơn vị";
            this.Load += new System.EventHandler(this.frmBC_4_4_KetQuaDieuHanhTheoDonVi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDieuHanhTheoDonVi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;    
        private Janus.Windows.CalendarCombo.CalendarCombo calDenNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuNgay;
        private System.Windows.Forms.Label lblTuNgay;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.GridEX.GridEX grdDieuHanhTheoDonVi;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private Janus.Windows.EditControls.UIButton btnVung;
        private Janus.Windows.EditControls.UIButton uiButton2;
        private Janus.Windows.EditControls.UIButton uiButton3;
        private Janus.Windows.EditControls.UIButton uiButton4;
        private Janus.Windows.EditControls.UIButton uiButton5;
        private Janus.Windows.EditControls.UIButton uiButton6;
        private Janus.Windows.EditControls.UIButton uiButton7;
        private Janus.Windows.EditControls.UIButton uiButton8;
        private Janus.Windows.EditControls.UIButton uiButton9;
        private Janus.Windows.EditControls.UIButton uiButton10;
        private Janus.Windows.EditControls.UIButton uiButton11;
        private Janus.Windows.EditControls.UIButton uiButton12;
        private Janus.Windows.EditControls.UIButton uiButton13;
        private Janus.Windows.EditControls.UIButton uiButton14;
        private Janus.Windows.EditControls.UIButton uiButton15;
        private Janus.Windows.EditControls.UIButton uiButton16;
        private Janus.Windows.EditControls.UIButton uiButton17;
        private Janus.Windows.EditControls.UIButton uiButton18;
        private System.Windows.Forms.RadioButton rbFilter;
        private System.Windows.Forms.RadioButton rbFilter_Tong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblTuNgayDen;
        private Janus.Windows.EditControls.UIButton uiButton1;
    }
}