namespace Taxi.GUI
{
    partial class SendMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendMessage));
            this.ctrlSendMessage = new Taxi.Controls.SendMessage();
            this.SuspendLayout();
            // 
            // ctrlSendMessage
            // 
            this.ctrlSendMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlSendMessage.Location = new System.Drawing.Point(0, 0);
            this.ctrlSendMessage.Name = "ctrlSendMessage";
            this.ctrlSendMessage.Size = new System.Drawing.Size(499, 319);
            this.ctrlSendMessage.TabIndex = 0;
            // 
            // SendMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 319);
            this.Controls.Add(this.ctrlSendMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendMessage";
            this.Text = "SendMessage";
            this.Load += new System.EventHandler(this.SendMessage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Taxi.Controls.SendMessage ctrlSendMessage;
    }
}