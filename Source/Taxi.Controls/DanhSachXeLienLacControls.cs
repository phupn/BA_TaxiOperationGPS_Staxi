using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Taxi.Business ;
using Taxi.Utils;

namespace Taxi.Controls
{
    public partial class DanhSachXeLienLacControls : UserControl
    {
//        Location[1,1] = 5,5  	[1,2] = 65,5
//                  [2,1] = 5,45	[2,2] = 65,45

                //dx = 60
                //dy = 40	
        private List<KiemSoatXeLienLac> mListOfXe = new List<KiemSoatXeLienLac> ();
               
        public DanhSachXeLienLacControls()
        {
            InitializeComponent();
        }
        public delegate void XeLienLacClickHandler(object XeLienLac, XeLienLacEventArgs XeLienLacInfo);
        // The event we publish
        public event XeLienLacClickHandler OnXeLienLacClickHandler;

        public void ViewListXe(KieuMatLienLac viewType, List<KiemSoatXeLienLac> ListOfXe)
        {   

            if (viewType == KieuMatLienLac.XeMatLienLac)
            {
                ViewDSXe(viewType, SapXepXeMatLienLac( GetDSXeMatLienLac(ListOfXe)));
            }
            else if (viewType == KieuMatLienLac.XeXinNghi )
            {
                ViewDSXe(viewType, GetDSXeXinNghi (ListOfXe));
            }
            else if (viewType == KieuMatLienLac.XeDiSanBay )
            {
                ViewDSXe(viewType, GetDSXeDiSanBay (ListOfXe));
            }
            else if (viewType == KieuMatLienLac.XeDiDuongDai )
            {
                ViewDSXe(viewType, GetDSXeDiDuongDai(ListOfXe));
            }
        }
        // sap xep theo thoi gian mat lien lac nho den on
        private List<KiemSoatXeLienLac> SapXepXeMatLienLac(List<KiemSoatXeLienLac> listXeMatLienLac)
        {
             
           // g_lstDienThoai.Sort(delegate(DieuHanhTaxi call1, DieuHanhTaxi call2) { return call2.ThoiDiemGoi.CompareTo(call1.ThoiDiemGoi); });
             listXeMatLienLac.Sort(delegate(KiemSoatXeLienLac xe1, KiemSoatXeLienLac xe2) { return xe1.ThoiDiemBao.CompareTo(xe2.ThoiDiemBao); });
             return listXeMatLienLac;
        }
        private List<KiemSoatXeLienLac> GetDSXeMatLienLac(List<KiemSoatXeLienLac> ListOfXe)
        {
            List<KiemSoatXeLienLac> ListOfXeMatLienLac = new List<KiemSoatXeLienLac>();
            foreach (KiemSoatXeLienLac objKSXe in ListOfXe)
            {
                if (!(objKSXe.TrangThaiLaiXeBao == KieuLaiXeBao.BaoNghi)) // kong phai nghi 
                {
                    if (objKSXe.LoaiChoKhach == LoaiChoKhach.ChoKhachNoiTinh)
                    {

                        if (objKSXe.IsMatLienLac)
                        {
                            ListOfXeMatLienLac.Add(objKSXe);
                        }
                    }
                }
            }
            // sap xep theo thoi gian 
            return ListOfXeMatLienLac;
        }

        private List<KiemSoatXeLienLac> GetDSXeDiSanBay(List<KiemSoatXeLienLac> ListOfXe)
        {
            List<KiemSoatXeLienLac> ListOfXeMatLienLac = new List<KiemSoatXeLienLac>();
            foreach (KiemSoatXeLienLac objKSXe in ListOfXe)
            {
                if (!(objKSXe.TrangThaiLaiXeBao == KieuLaiXeBao.BaoNghi)) // kong phai nghi 
                {
                    if (objKSXe.LoaiChoKhach == LoaiChoKhach.ChoKhachSanBay )
                    {
                       ListOfXeMatLienLac.Add(objKSXe);                     
                    }
                }
            }
            return ListOfXeMatLienLac;
        }

