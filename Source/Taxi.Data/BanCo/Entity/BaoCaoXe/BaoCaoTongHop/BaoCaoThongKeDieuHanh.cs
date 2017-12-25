using System;
using System.Collections.Generic;
using System.Linq;
using Taxi.Common.Extender;
using Taxi.Data.BaoCaoNew;

namespace Taxi.Data.BanCo.Entity.BaoCaoXe.BaoCaoTongHop
{
    public class BaoCaoThongKeDieuHanh:BaoCaoTongHopBase
    {
        public static Dictionary<string, string> DicMaDoiTac = new Dictionary<string, string>();
        public static Dictionary<string, string> DicXeHoatDongQuaTT = new Dictionary<string, string>();

        public static Dictionary<string,string>  DicXeHoatDongQuaGPS = new Dictionary<string, string>();
        public static Dictionary<int,SummaryGPS> DicSummaryGPS= new Dictionary<int, SummaryGPS>();
        public const int DiffHour = 0;//Không cần chỉnh tham số này nữa!
       
        /// <summary>
        /// Hàm liên kết dữ liệu với DB và view trên datatable!
        /// </summary>
        protected override void DoBind()
        {
            //Lấy dữ liệu chung!
            var data = BC_4_9_TKeSoLieuDieuHanh.Inst.LayDuLieuThongKeDieuHanh(From, To).ToList<TKePhongDieuHanhInfo>();//300K dữ liệu
            var dataSanh = BC_4_9_TKeSoLieuDieuHanh.Inst.LayDuLieuCacSanh().ToList<SanhDienThoai>();
            var dataGPS = BC_4_9_TKeSoLieuDieuHanh.Inst.LayDuLieuCuocGPS(From, To).ToList<TKePhongDieuHanhInfo>();//~300K dữ liệu

            #region Delegate tạo cột tiêu đề đầu tiên
            Action<string, List<string>> CreateRow = (km, lst) =>
            {
                foreach (var di in lst)
                {
                    var dr = Table.NewRow();
                    dr["KhoanMuc"] = km;
                    dr["NoiDung"] = di;
                    Table.Rows.Add(dr);
                    DicRow[di] = dr;
                }
            };
           
            CreateRow("Thống kê số liệu phòng điều hành",
                new List<string> 
                {    "Thống kê số liệu phòng điều hành" 
                    ,"Tổng số xe hoạt động qua GPS"
                    ,"Tổng số xe hoạt động qua trung tâm"
                    ,"Tổng cuốc"
                    ,"Đón được"
                    ,"Cuốc sảnh"
                    ,"Tổng cuốc gọi qua TT"
                    ,"Đón được TT"
                    ,"% đón được"
                    ,"Trượt hoãn"
                    ,"Không xe"
                    ,"Vùng 1"
                    ,"Vùng 2"
                    ,"Vùng 3"
                    ,"Vùng 4"
                    ,"Tổng số cuốc điều qua APP"
                    ,"Tỷ lệ điều qua APP"
                    ,"Số cuốc đón được từ APP"
                    ,"Tỷ lệ đón được qua APP"
                    ,"Khách qua GPS"
                    ,"Tỷ lệ cuốc đón qua TT"
                    ,"Khách đi sân bay gọi qua trung tâm (HN-NB)"
                    ,"NB-HN"
                    ,"Khách đi sân bay qua Đi chung"
                    ,"Số điểm hoa hồng gọi đến"
                    ,"Số cuốc từ điểm hoa hồng"
                    ,"Số cuốc từ điểm hoa hồng đón được"
                    ,"Số cuốc gọi 7 chỗ"
                    ,"Số cuốc gọi xe Avante"
                    ,"Khách gọi lại"
                    ,"Khách đặt"
                    ,"Khách đặt online"
                    ,"Tỷ lệ đón được khách đặt cả online"
                });           
            Action<string, Summary> FillCell = (cell, tsSum) =>
            {
                if (!Table.Columns.Contains(cell)) return;
                if (!tsSum.TinhSanh)
                {          
                    if(tsSum.KhachQuaGPS>0)
                        DicRow["Thống kê số liệu phòng điều hành"][cell] = (Convert.ToDouble(tsSum.TongCuoc) / Convert.ToDouble(tsSum.KhachQuaGPS)) * 100;
                    DicRow["Tổng số xe hoạt động qua GPS"][cell] = tsSum.TongXeQuaGPS;
                    DicRow["Tổng số xe hoạt động qua trung tâm"][cell] = tsSum.TongXeQuaTrungTam;
                    DicRow["Tổng cuốc"][cell] = tsSum.TongCuoc;
                    DicRow["Đón được"][cell] = tsSum.DonDuoc;
                    DicRow["Cuốc sảnh"][cell] = tsSum.CuocSanh;
                    DicRow["Tổng cuốc gọi qua TT"][cell] = tsSum.TongCuocQuaTT;
                    DicRow["Đón được TT"][cell] = tsSum.DonDuocThucTe;
                    if (tsSum.TongCuocQuaTT > 0)
                    {
                        tsSum.PhanTramDonDuoc = (Convert.ToDouble(tsSum.DonDuocThucTe)/Convert.ToDouble(tsSum.TongCuocQuaTT))*100;
                    }
                    DicRow["% đón được"][cell] = tsSum.PhanTramDonDuoc;
                    DicRow["Trượt hoãn"][cell] = tsSum.TruotHoan;
                    DicRow["Không xe"][cell] = tsSum.KhongXe;
                    DicRow["Vùng 1"][cell] = tsSum.Vung1;
                    DicRow["Vùng 2"][cell] = tsSum.Vung2;
                    DicRow["Vùng 3"][cell] = tsSum.Vung3;
                    DicRow["Vùng 4"][cell] = tsSum.Vung4;
                    DicRow["Tổng số cuốc điều qua APP"][cell] = tsSum.TongSoCuocDieuQuaApp;
                    if (tsSum.TongCuoc > 0)
                        tsSum.TyLeDieuQuaApp = (Convert.ToDouble(tsSum.TongSoCuocDieuQuaApp)/Convert.ToDouble(tsSum.TongCuoc))*100;
                    DicRow["Tỷ lệ điều qua APP"][cell] = tsSum.TyLeDieuQuaApp;
                    DicRow["Số cuốc đón được từ APP"][cell] = tsSum.SoCuocDonDuocTuApp;
                    if (tsSum.TongSoCuocDieuQuaApp > 0)
                        tsSum.TyLeDonDuocQuaApp = Convert.ToDouble(tsSum.SoCuocDonDuocTuApp)/
                                                  Convert.ToDouble(tsSum.TongSoCuocDieuQuaApp)*100;
                    DicRow["Tỷ lệ đón được qua APP"][cell] = tsSum.TyLeDonDuocQuaApp;
                    DicRow["Khách qua GPS"][cell] = tsSum.KhachQuaGPS;
                    if (tsSum.TongCuoc > 0)
                        tsSum.TyLeCuocDonQuaTT = Convert.ToDouble(tsSum.KhachQuaGPS)/Convert.ToDouble(tsSum.TongCuoc)*100;
                    DicRow["Tỷ lệ cuốc đón qua TT"][cell] = tsSum.TyLeCuocDonQuaTT;
                    DicRow["Khách đi sân bay gọi qua trung tâm (HN-NB)"][cell] = tsSum.SanBayQuaTT;
                    DicRow["NB-HN"][cell] = tsSum.NB_HN;
                    DicRow["Khách đi sân bay qua Đi chung"][cell] = tsSum.NB_DiChung;
                    DicRow["Số điểm hoa hồng gọi đến"][cell] = tsSum.SoDiemHoaHongGoiDen;
                    DicRow["Số cuốc từ điểm hoa hồng"][cell] = tsSum.SoCuocTuDiemHoaHong;
                    DicRow["Số cuốc từ điểm hoa hồng đón được"][cell] = tsSum.SoCuocDiemHoaHongDonDuoc;
                    DicRow["Số cuốc gọi 7 chỗ"][cell] = tsSum.SoCuoc7Cho;
                    DicRow["Số cuốc gọi xe Avante"][cell] = tsSum.SoCuocAvante;
                    DicRow["Khách gọi lại"][cell] = tsSum.KhachGoiLai;
                    DicRow["Khách đặt"][cell] = tsSum.KhachDat;
                    DicRow["Khách đặt online"][cell] = tsSum.KhachDatOnline;
                    if (tsSum.KhachDat > 0)
                        tsSum.TyLeDonDuocKhachDatOnline = Convert.ToDouble(tsSum.KhachDatDonDuoc)/Convert.ToDouble(tsSum.KhachDat)*100;
                    DicRow["Tỷ lệ đón được khách đặt cả online"][cell] = tsSum.TyLeDonDuocKhachDatOnline;
                }
                //Lấy tên theo sảnh để hiển thị và tính toán!
                else
                {
                    DicRow["Tổng khách điểm sảnh"][cell] = tsSum.TongKhachDiemSanh;
                    foreach (var item in dataSanh)
                    {
                        if (tsSum.DicMapSanh.ContainsKey(item.Name))
                        {
                            DicRow[item.Name][cell] = tsSum.DicMapSanh[item.Name];
                        }
                    }     
                }                                 
            };
            #endregion

            #region Tính tổng dữ liệu theo từng nhóm
            //0. Thống kê cuốc GPS
            int count =((DateTime)To).Day - ((DateTime) From).Day;
            for (int i = 1; i <= count + 1; i++)
            {
                SummaryGPS temp = new  SummaryGPS();
                temp.CuocGPS = dataGPS.Count(a => a.ThoiDiemGoi.Day == i);               
                temp.XeHoatDongGps = dataGPS.Where(a => a.ThoiDiemGoi.Day == i).Select(s=>s.XeDon).Distinct().Count();
                DicSummaryGPS[i] = temp;
            }
           
            #region 1.Tính tổng tĩnh: Nhóm dữ liệu theo ngày và phân theo từng ca làm việc
            var dataByDay = data.GroupBy(d => d.ThoiDiemGoi.AddHours(DiffHour).Day).SelectMany(g =>
            {
                DicMaDoiTac.Clear();
                DicXeHoatDongQuaTT.Clear();
                var result = g.Select(gi => gi.ToSummary()).GroupBy(gc => gc.ID).Select(gci =>
                {
                    var ts = gci.DoSum();
                    DicRow[gci.Key]["Day_" + g.Key] = ts.TongXeQuaTrungTam;
                    return new DataByDay { Day = g.Key, Summary = ts, MaCuoc = gci.Key };
                });
                return result;
            });
            //Tính toán dữ liệu trong 1 ngày và hiển thị lên cell!           
            var tsAll = DayWithWeek.Join(dataByDay, dwi => dwi.Key.Day, d => d.Day, (dwi, d) => new {w = dwi.Value, d})
                .GroupBy(wd => wd.w).SelectMany(gwd =>
                {
                    var result= gwd.GroupBy(gwdi => gwdi.d.MaCuoc).SelectMany(gwdi =>
                    {                        
                        return gwdi.Select(d => d.d);
                    });
                    return result;
                })//Lấy mã theo từng ngày!
                .GroupBy(b => b.Day).Select(g =>
                {
                    var ts = g.Select(t => t.Summary).DoSum();
                    ts.TongXeQuaGPS = DicSummaryGPS[g.Key].XeHoatDongGps;
                    ts.KhachQuaGPS = DicSummaryGPS[g.Key].CuocGPS;
                    FillCell("Day_" + g.Key, ts);
                    return new DataByDay {Day = g.Key, Summary = ts};
                })
                // Tính toán dữ liệu cho cả tuần và ngày còn lại!  tính các row còn lại!
                .Join(DayWithWeek, d => d.Day, dwi => dwi.Key.Day, (d, dwi) => new { Summary = d.Summary, Week = dwi.Value }).
                GroupBy(w => w.Week).Select(g =>
                {
                    var ts = g.Select(gi => gi.Summary).DoSum();
                    FillCell("W_" + g.Key, ts);
                    return ts;
                }).DoSum();
            #endregion

            #region 2. Tính sảnh: Nhóm trong data theo ngày sau đó mới join để tính tổng theo ngày!

            var dataSanhByDay = data.GroupBy(g => g.ThoiDiemGoi.AddHours(DiffHour).Day).SelectMany(s =>
            {
                var result = s.Select(sItem => sItem.ToSummary()).GroupBy(gi=>gi.Name).Select(gii =>
                {
                    var ts = gii.DoSum();//gii la tap cac sanh!                    
                    ts.TinhSanh = true;
                    return new DataByDay {Day= s.Key,MaCuoc =gii.Key,Summary = ts};
                });
                return result;           
            });
            //Tính cột total của các sảnh
            int totalSum = 0;
            List<Summary> lstSanhTotal = new List<Summary>();
            var totalSanh = dataSanhByDay.Join(dataSanh, a => a.MaCuoc, b => b.Name,
                (a, b) => new { a.MaCuoc, a.Summary.MaDoiTac,a.Summary.CuocSanh, a.Day })
                .GroupBy(g => g.MaCuoc).Select(s =>
                {
                    var sum1Sanh = 0;
                    var ts = new Summary();    
                    foreach (var item in s)
                    {
                        sum1Sanh += item.CuocSanh;
                    }                                    
                    ts.TinhSanh = true;
                    ts.DicMapSanh[s.Key] = sum1Sanh;
                    ts.Name = s.Key;
                    ts.CuocSanh = sum1Sanh;
                    totalSum += sum1Sanh;
                    ts.TongKhachDiemSanh = totalSum;
                    lstSanhTotal.Add(ts);
                    
                    return true;
                }).Count();
            //Sắp xếp và FillCell
            lstSanhTotal = lstSanhTotal.OrderByDescending(a => a.CuocSanh).ToList();
            List<string> lstSanhDienThoai = new List<string>();
            lstSanhDienThoai.Add("Tổng khách điểm sảnh");
            foreach (var item in lstSanhTotal)
            {
                lstSanhDienThoai.Add(item.Name);
                item.TongKhachDiemSanh = totalSum;
            }
            CreateRow("Tổng khách điểm sảnh", lstSanhDienThoai);
            foreach (var ts in lstSanhTotal)
            {
                FillCell("Total", ts);
            }
            var sumSanh = dataSanhByDay.Join(dataSanh, a => a.MaCuoc, b => b.Name, (a, b) => new { a.MaCuoc, a.Summary.MaDoiTac,a.Summary.CuocSanh,a.Day })
                .GroupBy(g2=>g2.Day).Select(s2 =>
                {
                    Summary ts=new Summary();
                    var tongNgay = 0;
                    foreach (var item in s2)
                    {
                        ts= new Summary();
                        ts.TinhSanh = true;
                        tongNgay += item.CuocSanh;
                        ts.TongKhachDiemSanh =tongNgay;
                        ts.DicMapSanh[item.MaCuoc] = item.CuocSanh;
                        FillCell("Day_" + s2.Key, ts);
                    }                    
                    return new DataByDay{Day=s2.Key,Summary=ts};
                }).Count();
                   
            FillCell("Total", tsAll);//Fill vào cột tổng!
            #endregion

            #endregion
        }
    }

