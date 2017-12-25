namespace Taxi.GUI
{
    partial class frmVePhatHanh
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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout6 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVePhatHanh));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.numSoLuong = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numSeriCuoi = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numSeriDau = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.numSoHopDong = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.cboKhachHang = new Janus.Windows.EditControls.UIComboBox();
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
            this.grdVePhatHanh = new Janus.Windows.GridEX.GridEX();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVePhatHanh)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXuatExcel);
            this.groupBox1.Controls.Add(this.numSoLuong);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.numSeriCuoi);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numSeriDau);
            this.groupBox1.Controls.Add(this.numSoHopDong);
            this.groupBox1.Controls.Add(this.cboKhachHang);
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
            this.groupBox1.Size = new System.Drawing.Size(568, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phát hành";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(400, 168);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(68, 23);
            this.btnXuatExcel.TabIndex = 22;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(468, 100);
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.ReadOnly = true;
            this.numSoLuong.Size = new System.Drawing.Size(94, 20);
            this.numSoLuong.TabIndex = 21;
            this.numSoLuong.Text = "0";
            this.numSoLuong.ValueType = Janus.Windows.GridEX.NumericEditValueType.UInt64;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(416, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Số lượng ";
            // 
            // numSeriCuoi
            // 
            this.numSeriCuoi.Location = new System.Drawing.Point(310, 100);
            this.numSeriCuoi.Name = "numSeriCuoi";
            this.numSeriCuoi.Size = new System.Drawing.Size(100, 20);
            this.numSeriCuoi.TabIndex = 19;
            this.numSeriCuoi.Text = "0";
            this.numSeriCuoi.ValueType = Janus.Windows.GridEX.NumericEditValueType.UInt64;
            this.numSeriCuoi.ValueChanged += new System.EventHandler(this.numSeriCuoi_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Seri cuối  (*)";
            // 
            // numSeriDau
            // 
            this.numSeriDau.Location = new System.Drawing.Point(132, 100);
            this.numSeriDau.Name = "numSeriDau";
            this.numSeriDau.Size = new System.Drawing.Size(100, 20);
            this.numSeriDau.TabIndex = 17;
            this.numSeriDau.Text = "0";
            this.numSeriDau.ValueType = Janus.Windows.GridEX.NumericEditValueType.UInt64;
            this.numSeriDau.ValueChanged += new System.EventHandler(this.numSeriDau_ValueChanged);
            // 
            // numSoHopDong
            // 
            this.numSoHopDong.Location = new System.Drawing.Point(132, 74);
            this.numSoHopDong.Name = "numSoHopDong";
            this.numSoHopDong.Size = new System.Drawing.Size(100, 20);
            this.numSoHopDong.TabIndex = 16;
            this.numSoHopDong.Text = "0";
            this.numSoHopDong.ValueType = Janus.Windows.GridEX.NumericEditValueType.UInt64;
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboKhachHang.Location = new System.Drawing.Point(132, 48);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(336, 20);
            this.cboKhachHang.TabIndex = 15;
            // 
            // calNgayPhatHanh
            // 
            // 
            // 
            // 
            this.calNgayPhatHanh.DropDownCalendar.FirstMonth = new System.DateTime(2009, 5, 1, 0, 0, 0, 0);
            this.calNgayPhatHanh.DropDownCalendar.Name = "";
            this.calNgayPhatHanh.Location = new System.Drawing.Point(132, 22);
            this.calNgayPhatHanh.Name = "calNgayPhatHanh";
            this.calNgayPhatHanh.Size = new System.Drawing.Size(92, 20);
            this.calNgayPhatHanh.TabIndex = 14;
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(199, 168);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(61, 23);
            this.btnHuyBo.TabIndex = 13;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.UseVisualStyleBackColor = true;
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(333, 168);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(61, 23);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(266, 168);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(61, 23);
            this.btnLuu.TabIndex = 11;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Location = new System.Drawing.Point(132, 168);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(61, 23);
            this.btnThemMoi.TabIndex = 10;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(132, 130);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(336, 20);
            this.txtGhiChu.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ghi chú";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Seri đầu  (*)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số hợp đồng (*)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Khách hàng (*)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày phát hành (*)";
            // 
            // grdVePhatHanh
            // 
            this.grdVePhatHanh.AllowColumnDrag = false;
            this.grdVePhatHanh.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout6.LayoutString = resources.GetString("gridEXLayout6.LayoutString");
            this.grdVePhatHanh.DesignTimeLayout = gridEXLayout6;
            this.grdVePhatHanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.grdVePhatHanh.Location = new System.Drawing.Point(12, 217);
            this.grdVePhatHanh.Name = "grdVePhatHanh";
            this.grdVePhatHanh.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.grdVePhatHanh.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdVePhatHanh.SaveSettings = false;
            this.grdVePhatHanh.Size = new System.Drawing.Size(1033, 404);
            this.grdVePhatHanh.TabIndex = 1;
            this.grdVePhatHanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdVePhatHanh_KeyDown);
            this.grdVePhatHanh.DoubleClick += new System.EventHandler(this.grdVePhatHanh_DoubleClick);
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.grdVePhatHanh;
            // 
            // frmVePhatHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 633);
            this.Controls.Add(this.grdVePhatHanh);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVePhatHanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập vé phát hành";
            this.Load += new System.EventHandler(this.frmVePhatHanh_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVePhatHanh)).EndInit();
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
        private Janus.Windows.GridEX.GridEX grdVePhatHanh;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnHuyBo;
        private Janus.Windows.EditControls.UIComboBox cboKhachHang;
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

    }
}