namespace Taxi.GUI
{
    partial class Messenger
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
            this.listMessages2 = new Taxi.Controls.ListMessages();
            this.SuspendLayout();
            // 
            // listMessages2
            // 
            this.listMessages2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMessages2.Location = new System.Drawing.Point(0, 0);
            this.listMessages2.Name = "listMessages2";
            this.listMessages2.Size = new System.Drawing.Size(664, 407);
            this.listMessages2.TabIndex = 1;
            // 
            // Messenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(664, 407);
            this.Controls.Add(this.listMessages2);
            this.Icon = global::TaxiApplication.Properties.Resources.Telephone_01;
            this.MaximizeBox = false;
            this.Name = "Messenger";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tin nhắn";
            this.Load += new System.EventHandler(this.Messenger_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ListMessages listMessages2;



    }
}