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
    public partial class  frmViewBaoCaoCuocGoiDenTuSoDT:Form
    {
        private DataTable dt = new DataTable();
        private bool mIsAdd = false;
        /// <summary>
        /// Get trang thi cua control (add/update)
        /// </summary>
        public bool IsAdd
        {
            get { return mIsAdd; }           
        }

        public  frmViewBaoCaoCuocGoiDenTuSoDT()
        {
            InitializeComponent();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {

            dt = new Business.TimKiem_BaoCao().GetBaoCao_GoiDenTuSoDT(editPhoneNumber.Text.ToString(), dateTuNgay.Value, dateDenNgay.Value);
            gridEX1.DataMember ="CuocGoiKhachLai";
            gridEX1.SetDataBinding(dt, "CuocGoiKhachLai");  
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(dt.Rows.Count <=0)
            {
                new MessageBox.MessageBoxBA  ().Show ("Không có dữ liệu để in");
                return ;
            }
            try
            {
                string FullPathReport = Application.StartupPath;
                FullPathReport += "\\Report\\Baocao_CuocGoiDenTuSoDT.rpt";
                string TuNgay = string.Format ("{0 : HH:mm:ss dd/MM/yyyy}",dateTuNgay.Value );
                string DenNgay = string.Format ("{0 : HH:mm:ss dd/MM/yyyy}",dateDenNgay.Value );
                frmInBaoCao frm = new frmInBaoCao(FullPathReport, dt,editPhoneNumber.Text , TuNgay,DenNgay );
                frm.ShowDialog();
            }
            catch
            { new MessageBox.MessageBoxBA().Show("Lỗi đọc dữ liệu In"); }
        }

    }
}