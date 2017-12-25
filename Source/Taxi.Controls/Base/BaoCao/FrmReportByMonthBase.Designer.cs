using Taxi.Controls.Base.Common;

namespace Taxi.Controls.BaoCao
{
    partial class FrmReportByMonthBase
    {
        public FrmReportByMonthBase()
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.ipMonth = new LookupEdit_Month();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.ipYear = new LookupEdit_Year();
            ((System.ComponentModel.ISupportInitialize)(this.pnInputs)).BeginInit();
            this.pnInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnButtons)).BeginInit();
            this.pnButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipYear.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnInputs
            // 
            this.pnInputs.Controls.Add(this.ipYear);
            this.pnInputs.Controls.Add(this.labelControl4);
            this.pnInputs.Controls.Add(this.ipMonth);
            this.pnInputs.Controls.Add(this.labelControl3);
            this.pnInputs.Location = new System.Drawing.Point(0, 61);
            this.pnInputs.Controls.SetChildIndex(this.ipFromDate, 0);
            this.pnInputs.Controls.SetChildIndex(this.labelControl1, 0);
            this.pnInputs.Controls.SetChildIndex(this.ipToDate, 0);
            this.pnInputs.Controls.SetChildIndex(this.labelControl2, 0);
            this.pnInputs.Controls.SetChildIndex(this.labelControl3, 0);
            this.pnInputs.Controls.SetChildIndex(this.ipMonth, 0);
            this.pnInputs.Controls.SetChildIndex(this.labelControl4, 0);
            this.pnInputs.Controls.SetChildIndex(this.ipYear, 0);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 31);
            this.labelControl2.Visible = false;
            // 
            // ipToDate
            // 
            this.ipToDate.EditValue = new System.DateTime(2014, 8, 31, 23, 59, 59, 0);
            this.ipToDate.Location = new System.Drawing.Point(70, 28);
            this.ipToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.ipToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.ipToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.ipToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.ipToDate.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 6);
            this.labelControl1.Visible = false;
            // 
            // ipFromDate
            // 
            this.ipFromDate.EditValue = new System.DateTime(2014, 8, 1, 0, 0, 0, 0);
            this.ipFromDate.Location = new System.Drawing.Point(70, 3);
            this.ipFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.ipFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.ipFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.ipFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.ipFromDate.Visible = false;
            // 
            // pnButtons
            // 
            this.pnButtons.Location = new System.Drawing.Point(0, 158);
            // 
            // lbMessage
            // 
            this.lbMessage.Appearance.ForeColor = System.Drawing.Color.Red;
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
            this.pnOutput.Location = new System.Drawing.Point(0, 210);
            this.pnOutput.Size = new System.Drawing.Size(817, 371);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(232, 6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(30, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Tháng";
            // 
            // ipMonth
            // 
            this.ipMonth.Location = new System.Drawing.Point(268, 3);
            this.ipMonth.Name = "ipMonth";
            this.ipMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ipMonth.Properties.NullText = "";
            this.ipMonth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ipMonth.Size = new System.Drawing.Size(100, 20);
            this.ipMonth.TabIndex = 5;
            this.ipMonth.EditValueChanged += new System.EventHandler(this.ipMonthYear_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(418, 6);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(21, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Năm";
            // 
            // ipYear
            // 
            this.ipYear.Location = new System.Drawing.Point(445, 3);
            this.ipYear.Name = "ipYear";
            this.ipYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ipYear.Properties.NullText = "";
            this.ipYear.Size = new System.Drawing.Size(100, 20);
            this.ipYear.TabIndex = 7;
            this.ipYear.EditValueChanged += new System.EventHandler(this.ipMonthYear_EditValueChanged);
            // 
            // FrmReportByMonthBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 581);
            this.Name = "FrmReportByMonthBase";
            this.Text = "FrmReportByMonthBase";
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
            ((System.ComponentModel.ISupportInitialize)(this.ipMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipYear.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.LabelControl labelControl3;
        protected LookupEdit_Year ipYear;
        protected DevExpress.XtraEditors.LabelControl labelControl4;
        protected LookupEdit_Month ipMonth;

    }
}