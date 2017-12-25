namespace TaxiOperation_BanCo.Controls.GiamSatXe
{
    partial class GiamSatXe_HanhTrinhXe
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grbHanhTrinhXe = new System.Windows.Forms.GroupBox();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.grcHanhTrinhXe = new Taxi.Controls.Base.Controls.ShGridControl();
            this.grvHanhTrinhXe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.lblmsg = new DevExpress.XtraEditors.LabelControl();
            this.txtSoHieu = new DevExpress.XtraEditors.TextEdit();
            this.dateThoiGian = new DevExpress.XtraEditors.DateEdit();
            this.grbHanhTrinhXe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcHanhTrinhXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHanhTrinhXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateThoiGian.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateThoiGian.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grbHanhTrinhXe
            // 
            this.grbHanhTrinhXe.Controls.Add(this.panelControl3);
            this.grbHanhTrinhXe.Controls.Add(this.panelControl2);
            this.grbHanhTrinhXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbHanhTrinhXe.Location = new System.Drawing.Point(0, 0);
            this.grbHanhTrinhXe.Name = "grbHanhTrinhXe";
            this.grbHanhTrinhXe.Size = new System.Drawing.Size(793, 495);
            this.grbHanhTrinhXe.TabIndex = 1;
            this.grbHanhTrinhXe.TabStop = false;
            this.grbHanhTrinhXe.Text = "Hành trình xe";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.grcHanhTrinhXe);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(3, 66);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(787, 426);
            this.panelControl3.TabIndex = 2;
            // 
            // grcHanhTrinhXe
            // 
            this.grcHanhTrinhXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcHanhTrinhXe.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.grcHanhTrinhXe.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.grcHanhTrinhXe.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.grcHanhTrinhXe.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.grcHanhTrinhXe.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.grcHanhTrinhXe.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.grcHanhTrinhXe.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.grcHanhTrinhXe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcHanhTrinhXe.Location = new System.Drawing.Point(2, 2);
            this.grcHanhTrinhXe.MainView = this.grvHanhTrinhXe;
            this.grcHanhTrinhXe.Name = "grcHanhTrinhXe";
            this.grcHanhTrinhXe.Size = new System.Drawing.Size(783, 422);
            this.grcHanhTrinhXe.TabIndex = 0;
            this.grcHanhTrinhXe.UseEmbeddedNavigator = true;
            this.grcHanhTrinhXe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvHanhTrinhXe});
            // 
            // grvHanhTrinhXe
            // 
            this.grvHanhTrinhXe.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvHanhTrinhXe.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvHanhTrinhXe.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvHanhTrinhXe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.grvHanhTrinhXe.GridControl = this.grcHanhTrinhXe;
            this.grvHanhTrinhXe.IndicatorWidth = 30;
            this.grvHanhTrinhXe.Name = "grvHanhTrinhXe";
            this.grvHanhTrinhXe.OptionsBehavior.Editable = false;
            this.grvHanhTrinhXe.OptionsView.ShowGroupPanel = false;
            this.grvHanhTrinhXe.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvHanhTrinhXe_CustomDrawRowIndicator);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Thời điểm";
            this.gridColumn1.DisplayFormat.FormatString = "HH:mm dd/MM";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "ThoiDiem";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.AllowShowHide = false;
            this.gridColumn1.OptionsColumn.AllowSize = false;
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsColumn.ShowInExpressionEditor = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 80;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.Caption = "Lái xe";
            this.gridColumn2.FieldName = "TenNhanVien";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn2.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 110;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Nội dung";
            this.gridColumn3.FieldName = "NoiDung";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 561;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnTimKiem);
            this.panelControl2.Controls.Add(this.lblmsg);
            this.panelControl2.Controls.Add(this.txtSoHieu);
            this.panelControl2.Controls.Add(this.dateThoiGian);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(3, 16);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(787, 50);
            this.panelControl2.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.btnTimKiem.Image = global::Taxi.Controls.Properties.Resources.find16x;
            this.btnTimKiem.Location = new System.Drawing.Point(267, 6);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(26, 26);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // lblmsg
            // 
            this.lblmsg.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsg.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblmsg.Location = new System.Drawing.Point(31, 29);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(0, 19);
            this.lblmsg.TabIndex = 5;
            // 
            // txtSoHieu
            // 
            this.txtSoHieu.Location = new System.Drawing.Point(159, 6);
            this.txtSoHieu.Name = "txtSoHieu";
            this.txtSoHieu.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoHieu.Properties.Appearance.Options.UseFont = true;
            this.txtSoHieu.Properties.MaxLength = 50;
            this.txtSoHieu.Properties.NullText = "Số xe";
            this.txtSoHieu.Properties.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoHieu_Properties_KeyDown);
            this.txtSoHieu.Properties.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoHieu_Properties_KeyPress);
            this.txtSoHieu.Properties.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSoHieu_Properties_KeyUp);
            this.txtSoHieu.Size = new System.Drawing.Size(134, 25);
            this.txtSoHieu.TabIndex = 4;
            this.txtSoHieu.EditValueChanged += new System.EventHandler(this.txtSoHieu_EditValueChanged);
            // 
            // dateThoiGian
            // 
            this.dateThoiGian.EditValue = null;
            this.dateThoiGian.Location = new System.Drawing.Point(31, 6);
            this.dateThoiGian.Name = "dateThoiGian";
            this.dateThoiGian.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateThoiGian.Properties.Appearance.Options.UseFont = true;
            this.dateThoiGian.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateThoiGian.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateThoiGian.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateThoiGian.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateThoiGian.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateThoiGian.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateThoiGian.Properties.NullText = "Chọn ngày";
            this.dateThoiGian.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateThoiGian.Size = new System.Drawing.Size(121, 25);
            this.dateThoiGian.TabIndex = 3;
            // 
            // GiamSatXe_HanhTrinhXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbHanhTrinhXe);
            this.Name = "GiamSatXe_HanhTrinhXe";
            this.Size = new System.Drawing.Size(793, 495);
            this.grbHanhTrinhXe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcHanhTrinhXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHanhTrinhXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoHieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateThoiGian.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateThoiGian.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbHanhTrinhXe;
        private Taxi.Controls.Base.Controls.ShGridControl grcHanhTrinhXe;
        private DevExpress.XtraGrid.Views.Grid.GridView grvHanhTrinhXe;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.TextEdit txtSoHieu;
        private DevExpress.XtraEditors.DateEdit dateThoiGian;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl lblmsg;
        private System.Windows.Forms.Button btnTimKiem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}
