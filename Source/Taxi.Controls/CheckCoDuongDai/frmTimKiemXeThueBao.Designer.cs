namespace Taxi.Controls.FormCheckCoDuongDai
{
    partial class frmTimKiemXeThueBao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimKiemXeThueBao));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoHieuXe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.calDenNgay = new Taxi.Controls.Base.Inputs.InputDate();
            this.calTuNgay = new Taxi.Controls.Base.Inputs.InputDate();
            ((System.ComponentModel.ISupportInitialize)(this.calDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calTuNgay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Đến ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Từ ngày";
            // 
            // txtSoHieuXe
            // 
            this.txtSoHieuXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoHieuXe.Location = new System.Drawing.Point(57, 32);
            this.txtSoHieuXe.MaxLength = 3;
            this.txtSoHieuXe.Name = "txtSoHieuXe";
            this.txtSoHieuXe.Size = new System.Drawing.Size(48, 23);
            this.txtSoHieuXe.TabIndex = 23;
            this.txtSoHieuXe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Số xe";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(324, 33);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 25;
            this.btnTimKiem.Text = "&Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(171, 33);
            this.txtTimKiem.MaxLength = 20;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(147, 23);
            this.txtTimKiem.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(107, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "Tìm khác";
            // 
            // calDenNgay
            // 
            this.calDenNgay.DateNowWhenLoad = true;
            this.calDenNgay.EditValue = null;
            this.calDenNgay.IsChangeText = false;
            this.calDenNgay.IsFocus = false;
            this.calDenNgay.Location = new System.Drawing.Point(257, 5);
            this.calDenNgay.Name = "calDenNgay";
            this.calDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.calDenNgay.Properties.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.calDenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.calDenNgay.Properties.EditFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.calDenNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.calDenNgay.Properties.Mask.EditMask = "HH:mm dd/MM/yyyy";
            this.calDenNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.calDenNgay.Properties.MinValue = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.calDenNgay.Size = new System.Drawing.Size(135, 20);
            this.calDenNgay.TabIndex = 51;
            this.calDenNgay.Tag = "FromDate";
            // 
            // calTuNgay
            // 
            this.calTuNgay.DateNowWhenLoad = true;
            this.calTuNgay.EditValue = null;
            this.calTuNgay.IsChangeText = false;
            this.calTuNgay.IsFocus = false;
            this.calTuNgay.Location = new System.Drawing.Point(57, 5);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.calTuNgay.Properties.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.calTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.calTuNgay.Properties.EditFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.calTuNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.calTuNgay.Properties.Mask.EditMask = "HH:mm dd/MM/yyyy";
            this.calTuNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.calTuNgay.Properties.MinValue = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.calTuNgay.Size = new System.Drawing.Size(135, 20);
            this.calTuNgay.TabIndex = 50;
            this.calTuNgay.Tag = "FromDate";
            // 
            // frmTimKiemXeThueBao
            // 
            this.AcceptButton = this.btnTimKiem;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 66);
            this.Controls.Add(this.calDenNgay);
            this.Controls.Add(this.calTuNgay);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtSoHieuXe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTimKiemXeThueBao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tìm xe";
            this.Load += new System.EventHandler(this.frmTimKiemXeThueBao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.calDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calTuNgay.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoHieuXe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label4;
        protected Base.Inputs.InputDate calTuNgay;
        protected Base.Inputs.InputDate calDenNgay;
    }
}