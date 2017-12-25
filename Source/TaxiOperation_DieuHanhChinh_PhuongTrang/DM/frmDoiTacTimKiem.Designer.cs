namespace Taxi.GUI
{
    partial class frmDoiTacTimKiem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoiTacTimKiem));
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.radDiaChi = new System.Windows.Forms.RadioButton();
            this.radDienThoại = new System.Windows.Forms.RadioButton();
            this.radTenDoiTac = new System.Windows.Forms.RadioButton();
            this.radMaDoiTac = new System.Windows.Forms.RadioButton();
            this.editThongTinTimKiem = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uiGroupBox2 = new Janus.Windows.EditControls.UIGroupBox();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.btnSave = new Janus.Windows.EditControls.UIButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.radDiaChi);
            this.uiGroupBox1.Controls.Add(this.radDienThoại);
            this.uiGroupBox1.Controls.Add(this.radTenDoiTac);
            this.uiGroupBox1.Controls.Add(this.radMaDoiTac);
            this.uiGroupBox1.Controls.Add(this.editThongTinTimKiem);
            this.uiGroupBox1.Controls.Add(this.label4);
            this.uiGroupBox1.ImageAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            this.uiGroupBox1.Location = new System.Drawing.Point(2, 0);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(406, 173);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "Thông tin đối tác";
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003;
            // 
            // radDiaChi
            // 
            this.radDiaChi.AutoSize = true;
            this.radDiaChi.Checked = true;
            this.radDiaChi.Location = new System.Drawing.Point(318, 60);
            this.radDiaChi.Name = "radDiaChi";
            this.radDiaChi.Size = new System.Drawing.Size(58, 17);
            this.radDiaChi.TabIndex = 11;
            this.radDiaChi.TabStop = true;
            this.radDiaChi.Text = "Địa chỉ";
            this.radDiaChi.UseVisualStyleBackColor = true;
            // 
            // radDienThoại
            // 
            this.radDienThoại.AutoSize = true;
            this.radDienThoại.Location = new System.Drawing.Point(239, 60);
            this.radDienThoại.Name = "radDienThoại";
            this.radDienThoại.Size = new System.Drawing.Size(73, 17);
            this.radDienThoại.TabIndex = 10;
            this.radDienThoại.Text = "Điện thoại";
            this.radDienThoại.UseVisualStyleBackColor = true;
            // 
            // radTenDoiTac
            // 
            this.radTenDoiTac.AutoSize = true;
            this.radTenDoiTac.Checked = true;
            this.radTenDoiTac.Location = new System.Drawing.Point(159, 60);
            this.radTenDoiTac.Name = "radTenDoiTac";
            this.radTenDoiTac.Size = new System.Drawing.Size(80, 17);
            this.radTenDoiTac.TabIndex = 9;
            this.radTenDoiTac.TabStop = true;
            this.radTenDoiTac.Text = "Tên đối tác";
            this.radTenDoiTac.UseVisualStyleBackColor = true;
            // 
            // radMaDoiTac
            // 
            this.radMaDoiTac.AutoSize = true;
            this.radMaDoiTac.Location = new System.Drawing.Point(80, 60);
            this.radMaDoiTac.Name = "radMaDoiTac";
            this.radMaDoiTac.Size = new System.Drawing.Size(76, 17);
            this.radMaDoiTac.TabIndex = 8;
            this.radMaDoiTac.Text = "Mã đối tác";
            this.radMaDoiTac.UseVisualStyleBackColor = true;
            // 
            // editThongTinTimKiem
            // 
            this.editThongTinTimKiem.Location = new System.Drawing.Point(81, 94);
            this.editThongTinTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.editThongTinTimKiem.MaxLength = 255;
            this.editThongTinTimKiem.Name = "editThongTinTimKiem";
            this.editThongTinTimKiem.Size = new System.Drawing.Size(298, 20);
            this.editThongTinTimKiem.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Thông tin tìm";
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.uiGroupBox2.Controls.Add(this.btnCancel);
            this.uiGroupBox2.Controls.Add(this.btnSave);
            this.uiGroupBox2.Location = new System.Drawing.Point(3, 177);
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
            this.btnCancel.Location = new System.Drawing.Point(208, 11);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 26);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Thoát";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(116, 11);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 26);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = " &Tìm kiếm";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // frmDoiTacTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 219);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmDoiTacTimKiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm đối tác";
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.GridEX.EditControls.EditBox editThongTinTimKiem;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox2;
        private Janus.Windows.EditControls.UIButton btnCancel;
        private Janus.Windows.EditControls.UIButton btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.RadioButton radDienThoại;
        private System.Windows.Forms.RadioButton radTenDoiTac;
        private System.Windows.Forms.RadioButton radMaDoiTac;
        private System.Windows.Forms.RadioButton radDiaChi;
    }
}