    public class Summary
    {
        public string ID { get; set; }
        public string MaDoiTac { get; set; }        

        public Dictionary<string, int> DicMapSanh =new Dictionary<string, int>();
        public string Name { get; set; }//Tên đối tác nếu có
        public int TongXeQuaGPS { get; set; }
        public int TongXeQuaTrungTam { get; set; }
        public int TongCuoc { get; set; }
        public int DonDuoc { get; set; }//Có qua sảnh
        public int CuocSanh { get; set; }

        public int TongCuocQuaTT { get; set; }

        public int DonDuocThucTe { get; set; }//Không qua sảnh!

        public double PhanTramDonDuoc { get; set; }
        public int TruotHoan { get; set; }
        public int KhongXe { get; set; }

        public int Vung1 { get; set; }
        public int Vung2 { get; set; }
        public int Vung3 { get; set; }
        public int Vung4 { get; set; }
        public int TongSoCuocDieuQuaApp { get; set; }
        public double TyLeDieuQuaApp { get; set; }
        public int SoCuocDonDuocTuApp { get; set; }
        public double TyLeDonDuocQuaApp { get; set; }//18
        public int KhachQuaGPS { get; set; }
        public double TyLeCuocDonQuaTT { get; set; }
        public int SanBayQuaTT { get; set; }
        public int NB_HN { get; set; }
        public int NB_DiChung { get; set; }
        public int SoDiemHoaHongGoiDen { get; set; }
        public int SoCuocTuDiemHoaHong { get; set; }//25
        public int SoCuocDiemHoaHongDonDuoc { get; set; }
        public int SoCuoc7Cho { get; set; }
        public int SoCuocAvante { get; set; }
        public int KhachGoiLai { get; set; }
        public int KhachDat { get; set; }
        public int KhachDatOnline { get; set; }
        public int KhachDatDonDuoc { get; set; } 
        public double TyLeDonDuocKhachDatOnline { get; set; }
        public double TKeSoLieuPhongDieuHanh { get; set; }
        public double TongKhachDiemSanh { get; set; }

