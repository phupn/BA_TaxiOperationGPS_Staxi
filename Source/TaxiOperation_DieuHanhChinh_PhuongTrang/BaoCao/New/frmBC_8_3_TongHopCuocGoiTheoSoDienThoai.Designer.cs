﻿namespace Taxi.GUI 
{
    partial class frmBC_8_3_TongHopCuocGoiTheoSoDienThoai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_8_3_TongHopCuocGoiTheoSoDienThoai));
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.label1.Location = new System.Drawing.Point(21, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(623, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO TỔNG HỢP LƯỢNG CUỘC GỌI THEO SỐ ĐIỆN THOẠI";
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
            this.calTuNgay.Location = new System.Drawing.Point(151, 38);
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
            this.gridBinhQuan.AllowColumnDrag = false;
            this.gridBinhQuan.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridBinhQuan.DesignTimeLayout = gridEXLayout1;
            this.gridBinhQuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBinhQuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBinhQuan.GroupByBoxVisible = false;
            this.gridBinhQuan.Location = new System.Drawing.Point(0, 0);
            this.gridBinhQuan.Name = "gridBinhQuan";
            this.gridBinhQuan.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridBinhQuan.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridBinhQuan.SaveSettings = false;
            this.gridBinhQuan.Size = new System.Drawing.Size(777, 417);
            this.gridBinhQuan.TabIndex = 27;
            this.gridBinhQuan.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridBinhQuan.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
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
            this.calDenNgay.Location = new System.Drawing.Point(379, 37);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(161, 20);
            this.calDenNgay.TabIndex = 2;
            this.calDenNgay.ValueChanged += new System.EventHandler(this.calDenNgay_ValueChanged);
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(320, 41);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(53, 13);
            this.lblDenNgay.TabIndex = 14;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(99, 42);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(46, 13);
            this.lblTuNgay.TabIndex = 1;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(418, 69);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 6;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(323, 69);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Số điện thoại";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(151, 69);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(141, 20);
            this.txtSoDienThoai.TabIndex = 33;
            this.txtSoDienThoai.TextChanged += new System.EventHandler(this.txtSoDienThoai_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSoDienThoai);
            this.panel1.Controls.Add(this.lblTuNgay);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.calTuNgay);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.calDenNgay);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Controls.Add(this.lblDenNgay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(777, 103);
            this.panel1.TabIndex = 34;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridBinhQuan);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(777, 417);
            this.panel2.TabIndex = 35;
            // 
            // frmBC_8_3_TongHopCuocGoiTheoSoDienThoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 520);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_8_3_TongHopCuocGoiTheoSoDienThoai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "8.3 BC tổng hợp lượng cuộc gọi theo số điện thoại";
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
       
    }
}