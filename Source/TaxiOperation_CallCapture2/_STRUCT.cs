using System;
using Taxi.Utils;

namespace TaxiCapture.Common
{
    public struct StructCuocGoi
    {
        public long  CuocGoiID; // la mot ma duoc tra ve tu khi chen vao cuoc goi ddang dieu hanh
        public string Line  ; 
        public string PhoneNumber  ;
        public DateTime ThoiDiemGoiDen  ;  // thoi diem goi den
        public DateTime ThoiDiemNgheMay   ;  // cho cuoc goi co nghe may, thoi diem nhac may nghe
        public DateTime ThoiDiemKhongNhacMay ;  // cho cuoc goi nho
        public DateTime KhoangThoiGianHoiThoai  ;  // khoi tao la 1900-01-00 00:01:01 chi lay phan H,M,S        
        public string fileAmThanhPath ;
        public TypeCall KieuCuocGoi  ;
        public byte SoLanGoiLaiGanDay;
        public KieuKhachHangGoiDen kieuKhachHangGoiDen;
        public long CuocGoiLaiID;
        public int SoLuotDoChuong;
        public string LoaiXe;
        public string ThoiGianGoiLai;
        public string GhiChuTiepNhan;
        public float GPS_KinhDo;
        public float GPS_ViDo;
    }    

    /// <summary>
    /// thoong tin cuoc goi theo udp ban ra
    /// minh quan tam mot so thong tin
    ///  - Thoi diem goi
    ///  - So dien thoai goi (nguyen thuy, tra ra the nao lay the do)
    ///  - Line (int) da quy doi
    ///  - CuocGoiID
    /// </summary>
    public struct CuocGoiUDP
    {
        public long CuocGoiID; // la mot ma duoc tra ve tu khi chen vao cuoc goi ddang dieu hanh
        public string Line;
        public string PhoneNumber;
        public DateTime ThoiDiemGoiDen;  // thoi diem goi den
    }

};

