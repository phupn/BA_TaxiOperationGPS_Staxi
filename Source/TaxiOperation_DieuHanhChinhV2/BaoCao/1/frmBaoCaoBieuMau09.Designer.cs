namespace Taxi.GUI.BaoCao
{
    partial class frmBaoCaoBieuMau09
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCaoBieuMau09));
            this.label1 = new System.Windows.Forms.Label();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.gridCuocGoiMGThang = new Janus.Windows.GridEX.GridEX();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboNhanVien = new Janus.Windows.EditControls.UIComboBox();
            this.intUDTuThang = new Janus.Windows.GridEX.EditControls.IntegerUpDown();
            this.intUDDenThang = new Janus.Windows.GridEX.EditControls.IntegerUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ddlNam = new System.Windows.Forms.ComboBox();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridCuocGoiMGThang)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(318, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO KHÁCH MÔI GIỚI THEO THÁNG";
            // 
            // gridEXExporter1
            // 
            this.gridEXExporter1.GridEX = this.gridCuocGoiMGThang;
            // 
            // gridCuocGoiMGThang
            // 
            this.gridCuocGoiMGThang.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridCuocGoiMGThang.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
            this.gridCuocGoiMGThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.gridCuocGoiMGThang.GroupByBoxVisible = false;
            this.gridCuocGoiMGThang.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            gridEXLayout1.IsCurrentLayout = true;
            gridEXLayout1.Key = "1";
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridCuocGoiMGThang.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gridEXLayout1});
            this.gridCuocGoiMGThang.Location = new System.Drawing.Point(3, 152);
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
            this.gridCuocGoiMGThang.Size = new System.Drawing.Size(1030, 555);
            this.gridCuocGoiMGThang.TabIndex = 38;
            this.gridCuocGoiMGThang.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.gridCuocGoiMGThang.TableSpacing = 8;
            this.gridCuocGoiMGThang.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Từ tháng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(345, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Nhân viên";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboNhanVien.Location = new System.Drawing.Point(407, 71);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(257, 20);
            this.cboNhanVien.TabIndex = 35;
            this.cboNhanVien.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003;
            this.cboNhanVien.SelectedValueChanged += new System.EventHandler(this.cboNhanVien_SelectedValueChanged);
            // 
            // intUDTuThang
            // 
            this.intUDTuThang.Location = new System.Drawing.Point(409, 35);
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
            this.intUDDenThang.Location = new System.Drawing.Point(522, 35);
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
            this.label3.Location = new System.Drawing.Point(460, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Đến tháng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(578, 38);
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
            this.ddlNam.Location = new System.Drawing.Point(613, 34);
            this.ddlNam.Name = "ddlNam";
            this.ddlNam.Size = new System.Drawing.Size(53, 21);
            this.ddlNam.TabIndex = 43;
            this.ddlNam.SelectedValueChanged += new System.EventHandler(this.ddlNam_SelectedValueChanged);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExportExcel.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.Excel;
            this.btnExportExcel.Location = new System.Drawing.Point(531, 97);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(84, 26);
            this.btnExportExcel.TabIndex = 8;
            this.btnExportExcel.Text = "Xuất &Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TaxiOperation_DieuHanhChinh.Properties.Resources.view_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(447, 97);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 26);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "&Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmBaoCaoBieuMau09
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 703);
            this.Controls.Add(this.ddlNam);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.intUDDenThang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.intUDTuThang);
            this.Controls.Add(this.gridCuocGoiMGThang);
            this.Controls.Add(this.cboNhanVien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCaoBieuMau09";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BC 09 - Bao cao khach moi gioi theo thang";
            this.Load += new System.EventHandler(this.frmBaoCaoBieuMau3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCuocGoiMGThang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private Janus.Windows.EditControls.UIButton btnRefresh;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.EditControls.UIComboBox cboNhanVien;
        private Janus.Windows.GridEX.GridEX gridCuocGoiMGThang;
        private Janus.Windows.GridEX.EditControls.IntegerUpDown intUDTuThang;
        private Janus.Windows.GridEX.EditControls.IntegerUpDown intUDDenThang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlNam;
       
    }
}