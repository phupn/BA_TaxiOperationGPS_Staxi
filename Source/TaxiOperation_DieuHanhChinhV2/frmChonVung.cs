using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taxi.GUI
{
    public partial class frmChonVung : Form
    {
        /// <summary>
        /// vùng có dang dữ liệu truyền vào là 1,2,3,4,5,6,7,8,9
        /// 
        /// 9 : chọn ban tin ban giá
        /// </summary>
        private string _VungChon;

        public string VungChon
        {
            get { return _VungChon; }
            set { _VungChon = value; }
        }

        public frmChonVung()
        {
            InitializeComponent();
        }
        public frmChonVung(string ChonVung)
        {
            InitializeComponent();
            this._VungChon = ChonVung;
        }
        private void frmChonVung_Load(object sender, EventArgs e)
        {
            KhoiTacVung();
            SetThongTinVungChon();
        }

        /// <summary>
        /// hàm thực hiện set thông tin vùng chọn
        /// </summary>
        private void SetThongTinVungChon(   )
        {
            if (this.VungChon != null && this.VungChon.Length > 0)
            {
                // phân tích ra mảng
                string[] arrVung = this.VungChon.Split(",".ToCharArray());
                if (arrVung.Length > 0)
                {
                    for (int i = 0; i < arrVung.Length; i++)
                    {
                        SetVungChon(arrVung[i]);
                    }
                }
            }
        }

        public string GetVungChon()
        {
            string strVung = "";
            if (chkVung1.Checked) strVung += "1,";
            if (chkVung2.Checked) strVung += "2,";
            if (chkVung3.Checked) strVung += "3,";
            if (chkVung4.Checked) strVung += "4,";
            if (chkVung5.Checked) strVung += "5,";
            if (chkVung6.Checked) strVung += "6,";
            if (chkVung7.Checked) strVung += "7,";
            if (chkVung8.Checked) strVung += "8,";
            if (chkVung9.Checked) strVung += "9,10";

            if (strVung.EndsWith(",")) strVung = strVung.Substring(0,strVung.Length - 1);
            this.VungChon = strVung;
            return strVung ;
        }

        /// <summary>
        /// set vùng lên checkbox
        /// </summary>
        /// <param name="p"></param>
        private void SetVungChon(string Vung)
        {
            if (Vung != null && Vung.Length > 0)
            {
                switch( Vung)
                {
                    case   "1" :  
                        chkVung1.Checked = true; break;
                    case "2" :
                        chkVung2.Checked = true; break;
                    case "3":
                        chkVung3.Checked = true; break;
                    case "4":
                        chkVung4.Checked = true; break;
                    case "5":
                        chkVung5.Checked = true; break;
                    case "6":
                        chkVung6.Checked = true; break;
                    case "7":
                        chkVung7.Checked = true; break;
                    case "8":
                        chkVung8.Checked = true; break;
                    case "9":
                        chkVung9.Checked = true; break;
                     
                }

            }
        }
        /// <summary>
        /// khoi tạo thông tin vùng
        /// </summary>
        private void KhoiTacVung()
        {
            chkVung1.Checked = false;
            chkVung2.Checked = false;
            chkVung3.Checked = false;
            chkVung4.Checked = false;
            chkVung5.Checked = false;
            chkVung6.Checked = false;
            chkVung7.Checked = false;
            chkVung8.Checked = false;
            chkVung9.Checked = false;            
             
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnChonXem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; 
            this.Close();
        }

               
    }
}