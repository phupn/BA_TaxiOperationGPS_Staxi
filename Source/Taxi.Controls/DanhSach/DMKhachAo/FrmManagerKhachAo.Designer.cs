namespace Taxi.Controls.DanhSach.DMKhachAo
{
    partial class FrmManagerKhachAo
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
            this.shGridControl1 = new Taxi.Controls.Base.Controls.ShGridControl();
            this.gridView1 = new Taxi.Controls.Base.Controls.ShGridView();
            this.colSoDienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenSoMay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel4 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtDiaChi = new Taxi.Controls.Base.Inputs.InputText();
            this.txtTen = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtSoDienThoai = new Taxi.Controls.Base.Inputs.InputText();
            this.grBTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelInputFind)).BeginInit();
            this.panelInputFind.SuspendLayout();
            this.panelView.SuspendLayout();
            this.panelAction.SuspendLayout();
            this.panelButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoDienThoai.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblMessage.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblMessage.Location = new System.Drawing.Point(269, 38);
            this.lblMessage.Size = new System.Drawing.Size(0, 14);
            this.lblMessage.Text = "";
            // 
            // grBTimKiem
            // 
            this.grBTimKiem.Size = new System.Drawing.Size(522, 100);
            // 
            // panelInputFind
            // 
            this.panelInputFind.Controls.Add(this.shLabel2);
            this.panelInputFind.Controls.Add(this.shLabel4);
            this.panelInputFind.Controls.Add(this.txtDiaChi);
            this.panelInputFind.Controls.Add(this.txtTen);
            this.panelInputFind.Controls.Add(this.shLabel1);
            this.panelInputFind.Controls.Add(this.txtSoDienThoai);
            this.panelInputFind.Size = new System.Drawing.Size(516, 81);
            // 
            // panelView
            // 
            this.panelView.Controls.Add(this.shGridControl1);
            this.panelView.Size = new System.Drawing.Size(522, 195);
            // 
            // panelAction
            // 
            this.panelAction.Size = new System.Drawing.Size(522, 58);
            // 
            // panelButton
            // 
            this.panelButton.Location = new System.Drawing.Point(24, 2);
            // 
            // shGridControl1
            // 
            this.shGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shGridControl1.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.shGridControl1.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.shGridControl1.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.shGridControl1.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.shGridControl1.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.shGridControl1.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.shGridControl1.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.shGridControl1.Location = new System.Drawing.Point(0, 0);
            this.shGridControl1.MainView = this.gridView1;
            this.shGridControl1.Name = "shGridControl1";
            this.shGridControl1.Size = new System.Drawing.Size(522, 195);
            this.shGridControl1.TabIndex = 1;
            this.shGridControl1.UseEmbeddedNavigator = true;
            this.shGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSoDienThoai,
            this.colTenSoMay,
            this.colDiaChi});
            this.gridView1.GridControl = this.shGridControl1;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colSoDienThoai
            // 
            this.colSoDienThoai.AppearanceCell.Options.UseTextOptions = true;
            this.colSoDienThoai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoDienThoai.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSoDienThoai.Caption = "Số điện thoại";
            this.colSoDienThoai.FieldName = "PhoneNumber";
            this.colSoDienThoai.Name = "colSoDienThoai";
            this.colSoDienThoai.OptionsColumn.AllowEdit = false;
            this.colSoDienThoai.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colSoDienThoai.OptionsFilter.AllowAutoFilter = false;
            this.colSoDienThoai.OptionsFilter.AllowFilter = false;
            this.colSoDienThoai.Visible = true;
            this.colSoDienThoai.VisibleIndex = 0;
            this.colSoDienThoai.Width = 89;
            // 
            // colTenSoMay
            // 
            this.colTenSoMay.Caption = "Tên số máy";
            this.colTenSoMay.FieldName = "Name";
            this.colTenSoMay.Name = "colTenSoMay";
            this.colTenSoMay.Visible = true;
            this.colTenSoMay.VisibleIndex = 1;
            this.colTenSoMay.Width = 92;
            // 
            // colDiaChi
            // 
            this.colDiaChi.Caption = "Địa chỉ";
            this.colDiaChi.FieldName = "Address";
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.Visible = true;
            this.colDiaChi.VisibleIndex = 2;
            this.colDiaChi.Width = 216;
            // 
            // shLabel2
            // 
            this.shLabel2.Location = new System.Drawing.Point(347, 27);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(32, 13);
            this.shLabel2.TabIndex = 11;
            this.shLabel2.Text = "Địa chỉ";
            // 
            // shLabel4
            // 
            this.shLabel4.Location = new System.Drawing.Point(214, 27);
            this.shLabel4.Name = "shLabel4";
            this.shLabel4.Size = new System.Drawing.Size(18, 13);
            this.shLabel4.TabIndex = 12;
            this.shLabel4.Text = "Tên";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.IsChangeText = false;
            this.txtDiaChi.IsFocus = false;
            this.txtDiaChi.Location = new System.Drawing.Point(391, 24);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Properties.Mask.EditMask = "[0-9A-Za-z\\-_.,]+";
            this.txtDiaChi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtDiaChi.Properties.MaxLength = 250;
            this.txtDiaChi.Size = new System.Drawing.Size(94, 20);
            this.txtDiaChi.TabIndex = 2;
            this.txtDiaChi.Tag = "Address";
            // 
            // txtTen
            // 
            this.txtTen.IsChangeText = false;
            this.txtTen.IsFocus = false;
            this.txtTen.Location = new System.Drawing.Point(240, 24);
            this.txtTen.Name = "txtTen";
            this.txtTen.Properties.Mask.EditMask = "[0-9A-Za-z\\-_.,]+";
            this.txtTen.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtTen.Properties.MaxLength = 50;
            this.txtTen.Size = new System.Drawing.Size(94, 20);
            this.txtTen.TabIndex = 1;
            this.txtTen.Tag = "Name";
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(32, 27);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(62, 13);
            this.shLabel1.TabIndex = 13;
            this.shLabel1.Text = "Số điện thoại";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.IsChangeText = false;
            this.txtSoDienThoai.IsFocus = false;
            this.txtSoDienThoai.Location = new System.Drawing.Point(102, 24);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Properties.Mask.EditMask = "[0-9]+";
            this.txtSoDienThoai.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSoDienThoai.Properties.MaxLength = 15;
            this.txtSoDienThoai.Size = new System.Drawing.Size(94, 20);
            this.txtSoDienThoai.TabIndex = 0;
            this.txtSoDienThoai.Tag = "PhoneNumber";
            // 
            // FrmManagerKhachAo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 353);
            this.Grid = this.shGridControl1;
            this.Name = "FrmManagerKhachAo";
            this.Text = "Danh sách khách ảo";
            this.grBTimKiem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelInputFind)).EndInit();
            this.panelInputFind.ResumeLayout(false);
            this.panelInputFind.PerformLayout();
            this.panelView.ResumeLayout(false);
            this.panelAction.ResumeLayout(false);
            this.panelAction.PerformLayout();
            this.panelButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoDienThoai.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Controls.ShGridControl shGridControl1;
        private Base.Controls.ShGridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSoDienThoai;
        private DevExpress.XtraGrid.Columns.GridColumn colTenSoMay;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChi;
        private Base.Controls.ShLabel shLabel2;
        private Base.Controls.ShLabel shLabel4;
        private Base.Inputs.InputText txtDiaChi;
        private Base.Inputs.InputText txtTen;
        private Base.Controls.ShLabel shLabel1;
        private Base.Inputs.InputText txtSoDienThoai;
    }
}