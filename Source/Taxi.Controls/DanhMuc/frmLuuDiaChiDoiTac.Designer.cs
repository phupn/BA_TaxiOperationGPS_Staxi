namespace Taxi.Controls.DanhMuc
{
    partial class frmLuuDiaChiDoiTac
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
            this.myPanelControl1 = new Taxi.Controls.BanCo.MyPanelControl();
            this.btnThoat = new Taxi.Controls.Base.Controls.ShButton();
            this.btnSave = new Taxi.Controls.Base.Controls.ShButton();
            this.txtDiaChiMoi = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            ((System.ComponentModel.ISupportInitialize)(this.myPanelControl1)).BeginInit();
            this.myPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChiMoi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // myPanelControl1
            // 
            this.myPanelControl1.Controls.Add(this.btnThoat);
            this.myPanelControl1.Controls.Add(this.btnSave);
            this.myPanelControl1.Controls.Add(this.txtDiaChiMoi);
            this.myPanelControl1.Controls.Add(this.shLabel1);
            this.myPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.myPanelControl1.Name = "myPanelControl1";
            this.myPanelControl1.Size = new System.Drawing.Size(406, 69);
            this.myPanelControl1.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(175, 41);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(81, 23);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(88, 41);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDiaChiMoi
            // 
            this.txtDiaChiMoi.IsChangeText = false;
            this.txtDiaChiMoi.IsFocus = false;
            this.txtDiaChiMoi.Location = new System.Drawing.Point(88, 9);
            this.txtDiaChiMoi.Name = "txtDiaChiMoi";
            this.txtDiaChiMoi.Size = new System.Drawing.Size(306, 20);
            this.txtDiaChiMoi.TabIndex = 2;
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(12, 12);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(58, 13);
            this.shLabel1.TabIndex = 1;
            this.shLabel1.Text = "Địa chỉ mới :";
            // 
            // frmLuuDiaChiDoiTac
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(406, 69);
            this.Controls.Add(this.myPanelControl1);
            this.Name = "frmLuuDiaChiDoiTac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lưu địa chỉ đối tác";
            this.Load += new System.EventHandler(this.frmLuuDiaChiDoiTac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myPanelControl1)).EndInit();
            this.myPanelControl1.ResumeLayout(false);
            this.myPanelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChiMoi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BanCo.MyPanelControl myPanelControl1;
        private Base.Controls.ShButton btnThoat;
        private Base.Controls.ShButton btnSave;
        private Base.Inputs.InputText txtDiaChiMoi;
        private Base.Controls.ShLabel shLabel1;
    }
}