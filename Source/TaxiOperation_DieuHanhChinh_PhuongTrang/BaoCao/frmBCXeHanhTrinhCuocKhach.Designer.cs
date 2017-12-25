namespace Taxi.GUI
{
    partial class frmBCXeHanhTrinhCuocKhach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBCXeHanhTrinhCuocKhach));
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new Janus.Windows.EditControls.UIButton();
            this.calendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label2 = new System.Windows.Forms.Label();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnXuatExcel = new Janus.Windows.EditControls.UIButton();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.radCuocKhach = new Janus.Windows.EditControls.UIRadioButton();
            this.radDiaChi = new Janus.Windows.EditControls.UIRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ngày :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(525, 50);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 26);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = " &Tìm kiếm";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // calendarCombo1
            // 
            // 
            // 
            // 
            this.calendarCombo1.DropDownCalendar.FirstMonth = new System.DateTime(2009, 7, 1, 0, 0, 0, 0);
            this.calendarCombo1.DropDownCalendar.Name = "";
            this.calendarCombo1.Location = new System.Drawing.Point(409, 54);
            this.calendarCombo1.Name = "calendarCombo1";
            this.calendarCombo1.Size = new System.Drawing.Size(86, 20);
            this.calendarCombo1.TabIndex = 5;
            this.calendarCombo1.ValueChanged += new System.EventHandler(this.calendarCombo1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(352, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(345, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "HÀNH TRÌNH XE CUỐC KHÁCH THEO NGÀY";
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.gridEX1;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Enabled = false;
            this.btnXuatExcel.Location = new System.Drawing.Point(607, 50);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(78, 26);
            this.btnXuatExcel.TabIndex = 7;
            this.btnXuatExcel.Text = " &Xuất Excel";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // gridEX1
            // 
            this.gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridEX1.AutomaticSort = false;
            gridEXLayout1.LayoutString = "<GridEXLayoutData><RootTable><GroupCondition ID=\"\" /></RootTable></GridEXLayoutDa" +
                "ta>";
            this.gridEX1.DesignTimeLayout = gridEXLayout1;
            this.gridEX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.Location = new System.Drawing.Point(3, 90);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.SaveSettings = false;
            this.gridEX1.Size = new System.Drawing.Size(1111, 543);
            this.gridEX1.TabIndex = 8;
            // 
            // radCuocKhach
            // 
            this.radCuocKhach.Checked = true;
            this.radCuocKhach.Location = new System.Drawing.Point(408, 24);
            this.radCuocKhach.Name = "radCuocKhach";
            this.radCuocKhach.Size = new System.Drawing.Size(127, 23);
            this.radCuocKhach.TabIndex = 9;
            this.radCuocKhach.TabStop = true;
            this.radCuocKhach.Text = "Chọn theo số cuốc";
            this.radCuocKhach.CheckedChanged += new System.EventHandler(this.radCuocKhach_CheckedChanged);
            // 
            // radDiaChi
            // 
            this.radDiaChi.Location = new System.Drawing.Point(541, 23);
            this.radDiaChi.Name = "radDiaChi";
            this.radDiaChi.Size = new System.Drawing.Size(104, 23);
            this.radDiaChi.TabIndex = 10;
            this.radDiaChi.Text = "Chọn theo địa chỉ";
            // 
            // frmBCXeHanhTrinhCuocKhach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 634);
            this.Controls.Add(this.radDiaChi);
            this.Controls.Add(this.radCuocKhach);
            this.Controls.Add(this.gridEX1);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.calendarCombo1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBCXeHanhTrinhCuocKhach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xe hành trình cuốc khách";
            this.Load += new System.EventHandler(this.frmKiemSoatXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIButton btnSave;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo1;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Janus.Windows.EditControls.UIButton btnXuatExcel;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private Janus.Windows.EditControls.UIRadioButton radCuocKhach;
        private Janus.Windows.EditControls.UIRadioButton radDiaChi;

    }
}