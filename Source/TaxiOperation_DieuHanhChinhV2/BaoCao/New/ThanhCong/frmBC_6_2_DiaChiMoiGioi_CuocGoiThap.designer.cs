namespace TaxiOperation_DieuHanhChinh.BaoCao.New.ThanhCong
{
    partial class frmBC_6_2_DiaChiMoiGioi_CuocGoiThap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_6_2_DiaChiMoiGioi_CuocGoiThap));
            this.txtMaMoiGioi = new System.Windows.Forms.TextBox();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdMoiGioiCuocGoiThap = new Janus.Windows.GridEX.GridEX();
            this.txtDonDuoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.calBatDauDen = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.calBatDauTu = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lbMess = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTienHH3 = new System.Windows.Forms.TextBox();
            this.txtTrenCuoc2 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTienHH2 = new System.Windows.Forms.TextBox();
            this.txtTrenCuoc1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.calNgayKyKet = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTuCuoc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTienHH1 = new System.Windows.Forms.TextBox();
            this.txtDenCuoc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdMoiGioiCuocGoiThap)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaMoiGioi
            // 
            this.txtMaMoiGioi.Location = new System.Drawing.Point(253, 58);
            this.txtMaMoiGioi.Name = "txtMaMoiGioi";
            this.txtMaMoiGioi.Size = new System.Drawing.Size(152, 20);
            this.txtMaMoiGioi.TabIndex = 0;
            this.txtMaMoiGioi.TextChanged += new System.EventHandler(this.txtMaMoiGioi_TextChanged);
            this.txtMaMoiGioi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaMoiGioi_KeyDown);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Button;
            this.btnExportExcel.Enabled = false;
            this.btnExportExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(359, 84);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(100, 33);
            this.btnExportExcel.TabIndex = 7;
            this.btnExportExcel.Text = "&Xuất Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Button;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(254, 84);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 33);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "&Mã môi giới";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(198, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "BÁO CÁO TỔNG HỢP MÔI GIỚI GỌI QUA TRUNG TÂM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdMoiGioiCuocGoiThap
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdMoiGioiCuocGoiThap.DesignTimeLayout = gridEXLayout1;
            this.grdMoiGioiCuocGoiThap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMoiGioiCuocGoiThap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdMoiGioiCuocGoiThap.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdMoiGioiCuocGoiThap.GroupByBoxVisible = false;
            this.grdMoiGioiCuocGoiThap.Location = new System.Drawing.Point(0, 0);
            this.grdMoiGioiCuocGoiThap.Name = "grdMoiGioiCuocGoiThap";
            this.grdMoiGioiCuocGoiThap.SaveSettings = false;
            this.grdMoiGioiCuocGoiThap.Size = new System.Drawing.Size(990, 476);
            this.grdMoiGioiCuocGoiThap.TabIndex = 8;
            this.grdMoiGioiCuocGoiThap.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdMoiGioiCuocGoiThap.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdMoiGioiCuocGoiThap_FormattingRow);
            // 
            // txtDonDuoc
            // 
            this.txtDonDuoc.Location = new System.Drawing.Point(530, 58);
            this.txtDonDuoc.Name = "txtDonDuoc";
            this.txtDonDuoc.Size = new System.Drawing.Size(51, 20);
            this.txtDonDuoc.TabIndex = 2;
            this.txtDonDuoc.TextChanged += new System.EventHandler(this.txtDonDuoc_TextChanged);
            this.txtDonDuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDonDuoc_KeyDown);
            this.txtDonDuoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonDuoc_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(423, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "&Số cuốc đón được >";
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.grdMoiGioiCuocGoiThap;
            // 
            // gridEXPrintDocument1
            // 
            this.gridEXPrintDocument1.GridEX = this.grdMoiGioiCuocGoiThap;
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
            // calBatDauDen
            // 
            this.calBatDauDen.CustomFormat = " HH:mm:ss dd/MM/yyyy";
            this.calBatDauDen.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calBatDauDen.DropDownCalendar.FirstMonth = new System.DateTime(2011, 5, 1, 0, 0, 0, 0);
            this.calBatDauDen.DropDownCalendar.Name = "";
            this.calBatDauDen.Location = new System.Drawing.Point(490, 32);
            this.calBatDauDen.Name = "calBatDauDen";
            this.calBatDauDen.Size = new System.Drawing.Size(146, 20);
            this.calBatDauDen.TabIndex = 18;
            this.calBatDauDen.Value = new System.DateTime(2011, 5, 26, 15, 4, 7, 0);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(179, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "&Từ ngày ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(425, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "&Đến ngày";
            // 
            // calBatDauTu
            // 
            this.calBatDauTu.CustomFormat = " HH:mm:ss dd/MM/yyyy";
            this.calBatDauTu.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calBatDauTu.DropDownCalendar.FirstMonth = new System.DateTime(2011, 5, 1, 0, 0, 0, 0);
            this.calBatDauTu.DropDownCalendar.Name = "";
            this.calBatDauTu.Location = new System.Drawing.Point(253, 32);
            this.calBatDauTu.Name = "calBatDauTu";
            this.calBatDauTu.Size = new System.Drawing.Size(152, 20);
            this.calBatDauTu.TabIndex = 17;
            this.calBatDauTu.Value = new System.DateTime(2011, 5, 26, 15, 3, 55, 0);
            // 
            // lbMess
            // 
            this.lbMess.AutoSize = true;
            this.lbMess.Location = new System.Drawing.Point(29, 213);
            this.lbMess.Name = "lbMess";
            this.lbMess.Size = new System.Drawing.Size(0, 13);
            this.lbMess.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.calBatDauDen);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtMaMoiGioi);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.calBatDauTu);
            this.panel1.Controls.Add(this.txtDonDuoc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 137);
            this.panel1.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtTienHH3);
            this.groupBox1.Controls.Add(this.txtTrenCuoc2);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtTienHH2);
            this.groupBox1.Controls.Add(this.txtTrenCuoc1);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.calNgayKyKet);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTuCuoc);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTienHH1);
            this.groupBox1.Controls.Add(this.txtDenCuoc);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(658, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 122);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tiền hoa hồng";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(76, 103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 47;
            this.label14.Text = "Cuốc";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(190, 103);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 46;
            this.label15.Text = "-Tiền HH";
            // 
            // txtTienHH3
            // 
            this.txtTienHH3.Location = new System.Drawing.Point(242, 100);
            this.txtTienHH3.Name = "txtTienHH3";
            this.txtTienHH3.Size = new System.Drawing.Size(63, 20);
            this.txtTienHH3.TabIndex = 45;
            this.txtTienHH3.Text = "10000";
            // 
            // txtTrenCuoc2
            // 
            this.txtTrenCuoc2.Location = new System.Drawing.Point(33, 100);
            this.txtTrenCuoc2.Name = "txtTrenCuoc2";
            this.txtTrenCuoc2.Size = new System.Drawing.Size(40, 20);
            this.txtTrenCuoc2.TabIndex = 43;
            this.txtTrenCuoc2.Text = "100";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(2, 103);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 13);
            this.label16.TabIndex = 44;
            this.label16.Text = "Trên";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(76, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Cuốc";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(190, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "-Tiền HH";
            // 
            // txtTienHH2
            // 
            this.txtTienHH2.Location = new System.Drawing.Point(242, 74);
            this.txtTienHH2.Name = "txtTienHH2";
            this.txtTienHH2.Size = new System.Drawing.Size(63, 20);
            this.txtTienHH2.TabIndex = 35;
            this.txtTienHH2.Text = "7000";
            // 
            // txtTrenCuoc1
            // 
            this.txtTrenCuoc1.Location = new System.Drawing.Point(33, 74);
            this.txtTrenCuoc1.Name = "txtTrenCuoc1";
            this.txtTrenCuoc1.Size = new System.Drawing.Size(40, 20);
            this.txtTrenCuoc1.TabIndex = 33;
            this.txtTrenCuoc1.Text = "30";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(2, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "Trên";
            // 
            // calNgayKyKet
            // 
            this.calNgayKyKet.CustomFormat = "00:00:00 dd/MM/yyyy";
            this.calNgayKyKet.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calNgayKyKet.DropDownCalendar.FirstMonth = new System.DateTime(2011, 5, 1, 0, 0, 0, 0);
            this.calNgayKyKet.DropDownCalendar.Name = "";
            this.calNgayKyKet.Location = new System.Drawing.Point(87, 19);
            this.calNgayKyKet.Name = "calNgayKyKet";
            this.calNgayKyKet.Size = new System.Drawing.Size(146, 20);
            this.calNgayKyKet.TabIndex = 31;
            this.calNgayKyKet.Value = new System.DateTime(2011, 4, 23, 15, 4, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = " Ngày ký kết";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Cuốc";
            // 
            // txtTuCuoc
            // 
            this.txtTuCuoc.Location = new System.Drawing.Point(33, 48);
            this.txtTuCuoc.Name = "txtTuCuoc";
            this.txtTuCuoc.Size = new System.Drawing.Size(40, 20);
            this.txtTuCuoc.TabIndex = 23;
            this.txtTuCuoc.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "-Tiền HH";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Từ";
            // 
            // txtTienHH1
            // 
            this.txtTienHH1.Location = new System.Drawing.Point(242, 48);
            this.txtTienHH1.Name = "txtTienHH1";
            this.txtTienHH1.Size = new System.Drawing.Size(63, 20);
            this.txtTienHH1.TabIndex = 28;
            this.txtTienHH1.Text = "5000";
            // 
            // txtDenCuoc
            // 
            this.txtDenCuoc.Location = new System.Drawing.Point(98, 48);
            this.txtDenCuoc.Name = "txtDenCuoc";
            this.txtDenCuoc.Size = new System.Drawing.Size(40, 20);
            this.txtDenCuoc.TabIndex = 26;
            this.txtDenCuoc.Text = "30";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(82, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "-";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdMoiGioiCuocGoiThap);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 137);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(990, 476);
            this.panel2.TabIndex = 24;
            // 
            // frmBC_6_2_DiaChiMoiGioi_CuocGoiThap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 613);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbMess);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_6_2_DiaChiMoiGioi_CuocGoiThap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo cáo tổng hợp môi giới gọi qua trung tâm";
            this.Load += new System.EventHandler(this.frmBC_6_2_DiaChiMoiGioi_CuocGoiThap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMoiGioiCuocGoiThap)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaMoiGioi;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.GridEX grdMoiGioiCuocGoiThap;
        private System.Windows.Forms.TextBox txtDonDuoc;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private Janus.Windows.CalendarCombo.CalendarCombo calBatDauDen;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private Janus.Windows.CalendarCombo.CalendarCombo calBatDauTu;
        private System.Windows.Forms.Label lbMess;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTienHH1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDenCuoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTuCuoc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.CalendarCombo.CalendarCombo calNgayKyKet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTienHH2;
        private System.Windows.Forms.TextBox txtTrenCuoc1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTienHH3;
        private System.Windows.Forms.TextBox txtTrenCuoc2;
        private System.Windows.Forms.Label label16;
    }
}