namespace TaxiOperation_DieuHanhChinh.BaoCao.New
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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout2 = new Janus.Windows.GridEX.GridEXLayout();
            this.txtMaMoiGioi = new System.Windows.Forms.TextBox();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.cbCongTy = new Janus.Windows.EditControls.UIComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdMoiGioiCuocGoiThap = new Janus.Windows.GridEX.GridEX();
            this.txtDonDuoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.gridExport = new Janus.Windows.GridEX.GridEX();
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
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdMoiGioiCuocGoiThap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExport)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaMoiGioi
            // 
            this.txtMaMoiGioi.Location = new System.Drawing.Point(461, 60);
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
            this.btnExportExcel.Location = new System.Drawing.Point(567, 112);
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
            this.btnRefresh.Location = new System.Drawing.Point(462, 112);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 33);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbCongTy
            // 
            this.cbCongTy.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cbCongTy.Location = new System.Drawing.Point(736, 57);
            this.cbCongTy.Name = "cbCongTy";
            this.cbCongTy.Size = new System.Drawing.Size(152, 20);
            this.cbCongTy.TabIndex = 1;
            this.cbCongTy.TextChanged += new System.EventHandler(this.cbCongTy_TextChanged);
            this.cbCongTy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCongTy_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(681, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "&Công ty";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(387, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "&Mã môi giới";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(468, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "BÁO CÁO ĐỊA CHỈ MÔI GIỚI CUỘC GỌI THẤP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdMoiGioiCuocGoiThap
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdMoiGioiCuocGoiThap.DesignTimeLayout = gridEXLayout1;
            this.grdMoiGioiCuocGoiThap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMoiGioiCuocGoiThap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdMoiGioiCuocGoiThap.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdMoiGioiCuocGoiThap.GroupByBoxVisible = false;
            this.grdMoiGioiCuocGoiThap.Location = new System.Drawing.Point(0, 0);
            this.grdMoiGioiCuocGoiThap.Name = "grdMoiGioiCuocGoiThap";
            this.grdMoiGioiCuocGoiThap.SaveSettings = false;
            this.grdMoiGioiCuocGoiThap.Size = new System.Drawing.Size(1175, 462);
            this.grdMoiGioiCuocGoiThap.TabIndex = 8;
            this.grdMoiGioiCuocGoiThap.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdMoiGioiCuocGoiThap.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdMoiGioiCuocGoiThap.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdMoiGioiCuocGoiThap_FormattingRow);
            this.grdMoiGioiCuocGoiThap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdMoiGioiCuocGoiThap_MouseDoubleClick);
            // 
            // txtDonDuoc
            // 
            this.txtDonDuoc.Location = new System.Drawing.Point(462, 86);
            this.txtDonDuoc.Name = "txtDonDuoc";
            this.txtDonDuoc.Size = new System.Drawing.Size(51, 20);
            this.txtDonDuoc.TabIndex = 2;
            this.txtDonDuoc.Text = "0";
            this.txtDonDuoc.TextChanged += new System.EventHandler(this.txtDonDuoc_TextChanged);
            this.txtDonDuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDonDuoc_KeyDown);
            this.txtDonDuoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonDuoc_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(359, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "&Số cuốc đón được >";
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.gridExport;
            // 
            // gridExport
            // 
            gridEXLayout2.LayoutString = resources.GetString("gridEXLayout2.LayoutString");
            this.gridExport.DesignTimeLayout = gridEXLayout2;
            this.gridExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridExport.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gridExport.GroupByBoxVisible = false;
            this.gridExport.Location = new System.Drawing.Point(12, 62);
            this.gridExport.Name = "gridExport";
            this.gridExport.SaveSettings = false;
            this.gridExport.Size = new System.Drawing.Size(1175, 462);
            this.gridExport.TabIndex = 9;
            this.gridExport.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridExport.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gridExport.Visible = false;
            this.gridExport.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.gridExport_RowDoubleClick);
            this.gridExport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridExport_KeyDown);
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
            this.calBatDauDen.Location = new System.Drawing.Point(736, 31);
            this.calBatDauDen.Name = "calBatDauDen";
            this.calBatDauDen.Size = new System.Drawing.Size(143, 20);
            this.calBatDauDen.TabIndex = 18;
            this.calBatDauDen.Value = new System.DateTime(2011, 5, 26, 15, 4, 7, 0);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(387, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "&Từ ngày ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(671, 35);
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
            this.calBatDauTu.Location = new System.Drawing.Point(461, 34);
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
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.calBatDauDen);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cbCongTy);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.calBatDauTu);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Controls.Add(this.txtDonDuoc);
            this.panel1.Controls.Add(this.txtMaMoiGioi);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1175, 151);
            this.panel1.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridExport);
            this.panel2.Controls.Add(this.grdMoiGioiCuocGoiThap);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 151);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1175, 462);
            this.panel2.TabIndex = 23;
            // 
            // frmBC_6_2_DiaChiMoiGioi_CuocGoiThap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 613);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbMess);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_6_2_DiaChiMoiGioi_CuocGoiThap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo cáo địa chỉ môi giới cuộc gọi thấp";
            this.Load += new System.EventHandler(this.frmBC_6_2_DiaChiMoiGioi_CuocGoiThap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMoiGioiCuocGoiThap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaMoiGioi;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.EditControls.UIComboBox cbCongTy;
        private System.Windows.Forms.Label label5;
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
        private Janus.Windows.GridEX.GridEX gridExport;
    }
}