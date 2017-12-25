using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Taxi.Controls.Base.Controls
{
    public class ShProgressPanel : System.Windows.Forms.UserControl 
    {
        private ShPicture shPicture1;
    
        private void InitializeComponent()
        {
            this.shPicture1 = new Taxi.Controls.Base.Controls.ShPicture();
            ((System.ComponentModel.ISupportInitialize)(this.shPicture1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // shPicture1
            // 
            this.shPicture1.EditValue = global::Taxi.Controls.Properties.Resources.wait;
            this.shPicture1.Location = new System.Drawing.Point(-30, -9);
            this.shPicture1.Name = "shPicture1";
            this.shPicture1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.shPicture1.Size = new System.Drawing.Size(136, 80);
            this.shPicture1.TabIndex = 0;
            // 
            // ShProgressPanel
            // 
            this.Controls.Add(this.shPicture1);
            this.Name = "ShProgressPanel";
            this.Size = new System.Drawing.Size(80, 59);
            ((System.ComponentModel.ISupportInitialize)(this.shPicture1.Properties)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
