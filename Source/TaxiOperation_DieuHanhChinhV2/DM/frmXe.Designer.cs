namespace Taxi.GUI
{
    partial class frmXe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXe));
            this.uiGroupBox2 = new Janus.Windows.EditControls.UIGroupBox();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.btnSave = new Janus.Windows.EditControls.UIButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.tabThongTinXe = new Janus.Windows.UI.Tab.UITabPage();
            this.cboGara = new Janus.Windows.EditControls.UIComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.editSoMay = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label10 = new System.Windows.Forms.Label();
            this.editSoKhung = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label3 = new System.Windows.Forms.Label();
            this.editBienKiemSoat = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editSoHieuXe = new Janus.Windows.GridEX.EditControls.EditBox();
            this.tabThongTinLaiXe = new Janus.Windows.UI.Tab.UITabPage();
            this.btnRemove = new Janus.Windows.EditControls.UIButton();
            this.btnRemoveAll = new Janus.Windows.EditControls.UIButton();
            this.btnAdd = new Janus.Windows.EditControls.UIButton();
            this.btnAddAll = new Janus.Windows.EditControls.UIButton();
            this.listDanhSachLaiXe = new System.Windows.Forms.ListBox();
            this.listLaiXe = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbLoaiXe = new Janus.Windows.EditControls.UIComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.tabThongTinXe.SuspendLayout();
            this.tabThongTinLaiXe.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.uiGroupBox2.Controls.Add(this.btnCancel);
            this.uiGroupBox2.Controls.Add(this.btnSave);
            this.uiGroupBox2.Location = new System.Drawing.Point(2, 199);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Size = new System.Drawing.Size(406, 39);
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
            this.uiTab1.Location = new System.Drawing.Point(7, 12);
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.Size = new System.Drawing.Size(401, 187);
            this.uiTab1.TabIndex = 0;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.tabThongTinXe,
            this.tabThongTinLaiXe});
            this.uiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2003;
            this.uiTab1.ChangingSelectedTab += new Janus.Windows.UI.Tab.TabCancelEventHandler(this.uiTab1_ChangingSelectedTab);
            this.uiTab1.TabIndexChanged += new System.EventHandler(this.uiTab1_TabIndexChanged);
            // 
            // tabThongTinXe
            // 
            this.tabThongTinXe.Controls.Add(this.cbLoaiXe);
            this.tabThongTinXe.Controls.Add(this.label8);
            this.tabThongTinXe.Controls.Add(this.cboGara);
            this.tabThongTinXe.Controls.Add(this.label7);
            this.tabThongTinXe.Controls.Add(this.editSoMay);
            this.tabThongTinXe.Controls.Add(this.label10);
            this.tabThongTinXe.Controls.Add(this.editSoKhung);
            this.tabThongTinXe.Controls.Add(this.label3);
            this.tabThongTinXe.Controls.Add(this.editBienKiemSoat);
            this.tabThongTinXe.Controls.Add(this.label2);
            this.tabThongTinXe.Controls.Add(this.label1);
            this.tabThongTinXe.Controls.Add(this.editSoHieuXe);
            this.tabThongTinXe.Location = new System.Drawing.Point(1, 21);
            this.tabThongTinXe.Name = "tabThongTinXe";
            this.tabThongTinXe.Size = new System.Drawing.Size(399, 165);
            this.tabThongTinXe.TabStop = true;
            this.tabThongTinXe.Text = "Thông tin xe";
            // 
            // cboGara
            // 
            this.cboGara.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboGara.Location = new System.Drawing.Point(143, 104);
            this.cboGara.Name = "cboGara";
            this.cboGara.Size = new System.Drawing.Size(183, 20);
            this.cboGara.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(106, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Gara";
            // 
            // editSoMay
            // 
            this.editSoMay.Location = new System.Drawing.Point(143, 133);
            this.editSoMay.Margin = new System.Windows.Forms.Padding(2);
            this.editSoMay.MaxLength = 50;
            this.editSoMay.Name = "editSoMay";
            this.editSoMay.Size = new System.Drawing.Size(183, 20);
            this.editSoMay.TabIndex = 3;
            this.editSoMay.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(95, 136);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Số máy";
            this.label10.Visible = false;
            // 
            // editSoKhung
            // 
            this.editSoKhung.Location = new System.Drawing.Point(143, 156);
            this.editSoKhung.Margin = new System.Windows.Forms.Padding(2);
            this.editSoKhung.MaxLength = 255;
            this.editSoKhung.Name = "editSoKhung";
            this.editSoKhung.Size = new System.Drawing.Size(183, 20);
            this.editSoKhung.TabIndex = 4;
            this.editSoKhung.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(84, 157);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Số khung";
            this.label3.Visible = false;
            // 
            // editBienKiemSoat
            // 
            this.editBienKiemSoat.Location = new System.Drawing.Point(143, 53);
            this.editBienKiemSoat.Margin = new System.Windows.Forms.Padding(2);
            this.editBienKiemSoat.MaxLength = 50;
            this.editBienKiemSoat.Name = "editBienKiemSoat";
            this.editBienKiemSoat.Size = new System.Drawing.Size(183, 20);
            this.editBienKiemSoat.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(63, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Biển kiểm soát";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(67, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Số hiệu xe (*)";
            // 
            // editSoHieuXe
            // 
            this.editSoHieuXe.Location = new System.Drawing.Point(143, 29);
            this.editSoHieuXe.Margin = new System.Windows.Forms.Padding(2);
            this.editSoHieuXe.MaxLength = 4;
            this.editSoHieuXe.Name = "editSoHieuXe";
            this.editSoHieuXe.Size = new System.Drawing.Size(43, 20);
            this.editSoHieuXe.TabIndex = 1;
            this.editSoHieuXe.TextChanged += new System.EventHandler(this.editSoHieuXe_TextChanged);
            this.editSoHieuXe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editSoHieuXe_KeyPress);
            this.editSoHieuXe.Validating += new System.ComponentModel.CancelEventHandler(this.editSoHieuXe_Validating);
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
            this.tabThongTinLaiXe.Size = new System.Drawing.Size(401, 187);
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
            // cbLoaiXe
            // 
            this.cbLoaiXe.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cbLoaiXe.Location = new System.Drawing.Point(143, 78);
            this.cbLoaiXe.Name = "cbLoaiXe";
            this.cbLoaiXe.Size = new System.Drawing.Size(183, 20);
            this.cbLoaiXe.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(95, 81);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Loại xe";
            // 
            // frmXe
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 245);
            this.Controls.Add(this.uiTab1);
            this.Controls.Add(this.uiGroupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmXe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm/Sửa xe taxi";
            this.Load += new System.EventHandler(this.frmDoiTac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.tabThongTinXe.ResumeLayout(false);
            this.tabThongTinXe.PerformLayout();
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
        private Janus.Windows.UI.Tab.UITabPage tabThongTinXe;
        private Janus.Windows.GridEX.EditControls.EditBox editSoMay;
        private System.Windows.Forms.Label label10;
        private Janus.Windows.GridEX.EditControls.EditBox editSoKhung;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.GridEX.EditControls.EditBox editBienKiemSoat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.EditControls.EditBox editSoHieuXe;
        private Janus.Windows.UI.Tab.UITabPage tabThongTinLaiXe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listDanhSachLaiXe;
        private System.Windows.Forms.ListBox listLaiXe;
        private Janus.Windows.EditControls.UIButton btnRemove;
        private Janus.Windows.EditControls.UIButton btnRemoveAll;
        private Janus.Windows.EditControls.UIButton btnAdd;
        private Janus.Windows.EditControls.UIButton btnAddAll;
        private System.Windows.Forms.Label label7;
        private Janus.Windows.EditControls.UIComboBox cboGara;
        private Janus.Windows.EditControls.UIComboBox cbLoaiXe;
        private System.Windows.Forms.Label label8;
    }
}