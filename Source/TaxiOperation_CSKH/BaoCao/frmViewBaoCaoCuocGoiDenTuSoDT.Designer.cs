namespace Taxi.GUI
{
    partial class  frmViewBaoCaoCuocGoiDenTuSoDT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewBaoCaoCuocGoiDenTuSoDT));
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new Janus.Windows.EditControls.UIButton();
            this.dateDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.btnFilter = new Janus.Windows.EditControls.UIButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.label4 = new System.Windows.Forms.Label();
            this.editPhoneNumber = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.editPhoneNumber);
            this.uiGroupBox1.Controls.Add(this.label4);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Controls.Add(this.btnPrint);
            this.uiGroupBox1.Controls.Add(this.dateDenNgay);
            this.uiGroupBox1.Controls.Add(this.label3);
            this.uiGroupBox1.Controls.Add(this.dateTuNgay);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Controls.Add(this.btnCancel);
            this.uiGroupBox1.Controls.Add(this.btnFilter);
            this.uiGroupBox1.ImageAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            this.uiGroupBox1.Location = new System.Drawing.Point(12, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(1017, 204);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "Chọn thông tin cần xem";
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(337, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Thông tin cuộc gọi đến từ số điện thoại";
            // 
            // btnPrint
            // 
           // this.btnPrint.Image = global::TaxiApplication.Properties.Resources.Printer;
            this.btnPrint.Location = new System.Drawing.Point(456, 162);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(97, 32);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = " &In";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dateDenNgay
            // 
            this.dateDenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.DateTime;
            // 
            // 
            // 
            this.dateDenNgay.DropDownCalendar.FirstMonth = new System.DateTime(2008, 8, 1, 0, 0, 0, 0);
            this.dateDenNgay.DropDownCalendar.Name = "";
            this.dateDenNgay.Location = new System.Drawing.Point(443, 121);
            this.dateDenNgay.Name = "dateDenNgay";
            this.dateDenNgay.Size = new System.Drawing.Size(176, 22);
            this.dateDenNgay.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Đến ngày giờ";
            // 
            // dateTuNgay
            // 
            this.dateTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.DateTime;
            // 
            // 
            // 
            this.dateTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2008, 8, 1, 0, 0, 0, 0);
            this.dateTuNgay.DropDownCalendar.Name = "";
            this.dateTuNgay.Location = new System.Drawing.Point(443, 93);
            this.dateTuNgay.Name = "dateTuNgay";
            this.dateTuNgay.Size = new System.Drawing.Size(176, 22);
            this.dateTuNgay.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(354, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Từ ngày giờ";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          //  this.btnCancel.Image = global::TaxiApplication.Properties.Resources.Close;
            this.btnCancel.Location = new System.Drawing.Point(556, 162);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Thoát";
            // 
            // btnFilter
            // 
           // this.btnFilter.Image = global::TaxiApplication.Properties.Resources.Search;
            this.btnFilter.Location = new System.Drawing.Point(342, 162);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(111, 32);
            this.btnFilter.TabIndex = 0;
            this.btnFilter.Text = " &Lọc dữ liệu";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // gridEX1
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEXLayout1;
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.Location = new System.Drawing.Point(12, 210);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.SaveSettings = false;
            this.gridEX1.Size = new System.Drawing.Size(1017, 498);
            this.gridEX1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Số điện thoại";
            // 
            // editPhoneNumber
            // 
            this.editPhoneNumber.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General;
            this.editPhoneNumber.Location = new System.Drawing.Point(443, 58);
            this.editPhoneNumber.Name = "editPhoneNumber";
            this.editPhoneNumber.Size = new System.Drawing.Size(176, 22);
            this.editPhoneNumber.TabIndex = 10;
            this.editPhoneNumber.Text = "0";
            // 
            // frmViewBaoCaoCuocGoiDenTuSoDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 720);
            this.Controls.Add(this.gridEX1);
            this.Controls.Add(this.uiGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmViewBaoCaoCuocGoiDenTuSoDT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem thông tin các cuộc gọi đến từ số";
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.EditControls.UIButton btnCancel;
        private Janus.Windows.EditControls.UIButton btnFilter;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Janus.Windows.CalendarCombo.CalendarCombo dateDenNgay;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.CalendarCombo.CalendarCombo dateTuNgay;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.EditControls.UIButton btnPrint;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.GridEX.EditControls.NumericEditBox editPhoneNumber;
    }
}