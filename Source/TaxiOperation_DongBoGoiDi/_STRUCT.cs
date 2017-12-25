using System;
using System.Collections.Generic;
using System.Text;
using EFiling.Utils;

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
    }    
};