        private List<KiemSoatXeLienLac> GetDSXeDiDuongDai(List<KiemSoatXeLienLac> ListOfXe)
        {
            List<KiemSoatXeLienLac> ListOfXeMatLienLac = new List<KiemSoatXeLienLac>();
            foreach (KiemSoatXeLienLac objKSXe in ListOfXe)
            {
                if (!(objKSXe.TrangThaiLaiXeBao == KieuLaiXeBao.BaoNghi)) // kong phai nghi 
                {
                    if (objKSXe.LoaiChoKhach == LoaiChoKhach.ChoKhachDuongDai )
                    {
                        ListOfXeMatLienLac.Add(objKSXe);
                    }
                }
            }
            return ListOfXeMatLienLac;
        }
        private List<KiemSoatXeLienLac> GetDSXeXinNghi(List<KiemSoatXeLienLac> ListOfXe)
        {
            List<KiemSoatXeLienLac> ListOfXeMatLienLac = new List<KiemSoatXeLienLac>();
            foreach (KiemSoatXeLienLac objKSXe in ListOfXe)
            {
                if (objKSXe.TrangThaiLaiXeBao == KieuLaiXeBao.BaoNghi) //
                {
                   ListOfXeMatLienLac.Add(objKSXe);                  
                }
            }
            return ListOfXeMatLienLac;
        }

        //        Location[1,1] = 5,5  	[1,2] = 65,5
        //                  [2,1] = 5,45	[2,2] = 65,45

        //dx = 60
        //dy = 40
        private void ViewDSXe(KieuMatLienLac viewType,List<KiemSoatXeLienLac> ListOfXe)
        {
            try
            {
                int xStart = 5;
                int yStart = 5;
                int dx = 60;
                int dy = 40;
                int iX = 1;
                int iY = 1;
                int iXeMatLienLac = 0;
                this.panel.Controls.Clear(); // xoa cac xe hien tai
                if (ListOfXe != null)
                {
                    foreach (KiemSoatXeLienLac objKSXe in ListOfXe)
                    {
                        XeLienLacControl ctrlXe = new XeLienLacControl();
                        ctrlXe.SetXeKSLienLac(objKSXe);

                        ctrlXe.OnXeLienLacChangeHandler += new XeLienLacControl.XeLienLacChangeHandler(ctrlXe_OnXeLienLacChangeHandler);

                        ctrlXe.Location = new Point((iX - 1) * dx + xStart, (iY - 1) * 50 + yStart);
                        this.panel.Controls.Add(ctrlXe);
                        if (iX < 9) iX = iX + 1;
                        else
                        {
                            iX = 1;
                            iY = iY + 1;
                        }
                        if (objKSXe.IsMatLienLac) iXeMatLienLac++;
                    }

                    if (viewType == KieuMatLienLac.XeMatLienLac)
                    {
                        this.ground.Text = " Danh sách xe mất liên lạc [" + ListOfXe.Count.ToString() + "]";
                    }
                    else if (viewType == KieuMatLienLac.XeXinNghi)
                    {

                        this.ground.Text = " Danh sách xe xin nghỉ [" + iXeMatLienLac.ToString() + "/" + ListOfXe.Count.ToString() + "]";
                    }
                    else if (viewType == KieuMatLienLac.XeDiSanBay)
                    {

                        this.ground.Text = " Danh sách xe đi sân bay [" + iXeMatLienLac.ToString() + "/" + ListOfXe.Count.ToString() + "]";
                    }
                    else if (viewType == KieuMatLienLac.XeDiDuongDai)
                    {

                        this.ground.Text = " Danh sách xe đi đường dài [" + iXeMatLienLac.ToString() + "/" + ListOfXe.Count.ToString() + "]";
                    }
                }
            }
            catch (Exception ex)
            {
                ////  LogError.WriteLog(" Loi view dach sach xe kiem soat ", ex);
            }
        }

        void ctrlXe_OnXeLienLacChangeHandler(object XeLienLac, XeLienLacEventArgs XeLienLacInfo)
        {
            if (OnXeLienLacClickHandler != null)
            {
                OnXeLienLacClickHandler(this, XeLienLacInfo); 
            }
        }
    }
}
