namespace WindowsFormsApplication_Test
{
    partial class FormTest
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
            this.txtUDPData = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtLinkUDP = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtLinkCall = new System.Windows.Forms.TextBox();
            this.btnCall = new System.Windows.Forms.Button();
            this.btnSendUDP = new System.Windows.Forms.Button();
            this.txtUDPRawData = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUDPData
            // 
            this.txtUDPData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUDPData.Location = new System.Drawing.Point(3, 16);
            this.txtUDPData.Name = "txtUDPData";
            this.txtUDPData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.txtUDPData.Size = new System.Drawing.Size(819, 336);
            this.txtUDPData.TabIndex = 0;
            this.txtUDPData.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 488);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtUDPData);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(825, 355);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Receive UDP";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSendUDP);
            this.groupBox3.Controls.Add(this.txtUDPRawData);
            this.groupBox3.Controls.Add(this.btnConnect);
            this.groupBox3.Controls.Add(this.txtLinkUDP);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 73);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(825, 60);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Connect UDP";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(180, 17);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtLinkUDP
            // 
            this.txtLinkUDP.Location = new System.Drawing.Point(6, 19);
            this.txtLinkUDP.Name = "txtLinkUDP";
            this.txtLinkUDP.Size = new System.Drawing.Size(168, 20);
            this.txtLinkUDP.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblResult);
            this.groupBox1.Controls.Add(this.txtLinkCall);
            this.groupBox1.Controls.Add(this.btnCall);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(825, 73);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Click to call";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(12, 46);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(43, 13);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "[Result]";
            // 
            // txtLinkCall
            // 
            this.txtLinkCall.Location = new System.Drawing.Point(12, 19);
            this.txtLinkCall.Name = "txtLinkCall";
            this.txtLinkCall.Size = new System.Drawing.Size(726, 20);
            this.txtLinkCall.TabIndex = 0;
            // 
            // btnCall
            // 
            this.btnCall.Location = new System.Drawing.Point(744, 17);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(75, 23);
            this.btnCall.TabIndex = 1;
            this.btnCall.Text = "Call";
            this.btnCall.UseVisualStyleBackColor = true;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // btnSendUDP
            // 
            this.btnSendUDP.Location = new System.Drawing.Point(747, 17);
            this.btnSendUDP.Name = "btnSendUDP";
            this.btnSendUDP.Size = new System.Drawing.Size(75, 23);
            this.btnSendUDP.TabIndex = 1;
            this.btnSendUDP.Text = "Send UDP";
            this.btnSendUDP.UseVisualStyleBackColor = true;
            this.btnSendUDP.Click += new System.EventHandler(this.btnSendUDP_Click);
            // 
            // txtUDPRawData
            // 
            this.txtUDPRawData.Location = new System.Drawing.Point(261, 19);
            this.txtUDPRawData.Name = "txtUDPRawData";
            this.txtUDPRawData.Size = new System.Drawing.Size(477, 20);
            this.txtUDPRawData.TabIndex = 0;
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 488);
            this.Controls.Add(this.panel1);
            this.Name = "FormTest";
            this.Text = "UDP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTest_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTest_FormClosed);
            this.Load += new System.EventHandler(this.FormTest_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtUDPData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtLinkUDP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLinkCall;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnSendUDP;
        private System.Windows.Forms.TextBox txtUDPRawData;
    }
}