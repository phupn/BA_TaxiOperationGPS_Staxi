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
using Janus.Windows.GridEX;

namespace Taxi.GUI 
{
    public partial class frmBaoCaoBieuMau15 : Form
    {
        /// <summary>
        /// báo cáo xe mat lien lac với tỏng đài
        /// </summary>
        public class BaoCao15
        {
            private string mSoHieuXe;  //120

            public string SoHieuXe
            {
                get { return mSoHieuXe; }
                set { mSoHieuXe = value; }
            }
            private string mTenLaiXe;  //Tuan

            public string TenLaiXe
            {
                get { return mTenLaiXe; }
                set { mTenLaiXe = value; }
            }
            private string mKhoangMatLienLac; // 15h-17h

            public string KhoangMatLienLac
            {
                get { return mKhoangMatLienLac; }
                set { mKhoangMatLienLac = value; }
            }
            private string mThoiDiemDaiGoi; //15:05, 16:40

            public string ThoiDiemDaiGoi
            {
                get { return mThoiDiemDaiGoi; }
                set { mThoiDiemDaiGoi = value; }
            }
            private string mGhiChu; // baos nghỉ 14:00

            public string GhiChu
            {
                get { return mGhiChu; }
                set { mGhiChu = value; }
            }
            public BaoCao15()
            {   
                mSoHieuXe = "";
                mTenLaiXe = "";
                mThoiDiemDaiGoi = "";
                mGhiChu = "";
                mKhoangMatLienLac = "";

            }
            public BaoCao15(string _SoHieuXe, string _TenLaiXe, string _KhoangMatLienLac, string _ThoiDiemDaiGoi, string _GhiChu)
            {
                this.SoHieuXe = _SoHieuXe;
                this.TenLaiXe = _TenLaiXe;
                this.KhoangMatLienLac = _KhoangMatLienLac;
                this.ThoiDiemDaiGoi = _ThoiDiemDaiGoi;
                this.GhiChu = _GhiChu;
            }
        }

        private List<BaoCao15> g_ListItemBC15 = new List<BaoCao15>();

        private fmProgress m_fmProgress = null;
        public frmBaoCaoBieuMau15()
        {
            InitializeComponent();
          
        }

        
        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
           // btnPrint.Enabled = btnRefresh.Enabled;
            btnExportExcel.Enabled = btnRefresh.Enabled;
            //LoadDuLieuCuocGoiDenTuPhanCung_VoiceFile();

        }

