namespace Taxi.GUI.BaoCao
{
    partial class frmBaoCaoKhachQuenTheoThang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCaoKhachQuenTheoThang));
            this.label1 = new System.Windows.Forms.Label();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.gridCuocGoiMGThang = new Janus.Windows.GridEX.GridEX();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.intSoChuyen = new Janus.Windows.GridEX.EditControls.IntegerUpDown();
            this.intUDTuThang = new Janus.Windows.GridEX.EditControls.IntegerUpDown();
            this.intUDDenThang = new Janus.Windows.GridEX.EditControls.IntegerUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ddlNam = new System.Windows.Forms.ComboBox();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inputRadioGroup = new Taxi.Controls.Base.Inputs.InputRadioGroup();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiaChi = new Taxi.Controls.Base.Inputs.InputText();
            this.txtTenKH = new Taxi.Controls.Base.Inputs.InputText();
            this.txtSoDienThoai = new Taxi.Controls.Base.Inputs.InputText();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridCuocGoiMGThang)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputRadioGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoDienThoai.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(339, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(493, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO CUỐC GỌI KHÁCH QUEN THEO THÁNG";
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.gridCuocGoiMGThang;
            // 
            // gridCuocGoiMGThang
            // 
            this.gridCuocGoiMGThang.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridCuocGoiMGThang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCuocGoiMGThang.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
            this.gridCuocGoiMGThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.gridCuocGoiMGThang.GroupByBoxVisible = false;
            this.gridCuocGoiMGThang.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            gridEXLayout1.IsCurrentLayout = true;
            gridEXLayout1.Key = "1";
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridCuocGoiMGThang.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gridEXLayout1});
            this.gridCuocGoiMGThang.Location = new System.Drawing.Point(0, 0);
            this.gridCuocGoiMGThang.Name = "gridCuocGoiMGThang";
            this.gridCuocGoiMGThang.PreviewRowFormatStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridCuocGoiMGThang.RowFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.RaisedLight;
            this.gridCuocGoiMGThang.RowFormatStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridCuocGoiMGThang.RowFormatStyle.FontSize = 9F;
            this.gridCuocGoiMGThang.RowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridCuocGoiMGThang.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridCuocGoiMGThang.RowHeaderFormatStyle.Font = new System.Drawing.Font("Tahoma", 6F);
            this.gridCuocGoiMGThang.RowHeaderFormatStyle.FontSize = 10F;
            this.gridCuocGoiMGThang.RowHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridCuocGoiMGThang.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridCuocGoiMGThang.SaveSettings = false;
            this.gridCuocGoiMGThang.Size = new System.Drawing.Size(1032, 484);
            this.gridCuocGoiMGThang.TabIndex = 38;
            this.gridCuocGoiMGThang.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.gridCuocGoiMGThang.TableSpacing = 8;
            this.gridCuocGoiMGThang.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Từ tháng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(531, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Số xe đón chuyến >=";
            this.label5.Visible = false;
            // 
            // intSoChuyen
            // 
            this.intSoChuyen.Location = new System.Drawing.Point(646, 66);
            this.intSoChuyen.Maximum = 10000;
            this.intSoChuyen.Name = "intSoChuyen";
            this.intSoChuyen.Size = new System.Drawing.Size(41, 20);
            this.intSoChuyen.TabIndex = 45;
            this.intSoChuyen.Visible = false;
            this.intSoChuyen.ValueChanged += new System.EventHandler(this.intSoChuyen_ValueChanged);
            this.intSoChuyen.Validating += new System.ComponentModel.CancelEventHandler(this.intSoChuyen_Validating);
            // 
            // intUDTuThang
            // 
            this.intUDTuThang.Location = new System.Drawing.Point(430, 40);
            this.intUDTuThang.Maximum = 12;
            this.intUDTuThang.Minimum = 1;
            this.intUDTuThang.Name = "intUDTuThang";
            this.intUDTuThang.Size = new System.Drawing.Size(41, 20);
            this.intUDTuThang.TabIndex = 39;
            this.intUDTuThang.Value = 1;
            this.intUDTuThang.TextChanged += new System.EventHandler(this.intUDTuThang_TextChanged);
            this.intUDTuThang.Validating += new System.ComponentModel.CancelEventHandler(this.intUDTuThang_Validating);
            // 
            // intUDDenThang
            // 
            this.intUDDenThang.Location = new System.Drawing.Point(543, 40);
            this.intUDDenThang.Maximum = 12;
            this.intUDDenThang.Minimum = 1;
            this.intUDDenThang.Name = "intUDDenThang";
            this.intUDDenThang.Size = new System.Drawing.Size(41, 20);
            this.intUDDenThang.TabIndex = 41;
            this.intUDDenThang.Value = 1;
            this.intUDDenThang.TextChanged += new System.EventHandler(this.intUDDenThang_TextChanged);
            this.intUDDenThang.Validating += new System.ComponentModel.CancelEventHandler(this.intUDDenThang_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(481, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Đến tháng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(599, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Năm";
            // 
            // ddlNam
            // 
            this.ddlNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlNam.FormattingEnabled = true;
            this.ddlNam.Items.AddRange(new object[] {
            " "});
            this.ddlNam.Location = new System.Drawing.Point(634, 39);
            this.ddlNam.Name = "ddlNam";
            this.ddlNam.Size = new System.Drawing.Size(53, 21);
            this.ddlNam.TabIndex = 43;
            this.ddlNam.SelectedValueChanged += new System.EventHandler(this.ddlNam_SelectedValueChanged);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(544, 177);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 49;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(460, 177);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 48;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.inputRadioGroup);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDiaChi);
            this.panel1.Controls.Add(this.txtTenKH);
            this.panel1.Controls.Add(this.txtSoDienThoai);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ddlNam);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Controls.Add(this.intUDDenThang);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.intUDTuThang);
            this.panel1.Controls.Add(this.intSoChuyen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 219);
            this.panel1.TabIndex = 44;
            // 
            // inputRadioGroup
            // 
            this.inputRadioGroup.EditValue = ((short)(0));
            this.inputRadioGroup.IsChangeText = false;
            this.inputRadioGroup.IsFocus = false;
            this.inputRadioGroup.Location = new System.Drawing.Point(460, 144);
            this.inputRadioGroup.Name = "inputRadioGroup";
            this.inputRadioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "Tất cả"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Môi giới"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(2)), "G5")});
            this.inputRadioGroup.Size = new System.Drawing.Size(190, 26);
            this.inputRadioGroup.TabIndex = 50;
            this.inputRadioGroup.SelectedIndexChanged += new System.EventHandler(this.inputRadioGroup_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(378, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Địa chỉ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(374, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Tên KH";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(380, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Số ĐT";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.IsChangeText = false;
            this.txtDiaChi.IsFocus = false;
            this.txtDiaChi.Location = new System.Drawing.Point(425, 118);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(262, 20);
            this.txtDiaChi.TabIndex = 47;
            this.txtDiaChi.Click += new System.EventHandler(this.txtDiaChi_Click);
            // 
            // txtTenKH
            // 
            this.txtTenKH.IsChangeText = false;
            this.txtTenKH.IsFocus = false;
            this.txtTenKH.Location = new System.Drawing.Point(425, 92);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(262, 20);
            this.txtTenKH.TabIndex = 46;
            this.txtTenKH.Click += new System.EventHandler(this.txtTenKH_Click);
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.IsChangeText = false;
            this.txtSoDienThoai.IsFocus = false;
            this.txtSoDienThoai.Location = new System.Drawing.Point(425, 66);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(100, 20);
            this.txtSoDienThoai.TabIndex = 44;
            this.txtSoDienThoai.Click += new System.EventHandler(this.txtSoDienThoai_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridCuocGoiMGThang);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 219);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1032, 484);
            this.panel2.TabIndex = 45;
            // 
            // frmBaoCaoKhachQuenTheoThang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 703);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCaoKhachQuenTheoThang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo cuốc khách quen theo tháng";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuMau3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCuocGoiMGThang)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputRadioGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoDienThoai.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private Janus.Windows.GridEX.EditControls.IntegerUpDown intSoChuyen;
        private Janus.Windows.GridEX.GridEX gridCuocGoiMGThang;
        private Janus.Windows.GridEX.EditControls.IntegerUpDown intUDTuThang;
        private Janus.Windows.GridEX.EditControls.IntegerUpDown intUDDenThang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlNam;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private Controls.Base.Inputs.InputText txtDiaChi;
        private Controls.Base.Inputs.InputText txtTenKH;
        private Controls.Base.Inputs.InputText txtSoDienThoai;
        private Controls.Base.Inputs.InputRadioGroup inputRadioGroup;
       
    }
}