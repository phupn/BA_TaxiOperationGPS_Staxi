namespace Taxi.GUI
{
    partial class frmDMGara
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMGara));
            this.grdDSGara = new Janus.Windows.GridEX.GridEX();
            this.lnkThemMoi = new System.Windows.Forms.LinkLabel();
            this.lnkSua = new System.Windows.Forms.LinkLabel();
            this.lnkXoa = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdDSGara)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDSGara
            // 
            this.grdDSGara.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.grdDSGara.DesignTimeLayout = gridEXLayout1;
            this.grdDSGara.GroupByBoxVisible = false;
            this.grdDSGara.Location = new System.Drawing.Point(12, 12);
            this.grdDSGara.Name = "grdDSGara";
            this.grdDSGara.SaveSettings = false;
            this.grdDSGara.Size = new System.Drawing.Size(401, 393);
            this.grdDSGara.TabIndex = 0;
            this.grdDSGara.DoubleClick += new System.EventHandler(this.grdDSGara_DoubleClick);
            // 
            // lnkThemMoi
            // 
            this.lnkThemMoi.AutoSize = true;
            this.lnkThemMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkThemMoi.Location = new System.Drawing.Point(272, 418);
            this.lnkThemMoi.Name = "lnkThemMoi";
            this.lnkThemMoi.Size = new System.Drawing.Size(61, 13);
            this.lnkThemMoi.TabIndex = 1;
            this.lnkThemMoi.TabStop = true;
            this.lnkThemMoi.Text = "Thêm mới";
            this.lnkThemMoi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkThemMoi_LinkClicked);
            // 
            // lnkSua
            // 
            this.lnkSua.AutoSize = true;
            this.lnkSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkSua.Location = new System.Drawing.Point(339, 418);
            this.lnkSua.Name = "lnkSua";
            this.lnkSua.Size = new System.Drawing.Size(29, 13);
            this.lnkSua.TabIndex = 2;
            this.lnkSua.TabStop = true;
            this.lnkSua.Text = "Sửa";
            this.lnkSua.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSua_LinkClicked);
            // 
            // lnkXoa
            // 
            this.lnkXoa.AutoSize = true;
            this.lnkXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkXoa.Location = new System.Drawing.Point(374, 418);
            this.lnkXoa.Name = "lnkXoa";
            this.lnkXoa.Size = new System.Drawing.Size(29, 13);
            this.lnkXoa.TabIndex = 3;
            this.lnkXoa.TabStop = true;
            this.lnkXoa.Text = "Xóa";
            this.lnkXoa.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkXoa_LinkClicked);
            // 
            // frmDMGara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 440);
            this.Controls.Add(this.lnkXoa);
            this.Controls.Add(this.lnkSua);
            this.Controls.Add(this.lnkThemMoi);
            this.Controls.Add(this.grdDSGara);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDMGara";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục gara";
            this.Load += new System.EventHandler(this.frmDMGara_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDSGara)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.GridEX.GridEX grdDSGara;
        private System.Windows.Forms.LinkLabel lnkThemMoi;
        private System.Windows.Forms.LinkLabel lnkSua;
        private System.Windows.Forms.LinkLabel lnkXoa;
    }
}