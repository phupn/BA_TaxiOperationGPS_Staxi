namespace TaxiOperation_DieuHanhChinh.BaoCao.New
{
    partial class frmBC_6_1_DSDiaChiMoiGioi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_6_1_DSDiaChiMoiGioi));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.calBatDauTu = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCongTy = new Janus.Windows.EditControls.UIComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.calKetThucTu = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calBatDauDen = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calKetThucDen = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.grdDSDiaChiMoiGioi = new Janus.Windows.GridEX.GridEX();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.chkBDTatCa = new Janus.Windows.EditControls.UICheckBox();
            this.chkKTTatCa = new Janus.Windows.EditControls.UICheckBox();
            this.txtMaMoiGioi = new System.Windows.Forms.TextBox();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTenDuong = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdDSDiaChiMoiGioi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(414, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "BÁO CÁO DANH SÁCH ĐỊA CHỈ MÔI GIỚI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "&Mã môi giới";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(409, 110);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(152, 20);
            this.txtDienThoai.TabIndex = 1;
            this.txtDienThoai.TextChanged += new System.EventHandler(this.txtDienThoai_TextChanged);
            this.txtDienThoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDienThoai_KeyDown);
            this.txtDienThoai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDienThoai_KeyPress);
            // 
            // calBatDauTu
            // 
            this.calBatDauTu.CustomFormat = "HH:mm dd/MM/yyyy";
            this.calBatDauTu.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calBatDauTu.DropDownCalendar.FirstMonth = new System.DateTime(2011, 5, 1, 0, 0, 0, 0);
            this.calBatDauTu.DropDownCalendar.Name = "";
            this.calBatDauTu.Enabled = false;
            this.calBatDauTu.Location = new System.Drawing.Point(409, 178);
            this.calBatDauTu.Name = "calBatDauTu";
            this.calBatDauTu.Size = new System.Drawing.Size(152, 20);
            this.calBatDauTu.TabIndex = 4;
            this.calBatDauTu.Value = new System.DateTime(2011, 5, 26, 15, 3, 55, 0);
            this.calBatDauTu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.calBatDauTu_KeyDown);
            this.calBatDauTu.TextChanged += new System.EventHandler(this.calBatDauTu_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "&Điện thoại";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(609, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "&Công ty";
            // 
            // cbCongTy
            // 
            this.cbCongTy.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cbCongTy.Location = new System.Drawing.Point(685, 110);
            this.cbCongTy.Name = "cbCongTy";
            this.cbCongTy.Size = new System.Drawing.Size(152, 20);
            this.cbCongTy.TabIndex = 2;
            this.cbCongTy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCongTy_KeyDown);
            this.cbCongTy.TextChanged += new System.EventHandler(this.cbCongTy_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(336, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Từ &ngày";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(612, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "&Đến ngày";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(612, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Đến n&gày";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(333, 182);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "&Từ ngày ";
            // 
            // calKetThucTu
            // 
            this.calKetThucTu.CustomFormat = "HH:mm dd/MM/yyyy";
            this.calKetThucTu.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calKetThucTu.DropDownCalendar.FirstMonth = new System.DateTime(2011, 5, 1, 0, 0, 0, 0);
            this.calKetThucTu.DropDownCalendar.Name = "";
            this.calKetThucTu.Enabled = false;
            this.calKetThucTu.Location = new System.Drawing.Point(409, 209);
            this.calKetThucTu.Name = "calKetThucTu";
            this.calKetThucTu.Size = new System.Drawing.Size(152, 20);
            this.calKetThucTu.TabIndex = 7;
            this.calKetThucTu.Value = new System.DateTime(2011, 5, 26, 15, 3, 43, 0);
            this.calKetThucTu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.calKetThucTu_KeyDown);
            this.calKetThucTu.TextChanged += new System.EventHandler(this.calKetThucTu_TextChanged);
            // 
            // calBatDauDen
            // 
            this.calBatDauDen.CustomFormat = "HH:mm dd/MM/yyyy";
            this.calBatDauDen.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calBatDauDen.DropDownCalendar.FirstMonth = new System.DateTime(2011, 5, 1, 0, 0, 0, 0);
            this.calBatDauDen.DropDownCalendar.Name = "";
            this.calBatDauDen.Enabled = false;
            this.calBatDauDen.Location = new System.Drawing.Point(685, 178);
            this.calBatDauDen.Name = "calBatDauDen";
            this.calBatDauDen.Size = new System.Drawing.Size(152, 20);
            this.calBatDauDen.TabIndex = 5;
            this.calBatDauDen.Value = new System.DateTime(2011, 5, 26, 15, 4, 7, 0);
            this.calBatDauDen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.calBatDauDen_KeyDown);
            this.calBatDauDen.TextChanged += new System.EventHandler(this.calBatDauDen_TextChanged);
            // 
            // calKetThucDen
            // 
            this.calKetThucDen.CustomFormat = "HH:mm dd/MM/yyyy";
            this.calKetThucDen.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calKetThucDen.DropDownCalendar.FirstMonth = new System.DateTime(2011, 5, 1, 0, 0, 0, 0);
            this.calKetThucDen.DropDownCalendar.Name = "";
            this.calKetThucDen.Enabled = false;
            this.calKetThucDen.Location = new System.Drawing.Point(685, 209);
            this.calKetThucDen.Name = "calKetThucDen";
            this.calKetThucDen.Size = new System.Drawing.Size(152, 20);
            this.calKetThucDen.TabIndex = 8;
            this.calKetThucDen.Value = new System.DateTime(2011, 5, 26, 15, 4, 13, 0);
            this.calKetThucDen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.calKetThucDen_KeyDown);
            this.calKetThucDen.TextChanged += new System.EventHandler(this.calKetThucDen_TextChanged);
            // 
            // grdDSDiaChiMoiGioi
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdDSDiaChiMoiGioi.DesignTimeLayout = gridEXLayout1;
            this.grdDSDiaChiMoiGioi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdDSDiaChiMoiGioi.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdDSDiaChiMoiGioi.GroupByBoxVisible = false;
            this.grdDSDiaChiMoiGioi.Location = new System.Drawing.Point(0, 313);
            this.grdDSDiaChiMoiGioi.Name = "grdDSDiaChiMoiGioi";
            this.grdDSDiaChiMoiGioi.SaveSettings = false;
            this.grdDSDiaChiMoiGioi.Size = new System.Drawing.Size(1147, 297);
            this.grdDSDiaChiMoiGioi.TabIndex = 11;
            this.grdDSDiaChiMoiGioi.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdDSDiaChiMoiGioi_FormattingRow);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Button;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::TaxiOperaion_MoiGioi.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(410, 243);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 33);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnRefresh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnRefresh_KeyDown);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Button;
            this.btnExportExcel.Enabled = false;
            this.btnExportExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Image = global::TaxiOperaion_MoiGioi.Properties.Resources.Excel_24x24;
            this.btnExportExcel.Location = new System.Drawing.Point(555, 243);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(100, 33);
            this.btnExportExcel.TabIndex = 10;
            this.btnExportExcel.Text = "&Xuất Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            this.btnExportExcel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnExportExcel_KeyDown);
            // 
            // chkBDTatCa
            // 
            this.chkBDTatCa.ImageAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            this.chkBDTatCa.Location = new System.Drawing.Point(231, 179);
            this.chkBDTatCa.Name = "chkBDTatCa";
            this.chkBDTatCa.Size = new System.Drawing.Size(85, 23);
            this.chkBDTatCa.TabIndex = 3;
            this.chkBDTatCa.Text = "Ngày &bắt đầu";
            this.chkBDTatCa.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            this.chkBDTatCa.Click += new System.EventHandler(this.chkBDTatCa_Click);
            this.chkBDTatCa.CheckedChanged += new System.EventHandler(this.chkBDTatCa_CheckedChanged);
            this.chkBDTatCa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkBDTatCa_KeyDown);
            // 
            // chkKTTatCa
            // 
            this.chkKTTatCa.ImageAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            this.chkKTTatCa.Location = new System.Drawing.Point(231, 209);
            this.chkKTTatCa.Name = "chkKTTatCa";
            this.chkKTTatCa.Size = new System.Drawing.Size(85, 23);
            this.chkKTTatCa.TabIndex = 6;
            this.chkKTTatCa.Text = "Ngày &kết thúc";
            this.chkKTTatCa.Click += new System.EventHandler(this.chkKTTatCa_Click);
            this.chkKTTatCa.CheckedChanged += new System.EventHandler(this.chkKTTatCa_CheckedChanged);
            this.chkKTTatCa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkKTTatCa_KeyDown);
            // 
            // txtMaMoiGioi
            // 
            this.txtMaMoiGioi.Location = new System.Drawing.Point(409, 74);
            this.txtMaMoiGioi.Name = "txtMaMoiGioi";
            this.txtMaMoiGioi.Size = new System.Drawing.Size(152, 20);
            this.txtMaMoiGioi.TabIndex = 0;
            this.txtMaMoiGioi.TextChanged += new System.EventHandler(this.txtMaMoiGioi_TextChanged);
            this.txtMaMoiGioi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaMoiGioi_KeyDown);
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.grdDSDiaChiMoiGioi;
            // 
            // gridEXPrintDocument1
            // 
            this.gridEXPrintDocument1.GridEX = this.grdDSDiaChiMoiGioi;
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
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.gridEXPrintDocument1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(609, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Địa chỉ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(333, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Tên phố";
            // 
            // txtTenDuong
            // 
            this.txtTenDuong.Location = new System.Drawing.Point(409, 144);
            this.txtTenDuong.Name = "txtTenDuong";
            this.txtTenDuong.Size = new System.Drawing.Size(152, 20);
            this.txtTenDuong.TabIndex = 21;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(685, 146);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(152, 20);
            this.txtDiaChi.TabIndex = 25;
            // 
            // frmBC_6_1_DSDiaChiMoiGioi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 610);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTenDuong);
            this.Controls.Add(this.txtMaMoiGioi);
            this.Controls.Add(this.chkKTTatCa);
            this.Controls.Add(this.chkBDTatCa);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.grdDSDiaChiMoiGioi);
            this.Controls.Add(this.calKetThucDen);
            this.Controls.Add(this.calBatDauDen);
            this.Controls.Add(this.calKetThucTu);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbCongTy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.calBatDauTu);
            this.Controls.Add(this.txtDienThoai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_6_1_DSDiaChiMoiGioi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo cáo danh sách địa chỉ môi giới";
            this.Load += new System.EventHandler(this.frmBC_6_1_DSDiaChiMoiGioi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDSDiaChiMoiGioi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDienThoai;
        private Janus.Windows.CalendarCombo.CalendarCombo calBatDauTu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Janus.Windows.EditControls.UIComboBox cbCongTy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private Janus.Windows.CalendarCombo.CalendarCombo calKetThucTu;
        private Janus.Windows.CalendarCombo.CalendarCombo calBatDauDen;
        private Janus.Windows.CalendarCombo.CalendarCombo calKetThucDen;
        private Janus.Windows.GridEX.GridEX grdDSDiaChiMoiGioi;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.EditControls.UICheckBox chkBDTatCa;
        private Janus.Windows.EditControls.UICheckBox chkKTTatCa;
        private System.Windows.Forms.TextBox txtMaMoiGioi;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTenDuong;
        private System.Windows.Forms.TextBox txtDiaChi;
    }
}