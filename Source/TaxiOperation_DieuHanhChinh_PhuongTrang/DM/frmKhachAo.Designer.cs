namespace Taxi.GUI
{
    partial class frmKhachAo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhachAo));
            this.uiGroupBox2 = new Janus.Windows.EditControls.UIGroupBox();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.btnSave = new Janus.Windows.EditControls.UIButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.tabDiaChi = new Janus.Windows.UI.Tab.UITabPage();
            this.editDiaChi = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label10 = new System.Windows.Forms.Label();
            this.editTen = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editSoDienThoai = new Janus.Windows.GridEX.EditControls.EditBox();
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
            this.tabThongTinLaiXe.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.uiGroupBox2.Controls.Add(this.btnCancel);
            this.uiGroupBox2.Controls.Add(this.btnSave);
            this.uiGroupBox2.Location = new System.Drawing.Point(4, 190);
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
            this.uiTab1.Size = new System.Drawing.Size(401, 182);
            this.uiTab1.TabIndex = 0;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.tabDiaChi,
            this.tabThongTinLaiXe});
            this.uiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2003;
            // 
            // tabDiaChi
            // 
            this.tabDiaChi.Controls.Add(this.editDiaChi);
            this.tabDiaChi.Controls.Add(this.label10);
            this.tabDiaChi.Controls.Add(this.editTen);
            this.tabDiaChi.Controls.Add(this.label2);
            this.tabDiaChi.Controls.Add(this.label1);
            this.tabDiaChi.Controls.Add(this.editSoDienThoai);
            this.tabDiaChi.Location = new System.Drawing.Point(1, 21);
            this.tabDiaChi.Name = "tabDiaChi";
            this.tabDiaChi.Size = new System.Drawing.Size(399, 160);
            this.tabDiaChi.TabStop = true;
            this.tabDiaChi.Text = "Thông tin khách ảo";
            // 
            // editDiaChi
            // 
            this.editDiaChi.Location = new System.Drawing.Point(103, 79);
            this.editDiaChi.Margin = new System.Windows.Forms.Padding(2);
            this.editDiaChi.MaxLength = 255;
            this.editDiaChi.Name = "editDiaChi";
            this.editDiaChi.Size = new System.Drawing.Size(254, 20);
            this.editDiaChi.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(47, 80);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Địa chỉ (*)";
            // 
            // editTen
            // 
            this.editTen.Location = new System.Drawing.Point(103, 53);
            this.editTen.Margin = new System.Windows.Forms.Padding(2);
            this.editTen.MaxLength = 50;
            this.editTen.Name = "editTen";
            this.editTen.Size = new System.Drawing.Size(254, 20);
            this.editTen.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(57, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Tên  (*)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Số điện thoại (*)";
            // 
            // editSoDienThoai
            // 
            this.editSoDienThoai.Location = new System.Drawing.Point(103, 26);
            this.editSoDienThoai.Margin = new System.Windows.Forms.Padding(2);
            this.editSoDienThoai.MaxLength = 11;
            this.editSoDienThoai.Name = "editSoDienThoai";
            this.editSoDienThoai.Size = new System.Drawing.Size(118, 20);
            this.editSoDienThoai.TabIndex = 1;
            this.editSoDienThoai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editSoHieuXe_KeyPress);
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
            this.tabThongTinLaiXe.Size = new System.Drawing.Size(401, 182);
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
            // frmKhachAo
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 230);
            this.Controls.Add(this.uiTab1);
            this.Controls.Add(this.uiGroupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmKhachAo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm/Sửa khách ảo";
            this.Load += new System.EventHandler(this.frmDoiTac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.tabDiaChi.ResumeLayout(false);
            this.tabDiaChi.PerformLayout();
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
        private Janus.Windows.GridEX.EditControls.EditBox editDiaChi;
        private System.Windows.Forms.Label label10;
        private Janus.Windows.GridEX.EditControls.EditBox editTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.EditControls.EditBox editSoDienThoai;
        private Janus.Windows.UI.Tab.UITabPage tabThongTinLaiXe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listDanhSachLaiXe;
        private System.Windows.Forms.ListBox listLaiXe;
        private Janus.Windows.EditControls.UIButton btnRemove;
        private Janus.Windows.EditControls.UIButton btnRemoveAll;
        private Janus.Windows.EditControls.UIButton btnAdd;
        private Janus.Windows.EditControls.UIButton btnAddAll;
    }
}