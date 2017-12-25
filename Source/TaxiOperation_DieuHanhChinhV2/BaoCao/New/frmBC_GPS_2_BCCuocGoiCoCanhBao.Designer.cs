namespace Taxi.GUI 
{
    partial class frmBC_GPS_2_BCCuocGoiCoCanhBao
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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout4 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_GPS_2_BCCuocGoiCoCanhBao));
            this.label1 = new System.Windows.Forms.Label();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.gridBinhQuan = new Janus.Windows.GridEX.GridEX();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.calDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk_Loai4 = new Janus.Windows.EditControls.UICheckBox();
            this.chk_Loai3 = new Janus.Windows.EditControls.UICheckBox();
            this.chk_Loai2 = new Janus.Windows.EditControls.UICheckBox();
            this.chk_Loai1 = new Janus.Windows.EditControls.UICheckBox();
            this.txtVung = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridBinhQuan)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(256, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(523, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO CUỘC GỌI ĐIỀU HÀNH GPS CÓ CẢNH BÁO";
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
            this.calTuNgay.Location = new System.Drawing.Point(349, 37);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(141, 20);
            this.calTuNgay.TabIndex = 1;
            this.calTuNgay.ValueChanged += new System.EventHandler(this.calTuNgay_ValueChanged);
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.gridBinhQuan;
            this.gridEXExporter1.IncludeChildTables = true;
            // 
            // gridBinhQuan
            // 
            this.gridBinhQuan.AllowCardSizing = false;
            this.gridBinhQuan.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout4.LayoutString = resources.GetString("gridEXLayout4.LayoutString");
            this.gridBinhQuan.DesignTimeLayout = gridEXLayout4;
            this.gridBinhQuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBinhQuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridBinhQuan.Location = new System.Drawing.Point(0, 0);
            this.gridBinhQuan.Name = "gridBinhQuan";
            this.gridBinhQuan.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridBinhQuan.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridBinhQuan.SaveSettings = false;
            this.gridBinhQuan.Size = new System.Drawing.Size(1035, 373);
            this.gridBinhQuan.TabIndex = 27;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
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
            this.calDenNgay.Location = new System.Drawing.Point(577, 36);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(161, 20);
            this.calDenNgay.TabIndex = 2;
            this.calDenNgay.ValueChanged += new System.EventHandler(this.calDenNgay_ValueChanged);
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(518, 40);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(53, 13);
            this.lblDenNgay.TabIndex = 14;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(297, 41);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(46, 13);
            this.lblTuNgay.TabIndex = 1;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(521, 115);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 6;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(426, 115);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chk_Loai4);
            this.panel1.Controls.Add(this.chk_Loai3);
            this.panel1.Controls.Add(this.chk_Loai2);
            this.panel1.Controls.Add(this.chk_Loai1);
            this.panel1.Controls.Add(this.txtVung);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtMaNV);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTuNgay);
            this.panel1.Controls.Add(this.calDenNgay);
            this.panel1.Controls.Add(this.calTuNgay);
            this.panel1.Controls.Add(this.lblDenNgay);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1035, 147);
            this.panel1.TabIndex = 28;
            // 
            // chk_Loai4
            // 
            this.chk_Loai4.Location = new System.Drawing.Point(688, 87);
            this.chk_Loai4.Name = "chk_Loai4";
            this.chk_Loai4.Size = new System.Drawing.Size(161, 23);
            this.chk_Loai4.TabIndex = 19;
            this.chk_Loai4.Text = "Trùng xe đón";
            this.chk_Loai4.CheckedChanged += new System.EventHandler(this.chk_Loai4_CheckedChanged);
            // 
            // chk_Loai3
            // 
            this.chk_Loai3.Location = new System.Drawing.Point(521, 87);
            this.chk_Loai3.Name = "chk_Loai3";
            this.chk_Loai3.Size = new System.Drawing.Size(161, 23);
            this.chk_Loai3.TabIndex = 20;
            this.chk_Loai3.Text = "Thiếu xe đón";
            this.chk_Loai3.CheckedChanged += new System.EventHandler(this.chk_Loai3_CheckedChanged);
            // 
            // chk_Loai2
            // 
            this.chk_Loai2.Location = new System.Drawing.Point(688, 60);
            this.chk_Loai2.Name = "chk_Loai2";
            this.chk_Loai2.Size = new System.Drawing.Size(161, 23);
            this.chk_Loai2.TabIndex = 17;
            this.chk_Loai2.Text = "Xe nhận quá xa";
            this.chk_Loai2.CheckedChanged += new System.EventHandler(this.chk_Loai2_CheckedChanged);
            // 
            // chk_Loai1
            // 
            this.chk_Loai1.Location = new System.Drawing.Point(521, 60);
            this.chk_Loai1.Name = "chk_Loai1";
            this.chk_Loai1.Size = new System.Drawing.Size(161, 23);
            this.chk_Loai1.TabIndex = 18;
            this.chk_Loai1.Text = "Đón không thuộc xe nhận";
            this.chk_Loai1.CheckedChanged += new System.EventHandler(this.chk_Loai1_CheckedChanged);
            // 
            // txtVung
            // 
            this.txtVung.Location = new System.Drawing.Point(349, 89);
            this.txtVung.Name = "txtVung";
            this.txtVung.Size = new System.Drawing.Size(72, 20);
            this.txtVung.TabIndex = 16;
            this.txtVung.TextChanged += new System.EventHandler(this.txtSoDienThoai_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(311, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Vùng";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(349, 63);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(72, 20);
            this.txtMaNV.TabIndex = 16;
            this.txtMaNV.TextChanged += new System.EventHandler(this.txtSoDienThoai_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Mã nhân viên";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridBinhQuan);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 147);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1035, 373);
            this.panel2.TabIndex = 29;
            // 
            // frmBC_GPS_2_BCCuocGoiCoCanhBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 520);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_GPS_2_BCCuocGoiCoCanhBao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "9.2 BC Cuộc gọi điều hành GPS có cảnh báo";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuMau2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridBinhQuan)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private Janus.Windows.GridEX.GridEX gridBinhQuan;
        private Janus.Windows.GridEX.GridEX gridEX2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVung;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.EditControls.UICheckBox chk_Loai4;
        private Janus.Windows.EditControls.UICheckBox chk_Loai3;
        private Janus.Windows.EditControls.UICheckBox chk_Loai2;
        private Janus.Windows.EditControls.UICheckBox chk_Loai1;
       
    }
}