        /// <summary>
        /// hàm sẽ trả về thông tin maats liên lạc của xe
        ///   - nếu mất liên lạc thì giá trị trả về khách null
        ///   - nếu có HasTôngDàicheck = true thì lưu lại vào objOld để cho vòng lặp sau
        /// 
        /// </summary>
        /// <param name="objOld"></param>
        /// <param name="TrangThaiXe1"></param>
        /// <param name="TrangThaiXe2"></param>
        /// <param name="HasTongDaiCheck"></param>
        /// <returns></returns>
        private BaoCao15 XacDinhMatLienLacCuaXe(KiemSoatXeLienLac TrangThaiXe1, KiemSoatXeLienLac TrangThaiXe2)
        {            
            string KhoangMatLienLac ="";
            string TongDaiCheck ="";
            string GhiChu = "";
           
               
            if(TrangThaiXe1.SoHieuXe !=TrangThaiXe2.SoHieuXe  ) return null;
            
            if(TrangThaiXe2.TrangThaiLaiXeBao==Taxi.Utils.KieuLaiXeBao.BaoRaHoatDong) return null; // thời đỉem trước đó là về không cần xét

            TimeSpan timeSpan = TrangThaiXe2.ThoiDiemBao - TrangThaiXe1.ThoiDiemBao;

            if ((TrangThaiXe2.TrangThaiLaiXeBao!=Taxi.Utils.KieuLaiXeBao.TongDaiCheck) && ( timeSpan.TotalMinutes < ThongTinCauHinh.SoPhutGioiHanMatLienLac)) return null;
            else // có dấu hiệu mất liên lạc
            {                    
                // Khach duong dai 
               if(TrangThaiXe1.LoaiChoKhach ==Taxi.Utils.LoaiChoKhach.ChoKhachDuongDai)
               {
                   if (timeSpan.TotalMinutes >= ThongTinCauHinh.SoPhutGioiHanMatLienLacBaoDiDuongDai) //  mât liên lạc
                    {
                        KhoangMatLienLac = string.Format("{0: HH:mm}h", TrangThaiXe1.ThoiDiemBao.Add(new TimeSpan(0, ThongTinCauHinh.SoPhutGioiHanMatLienLacBaoDiDuongDai, 0))) + string.Format("-{0: HH:mm}h ngày {1:dd/MM}", TrangThaiXe2.ThoiDiemBao, TrangThaiXe2.ThoiDiemBao);
                    }
                }
                //  báo cho khach di san bay
                else   if(TrangThaiXe1.LoaiChoKhach ==Taxi.Utils.LoaiChoKhach.ChoKhachSanBay)
                {
                    if (timeSpan.TotalMinutes >= ThongTinCauHinh.SoPhutGioiHanMatLienLacBaoDiSanBay) //  mât liên lạc
                    {
                        KhoangMatLienLac = string.Format("{0: HH:mm}h", TrangThaiXe1.ThoiDiemBao.Add(new TimeSpan(0, ThongTinCauHinh.SoPhutGioiHanMatLienLacBaoDiSanBay, 0))) + string.Format("-{0: HH:mm}h ngày {1:dd/MM}", TrangThaiXe2.ThoiDiemBao, TrangThaiXe2.ThoiDiemBao);
                    }
                }
                else    
                {
                    if (TrangThaiXe1.TrangThaiLaiXeBao == Taxi.Utils.KieuLaiXeBao.BaoNghi)
                    {
                        if (timeSpan.TotalMinutes >= ThongTinCauHinh.SoPhutGioiHanMatLienLacBaoNghi)
                        {
                            KhoangMatLienLac = string.Format("{0: HH:mm}h", TrangThaiXe1.ThoiDiemBao.Add(new TimeSpan(0, ThongTinCauHinh.SoPhutGioiHanMatLienLacBaoNghi, 0))) + string.Format("-{0: HH:mm}h ngày {1:dd/MM}", TrangThaiXe2.ThoiDiemBao, TrangThaiXe2.ThoiDiemBao);
                        }
                    }
                    else
                    {
                        if ((timeSpan.TotalMinutes >= ThongTinCauHinh.SoPhutGioiHanMatLienLac) || (TrangThaiXe2.TrangThaiLaiXeBao == Taxi.Utils.KieuLaiXeBao.TongDaiCheck))
                        {
                            if (TrangThaiXe2.TrangThaiLaiXeBao != Taxi.Utils.KieuLaiXeBao.TongDaiCheck)
                            {
                                DateTime temp = TrangThaiXe1.ThoiDiemBao.Add(new TimeSpan(0, ThongTinCauHinh.SoPhutGioiHanMatLienLac, 0));
                                KhoangMatLienLac = string.Format("{0: HH:mm }h", temp);
                                KhoangMatLienLac += string.Format("-{0: HH:mm}h ngày {1:dd/MM}", TrangThaiXe2.ThoiDiemBao, TrangThaiXe2.ThoiDiemBao);
                            }
                            else
                            {
                               
                                KhoangMatLienLac = string.Format("{0: HH:mm }h", TrangThaiXe1.ThoiDiemBao);
                                KhoangMatLienLac += string.Format("-{0: HH:mm}h ngày {1:dd/MM}", TrangThaiXe2.ThoiDiemBao, TrangThaiXe2.ThoiDiemBao);
               
                            }
                        }
                    }
                }

          }
          if (TrangThaiXe2.TrangThaiLaiXeBao == Taxi.Utils.KieuLaiXeBao.TongDaiCheck)
          { TongDaiCheck = string.Format("{0: HH:mm}h", TrangThaiXe2.ThoiDiemBao);   }
          
          GhiChu =  GetGhiChu(TrangThaiXe1);


         BaoCao15 objBC15 = new BaoCao15 ();
         objBC15.SoHieuXe = TrangThaiXe1.SoHieuXe;             
         objBC15.KhoangMatLienLac = KhoangMatLienLac;
         objBC15.TenLaiXe = TrangThaiXe1.MaLaiXe;
         objBC15.ThoiDiemDaiGoi =   TongDaiCheck;
         
         objBC15.GhiChu = GhiChu;

         if (((objBC15.GhiChu.Length <= 0) || (objBC15.KhoangMatLienLac.Length <= 0)) && (objBC15.ThoiDiemDaiGoi.Length <= 0)) return null;

         return objBC15;

          
         
        }

