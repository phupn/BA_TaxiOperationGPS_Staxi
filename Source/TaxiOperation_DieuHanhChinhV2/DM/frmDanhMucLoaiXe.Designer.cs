namespace TaxiOperation_DieuHanhChinh.DM
{
    partial class frmDanhMucLoaiXe
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
            this.groupBox = new Taxi.Controls.Base.Controls.ShGroupBox();
            this.gridLoaiXe = new Taxi.Controls.Base.Controls.ShGridControl();
            this.gridViewLoaiXe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.shGroupBox1 = new Taxi.Controls.Base.Controls.ShGroupBox();
            this.lblMessage = new Taxi.Controls.Base.Controls.ShLabel();
            this.btnRefresh = new Taxi.Controls.Base.Controls.ShButton();
            this.btnExit = new Taxi.Controls.Base.Controls.ShButton();
            this.btnSave = new Taxi.Controls.Base.Controls.ShButton();
            this.txtType = new Taxi.Controls.Base.Inputs.InputText();
            this.inputIsActive = new Taxi.Controls.Base.Inputs.InputRadioGroup();
            this.txtOrderBy = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel5 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel4 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shLabel3 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtSeat = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel2 = new Taxi.Controls.Base.Controls.ShLabel();
            this.txtName = new Taxi.Controls.Base.Inputs.InputText();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.panelTop = new Taxi.Controls.Base.Controls.ShPanel();
            this.panelBody = new Taxi.Controls.Base.Controls.ShPanel();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLoaiXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLoaiXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shGroupBox1)).BeginInit();
            this.shGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBody)).BeginInit();
            this.panelBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.gridLoaiXe);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(2, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(567, 231);
            this.groupBox.TabIndex = 0;
            this.groupBox.Text = "Thông tin chi tiết";
            // 
            // gridLoaiXe
            // 
            this.gridLoaiXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLoaiXe.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.gridLoaiXe.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.gridLoaiXe.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.gridLoaiXe.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.gridLoaiXe.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.gridLoaiXe.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.gridLoaiXe.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.gridLoaiXe.Location = new System.Drawing.Point(2, 22);
            this.gridLoaiXe.MainView = this.gridViewLoaiXe;
            this.gridLoaiXe.Name = "gridLoaiXe";
            this.gridLoaiXe.Size = new System.Drawing.Size(563, 207);
            this.gridLoaiXe.TabIndex = 0;
            this.gridLoaiXe.UseEmbeddedNavigator = true;
            this.gridLoaiXe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLoaiXe});
            // 
            // gridViewLoaiXe
            // 
            this.gridViewLoaiXe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col1,
            this.col2,
            this.col3,
            this.col4,
            this.col5,
            this.col6,
            this.col7});
            this.gridViewLoaiXe.GridControl = this.gridLoaiXe;
            this.gridViewLoaiXe.Name = "gridViewLoaiXe";
            this.gridViewLoaiXe.OptionsView.ColumnAutoWidth = false;
            this.gridViewLoaiXe.OptionsView.ShowGroupPanel = false;
            this.gridViewLoaiXe.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewLoaiXe_FocusedRowChanged);
            // 
            // col1
            // 
            this.col1.Caption = "Loại ứng dụng lái xe";
            this.col1.FieldName = "StaxiType";
            this.col1.Name = "col1";
            this.col1.OptionsColumn.AllowEdit = false;
            this.col1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col1.OptionsFilter.AllowFilter = false;
            this.col1.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.col1.Visible = true;
            this.col1.VisibleIndex = 0;
            this.col1.Width = 110;
            // 
            // col2
            // 
            this.col2.Caption = "Tên loại xe";
            this.col2.FieldName = "Name";
            this.col2.Name = "col2";
            this.col2.OptionsColumn.AllowEdit = false;
            this.col2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col2.OptionsFilter.AllowAutoFilter = false;
            this.col2.OptionsFilter.AllowFilter = false;
            this.col2.Visible = true;
            this.col2.VisibleIndex = 1;
            this.col2.Width = 90;
            // 
            // col3
            // 
            this.col3.Caption = "Số chỗ";
            this.col3.FieldName = "Seat";
            this.col3.Name = "col3";
            this.col3.OptionsColumn.AllowEdit = false;
            this.col3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col3.OptionsFilter.AllowAutoFilter = false;
            this.col3.OptionsFilter.AllowFilter = false;
            this.col3.Visible = true;
            this.col3.VisibleIndex = 2;
            // 
            // col4
            // 
            this.col4.Caption = "Trạng thái";
            this.col4.FieldName = "IsActive";
            this.col4.Name = "col4";
            this.col4.OptionsColumn.AllowEdit = false;
            this.col4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col4.OptionsFilter.AllowAutoFilter = false;
            this.col4.OptionsFilter.AllowFilter = false;
            this.col4.Visible = true;
            this.col4.VisibleIndex = 3;
            this.col4.Width = 90;
            // 
            // col5
            // 
            this.col5.Caption = "Loại";
            this.col5.FieldName = "Type";
            this.col5.Name = "col5";
            this.col5.OptionsColumn.AllowEdit = false;
            this.col5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col5.OptionsFilter.AllowAutoFilter = false;
            this.col5.OptionsFilter.AllowFilter = false;
            this.col5.Visible = true;
            this.col5.VisibleIndex = 4;
            // 
            // col6
            // 
            this.col6.Caption = "Thứ tự";
            this.col6.FieldName = "OrderBy";
            this.col6.Name = "col6";
            this.col6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col6.OptionsFilter.AllowAutoFilter = false;
            this.col6.Visible = true;
            this.col6.VisibleIndex = 5;
            // 
            // col7
            // 
            this.col7.Caption = "Thời gian cập nhật";
            this.col7.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.col7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col7.FieldName = "UpdateTime";
            this.col7.Name = "col7";
            this.col7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col7.OptionsFilter.AllowAutoFilter = false;
            this.col7.Visible = true;
            this.col7.VisibleIndex = 6;
            this.col7.Width = 120;
            // 
            // shGroupBox1
            // 
            this.shGroupBox1.Controls.Add(this.lblMessage);
            this.shGroupBox1.Controls.Add(this.btnRefresh);
            this.shGroupBox1.Controls.Add(this.btnExit);
            this.shGroupBox1.Controls.Add(this.btnSave);
            this.shGroupBox1.Controls.Add(this.txtType);
            this.shGroupBox1.Controls.Add(this.inputIsActive);
            this.shGroupBox1.Controls.Add(this.txtOrderBy);
            this.shGroupBox1.Controls.Add(this.shLabel5);
            this.shGroupBox1.Controls.Add(this.shLabel4);
            this.shGroupBox1.Controls.Add(this.shLabel3);
            this.shGroupBox1.Controls.Add(this.txtSeat);
            this.shGroupBox1.Controls.Add(this.shLabel2);
            this.shGroupBox1.Controls.Add(this.txtName);
            this.shGroupBox1.Controls.Add(this.shLabel1);
            this.shGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shGroupBox1.Location = new System.Drawing.Point(2, 2);
            this.shGroupBox1.Name = "shGroupBox1";
            this.shGroupBox1.Size = new System.Drawing.Size(567, 199);
            this.shGroupBox1.TabIndex = 1;
            this.shGroupBox1.Text = "Thông tin loại xe";
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(188, 152);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(29, 13);
            this.lblMessage.TabIndex = 15;
            this.lblMessage.Text = "error";
            this.lblMessage.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(223, 171);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(304, 171);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(142, 171);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtType
            // 
            this.txtType.IsChangeText = false;
            this.txtType.IsFocus = false;
            this.txtType.Location = new System.Drawing.Point(102, 93);
            this.txtType.Name = "txtType";
            this.txtType.Properties.MaxLength = 3;
            this.txtType.Size = new System.Drawing.Size(115, 20);
            this.txtType.TabIndex = 11;
            this.txtType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigital_KeyPress);
            // 
            // inputIsActive
            // 
            this.inputIsActive.EditValue = 0;
            this.inputIsActive.IsChangeText = false;
            this.inputIsActive.IsFocus = false;
            this.inputIsActive.Location = new System.Drawing.Point(102, 60);
            this.inputIsActive.Name = "inputIsActive";
            this.inputIsActive.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.inputIsActive.Properties.Appearance.Options.UseBackColor = true;
            this.inputIsActive.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.inputIsActive.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Hoạt động"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Không hoạt động")});
            this.inputIsActive.Size = new System.Drawing.Size(208, 27);
            this.inputIsActive.TabIndex = 10;
            this.inputIsActive.Tag = "IsActive";
            // 
            // txtOrderBy
            // 
            this.txtOrderBy.IsChangeText = false;
            this.txtOrderBy.IsFocus = false;
            this.txtOrderBy.Location = new System.Drawing.Point(102, 121);
            this.txtOrderBy.Name = "txtOrderBy";
            this.txtOrderBy.Properties.MaxLength = 2;
            this.txtOrderBy.Size = new System.Drawing.Size(115, 20);
            this.txtOrderBy.TabIndex = 9;
            this.txtOrderBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigital_KeyPress);
            // 
            // shLabel5
            // 
            this.shLabel5.Location = new System.Drawing.Point(59, 124);
            this.shLabel5.Name = "shLabel5";
            this.shLabel5.Size = new System.Drawing.Size(37, 13);
            this.shLabel5.TabIndex = 8;
            this.shLabel5.Text = "Thứ tự:";
            // 
            // shLabel4
            // 
            this.shLabel4.Location = new System.Drawing.Point(43, 68);
            this.shLabel4.Name = "shLabel4";
            this.shLabel4.Size = new System.Drawing.Size(53, 13);
            this.shLabel4.TabIndex = 6;
            this.shLabel4.Text = "Trạng thái:";
            // 
            // shLabel3
            // 
            this.shLabel3.Location = new System.Drawing.Point(73, 96);
            this.shLabel3.Name = "shLabel3";
            this.shLabel3.Size = new System.Drawing.Size(23, 13);
            this.shLabel3.TabIndex = 4;
            this.shLabel3.Text = "Loại:";
            // 
            // txtSeat
            // 
            this.txtSeat.IsChangeText = false;
            this.txtSeat.IsFocus = false;
            this.txtSeat.Location = new System.Drawing.Point(272, 93);
            this.txtSeat.Name = "txtSeat";
            this.txtSeat.Properties.MaxLength = 2;
            this.txtSeat.Size = new System.Drawing.Size(115, 20);
            this.txtSeat.TabIndex = 3;
            this.txtSeat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigital_KeyPress);
            // 
            // shLabel2
            // 
            this.shLabel2.Location = new System.Drawing.Point(230, 96);
            this.shLabel2.Name = "shLabel2";
            this.shLabel2.Size = new System.Drawing.Size(36, 13);
            this.shLabel2.TabIndex = 2;
            this.shLabel2.Text = "Số chỗ:";
            // 
            // txtName
            // 
            this.txtName.IsChangeText = false;
            this.txtName.IsFocus = false;
            this.txtName.Location = new System.Drawing.Point(102, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(285, 20);
            this.txtName.TabIndex = 1;
            // 
            // shLabel1
            // 
            this.shLabel1.Location = new System.Drawing.Point(40, 37);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(56, 13);
            this.shLabel1.TabIndex = 0;
            this.shLabel1.Text = "Tên loại xe:";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.shGroupBox1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.LabelMessage = null;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(571, 203);
            this.panelTop.TabIndex = 2;
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.groupBox);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.LabelMessage = null;
            this.panelBody.Location = new System.Drawing.Point(0, 203);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(571, 235);
            this.panelBody.TabIndex = 3;
            // 
            // frmDanhMucLoaiXe
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 438);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelTop);
            this.Name = "frmDanhMucLoaiXe";
            this.Text = "Danh mục loại xe";
            this.Load += new System.EventHandler(this.frmDanhMucLoaiXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLoaiXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLoaiXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shGroupBox1)).EndInit();
            this.shGroupBox1.ResumeLayout(false);
            this.shGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBody)).EndInit();
            this.panelBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.Base.Controls.ShGroupBox groupBox;
        private Taxi.Controls.Base.Controls.ShGroupBox shGroupBox1;
        private Taxi.Controls.Base.Controls.ShPanel panelTop;
        private Taxi.Controls.Base.Controls.ShPanel panelBody;
        private Taxi.Controls.Base.Controls.ShGridControl gridLoaiXe;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLoaiXe;
        private Taxi.Controls.Base.Inputs.InputText txtOrderBy;
        private Taxi.Controls.Base.Controls.ShLabel shLabel5;
        private Taxi.Controls.Base.Controls.ShLabel shLabel4;
        private Taxi.Controls.Base.Controls.ShLabel shLabel3;
        private Taxi.Controls.Base.Inputs.InputText txtSeat;
        private Taxi.Controls.Base.Controls.ShLabel shLabel2;
        private Taxi.Controls.Base.Inputs.InputText txtName;
        private Taxi.Controls.Base.Controls.ShLabel shLabel1;
        private Taxi.Controls.Base.Inputs.InputRadioGroup inputIsActive;
        private Taxi.Controls.Base.Controls.ShButton btnExit;
        private Taxi.Controls.Base.Controls.ShButton btnSave;
        private Taxi.Controls.Base.Inputs.InputText txtType;
        private DevExpress.XtraGrid.Columns.GridColumn col1;
        private DevExpress.XtraGrid.Columns.GridColumn col2;
        private DevExpress.XtraGrid.Columns.GridColumn col3;
        private DevExpress.XtraGrid.Columns.GridColumn col4;
        private DevExpress.XtraGrid.Columns.GridColumn col5;
        private DevExpress.XtraGrid.Columns.GridColumn col6;
        private DevExpress.XtraGrid.Columns.GridColumn col7;
        private Taxi.Controls.Base.Controls.ShButton btnRefresh;
        private Taxi.Controls.Base.Controls.ShLabel lblMessage;
    }
}