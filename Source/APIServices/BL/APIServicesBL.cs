using System;
using System.Data;
using APIServices.DAL;
using APIServices.Entities;
using System.Collections.Generic;

namespace APIServices.BL
{
    public class APIServicesBL
    {
        #region=========================SERVICE - DS XE DE CU=================
        /// <summary>
        /// hàm thực hiện lấy ra ds xe đề cử.
        /// </summary>
        /// 
        /// <param name="kinhDo"> kinh độ điểm khách gọi </param>
        /// <param name="viDo">  vĩ độ điểm khách gọi</param>
        /// <param name="maXN"> thông mã xí nghiệp trên hệ thống GPS </param>
        /// <param name="loaiXe">loại xe, chuyển đổi về loại xe tương ứng của GPS, (KIA, VIO, INO, LIMO). KHong chọn là tất cả </param>
        /// <param name="kenhVung">số kênh phía điện thoại đã chọn, Không chọn là tất cả</param>
        /// <param name="banKinhGioiHan">trong vòng bán kính giới hạn (bán kính từ khách tới xe) 3000 m</param>
        /// <param name="trangThaiCoKhach">trạng thái. 1: có khách, 2: không khách, 3: là cả hai. MẶC ĐỊNH là không khách</param>
        /// <param name="soXeTraVe">giới hạn số xe trả về. MẶC ĐỊNH là 5 xe </param>
        /// <returns>mẫu SHXe_KhoangCach_KD_VD_TrangThai : 1232_1.2_20.9868345082291_105.867611181313_0,3253_1.4_20.9868345082291_105.867611181313_0</returns>
        public string LayDanhSachXeDeCu(double KD, double VD, string maXN, string loaiXe, int banKinhGioiHan, int soLuongXe)
        {
            return getDSXe(new APIServicesDAL().LayDanhSachXeDeCu(KD, VD, maXN, loaiXe, banKinhGioiHan, soLuongXe));
        }

        /// <summary>
        /// hàm thực hiện lấy ra ds xe đề cử.
        /// </summary>
        /// 
        /// <param name="kinhDo"> kinh độ điểm khách gọi </param>
        /// <param name="viDo">  vĩ độ điểm khách gọi</param>
        /// <param name="maXN"> thông mã xí nghiệp trên hệ thống GPS </param>
        /// <param name="loaiXe">loại xe, chuyển đổi về loại xe tương ứng của GPS, (KIA, VIO, INO, LIMO). KHong chọn là tất cả </param>
        /// <param name="kenhVung">số kênh phía điện thoại đã chọn, Không chọn là tất cả</param>
        /// <param name="banKinhGioiHan">trong vòng bán kính giới hạn (bán kính từ khách tới xe) 3000 m</param>
        /// <param name="trangThaiCoKhach">trạng thái. 1: có khách, 2: không khách, 3: là cả hai. MẶC ĐỊNH là không khách</param>
        /// <param name="soXeTraVe">giới hạn số xe trả về. MẶC ĐỊNH là 5 xe </param>
        /// <returns>mẫu SHXe_KhoangCach_KD_VD_TrangThai : 1232_1.2_20.9868345082291_105.867611181313_0,3253_1.4_20.9868345082291_105.867611181313_0</returns>
        public string LayDanhSachXeDeCu2_CalGEO(double KDMin, double VDMin, double KDMax, double VDMax, string maXN, string loaiXe, int soLuongXe)
        {
            return getDSXe(new APIServicesDAL().LayDanhSachXeDeCu_CalGEO(KDMin, VDMin, KDMax, VDMax, maXN, loaiXe, soLuongXe));
        }

