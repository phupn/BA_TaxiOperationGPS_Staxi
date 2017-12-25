namespace Taxi.GUI
{
    partial class frmKhachQuen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhachQuen));
            this.uiGroupBox2 = new Janus.Windows.EditControls.UIGroupBox();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.btnSave = new Janus.Windows.EditControls.UIButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.tabDiaChi = new Janus.Windows.UI.Tab.UITabPage();
            this.picMap = new Taxi.Controls.Base.Controls.ShPicture();
            this.cb_Rank = new System.Windows.Forms.ComboBox();
            this.cb_Type = new System.Windows.Forms.ComboBox();
            this.chk_IsActive = new System.Windows.Forms.CheckBox();
            this.date_Birthday = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Notes = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Email = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Fax = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Address = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Name = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MaKH = new Janus.Windows.GridEX.EditControls.EditBox();
            this.txt_Phones = new Janus.Windows.GridEX.EditControls.EditBox();
            this.tabThongTinLaiXe = new Janus.Windows.UI.Tab.UITabPage();
            this.btnRemove = new Janus.Windows.EditControls.UIButton();
            this.btnRemoveAll = new Janus.Windows.EditControls.UIButton();
            this.btnAdd = new Janus.Windows.EditControls.UIButton();
            this.btnAddAll = new Janus.Windows.EditControls.UIButton();
            this.listDanhSachLaiXe = new System.Windows.Forms.ListBox();
            this.listLaiXe = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.tabDiaChi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap.Properties)).BeginInit();
            this.tabThongTinLaiXe.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.uiGroupBox2.Controls.Add(this.btnCancel);
            this.uiGroupBox2.Controls.Add(this.btnSave);
            this.uiGroupBox2.Location = new System.Drawing.Point(4, 352);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Size = new System.Drawing.Size(401, 39);
            this.uiGroupBox2.TabIndex = 1;
            this.uiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Close;
            this.btnCancel.Location = new System.Drawing.Point(209, 9);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 26);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Thoát";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(122, 9);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 26);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = " &Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // uiTab1
            // 
            this.uiTab1.Location = new System.Drawing.Point(4, 12);
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.Size = new System.Drawing.Size(401, 344);
            this.uiTab1.TabIndex = 0;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.tabDiaChi,
            this.tabThongTinLaiXe});
            this.uiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2003;
            // 
            // tabDiaChi
            // 
            this.tabDiaChi.Controls.Add(this.picMap);
            this.tabDiaChi.Controls.Add(this.cb_Rank);
            this.tabDiaChi.Controls.Add(this.cb_Type);
            this.tabDiaChi.Controls.Add(this.chk_IsActive);
            this.tabDiaChi.Controls.Add(this.date_Birthday);
            this.tabDiaChi.Controls.Add(this.label13);
            this.tabDiaChi.Controls.Add(this.label12);
            this.tabDiaChi.Controls.Add(this.label11);
            this.tabDiaChi.Controls.Add(this.txt_Notes);
            this.tabDiaChi.Controls.Add(this.label9);
            this.tabDiaChi.Controls.Add(this.label8);
            this.tabDiaChi.Controls.Add(this.txt_Email);
            this.tabDiaChi.Controls.Add(this.label7);
            this.tabDiaChi.Controls.Add(this.txt_Fax);
            this.tabDiaChi.Controls.Add(this.label4);
            this.tabDiaChi.Controls.Add(this.txt_Address);
            this.tabDiaChi.Controls.Add(this.label10);
            this.tabDiaChi.Controls.Add(this.txt_Name);
            this.tabDiaChi.Controls.Add(this.label2);
            this.tabDiaChi.Controls.Add(this.label3);
            this.tabDiaChi.Controls.Add(this.label1);
            this.tabDiaChi.Controls.Add(this.txt_MaKH);
            this.tabDiaChi.Controls.Add(this.txt_Phones);
            this.tabDiaChi.Location = new System.Drawing.Point(1, 21);
            this.tabDiaChi.Name = "tabDiaChi";
            this.tabDiaChi.Size = new System.Drawing.Size(399, 322);
            this.tabDiaChi.TabStop = true;
            this.tabDiaChi.Text = "Thông tin khách quen";
            // 
            // picMap
            // 
            this.picMap.EditValue = global::TaxiOperation_DieuHanhChinh.Properties.Resources.markerMG;
            this.picMap.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.B)));
            this.picMap.Location = new System.Drawing.Point(369, 2);
            this.picMap.Name = "picMap";
            this.picMap.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picMap.Properties.Appearance.Options.UseBackColor = true;
            this.picMap.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picMap.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picMap.Size = new System.Drawing.Size(24, 29);
            this.picMap.TabIndex = 98;
            this.picMap.ToolTip = "Tìm kiếm địa chỉ(Alt+B)";
            this.picMap.EditValueChanged += new System.EventHandler(this.picMap_EditValueChanged);
            this.picMap.Click += new System.EventHandler(this.picMap_Click);
            // 
            // cb_Rank
            // 
            this.cb_Rank.FormattingEnabled = true;
            this.cb_Rank.Location = new System.Drawing.Point(96, 266);
            this.cb_Rank.Name = "cb_Rank";
            this.cb_Rank.Size = new System.Drawing.Size(180, 21);
            this.cb_Rank.TabIndex = 10;
            // 
            // cb_Type
            // 
            this.cb_Type.FormattingEnabled = true;
            this.cb_Type.Location = new System.Drawing.Point(97, 241);
            this.cb_Type.Name = "cb_Type";
            this.cb_Type.Size = new System.Drawing.Size(180, 21);
            this.cb_Type.TabIndex = 9;
            // 
            // chk_IsActive
            // 
            this.chk_IsActive.AutoSize = true;
            this.chk_IsActive.Checked = true;
            this.chk_IsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_IsActive.Location = new System.Drawing.Point(97, 216);
            this.chk_IsActive.Name = "chk_IsActive";
            this.chk_IsActive.Size = new System.Drawing.Size(73, 17);
            this.chk_IsActive.TabIndex = 8;
            this.chk_IsActive.Text = "Kích hoạt";
            this.chk_IsActive.UseVisualStyleBackColor = true;
            // 
            // date_Birthday
            // 
            this.date_Birthday.CustomFormat = "dd/MM/yyyy";
            this.date_Birthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_Birthday.Location = new System.Drawing.Point(96, 162);
            this.date_Birthday.MaxDate = new System.DateTime(2200, 12, 31, 0, 0, 0, 0);
            this.date_Birthday.Name = "date_Birthday";
            this.date_Birthday.Size = new System.Drawing.Size(118, 20);
            this.date_Birthday.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(39, 269);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "Xếp hạng";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(65, 244);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Loại";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(34, 218);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Hoạt động";
            // 
            // txt_Notes
            // 
            this.txt_Notes.Location = new System.Drawing.Point(96, 188);
            this.txt_Notes.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Notes.MaxLength = 255;
            this.txt_Notes.Name = "txt_Notes";
            this.txt_Notes.Size = new System.Drawing.Size(298, 20);
            this.txt_Notes.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(48, 191);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Ghi chú";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(38, 166);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Ngày sinh";
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(96, 136);
            this.txt_Email.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Email.MaxLength = 255;
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(118, 20);
            this.txt_Email.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(60, 139);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Email";
            // 
            // txt_Fax
            // 
            this.txt_Fax.Location = new System.Drawing.Point(96, 110);
            this.txt_Fax.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Fax.MaxLength = 255;
            this.txt_Fax.Name = "txt_Fax";
            this.txt_Fax.Size = new System.Drawing.Size(118, 20);
            this.txt_Fax.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(68, 114);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Fax";
            // 
            // txt_Address
            // 
            this.txt_Address.Location = new System.Drawing.Point(96, 84);
            this.txt_Address.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Address.MaxLength = 255;
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(298, 20);
            this.txt_Address.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(49, 88);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Địa chỉ ";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(96, 58);
            this.txt_Name.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Name.MaxLength = 50;
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(298, 20);
            this.txt_Name.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(53, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Tên (*)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(39, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Mã KH (*)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Số điện thoại (*)";
            // 
            // txt_MaKH
            // 
            this.txt_MaKH.Location = new System.Drawing.Point(96, 6);
            this.txt_MaKH.Margin = new System.Windows.Forms.Padding(2);
            this.txt_MaKH.MaxLength = 11;
            this.txt_MaKH.Name = "txt_MaKH";
            this.txt_MaKH.Size = new System.Drawing.Size(118, 20);
            this.txt_MaKH.TabIndex = 0;
            this.txt_MaKH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editSoHieuXe_KeyPress);
            // 
            // txt_Phones
            // 
            this.txt_Phones.Location = new System.Drawing.Point(96, 32);
            this.txt_Phones.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Phones.MaxLength = 100;
            this.txt_Phones.Name = "txt_Phones";
            this.txt_Phones.Size = new System.Drawing.Size(298, 20);
            this.txt_Phones.TabIndex = 1;
            this.txt_Phones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editSoHieuXe_KeyPress);
            // 
            // tabThongTinLaiXe
            // 
            this.tabThongTinLaiXe.Controls.Add(this.btnRemove);
            this.tabThongTinLaiXe.Controls.Add(this.btnRemoveAll);
            this.tabThongTinLaiXe.Controls.Add(this.btnAdd);
            this.tabThongTinLaiXe.Controls.Add(this.btnAddAll);
            this.tabThongTinLaiXe.Controls.Add(this.listDanhSachLaiXe);
            this.tabThongTinLaiXe.Controls.Add(this.listLaiXe);
            this.tabThongTinLaiXe.Controls.Add(this.label6);
            this.tabThongTinLaiXe.Controls.Add(this.label5);
            this.tabThongTinLaiXe.Location = new System.Drawing.Point(1, 21);
            this.tabThongTinLaiXe.Name = "tabThongTinLaiXe";
            this.tabThongTinLaiXe.Size = new System.Drawing.Size(401, 344);
            this.tabThongTinLaiXe.TabStop = true;
            this.tabThongTinLaiXe.TabVisible = false;
            this.tabThongTinLaiXe.Text = "Thông tin lái xe";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(185, 106);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(22, 23);
            this.btnRemove.TabIndex = 13;
            this.btnRemove.Text = ">";
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(185, 135);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(22, 23);
            this.btnRemoveAll.TabIndex = 12;
            this.btnRemoveAll.Text = ">>";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(185, 45);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(22, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "<";
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(185, 68);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(22, 23);
            this.btnAddAll.TabIndex = 10;
            this.btnAddAll.Text = "<<";
            // 
            // listDanhSachLaiXe
            // 
            this.listDanhSachLaiXe.DisplayMember = "TenNhanVien";
            this.listDanhSachLaiXe.FormattingEnabled = true;
            this.listDanhSachLaiXe.Location = new System.Drawing.Point(222, 33);
            this.listDanhSachLaiXe.Name = "listDanhSachLaiXe";
            this.listDanhSachLaiXe.Size = new System.Drawing.Size(168, 173);
            this.listDanhSachLaiXe.TabIndex = 9;
            this.listDanhSachLaiXe.ValueMember = "MaNhanVien";
            // 
            // listLaiXe
            // 
            this.listLaiXe.DisplayMember = "TenNhanVien";
            this.listLaiXe.FormattingEnabled = true;
            this.listLaiXe.Location = new System.Drawing.Point(7, 33);
            this.listLaiXe.Name = "listLaiXe";
            this.listLaiXe.Size = new System.Drawing.Size(168, 173);
            this.listLaiXe.TabIndex = 8;
            this.listLaiXe.ValueMember = "MaNhanVien";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(219, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Danh sách lái xe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(4, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Lái xe ";
            // 
            // frmKhachQuen
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 392);
            this.Controls.Add(this.uiTab1);
            this.Controls.Add(this.uiGroupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmKhachQuen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm/Sửa khách hàng thân thiết";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKhachQuen_FormClosing);
            this.Load += new System.EventHandler(this.frmDoiTac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.tabDiaChi.ResumeLayout(false);
            this.tabDiaChi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap.Properties)).EndInit();
            this.tabThongTinLaiXe.ResumeLayout(false);
            this.tabThongTinLaiXe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIGroupBox uiGroupBox2;
        private Janus.Windows.EditControls.UIButton btnCancel;
        private Janus.Windows.EditControls.UIButton btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage tabDiaChi;
        private Janus.Windows.GridEX.EditControls.EditBox txt_Address;
        private System.Windows.Forms.Label label10;
        private Janus.Windows.GridEX.EditControls.EditBox txt_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.EditControls.EditBox txt_Phones;
        private Janus.Windows.UI.Tab.UITabPage tabThongTinLaiXe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listDanhSachLaiXe;
        private System.Windows.Forms.ListBox listLaiXe;
        private Janus.Windows.EditControls.UIButton btnRemove;
        private Janus.Windows.EditControls.UIButton btnRemoveAll;
        private Janus.Windows.EditControls.UIButton btnAdd;
        private Janus.Windows.EditControls.UIButton btnAddAll;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.GridEX.EditControls.EditBox txt_MaKH;
        private Janus.Windows.GridEX.EditControls.EditBox txt_Fax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private Janus.Windows.GridEX.EditControls.EditBox txt_Notes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Janus.Windows.GridEX.EditControls.EditBox txt_Email;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker date_Birthday;
        private System.Windows.Forms.CheckBox chk_IsActive;
        private System.Windows.Forms.ComboBox cb_Type;
        private System.Windows.Forms.ComboBox cb_Rank;
        private Controls.Base.Controls.ShPicture picMap;
    }
}