        public bool TinhSanh = false;
    }

    public static class SummaryExtender
    {
        /// <summary>
        /// Trả ra đối tượng sum trong linq!
        /// </summary>
        public static Summary DoSum(this IEnumerable<Summary> tss)
        {
            var s = new Summary();
            foreach (var item in tss)
            {
                s.TongXeQuaTrungTam += item.TongXeQuaTrungTam;
                s.TongXeQuaGPS += item.TongXeQuaGPS;
                s.TongCuoc += item.TongCuoc;
                s.DonDuoc += item.DonDuoc;//Bao gồm cuốc sảnh!
                s.CuocSanh += item.CuocSanh;
                s.TongCuocQuaTT += item.TongCuocQuaTT;
                s.DonDuocThucTe += item.DonDuocThucTe;
                //s.PhanTramDonDuoc += item.PhanTramDonDuoc;
                s.TruotHoan += item.TruotHoan;
                s.KhongXe += item.KhongXe;
                s.Vung1 += item.Vung1;
                s.Vung2 += item.Vung2;
                s.Vung3 += item.Vung3;
                s.Vung4 += item.Vung4;
                s.TongSoCuocDieuQuaApp += item.TongSoCuocDieuQuaApp;                
                s.SoCuocDonDuocTuApp += item.SoCuocDonDuocTuApp;                
                s.KhachQuaGPS += item.KhachQuaGPS;                
                s.SanBayQuaTT += item.SanBayQuaTT;
                s.NB_HN += item.NB_HN;
                s.NB_DiChung += item.NB_DiChung;
                s.SoDiemHoaHongGoiDen += item.SoDiemHoaHongGoiDen;
                s.SoCuocTuDiemHoaHong += item.SoCuocTuDiemHoaHong;
                s.SoCuocDiemHoaHongDonDuoc += item.SoCuocDiemHoaHongDonDuoc;
                s.SoCuoc7Cho += item.SoCuoc7Cho;
                s.SoCuocAvante += item.SoCuocAvante;
                s.KhachGoiLai += item.KhachGoiLai;
                s.KhachDat += item.KhachDat;
                s.KhachDatOnline += item.KhachDatOnline;
            }
            return s;
        }

