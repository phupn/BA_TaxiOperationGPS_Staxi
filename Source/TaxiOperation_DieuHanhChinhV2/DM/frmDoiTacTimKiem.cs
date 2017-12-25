using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmDoiTacTimKiem : Form
    {
        private   List<DoiTac> mListOfDoiTac = new List<DoiTac>();       
        public frmDoiTacTimKiem()
        {
            InitializeComponent();
        }

        public List<DoiTac> GetResultListOfDoiTac()
        {
            return mListOfDoiTac;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int KieuTimKiem = 0;
                string ThongTinTimKiem = StringTools.TrimSpace(editThongTinTimKiem.Text);
                if (radMaDoiTac.Checked)
                {
                    KieuTimKiem = 1;
                }
                else if (radTenDoiTac.Checked)
                {
                    KieuTimKiem = 2;
                }
                else if (radDienThoại.Checked)
                {
                    KieuTimKiem = 3;
                }
                else if (radDiaChi.Checked)
                {
                    KieuTimKiem = 4;
                }

                mListOfDoiTac = DoiTac.GetDoiTacs_V2(KieuTimKiem, ThongTinTimKiem);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnSave_Click: ",ex);                
            }
        }
    }
}