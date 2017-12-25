namespace Taxi.Controls.BaoCao
{
    partial class FrmReportBase
    {
        public FrmReportBase()
        {
            IsLastDate = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportBase));
            this.pnTitle = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.pnInputs = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.ipToDate = new Taxi.Controls.Base.Inputs.InputDate();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ipFromDate = new Taxi.Controls.Base.Inputs.InputDate();
            this.pnButtons = new DevExpress.XtraEditors.PanelControl();
            this.lbMessage = new DevExpress.XtraEditors.LabelControl();
            this.btnExportExcel = new Taxi.Controls.Base.Controls.ShButton();
            this.btnThoat = new Taxi.Controls.Base.Controls.ShButton();
            this.btnTim = new Taxi.Controls.Base.Controls.ShButton();
            this.pnOutput = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnTitle)).BeginInit();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnInputs)).BeginInit();
            this.pnInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnButtons)).BeginInit();
            this.pnButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTitle
            // 
            this.pnTitle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnTitle.Controls.Add(this.lblTitle);
            resources.ApplyResources(this.pnTitle, "pnTitle");
            this.pnTitle.Name = "pnTitle";
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblTitle.Appearance.Font")));
            this.lblTitle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // pnInputs
            // 
            this.pnInputs.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnInputs.Controls.Add(this.labelControl2);
            this.pnInputs.Controls.Add(this.ipToDate);
            this.pnInputs.Controls.Add(this.labelControl1);
            this.pnInputs.Controls.Add(this.ipFromDate);
            resources.ApplyResources(this.pnInputs, "pnInputs");
            this.pnInputs.Name = "pnInputs";
            // 
            // labelControl2
            // 
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Name = "labelControl2";
            // 
            // ipToDate
            // 
            this.ipToDate.DateNowWhenLoad = true;
            resources.ApplyResources(this.ipToDate, "ipToDate");
            this.ipToDate.IsChangeText = false;
            this.ipToDate.IsFocus = false;
            this.ipToDate.Name = "ipToDate";
            this.ipToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ipToDate.Properties.Buttons"))))});
            this.ipToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.ipToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.ipToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipToDate.Properties.Mask.EditMask = resources.GetString("ipToDate.Properties.Mask.EditMask");
            this.ipToDate.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("ipToDate.Properties.Mask.MaskType")));
            this.ipToDate.Properties.MinValue = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.ipToDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ipToDate.Tag = "ToDate";
            this.ipToDate.EditValueChanged += new System.EventHandler(this.ipToDate_EditValueChanged);
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // ipFromDate
            // 
            this.ipFromDate.DateNowWhenLoad = true;
            resources.ApplyResources(this.ipFromDate, "ipFromDate");
            this.ipFromDate.IsChangeText = false;
            this.ipFromDate.IsFocus = false;
            this.ipFromDate.Name = "ipFromDate";
            this.ipFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ipFromDate.Properties.Buttons"))))});
            this.ipFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.ipFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.ipFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ipFromDate.Properties.Mask.EditMask = resources.GetString("ipFromDate.Properties.Mask.EditMask");
            this.ipFromDate.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("ipFromDate.Properties.Mask.MaskType")));
            this.ipFromDate.Properties.MinValue = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.ipFromDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ipFromDate.Tag = "FromDate";
            this.ipFromDate.EditValueChanged += new System.EventHandler(this.ipFromDate_EditValueChanged);
            // 
            // pnButtons
            // 
            this.pnButtons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnButtons.Controls.Add(this.lbMessage);
            this.pnButtons.Controls.Add(this.btnExportExcel);
            this.pnButtons.Controls.Add(this.btnThoat);
            this.pnButtons.Controls.Add(this.btnTim);
            resources.ApplyResources(this.pnButtons, "pnButtons");
            this.pnButtons.Name = "pnButtons";
            // 
            // lbMessage
            // 
            resources.ApplyResources(this.lbMessage, "lbMessage");
            this.lbMessage.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lbMessage.Appearance.ForeColor")));
            this.lbMessage.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.lbMessage.Name = "lbMessage";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnExportExcel.Appearance.Font")));
            this.btnExportExcel.Appearance.Options.UseFont = true;
            this.btnExportExcel.KeyCommand = System.Windows.Forms.Keys.F4;
            resources.ApplyResources(this.btnExportExcel, "btnExportExcel");
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnThoat.Appearance.Font")));
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.KeyCommand = System.Windows.Forms.Keys.F3;
            resources.ApplyResources(this.btnThoat, "btnThoat");
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTim
            // 
            this.btnTim.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnTim.Appearance.Font")));
            this.btnTim.Appearance.Options.UseFont = true;
            this.btnTim.KeyCommand = System.Windows.Forms.Keys.F1;
            resources.ApplyResources(this.btnTim, "btnTim");
            this.btnTim.Name = "btnTim";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // pnOutput
            // 
            this.pnOutput.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            resources.ApplyResources(this.pnOutput, "pnOutput");
            this.pnOutput.Name = "pnOutput";
            // 
            // FrmReportBase
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnOutput);
            this.Controls.Add(this.pnButtons);
            this.Controls.Add(this.pnInputs);
            this.Controls.Add(this.pnTitle);
            this.Name = "FrmReportBase";
            this.Load += new System.EventHandler(this.FrmReportBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnTitle)).EndInit();
            this.pnTitle.ResumeLayout(false);
            this.pnTitle.PerformLayout();
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
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.PanelControl pnInputs;
        protected DevExpress.XtraEditors.LabelControl labelControl2;
        protected Taxi.Controls.Base.Inputs.InputDate ipToDate;
        protected DevExpress.XtraEditors.LabelControl labelControl1;
        protected Taxi.Controls.Base.Inputs.InputDate ipFromDate;
        protected DevExpress.XtraEditors.PanelControl pnButtons;
        protected DevExpress.XtraEditors.LabelControl lbMessage;
        protected Taxi.Controls.Base.Controls.ShButton btnExportExcel;
        protected Taxi.Controls.Base.Controls.ShButton btnThoat;
        protected Taxi.Controls.Base.Controls.ShButton btnTim;
        protected DevExpress.XtraEditors.PanelControl pnOutput;
        public DevExpress.XtraEditors.PanelControl pnTitle;
        public DevExpress.XtraEditors.LabelControl lblTitle;


    }
}