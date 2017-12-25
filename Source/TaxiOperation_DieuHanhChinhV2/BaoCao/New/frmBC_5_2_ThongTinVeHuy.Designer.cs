namespace Taxi.GUI
{
    partial class frmBC_5_2_ThongTinVeHuy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_5_2_ThongTinVeHuy));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkHopDongHuy = new System.Windows.Forms.CheckBox();
            this.chkQuyDinhHanMuc = new System.Windows.Forms.CheckBox();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboCongTy = new Janus.Windows.EditControls.UIComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numSeri = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.calDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numSoHopDong = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.grdVePhatHanh = new Janus.Windows.GridEX.GridEX();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVePhatHanh)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkHopDongHuy);
            this.groupBox1.Controls.Add(this.chkQuyDinhHanMuc);
            this.groupBox1.Controls.Add(this.txtTenKhachHang);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboCongTy);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numSeri);
            this.groupBox1.Controls.Add(this.calDenNgay);
            this.groupBox1.Controls.Add(this.calTuNgay);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numSoHopDong);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnXuatExcel);
            this.groupBox1.Controls.Add(this.btnThemMoi);
            this.groupBox1.Location = new System.Drawing.Point(110, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 169);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // chkHopDongHuy
            // 
            this.chkHopDongHuy.AutoSize = true;
            this.chkHopDongHuy.Location = new System.Drawing.Point(270, 121);
            this.chkHopDongHuy.Name = "chkHopDongHuy";
            this.chkHopDongHuy.Size = new System.Drawing.Size(94, 17);
            this.chkHopDongHuy.TabIndex = 39;
            this.chkHopDongHuy.Text = "Hợp đồng hủy";
            this.chkHopDongHuy.UseVisualStyleBackColor = true;
            this.chkHopDongHuy.CheckedChanged += new System.EventHandler(this.chkHopDongHuy_CheckedChanged);
            // 
            // chkQuyDinhHanMuc
            // 
            this.chkQuyDinhHanMuc.AutoSize = true;
            this.chkQuyDinhHanMuc.Location = new System.Drawing.Point(140, 121);
            this.chkQuyDinhHanMuc.Name = "chkQuyDinhHanMuc";
            this.chkQuyDinhHanMuc.Size = new System.Drawing.Size(113, 17);
            this.chkQuyDinhHanMuc.TabIndex = 38;
            this.chkQuyDinhHanMuc.Text = "Quy định hạn mức";
            this.chkQuyDinhHanMuc.UseVisualStyleBackColor = true;
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Location = new System.Drawing.Point(140, 97);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(318, 20);
            this.txtTenKhachHang.TabIndex = 5;
            this.txtTenKhachHang.TextChanged += new System.EventHandler(this.txtTenKhachHang_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Tên khách hàng";
            // 
            // cboCongTy
            // 
            this.cboCongTy.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboCongTy.Location = new System.Drawing.Point(300, 45);
            this.cboCongTy.Name = "cboCongTy";
            this.cboCongTy.Size = new System.Drawing.Size(158, 20);
            this.cboCongTy.TabIndex = 3;
            this.cboCongTy.SelectedIndexChanged += new System.EventHandler(this.cboCongTy_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(240, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Đơn vị  (*)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Seri";
            // 
            // numSeri
            // 
            this.numSeri.Location = new System.Drawing.Point(140, 71);
            this.numSeri.Name = "numSeri";
            this.numSeri.Size = new System.Drawing.Size(92, 20);
            this.numSeri.TabIndex = 4;
            this.numSeri.Text = "0";
            this.numSeri.ValueType = Janus.Windows.GridEX.NumericEditValueType.UInt64;
            this.numSeri.Click += new System.EventHandler(this.numSeri_Click);
            // 
            // calDenNgay
            // 
            // 
            // 
            // 
            this.calDenNgay.DropDownCalendar.FirstMonth = new System.DateTime(2009, 5, 1, 0, 0, 0, 0);
            this.calDenNgay.DropDownCalendar.Name = "";
            this.calDenNgay.Location = new System.Drawing.Point(300, 19);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Size = new System.Drawing.Size(92, 20);
            this.calDenNgay.TabIndex = 1;
            this.calDenNgay.ValueChanged += new System.EventHandler(this.calDenNgay_ValueChanged);
            // 
            // calTuNgay
            // 
            // 
            // 
            // 
            this.calTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2009, 5, 1, 0, 0, 0, 0);
            this.calTuNgay.DropDownCalendar.Name = "";
            this.calTuNgay.Location = new System.Drawing.Point(140, 19);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(92, 20);
            this.calTuNgay.TabIndex = 0;
            this.calTuNgay.ValueChanged += new System.EventHandler(this.calTuNgay_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(242, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Đến ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Ngày hủy Từ ngày";
            // 
            // numSoHopDong
            // 
            this.numSoHopDong.Location = new System.Drawing.Point(140, 45);
            this.numSoHopDong.Name = "numSoHopDong";
            this.numSoHopDong.Size = new System.Drawing.Size(92, 20);
            this.numSoHopDong.TabIndex = 2;
            this.numSoHopDong.Text = "0";
            this.numSoHopDong.ValueType = Janus.Windows.GridEX.NumericEditValueType.UInt64;
            this.numSoHopDong.Click += new System.EventHandler(this.numSoHopDong_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Hợp đồng";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(207, 142);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(68, 23);
            this.btnXuatExcel.TabIndex = 7;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Location = new System.Drawing.Point(140, 142);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(61, 23);
            this.btnThemMoi.TabIndex = 6;
            this.btnThemMoi.Text = "Làm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // grdVePhatHanh
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdVePhatHanh.DesignTimeLayout = gridEXLayout1;
            this.grdVePhatHanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdVePhatHanh.GroupByBoxVisible = false;
            this.grdVePhatHanh.Location = new System.Drawing.Point(25, 187);
            this.grdVePhatHanh.Name = "grdVePhatHanh";
            this.grdVePhatHanh.SaveSettings = false;
            this.grdVePhatHanh.Size = new System.Drawing.Size(987, 501);
            this.grdVePhatHanh.TabIndex = 1;
            this.grdVePhatHanh.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdVePhatHanh_FormattingRow);
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.grdVePhatHanh;
            // 
            // frmBC_5_2_ThongTinVeHuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 692);
            this.Controls.Add(this.grdVePhatHanh);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_5_2_ThongTinVeHuy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "5.2 Báo cáo thông tin vé hủy";
            this.Load += new System.EventHandler(this.frmVePhatHanh_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVePhatHanh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Janus.Windows.GridEX.GridEX grdVePhatHanh;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnXuatExcel;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Janus.Windows.GridEX.EditControls.NumericEditBox numSoHopDong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.CalendarCombo.CalendarCombo calDenNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuNgay;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.EditControls.NumericEditBox numSeri;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.Label label8;
        private Janus.Windows.EditControls.UIComboBox cboCongTy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkQuyDinhHanMuc;
        private System.Windows.Forms.CheckBox chkHopDongHuy;

    }
}