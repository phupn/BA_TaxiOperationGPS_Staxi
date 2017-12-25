using DevExpress.XtraPrinting;

namespace Taxi.Controls.Base
{
    partial class FormManager
    {
        public FormManager()
        {
            InitializeComponent();
        }
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
            this.panelView = new System.Windows.Forms.Panel();
            this.panelAction = new System.Windows.Forms.Panel();
            this.lblMessage = new Taxi.Controls.Base.Controls.ShLabel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnThem = new Taxi.Controls.Base.Controls.ShButton();
            this.btnXuatExcel = new Taxi.Controls.Base.Controls.ShButton();
            this.btnTimKiem = new Taxi.Controls.Base.Controls.ShButton();
            this.btnLamMoi = new Taxi.Controls.Base.Controls.ShButton();
            this.btnSua = new Taxi.Controls.Base.Controls.ShButton();
            this.btnXoa = new Taxi.Controls.Base.Controls.ShButton();
            this.grBTimKiem = new System.Windows.Forms.GroupBox();
            this.panelInputFind = new Taxi.Controls.Base.Controls.ShPanel();
            this.panelAction.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.grBTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelInputFind)).BeginInit();
            this.SuspendLayout();
            // 
            // panelView
            // 
            this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelView.Location = new System.Drawing.Point(0, 158);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(682, 418);
            this.panelView.TabIndex = 2;
            // 
            // panelAction
            // 
            this.panelAction.Controls.Add(this.lblMessage);
            this.panelAction.Controls.Add(this.panelButton);
            this.panelAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAction.Location = new System.Drawing.Point(0, 100);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(682, 58);
            this.panelAction.TabIndex = 1;
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblMessage.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblMessage.Location = new System.Drawing.Point(313, 38);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(60, 14);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Thông báo";
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btnThem);
            this.panelButton.Controls.Add(this.btnXuatExcel);
            this.panelButton.Controls.Add(this.btnTimKiem);
            this.panelButton.Controls.Add(this.btnLamMoi);
            this.panelButton.Controls.Add(this.btnSua);
            this.panelButton.Controls.Add(this.btnXoa);
            this.panelButton.Location = new System.Drawing.Point(97, 2);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(489, 31);
            this.panelButton.TabIndex = 1;
            // 
            // btnThem
            // 
            this.btnThem.KeyCommand = System.Windows.Forms.Keys.F1;
            this.btnThem.Location = new System.Drawing.Point(3, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm (F1)";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.btnXuatExcel.Location = new System.Drawing.Point(408, 4);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(75, 23);
            this.btnXuatExcel.TabIndex = 5;
            this.btnXuatExcel.Text = "Xuất [E]xcel";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.KeyCommand = System.Windows.Forms.Keys.F3;
            this.btnTimKiem.Location = new System.Drawing.Point(246, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm kiếm (F3)";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.KeyCommand = System.Windows.Forms.Keys.F5;
            this.btnLamMoi.Location = new System.Drawing.Point(327, 4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 23);
            this.btnLamMoi.TabIndex = 4;
            this.btnLamMoi.Text = "Làm mới (F5)";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnSua
            // 
            this.btnSua.KeyCommand = System.Windows.Forms.Keys.F2;
            this.btnSua.Location = new System.Drawing.Point(84, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa (F2)";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.KeyCommand = System.Windows.Forms.Keys.F6;
            this.btnXoa.Location = new System.Drawing.Point(165, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa (F6)";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // grBTimKiem
            // 
            this.grBTimKiem.Controls.Add(this.panelInputFind);
            this.grBTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.grBTimKiem.Location = new System.Drawing.Point(0, 0);
            this.grBTimKiem.Name = "grBTimKiem";
            this.grBTimKiem.Size = new System.Drawing.Size(682, 100);
            this.grBTimKiem.TabIndex = 0;
            this.grBTimKiem.TabStop = false;
            this.grBTimKiem.Text = "Thông tin tìm kiếm";
            // 
            // panelInputFind
            // 
            this.panelInputFind.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelInputFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInputFind.LabelMessage = null;
            this.panelInputFind.Location = new System.Drawing.Point(3, 16);
            this.panelInputFind.Name = "panelInputFind";
            this.panelInputFind.Size = new System.Drawing.Size(676, 81);
            this.panelInputFind.TabIndex = 0;
            // 
            // FormManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 576);
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.panelAction);
            this.Controls.Add(this.grBTimKiem);
            this.Name = "FormManager";
            this.Text = "FormManger";
            this.Load += new System.EventHandler(this.FormManger_Load);
            this.SizeChanged += new System.EventHandler(this.FormManger_SizeChanged);
            this.panelAction.ResumeLayout(false);
            this.panelAction.PerformLayout();
            this.panelButton.ResumeLayout(false);
            this.grBTimKiem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelInputFind)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Controls.ShButton btnLamMoi;
        protected Controls.ShButton btnXoa;
        protected Controls.ShButton btnSua;
        protected Controls.ShButton btnThem;
        protected Controls.ShButton btnXuatExcel;
        protected Controls.ShLabel lblMessage;
        protected Controls.ShButton btnTimKiem;
        public System.Windows.Forms.GroupBox grBTimKiem;
        public Controls.ShPanel panelInputFind;
        public System.Windows.Forms.Panel panelView;
        public System.Windows.Forms.Panel panelAction;
        public System.Windows.Forms.Panel panelButton;
    }
}