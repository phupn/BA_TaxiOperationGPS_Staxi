using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.DM;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmTimKiemXe : Form
    {
        private List<Xe> lstXes = new List<Xe>();
        public frmTimKiemXe()
        {
            InitializeComponent();
        }

        public  List<Xe> GetResultListOfXe()
        {
            return lstXes;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<Xe> lstXe = new List<Xe>();
            lstXe = new Xe().GetListXes();
            if ((lstXe != null) && (lstXe.Count > 0))
            {
                string SoHieuXe = "";
                SoHieuXe = StringTools.TrimSpace(txtThongTinTim.Text);
                //if (SoHieuXe.Length <= 4)
                //{
                    foreach (Xe objXe in lstXe)
                    {
                        if (objXe.SoHieuXe.Contains(SoHieuXe))
                        {
                            lstXes.Add(objXe);
                            continue;
                        }
                        if (objXe.BienKiemSoat.Contains(SoHieuXe))
                        {
                            lstXes.Add(objXe);
                            continue;
                        }
                    }
                //}
                //else
                //{
                    //foreach (Xe objXe in lstXe)
                    //{
                    //    if (objXe.BienKiemSoat.Contains(SoHieuXe))
                    //    {
                    //        lstXes.Add(objXe);
                    //    }
                    //}
                //}


            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtThongTinTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnTimKiem_Click(null, null);
            }
        }
    
    }
}