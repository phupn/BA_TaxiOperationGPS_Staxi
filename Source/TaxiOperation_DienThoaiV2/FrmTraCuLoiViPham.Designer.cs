namespace TaxiApplication
{
    partial class FrmTraCuLoiViPham
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
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoXe = new Taxi.Controls.Base.Inputs.InputText();
            this.deEnd = new Taxi.Controls.Base.Inputs.InputDate();
            this.btnTimKiem = new Taxi.Controls.Base.Controls.ShButton();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvLoiViPham = new Taxi.Controls.Base.Controls.ShGridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdLoiViPham = new Taxi.Controls.Base.Controls.ShGridControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.deStart = new Taxi.Controls.Base.Inputs.InputDate();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLoiViPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoiViPham)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Ghi chú";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Đến ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Số xe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Từ ngày";
            // 
            // txtSoXe
            // 
            this.txtSoXe.IsChangeText = false;
            this.txtSoXe.IsFocus = false;
            this.txtSoXe.Location = new System.Drawing.Point(100, 38);
            this.txtSoXe.Name = "txtSoXe";
            this.txtSoXe.Properties.MaxLength = 50;
            this.txtSoXe.Size = new System.Drawing.Size(115, 20);
            this.txtSoXe.TabIndex = 2;
            // 
            // deEnd
            // 
            this.deEnd.DateNowWhenLoad = true;
            this.deEnd.EditValue = new System.DateTime(2015, 8, 13, 17, 20, 43, 848);
            this.deEnd.IsChangeText = false;
            this.deEnd.IsFocus = false;
            this.deEnd.Location = new System.Drawing.Point(277, 12);
            this.deEnd.Name = "deEnd";
            this.deEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEnd.Properties.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.deEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deEnd.Properties.EditFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.deEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deEnd.Properties.Mask.EditMask = "HH:mm dd/MM/yyyy";
            this.deEnd.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.deEnd.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
            this.deEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deEnd.Properties.VistaTimeProperties.DisplayFormat.FormatString = "HH:mm";
            this.deEnd.Properties.VistaTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deEnd.Properties.VistaTimeProperties.EditFormat.FormatString = "HH:mm";
            this.deEnd.Properties.VistaTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deEnd.Properties.VistaTimeProperties.Mask.EditMask = "HH:mm";
            this.deEnd.Size = new System.Drawing.Size(112, 20);
            this.deEnd.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.KeyCommand = System.Windows.Forms.Keys.F3;
            this.btnTimKiem.Location = new System.Drawing.Point(441, 9);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Đến ngày";
            this.gridColumn5.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn5.FieldName = "DenNgay";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 150;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Áp dụng từ ngày";
            this.gridColumn4.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn4.FieldName = "TuNgay";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 150;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "Số xe";
            this.gridColumn1.FieldName = "SoXe";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 70;
            // 
            // grvLoiViPham
            // 
            this.grvLoiViPham.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvLoiViPham.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvLoiViPham.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvLoiViPham.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvLoiViPham.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvLoiViPham.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn2,
            this.gridColumn3});
            this.grvLoiViPham.GridControl = this.grdLoiViPham;
            this.grvLoiViPham.IndicatorWidth = 35;
            this.grvLoiViPham.Name = "grvLoiViPham";
            this.grvLoiViPham.OptionsBehavior.Editable = false;
            this.grvLoiViPham.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Loại lỗi vi phạm";
            this.gridColumn2.FieldName = "TenLoaiLoiViPham";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 150;
            // 
            // grdLoiViPham
            // 
            this.grdLoiViPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLoiViPham.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.grdLoiViPham.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.grdLoiViPham.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.grdLoiViPham.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.grdLoiViPham.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.grdLoiViPham.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.grdLoiViPham.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.grdLoiViPham.Location = new System.Drawing.Point(0, 0);
            this.grdLoiViPham.MainView = this.grvLoiViPham;
            this.grdLoiViPham.Name = "grdLoiViPham";
            this.grdLoiViPham.Size = new System.Drawing.Size(609, 403);
            this.grdLoiViPham.TabIndex = 0;
            this.grdLoiViPham.UseEmbeddedNavigator = true;
            this.grdLoiViPham.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLoiViPham});
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdLoiViPham);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(609, 403);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMsg);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSoXe);
            this.panel1.Controls.Add(this.deStart);
            this.panel1.Controls.Add(this.deEnd);
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 61);
            this.panel1.TabIndex = 0;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(277, 40);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 13);
            this.lblMsg.TabIndex = 6;
            // 
            // deStart
            // 
            this.deStart.DateNowWhenLoad = true;
            this.deStart.EditValue = new System.DateTime(2015, 8, 13, 17, 20, 43, 848);
            this.deStart.IsChangeText = false;
            this.deStart.IsFocus = false;
            this.deStart.Location = new System.Drawing.Point(100, 12);
            this.deStart.Name = "deStart";
            this.deStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deStart.Properties.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.deStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deStart.Properties.EditFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.deStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deStart.Properties.Mask.EditMask = "HH:mm dd/MM/yyyy";
            this.deStart.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.deStart.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
            this.deStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deStart.Properties.VistaTimeProperties.DisplayFormat.FormatString = "HH:mm";
            this.deStart.Properties.VistaTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deStart.Properties.VistaTimeProperties.EditFormat.FormatString = "HH:mm";
            this.deStart.Properties.VistaTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deStart.Properties.VistaTimeProperties.Mask.EditMask = "HH:mm";
            this.deStart.Size = new System.Drawing.Size(112, 20);
            this.deStart.TabIndex = 0;
            // 
            // FrmTraCuLoiViPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 464);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmTraCuLoiViPham";
            this.Text = "Tra cứu lỗi vi phạm";
            this.Load += new System.EventHandler(this.FrmTraCuLoiViPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSoXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLoiViPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoiViPham)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Taxi.Controls.Base.Inputs.InputText txtSoXe;
        private Taxi.Controls.Base.Inputs.InputDate deEnd;
        private Taxi.Controls.Base.Controls.ShButton btnTimKiem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private Taxi.Controls.Base.Controls.ShGridView grvLoiViPham;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private Taxi.Controls.Base.Controls.ShGridControl grdLoiViPham;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMsg;
        private Taxi.Controls.Base.Inputs.InputDate deStart;
    }
}