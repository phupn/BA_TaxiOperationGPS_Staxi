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
    public partial class  frmViewBaoCaoCuocGoiTuDoiTac: Form
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

        public  frmViewBaoCaoCuocGoiTuDoiTac()
        {
            InitializeComponent();
        }
        private void frmViewBaoCaoCuocGoiTuDoiTac_Load(object sender, EventArgs e)
        {
            LoadDanhSachDoiTac();
        }

        private void LoadDanhSachDoiTac()
        {
            DoiTac objDoiTac = new DoiTac();
            cboDoiTac.DisplayMember = "Name";
            cboDoiTac.ValueMember = "Ma_DoiTac";
            cboDoiTac.DataSource = objDoiTac.GetListOfDoiTacs().ToArray();   
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {   DoiTac objDT;
            if (cboDoiTac.SelectedItem != null)
            {            
                objDT = (DoiTac)cboDoiTac.SelectedItem.DataRow;             
            }
            else return;


            dt = new Business.TimKiem_BaoCao().GetBaoCaoCuocGoiTuDoiTac(objDT,dateTuNgay.Value, dateDenNgay.Value);  
            gridEX1.DataMember ="CuocGoiCuaDoiTac";
            gridEX1.SetDataBinding(dt, "CuocGoiCuaDoiTac");  
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //DoiTac objDT;
            //if (cboDoiTac.SelectedItem != null)
            //{
            //    objDT = (DoiTac)cboDoiTac.SelectedItem.DataRow;
            //}
            //else return;
            //if(dt.Rows.Count <=0)
            //{
            //    new MessageBox.MessageBox  ().Show ("Không có dữ liệu để in");
            //    return ;
            //}
            //try
            //{
            //    string FullPathReport = Application.StartupPath;
            //    FullPathReport += "\\Report\\Baocao_CuocGoiCuaDoiTac.rpt";
            //    string TuNgay = string.Format ("{0 : HH:mm:ss dd/MM/yyyy}",dateTuNgay.Value );
            //    string DenNgay = string.Format ("{0 : HH:mm:ss dd/MM/yyyy}",dateDenNgay.Value );
            //    frmInBaoCao frm = new frmInBaoCao(FullPathReport, dt,objDT, TuNgay,DenNgay );
            //    frm.ShowDialog(this);
            //}
            //catch
            //{ new MessageBox.MessageBox().Show("Lỗi đọc dữ liệu In"); }
        }

        private void cboDoiTac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDoiTac.SelectedItem !=null )
            {
                DoiTac objDT = new DoiTac();
                objDT = (DoiTac )cboDoiTac.SelectedItem.DataRow;
                lblDiaChi.Text = objDT.Address;
                lblDienThoai.Text = objDT.Phones;
            }

        }

        

    }
}