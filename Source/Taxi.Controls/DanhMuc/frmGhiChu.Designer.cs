namespace Taxi.Controls
{
    partial class frmGhiChu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNoiDung = new Taxi.Controls.Base.Inputs.InputMemoEdit();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.btnThem = new Taxi.Controls.Base.Controls.ShButton();
            this.txtTieuDe = new Taxi.Controls.Base.Inputs.InputText();
            this.btnThuNho = new Taxi.Controls.Base.Controls.ShButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTieuDe.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 176);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNoiDung);
            this.groupBox1.Controls.Add(this.shLabel2);
            this.groupBox1.Controls.Add(this.shLabel1);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.txtTieuDe);
            this.groupBox1.Controls.Add(this.btnThuNho);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 176);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.IsChangeText = false;
            this.txtNoiDung.IsFocus = false;
            this.txtNoiDung.Location = new System.Drawing.Point(64, 37);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(292, 81);
            this.txtNoiDung.TabIndex = 8;
            this.txtNoiDung.TextChanged += new System.EventHandler(this.txtNoiDung_TextChanged);
            this.txtNoiDung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoiDung_KeyDown);
            this.txtNoiDung.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNoiDung_KeyUp);
            // 
            // shLabel2
            // 
            this.shLabel2.Location = new System.Drawing.Point(14, 69);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(42, 13);
            this.shLabel2.TabIndex = 7;
            this.shLabel2.Text = "Nội dung";
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(14, 15);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(35, 13);
            this.shLabel1.TabIndex = 7;
            this.shLabel1.Text = "Tiêu đề";
            // 
            // btnThem
            // 
            this.btnThem.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnThem.KeyCommand = System.Windows.Forms.Keys.F2;
            this.btnThem.Location = new System.Drawing.Point(157, 123);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(56, 23);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "OK (F2)";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtTieuDe
            // 
            this.txtTieuDe.EditValue = "Ghi chú";
            this.txtTieuDe.IsChangeText = false;
            this.txtTieuDe.IsFocus = false;
            this.txtTieuDe.Location = new System.Drawing.Point(64, 11);
            this.txtTieuDe.Name = "txtTieuDe";
            this.txtTieuDe.Properties.MaxLength = 99;
            this.txtTieuDe.Size = new System.Drawing.Size(292, 20);
            this.txtTieuDe.TabIndex = 5;
            // 
            // btnThuNho
            // 
            this.btnThuNho.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnThuNho.KeyCommand = System.Windows.Forms.Keys.F3;
            this.btnThuNho.Location = new System.Drawing.Point(209, 69);
            this.btnThuNho.Name = "btnThuNho";
            this.btnThuNho.Size = new System.Drawing.Size(75, 23);
            this.btnThuNho.TabIndex = 0;
            this.btnThuNho.Text = "Thu nhỏ (F3)";
            this.btnThuNho.Click += new System.EventHandler(this.btnThuNho_Click);
            // 
            // frmGhiChu
            // 
            this.AcceptButton = this.btnThem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 153);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmGhiChu";
            this.Text = "Ghi chú (F3:Thu nhỏ)";
            this.Load += new System.EventHandler(this.frmGhiChu_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTieuDe.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Taxi.Controls.Base.Controls.ShLabel shLabel2;
        private Taxi.Controls.Base.Controls.ShLabel shLabel1;
        private Taxi.Controls.Base.Controls.ShButton btnThem;
        private Taxi.Controls.Base.Inputs.InputText txtTieuDe;
        private Taxi.Controls.Base.Inputs.InputMemoEdit txtNoiDung;
        private Base.Controls.ShButton btnThuNho;
    }
}