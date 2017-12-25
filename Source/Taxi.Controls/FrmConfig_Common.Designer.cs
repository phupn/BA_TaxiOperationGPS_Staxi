namespace Taxi.Controls
{
    partial class FrmConfig_Common
    {
        public FrmConfig_Common()
        {
            InitializeComponent();
        }
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
            this.LayoutControl = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.shLabel1 = new Taxi.Controls.Base.Controls.ShLabel();
            this.shButton1 = new Taxi.Controls.Base.Controls.ShButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.AutoScroll = true;
            this.LayoutControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LayoutControl.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.LayoutControl.ColumnCount = 1;
            this.LayoutControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1299F));
            this.LayoutControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl.Location = new System.Drawing.Point(0, 33);
            this.LayoutControl.Name = "LayoutControl";
            this.LayoutControl.RowCount = 1;
            this.LayoutControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 642F));
            this.LayoutControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 642F));
            this.LayoutControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 642F));
            this.LayoutControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 642F));
            this.LayoutControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 642F));
            this.LayoutControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 642F));
            this.LayoutControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 642F));
            this.LayoutControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 642F));
            this.LayoutControl.Size = new System.Drawing.Size(1299, 632);
            this.LayoutControl.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.shLabel1);
            this.panel1.Controls.Add(this.shButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1299, 33);
            this.panel1.TabIndex = 0;
            // 
            // shLabel1
            // 
            this.shLabel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.shLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.shLabel1.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.shLabel1.Location = new System.Drawing.Point(179, 7);
            this.shLabel1.Name = "shLabel1";
            this.shLabel1.Size = new System.Drawing.Size(378, 19);
            this.shLabel1.TabIndex = 1;
            this.shLabel1.Text = "Lưu ý: Thay đổi sẽ làm ảnh hưởng toàn bộ hệ thống.";
            // 
            // shButton1
            // 
            this.shButton1.KeyCommand = System.Windows.Forms.Keys.F2;
            this.shButton1.Location = new System.Drawing.Point(52, 3);
            this.shButton1.LookAndFeel.SkinName = "Caramel";
            this.shButton1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.shButton1.Name = "shButton1";
            this.shButton1.Size = new System.Drawing.Size(112, 27);
            this.shButton1.TabIndex = 0;
            this.shButton1.Text = "Lưu cấu hình (F2)";
            this.shButton1.Click += new System.EventHandler(this.shButton1_Click);
            // 
            // FrmConfig_Common
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 665);
            this.Controls.Add(this.LayoutControl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmConfig_Common";
            this.ShowIcon = false;
            this.Text = "Quản lý cấu hình chung";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmConfig_Common_FormClosed);
            this.Load += new System.EventHandler(this.FrmConfig_Common_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutControl;
        private System.Windows.Forms.Panel panel1;
        private Base.Controls.ShButton shButton1;
        private Base.Controls.ShLabel shLabel1;
    }
}