namespace TaxiOperation_DienThoai.CheckCoDuongDai
{
    partial class DSCuocDuongDai_SanBay
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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DSCuocDuongDai_SanBay));
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem1 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem2 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem3 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem4 = new Janus.Windows.EditControls.UIComboBoxItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoHieuXe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grdCuocSanBayDuongDai = new Janus.Windows.GridEX.GridEX();
            this.cbThoiGian = new Janus.Windows.EditControls.UIComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbGara = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdCuocSanBayDuongDai)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số hiệu xe ";
            // 
            // txtSoHieuXe
            // 
            this.txtSoHieuXe.Location = new System.Drawing.Point(192, 58);
            this.txtSoHieuXe.Name = "txtSoHieuXe";
            this.txtSoHieuXe.Size = new System.Drawing.Size(100, 20);
            this.txtSoHieuXe.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(298, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Danh sách các cuốc đường dài sân bay";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(587, 56);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grdCuocSanBayDuongDai
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdCuocSanBayDuongDai.DesignTimeLayout = gridEXLayout1;
            this.grdCuocSanBayDuongDai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCuocSanBayDuongDai.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
            this.grdCuocSanBayDuongDai.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdCuocSanBayDuongDai.GroupByBoxVisible = false;
            this.grdCuocSanBayDuongDai.Location = new System.Drawing.Point(0, 0);
            this.grdCuocSanBayDuongDai.Name = "grdCuocSanBayDuongDai";
            this.grdCuocSanBayDuongDai.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.grdCuocSanBayDuongDai.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdCuocSanBayDuongDai.SaveSettings = false;
            this.grdCuocSanBayDuongDai.Size = new System.Drawing.Size(927, 284);
            this.grdCuocSanBayDuongDai.TabIndex = 5;
            this.grdCuocSanBayDuongDai.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdCuocSanBayDuongDai_FormattingRow);
            this.grdCuocSanBayDuongDai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdCuocSanBayDuongDai_KeyDown);
            this.grdCuocSanBayDuongDai.DoubleClick += new System.EventHandler(this.grdCuocSanBayDuongDai_DoubleClick);
            // 
            // cbThoiGian
            // 
            this.cbThoiGian.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            uiComboBoxItem1.FormatStyle.Alpha = 0;
            uiComboBoxItem1.Text = "1 ngày gần đây";
            uiComboBoxItem1.Value = 1;
            uiComboBoxItem2.FormatStyle.Alpha = 0;
            uiComboBoxItem2.Text = "3 ngày gần đây";
            uiComboBoxItem2.Value = 3;
            uiComboBoxItem3.FormatStyle.Alpha = 0;
            uiComboBoxItem3.Text = "5 ngày gần đây";
            uiComboBoxItem3.Value = 5;
            uiComboBoxItem4.FormatStyle.Alpha = 0;
            uiComboBoxItem4.Text = "15 ngày gần đây";
            uiComboBoxItem4.Value = 15;
            this.cbThoiGian.Items.AddRange(new Janus.Windows.EditControls.UIComboBoxItem[] {
            uiComboBoxItem1,
            uiComboBoxItem2,
            uiComboBoxItem3,
            uiComboBoxItem4});
            this.cbThoiGian.Location = new System.Drawing.Point(439, 58);
            this.cbThoiGian.Name = "cbThoiGian";
            this.cbThoiGian.Size = new System.Drawing.Size(137, 20);
            this.cbThoiGian.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbGara);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbThoiGian);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSoHieuXe);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(927, 84);
            this.panel1.TabIndex = 7;
            // 
            // cbGara
            // 
            this.cbGara.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbGara.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGara.Location = new System.Drawing.Point(297, 58);
            this.cbGara.Margin = new System.Windows.Forms.Padding(4);
            this.cbGara.Name = "cbGara";
            this.cbGara.Size = new System.Drawing.Size(135, 21);
            this.cbGara.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdCuocSanBayDuongDai);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(927, 284);
            this.panel2.TabIndex = 8;
            // 
            // DSCuocDuongDai_SanBay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 368);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = global::TaxiOperation_TongDai_ENVANGVIP.Properties.Resources.Taxi;
            this.Name = "DSCuocDuongDai_SanBay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách các cuốc đường dài sân bay";
            this.Load += new System.EventHandler(this.DSCuocDuongDai_SanBay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCuocSanBayDuongDai)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoHieuXe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private Janus.Windows.GridEX.GridEX grdCuocSanBayDuongDai;
        private Janus.Windows.EditControls.UIComboBox cbThoiGian;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.ComboBox cbGara;
    }
}