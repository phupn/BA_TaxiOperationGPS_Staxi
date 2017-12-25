namespace Taxi.GUI
{
    partial class frmDienThoaiHenKhach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDienThoaiHenKhach));
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.btnOK = new Janus.Windows.EditControls.UIButton();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDiaChiTraKhach = new Janus.Windows.GridEX.EditControls.EditBox();
            this.txtCuocGoiKoThanhCong = new Janus.Windows.GridEX.EditControls.EditBox();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.editGhiChu = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.intPhut = new Janus.Windows.GridEX.EditControls.IntegerUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.timeHen = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.chkXe7 = new Janus.Windows.EditControls.UICheckBox();
            this.dateNgayHen = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.chkXe4 = new Janus.Windows.EditControls.UICheckBox();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.editSoLuongXe = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.editVung = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.txtDiaChiDonKhach = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblXe7Cho = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
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
            this.uiGroupBox1.Location = new System.Drawing.Point(2, 244);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(373, 37);
            this.uiGroupBox1.TabIndex = 1;
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003;
            // 
            // btnOK
            // 
            this.btnOK.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Button;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(103, 2);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(79, 26);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "&Cập nhật";
            this.btnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(186, 2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 26);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "&Hủy bỏ";
            this.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003;
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
            this.uiTabPage1.Controls.Add(this.editGhiChu);
            this.uiTabPage1.Controls.Add(this.label5);
            this.uiTabPage1.Controls.Add(this.label1);
            this.uiTabPage1.Controls.Add(this.intPhut);
            this.uiTabPage1.Controls.Add(this.label6);
            this.uiTabPage1.Controls.Add(this.timeHen);
            this.uiTabPage1.Controls.Add(this.chkXe7);
            this.uiTabPage1.Controls.Add(this.dateNgayHen);
            this.uiTabPage1.Controls.Add(this.chkXe4);
            this.uiTabPage1.Controls.Add(this.lblStartTime);
            this.uiTabPage1.Controls.Add(this.lblInfo);
            this.uiTabPage1.Controls.Add(this.lblEndTime);
            this.uiTabPage1.Controls.Add(this.editSoLuongXe);
            this.uiTabPage1.Controls.Add(this.editVung);
            this.uiTabPage1.Controls.Add(this.txtDiaChiDonKhach);
            this.uiTabPage1.Controls.Add(this.label4);
            this.uiTabPage1.Controls.Add(this.lblXe7Cho);
            this.uiTabPage1.Controls.Add(this.label3);
            this.uiTabPage1.Controls.Add(this.label2);
            this.uiTabPage1.Location = new System.Drawing.Point(1, 21);
            this.uiTabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.uiTabPage1.Name = "uiTabPage1";
            this.uiTabPage1.Size = new System.Drawing.Size(372, 218);
            this.uiTabPage1.TabStop = true;
            this.uiTabPage1.Text = "Thông tin hẹn khách";
            // 
            // editGhiChu
            // 
            this.editGhiChu.DisabledBackColor = System.Drawing.Color.White;
            this.editGhiChu.DisabledForeColor = System.Drawing.Color.Black;
            this.editGhiChu.Font = new System.Drawing.Font("Tahoma", 8F);
            this.editGhiChu.Location = new System.Drawing.Point(111, 184);
            this.editGhiChu.Margin = new System.Windows.Forms.Padding(2);
            this.editGhiChu.Name = "editGhiChu";
            this.editGhiChu.Size = new System.Drawing.Size(238, 20);
            this.editGhiChu.TabIndex = 55;
            this.editGhiChu.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 187);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Ghi chú";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(147, 159);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "(phút)";
            // 
            // intPhut
            // 
            this.intPhut.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intPhut.Location = new System.Drawing.Point(111, 158);
            this.intPhut.Margin = new System.Windows.Forms.Padding(2);
            this.intPhut.Maximum = 120;
            this.intPhut.Minimum = 10;
            this.intPhut.Name = "intPhut";
            this.intPhut.Size = new System.Drawing.Size(35, 19);
            this.intPhut.TabIndex = 52;
            this.intPhut.Value = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(58, 67);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 51;
            this.label6.Tag = " ";
            this.label6.Text = "Loại xe";
            // 
            // timeHen
            // 
            this.timeHen.CustomFormat = "HH:mm";
            this.timeHen.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.timeHen.DropDownCalendar.FirstMonth = new System.DateTime(2006, 3, 1, 0, 0, 0, 0);
            this.timeHen.DropDownCalendar.Name = "";
            this.timeHen.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            this.timeHen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeHen.Location = new System.Drawing.Point(111, 136);
            this.timeHen.Margin = new System.Windows.Forms.Padding(2);
            this.timeHen.Name = "timeHen";
            this.timeHen.ShowDropDown = false;
            this.timeHen.ShowUpDown = true;
            this.timeHen.Size = new System.Drawing.Size(54, 19);
            this.timeHen.TabIndex = 3;
            this.timeHen.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            // 
            // chkXe7
            // 
            this.chkXe7.BackColor = System.Drawing.Color.Transparent;
            this.chkXe7.Enabled = false;
            this.chkXe7.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F);
            this.chkXe7.Location = new System.Drawing.Point(171, 67);
            this.chkXe7.Name = "chkXe7";
            this.chkXe7.Size = new System.Drawing.Size(54, 20);
            this.chkXe7.TabIndex = 7;
            this.chkXe7.Text = "Xe 7 ";
            // 
            // dateNgayHen
            // 
            // 
            // 
            // 
            this.dateNgayHen.DropDownCalendar.FirstMonth = new System.DateTime(2006, 3, 1, 0, 0, 0, 0);
            this.dateNgayHen.DropDownCalendar.Name = "";
            this.dateNgayHen.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            this.dateNgayHen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateNgayHen.Location = new System.Drawing.Point(171, 136);
            this.dateNgayHen.Margin = new System.Windows.Forms.Padding(2);
            this.dateNgayHen.Name = "dateNgayHen";
            this.dateNgayHen.Size = new System.Drawing.Size(82, 19);
            this.dateNgayHen.TabIndex = 2;
            this.dateNgayHen.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            // 
            // chkXe4
            // 
            this.chkXe4.BackColor = System.Drawing.Color.Transparent;
            this.chkXe4.Enabled = false;
            this.chkXe4.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F);
            this.chkXe4.Location = new System.Drawing.Point(111, 67);
            this.chkXe4.Name = "chkXe4";
            this.chkXe4.Size = new System.Drawing.Size(54, 20);
            this.chkXe4.TabIndex = 6;
            this.chkXe4.Text = "Xe 4";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.BackColor = System.Drawing.Color.Transparent;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(13, 138);
            this.lblStartTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(91, 13);
            this.lblStartTime.TabIndex = 44;
            this.lblStartTime.Text = "Thời gian bắt đầu";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(109, 23);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(106, 13);
            this.lblInfo.TabIndex = 46;
            this.lblInfo.Text = "Line   Phone  Gio";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.BackColor = System.Drawing.Color.Transparent;
            this.lblEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(47, 162);
            this.lblEndTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(56, 13);
            this.lblEndTime.TabIndex = 45;
            this.lblEndTime.Text = "Báo trước ";
            // 
            // editSoLuongXe
            // 
            this.editSoLuongXe.Enabled = false;
            this.editSoLuongXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.editSoLuongXe.IncludeLiterals = false;
            this.editSoLuongXe.Location = new System.Drawing.Point(111, 90);
            this.editSoLuongXe.Margin = new System.Windows.Forms.Padding(2);
            this.editSoLuongXe.Mask = "0";
            this.editSoLuongXe.Name = "editSoLuongXe";
            this.editSoLuongXe.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.editSoLuongXe.Size = new System.Drawing.Size(30, 19);
            this.editSoLuongXe.TabIndex = 9;
            // 
            // editVung
            // 
            this.editVung.Enabled = false;
            this.editVung.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editVung.Location = new System.Drawing.Point(111, 114);
            this.editVung.Margin = new System.Windows.Forms.Padding(2);
            this.editVung.Mask = "0";
            this.editVung.Name = "editVung";
            this.editVung.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.editVung.Size = new System.Drawing.Size(30, 19);
            this.editVung.TabIndex = 11;
            this.editVung.Text = " ";
            // 
            // txtDiaChiDonKhach
            // 
            this.txtDiaChiDonKhach.DisabledBackColor = System.Drawing.Color.White;
            this.txtDiaChiDonKhach.DisabledForeColor = System.Drawing.Color.Black;
            this.txtDiaChiDonKhach.Enabled = false;
            this.txtDiaChiDonKhach.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDiaChiDonKhach.Location = new System.Drawing.Point(111, 46);
            this.txtDiaChiDonKhach.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiaChiDonKhach.Name = "txtDiaChiDonKhach";
            this.txtDiaChiDonKhach.Size = new System.Drawing.Size(238, 20);
            this.txtDiaChiDonKhach.TabIndex = 5;
            this.txtDiaChiDonKhach.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Địa chỉ đón khách";
            // 
            // lblXe7Cho
            // 
            this.lblXe7Cho.AutoSize = true;
            this.lblXe7Cho.BackColor = System.Drawing.Color.Transparent;
            this.lblXe7Cho.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXe7Cho.ForeColor = System.Drawing.Color.Black;
            this.lblXe7Cho.Location = new System.Drawing.Point(71, 115);
            this.lblXe7Cho.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblXe7Cho.Name = "lblXe7Cho";
            this.lblXe7Cho.Size = new System.Drawing.Size(32, 13);
            this.lblXe7Cho.TabIndex = 41;
            this.lblXe7Cho.Text = "Vùng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(41, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 39;
            this.label3.Tag = " ";
            this.label3.Text = "Số lượng xe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Điện thoại";
            // 
            // uiTab1
            // 
            this.uiTab1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTab1.Location = new System.Drawing.Point(0, 0);
            this.uiTab1.Margin = new System.Windows.Forms.Padding(2);
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.Size = new System.Drawing.Size(374, 240);
            this.uiTab1.TabIndex = 0;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage1});
            this.uiTab1.TabStop = false;
            this.uiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2003;
            // 
            // frmDienThoaiHenKhach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 278);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.uiTab1);
            this.Icon = TaxiApplication.Properties.Resources.Telephone_01;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmDienThoaiHenKhach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điều hành điện thoại";
            this.Load += new System.EventHandler(this.frmBoDamInputData_Load);
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
        private Janus.Windows.EditControls.UICheckBox chkXe7;
        private Janus.Windows.EditControls.UICheckBox chkXe4;
        private System.Windows.Forms.Label lblInfo;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox editSoLuongXe;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox editVung;
        private Janus.Windows.GridEX.EditControls.EditBox txtDiaChiDonKhach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblXe7Cho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        internal Janus.Windows.CalendarCombo.CalendarCombo timeHen;
        internal Janus.Windows.CalendarCombo.CalendarCombo dateNgayHen;
        internal System.Windows.Forms.Label lblStartTime;
        internal System.Windows.Forms.Label lblEndTime;
        internal System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.EditControls.IntegerUpDown intPhut;
        private Janus.Windows.GridEX.EditControls.EditBox editGhiChu;
        internal System.Windows.Forms.Label label5;


    }
}