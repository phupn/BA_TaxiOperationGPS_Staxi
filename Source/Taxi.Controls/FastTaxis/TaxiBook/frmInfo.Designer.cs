namespace Taxi.Controls.FastTaxis.TaxiDieuXe
{
    partial class frmInfo
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
            this.timer1 = new System.Windows.Forms.Timer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.shProgressBar_Timeout = new Taxi.Controls.Base.Controls.ShProgressBar();
            this.btnHienThi = new Taxi.Controls.Base.Controls.ShButton();
            this.shLabel5 = new Taxi.Controls.Base.Controls.ShLabel();
            this.lblXeDon = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel4 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel3 = new Taxi.Controls.Base.Controls.ShLabel();
            this.lblSoDT = new Taxi.Controls.Base.Controls.ShLabel();
            this.lblThoiDiemDon = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.lblDiaChiTra = new Taxi.Controls.Base.Inputs.InputMemoEdit();
            this.lblDiaChiDon = new Taxi.Controls.Base.Inputs.InputMemoEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shProgressBar_Timeout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDiaChiTra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDiaChiDon.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.shProgressBar_Timeout);
            this.groupBox1.Controls.Add(this.btnHienThi);
            this.groupBox1.Controls.Add(this.shLabel5);
            this.groupBox1.Controls.Add(this.lblXeDon);
            this.groupBox1.Controls.Add(this.shLabel4);
            this.groupBox1.Controls.Add(this.shLabel3);
            this.groupBox1.Controls.Add(this.lblSoDT);
            this.groupBox1.Controls.Add(this.lblThoiDiemDon);
            this.groupBox1.Controls.Add(this.shLabel2);
            this.groupBox1.Controls.Add(this.shLabel1);
            this.groupBox1.Controls.Add(this.lblDiaChiTra);
            this.groupBox1.Controls.Add(this.lblDiaChiDon);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 161);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Có khách cần xe chiều về";
            // 
            // shProgressBar_Timeout
            // 
            this.shProgressBar_Timeout.EditValue = 60;
            this.shProgressBar_Timeout.Location = new System.Drawing.Point(11, 128);
            this.shProgressBar_Timeout.Name = "shProgressBar_Timeout";
            this.shProgressBar_Timeout.Properties.EndColor = System.Drawing.Color.LimeGreen;
            this.shProgressBar_Timeout.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.shProgressBar_Timeout.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.shProgressBar_Timeout.Properties.Maximum = 60;
            this.shProgressBar_Timeout.Properties.PercentView = false;
            this.shProgressBar_Timeout.Properties.ShowTitle = true;
            this.shProgressBar_Timeout.Properties.StartColor = System.Drawing.Color.Ivory;
            this.shProgressBar_Timeout.Properties.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.shProgressBar_Timeout_Properties_CustomDisplayText);
            this.shProgressBar_Timeout.Size = new System.Drawing.Size(129, 22);
            this.shProgressBar_Timeout.TabIndex = 2;
            // 
            // btnHienThi
            // 
            this.btnHienThi.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnHienThi.Appearance.Font = new System.Drawing.Font("Arial", 9.25F);
            this.btnHienThi.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnHienThi.Appearance.Options.UseBackColor = true;
            this.btnHienThi.Appearance.Options.UseFont = true;
            this.btnHienThi.Appearance.Options.UseForeColor = true;
            this.btnHienThi.Appearance.Options.UseTextOptions = true;
            this.btnHienThi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnHienThi.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnHienThi.Location = new System.Drawing.Point(203, 126);
            this.btnHienThi.LookAndFeel.SkinName = "Caramel";
            this.btnHienThi.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnHienThi.Name = "btnHienThi";
            this.btnHienThi.Size = new System.Drawing.Size(111, 26);
            this.btnHienThi.TabIndex = 1;
            this.btnHienThi.Text = "Hiển thị (Ctrl+H)";
            this.btnHienThi.Click += new System.EventHandler(this.btnHienThi_Click);
            // 
            // shLabel5
            // 
            this.shLabel5.Location = new System.Drawing.Point(286, 15);
            this.shLabel5.Name = "shLabel5";
            this.shLabel5.Size = new System.Drawing.Size(33, 13);
            this.shLabel5.TabIndex = 0;
            this.shLabel5.Text = "Xe đón";
            this.shLabel5.Visible = false;
            // 
            // lblXeDon
            // 
            this.lblXeDon.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblXeDon.Location = new System.Drawing.Point(286, 28);
            this.lblXeDon.Name = "lblXeDon";
            this.lblXeDon.Size = new System.Drawing.Size(58, 13);
            this.lblXeDon.TabIndex = 0;
            this.lblXeDon.Text = "Địa chỉ trả";
            this.lblXeDon.Visible = false;
            // 
            // shLabel4
            // 
            this.shLabel4.Location = new System.Drawing.Point(10, 99);
            this.shLabel4.Name = "shLabel4";
            this.shLabel4.Size = new System.Drawing.Size(49, 13);
            this.shLabel4.TabIndex = 0;
            this.shLabel4.Text = "Địa chỉ trả";
            // 
            // shLabel3
            // 
            this.shLabel3.Location = new System.Drawing.Point(10, 65);
            this.shLabel3.Name = "shLabel3";
            this.shLabel3.Size = new System.Drawing.Size(53, 13);
            this.shLabel3.TabIndex = 0;
            this.shLabel3.Text = "Địa chỉ đón";
            // 
            // lblSoDT
            // 
            this.lblSoDT.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSoDT.Location = new System.Drawing.Point(83, 38);
            this.lblSoDT.Name = "lblSoDT";
            this.lblSoDT.Size = new System.Drawing.Size(29, 13);
            this.lblSoDT.TabIndex = 0;
            this.lblSoDT.Text = "Số đt";
            // 
            // lblThoiDiemDon
            // 
            this.lblThoiDiemDon.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblThoiDiemDon.Location = new System.Drawing.Point(82, 20);
            this.lblThoiDiemDon.Name = "lblThoiDiemDon";
            this.lblThoiDiemDon.Size = new System.Drawing.Size(79, 13);
            this.lblThoiDiemDon.TabIndex = 0;
            this.lblThoiDiemDon.Text = "Thời điểm đón";
            // 
            // shLabel2
            // 
            this.shLabel2.Location = new System.Drawing.Point(11, 38);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(25, 13);
            this.shLabel2.TabIndex = 0;
            this.shLabel2.Text = "Số đt";
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(10, 20);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(66, 13);
            this.shLabel1.TabIndex = 0;
            this.shLabel1.Text = "Thời điểm đón";
            // 
            // lblDiaChiTra
            // 
            this.lblDiaChiTra.IsChangeText = false;
            this.lblDiaChiTra.IsFocus = false;
            this.lblDiaChiTra.Location = new System.Drawing.Point(81, 91);
            this.lblDiaChiTra.Name = "lblDiaChiTra";
            this.lblDiaChiTra.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblDiaChiTra.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this.lblDiaChiTra.Properties.Appearance.Options.UseBackColor = true;
            this.lblDiaChiTra.Properties.Appearance.Options.UseFont = true;
            this.lblDiaChiTra.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblDiaChiTra.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblDiaChiTra.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.lblDiaChiTra.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.lblDiaChiTra.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.lblDiaChiTra.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lblDiaChiTra.Properties.AppearanceReadOnly.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.lblDiaChiTra.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblDiaChiTra.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblDiaChiTra.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.lblDiaChiTra.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.lblDiaChiTra.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblDiaChiTra.Properties.ReadOnly = true;
            this.lblDiaChiTra.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.lblDiaChiTra.Size = new System.Drawing.Size(233, 29);
            this.lblDiaChiTra.TabIndex = 3;
            // 
            // lblDiaChiDon
            // 
            this.lblDiaChiDon.IsChangeText = false;
            this.lblDiaChiDon.IsFocus = false;
            this.lblDiaChiDon.Location = new System.Drawing.Point(81, 57);
            this.lblDiaChiDon.Name = "lblDiaChiDon";
            this.lblDiaChiDon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblDiaChiDon.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this.lblDiaChiDon.Properties.Appearance.Options.UseBackColor = true;
            this.lblDiaChiDon.Properties.Appearance.Options.UseFont = true;
            this.lblDiaChiDon.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblDiaChiDon.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblDiaChiDon.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.lblDiaChiDon.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.lblDiaChiDon.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.lblDiaChiDon.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.lblDiaChiDon.Properties.AppearanceReadOnly.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.lblDiaChiDon.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblDiaChiDon.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblDiaChiDon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.lblDiaChiDon.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.lblDiaChiDon.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblDiaChiDon.Properties.ReadOnly = true;
            this.lblDiaChiDon.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.lblDiaChiDon.Size = new System.Drawing.Size(233, 29);
            this.lblDiaChiDon.TabIndex = 3;
            // 
            // frmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 161);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shProgressBar_Timeout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDiaChiTra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDiaChiDon.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Base.Controls.ShLabel shLabel1;
        private Base.Controls.ShLabel shLabel5;
        private Base.Controls.ShLabel shLabel4;
        private Base.Controls.ShLabel shLabel3;
        private Base.Controls.ShLabel shLabel2;
        private Base.Controls.ShLabel lblSoDT;
        private Base.Controls.ShLabel lblThoiDiemDon;
        private Base.Controls.ShLabel lblXeDon;
        private System.Windows.Forms.Timer timer1;
        private Base.Controls.ShButton btnHienThi;
        private Base.Controls.ShProgressBar shProgressBar_Timeout;
        private Base.Inputs.InputMemoEdit lblDiaChiTra;
        private Base.Inputs.InputMemoEdit lblDiaChiDon;
    }
}