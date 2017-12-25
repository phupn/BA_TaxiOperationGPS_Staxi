using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmKiemTraTrungSoDoiTac : Form
    {
        private List<string> lstDTTrung = new List<string>();
        public frmKiemTraTrungSoDoiTac()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // llay danh sach doi tác
            DoiTac objDT = new DoiTac();
            List<DoiTac> lstDT = new List<DoiTac>();
            lstDT = objDT.GetListOfDoiTacs();
            if ((lstDT != null) && (lstDT.Count > 0))
            {
                string strTemp = "";
                foreach (DoiTac objDoiTac in lstDT)
                {
                    // lay dung so dien thoại của doi tac de so sanh
                    string strTrungSo = GetDoiTacsTrungSo(objDoiTac, lstDT);
                    if (strTrungSo.Length > 0)
                    {                         
                        strTemp += strTrungSo;
                        strTemp += Environment.NewLine + Environment.NewLine + " ";
                    }
                }
                textBox1.Text = strTemp;
            }
           
            if (lstDTTrung.Count > 0)
            {
                string strText = "";
                foreach (string strS in lstDTTrung)
                {
                    strText += strS + Environment.NewLine;
                }
                    
                
                new MessageBox.MessageBoxBA().Show ("Có trùng số giữa các môi giời");

            }
            else new MessageBox.MessageBoxBA().Show("Không có trùng số giữa các môi giới");
        }

        /// <summary>
        /// hàm tra ve ds trung so khong phải la chính minh
        /// </summary>
        /// <param name="objDoiTac"></param>
        /// <param name="lstDT"></param>
        /// <returns></returns>
        private string GetDoiTacsTrungSo(DoiTac  _DoiTac, List<DoiTac> lstDT)
        {
            string strReturn = "";
            string[] arrPhones = _DoiTac.Phones.Split(";".ToCharArray());

            string strPrefix = string.Format("Mã : {0}-- Tên : {1} -- Địa chỉ : {2} -- ĐT : {3} ", _DoiTac.MaDoiTac, _DoiTac.TenCongTy, _DoiTac.Address, _DoiTac.Phones);
            string Temp = "";
            if (arrPhones.Length > 0)
            {

                for (int i = 0; i < arrPhones.Length; i++)
                {
                    string PhoneCall = StringTools.TrimSpace( arrPhones[i].ToString());
                    if (PhoneCall.Length > 6)
                    {
                        foreach (DoiTac objDoiTac in lstDT)
                        {
                            if (objDoiTac.MaDoiTac != _DoiTac.MaDoiTac)
                            {
                                if (objDoiTac.Phones.Contains(PhoneCall))
                                {
                                    Temp += Environment.NewLine  + string.Format("     Mã : {0}-- Tên : {1} -- Địa chỉ : {2} -- ĐT : {3} ", objDoiTac.MaDoiTac, objDoiTac.TenCongTy, objDoiTac.Address, objDoiTac.Phones)  ;
                                }
                            }
                        }
                    }
                }
            }
            if (Temp.Length > 10)
            {
                strReturn = strPrefix + Temp;
            }
            return strReturn;
        }
    }
}