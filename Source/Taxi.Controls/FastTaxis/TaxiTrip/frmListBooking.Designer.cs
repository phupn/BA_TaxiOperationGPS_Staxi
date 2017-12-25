namespace Taxi.Controls.FastTaxis.TaxiTrip
{
    partial class frmListBooking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListBooking));
            this.shGridControl_Bookings = new Taxi.Controls.Base.Controls.ShGridControl();
            this.gridView_Bookings = new Taxi.Controls.Base.Controls.ShGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThoat = new Taxi.Controls.Base.Controls.ShButton();
            this.btnHuyDieu = new Taxi.Controls.Base.Controls.ShButton();
            this.btnChapNhan = new Taxi.Controls.Base.Controls.ShButton();
            this.timer_ThoiGianXuLy = new System.Windows.Forms.Timer();
            this.shProgressBar1 = new Taxi.Controls.Base.Controls.ShProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.shGridControl_Bookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Bookings)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shProgressBar1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // shGridControl_Bookings
            // 
            this.shGridControl_Bookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shGridControl_Bookings.EmbeddedNavigator.Buttons.First.Hint = "Đầu tiên";
            this.shGridControl_Bookings.EmbeddedNavigator.Buttons.Last.Hint = "Cuối cùng";
            this.shGridControl_Bookings.EmbeddedNavigator.Buttons.Next.Hint = "Kế tiếp";
            this.shGridControl_Bookings.EmbeddedNavigator.Buttons.NextPage.Hint = "Trang tiếp";
            this.shGridControl_Bookings.EmbeddedNavigator.Buttons.Prev.Hint = "Trước đó";
            this.shGridControl_Bookings.EmbeddedNavigator.Buttons.PrevPage.Hint = "Trang trước";
            this.shGridControl_Bookings.EmbeddedNavigator.TextStringFormat = "Dòng thứ {0}/{1}";
            this.shGridControl_Bookings.Location = new System.Drawing.Point(0, 0);
            this.shGridControl_Bookings.MainView = this.gridView_Bookings;
            this.shGridControl_Bookings.Name = "shGridControl_Bookings";
            this.shGridControl_Bookings.Size = new System.Drawing.Size(792, 437);
            this.shGridControl_Bookings.TabIndex = 0;
            this.shGridControl_Bookings.UseEmbeddedNavigator = true;
            this.shGridControl_Bookings.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Bookings});
            // 
            // gridView_Bookings
            // 
            this.gridView_Bookings.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView_Bookings.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView_Bookings.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView_Bookings.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView_Bookings.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView_Bookings.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn8});
            this.gridView_Bookings.GridControl = this.shGridControl_Bookings;
            this.gridView_Bookings.IndicatorWidth = 35;
            this.gridView_Bookings.Name = "gridView_Bookings";
            this.gridView_Bookings.OptionsBehavior.Editable = false;
            this.gridView_Bookings.OptionsView.ShowGroupPanel = false;
            this.gridView_Bookings.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số điện thoại";
            this.gridColumn1.FieldName = "Mobile";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 91;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Từ thời điểm";
            this.gridColumn6.FieldName = "FromTime";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 98;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Đến thời điểm";
            this.gridColumn7.FieldName = "ToTime";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 98;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Điểm đi";
            this.gridColumn2.FieldName = "FromName";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Địa chỉ đi";
            this.gridColumn3.FieldName = "FromAddress";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 196;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Điểm đến";
            this.gridColumn4.FieldName = "ToName";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Địa chỉ đến";
            this.gridColumn5.FieldName = "ToAdress";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 201;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Ghi chú";
            this.gridColumn8.FieldName = "Description";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.shProgressBar1);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnHuyDieu);
            this.panel1.Controls.Add(this.btnChapNhan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 437);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 44);
            this.panel1.TabIndex = 1;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(454, 9);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Thoát (Esc)";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnHuyDieu
            // 
            this.btnHuyDieu.KeyCommand = System.Windows.Forms.Keys.F3;
            this.btnHuyDieu.Location = new System.Drawing.Point(369, 9);
            this.btnHuyDieu.Name = "btnHuyDieu";
            this.btnHuyDieu.Size = new System.Drawing.Size(79, 23);
            this.btnHuyDieu.TabIndex = 1;
            this.btnHuyDieu.Text = "Hủy điều (F3)";
            this.btnHuyDieu.Click += new System.EventHandler(this.btnHuyDieu_Click);
            // 
            // btnChapNhan
            // 
            this.btnChapNhan.Location = new System.Drawing.Point(264, 9);
            this.btnChapNhan.Name = "btnChapNhan";
            this.btnChapNhan.Size = new System.Drawing.Size(99, 23);
            this.btnChapNhan.TabIndex = 0;
            this.btnChapNhan.Text = "Chấp nhận (Enter)";
            this.btnChapNhan.Click += new System.EventHandler(this.btnChapNhan_Click);
            // 
            // timer_ThoiGianXuLy
            // 
            this.timer_ThoiGianXuLy.Interval = 1000;
            this.timer_ThoiGianXuLy.Tick += new System.EventHandler(this.timer_ThoiGianXuLy_Tick);
            // 
            // shProgressBar1
            // 
            this.shProgressBar1.Location = new System.Drawing.Point(45, 9);
            this.shProgressBar1.Name = "shProgressBar1";
            this.shProgressBar1.Properties.Maximum = 300;
            this.shProgressBar1.Properties.PercentView = false;
            this.shProgressBar1.Properties.ShowTitle = true;
            this.shProgressBar1.Properties.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.shProgressBar1_Properties_CustomDisplayText);
            this.shProgressBar1.Size = new System.Drawing.Size(117, 23);
            this.shProgressBar1.TabIndex = 2;
            // 
            // frmListBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 481);
            this.Controls.Add(this.shGridControl_Bookings);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách cuốc khách đề cử cho xe";
            this.Load += new System.EventHandler(this.frmListBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.shGridControl_Bookings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Bookings)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shProgressBar1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Controls.ShGridControl shGridControl_Bookings;
        private Taxi.Controls.Base.Controls.ShGridView gridView_Bookings;
        private System.Windows.Forms.Panel panel1;
        private Base.Controls.ShButton btnThoat;
        private Base.Controls.ShButton btnHuyDieu;
        private Base.Controls.ShButton btnChapNhan;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private System.Windows.Forms.Timer timer_ThoiGianXuLy;
        private Base.Controls.ShProgressBar shProgressBar1;
    }
}