namespace Taxi.GUI
{
    public partial class fmXoaDuLieu
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.bnCancel = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.rad60 = new System.Windows.Forms.RadioButton();
            this.rad30 = new System.Windows.Forms.RadioButton();
            this.rad15 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rad5Phut = new System.Windows.Forms.RadioButton();
            this.rad1000Cuoc = new System.Windows.Forms.RadioButton();
            this.rad100Cuoc = new System.Windows.Forms.RadioButton();
            this.rad500Cuoc = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(292, 117);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 0;
            this.bnCancel.Text = "Hủy bỏ";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnXoa.Location = new System.Drawing.Point(103, 117);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(181, 23);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Chuyển về cuốc không xác định";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // rad60
            // 
            this.rad60.AutoSize = true;
            this.rad60.Location = new System.Drawing.Point(28, 54);
            this.rad60.Name = "rad60";
            this.rad60.Size = new System.Drawing.Size(61, 17);
            this.rad60.TabIndex = 2;
            this.rad60.Text = "60 phút";
            this.rad60.UseVisualStyleBackColor = true;
            // 
            // rad30
            // 
            this.rad30.AutoSize = true;
            this.rad30.Checked = true;
            this.rad30.Location = new System.Drawing.Point(105, 54);
            this.rad30.Name = "rad30";
            this.rad30.Size = new System.Drawing.Size(61, 17);
            this.rad30.TabIndex = 3;
            this.rad30.TabStop = true;
            this.rad30.Text = "30 phút";
            this.rad30.UseVisualStyleBackColor = true;
            // 
            // rad15
            // 
            this.rad15.AutoSize = true;
            this.rad15.Location = new System.Drawing.Point(172, 54);
            this.rad15.Name = "rad15";
            this.rad15.Size = new System.Drawing.Size(61, 17);
            this.rad15.TabIndex = 4;
            this.rad15.Text = "15 phút";
            this.rad15.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Chuyển các cuốc chưa xử lý về cuốc không xác định. ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(340, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Thoát các cuốc khách từ số phút về trước. (Chỉ dùng khi đông khách)";
            // 
            // rad5Phut
            // 
            this.rad5Phut.AutoSize = true;
            this.rad5Phut.Location = new System.Drawing.Point(250, 54);
            this.rad5Phut.Name = "rad5Phut";
            this.rad5Phut.Size = new System.Drawing.Size(55, 17);
            this.rad5Phut.TabIndex = 7;
            this.rad5Phut.Text = "5 phút";
            this.rad5Phut.UseVisualStyleBackColor = true;
            // 
            // rad1000Cuoc
            // 
            this.rad1000Cuoc.AutoSize = true;
            this.rad1000Cuoc.Location = new System.Drawing.Point(28, 81);
            this.rad1000Cuoc.Name = "rad1000Cuoc";
            this.rad1000Cuoc.Size = new System.Drawing.Size(150, 17);
            this.rad1000Cuoc.TabIndex = 8;
            this.rad1000Cuoc.Text = "Giữ lại 1000 cuốc gần đây";
            this.rad1000Cuoc.UseVisualStyleBackColor = true;
            // 
            // rad100Cuoc
            // 
            this.rad100Cuoc.AutoSize = true;
            this.rad100Cuoc.ForeColor = System.Drawing.Color.Red;
            this.rad100Cuoc.Location = new System.Drawing.Point(321, 82);
            this.rad100Cuoc.Name = "rad100Cuoc";
            this.rad100Cuoc.Size = new System.Drawing.Size(144, 17);
            this.rad100Cuoc.TabIndex = 9;
            this.rad100Cuoc.Text = "Giữ lại 100 cuốc gần đây";
            this.rad100Cuoc.UseVisualStyleBackColor = true;
            // 
            // rad500Cuoc
            // 
            this.rad500Cuoc.AutoSize = true;
            this.rad500Cuoc.ForeColor = System.Drawing.Color.LightCoral;
            this.rad500Cuoc.Location = new System.Drawing.Point(174, 81);
            this.rad500Cuoc.Name = "rad500Cuoc";
            this.rad500Cuoc.Size = new System.Drawing.Size(144, 17);
            this.rad500Cuoc.TabIndex = 10;
            this.rad500Cuoc.Text = "Giữ lại 500 cuốc gần đây";
            this.rad500Cuoc.UseVisualStyleBackColor = true;
            // 
            // fmXoaDuLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(481, 155);
            this.Controls.Add(this.rad500Cuoc);
            this.Controls.Add(this.rad100Cuoc);
            this.Controls.Add(this.rad1000Cuoc);
            this.Controls.Add(this.rad5Phut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rad15);
            this.Controls.Add(this.rad30);
            this.Controls.Add(this.rad60);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.bnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmXoaDuLieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chuyển cuốc không xác định";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.RadioButton rad60;
        private System.Windows.Forms.RadioButton rad30;
        private System.Windows.Forms.RadioButton rad15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rad5Phut;
        private System.Windows.Forms.RadioButton rad1000Cuoc;
        private System.Windows.Forms.RadioButton rad100Cuoc;
        private System.Windows.Forms.RadioButton rad500Cuoc;

    }
}