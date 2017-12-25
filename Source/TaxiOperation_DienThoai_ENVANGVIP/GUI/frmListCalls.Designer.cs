namespace Taxi.GUI
{
    partial class frmListCalls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListCalls));
            this.gridListCalls = new Janus.Windows.GridEX.GridEX();
            this.btnChon = new Janus.Windows.EditControls.UIButton();
            this.btnDong = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridListCalls)).BeginInit();
            this.SuspendLayout();
            // 
            // gridListCalls
            // 
            this.gridListCalls.AllowCardSizing = false;
            this.gridListCalls.AllowColumnDrag = false;
            this.gridListCalls.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.gridListCalls.DesignTimeLayout = gridEXLayout1;
            this.gridListCalls.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridListCalls.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
            this.gridListCalls.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.gridListCalls.GroupByBoxVisible = false;
            this.gridListCalls.Location = new System.Drawing.Point(0, 0);
            this.gridListCalls.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridListCalls.Name = "gridListCalls";
            this.gridListCalls.SaveSettings = false;
            this.gridListCalls.Size = new System.Drawing.Size(374, 340);
            this.gridListCalls.TabIndex = 1;
            this.gridListCalls.DoubleClick += new System.EventHandler(this.gridEX1_DoubleClick);
            // 
            // btnChon
            // 
            this.btnChon.Image = global::TaxiApplication.Properties.Resources.ExportHTML;
            this.btnChon.Location = new System.Drawing.Point(110, 344);
            this.btnChon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(65, 24);
            this.btnChon.TabIndex = 2;
            this.btnChon.Text = "&Chọn";
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // btnDong
            // 
            this.btnDong.Image = global::TaxiApplication.Properties.Resources.Close;
            this.btnDong.Location = new System.Drawing.Point(180, 344);
            this.btnDong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(63, 24);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "&Thoát";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmListCalls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 372);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.gridListCalls);
            this.Icon = global::TaxiApplication.Properties.Resources.Telephone_01;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListCalls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Các cuộc gọi gần đây";
            this.Load += new System.EventHandler(this.frmListCalls_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmListCalls_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridListCalls)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX gridListCalls;
        private Janus.Windows.EditControls.UIButton btnChon;
        private Janus.Windows.EditControls.UIButton btnDong;
    }
}