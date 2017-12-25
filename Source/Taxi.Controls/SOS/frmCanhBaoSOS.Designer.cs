namespace Taxi.Controls.SOS
{
    partial class frmCanhBaoSOS
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grcCanhBaoSOS = new Taxi.Controls.Base.Controls.ShGridControl();
            this.grvCanhBaoSOS = new Taxi.Controls.Base.Controls.ShGridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThoiGianNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoXe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new Taxi.Controls.Base.Controls.Grids.GridColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcCanhBaoSOS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCanhBaoSOS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Image = global::Taxi.Controls.Properties.Resources.ok;
            this.btnAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccept.Location = new System.Drawing.Point(716, 3);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(89, 30);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Đã nhận";
            this.btnAccept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.btnAccept);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(808, 35);
            this.panel3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(37, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(526, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cảnh báo khi lái xe gặp sự cố cần sự trợ giúp của phòng tổng đài";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Taxi.Controls.Properties.Resources.messagebox_warning;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 29);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grcCanhBaoSOS);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 231);
            this.panel1.TabIndex = 5;
            // 
            // grcCanhBaoSOS
            // 
            this.grcCanhBaoSOS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcCanhBaoSOS.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.grcCanhBaoSOS.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.grcCanhBaoSOS.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.grcCanhBaoSOS.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.grcCanhBaoSOS.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.grcCanhBaoSOS.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.grcCanhBaoSOS.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.grcCanhBaoSOS.Location = new System.Drawing.Point(0, 0);
            this.grcCanhBaoSOS.MainView = this.grvCanhBaoSOS;
            this.grcCanhBaoSOS.Name = "grcCanhBaoSOS";
            this.grcCanhBaoSOS.Size = new System.Drawing.Size(808, 231);
            this.grcCanhBaoSOS.TabIndex = 6;
            this.grcCanhBaoSOS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCanhBaoSOS});
            // 
            // grvCanhBaoSOS
            // 
            this.grvCanhBaoSOS.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvCanhBaoSOS.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCanhBaoSOS.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvCanhBaoSOS.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCanhBaoSOS.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCanhBaoSOS.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvCanhBaoSOS.Appearance.Row.Options.UseFont = true;
            this.grvCanhBaoSOS.Appearance.Row.Options.UseTextOptions = true;
            this.grvCanhBaoSOS.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCanhBaoSOS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colNoiDung,
            this.colThoiGianNhan,
            this.colSDT,
            this.colSoXe,
            this.gridColumn1});
            this.grvCanhBaoSOS.GridControl = this.grcCanhBaoSOS;
            this.grvCanhBaoSOS.GroupPanelText = "Kéo cột muốn nhóm vào đây";
            this.grvCanhBaoSOS.IndicatorWidth = 35;
            this.grvCanhBaoSOS.Name = "grvCanhBaoSOS";
            this.grvCanhBaoSOS.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvCanhBaoSOS.OptionsBehavior.Editable = false;
            this.grvCanhBaoSOS.OptionsMenu.EnableFooterMenu = false;
            this.grvCanhBaoSOS.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.Caption = "ID";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colId.OptionsFilter.AllowFilter = false;
            this.colId.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colId.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colId.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colId.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colId.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colNoiDung
            // 
            this.colNoiDung.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNoiDung.AppearanceCell.Options.UseFont = true;
            this.colNoiDung.AppearanceCell.Options.UseTextOptions = true;
            this.colNoiDung.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colNoiDung.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNoiDung.Caption = "Nội dung";
            this.colNoiDung.FieldName = "DiaChi";
            this.colNoiDung.Name = "colNoiDung";
            this.colNoiDung.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colNoiDung.OptionsFilter.AllowAutoFilter = false;
            this.colNoiDung.OptionsFilter.AllowFilter = false;
            this.colNoiDung.Visible = true;
            this.colNoiDung.VisibleIndex = 1;
            this.colNoiDung.Width = 469;
            // 
            // colThoiGianNhan
            // 
            this.colThoiGianNhan.Caption = "Thời điểm";
            this.colThoiGianNhan.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.colThoiGianNhan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colThoiGianNhan.FieldName = "ThoiDiem";
            this.colThoiGianNhan.Name = "colThoiGianNhan";
            this.colThoiGianNhan.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colThoiGianNhan.Visible = true;
            this.colThoiGianNhan.VisibleIndex = 3;
            this.colThoiGianNhan.Width = 92;
            // 
            // colSDT
            // 
            this.colSDT.Caption = "SĐT";
            this.colSDT.FieldName = "PhoneNumber";
            this.colSDT.Name = "colSDT";
            this.colSDT.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colSDT.OptionsFilter.AllowAutoFilter = false;
            this.colSDT.OptionsFilter.AllowFilter = false;
            this.colSDT.Visible = true;
            this.colSDT.VisibleIndex = 2;
            this.colSDT.Width = 138;
            // 
            // colSoXe
            // 
            this.colSoXe.Caption = "Số xe";
            this.colSoXe.FieldName = "SoXe";
            this.colSoXe.Name = "colSoXe";
            this.colSoXe.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colSoXe.Visible = true;
            this.colSoXe.VisibleIndex = 0;
            this.colSoXe.Width = 72;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Trạng thái";
            this.gridColumn1.FieldName = "TrangThai";
            this.gridColumn1.FormatType = Taxi.Controls.Base.Controls.Grids.ColumnFormatType.None;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.TagLanguage = null;
            // 
            // frmCanhBaoSOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 266);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "frmCanhBaoSOS";
            this.Text = "Cảnh báo SOS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCanhBaoSOS_FormClosed);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcCanhBaoSOS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCanhBaoSOS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Base.Controls.ShGridControl grcCanhBaoSOS;
        private Base.Controls.ShGridView grvCanhBaoSOS;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colNoiDung;
        private DevExpress.XtraGrid.Columns.GridColumn colThoiGianNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colSDT;
        private DevExpress.XtraGrid.Columns.GridColumn colSoXe;
        private Base.Controls.Grids.GridColumn gridColumn1;
    }
}