namespace TaxiOperation_DienThoai.CheckCoDuongDai
{
    partial class ThongTinSanBay_DuongDai
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
            this.checkCoDuongDai1 = new Taxi.Controls.CheckCoDuongDai();
            this.SuspendLayout();
            // 
            // checkCoDuongDai1
            // 
            this.checkCoDuongDai1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkCoDuongDai1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkCoDuongDai1.Location = new System.Drawing.Point(0, 0);
            this.checkCoDuongDai1.Margin = new System.Windows.Forms.Padding(4);
            this.checkCoDuongDai1.Name = "checkCoDuongDai1";
            this.checkCoDuongDai1.Size = new System.Drawing.Size(504, 432);
            this.checkCoDuongDai1.TabIndex = 0;
            // 
            // ThongTinSanBay_DuongDai
            // 
            this.ClientSize = new System.Drawing.Size(504, 432);
            this.Controls.Add(this.checkCoDuongDai1);
            this.Icon = TaxiApplication.Properties.Resources.Telephone_01;
            this.Name = "ThongTinSanBay_DuongDai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xe đi sân bay đường dài. (Chốt cơ F11, ESC thoát)";
            this.Load += new System.EventHandler(this.ThongTinSanBay_DuongDai_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.CheckCoDuongDai checkCoDuongDai1;

        

       
        
    }
}