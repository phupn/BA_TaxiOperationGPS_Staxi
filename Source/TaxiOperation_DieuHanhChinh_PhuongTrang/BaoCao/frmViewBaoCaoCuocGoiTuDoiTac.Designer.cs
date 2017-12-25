namespace Taxi.GUI
{
    partial class  frmViewBaoCaoCuocGoiTuDoiTac
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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout3 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewBaoCaoCuocGoiTuDoiTac));
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
            this.cboDoiTac = new Janus.Windows.EditControls.UIComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblDienThoai = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.lblDienThoai);
            this.uiGroupBox1.Controls.Add(this.lblDiaChi);
            this.uiGroupBox1.Controls.Add(this.label6);
            this.uiGroupBox1.Controls.Add(this.label5);
            this.uiGroupBox1.Controls.Add(this.cboDoiTac);
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
            this.uiGroupBox1.Size = new System.Drawing.Size(1017, 235);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "Chọn thông tin cần xem";
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(282, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Thông tin sản lượng khách gọi từ điểm môi giới";
            // 
            // btnPrint
            // 
           // this.btnPrint.Image = global::TaxiApplication.Properties.Resources.Printer;
            this.btnPrint.Location = new System.Drawing.Point(453, 179);
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
            this.dateDenNgay.Location = new System.Drawing.Point(572, 40);
            this.dateDenNgay.Name = "dateDenNgay";
            this.dateDenNgay.Size = new System.Drawing.Size(176, 22);
            this.dateDenNgay.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(474, 44);
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
            this.dateTuNgay.Location = new System.Drawing.Point(287, 41);
            this.dateTuNgay.Name = "dateTuNgay";
            this.dateTuNgay.Size = new System.Drawing.Size(176, 22);
            this.dateTuNgay.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Từ ngày giờ";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          //  this.btnCancel.Image = global::TaxiApplication.Properties.Resources.Close;
            this.btnCancel.Location = new System.Drawing.Point(553, 179);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Thoát";
            // 
            // btnFilter
            // 
           // this.btnFilter.Image = global::TaxiApplication.Properties.Resources.Search;
            this.btnFilter.Location = new System.Drawing.Point(339, 179);
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
            gridEXLayout3.LayoutString = resources.GetString("gridEXLayout3.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEXLayout3;
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.Location = new System.Drawing.Point(12, 241);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.SaveSettings = false;
            this.gridEX1.Size = new System.Drawing.Size(1017, 565);
            this.gridEX1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Đối tác";
            // 
            // cboDoiTac
            // 
            this.cboDoiTac.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboDoiTac.Location = new System.Drawing.Point(287, 75);
            this.cboDoiTac.Name = "cboDoiTac";
            this.cboDoiTac.Size = new System.Drawing.Size(461, 22);
            this.cboDoiTac.TabIndex = 10;
            this.cboDoiTac.SelectedIndexChanged += new System.EventHandler(this.cboDoiTac_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Địa chỉ ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(185, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Số điện thoại";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChi.Location = new System.Drawing.Point(284, 108);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(0, 17);
            this.lblDiaChi.TabIndex = 13;
            // 
            // lblDienThoai
            // 
            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDienThoai.Location = new System.Drawing.Point(284, 141);
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Size = new System.Drawing.Size(0, 17);
            this.lblDienThoai.TabIndex = 14;
            // 
            // frmViewBaoCaoCuocGoiTuDoiTac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 812);
            this.Controls.Add(this.gridEX1);
            this.Controls.Add(this.uiGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmViewBaoCaoCuocGoiTuDoiTac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem thông tin sản lượng khách gọi từ điểm môi giới (đối tác)";
            this.Load += new System.EventHandler(this.frmViewBaoCaoCuocGoiTuDoiTac_Load);
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
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Janus.Windows.EditControls.UIComboBox cboDoiTac;
        private System.Windows.Forms.Label label4;
    }
}