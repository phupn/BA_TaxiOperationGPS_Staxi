namespace Taxi.GUI
{
    partial class frmTimKiem
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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout7 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimKiem));
            Janus.Windows.GridEX.GridEXLayout gridEXLayout8 = new Janus.Windows.GridEX.GridEXLayout();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.cbDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.grdGiaiQuyetPA = new Janus.Windows.GridEX.GridEX();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdGiaiQuyetPA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Số điện thoại";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(385, 2);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(325, 20);
            this.txtSoDienThoai.TabIndex = 0;
            this.txtSoDienThoai.TextChanged += new System.EventHandler(this.txtSoDienThoai_TextChanged);
            this.txtSoDienThoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoDienThoai_KeyDown);
            this.txtSoDienThoai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoDienThoai_KeyPress);
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(385, 26);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(325, 20);
            this.txtNoiDung.TabIndex = 1;
            this.txtNoiDung.TextChanged += new System.EventHandler(this.txtNoiDung_TextChanged);
            this.txtNoiDung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoiDung_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nội dung";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Từ ngày ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(524, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Đến ngày";
            // 
            // cbTuNgay
            // 
            this.cbTuNgay.CustomFormat = "HH:mm dd/MM/yyyy ";
            this.cbTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.cbTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2011, 7, 1, 0, 0, 0, 0);
            this.cbTuNgay.DropDownCalendar.Name = "";
            this.cbTuNgay.Location = new System.Drawing.Point(385, 51);
            this.cbTuNgay.Name = "cbTuNgay";
            this.cbTuNgay.Size = new System.Drawing.Size(125, 20);
            this.cbTuNgay.TabIndex = 2;
            this.cbTuNgay.ValueChanged += new System.EventHandler(this.cbTuNgay_ValueChanged);
            this.cbTuNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbTuNgay_KeyDown);
            // 
            // cbDenNgay
            // 
            this.cbDenNgay.CustomFormat = "HH:mm dd/MM/yyyy ";
            this.cbDenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.cbDenNgay.DropDownCalendar.FirstMonth = new System.DateTime(2011, 7, 1, 0, 0, 0, 0);
            this.cbDenNgay.DropDownCalendar.Name = "";
            this.cbDenNgay.Location = new System.Drawing.Point(578, 52);
            this.cbDenNgay.Name = "cbDenNgay";
            this.cbDenNgay.Size = new System.Drawing.Size(132, 20);
            this.cbDenNgay.TabIndex = 3;
            this.cbDenNgay.ValueChanged += new System.EventHandler(this.cbDenNgay_ValueChanged);
            this.cbDenNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbDenNgay_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(425, 87);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm &kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSearch_KeyDown);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(511, 87);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "&Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            this.btnThoat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnThoat_KeyDown);
            // 
            // grdGiaiQuyetPA
            // 
            this.grdGiaiQuyetPA.AllowColumnDrag = false;
            this.grdGiaiQuyetPA.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout7.LayoutString = resources.GetString("gridEXLayout7.LayoutString");
            this.grdGiaiQuyetPA.DesignTimeLayout = gridEXLayout7;
            this.grdGiaiQuyetPA.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
            this.grdGiaiQuyetPA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdGiaiQuyetPA.GroupByBoxVisible = false;
            this.grdGiaiQuyetPA.Location = new System.Drawing.Point(4, 124);
            this.grdGiaiQuyetPA.Name = "grdGiaiQuyetPA";
            this.grdGiaiQuyetPA.SaveSettings = false;
            this.grdGiaiQuyetPA.Size = new System.Drawing.Size(1086, 405);
            this.grdGiaiQuyetPA.TabIndex = 10;
            this.grdGiaiQuyetPA.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdGiaiQuyetPA_FormattingRow);
            this.grdGiaiQuyetPA.DoubleClick += new System.EventHandler(this.grdGiaiQuyetPA_DoubleClick);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(601, 87);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(75, 23);
            this.btnXuatExcel.TabIndex = 11;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.gridEX1;
            this.gridEXExporter1.IncludeFormatStyle = false;
            // 
            // gridEX1
            // 
            this.gridEX1.AllowColumnDrag = false;
            this.gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout8.LayoutString = resources.GetString("gridEXLayout8.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEXLayout8;
            this.gridEX1.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
            this.gridEX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.Location = new System.Drawing.Point(34, 115);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.SaveSettings = false;
            this.gridEX1.Size = new System.Drawing.Size(1086, 405);
            this.gridEX1.TabIndex = 12;
            this.gridEX1.Visible = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(717, 55);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(165, 13);
            this.lblMessage.TabIndex = 13;
            this.lblMessage.Text = "DoubleClick chọn dùng lại dữ liệu";
            // 
            // frmTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 529);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.grdGiaiQuyetPA);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbDenNgay);
            this.Controls.Add(this.cbTuNgay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSoDienThoai);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridEX1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmTimKiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tìm kiếm";
            this.Load += new System.EventHandler(this.frmTimKiem_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTimKiem_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.grdGiaiQuyetPA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.CalendarCombo.CalendarCombo cbTuNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo cbDenNgay;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnThoat;
        private Janus.Windows.GridEX.GridEX grdGiaiQuyetPA;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private System.Windows.Forms.Label lblMessage;
    }
}