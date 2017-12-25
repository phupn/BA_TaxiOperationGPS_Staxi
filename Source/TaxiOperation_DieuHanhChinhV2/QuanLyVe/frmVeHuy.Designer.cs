namespace Taxi.GUI
{
    partial class frmVeHuy
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
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem1 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem2 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVeHuy));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkTamNhap = new Janus.Windows.EditControls.UICheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkNhapHopDongHuy = new Janus.Windows.EditControls.UICheckBox();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.cboCongTy = new Janus.Windows.EditControls.UIComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboLydoHuy = new Janus.Windows.EditControls.UIComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.numSoLuong = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numSeriCuoi = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numSeriDau = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.numSoHopDong = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.calNgayPhatHanh = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdVeHuy = new Janus.Windows.GridEX.GridEX();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVeHuy)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.chkTamNhap);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.chkNhapHopDongHuy);
            this.groupBox1.Controls.Add(this.txtTenKhachHang);
            this.groupBox1.Controls.Add(this.cboCongTy);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cboLydoHuy);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnXuatExcel);
            this.groupBox1.Controls.Add(this.numSoLuong);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.numSeriCuoi);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numSeriDau);
            this.groupBox1.Controls.Add(this.numSoHopDong);
            this.groupBox1.Controls.Add(this.calNgayPhatHanh);
            this.groupBox1.Controls.Add(this.btnHuyBo);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Controls.Add(this.btnThemMoi);
            this.groupBox1.Controls.Add(this.txtGhiChu);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(221, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 242);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hủy";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(380, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(152, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "(Bộ phận Trưởng ca tạm nhập)";
            // 
            // chkTamNhap
            // 
            this.chkTamNhap.Location = new System.Drawing.Point(310, 13);
            this.chkTamNhap.Name = "chkTamNhap";
            this.chkTamNhap.Size = new System.Drawing.Size(128, 23);
            this.chkTamNhap.TabIndex = 1;
            this.chkTamNhap.Text = "Tạm nhập";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(133, 199);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(361, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Ghi chú nhập tiền tố [GIOI HAN] để nhập hợp đồng chưa hủy có hạn mức.";
            // 
            // chkNhapHopDongHuy
            // 
            this.chkNhapHopDongHuy.Location = new System.Drawing.Point(132, 13);
            this.chkNhapHopDongHuy.Name = "chkNhapHopDongHuy";
            this.chkNhapHopDongHuy.Size = new System.Drawing.Size(128, 23);
            this.chkNhapHopDongHuy.TabIndex = 0;
            this.chkNhapHopDongHuy.Text = "Chỉ nhập hợp đồng hủy";
            this.chkNhapHopDongHuy.CheckedChanged += new System.EventHandler(this.chkNhapHopDongHuy_CheckedChanged);
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Location = new System.Drawing.Point(132, 128);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(360, 20);
            this.txtTenKhachHang.TabIndex = 8;
            // 
            // cboCongTy
            // 
            this.cboCongTy.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboCongTy.Location = new System.Drawing.Point(310, 42);
            this.cboCongTy.Name = "cboCongTy";
            this.cboCongTy.Size = new System.Drawing.Size(158, 20);
            this.cboCongTy.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(242, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Đơn vị  (*)";
            // 
            // cboLydoHuy
            // 
            this.cboLydoHuy.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            uiComboBoxItem1.FormatStyle.Alpha = 0;
            uiComboBoxItem1.Text = "Vé mất";
            uiComboBoxItem1.Value = "Vé mất";
            uiComboBoxItem2.FormatStyle.Alpha = 0;
            uiComboBoxItem2.Text = "Hủy hợp đồng";
            uiComboBoxItem2.Value = "Hủy hợp đồng";
            this.cboLydoHuy.Items.AddRange(new Janus.Windows.EditControls.UIComboBoxItem[] {
            uiComboBoxItem1,
            uiComboBoxItem2});
            this.cboLydoHuy.Location = new System.Drawing.Point(132, 97);
            this.cboLydoHuy.Name = "cboLydoHuy";
            this.cboLydoHuy.Size = new System.Drawing.Size(100, 20);
            this.cboLydoHuy.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Lý do hủy (*)";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(400, 214);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(68, 23);
            this.btnXuatExcel.TabIndex = 15;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(474, 72);
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.ReadOnly = true;
            this.numSoLuong.Size = new System.Drawing.Size(52, 20);
            this.numSoLuong.TabIndex = 6;
            this.numSoLuong.Text = "0";
            this.numSoLuong.ValueType = Janus.Windows.GridEX.NumericEditValueType.UInt64;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(416, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Số lượng ";
            // 
            // numSeriCuoi
            // 
            this.numSeriCuoi.Location = new System.Drawing.Point(310, 71);
            this.numSeriCuoi.Name = "numSeriCuoi";
            this.numSeriCuoi.Size = new System.Drawing.Size(100, 20);
            this.numSeriCuoi.TabIndex = 5;
            this.numSeriCuoi.Text = "0";
            this.numSeriCuoi.ValueType = Janus.Windows.GridEX.NumericEditValueType.UInt64;
            this.numSeriCuoi.ValueChanged += new System.EventHandler(this.numSeriCuoi_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Seri cuối  (*)";
            // 
            // numSeriDau
            // 
            this.numSeriDau.Location = new System.Drawing.Point(132, 71);
            this.numSeriDau.Name = "numSeriDau";
            this.numSeriDau.Size = new System.Drawing.Size(100, 20);
            this.numSeriDau.TabIndex = 4;
            this.numSeriDau.Text = "0";
            this.numSeriDau.ValueType = Janus.Windows.GridEX.NumericEditValueType.UInt64;
            this.numSeriDau.ValueChanged += new System.EventHandler(this.numSeriDau_ValueChanged);
            // 
            // numSoHopDong
            // 
            this.numSoHopDong.Location = new System.Drawing.Point(132, 151);
            this.numSoHopDong.Name = "numSoHopDong";
            this.numSoHopDong.Size = new System.Drawing.Size(100, 20);
            this.numSoHopDong.TabIndex = 9;
            this.numSoHopDong.Text = "0";
            this.numSoHopDong.ValueType = Janus.Windows.GridEX.NumericEditValueType.UInt64;
            // 
            // calNgayPhatHanh
            // 
            // 
            // 
            // 
            this.calNgayPhatHanh.DropDownCalendar.FirstMonth = new System.DateTime(2009, 5, 1, 0, 0, 0, 0);
            this.calNgayPhatHanh.DropDownCalendar.Name = "";
            this.calNgayPhatHanh.Location = new System.Drawing.Point(132, 42);
            this.calNgayPhatHanh.Name = "calNgayPhatHanh";
            this.calNgayPhatHanh.Size = new System.Drawing.Size(92, 20);
            this.calNgayPhatHanh.TabIndex = 2;
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(199, 214);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(61, 23);
            this.btnHuyBo.TabIndex = 12;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.UseVisualStyleBackColor = true;
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(333, 214);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(61, 23);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(266, 214);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(61, 23);
            this.btnLuu.TabIndex = 13;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Location = new System.Drawing.Point(132, 214);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(61, 23);
            this.btnThemMoi.TabIndex = 11;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(132, 174);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(360, 20);
            this.txtGhiChu.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ghi chú";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Seri đầu  (*)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số hợp đồng ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Khách hàng ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày nhập hủy (*)";
            // 
            // grdVeHuy
            // 
            this.grdVeHuy.AllowColumnDrag = false;
            this.grdVeHuy.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdVeHuy.DesignTimeLayout = gridEXLayout1;
            this.grdVeHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.grdVeHuy.GroupByBoxVisible = false;
            this.grdVeHuy.Location = new System.Drawing.Point(12, 253);
            this.grdVeHuy.Name = "grdVeHuy";
            this.grdVeHuy.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.grdVeHuy.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdVeHuy.SaveSettings = false;
            this.grdVeHuy.Size = new System.Drawing.Size(1033, 368);
            this.grdVeHuy.TabIndex = 1;
            this.grdVeHuy.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdVeHuy_FormattingRow);
            this.grdVeHuy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdVePhatHanh_KeyDown);
            this.grdVeHuy.DoubleClick += new System.EventHandler(this.grdVePhatHanh_DoubleClick);
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.grdVeHuy;
            // 
            // frmVeHuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 633);
            this.Controls.Add(this.grdVeHuy);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVeHuy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập vé hủy";
            this.Load += new System.EventHandler(this.frmVeHuy_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVeHuy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.GridEX grdVeHuy;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnHuyBo;
        private Janus.Windows.CalendarCombo.CalendarCombo calNgayPhatHanh;
        private Janus.Windows.GridEX.EditControls.NumericEditBox numSoHopDong;
        private Janus.Windows.GridEX.EditControls.NumericEditBox numSeriCuoi;
        private System.Windows.Forms.Label label6;
        private Janus.Windows.GridEX.EditControls.NumericEditBox numSeriDau;
        private Janus.Windows.GridEX.EditControls.NumericEditBox numSoLuong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnXuatExcel;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label8;
        private Janus.Windows.EditControls.UIComboBox cboLydoHuy;
        private Janus.Windows.EditControls.UIComboBox cboCongTy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private Janus.Windows.EditControls.UICheckBox chkNhapHopDongHuy;
        private System.Windows.Forms.Label label10;
        private Janus.Windows.EditControls.UICheckBox chkTamNhap;
        private System.Windows.Forms.Label label11;

    }
}