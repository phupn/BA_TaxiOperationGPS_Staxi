namespace Taxi.GUI
{
    partial class frmBCVeTheoHopDong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBCVeTheoHopDong));
            Janus.Windows.GridEX.GridEXLayout gridEXLayout2 = new Janus.Windows.GridEX.GridEXLayout();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.calDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numSoHopDong = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLienHe = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.grdVePhatHanh = new Janus.Windows.GridEX.GridEX();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grdVeSuDung = new Janus.Windows.GridEX.GridEX();
            this.gridEXExporter2 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVePhatHanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVeSuDung)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.calDenNgay);
            this.groupBox1.Controls.Add(this.calTuNgay);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numSoHopDong);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblKhachHang);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblLienHe);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnXuatExcel);
            this.groupBox1.Controls.Add(this.btnThemMoi);
            this.groupBox1.Location = new System.Drawing.Point(133, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 169);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phát hành";
            // 
            // calDenNgay
            // 
            // 
            // 
            // 
            this.calDenNgay.DropDownCalendar.FirstMonth = new System.DateTime(2009, 5, 1, 0, 0, 0, 0);
            this.calDenNgay.DropDownCalendar.Name = "";
            this.calDenNgay.Location = new System.Drawing.Point(280, 46);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(92, 20);
            this.calDenNgay.TabIndex = 31;
            this.calDenNgay.TextChanged += new System.EventHandler(this.calTuNgay_TextChanged);
            // 
            // calTuNgay
            // 
            // 
            // 
            // 
            this.calTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2009, 5, 1, 0, 0, 0, 0);
            this.calTuNgay.DropDownCalendar.Name = "";
            this.calTuNgay.Location = new System.Drawing.Point(112, 46);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(92, 20);
            this.calTuNgay.TabIndex = 30;
            this.calTuNgay.TextChanged += new System.EventHandler(this.calTuNgay_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Đến ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Từ ngày";
            // 
            // numSoHopDong
            // 
            this.numSoHopDong.Location = new System.Drawing.Point(112, 20);
            this.numSoHopDong.Name = "numSoHopDong";
            this.numSoHopDong.Size = new System.Drawing.Size(92, 20);
            this.numSoHopDong.TabIndex = 2;
            this.numSoHopDong.Text = "0";
            this.numSoHopDong.ValueType = Janus.Windows.GridEX.NumericEditValueType.UInt64;
            this.numSoHopDong.TextChanged += new System.EventHandler(this.numSoHopDong_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Hộp đồng";
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Location = new System.Drawing.Point(110, 69);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(65, 13);
            this.lblKhachHang.TabIndex = 26;
            this.lblKhachHang.Text = "Khach hagn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Khách hàng";
            // 
            // lblLienHe
            // 
            this.lblLienHe.AutoSize = true;
            this.lblLienHe.Location = new System.Drawing.Point(110, 92);
            this.lblLienHe.Name = "lblLienHe";
            this.lblLienHe.Size = new System.Drawing.Size(69, 13);
            this.lblLienHe.TabIndex = 24;
            this.lblLienHe.Text = "Người liên hệ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Người liên hệ";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(183, 130);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(68, 23);
            this.btnXuatExcel.TabIndex = 22;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Location = new System.Drawing.Point(116, 130);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(61, 23);
            this.btnThemMoi.TabIndex = 10;
            this.btnThemMoi.Text = "Làm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // grdVePhatHanh
            // 
            this.grdVePhatHanh.AllowColumnDrag = false;
            this.grdVePhatHanh.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdVePhatHanh.DesignTimeLayout = gridEXLayout1;
            this.grdVePhatHanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.grdVePhatHanh.Location = new System.Drawing.Point(25, 195);
            this.grdVePhatHanh.Name = "grdVePhatHanh";
            this.grdVePhatHanh.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.grdVePhatHanh.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdVePhatHanh.SaveSettings = false;
            this.grdVePhatHanh.Size = new System.Drawing.Size(777, 209);
            this.grdVePhatHanh.TabIndex = 1;
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.grdVePhatHanh;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(290, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Vé tồn khách hàng đang quản lý chưa sử dụng đến cuối kỳ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 414);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Vé  khách hàng sử dụng trong kỳ";
            // 
            // grdVeSuDung
            // 
            this.grdVeSuDung.AllowColumnDrag = false;
            this.grdVeSuDung.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout2.LayoutString = resources.GetString("gridEXLayout2.LayoutString");
            this.grdVeSuDung.DesignTimeLayout = gridEXLayout2;
            this.grdVeSuDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.grdVeSuDung.Location = new System.Drawing.Point(25, 430);
            this.grdVeSuDung.Name = "grdVeSuDung";
            this.grdVeSuDung.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.grdVeSuDung.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdVeSuDung.SaveSettings = false;
            this.grdVeSuDung.Size = new System.Drawing.Size(777, 250);
            this.grdVeSuDung.TabIndex = 5;
            // 
            // gridEXExporter2
            // 
            this.gridEXExporter2.GridEX = this.grdVeSuDung;
            // 
            // frmBCVeTheoHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 692);
            this.Controls.Add(this.grdVeSuDung);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.grdVePhatHanh);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBCVeTheoHopDong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo vé theo hợp đồng";
            this.Load += new System.EventHandler(this.frmVePhatHanh_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVePhatHanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVeSuDung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Janus.Windows.GridEX.GridEX grdVePhatHanh;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnXuatExcel;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLienHe;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.EditControls.NumericEditBox numSoHopDong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.CalendarCombo.CalendarCombo calDenNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuNgay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Janus.Windows.GridEX.GridEX grdVeSuDung;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter2;

    }
}