        /// <summary>
        /// Lấy tọa độ của xe nhận
        /// </summary>
        /// <param name="KD"></param>
        /// <param name="VD"></param>
        /// <param name="maXN"></param>
        /// <param name="SoHieuXe"></param>
        /// <returns>SHXe_KhoangCach_KD_VD_TrangThai</returns>
        public string LayToaDoXeNhan(double KD, double VD, string maXN, string SoHieuXe)
        {
            return new APIServicesDAL().LayToaDoXeNhan(KD, VD, maXN, SoHieuXe);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>mẫu SHXe_KhoangCach_KD_VD_TrangThai : 1232-1.2-20.9868345082291-105.867611181313-0,3253-1.4-20.9868345082291-105.867611181313-0</returns>
        public static string getDSXe(DataTable dt)
        {
            try
            {
                if (dt != null)
                {
                    string returnVal = "";
                    if (dt.Rows.Count > 0)
                    {
                        //dt.DefaultView.Sort = "KhoangCach ASC";
                        foreach (DataRow row in dt.Rows)
                        {
                            returnVal = string.Format("{0}{1}_{2}_{3}_{4}_{5},",
                                                         returnVal,
                                                         row["PK_SoHieuXe"].ToString().Trim(),
                                                         Math.Round(Convert.ToDouble(row["KhoangCach"].ToString().Trim()) / 1000, 1),
                                                         row["KinhDo"].ToString().Trim(),
                                                         row["ViDo"].ToString().Trim(),
                                                         row["TrangThai"].ToString().Trim()
                                                     );
                        }
                        returnVal = returnVal.Substring(0, returnVal.Length - 1);
                    }
                    else
                    {
                        returnVal = "5";
                    }
                    return returnVal;
                }
                else
                {
                    return "5";
                }
            }
            catch(Exception ex)
            {
                return "";
            }
        }

        #endregion=============================================================

        #region=========================SERVICE - DS XE TOI DIEM=================

        /// <summary>
        /// Congnt
        /// Ham tra ve ds cac xe toi diem cuar moi cuoc goi
        /// 
        /// </summary>
        /// <param name="dsCuocGoi">DS cac cuoc goi : IDCuocGoi;KinhDo;ViDo;DSXeNhan#IDCuocGoi;KinhDo;ViDo;DSXeNhan#
        ///                         Vi du : 190;105.010254;21.902343;4320.9890.4578#198;105.010254;21.902343;1209.8900.2578
        /// </param>
        /// <param name="banKinhGioiHan">met , 50</param>
        /// <returns> IDCuocGoi;XeNhan-KhoangCach,XeNhan-KhoangCach#IDCuocGoi;XeNhan-KhoangCach,XeNhan-KhoangCach#
        /// vd :      190;4320-43,4578-43#105;1209-12,8900-30
        /// </returns>
        public string GetDSToiDiem(string dsCuocGoiCanXeToiDiem, int soGiayCoTinHieuGanDay, string maCungXNs, int banKinhGioiHan)
        {
            string ret = string.Empty;
            string [] arrCuocGoi = dsCuocGoiCanXeToiDiem.Split ("#".ToCharArray ());
            List<ThamSoXeToiDiem> cuocGoiXeToiDiems = new List<ThamSoXeToiDiem> ();
            
            if(arrCuocGoi!=null && arrCuocGoi.Length>0)
            {
                for (int i = 0; i < arrCuocGoi.Length; i++)
                {
                    cuocGoiXeToiDiems.Add(new ThamSoXeToiDiem( arrCuocGoi[i]));
                }
            }
            ret = GetDSToiDiem(cuocGoiXeToiDiems,soGiayCoTinHieuGanDay,maCungXNs, banKinhGioiHan);

            return ret;
        }

        /// <summary>
        /// lay cac xe toi diem cua cuoc goi
        /// </summary>
        /// <param name="cuocGoiXeToiDiems"></param>
        /// <param name="soGiayCoTinHieuGanDay"></param>
        /// <param name="maCungXNs"></param>
        /// <param name="banKinhGioiHan">ban kinh - met</param>
        /// <returns> 190;4320-43,4578-43#105;1209-12,8900-30 (idCuocGoi;SoHieuXe-Khoang Cach)</returns>
        private string GetDSToiDiem(List<ThamSoXeToiDiem> cuocGoiKiemTraXeToiDiems, int soGiayCoTinHieuGanDay, string maCungXNs, int banKinhGioiHan)
        {
            string ret = string.Empty;
            // lay xe online 
            List<XeOnlineEntity> listXeOnline = GetDSXeOnlineHoatDong(soGiayCoTinHieuGanDay, maCungXNs);
            // loc tim xe toi diem            
            foreach (ThamSoXeToiDiem item in cuocGoiKiemTraXeToiDiems)
            {
                string xeCoToiDiem = KiemTraXeToiDiem(item, listXeOnline, banKinhGioiHan);
                if (xeCoToiDiem.Length > 0)
                    ret += xeCoToiDiem + "#";

            }
            if (ret.Length > 0) // cat bo dau #
                ret = ret.Substring(0, ret.Length - 1);

            return ret;
        }
        /// <summary>
        /// ham kiem tra thong tin xe nhan da toi diem chua, neu toi trong khoang cach ban kinh thi trar ve thong tin cac xe toi diem
        /// </summary>
        /// <param name="item"> cuoc goi, voi vi tri cua khach va ds xe nhan</param>
        /// <param name="listXeOnline"> ds xe online </param>
        /// <returns> 190;4320-43,4578-43 </returns>
        private string KiemTraXeToiDiem(ThamSoXeToiDiem item, List<XeOnlineEntity> listXeOnline,int banKinhGioiHan)
        {
            string ret = string.Empty;
            string xeToiDiem = string.Empty;
            foreach (string xeNhan in item.XeNhans)
            {
                double  khoangCach = 0;
                foreach (XeOnlineEntity xeOnline in listXeOnline)
                {
                    if (xeNhan == xeOnline.SoHieuXe)
                    {
                        khoangCach = Globals.TinhKhoangCachFast(item.KinhDo, item.ViDo, xeOnline.KinhDo, xeOnline.ViDo);
                        if (khoangCach <= banKinhGioiHan) // xe toi diem cua khach
                        {
                            xeToiDiem += string.Format("{0}-{1},", xeNhan, (int)khoangCach);
                                
                        }
                    }
                }
            }

            if (xeToiDiem.Length > 0)
            {
                ret = string.Format("{0};{1}", item.IdCuocGoi, xeToiDiem.Substring(0,xeToiDiem.Length -1));
            }
            
            return ret; ;
        }

        /// <summary>
        /// hàm thực,hiện gửi về ds xe tới diểm đón dược khách.
        /// </summary>
        /// <param name="cuocGoiKiemTraXeDonKhachs"></param>
        /// <param name="soGiayCoTinHieuGanDay"></param>
        /// <param name="maCungXNs"></param>
        /// <returns></returns>
        public  string GetDSToiDiemDaDonKhach( string  cuocGoiKiemTraXeDonKhachs, int soGiayCoTinHieuGanDay, string maCungXNs)
        {
            string ret = string.Empty;
            string[] arrCuocGoi = cuocGoiKiemTraXeDonKhachs.Split("#".ToCharArray());
            List<ThamSoXeToiDiem> cuocGoiXeToiDiems = new List<ThamSoXeToiDiem>();

            if (arrCuocGoi != null && arrCuocGoi.Length > 0)
            {
                for (int i = 0; i < arrCuocGoi.Length; i++)
                {
                    cuocGoiXeToiDiems.Add(new ThamSoXeToiDiem(arrCuocGoi[i]));
                }
            }
            ret = GetDSToiDiemDaDonKhach(cuocGoiXeToiDiems, soGiayCoTinHieuGanDay, maCungXNs);

            return ret;
        }
        /// <summary>
        /// Hàm thực hiện lấy xe đón được khách trong ds xe nhận
        /// </summary>
        /// <param name="cuocGoiKiemTraXeToiDiems"></param>
        /// <param name="soGiayCoTinHieuGanDay"></param>
        /// <param name="maCungXNs"></param>
        /// <returns>   </returns>
        private   string GetDSToiDiemDaDonKhach(List<ThamSoXeToiDiem> cuocGoiKiemTraXeDonKhachs, int soGiayCoTinHieuGanDay, string maCungXNs)
        {
            string ret = string.Empty;
            // lay xe online 
            List<XeOnlineEntity> listXeOnline = GetDSXeOnlineHoatDong(soGiayCoTinHieuGanDay, maCungXNs);
            // loc tim xe toi diem            
            foreach (ThamSoXeToiDiem item in cuocGoiKiemTraXeDonKhachs)
            {
                string xeCoToiDiem = KiemTraXeToiDiemDonKhach(item, listXeOnline);
                if (xeCoToiDiem.Length > 0)
                    ret += xeCoToiDiem + "#";
            }
            if (ret.Length > 0) // cat bo dau #
                ret = ret.Substring(0, ret.Length - 1);

            return ret;

        }
        /// <summary>
        /// ham kiem tra thong tin xe nhan da toi diem chua, neu toi trong khoang cach ban kinh thi trar ve thong tin cac xe toi diem
        /// </summary>
        /// <param name="item"> cuoc goi, voi vi tri cua khach va ds xe nhan</param>
        /// <param name="listXeOnline"> ds xe online </param>
        /// <returns> 190;4320-43,4578-43 </returns>
        private string KiemTraXeToiDiemDonKhach(ThamSoXeToiDiem item, List<XeOnlineEntity> listXeOnline )
        {
            string ret = string.Empty;
            string xeToiDiem = string.Empty;
            foreach (string xeNhan in item.XeNhans)
            {
                double khoangCach = 0;
                foreach (XeOnlineEntity xeOnline in listXeOnline)
                {
                    if (xeNhan == xeOnline.SoHieuXe)
                    {

                        if ((xeOnline.TrangThai & 3) >0 ) // kiem tra xe don khách
                        {
                            xeToiDiem += string.Format("{0},", xeNhan); 
                        }
                    }
                }
            }

            if (xeToiDiem.Length > 0)
            {
                ret = string.Format("{0};{1}", item.IdCuocGoi, xeToiDiem.Substring(0, xeToiDiem.Length - 1));
            }

            return ret; ;
        }

        ///=======================================================================
       /// <summary>
       /// Congnt        
       /// Hàm trả về ds xe online của những xe còn có tín hiệu gần đây.
       /// với điều kiện ThoiDiemChenDuLieu > thời điểm hiện tại trừ đi SoGiayCoTinHieuGanDay,
       /// mặc định là 120
       /// </summary>
       /// <param name="soGiayCoTinHieuGanDay">Số giây có tin hiệu gân đây</param>
       /// <param name="maCungXNs">ds mã cứng XN - 329,450,6025</param>
       /// <returns></returns>
        public List<XeOnlineEntity> GetDSXeOnlineHoatDong(int soGiayCoTinHieuGanDay, string maCungXNs)
        {
            return new DAL.APIServicesDAL ().GetDSXeOnlineHoatDong(soGiayCoTinHieuGanDay,maCungXNs);
        }

        #endregion

         
    }
}