        /// <summary>
        /// trả về trạng thái ghi chú 
        /// </summary>
        /// <param name="TrangThaiXe1"></param>
        /// <returns></returns>
        private string GetGhiChu(KiemSoatXeLienLac TrangThaiXe1)
        {
            string GhiChu = "";
            if(TrangThaiXe1.TrangThaiLaiXeBao ==Taxi.Utils.KieuLaiXeBao.BaoRaHoatDong)
                GhiChu = string.Format("Báo ra hoạt động: {0:HH:mm}h",TrangThaiXe1.ThoiDiemBao);
             else if(TrangThaiXe1.TrangThaiLaiXeBao ==Taxi.Utils.KieuLaiXeBao.BaoDiemDo)
                GhiChu = string.Format("Báo điểm đỗ: {0:HH:mm}h",TrangThaiXe1.ThoiDiemBao);
            else if(TrangThaiXe1.TrangThaiLaiXeBao ==Taxi.Utils.KieuLaiXeBao.BaoNghi)
                GhiChu = string.Format("Báo nghỉ: {0:HH:mm}h",TrangThaiXe1.ThoiDiemBao);
            else if(TrangThaiXe1.TrangThaiLaiXeBao ==Taxi.Utils.KieuLaiXeBao.BaoNghi_RoiXe)
                GhiChu = string.Format("Nhận điểm trung tâm: {0:HH:mm}h",TrangThaiXe1.ThoiDiemBao);
            else if(TrangThaiXe1.TrangThaiLaiXeBao ==Taxi.Utils.KieuLaiXeBao.BaoDiemCuaTrungTam_DCTraKhach)
                GhiChu = string.Format("Báo trả khách trung tâm: {0:HH:mm}h",TrangThaiXe1.ThoiDiemBao);
            else if (TrangThaiXe1.TrangThaiLaiXeBao == Taxi.Utils.KieuLaiXeBao.TongDaiCheck)
                GhiChu = string.Format("Tổng đài gọi: {0:HH:mm}h", TrangThaiXe1.ThoiDiemBao);

            return GhiChu; 
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {

            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
             {
                 List<KiemSoatXeLienLac> ListSuKienCuaXe = KiemSoatXeLienLac.GetBaoCaoMatLienLac( calTuNgay.Value, calDenNgay.Value);

                 if ((ListSuKienCuaXe != null) && (ListSuKienCuaXe.Count > 1))
                 { 
                      
                     int iLen = ListSuKienCuaXe.Count;

                     BaoCao15 objBC15;
                     BaoCao15 objBC15LLTongDai = new BaoCao15(); 
                     for(int i =0; i<iLen-1; i++)
                     {

                         objBC15 = XacDinhMatLienLacCuaXe( ListSuKienCuaXe[i], ListSuKienCuaXe[i + 1] ); 
                         
                         if (objBC15 != null)
                         {
                             if (objBC15.ThoiDiemDaiGoi.Length > 0) // co thong tin dai goi
                             {
                                 if (objBC15LLTongDai.ThoiDiemDaiGoi.Length <= 0) // chua khoi tao du lieu tong dai goi
                                 {

                                     objBC15LLTongDai.KhoangMatLienLac = objBC15.KhoangMatLienLac;
                                     objBC15LLTongDai.SoHieuXe = objBC15.SoHieuXe;
                                     objBC15LLTongDai.TenLaiXe = objBC15.TenLaiXe;
                                     objBC15LLTongDai.ThoiDiemDaiGoi = objBC15.ThoiDiemDaiGoi;
                                     objBC15LLTongDai.GhiChu = objBC15.GhiChu;
                                 }
                                 else  // truoc day da co thong tin dai goi
                                 {
                                     objBC15LLTongDai.ThoiDiemDaiGoi += ";" + objBC15.ThoiDiemDaiGoi;
                                 }
                             }
                             else
                             {
                                 if ((objBC15LLTongDai.KhoangMatLienLac==null)||(objBC15LLTongDai.ThoiDiemDaiGoi.Length <= 0)) // Khoong co thong tin dai goi truoc day
                                 {

                                     g_ListItemBC15.Add(objBC15);   
                                 }
                                 else  // truoc day da co thong tin dai goi
                                 {
                                     objBC15LLTongDai.GhiChu = objBC15.GhiChu;
                                     objBC15LLTongDai.KhoangMatLienLac += objBC15.KhoangMatLienLac;

                                     g_ListItemBC15.Add(new BaoCao15(objBC15LLTongDai.SoHieuXe,objBC15LLTongDai.TenLaiXe,GetChuanKhoangMatLiennLac(objBC15LLTongDai.KhoangMatLienLac),objBC15LLTongDai.ThoiDiemDaiGoi,objBC15LLTongDai.GhiChu ));
                                     // khoi tao lai
                                     objBC15LLTongDai.ThoiDiemDaiGoi = "";
                                     objBC15LLTongDai.SoHieuXe = "";
                                     objBC15LLTongDai.GhiChu = "";
                                     objBC15LLTongDai.TenLaiXe = "";
                                     objBC15LLTongDai.KhoangMatLienLac = "";

                                 }
                             }                                                         
                         }
                         if ((i == iLen - 1 - 1) && (objBC15LLTongDai.KhoangMatLienLac.Length > 0)) g_ListItemBC15.Add(objBC15LLTongDai);
                     }                     
                 }
                 

                 gridXeMatLienLac.DataMember = "lstXeMatLienLac";
                 gridXeMatLienLac.SetDataBinding(g_ListItemBC15, "lstXeMatLienLac");

                 btnRefresh.Enabled = false;
               //  btnPrint.Enabled = !btnRefresh.Enabled;
                 btnExportExcel.Enabled = !btnRefresh.Enabled;

            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
        }
        /// <summary>
        /// xu ly du lieu de 
        /// input : " 00:52 h- 03:54h ngày 03/06 04:56 h- 06:55h ngày 03/06"
        /// output :" 00:52 h-06:55h ngày 03/06"
        /// </summary>
        /// <param name="KhoangMatLienLac"></param>
        /// <returns></returns>
        private string GetChuanKhoangMatLiennLac( string KhoangMatLienLac)
        {
            if (KhoangMatLienLac.Length > 30)
            {
                 string DoanDau = KhoangMatLienLac.Substring(0,KhoangMatLienLac.IndexOf("-")+1);
                 string DoanSau = KhoangMatLienLac.Substring(KhoangMatLienLac.LastIndexOf("-") + 2, KhoangMatLienLac.Length - (KhoangMatLienLac.LastIndexOf("-") + 2));
                 return DoanDau + DoanSau;
            }
            return KhoangMatLienLac;
        }
        /// <summary>
        /// Ham thuc chức năng tim các sự kiện mất liên lạc của một xe
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ListXeSuKienCuaMotXe">Du lieu nay se bi thay đổi</param>
        /// <param name="MocCuaThoiDiemCuoi">Thoi diem DenNgayGio, thêm vào để so sách thêm với thời điểm hiện tại</param>      
        private void GetSuKienMatLienLacCuaXe(List<BaoCao15> listItems, List<KiemSoatXeLienLac> ListXeSuKienCuaMotXe,DateTime ThoiDiemDau, DateTime  ThoiDiemCuoi)
        {

            // bMatLL = false 
            // if(!bMatLL) {
            //   {  if(la phan tu dau)
            //      luu gia tri khoi dau cua ghi chu. Lien lac lan cuoi truoc khi mat lien lac , thoi diem dau cua mat lien lac 
            // if kiem tra item tiep la  tong dai check khong, ghi nhat gia tri tong dai check, bMatLL = true
            // else (Tinh KhoangThoiGian)
                   //if (KhoangThoiGian < SoPhutGioiHan) // bMa
           

            //TimeSpan KhoangThoiGian ;
            //for (int i=0 ;i < ListXeSuKienCuaMotXe.Count ;i++)
            //{
            //    if (i == ListXeSuKienCuaMotXe.Count - 1) // so sach voi MocCuaThoiDiemCuoi
            //    {
            //         KhoangThoiGian =MocCuaThoiDiemCuoi - ListXeSuKienCuaMotXe[i] .ThoiDiemBao ;
            //    }
            //    else if(i < ListXeSuKienCuaMotXe.Count - 1)
            //        KhoangThoiGian = ListXeSuKienCuaMotXe[i+1].ThoiDiemBao - ListXeSuKienCuaMotXe[i].ThoiDiemBao;
               
            //    if (KhoangThoiGian.Minutes > Configuration.GetSoPhutGioiHanMatLienLac())
            //    {
            //        if(listItems.Count > 1)
            //        listItems.Add (new BaoCao15 (
            //    }
            //{
            //}
             
            //= XeSuKien2.ThoiDiemBao - XeSuKien1.ThoiDiemBao;

           
            //    bMLL = true;
            //    ThoiDiemDau_MLL = string.Format("{0: HH:mm}", XeSuKien1.ThoiDiemBao);
            //    if (XeSuKien2.TrangThaiLaiXeBao == Taxi.Utils.KieuLaiXeBao.TongDaiCheck)
            //    {
            //        TongDaiGoi_MLL += string.Format("{0: HH:mm}", XeSuKien2.ThoiDiemBao) + ";";
            //    }
            //    else
            //    {
            //        // chen vao ĐB  

            //    }
            //}

            //i = i + 1;
        }


        private DataTable CreateBangDuLieuChoReport_NVDienThoai()
        {


            //<dataroot>
            //  <BaoCaoBieuMau15>
            //     <SoHieuXe></SoHieuXe>
            //    < TenLaiXe></TenLaiXe>
            //    <ThoigianMatLienLac></ThoigianMatLienLac>
            //    < ThoiDiemDaiGoi></ ThoiDiemDaiGoi> 
            //    <GhiChu></GhiChu>
            //  </BaoCaoBieuMau15>
            //</dataroot>

            DataTable dt = new DataTable();

            DataColumn dc;

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.String");
            dc.ColumnName = "SoHieuXe";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.String");
            dc.ColumnName = "TenLaiXe";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.String");
            dc.ColumnName = "ThoigianMatLienLac";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.String");
            dc.ColumnName = "ThoiDiemDaiGoi";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.String");
            dc.ColumnName = "GhiChu";
            dt.Columns.Add(dc); 

            return dt;
        }



        private void editPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char  chr = Convert.ToChar(";");
            if(char.IsDigit ( e.KeyChar) || (e.KeyChar == (char) Keys.Back ) || (e.KeyChar == chr  ))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void editSoChuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (e.KeyChar ==(char)Keys.Back))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void editPhut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        
         
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //frmInBaoCao frmPrint = new frmInBaoCao();
            //frmPrint.InBaoCaoBieuMau3(Configuration.GetReportPath() + "\\Baocao_Bieumau3.rpt", g_lstBaoCaoBieuMau3, calTuNgay.Value, calDenNgay.Value, GetLoaiCuocGoi(), StringTools.TrimSpace(editPhoneNumber.Text), editSoChuong.Text, string.Format("{0: HH:mm:ss}", timeThoiGianDamThoai.Value ));  
            //frmPrint .ShowDialog();
        }

        

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_BieuMau14.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
            }
        }

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true ;
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
//btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chkGoiTaxi_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            //btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chkGoiLai_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
//btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chkGoiKhac_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            //btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void editPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void editSoChuong_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            //btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void editPhut_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
 
    }
}