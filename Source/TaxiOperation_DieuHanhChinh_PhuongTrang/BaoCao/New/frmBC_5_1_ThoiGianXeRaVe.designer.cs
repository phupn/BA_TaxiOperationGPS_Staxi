namespace Taxi.GUI.BaoCao
{
    partial class frmBC_5_1_ThoiGianXeRaVe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_5_1_ThoiGianXeRaVe));
            this.label1 = new System.Windows.Forms.Label();
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.gridBaoCaoBieuMau1 = new Janus.Windows.GridEX.GridEX();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.label2 = new System.Windows.Forms.Label();
            this.calTuThoiDiem = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.calDenThoiDiem = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoHieuXe = new System.Windows.Forms.TextBox();
            this.txtLaiXeID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridBaoCaoBieuMau1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(201, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO THỜI GIAN LÁI XE RA - VỀ";
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.gridBaoCaoBieuMau1;
            // 
            // gridBaoCaoBieuMau1
            // 
            this.gridBaoCaoBieuMau1.AllowCardSizing = false;
            this.gridBaoCaoBieuMau1.AllowColumnDrag = false;
            this.gridBaoCaoBieuMau1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridBaoCaoBieuMau1.AutomaticSort = false;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridBaoCaoBieuMau1.DesignTimeLayout = gridEXLayout1;
            this.gridBaoCaoBieuMau1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridBaoCaoBieuMau1.GroupByBoxVisible = false;
            this.gridBaoCaoBieuMau1.HeaderFormatStyle.LineAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridBaoCaoBieuMau1.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridBaoCaoBieuMau1.Location = new System.Drawing.Point(0, 131);
            this.gridBaoCaoBieuMau1.Name = "gridBaoCaoBieuMau1";
            this.gridBaoCaoBieuMau1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridBaoCaoBieuMau1.SaveSettings = false;
            this.gridBaoCaoBieuMau1.Size = new System.Drawing.Size(872, 462);
            this.gridBaoCaoBieuMau1.TabIndex = 15;
            this.gridBaoCaoBieuMau1.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridBaoCaoBieuMau1.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gridBaoCaoBieuMau1_FormattingRow_1);
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
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.AliceBlue;
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(389, 101);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 5;
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Thời điểm";
            // 
            // calTuThoiDiem
            // 
            this.calTuThoiDiem.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.calTuThoiDiem.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calTuThoiDiem.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.calTuThoiDiem.DropDownCalendar.Name = "";
            this.calTuThoiDiem.Location = new System.Drawing.Point(239, 29);
            this.calTuThoiDiem.Name = "calTuThoiDiem";
            this.calTuThoiDiem.Size = new System.Drawing.Size(141, 20);
            this.calTuThoiDiem.TabIndex = 0;
            this.calTuThoiDiem.ValueChanged += new System.EventHandler(this.calTuThoiDiem_ValueChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(305, 101);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // calDenThoiDiem
            // 
            this.calDenThoiDiem.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.calDenThoiDiem.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calDenThoiDiem.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.calDenThoiDiem.DropDownCalendar.Name = "";
            this.calDenThoiDiem.Location = new System.Drawing.Point(697, 25);
            this.calDenThoiDiem.Name = "calDenThoiDiem";
            this.calDenThoiDiem.Size = new System.Drawing.Size(141, 20);
            this.calDenThoiDiem.TabIndex = 22;
            this.calDenThoiDiem.Visible = false;
            this.calDenThoiDiem.ValueChanged += new System.EventHandler(this.calDenThoiDiem_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(645, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Đến ngày";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Số xe";
            // 
            // txtSoHieuXe
            // 
            this.txtSoHieuXe.Location = new System.Drawing.Point(239, 52);
            this.txtSoHieuXe.Name = "txtSoHieuXe";
            this.txtSoHieuXe.Size = new System.Drawing.Size(141, 20);
            this.txtSoHieuXe.TabIndex = 1;
            this.txtSoHieuXe.TextChanged += new System.EventHandler(this.txtSoHieuXe_TextChanged);
            // 
            // txtLaiXeID
            // 
            this.txtLaiXeID.Location = new System.Drawing.Point(438, 53);
            this.txtLaiXeID.Name = "txtLaiXeID";
            this.txtLaiXeID.Size = new System.Drawing.Size(141, 20);
            this.txtLaiXeID.TabIndex = 2;
            this.txtLaiXeID.TextChanged += new System.EventHandler(this.txtLaiXeID_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(386, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "ID lái xe";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Công ty";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(239, 76);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(340, 21);
            this.comboBox1.TabIndex = 41;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // frmBC_5_1_ThoiGianXeRaVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 595);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLaiXeID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSoHieuXe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.calDenThoiDiem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.calTuThoiDiem);
            this.Controls.Add(this.gridBaoCaoBieuMau1);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_5_1_ThoiGianXeRaVe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BC 5.1 - Bao cao thoi gian lai xe ra - ve";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuMau2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridBaoCaoBieuMau1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.GridEX gridBaoCaoBieuMau1;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuThoiDiem;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.CalendarCombo.CalendarCombo calDenThoiDiem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSoHieuXe;
        private System.Windows.Forms.TextBox txtLaiXeID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
       
       
    }
}