namespace Taxi.GUI.ThanhCong
{
    partial class frmBC_1_2_TongHopCuocGoiDenTheoCa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_1_2_TongHopCuocGoiDenTheoCa));
            Janus.Windows.GridEX.GridEXLayout gridEXLayout2 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout gridEXLayout3 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout gridEXLayout4 = new Janus.Windows.GridEX.GridEXLayout();
            this.label1 = new System.Windows.Forms.Label();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.calDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.griTongCuocGoiDen = new Janus.Windows.GridEX.GridEX();
            this.gridBinhQuan = new Janus.Windows.GridEX.GridEX();
            this.label3 = new System.Windows.Forms.Label();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.gridEX2 = new Janus.Windows.GridEX.GridEX();
            this.lblTuNgayDen = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.griTongCuocGoiDen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBinhQuan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX2)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(244, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(471, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO TỔNG HỢP CUỘC GỌI ĐẾN THEO CA";
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
            this.calTuNgay.Location = new System.Drawing.Point(371, 42);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(90, 20);
            this.calTuNgay.TabIndex = 1;
            this.calTuNgay.ValueChanged += new System.EventHandler(this.calTuNgay_ValueChanged);
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.IncludeChildTables = true;
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
            this.calDenNgay.Location = new System.Drawing.Point(533, 43);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(90, 20);
            this.calDenNgay.TabIndex = 2;
            this.calDenNgay.ValueChanged += new System.EventHandler(this.calDenNgay_ValueChanged);
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(478, 46);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(53, 13);
            this.lblDenNgay.TabIndex = 14;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(323, 45);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(46, 13);
            this.lblTuNgay.TabIndex = 1;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(486, 89);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 6;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(401, 89);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // griTongCuocGoiDen
            // 
            this.griTongCuocGoiDen.AllowCardSizing = false;
            this.griTongCuocGoiDen.AllowColumnDrag = false;
            this.griTongCuocGoiDen.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.griTongCuocGoiDen.DesignTimeLayout = gridEXLayout1;
            this.griTongCuocGoiDen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.griTongCuocGoiDen.GroupByBoxVisible = false;
            this.griTongCuocGoiDen.Location = new System.Drawing.Point(0, 0);
            this.griTongCuocGoiDen.Name = "griTongCuocGoiDen";
            this.griTongCuocGoiDen.SaveSettings = false;
            this.griTongCuocGoiDen.Size = new System.Drawing.Size(1032, 344);
            this.griTongCuocGoiDen.TabIndex = 24;
            this.griTongCuocGoiDen.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.griTongCuocGoiDen.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.griTongCuocGoiDen.TotalRowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
            this.griTongCuocGoiDen.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.griTongCuocGoiDen_FormattingRow);
            // 
            // gridBinhQuan
            // 
            this.gridBinhQuan.AllowCardSizing = false;
            this.gridBinhQuan.AllowColumnDrag = false;
            this.gridBinhQuan.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout2.LayoutString = resources.GetString("gridEXLayout2.LayoutString");
            this.gridBinhQuan.DesignTimeLayout = gridEXLayout2;
            this.gridBinhQuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBinhQuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridBinhQuan.GroupByBoxVisible = false;
            this.gridBinhQuan.Location = new System.Drawing.Point(3, 16);
            this.gridBinhQuan.Name = "gridBinhQuan";
            this.gridBinhQuan.SaveSettings = false;
            this.gridBinhQuan.Size = new System.Drawing.Size(1026, 241);
            this.gridBinhQuan.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(641, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "(dữ liệu chọn cùng một tháng)";
            // 
            // gridEX1
            // 
            this.gridEX1.AllowCardSizing = false;
            this.gridEX1.AllowColumnDrag = false;
            this.gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout3.LayoutString = resources.GetString("gridEXLayout3.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEXLayout3;
            this.gridEX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.Location = new System.Drawing.Point(795, 12);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.SaveSettings = false;
            this.gridEX1.Size = new System.Drawing.Size(400, 376);
            this.gridEX1.TabIndex = 29;
            this.gridEX1.Visible = false;
            // 
            // gridEX2
            // 
            this.gridEX2.AllowCardSizing = false;
            this.gridEX2.AllowColumnDrag = false;
            this.gridEX2.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout4.LayoutString = resources.GetString("gridEXLayout4.LayoutString");
            this.gridEX2.DesignTimeLayout = gridEXLayout4;
            this.gridEX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridEX2.GroupByBoxVisible = false;
            this.gridEX2.Location = new System.Drawing.Point(534, 344);
            this.gridEX2.Name = "gridEX2";
            this.gridEX2.SaveSettings = false;
            this.gridEX2.Size = new System.Drawing.Size(400, 376);
            this.gridEX2.TabIndex = 30;
            this.gridEX2.Visible = false;
            // 
            // lblTuNgayDen
            // 
            this.lblTuNgayDen.AutoSize = true;
            this.lblTuNgayDen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuNgayDen.Location = new System.Drawing.Point(371, 69);
            this.lblTuNgayDen.Name = "lblTuNgayDen";
            this.lblTuNgayDen.Size = new System.Drawing.Size(0, 13);
            this.lblTuNgayDen.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTuNgayDen);
            this.panel1.Controls.Add(this.gridEX1);
            this.panel1.Controls.Add(this.gridEX2);
            this.panel1.Controls.Add(this.lblTuNgay);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.calTuNgay);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Controls.Add(this.lblDenNgay);
            this.panel1.Controls.Add(this.calDenNgay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 121);
            this.panel1.TabIndex = 32;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridBinhQuan);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 465);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1032, 260);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bình quân";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.griTongCuocGoiDen);
            this.panel2.Location = new System.Drawing.Point(0, 121);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1032, 344);
            this.panel2.TabIndex = 34;
            // 
            // frmBC_1_2_TongHopCuocGoiDenTheoCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 725);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_1_2_TongHopCuocGoiDenTheoCa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "1.2 BC Tổng hợp cuộc gọi theo ca";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuMau2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.griTongCuocGoiDen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBinhQuan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuNgay;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Janus.Windows.CalendarCombo.CalendarCombo calDenNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Label lblTuNgay;
        private Janus.Windows.GridEX.GridEX griTongCuocGoiDen;
        private Janus.Windows.GridEX.GridEX gridBinhQuan;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private Janus.Windows.GridEX.GridEX gridEX2;
        private System.Windows.Forms.Label lblTuNgayDen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
       
    }
}