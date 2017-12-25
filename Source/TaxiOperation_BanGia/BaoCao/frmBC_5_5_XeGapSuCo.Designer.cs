namespace Taxi.GUI.BaoCao
{
    partial class frmBC_5_5_XeGapSuCo
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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBC_5_5_XeGapSuCo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.date_DenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.txtSoXe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridEX = new Janus.Windows.GridEX.GridEX();
            this.gridEXExporter = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblTuNgay);
            this.panel1.Controls.Add(this.date_DenNgay);
            this.panel1.Controls.Add(this.calTuNgay);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Controls.Add(this.txtSoXe);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 106);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Đến ngày";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(158, 47);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(46, 13);
            this.lblTuNgay.TabIndex = 47;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // date_DenNgay
            // 
            this.date_DenNgay.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.date_DenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.date_DenNgay.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.date_DenNgay.DropDownCalendar.Name = "";
            this.date_DenNgay.Location = new System.Drawing.Point(433, 43);
            this.date_DenNgay.Name = "date_DenNgay";
            this.date_DenNgay.Size = new System.Drawing.Size(143, 20);
            this.date_DenNgay.TabIndex = 50;
            this.date_DenNgay.Value = new System.DateTime(2012, 10, 8, 0, 0, 0, 0);
            // 
            // calTuNgay
            // 
            this.calTuNgay.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            this.calTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2008, 10, 1, 0, 0, 0, 0);
            this.calTuNgay.DropDownCalendar.Name = "";
            this.calTuNgay.Location = new System.Drawing.Point(210, 43);
            this.calTuNgay.Name = "calTuNgay";
            this.calTuNgay.Size = new System.Drawing.Size(143, 20);
            this.calTuNgay.TabIndex = 49;
            this.calTuNgay.Value = new System.DateTime(2012, 10, 8, 0, 0, 0, 0);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_TongDai.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(379, 69);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 41;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_TongDai.Properties.Resources.Excel_24x24;
            this.btnExportExcel.Location = new System.Drawing.Point(464, 69);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 42;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // txtSoXe
            // 
            this.txtSoXe.Location = new System.Drawing.Point(210, 69);
            this.txtSoXe.Name = "txtSoXe";
            this.txtSoXe.Size = new System.Drawing.Size(65, 20);
            this.txtSoXe.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Xe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(248, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 22);
            this.label1.TabIndex = 18;
            this.label1.Text = "BÁO CÁO XE GẶP SỰ CỐ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridEX);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(734, 406);
            this.panel2.TabIndex = 1;
            // 
            // gridEX
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridEX.DesignTimeLayout = gridEXLayout1;
            this.gridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridEX.Location = new System.Drawing.Point(0, 0);
            this.gridEX.Name = "gridEX";
            this.gridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX.SaveSettings = false;
            this.gridEX.Size = new System.Drawing.Size(734, 406);
            this.gridEX.TabIndex = 0;
            this.gridEX.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gridEX_FormattingRow);
            // 
            // gridEXExporter
            // 
            this.gridEXExporter.GridEX = this.gridEX;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Excel files|*.xls|All files|*.*";
            // 
            // frmBC_5_5_XeGapSuCo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 512);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBC_5_5_XeGapSuCo";
            this.Text = "Báo cáo xe gặp sự cố";
            this.Load += new System.EventHandler(this.frmBC_5_5_XeGapSuCo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoXe;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.GridEX.GridEX gridEX;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTuNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo date_DenNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo calTuNgay;
    }
}