namespace Taxi.GUI
{
    partial class frmDienThoaiInputDataNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDienThoaiInputDataNew));
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.btnOK = new Janus.Windows.EditControls.UIButton();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDiaChiTraKhach = new Janus.Windows.GridEX.EditControls.EditBox();
            this.txtCuocGoiKoThanhCong = new Janus.Windows.GridEX.EditControls.EditBox();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.chkGoiKhieuNai = new Janus.Windows.EditControls.UICheckBox();
            this.lblGhiChuDienThoai = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.editLenhDienThoai = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editGhiChu = new Janus.Windows.GridEX.EditControls.EditBox();
            this.chkXe7 = new Janus.Windows.EditControls.UICheckBox();
            this.chkXe4 = new Janus.Windows.EditControls.UICheckBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.chkGoiKhac = new Janus.Windows.EditControls.UICheckBox();
            this.editSoLuongXe = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.chkGoiTaxi = new Janus.Windows.EditControls.UICheckBox();
            this.chkGoiLai = new Janus.Windows.EditControls.UICheckBox();
            this.editVung = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.txtDiaChiDonKhach = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblXe7Cho = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkHoiDam = new Janus.Windows.EditControls.UICheckBox();
            this.chkGoiDichVu = new Janus.Windows.EditControls.UICheckBox();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.chkXeKhongChon = new Janus.Windows.EditControls.UICheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.uiTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel;
            this.uiGroupBox1.Controls.Add(this.btnOK);
            this.uiGroupBox1.Controls.Add(this.btnCancel);
            this.uiGroupBox1.FrameStyle = Janus.Windows.EditControls.FrameStyle.None;
            this.uiGroupBox1.Location = new System.Drawing.Point(1, 208);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(484, 37);
            this.uiGroupBox1.TabIndex = 1;
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003;
            // 
            // btnOK
            // 
            this.btnOK.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Button;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Image = global::TaxiApplication.Properties.Resources.disk;
            this.btnOK.Location = new System.Drawing.Point(149, 6);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(79, 26);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&Cập nhật";
            this.btnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::TaxiApplication.Properties.Resources.Close;
            this.btnCancel.Location = new System.Drawing.Point(232, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 26);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Hủy bỏ";
            this.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // txtDiaChiTraKhach
            // 
            this.txtDiaChiTraKhach.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDiaChiTraKhach.Enabled = false;
            this.txtDiaChiTraKhach.Location = new System.Drawing.Point(151, 121);
            this.txtDiaChiTraKhach.Name = "txtDiaChiTraKhach";
            this.txtDiaChiTraKhach.ReadOnly = true;
            this.txtDiaChiTraKhach.Size = new System.Drawing.Size(642, 20);
            this.txtDiaChiTraKhach.TabIndex = 0;
            this.txtDiaChiTraKhach.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // txtCuocGoiKoThanhCong
            // 
            this.txtCuocGoiKoThanhCong.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCuocGoiKoThanhCong.Enabled = false;
            this.txtCuocGoiKoThanhCong.Location = new System.Drawing.Point(199, 152);
            this.txtCuocGoiKoThanhCong.MaxLength = 1;
            this.txtCuocGoiKoThanhCong.Name = "txtCuocGoiKoThanhCong";
            this.txtCuocGoiKoThanhCong.ReadOnly = true;
            this.txtCuocGoiKoThanhCong.Size = new System.Drawing.Size(50, 20);
            this.txtCuocGoiKoThanhCong.TabIndex = 1;
            this.txtCuocGoiKoThanhCong.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // uiTabPage1
            // 
            this.uiTabPage1.Controls.Add(this.chkXeKhongChon);
            this.uiTabPage1.Controls.Add(this.label7);
            this.uiTabPage1.Controls.Add(this.chkGoiKhieuNai);
            this.uiTabPage1.Controls.Add(this.lblGhiChuDienThoai);
            this.uiTabPage1.Controls.Add(this.label6);
            this.uiTabPage1.Controls.Add(this.editLenhDienThoai);
            this.uiTabPage1.Controls.Add(this.label9);
            this.uiTabPage1.Controls.Add(this.label1);
            this.uiTabPage1.Controls.Add(this.editGhiChu);
            this.uiTabPage1.Controls.Add(this.chkXe7);
            this.uiTabPage1.Controls.Add(this.chkXe4);
            this.uiTabPage1.Controls.Add(this.lblInfo);
            this.uiTabPage1.Controls.Add(this.chkGoiKhac);
            this.uiTabPage1.Controls.Add(this.editSoLuongXe);
            this.uiTabPage1.Controls.Add(this.chkGoiTaxi);
            this.uiTabPage1.Controls.Add(this.chkGoiLai);
            this.uiTabPage1.Controls.Add(this.editVung);
            this.uiTabPage1.Controls.Add(this.txtDiaChiDonKhach);
            this.uiTabPage1.Controls.Add(this.label4);
            this.uiTabPage1.Controls.Add(this.lblXe7Cho);
            this.uiTabPage1.Controls.Add(this.label3);
            this.uiTabPage1.Controls.Add(this.label2);
            this.uiTabPage1.Controls.Add(this.label5);
            this.uiTabPage1.Controls.Add(this.chkHoiDam);
            this.uiTabPage1.Controls.Add(this.chkGoiDichVu);
            this.uiTabPage1.Location = new System.Drawing.Point(1, 21);
            this.uiTabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.uiTabPage1.Name = "uiTabPage1";
            this.uiTabPage1.Size = new System.Drawing.Size(484, 180);
            this.uiTabPage1.TabStop = true;
            this.uiTabPage1.Text = "Thông tin điều hành";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Goldenrod;
            this.label7.Location = new System.Drawing.Point(238, 160);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(248, 13);
            this.label7.TabIndex = 53;
            this.label7.Text = "(chọn chuyển k/hàng và vùng 11 để chuyển pKH)";
            // 
            // chkGoiKhieuNai
            // 
            this.chkGoiKhieuNai.BackColor = System.Drawing.Color.Transparent;
            this.chkGoiKhieuNai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGoiKhieuNai.Location = new System.Drawing.Point(203, 62);
            this.chkGoiKhieuNai.Margin = new System.Windows.Forms.Padding(2);
            this.chkGoiKhieuNai.Name = "chkGoiKhieuNai";
            this.chkGoiKhieuNai.Size = new System.Drawing.Size(93, 19);
            this.chkGoiKhieuNai.TabIndex = 3;
            this.chkGoiKhieuNai.Text = "Chuyển k/h&àng";
            this.chkGoiKhieuNai.ToolTipText = "Gọi khiếu &nại";
            this.chkGoiKhieuNai.CheckedChanged += new System.EventHandler(this.chkGoiKhieuNai_CheckedChanged);
            // 
            // lblGhiChuDienThoai
            // 
            this.lblGhiChuDienThoai.AutoSize = true;
            this.lblGhiChuDienThoai.Location = new System.Drawing.Point(124, 148);
            this.lblGhiChuDienThoai.Name = "lblGhiChuDienThoai";
            this.lblGhiChuDienThoai.Size = new System.Drawing.Size(0, 13);
            this.lblGhiChuDienThoai.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(47, 87);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 51;
            this.label6.Tag = " ";
            this.label6.Text = "Loại xe";
            // 
            // editLenhDienThoai
            // 
            this.editLenhDienThoai.Font = new System.Drawing.Font("Tahoma", 12F);
            this.editLenhDienThoai.Location = new System.Drawing.Point(102, 114);
            this.editLenhDienThoai.Name = "editLenhDienThoai";
            this.editLenhDienThoai.Size = new System.Drawing.Size(134, 27);
            this.editLenhDienThoai.TabIndex = 14;
            this.editLenhDienThoai.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.editLenhDienThoai.TextChanged += new System.EventHandler(this.editLenhDienThoai_TextChanged);
            this.editLenhDienThoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editLenhDienThoai_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(46, 154);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Gh&i chú";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 120);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Lệnh điện &thoại";
            // 
            // editGhiChu
            // 
            this.editGhiChu.Font = new System.Drawing.Font("Tahoma", 12F);
            this.editGhiChu.Location = new System.Drawing.Point(102, 148);
            this.editGhiChu.Margin = new System.Windows.Forms.Padding(2);
            this.editGhiChu.MaxLength = 255;
            this.editGhiChu.Name = "editGhiChu";
            this.editGhiChu.Size = new System.Drawing.Size(134, 27);
            this.editGhiChu.TabIndex = 15;
            this.editGhiChu.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.editGhiChu.TextChanged += new System.EventHandler(this.editGhiChu_TextChanged);
            // 
            // chkXe7
            // 
            this.chkXe7.BackColor = System.Drawing.Color.Transparent;
            this.chkXe7.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkXe7.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F);
            this.chkXe7.Location = new System.Drawing.Point(146, 86);
            this.chkXe7.Name = "chkXe7";
            this.chkXe7.Size = new System.Drawing.Size(46, 23);
            this.chkXe7.TabIndex = 8;
            this.chkXe7.Text = "Xe &7 ";
            this.chkXe7.CheckedChanged += new System.EventHandler(this.chkXe7_CheckedChanged);
            // 
            // chkXe4
            // 
            this.chkXe4.BackColor = System.Drawing.Color.Transparent;
            this.chkXe4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkXe4.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F);
            this.chkXe4.Location = new System.Drawing.Point(96, 85);
            this.chkXe4.Name = "chkXe4";
            this.chkXe4.Size = new System.Drawing.Size(47, 25);
            this.chkXe4.TabIndex = 7;
            this.chkXe4.Text = "Xe &4";
            this.chkXe4.CheckedChanged += new System.EventHandler(this.chkXe4_CheckedChanged);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(98, 10);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(106, 13);
            this.lblInfo.TabIndex = 46;
            this.lblInfo.Text = "Line   Phone  Gio";
            // 
            // chkGoiKhac
            // 
            this.chkGoiKhac.BackColor = System.Drawing.Color.Transparent;
            this.chkGoiKhac.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGoiKhac.Location = new System.Drawing.Point(414, 61);
            this.chkGoiKhac.Margin = new System.Windows.Forms.Padding(2);
            this.chkGoiKhac.Name = "chkGoiKhac";
            this.chkGoiKhac.Size = new System.Drawing.Size(62, 19);
            this.chkGoiKhac.TabIndex = 6;
            this.chkGoiKhac.Text = "Gọi &khác";
            this.chkGoiKhac.CheckedChanged += new System.EventHandler(this.chkGoiKhac_CheckedChanged);
            // 
            // editSoLuongXe
            // 
            this.editSoLuongXe.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editSoLuongXe.IncludeLiterals = false;
            this.editSoLuongXe.Location = new System.Drawing.Point(368, 86);
            this.editSoLuongXe.Margin = new System.Windows.Forms.Padding(2);
            this.editSoLuongXe.Mask = "0";
            this.editSoLuongXe.Name = "editSoLuongXe";
            this.editSoLuongXe.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.editSoLuongXe.Size = new System.Drawing.Size(30, 20);
            this.editSoLuongXe.TabIndex = 10;
            this.editSoLuongXe.TextChanged += new System.EventHandler(this.editSoLuongXe_TextChanged);
            this.editSoLuongXe.Click += new System.EventHandler(this.editSoLuongXe_Click);
            this.editSoLuongXe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editSoLuongXe_KeyDown);
            // 
            // chkGoiTaxi
            // 
            this.chkGoiTaxi.BackColor = System.Drawing.Color.Transparent;
            this.chkGoiTaxi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGoiTaxi.Location = new System.Drawing.Point(101, 62);
            this.chkGoiTaxi.Margin = new System.Windows.Forms.Padding(2);
            this.chkGoiTaxi.Name = "chkGoiTaxi";
            this.chkGoiTaxi.Size = new System.Drawing.Size(54, 19);
            this.chkGoiTaxi.TabIndex = 1;
            this.chkGoiTaxi.Text = "&Gọi taxi";
            this.chkGoiTaxi.CheckedChanged += new System.EventHandler(this.chkGoiTaxi_CheckedChanged);
            // 
            // chkGoiLai
            // 
            this.chkGoiLai.BackColor = System.Drawing.Color.Transparent;
            this.chkGoiLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGoiLai.Location = new System.Drawing.Point(155, 62);
            this.chkGoiLai.Margin = new System.Windows.Forms.Padding(2);
            this.chkGoiLai.Name = "chkGoiLai";
            this.chkGoiLai.Size = new System.Drawing.Size(50, 19);
            this.chkGoiLai.TabIndex = 2;
            this.chkGoiLai.Text = "Gọi &lại";
            this.chkGoiLai.CheckedChanged += new System.EventHandler(this.chkGoiLai_CheckedChanged);
            // 
            // editVung
            // 
            this.editVung.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editVung.Location = new System.Drawing.Point(439, 86);
            this.editVung.Margin = new System.Windows.Forms.Padding(2);
            this.editVung.Mask = "00";
            this.editVung.MaxLength = 3;
            this.editVung.Name = "editVung";
            this.editVung.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.editVung.Size = new System.Drawing.Size(30, 20);
            this.editVung.TabIndex = 11;
            this.editVung.Text = "  ";
            this.editVung.TextChanged += new System.EventHandler(this.editVung_TextChanged);
            this.editVung.Click += new System.EventHandler(this.editVung_Click);
            this.editVung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editVung_KeyDown);
            // 
            // txtDiaChiDonKhach
            // 
            this.txtDiaChiDonKhach.DisabledBackColor = System.Drawing.Color.White;
            this.txtDiaChiDonKhach.DisabledForeColor = System.Drawing.Color.Black;
            this.txtDiaChiDonKhach.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtDiaChiDonKhach.Location = new System.Drawing.Point(102, 33);
            this.txtDiaChiDonKhach.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiaChiDonKhach.Name = "txtDiaChiDonKhach";
            this.txtDiaChiDonKhach.Size = new System.Drawing.Size(372, 27);
            this.txtDiaChiDonKhach.TabIndex = 0;
            this.txtDiaChiDonKhach.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.txtDiaChiDonKhach.TextChanged += new System.EventHandler(this.txtDiaChiDonKhach_TextChanged);
            this.txtDiaChiDonKhach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiaChiDonKhach_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Địa chỉ đó&n khách";
            // 
            // lblXe7Cho
            // 
            this.lblXe7Cho.AutoSize = true;
            this.lblXe7Cho.BackColor = System.Drawing.Color.Transparent;
            this.lblXe7Cho.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXe7Cho.ForeColor = System.Drawing.Color.Black;
            this.lblXe7Cho.Location = new System.Drawing.Point(404, 90);
            this.lblXe7Cho.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblXe7Cho.Name = "lblXe7Cho";
            this.lblXe7Cho.Size = new System.Drawing.Size(32, 13);
            this.lblXe7Cho.TabIndex = 13;
            this.lblXe7Cho.Text = "&Vùng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(306, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 12;
            this.label3.Tag = " ";
            this.label3.Text = "&Số lượng xe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Điện thoại";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(234, 120);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(249, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "(3 : Khách hẹn - Phải có lệnh hẹn để không bị xóa)";
            // 
            // chkHoiDam
            // 
            this.chkHoiDam.BackColor = System.Drawing.Color.Transparent;
            this.chkHoiDam.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHoiDam.Location = new System.Drawing.Point(355, 62);
            this.chkHoiDam.Margin = new System.Windows.Forms.Padding(2);
            this.chkHoiDam.Name = "chkHoiDam";
            this.chkHoiDam.Size = new System.Drawing.Size(60, 19);
            this.chkHoiDam.TabIndex = 5;
            this.chkHoiDam.Text = "Hỏi đà&m";
            this.chkHoiDam.CheckedChanged += new System.EventHandler(this.chkLaiXeBao_CheckedChanged);
            // 
            // chkGoiDichVu
            // 
            this.chkGoiDichVu.BackColor = System.Drawing.Color.Transparent;
            this.chkGoiDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGoiDichVu.Location = new System.Drawing.Point(297, 62);
            this.chkGoiDichVu.Margin = new System.Windows.Forms.Padding(2);
            this.chkGoiDichVu.Name = "chkGoiDichVu";
            this.chkGoiDichVu.Size = new System.Drawing.Size(60, 19);
            this.chkGoiDichVu.TabIndex = 4;
            this.chkGoiDichVu.Text = "&Dịch vụ";
            this.chkGoiDichVu.CheckedChanged += new System.EventHandler(this.chkGoiDichVu_CheckedChanged);
            // 
            // uiTab1
            // 
            this.uiTab1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTab1.Location = new System.Drawing.Point(0, 2);
            this.uiTab1.Margin = new System.Windows.Forms.Padding(2);
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.Size = new System.Drawing.Size(486, 202);
            this.uiTab1.TabIndex = 0;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage1});
            this.uiTab1.TabStop = false;
            this.uiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2003;
            // 
            // chkXeKhongChon
            // 
            this.chkXeKhongChon.BackColor = System.Drawing.Color.Transparent;
            this.chkXeKhongChon.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkXeKhongChon.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F);
            this.chkXeKhongChon.Location = new System.Drawing.Point(200, 85);
            this.chkXeKhongChon.Name = "chkXeKhongChon";
            this.chkXeKhongChon.Size = new System.Drawing.Size(96, 23);
            this.chkXeKhongChon.TabIndex = 9;
            this.chkXeKhongChon.Text = "LX không (&0)";
            this.chkXeKhongChon.ToolTipText = "Khách hàng không chọn loại xe nào";
            this.chkXeKhongChon.CheckedChanged += new System.EventHandler(this.chkXeKhongChon_CheckedChanged);
            // 
            // frmDienThoaiInputDataNew
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 246);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.uiTab1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDienThoaiInputDataNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điều hành điện thoại";
            this.Load += new System.EventHandler(this.frmBoDamInputData_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDienThoaiInputDataCP_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.uiTabPage1.ResumeLayout(false);
            this.uiTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.EditControls.UIButton btnOK;
        private Janus.Windows.EditControls.UIButton btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Janus.Windows.GridEX.EditControls.EditBox txtDiaChiTraKhach;
        private Janus.Windows.GridEX.EditControls.EditBox txtCuocGoiKoThanhCong;
        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
        private Janus.Windows.GridEX.EditControls.EditBox editLenhDienThoai;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UICheckBox chkXe7;
        private Janus.Windows.EditControls.UICheckBox chkXe4;
        private System.Windows.Forms.Label lblInfo;
        private Janus.Windows.EditControls.UICheckBox chkGoiKhac;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox editSoLuongXe;
        private Janus.Windows.EditControls.UICheckBox chkGoiTaxi;
        private Janus.Windows.EditControls.UICheckBox chkGoiLai;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox editVung;
        private Janus.Windows.GridEX.EditControls.EditBox txtDiaChiDonKhach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblXe7Cho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblGhiChuDienThoai;
        private Janus.Windows.EditControls.UICheckBox chkGoiKhieuNai;
        private System.Windows.Forms.Label label9;
        private Janus.Windows.GridEX.EditControls.EditBox editGhiChu;
        private Janus.Windows.EditControls.UICheckBox chkHoiDam;
        private Janus.Windows.EditControls.UICheckBox chkGoiDichVu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private Janus.Windows.EditControls.UICheckBox chkXeKhongChon;


    }
}