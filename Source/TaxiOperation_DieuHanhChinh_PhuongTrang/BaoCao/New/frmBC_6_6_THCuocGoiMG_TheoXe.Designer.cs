namespace TaxiOperation_DieuHanhChinh.BaoCao.New
{
    partial class frmBC_6_6_THCuocGoiMG_TheoXe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_6_6_THCuocGoiMG_TheoXe));
            Janus.Windows.GridEX.GridEXLayout gridEXLayout2 = new Janus.Windows.GridEX.GridEXLayout();
            this.txtMaMoiGioi = new System.Windows.Forms.TextBox();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdMoiGioiCuocGoiThap = new Janus.Windows.GridEX.GridEX();
            this.txtSoXe = new System.Windows.Forms.TextBox();
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
            this.chkHoaHong = new System.Windows.Forms.CheckBox();
            this.chkCiputra = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridEX_TH = new Janus.Windows.GridEX.GridEX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridEXExporter2 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdMoiGioiCuocGoiThap)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX_TH)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaMoiGioi
            // 
            this.txtMaMoiGioi.Location = new System.Drawing.Point(215, 57);
            this.txtMaMoiGioi.Name = "txtMaMoiGioi";
            this.txtMaMoiGioi.Size = new System.Drawing.Size(115, 20);
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
            this.btnExportExcel.Location = new System.Drawing.Point(321, 83);
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
            this.btnRefresh.Location = new System.Drawing.Point(216, 83);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 33);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "&Mã môi giới";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(160, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(440, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "BÁO CÁO TỔNG HỢP CUỘC GỌI HOA HỒNG PHÁT SINH THEO XE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdMoiGioiCuocGoiThap
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdMoiGioiCuocGoiThap.DesignTimeLayout = gridEXLayout1;
            this.grdMoiGioiCuocGoiThap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMoiGioiCuocGoiThap.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdMoiGioiCuocGoiThap.GroupByBoxVisible = false;
            this.grdMoiGioiCuocGoiThap.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grdMoiGioiCuocGoiThap.Location = new System.Drawing.Point(0, 0);
            this.grdMoiGioiCuocGoiThap.Name = "grdMoiGioiCuocGoiThap";
            this.grdMoiGioiCuocGoiThap.SaveSettings = false;
            this.grdMoiGioiCuocGoiThap.Size = new System.Drawing.Size(828, 476);
            this.grdMoiGioiCuocGoiThap.TabIndex = 8;
            this.grdMoiGioiCuocGoiThap.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdMoiGioiCuocGoiThap.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grdMoiGioiCuocGoiThap.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdMoiGioiCuocGoiThap_FormattingRow);
            // 
            // txtSoXe
            // 
            this.txtSoXe.Location = new System.Drawing.Point(459, 57);
            this.txtSoXe.Name = "txtSoXe";
            this.txtSoXe.Size = new System.Drawing.Size(51, 20);
            this.txtSoXe.TabIndex = 2;
            this.txtSoXe.TextChanged += new System.EventHandler(this.txtDonDuoc_TextChanged);
            this.txtSoXe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDonDuoc_KeyDown);
            this.txtSoXe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonDuoc_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(419, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Số xe";
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
            this.calBatDauDen.CustomFormat = "HH:mm:ss  dd/MM/yyyy";
            this.calBatDauDen.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calBatDauDen.DropDownCalendar.FirstMonth = new System.DateTime(2011, 5, 1, 0, 0, 0, 0);
            this.calBatDauDen.DropDownCalendar.Name = "";
            this.calBatDauDen.Location = new System.Drawing.Point(459, 31);
            this.calBatDauDen.Name = "calBatDauDen";
            this.calBatDauDen.Size = new System.Drawing.Size(146, 20);
            this.calBatDauDen.TabIndex = 18;
            this.calBatDauDen.Value = new System.DateTime(2011, 5, 26, 15, 4, 7, 0);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(141, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "&Từ ngày ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(394, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "&Đến ngày";
            // 
            // calBatDauTu
            // 
            this.calBatDauTu.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.calBatDauTu.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calBatDauTu.DropDownCalendar.FirstMonth = new System.DateTime(2011, 5, 1, 0, 0, 0, 0);
            this.calBatDauTu.DropDownCalendar.Name = "";
            this.calBatDauTu.Location = new System.Drawing.Point(215, 31);
            this.calBatDauTu.Name = "calBatDauTu";
            this.calBatDauTu.Size = new System.Drawing.Size(147, 20);
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
            this.panel1.Controls.Add(this.chkHoaHong);
            this.panel1.Controls.Add(this.chkCiputra);
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
            this.panel1.Controls.Add(this.txtSoXe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1018, 137);
            this.panel1.TabIndex = 23;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // chkHoaHong
            // 
            this.chkHoaHong.AutoSize = true;
            this.chkHoaHong.Checked = true;
            this.chkHoaHong.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHoaHong.Location = new System.Drawing.Point(590, 59);
            this.chkHoaHong.Name = "chkHoaHong";
            this.chkHoaHong.Size = new System.Drawing.Size(73, 17);
            this.chkHoaHong.TabIndex = 22;
            this.chkHoaHong.Text = "Hoa hồng";
            this.chkHoaHong.UseVisualStyleBackColor = true;
            this.chkHoaHong.Visible = false;
            this.chkHoaHong.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkCiputra
            // 
            this.chkCiputra.AutoSize = true;
            this.chkCiputra.Location = new System.Drawing.Point(525, 60);
            this.chkCiputra.Name = "chkCiputra";
            this.chkCiputra.Size = new System.Drawing.Size(59, 17);
            this.chkCiputra.TabIndex = 21;
            this.chkCiputra.Text = "Ciputra";
            this.chkCiputra.UseVisualStyleBackColor = true;
            this.chkCiputra.Visible = false;
            this.chkCiputra.CheckedChanged += new System.EventHandler(this.chkCiputra_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridEX_TH);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 137);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(190, 476);
            this.panel3.TabIndex = 25;
            // 
            // gridEX_TH
            // 
            gridEXLayout2.LayoutString = resources.GetString("gridEXLayout2.LayoutString");
            this.gridEX_TH.DesignTimeLayout = gridEXLayout2;
            this.gridEX_TH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEX_TH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridEX_TH.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gridEX_TH.GroupByBoxVisible = false;
            this.gridEX_TH.Location = new System.Drawing.Point(0, 0);
            this.gridEX_TH.Name = "gridEX_TH";
            this.gridEX_TH.SaveSettings = false;
            this.gridEX_TH.Size = new System.Drawing.Size(190, 476);
            this.gridEX_TH.TabIndex = 9;
            this.gridEX_TH.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX_TH.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdMoiGioiCuocGoiThap);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(190, 137);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(828, 476);
            this.panel2.TabIndex = 26;
            // 
            // gridEXExporter2
            // 
            this.gridEXExporter2.GridEX = this.gridEX_TH;
            // 
            // frmBC_6_6_THCuocGoiMG_TheoXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 613);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbMess);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_6_6_THCuocGoiMG_TheoXe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "6.6 Báo cáo tổng hợp cuộc gọi hoa hồng phát sinh theo xe";
            this.Load += new System.EventHandler(this.frmBC_6_2_DiaChiMoiGioi_CuocGoiThap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMoiGioiCuocGoiThap)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEX_TH)).EndInit();
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
        private System.Windows.Forms.TextBox txtSoXe;
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Janus.Windows.GridEX.GridEX gridEX_TH;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter2;
        private System.Windows.Forms.CheckBox chkCiputra;
        private System.Windows.Forms.CheckBox chkHoaHong;
    }
}