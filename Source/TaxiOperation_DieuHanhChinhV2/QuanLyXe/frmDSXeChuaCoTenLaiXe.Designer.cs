namespace Taxi.GUI
{
    partial class frmDSXeChuaCoTenLaiXe
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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDSXeChuaCoTenLaiXe));
            this.grdDSXeChuaCoLai = new Janus.Windows.GridEX.GridEX();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNhapTuExcel = new System.Windows.Forms.Button();
            this.calendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.radXeChuaCoTen = new System.Windows.Forms.RadioButton();
            this.radTatCaXe = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdDSXeChuaCoLai)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDSXeChuaCoLai
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdDSXeChuaCoLai.DesignTimeLayout = gridEXLayout1;
            this.grdDSXeChuaCoLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDSXeChuaCoLai.GroupByBoxVisible = false;
            this.grdDSXeChuaCoLai.Location = new System.Drawing.Point(12, 48);
            this.grdDSXeChuaCoLai.Name = "grdDSXeChuaCoLai";
            this.grdDSXeChuaCoLai.SaveSettings = false;
            this.grdDSXeChuaCoLai.Size = new System.Drawing.Size(478, 452);
            this.grdDSXeChuaCoLai.TabIndex = 0;
            this.grdDSXeChuaCoLai.DoubleClick += new System.EventHandler(this.grdDSXeChuaCoLai_DoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(260, 506);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNhapTuExcel
            // 
            this.btnNhapTuExcel.Location = new System.Drawing.Point(148, 506);
            this.btnNhapTuExcel.Name = "btnNhapTuExcel";
            this.btnNhapTuExcel.Size = new System.Drawing.Size(106, 35);
            this.btnNhapTuExcel.TabIndex = 2;
            this.btnNhapTuExcel.Text = "Nhập lái xe từ file Excel";
            this.btnNhapTuExcel.UseVisualStyleBackColor = true;
            this.btnNhapTuExcel.Click += new System.EventHandler(this.btnNhapTuExcel_Click);
            // 
            // calendarCombo1
            // 
            // 
            // 
            // 
            this.calendarCombo1.DropDownCalendar.FirstMonth = new System.DateTime(2009, 12, 1, 0, 0, 0, 0);
            this.calendarCombo1.DropDownCalendar.Name = "";
            this.calendarCombo1.Location = new System.Drawing.Point(58, 10);
            this.calendarCombo1.Name = "calendarCombo1";
            this.calendarCombo1.Size = new System.Drawing.Size(88, 20);
            this.calendarCombo1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ngày";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(358, 8);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // radXeChuaCoTen
            // 
            this.radXeChuaCoTen.AutoSize = true;
            this.radXeChuaCoTen.Checked = true;
            this.radXeChuaCoTen.Location = new System.Drawing.Point(157, 10);
            this.radXeChuaCoTen.Name = "radXeChuaCoTen";
            this.radXeChuaCoTen.Size = new System.Drawing.Size(125, 17);
            this.radXeChuaCoTen.TabIndex = 6;
            this.radXeChuaCoTen.TabStop = true;
            this.radXeChuaCoTen.Text = "Xe chưa có tên lái xe";
            this.radXeChuaCoTen.UseVisualStyleBackColor = true;
            // 
            // radTatCaXe
            // 
            this.radTatCaXe.AutoSize = true;
            this.radTatCaXe.Location = new System.Drawing.Point(286, 10);
            this.radTatCaXe.Name = "radTatCaXe";
            this.radTatCaXe.Size = new System.Drawing.Size(70, 17);
            this.radTatCaXe.TabIndex = 7;
            this.radTatCaXe.Text = "Tất cả xe";
            this.radTatCaXe.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Salmon;
            this.label2.Location = new System.Drawing.Point(155, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Doubleclick để chọn dòng sửa đổi thông tin lái xe.";
            // 
            // frmDSXeChuaCoTenLaiXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 543);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radTatCaXe);
            this.Controls.Add(this.radXeChuaCoTen);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.calendarCombo1);
            this.Controls.Add(this.btnNhapTuExcel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grdDSXeChuaCoLai);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDSXeChuaCoTenLaiXe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách xe chưa có tên lái xe";
            this.Load += new System.EventHandler(this.frmDSXeChuaCoTenLaiXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDSXeChuaCoLai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.GridEX.GridEX grdDSXeChuaCoLai;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNhapTuExcel;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.RadioButton radXeChuaCoTen;
        private System.Windows.Forms.RadioButton radTatCaXe;
        private System.Windows.Forms.Label label2;
    }
}