namespace Taxi.GUI
{
    partial class frmChenCuocGoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChenCuocGoi));
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.chlCongTy = new System.Windows.Forms.CheckedListBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.cbLoaiPhanAnh = new Janus.Windows.EditControls.UIComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkNghiemTrong = new System.Windows.Forms.CheckBox();
            this.chkBinhThuong = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.btnThem = new Janus.Windows.EditControls.UIButton();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.uiTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTab1
            // 
            this.uiTab1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTab1.Location = new System.Drawing.Point(0, 1);
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.Size = new System.Drawing.Size(512, 312);
            this.uiTab1.TabIndex = 0;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage1});
            this.uiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2003;
            // 
            // uiTabPage1
            // 
            this.uiTabPage1.Controls.Add(this.chlCongTy);
            this.uiTabPage1.Controls.Add(this.txtDienThoai);
            this.uiTabPage1.Controls.Add(this.cbLoaiPhanAnh);
            this.uiTabPage1.Controls.Add(this.label6);
            this.uiTabPage1.Controls.Add(this.label5);
            this.uiTabPage1.Controls.Add(this.chkNghiemTrong);
            this.uiTabPage1.Controls.Add(this.chkBinhThuong);
            this.uiTabPage1.Controls.Add(this.label4);
            this.uiTabPage1.Controls.Add(this.txtNoiDung);
            this.uiTabPage1.Controls.Add(this.label3);
            this.uiTabPage1.Controls.Add(this.txtTenKH);
            this.uiTabPage1.Controls.Add(this.label2);
            this.uiTabPage1.Controls.Add(this.label1);
            this.uiTabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTabPage1.Location = new System.Drawing.Point(1, 21);
            this.uiTabPage1.Name = "uiTabPage1";
            this.uiTabPage1.Size = new System.Drawing.Size(510, 290);
            this.uiTabPage1.TabStop = true;
            this.uiTabPage1.Tag = "22";
            this.uiTabPage1.Text = "Thêm phản ánh";
            // 
            // chlCongTy
            // 
            this.chlCongTy.FormattingEnabled = true;
            this.chlCongTy.Location = new System.Drawing.Point(132, 215);
            this.chlCongTy.Name = "chlCongTy";
            this.chlCongTy.ScrollAlwaysVisible = true;
            this.chlCongTy.Size = new System.Drawing.Size(143, 64);
            this.chlCongTy.TabIndex = 23;
            this.chlCongTy.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chlCongTy_ItemCheck);
            this.chlCongTy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chlCongTy_KeyDown);
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(133, 25);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(148, 20);
            this.txtDienThoai.TabIndex = 0;
            this.txtDienThoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDienThoai_KeyDown);
            this.txtDienThoai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDienThoai_KeyPress);
            // 
            // cbLoaiPhanAnh
            // 
            this.cbLoaiPhanAnh.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cbLoaiPhanAnh.Location = new System.Drawing.Point(132, 157);
            this.cbLoaiPhanAnh.Name = "cbLoaiPhanAnh";
            this.cbLoaiPhanAnh.Size = new System.Drawing.Size(176, 20);
            this.cbLoaiPhanAnh.TabIndex = 3;
            this.cbLoaiPhanAnh.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003;
            this.cbLoaiPhanAnh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbLoaiPhanAnh_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(70, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "&Đơn vị(*) ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(65, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Mức độ(*) ";
            // 
            // chkNghiemTrong
            // 
            this.chkNghiemTrong.AutoSize = true;
            this.chkNghiemTrong.BackColor = System.Drawing.Color.Transparent;
            this.chkNghiemTrong.Location = new System.Drawing.Point(239, 192);
            this.chkNghiemTrong.Name = "chkNghiemTrong";
            this.chkNghiemTrong.Size = new System.Drawing.Size(89, 17);
            this.chkNghiemTrong.TabIndex = 5;
            this.chkNghiemTrong.Text = "Nghiê&m trọng";
            this.chkNghiemTrong.UseVisualStyleBackColor = false;
            this.chkNghiemTrong.CheckedChanged += new System.EventHandler(this.chkNghiemTrong_CheckedChanged);
            this.chkNghiemTrong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkNghiemTrong_KeyDown);
            // 
            // chkBinhThuong
            // 
            this.chkBinhThuong.AutoSize = true;
            this.chkBinhThuong.BackColor = System.Drawing.Color.Transparent;
            this.chkBinhThuong.Checked = true;
            this.chkBinhThuong.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBinhThuong.Location = new System.Drawing.Point(133, 192);
            this.chkBinhThuong.Name = "chkBinhThuong";
            this.chkBinhThuong.Size = new System.Drawing.Size(83, 17);
            this.chkBinhThuong.TabIndex = 4;
            this.chkBinhThuong.Text = "&Bình thường";
            this.chkBinhThuong.UseVisualStyleBackColor = false;
            this.chkBinhThuong.CheckedChanged += new System.EventHandler(this.chkBinhThuong_CheckedChanged);
            this.chkBinhThuong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkBinhThuong_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(31, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "&Loại phản ánh (*)";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(132, 78);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(308, 68);
            this.txtNoiDung.TabIndex = 2;
            this.txtNoiDung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoiDung_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(13, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "&Nội dung phản ánh(*) ";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(133, 51);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(175, 20);
            this.txtTenKH.TabIndex = 1;
            this.txtTenKH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenKH_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(25, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "&Tên khách hàng(*) ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(38, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "&Số điện thoại (*) ";
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.uiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel;
            this.uiGroupBox1.BorderColor = System.Drawing.Color.White;
            this.uiGroupBox1.Controls.Add(this.btnThem);
            this.uiGroupBox1.Controls.Add(this.btnCancel);
            this.uiGroupBox1.Controls.Add(this.label7);
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 311);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(512, 51);
            this.uiGroupBox1.TabIndex = 1;
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003;
            // 
            // btnThem
            // 
            this.btnThem.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Button;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = global::TaxiOperation_TongDai.Properties.Resources.disk;
            this.btnThem.Location = new System.Drawing.Point(94, 11);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(82, 36);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "&Cập nhật";
            this.btnThem.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnThem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnThem_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::TaxiOperation_TongDai.Properties.Resources.Close;
            this.btnCancel.Location = new System.Drawing.Point(192, 11);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 36);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Hủy bỏ";
            this.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCancel_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(281, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(225, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Dùng mũi tên trái phải để chuyển hướng";
            // 
            // frmChenCuocGoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 365);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.uiTab1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChenCuocGoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm phản ánh";
            this.Load += new System.EventHandler(this.frmChenCuocGoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.uiTabPage1.ResumeLayout(false);
            this.uiTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkNghiemTrong;
        private System.Windows.Forms.CheckBox chkBinhThuong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.EditControls.UIButton btnThem;
        private Janus.Windows.EditControls.UIButton btnCancel;
        private Janus.Windows.EditControls.UIComboBox cbLoaiPhanAnh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox chlCongTy;
    }
}