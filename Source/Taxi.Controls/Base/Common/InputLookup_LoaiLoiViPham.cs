using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Controls.Base.Inputs;
using Taxi.Data.FastTaxi;

namespace Taxi.Controls.Base.Common
{
    public class InputLookup_LoaiLoiViPham :InputLookUp<LoaiLoiViPham>
    {
       
        public bool IsVaildateAdd { get; set; }
        protected override bool CheckInputNewValue(bool partial)
        {
            return base.CheckInputNewValue(partial);
        }
        protected override void OnLeave(EventArgs e)
        {
            if (IsVaildateAdd && this.FindItem(this.Text,true,0)==-1)
            {
                string tenloaiLoi = this.Text;
                if (!string.IsNullOrEmpty(tenloaiLoi))
                {
                    var ll = new LoaiLoiViPham() { TenLoaiLoiViPham = tenloaiLoi };
                    ll.Insert();
                    this.Bind();
                    this.SelectedText = tenloaiLoi;
                }
               
            }
            base.OnLeave(e);
        }
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (IsVaildateAdd && e.KeyValue == (int)Keys.Enter && this.FindItem(this.Text, true, 0) == -1)
            {
                string tenloaiLoi = this.Text;
                if (!string.IsNullOrEmpty(tenloaiLoi))
                {
                    var ll = new LoaiLoiViPham() { TenLoaiLoiViPham = tenloaiLoi };
                    ll.Insert();
                    this.Bind();
                    this.SelectedText = tenloaiLoi;
                }
            }
            base.OnKeyDown(e);
        }
    }
}