        /// <summary>
        /// *sign hàm tính toán quan trọng nhất!
        /// </summary>
        public static Summary ToSummary(this TKePhongDieuHanhInfo pTKe)
        {
            var result = new Summary();
            result.ID = pTKe.ID;
            result.MaDoiTac = pTKe.MaDoiTac;
            result.Name = pTKe.Name;            
            if (pTKe.KieuCuocGoi == 2) result.KhachGoiLai = 1; else result.KhachGoiLai = 0;
            if (pTKe.KieuCuocGoi != 1) return result;            
            //1. Tổng qua TT
            if (pTKe.XeDon.Length > 0) 
            {
                foreach (var item in pTKe.XeDon.Split('.'))
	            {
                    if (!BaoCaoThongKeDieuHanh.DicXeHoatDongQuaTT.ContainsKey(item) )//ko lap lai số xe => số xe hoạt động
                    {
                        result.TongXeQuaTrungTam = 1;
                        BaoCaoThongKeDieuHanh.DicXeHoatDongQuaTT.Add(item, item);
                    }
                    else
                    {
                        result.TongXeQuaTrungTam = 0;
                    }
	            }
            }
            //2. Tổng qua GPS
            //if (pTKe.XeDon.Length>0&&  pTKe.GPS_KinhDo > 0) result.TongQuaGPS = 10; else result.TongQuaGPS=0;//Đang tạm tính!
            //3. Tổng Cuốc 
            result.TongCuoc = 1;
            //4. Đón được ,trượt/hoãn và không xe
            string lenhDT = pTKe.LenhDienThoai.ToLower();
            string lenhTD = pTKe.LenhTongDai.ToLower();
            //5. Trượt hủy hoãn
            int trangThaiCG = pTKe.TrangThaiCuocGoi;
            int trangThaiLenh = pTKe.TrangThaiLenh;
            bool isTruotHoan = (trangThaiCG == 2 || trangThaiCG == 3 || (trangThaiCG == 5 && string.IsNullOrEmpty(pTKe.XeDon) && trangThaiLenh == 4));
            bool isKhongXe = (string.IsNullOrEmpty(pTKe.XeDon) && !(trangThaiCG == 2 || trangThaiCG == 3 || (trangThaiCG == 5 && string.IsNullOrEmpty(pTKe.XeDon) && trangThaiLenh == 4)));
            if (isTruotHoan) result.TruotHoan = 1;  else result.TruotHoan=0;
            if (isKhongXe)   result.KhongXe = 1;    else result.KhongXe=0;
            //7. Cuốc sảnh
            if (pTKe.LoaiDoiTacID == 2) result.CuocSanh = 1;else result.CuocSanh =0;
            //8. Đón được 
            //result.DonDuoc = result.TongCuoc - result.TruotHoan - result.KhongXe; 
            if (pTKe.XeDon.Length > 0) result.DonDuoc = 1; else result.DonDuoc=0;
            //9. Đón được thực tế
            result.DonDuocThucTe = result.DonDuoc-result.CuocSanh;
            //10. Tổng qua TT
            result.TongCuocQuaTT = 1-result.CuocSanh;
            //11. Vùng 1
            if(pTKe.Vung==1 && result.CuocSanh==0)result.Vung1 = 1;else result.Vung1=0;
            if (pTKe.Vung == 2 && result.CuocSanh==0) result.Vung2 = 1;else result.Vung2=0;
            if (pTKe.Vung == 3 &&result.CuocSanh==0) result.Vung3 = 1;else result.Vung3=0;
            if (pTKe.Vung == 4 &&result.CuocSanh==0) result.Vung4 = 1;else result.Vung4=0;            
            if (pTKe.G5_Type == 3)
            {
                result.TongSoCuocDieuQuaApp = 1;
                if(pTKe.XeDon.Length>0)result.SoCuocDonDuocTuApp = 1 ;else result.SoCuocDonDuocTuApp=0;
            } 
            else result.TongSoCuocDieuQuaApp = 0;
            //12.San bay goi qua TT
            if (pTKe.SanBay_DuongDai.Contains("1")) result.SanBayQuaTT = 1; else result.SanBayQuaTT = 0;//&& pTKe.MaDoiTac.Length == 0
            if (pTKe.SanBay_DuongDai.Contains("1")) result.NB_HN = 1; else result.NB_HN  = 0;
            if (pTKe.SourceType == 2) result.NB_DiChung = 1;else result.NB_DiChung=0;
            //13. Nhóm số cuốc 7 chỗ, Avante
            if (pTKe.G5_CarType==4||pTKe.G5_CarType==6) result.SoCuoc7Cho = 1;else result.SoCuoc7Cho=0;
            if (pTKe.XeDon.Length == 4 && pTKe.XeDon.StartsWith("2")) result.SoCuocAvante = 1; else result.SoCuocAvante = 0;
            //14. Nhóm khách đặt 
            if (lenhDT.Contains("khách đặt") && pTKe.SourceType != 1) result.KhachDat = 1; else result.KhachDat=0;
            if (pTKe.SourceType == 1) result.KhachDatOnline = 1;else result.KhachDatOnline=0;
            //
            int khachdatKhongDonDuoc = 0;
            if(lenhDT.Contains("khách đặt") && (lenhDT.Contains("hủy") || lenhDT.Contains("hoãn") || lenhDT.Contains("trượt") || lenhTD.Contains("hủy") ||
                 lenhTD.Contains("hoãn") || lenhTD.Contains("trượt")||lenhTD.Contains("ko xe")))
                khachdatKhongDonDuoc = 1;
            result.KhachDatDonDuoc = result.KhachDat - khachdatKhongDonDuoc;
            //15. Nhóm hoa hồng!            
            if (pTKe.Ma_DoiTac.Length > 0 && !BaoCaoThongKeDieuHanh.DicMaDoiTac.ContainsKey(pTKe.MaDoiTac) && pTKe.KieuKhachHangGoiDen == 2)//ko lap lai ma doi tac=> số điểm hoa hồng!
            {
                result.SoDiemHoaHongGoiDen = 1;
                BaoCaoThongKeDieuHanh.DicMaDoiTac.Add(pTKe.MaDoiTac,pTKe.MaDoiTac);
            }
            else
            {
                result.SoDiemHoaHongGoiDen = 0;
            }
            if (pTKe.Ma_DoiTac.Length > 0 && pTKe.KieuKhachHangGoiDen==2) result.SoCuocTuDiemHoaHong = 1;else result.SoCuocTuDiemHoaHong=0;
            if (pTKe.Ma_DoiTac.Length > 0 && pTKe.KieuKhachHangGoiDen == 2 && result.TruotHoan == 0 && result.KhongXe == 0)
                result.SoCuocDiemHoaHongDonDuoc = 1;
            else result.SoCuocDiemHoaHongDonDuoc = 0;
            //16. Tính toán các tỷ lệ ở trong FillCell!
            return result;
        }
        public static Summary ToSummaryGPS(this TKePhongDieuHanhInfo pTKe)
        {
            var result = new Summary();
            foreach (var item in pTKe.XeDon.Split('.'))
            {
                if (!BaoCaoThongKeDieuHanh.DicXeHoatDongQuaGPS.ContainsKey(item))//ko lap lai số xe => số xe hoạt động
                {
                    result.TongXeQuaGPS = 1;
                    BaoCaoThongKeDieuHanh.DicXeHoatDongQuaGPS.Add(item, item);
                }
                else
                {
                    result.TongXeQuaTrungTam = 0;
                }
            }
            result.KhachQuaGPS = 1;
            return result;
        }
    }

