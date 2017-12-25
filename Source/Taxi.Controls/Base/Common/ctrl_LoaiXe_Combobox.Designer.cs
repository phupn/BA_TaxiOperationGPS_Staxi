namespace Taxi.Controls.Base.Common
{
    partial class ctrl_LoaiXe_Combobox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lueSoHieuXe = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSoHieuXe.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lueSoHieuXe
            // 
            this.lueSoHieuXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lueSoHieuXe.Location = new System.Drawing.Point(0, 0);
            this.lueSoHieuXe.Name = "lueSoHieuXe";
            this.lueSoHieuXe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSoHieuXe.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LoaiXeID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenLoaiXe", "Tên"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SoCho", "Số chỗ", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LoaiXeID_GPS", "ID GPS", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VietTat", "Viết tắt", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lueSoHieuXe.Properties.NullText = "Chọn loại xe";
            this.lueSoHieuXe.Size = new System.Drawing.Size(208, 20);
            this.lueSoHieuXe.TabIndex = 0;
            this.lueSoHieuXe.EditValueChanged += new System.EventHandler(this.lueSoHieuXe_EditValueChanged);
            // 
            // ctrl_LoaiXe_Combobox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lueSoHieuXe);
            this.Name = "ctrl_LoaiXe_Combobox";
            this.Size = new System.Drawing.Size(208, 20);
            ((System.ComponentModel.ISupportInitialize)(this.lueSoHieuXe.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraEditors.LookUpEdit lueSoHieuXe;
    }
}
