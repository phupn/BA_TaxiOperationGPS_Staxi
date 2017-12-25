namespace TaxiOperation_DieuXeDuongDai.XuLyDieuXe
{
    partial class frmXeDiTinhXoa
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
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.inputMemoEdit1 = new Taxi.Controls.Base.Inputs.InputMemoEdit();
            this.lupTrangThai = new Taxi.Controls.Base.Inputs.InputLookUp();
            this.btnCancel = new Taxi.Controls.Base.Controls.ShButton();
            this.btnOK = new Taxi.Controls.Base.Controls.ShButton();
            ((System.ComponentModel.ISupportInitialize)(this.inputMemoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupTrangThai.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // shLabel2
            // 
            this.shLabel2.Location = new System.Drawing.Point(22, 36);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(35, 13);
            this.shLabel2.TabIndex = 8;
            this.shLabel2.Text = "Ghi chú";
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(22, 11);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(47, 13);
            this.shLabel1.TabIndex = 8;
            this.shLabel1.Text = "Lý do xóa";
            // 
            // inputMemoEdit1
            // 
            this.inputMemoEdit1.Location = new System.Drawing.Point(73, 33);
            this.inputMemoEdit1.Name = "inputMemoEdit1";
            this.inputMemoEdit1.Size = new System.Drawing.Size(189, 70);
            this.inputMemoEdit1.TabIndex = 7;
            // 
            // lupTrangThai
            // 
            this.lupTrangThai.KeyCommand = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.lupTrangThai.Location = new System.Drawing.Point(73, 8);
            this.lupTrangThai.Name = "lupTrangThai";
            this.lupTrangThai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupTrangThai.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TrangThai", "  ")});
            this.lupTrangThai.Properties.DisplayMember = "TrangThai";
            this.lupTrangThai.Properties.NullText = "";
            this.lupTrangThai.Properties.ValueMember = "GiaTri";
            this.lupTrangThai.Size = new System.Drawing.Size(189, 20);
            this.lupTrangThai.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(169, 108);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(78, 108);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmXeDiTinhXoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 136);
            this.CloseByKeyEsc = true;
            this.Controls.Add(this.shLabel2);
            this.Controls.Add(this.shLabel1);
            this.Controls.Add(this.inputMemoEdit1);
            this.Controls.Add(this.lupTrangThai);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.HelpButton = true;
            this.Name = "frmXeDiTinhXoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bạn có chắc xóa";
            this.Load += new System.EventHandler(this.frmXeDiTinhXoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inputMemoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupTrangThai.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Taxi.Controls.Base.Controls.ShButton btnOK;
        private Taxi.Controls.Base.Controls.ShButton btnCancel;
        private Taxi.Controls.Base.Inputs.InputLookUp lupTrangThai;
        private Taxi.Controls.Base.Inputs.InputMemoEdit inputMemoEdit1;
        private Taxi.Controls.Base.Controls.ShLabel shLabel1;
        private Taxi.Controls.Base.Controls.ShLabel shLabel2;
    }
}