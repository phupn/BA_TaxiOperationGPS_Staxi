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
        private List<DoiTac> g_lstDoiTacActive = new List<DoiTac>();
        private List<DoiTac> g_lstDoiTacUnActive = new List<DoiTac>();
        public frmKiemTraTrungSoDoiTac(List<DoiTac> lstDoiTacActive, List<DoiTac> lstDoiTacUnActive)
        {
            InitializeComponent();
            g_lstDoiTacActive = lstDoiTacActive;
            g_lstDoiTacUnActive = lstDoiTacUnActive;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //g_lstDoiTacActive.
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
                    
                
                new MessageBox.MessageBox().Show ("Có trùng số giữa các môi giời");

            }
            else new MessageBox.MessageBox().Show("Không có trùng số giữa các môi giới");
        }


        private void Search()
        {
            string strTempActive = "";
            if ((g_lstDoiTacActive != null) && (g_lstDoiTacActive.Count > 0))
            {                
                foreach (DoiTac objDoiTac in g_lstDoiTacActive)
                {
                    // lay dung so dien thoại của doi tac de so sanh
                    string strTrungSo = searchDetail(objDoiTac, g_lstDoiTacActive);
                    if (strTrungSo.Length > 0)
                    {
                        strTempActive += strTrungSo;
                        strTempActive += Environment.NewLine + Environment.NewLine + " ";
                    }
                }
                
            }
            string strTempUnActive = "";
            if ((g_lstDoiTacUnActive != null) && (g_lstDoiTacUnActive.Count > 0))
            {
                
                foreach (DoiTac objDoiTac in g_lstDoiTacUnActive)
                {
                    // lay dung so dien thoại của doi tac de so sanh
                    string strTrungSo = searchDetail(objDoiTac, g_lstDoiTacUnActive);
                    if (strTrungSo.Length > 0)
                    {
                        strTempUnActive += strTrungSo;
                        strTempUnActive += Environment.NewLine + Environment.NewLine + " ";
                    }
                }

            }

            textBox1.Text = strTempActive + strTempUnActive;
        }

        private string searchDetail(DoiTac _DoiTac, List<DoiTac> lstDT)
        {
            string strReturn = "";
            string[] arrPhones = _DoiTac.Phones.Split(';');

            string strPrefix = string.Format("Mã : {0}-- Tên : {1} -- Địa chỉ : {2} -- ĐT : {3} ", _DoiTac.MaDoiTac, _DoiTac.TenCongTy, _DoiTac.Address, _DoiTac.Phones);
            string Temp = "";
            if (arrPhones.Length > 0)
            {
                List<DoiTac> listDoiTac = new List<DoiTac>();
                for (int i = 0; i < arrPhones.Length; i++)
                {
                    string PhoneCall = StringTools.TrimSpace(arrPhones[i]);
                    if (PhoneCall.Length > 6)
                    {
                        listDoiTac = lstDT.FindAll(doitac => doitac.Phones == PhoneCall && doitac.MaDoiTac != _DoiTac.MaDoiTac);

                        foreach (DoiTac objDoiTac in listDoiTac)
                        {
                            Temp += Environment.NewLine + string.Format("     Mã : {0}-- Tên : {1} -- Địa chỉ : {2} -- ĐT : {3} ", objDoiTac.MaDoiTac, objDoiTac.TenCongTy, objDoiTac.Address, objDoiTac.Phones);
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