    /// <summary>
    /// Dùng để chứa dữ liệu chung để lọc GroupBy lấy lên từ DB!
    /// </summary>
    public class TKePhongDieuHanhInfo
    {
        public string ID { get; set; }
        public string MaDoiTac { get; set; }//Dùng để lấy điểm hoa hồng!
        public string Ma_DoiTac { get; set; }
        public string Name { get; set; }
        public DateTime ThoiDiemGoi { get; set; }
        public string XeDon { get; set; }
        public int KieuCuocGoi { get; set; }

        public double GPS_KinhDo { get; set; }

        public int LoaiDoiTacID { get; set; }//Dung de lay cuoc sanh!        
        public int SourceType { get; set; }

        public string LenhDienThoai { get; set; }//Dung de lay cuoc huy/hoan khách đặt
        public string LenhTongDai { get; set; }
        public int TrangThaiCuocGoi { get; set; }
        public int TrangThaiLenh { get; set; }
        public int KieuKhachHangGoiDen { get; set; }
        public int Vung { get; set; }
        public int G5_Type { get; set; }
        public int G5_CarType { get; set; }
        public string SanBay_DuongDai { get; set; }
    }

    public class DataByDay  
    {
        public int Day { get; set; }
        public Summary Summary { get; set; }
        public string MaCuoc { get; set; } 
    }

    public class SanhDienThoai
    {
        public string MaDoiTac { get; set; }
        public string Name { get; set; }
        public int LoaiDoiTacID { get; set; }
        public int SoCuoc { get; set; }
    }

    public class SummaryGPS
    {
        public int XeHoatDongGps { get; set; }
        public int CuocGPS { get; set; }
    }
}
