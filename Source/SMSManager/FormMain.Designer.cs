namespace SMSManager
{
    partial class FormMain
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.date_SendSMS = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoTrip = new System.Windows.Forms.TextBox();
            this.chk_SumTrip = new System.Windows.Forms.CheckBox();
            this.chk_Birthday = new System.Windows.Forms.CheckBox();
            this.chkAutoSendSMS = new System.Windows.Forms.CheckBox();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.pnlBot = new System.Windows.Forms.Panel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSMS_Birthday = new System.Windows.Forms.Button();
            this.btnSMS_Trips = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.RichTextBox();
            this.pnlTop.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.date_SendSMS);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.txtNoTrip);
            this.pnlTop.Controls.Add(this.chk_SumTrip);
            this.pnlTop.Controls.Add(this.chk_Birthday);
            this.pnlTop.Controls.Add(this.chkAutoSendSMS);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(686, 52);
            this.pnlTop.TabIndex = 0;
            // 
            // date_SendSMS
            // 
            this.date_SendSMS.CustomFormat = "HH:mm";
            this.date_SendSMS.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.date_SendSMS.Location = new System.Drawing.Point(212, 3);
            this.date_SendSMS.Name = "date_SendSMS";
            this.date_SendSMS.Size = new System.Drawing.Size(130, 20);
            this.date_SendSMS.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Thời gian gửi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(644, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "cuốc";
            // 
            // txtNoTrip
            // 
            this.txtNoTrip.Location = new System.Drawing.Point(594, 24);
            this.txtNoTrip.Name = "txtNoTrip";
            this.txtNoTrip.Size = new System.Drawing.Size(46, 20);
            this.txtNoTrip.TabIndex = 1;
            // 
            // chk_SumTrip
            // 
            this.chk_SumTrip.AutoSize = true;
            this.chk_SumTrip.Location = new System.Drawing.Point(435, 26);
            this.chk_SumTrip.Name = "chk_SumTrip";
            this.chk_SumTrip.Size = new System.Drawing.Size(158, 17);
            this.chk_SumTrip.TabIndex = 0;
            this.chk_SumTrip.Text = "KH : Tổng số cuốc khách >";
            this.chk_SumTrip.UseVisualStyleBackColor = true;
            // 
            // chk_Birthday
            // 
            this.chk_Birthday.AutoSize = true;
            this.chk_Birthday.Location = new System.Drawing.Point(435, 3);
            this.chk_Birthday.Name = "chk_Birthday";
            this.chk_Birthday.Size = new System.Drawing.Size(150, 17);
            this.chk_Birthday.TabIndex = 0;
            this.chk_Birthday.Text = "KH : Chúc mừng sinh nhật";
            this.chk_Birthday.UseVisualStyleBackColor = true;
            // 
            // chkAutoSendSMS
            // 
            this.chkAutoSendSMS.AutoSize = true;
            this.chkAutoSendSMS.Location = new System.Drawing.Point(3, 6);
            this.chkAutoSendSMS.Name = "chkAutoSendSMS";
            this.chkAutoSendSMS.Size = new System.Drawing.Size(108, 17);
            this.chkAutoSendSMS.TabIndex = 0;
            this.chkAutoSendSMS.Text = "Gửi SMS tự động";
            this.chkAutoSendSMS.UseVisualStyleBackColor = true;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.txtMsg);
            this.pnlCenter.Controls.Add(this.btnSMS_Trips);
            this.pnlCenter.Controls.Add(this.btnSMS_Birthday);
            this.pnlCenter.Controls.Add(this.txtPhoneNumber);
            this.pnlCenter.Controls.Add(this.label4);
            this.pnlCenter.Controls.Add(this.label3);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 52);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(686, 370);
            this.pnlCenter.TabIndex = 1;
            // 
            // pnlBot
            // 
            this.pnlBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBot.Location = new System.Drawing.Point(0, 422);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.Size = new System.Drawing.Size(686, 41);
            this.pnlBot.TabIndex = 0;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(39, 6);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(635, 20);
            this.txtPhoneNumber.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "SĐT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "(Cách nhau bởi dấu chấm phẩy)";
            // 
            // btnSMS_Birthday
            // 
            this.btnSMS_Birthday.Location = new System.Drawing.Point(39, 46);
            this.btnSMS_Birthday.Name = "btnSMS_Birthday";
            this.btnSMS_Birthday.Size = new System.Drawing.Size(122, 23);
            this.btnSMS_Birthday.TabIndex = 3;
            this.btnSMS_Birthday.Text = "Chúc mừng sinh nhật";
            this.btnSMS_Birthday.UseVisualStyleBackColor = true;
            this.btnSMS_Birthday.Click += new System.EventHandler(this.btnSMS_Birthday_Click);
            // 
            // btnSMS_Trips
            // 
            this.btnSMS_Trips.Location = new System.Drawing.Point(168, 46);
            this.btnSMS_Trips.Name = "btnSMS_Trips";
            this.btnSMS_Trips.Size = new System.Drawing.Size(174, 23);
            this.btnSMS_Trips.TabIndex = 4;
            this.btnSMS_Trips.Text = "Cám ơn đã sử dụng dv nhiều";
            this.btnSMS_Trips.UseVisualStyleBackColor = true;
            this.btnSMS_Trips.Click += new System.EventHandler(this.btnSMS_Trips_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(3, 75);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(680, 289);
            this.txtMsg.TabIndex = 5;
            this.txtMsg.Text = "";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 463);
            this.ControlBox = false;
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBot);
            this.Controls.Add(this.pnlTop);
            this.Name = "FormMain";
            this.Text = "SMS Manager";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.pnlCenter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Panel pnlBot;
        private System.Windows.Forms.CheckBox chkAutoSendSMS;
        private System.Windows.Forms.CheckBox chk_SumTrip;
        private System.Windows.Forms.CheckBox chk_Birthday;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoTrip;
        private System.Windows.Forms.DateTimePicker date_SendSMS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSMS_Trips;
        private System.Windows.Forms.Button btnSMS_Birthday;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.RichTextBox txtMsg;
    }
}

