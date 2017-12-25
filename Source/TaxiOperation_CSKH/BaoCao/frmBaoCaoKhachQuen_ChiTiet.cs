using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using ChartDirector;
using System.IO;
using Taxi.Utils;
using Taxi.Business.DM;

namespace Taxi.GUI.BaoCao
{
    public partial class frmBaoCaoKhachQuen_ChiTiet : Form
    {
        
        DateTime g_TuNgayGio;
        DateTime g_DenNgayGio;
        string g_SoDienThoai;
        
        public frmBaoCaoKhachQuen_ChiTiet(DateTime TuNgayGio, DateTime DenNgayGio, string SoDienThoai)
        {
            g_DenNgayGio = DenNgayGio;
            g_TuNgayGio = TuNgayGio;
            g_SoDienThoai = SoDienThoai;

            InitializeComponent();

        }
        private void frmBaoCaoBieuMau5_Load(object sender, EventArgs e)
        {
            LoadCacCuocGoi();
            label1.Text += " : " + g_SoDienThoai;
        }
         
 
        #region XuLyCacCuocGoi ket thuc



        private void LoadCacCuocGoi()
        {
            try
            {
                
               
                gridEX1.DataMember = "lstKhachHang";
                gridEX1.SetDataBinding(TimKiem_BaoCao.TimKhachHangThanThietBySoDienThoai(g_TuNgayGio,g_DenNgayGio,g_SoDienThoai), "lstKhachHang");
            }
            catch (Exception ex)
            {
                //TimerCapturePhone.Stop();
                // new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình load dữ liệu", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
            }
        }
        #endregion XuLyCacCuocGoi ket thuc

        private void btnThemKhachQuen_Click(object sender, EventArgs e)
        {
            DanhBaKhachQuen dbKhachQuen = new DanhBaKhachQuen(g_SoDienThoai, "", "", new DateTime(2000, 01, 01, 0, 0, 0), "", "", "", false, "", 0, 0);
            using (frmKhachQuen frm = new frmKhachQuen(dbKhachQuen, true))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {

                    dbKhachQuen = frm.GetKhachQuen();
                    //Insert DataBase
                    if (!dbKhachQuen.Insert())
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới khách quen"); 
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Thêm mới khách quen thành công");

                    }
                }
            }
        }  
        
    }
}