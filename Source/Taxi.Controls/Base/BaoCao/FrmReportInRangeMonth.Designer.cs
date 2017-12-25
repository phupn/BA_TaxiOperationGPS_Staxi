using Taxi.Controls.Base.Common;

namespace Taxi.Controls.BaoCao
{
    partial class FrmReportInRangeMonth
    {
        public FrmReportInRangeMonth()
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
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.ipToMonth = new LookupEdit_Month();
            ((System.ComponentModel.ISupportInitialize)(this.ipYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnInputs)).BeginInit();
            this.pnInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnButtons)).BeginInit();
            this.pnButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipToMonth.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(209, 9);
            this.labelControl3.Size = new System.Drawing.Size(44, 13);
            this.labelControl3.Text = "Từ tháng";
            // 
            // ipYear
            // 
            this.ipYear.EditValue = "2014";
            this.ipYear.Location = new System.Drawing.Point(259, 32);
            this.ipYear.Tag = "Year";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(209, 35);
            // 
            // ipMonth
            // 
            this.ipMonth.EditValue = "8";
            this.ipMonth.Location = new System.Drawing.Point(259, 6);
            this.ipMonth.Tag = "FromMonth";
            // 
            // pnInputs
            // 
            this.pnInputs.Controls.Add(this.ipToMonth);
            this.pnInputs.Controls.Add(this.labelControl5);
            this.pnInputs.Size = new System.Drawing.Size(817, 64);
            this.pnInputs.Controls.SetChildIndex(this.ipFromDate, 0);
            this.pnInputs.Controls.SetChildIndex(this.labelControl1, 0);
            this.pnInputs.Controls.SetChildIndex(this.ipToDate, 0);
            this.pnInputs.Controls.SetChildIndex(this.labelControl2, 0);
            this.pnInputs.Controls.SetChildIndex(this.labelControl3, 0);
            this.pnInputs.Controls.SetChildIndex(this.ipMonth, 0);
            this.pnInputs.Controls.SetChildIndex(this.labelControl4, 0);
            this.pnInputs.Controls.SetChildIndex(this.ipYear, 0);
            this.pnInputs.Controls.SetChildIndex(this.labelControl5, 0);
            this.pnInputs.Controls.SetChildIndex(this.ipToMonth, 0);
            // 
            // ipToDate
            // 
            this.ipToDate.EditValue = new System.DateTime(2014, 8, 21, 15, 1, 42, 204);
            this.ipToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.ipToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.ipToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.ipToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            // 
            // ipFromDate
            // 
            this.ipFromDate.EditValue = new System.DateTime(2014, 8, 1, 0, 0, 0, 0);
            this.ipFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.ipFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.ipFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.ipFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            // 
            // pnButtons
            // 
            this.pnButtons.Location = new System.Drawing.Point(0, 125);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Appearance.Options.UseFont = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.Options.UseFont = true;
            // 
            // btnTim
            // 
            this.btnTim.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Appearance.Options.UseFont = true;
            // 
            // pnOutput
            // 
            this.pnOutput.Location = new System.Drawing.Point(0, 177);
            this.pnOutput.Size = new System.Drawing.Size(817, 404);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(398, 9);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(51, 13);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "Đến tháng";
            // 
            // ipToMonth
            // 
            this.ipToMonth.Location = new System.Drawing.Point(455, 6);
            this.ipToMonth.Name = "ipToMonth";
            this.ipToMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ipToMonth.Properties.NullText = "";
            this.ipToMonth.Size = new System.Drawing.Size(100, 20);
            this.ipToMonth.TabIndex = 9;
            this.ipToMonth.Tag = "ToMonth";
            // 
            // FrmReportInRangeMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 581);
            this.Name = "FrmReportInRangeMonth";
            this.Text = "FrmReportInRangeMonth";
            ((System.ComponentModel.ISupportInitialize)(this.ipYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnInputs)).EndInit();
            this.pnInputs.ResumeLayout(false);
            this.pnInputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnButtons)).EndInit();
            this.pnButtons.ResumeLayout(false);
            this.pnButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipToMonth.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected LookupEdit_Month ipToMonth;
        protected DevExpress.XtraEditors.LabelControl labelControl5;

    }
}