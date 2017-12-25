namespace Taxi.GUI
{
    partial class frmVeSuDung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVeSuDung));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSoHieuXe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numSoTien = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHopDong = new System.Windows.Forms.Label();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.numSeriDau = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.calNgaySuDung = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdVeSuDung = new Janus.Windows.GridEX.GridEX();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVeSuDung)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSoHieuXe);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numSoTien);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblHopDong);
            this.groupBox1.Controls.Add(this.btnXuatExcel);
            this.groupBox1.Controls.Add(this.numSeriDau);
            this.groupBox1.Controls.Add(this.calNgaySuDung);
            this.groupBox1.Controls.Add(this.btnHuyBo);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Controls.Add(this.btnThemMoi);
            this.groupBox1.Controls.Add(this.txtGhiChu);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(221, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sử dụng";
            // 
            // txtSoHieuXe
            // 
            this.txtSoHieuXe.Location = new System.Drawing.Point(132, 103);
            this.txtSoHieuXe.Name = "txtSoHieuXe";
            this.txtSoHieuXe.Size = new System.Drawing.Size(100, 20);
            this.txtSoHieuXe.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Số hiệu xe  (*)";
            // 
            // numSoTien
            // 
            this.numSoTien.Location = new System.Drawing.Point(132, 77);
            this.numSoTien.Name = "numSoTien";
            this.numSoTien.Size = new System.Drawing.Size(100, 20);
            this.numSoTien.TabIndex = 2;
            this.numSoTien.Text = "0";
            this.numSoTien.ValueType = Janus.Windows.GridEX.NumericEditValueType.UInt64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Số tiền  (*)";
            // 
            // lblHopDong
            // 
            this.lblHopDong.AutoSize = true;
            this.lblHopDong.Location = new System.Drawing.Point(238, 54);
            this.lblHopDong.Name = "lblHopDong";
            this.lblHopDong.Size = new System.Drawing.Size(60, 13);
            this.lblHopDong.TabIndex = 24;
            this.lblHopDong.Text = "[Hop dong]";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(400, 179);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(68, 23);
            this.btnXuatExcel.TabIndex = 8;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // numSeriDau
            // 
            this.numSeriDau.Location = new System.Drawing.Point(132, 51);
            this.numSeriDau.Name = "numSeriDau";
            this.numSeriDau.Size = new System.Drawing.Size(100, 20);
            this.numSeriDau.TabIndex = 1;
            this.numSeriDau.Text = "0";
            this.numSeriDau.ValueType = Janus.Windows.GridEX.NumericEditValueType.UInt64;
            this.numSeriDau.ValueChanged += new System.EventHandler(this.numSeriDau_ValueChanged);
            this.numSeriDau.Leave += new System.EventHandler(this.numSeriDau_Leave);
            // 
            // calNgaySuDung
            // 
            // 
            // 
            // 
            this.calNgaySuDung.DropDownCalendar.FirstMonth = new System.DateTime(2009, 5, 1, 0, 0, 0, 0);
            this.calNgaySuDung.DropDownCalendar.Name = "";
            this.calNgaySuDung.Location = new System.Drawing.Point(132, 22);
            this.calNgaySuDung.Name = "calNgaySuDung";
            this.calNgaySuDung.Size = new System.Drawing.Size(100, 20);
            this.calNgaySuDung.TabIndex = 0;
            this.calNgaySuDung.Value = new System.DateTime(2009, 5, 10, 0, 0, 0, 0);
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(199, 179);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(61, 23);
            this.btnHuyBo.TabIndex = 6;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.UseVisualStyleBackColor = true;
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(333, 179);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(61, 23);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(266, 179);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(61, 23);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Location = new System.Drawing.Point(132, 179);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(61, 23);
            this.btnThemMoi.TabIndex = 9;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(132, 129);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(336, 20);
            this.txtGhiChu.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Ghi chú";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Seri đầu  (*)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ngày sử dụng (*)";
            // 
            // grdVeSuDung
            // 
            this.grdVeSuDung.AllowColumnDrag = false;
            this.grdVeSuDung.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdVeSuDung.DesignTimeLayout = gridEXLayout1;
            this.grdVeSuDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.grdVeSuDung.Location = new System.Drawing.Point(12, 217);
            this.grdVeSuDung.Name = "grdVeSuDung";
            this.grdVeSuDung.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.grdVeSuDung.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdVeSuDung.SaveSettings = false;
            this.grdVeSuDung.Size = new System.Drawing.Size(1033, 404);
            this.grdVeSuDung.TabIndex = 1;
            this.grdVeSuDung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdVePhatHanh_KeyDown);
            this.grdVeSuDung.DoubleClick += new System.EventHandler(this.grdVePhatHanh_DoubleClick);
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.grdVeSuDung;
            // 
            // frmVeSuDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 633);
            this.Controls.Add(this.grdVeSuDung);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVeSuDung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập vé sử dụng";
            this.Load += new System.EventHandler(this.frmVeSuDung_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVeSuDung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.GridEX.GridEX grdVeSuDung;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnHuyBo;
        private Janus.Windows.CalendarCombo.CalendarCombo calNgaySuDung;
        private Janus.Windows.GridEX.EditControls.NumericEditBox numSeriDau;
        private System.Windows.Forms.Button btnXuatExcel;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblHopDong;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.GridEX.EditControls.NumericEditBox numSoTien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoHieuXe;

    }
}