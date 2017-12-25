namespace Taxi.GUI
{
    partial class frmTraCuu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTraCuu));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaSoThe = new Janus.Windows.GridEX.EditControls.EditBox();
            this.cboCongTy = new Janus.Windows.EditControls.UIComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblGiaTriSuDung = new System.Windows.Forms.Label();
            this.numSeriDau = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.lblVeThe = new System.Windows.Forms.Label();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.radVe = new Janus.Windows.EditControls.UIRadioButton();
            this.radHopDong = new Janus.Windows.EditControls.UIRadioButton();
            this.radThe = new Janus.Windows.EditControls.UIRadioButton();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblGhiChu);
            this.groupBox1.Controls.Add(this.txtNam);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMaSoThe);
            this.groupBox1.Controls.Add(this.cboCongTy);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblGiaTriSuDung);
            this.groupBox1.Controls.Add(this.numSeriDau);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnThemMoi);
            this.groupBox1.Controls.Add(this.lblVeThe);
            this.groupBox1.Controls.Add(this.uiGroupBox1);
            this.groupBox1.Location = new System.Drawing.Point(9, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tra cứu";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.ForeColor = System.Drawing.Color.Red;
            this.lblGhiChu.Location = new System.Drawing.Point(127, 96);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(44, 13);
            this.lblGhiChu.TabIndex = 30;
            this.lblGhiChu.Text = "Ghi chu";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(312, 20);
            this.txtNam.MaxLength = 4;
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(32, 20);
            this.txtNam.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(253, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Năm (*)";
            // 
            // txtMaSoThe
            // 
            this.txtMaSoThe.Location = new System.Drawing.Point(127, 70);
            this.txtMaSoThe.Name = "txtMaSoThe";
            this.txtMaSoThe.Size = new System.Drawing.Size(117, 20);
            this.txtMaSoThe.TabIndex = 1;
            this.txtMaSoThe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaSoThe_KeyDown);
            // 
            // cboCongTy
            // 
            this.cboCongTy.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboCongTy.Location = new System.Drawing.Point(127, 19);
            this.cboCongTy.Name = "cboCongTy";
            this.cboCongTy.Size = new System.Drawing.Size(117, 20);
            this.cboCongTy.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(47, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 17);
            this.label9.TabIndex = 27;
            this.label9.Text = "Đơn vị  (*)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Giá trị sử dụng";
            // 
            // lblGiaTriSuDung
            // 
            this.lblGiaTriSuDung.AutoSize = true;
            this.lblGiaTriSuDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaTriSuDung.ForeColor = System.Drawing.Color.Blue;
            this.lblGiaTriSuDung.Location = new System.Drawing.Point(108, 116);
            this.lblGiaTriSuDung.Name = "lblGiaTriSuDung";
            this.lblGiaTriSuDung.Size = new System.Drawing.Size(0, 13);
            this.lblGiaTriSuDung.TabIndex = 21;
            // 
            // numSeriDau
            // 
            this.numSeriDau.Location = new System.Drawing.Point(127, 70);
            this.numSeriDau.Name = "numSeriDau";
            this.numSeriDau.Size = new System.Drawing.Size(117, 20);
            this.numSeriDau.TabIndex = 1;
            this.numSeriDau.Text = "0";
            this.numSeriDau.ValueType = Janus.Windows.GridEX.NumericEditValueType.UInt64;
            this.numSeriDau.Leave += new System.EventHandler(this.numSeriDau_Leave);
            this.numSeriDau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numSeriDau_KeyDown);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(209, 137);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(61, 27);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMoi.Location = new System.Drawing.Point(130, 137);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(73, 27);
            this.btnThemMoi.TabIndex = 2;
            this.btnThemMoi.Text = "Tra cứu";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // lblVeThe
            // 
            this.lblVeThe.AutoSize = true;
            this.lblVeThe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVeThe.Location = new System.Drawing.Point(40, 70);
            this.lblVeThe.Name = "lblVeThe";
            this.lblVeThe.Size = new System.Drawing.Size(52, 17);
            this.lblVeThe.TabIndex = 6;
            this.lblVeThe.Text = "Seri vé";
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BorderColor = System.Drawing.Color.Transparent;
            this.uiGroupBox1.Controls.Add(this.radVe);
            this.uiGroupBox1.Controls.Add(this.radHopDong);
            this.uiGroupBox1.Controls.Add(this.radThe);
            this.uiGroupBox1.Location = new System.Drawing.Point(125, 40);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(219, 27);
            this.uiGroupBox1.TabIndex = 0;
            // 
            // radVe
            // 
            this.radVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radVe.Location = new System.Drawing.Point(5, 1);
            this.radVe.Name = "radVe";
            this.radVe.Size = new System.Drawing.Size(39, 23);
            this.radVe.TabIndex = 0;
            this.radVe.Text = "Vé";
            this.radVe.CheckedChanged += new System.EventHandler(this.radVe_CheckedChanged);
            // 
            // radHopDong
            // 
            this.radHopDong.Checked = true;
            this.radHopDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHopDong.Location = new System.Drawing.Point(104, 0);
            this.radHopDong.Name = "radHopDong";
            this.radHopDong.Size = new System.Drawing.Size(83, 23);
            this.radHopDong.TabIndex = 2;
            this.radHopDong.TabStop = true;
            this.radHopDong.Text = "Hợp đồng";
            this.radHopDong.CheckedChanged += new System.EventHandler(this.radHopDong_CheckedChanged);
            // 
            // radThe
            // 
            this.radThe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radThe.Location = new System.Drawing.Point(50, 0);
            this.radThe.Name = "radThe";
            this.radThe.Size = new System.Drawing.Size(48, 23);
            this.radThe.TabIndex = 1;
            this.radThe.Text = "Thẻ";
            this.radThe.CheckedChanged += new System.EventHandler(this.radThe_CheckedChanged);
            // 
            // frmTraCuu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 185);
            this.Controls.Add(this.groupBox1);
            this.Icon = TaxiApplication.Properties.Resources.Telephone_01;
            this.Name = "frmTraCuu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tra cứu vé";
            this.Load += new System.EventHandler(this.frmTraCuu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblVeThe;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnThoat;
        private Janus.Windows.GridEX.EditControls.NumericEditBox numSeriDau;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblGiaTriSuDung;
        private Janus.Windows.EditControls.UIComboBox cboCongTy;
        private System.Windows.Forms.Label label9;
        private Janus.Windows.EditControls.UIRadioButton radThe;
        private Janus.Windows.EditControls.UIRadioButton radVe;
        private Janus.Windows.GridEX.EditControls.EditBox txtMaSoThe;
        private Janus.Windows.EditControls.UIRadioButton radHopDong;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGhiChu;

    }
}