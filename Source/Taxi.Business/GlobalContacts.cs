using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading;
using Taxi.Utils;

namespace Taxi.Business
{
    /// <summary>
    /// Chứa thông tin địa chỉ của các danh mục
    /// </summary>
    public class GlobalContacts
    {
        #region init
        /// <summary>
        /// Chứa thông tin danh bạ công ty, khách ảo
        /// </summary>
        private ConcurrentDictionary<string, DanhBaEx> dicDanhBaCongTy = new ConcurrentDictionary<string, DanhBaEx>();
        /// <summary>
        /// Chứa thông tin danh bạ bưu điện
        /// </summary>
        private ConcurrentDictionary<string, DanhBaEx> dicDanhBa_BuuDien = new ConcurrentDictionary<string, DanhBaEx>();
        /// <summary>
        /// Chứa thông tin danh bạ các điểm môi giới
        /// </summary>
        private ConcurrentDictionary<string, DanhBaEx> dicMoiGioi = new ConcurrentDictionary<string, DanhBaEx>();
        /// <summary>
        /// Chứa thông tin danh bạ các cuộc gọi gần đây
        /// </summary>
        private ConcurrentDictionary<string, DanhBaEx> dicCuocOnline = new ConcurrentDictionary<string, DanhBaEx>();
        /// <summary>
        /// Chứa thông tin danh bạ khách quen
        /// </summary>
        private ConcurrentDictionary<string, DanhBaEx> dicKhachQuen = new ConcurrentDictionary<string, DanhBaEx>();

        private BackgroundWorker bwSync_LoadDanhBaBuuDien = new BackgroundWorker();
        private BackgroundWorker bwSync_LoadDanhBaKhachQuen = new BackgroundWorker();
        private BackgroundWorker bwSync_LoadDanhBaMoiGioi = new BackgroundWorker();
        //private BackgroundWorker bwSync_LoadDanhBaCongTy = new BackgroundWorker();
        //private BackgroundWorker bwSync_LoadDanhBaCuocGoi = new BackgroundWorker();
        private System.Timers.Timer G_TimerCapture = null;
        private DateTime g_ThoiDiemLayTruoc_KhachHang;
        private DateTime g_ThoiDiemLayTruoc_DoiTac;
        private DateTime g_ThoiDiemLayTruoc_CongTy;


        #endregion

        #region Load
        public GlobalContacts()
        {
            try
            {                
                bwSync_LoadDanhBaBuuDien.DoWork += bwSync_LoadDanhBaBuuDien_DoWork;
                bwSync_LoadDanhBaKhachQuen.DoWork += bwSync_LoadDanhBaKhachQuen_DoWork;

                g_ThoiDiemLayTruoc_KhachHang = DateTime.Now;
                g_ThoiDiemLayTruoc_DoiTac = DateTime.Now;
                g_ThoiDiemLayTruoc_CongTy = DateTime.Now;

                G_TimerCapture = new System.Timers.Timer(1000);
                G_TimerCapture.Elapsed += timerCapture_Elapsed;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GlobalContacts Init:", ex);
            }
        }
        /// <summary>
        /// Load danh bạ
        /// </summary>
        public bool LoadGlobalContacts()
        {
            KhoiTaoCuocKhachOnlineLenMEM();

            KhoiTaoDanhBaOnMEM();

            bwSync_LoadDanhBaKhachQuen.RunWorkerAsync();

            //bwSync_LoadDanhBaBuuDien.RunWorkerAsync();

            G_TimerCapture.Enabled = true;
            G_TimerCapture.Start();
            return true;
        }

        #endregion

        #region Load Danh Bạ

        /// <summary>
        /// Load danh sách  cuộc gọi gần đây
        /// </summary>
        private void KhoiTaoCuocKhachOnlineLenMEM()
        {
            try
            {
                dicCuocOnline.Clear();
                DataTable dt = new Data.CuocGoi().GetCuocOnlines_v2();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        DanhBaEx dicRet = new DanhBaEx();
                        string soDienThoai = dr["PhoneNumber"] == DBNull.Value ? string.Empty : dr["PhoneNumber"].ToString();
                        string diaChi = dr["DiaChiDonKhach"] == DBNull.Value ? string.Empty : dr["DiaChiDonKhach"].ToString();
                        if (soDienThoai != string.Empty && diaChi != string.Empty)
                        {
                            if (dicCuocOnline.ContainsKey(soDienThoai)) continue;

                            string diaChiTra = dr["DiaChiTraKhach"] == DBNull.Value ? string.Empty : dr["DiaChiTraKhach"].ToString();
                            int vung = dr["Vung"] == DBNull.Value ? 0 : int.Parse(dr["Vung"].ToString());
                            string maDoiTac = dr["MaDoiTac"] == DBNull.Value ? string.Empty : dr["MaDoiTac"].ToString();
                            string loaiXe = dr["LoaiXe"] == DBNull.Value ? string.Empty : dr["LoaiXe"].ToString();
                            float kinhDo = dr["GPS_KinhDo"] == DBNull.Value ? 0 : float.Parse(dr["GPS_KinhDo"].ToString());
                            float viDo = dr["GPS_ViDo"] == DBNull.Value ? 0 : float.Parse(dr["GPS_ViDo"].ToString());
                            string lenhDienThoai = dr["LenhDienThoai"] == DBNull.Value ? string.Empty : dr["LenhDienThoai"].ToString();
                            string GhiChuDienThoai = dr["GhiChuDienThoai"] == DBNull.Value ? string.Empty : dr["GhiChuDienThoai"].ToString();
                            DateTime ThoiDiemGoi = dr["ThoiDiemGoi"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(dr["ThoiDiemGoi"].ToString());
                            long ID = dr["ID"] == DBNull.Value ? 0 : long.Parse(dr["ID"].ToString());
                            int SoLanGoi = dr["SoLanGoi"] == DBNull.Value ? 0 : int.Parse(dr["SoLanGoi"].ToString());
                            int KieuKHGoiDen = dr["KieuKhachHangGoiDen"] == DBNull.Value ? 0 : int.Parse(dr["KieuKhachHangGoiDen"].ToString());

                            dicRet.Address = diaChi;
                            dicRet.PhoneNumber = soDienThoai;
                            dicRet.Vung = vung;
                            dicRet.MaDoiTac = maDoiTac;
                            dicRet.LoaiXe = loaiXe;
                            dicRet.Address_Destination = diaChiTra;
                            dicRet.GPS_KinhDo = kinhDo;
                            dicRet.GPS_ViDo = viDo;
                            dicRet.LenhTiepNhan = lenhDienThoai;
                            dicRet.GhiChuTiepNhan = GhiChuDienThoai;
                            dicRet.SoLanGoi = SoLanGoi;
                            dicRet.IdCuocGoi = ID;
                            dicRet.ThoiDiemGoi = ThoiDiemGoi;
                            try
                            {
                                dicRet.KieuKHGoiDen = (KieuKhachHangGoiDen)KieuKHGoiDen;
                            }
                            catch
                            {
                                dicRet.KieuKHGoiDen = KieuKhachHangGoiDen.KhachHangBinhThuong;
                            }
                            dicCuocOnline.TryAdd(soDienThoai, dicRet);
                            if (Global.IsDebug)
                                LogError.WriteLogInfo("KhoiTaoCuocKhachOnlineLenMEM:" + soDienThoai + "-" + dicRet.Address);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("KhoiTaoCuocKhachOnlineLenMEM.", ex);
            }
        }
        
        #region Load danh bạ khách quen
        private void bwSync_LoadDanhBaKhachQuen_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                List<DanhBaEx> lstKhachVip = DanhBaKhachQuen.GetAllKhachQuens_V2();
                if (lstKhachVip != null && lstKhachVip.Count > 0)
                {                    
                    DanhBaEx dicRet = new DanhBaEx();
                    foreach (DanhBaEx item in lstKhachVip)
                    {                        
                        if (dicKhachQuen.ContainsKey(dicRet.PhoneNumber)) continue;
                        dicKhachQuen.TryAdd(dicRet.PhoneNumber, dicRet);
                        if (Global.IsDebug)
                            LogError.WriteLogInfo("bwSync_LoadDanhBaKhachQuen_DoWork:" + dicRet.PhoneNumber + "-" + dicRet.Address);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("bwSync_LoadDanhBaKhachQuen_DoWork.", ex);
            }
        }
        private void KhoiTaoDanhBaOnMEM_KhachHang_GetLast(DateTime LastUpdate)
        {
            try
            {
                List<DanhBaEx> lstKhachVip = DanhBaKhachQuen.GetKhachQuens_LastUpdate_V2(LastUpdate);
                if (lstKhachVip != null && lstKhachVip.Count > 0)
                {
                    g_ThoiDiemLayTruoc_KhachHang = DateTime.Now;
                    foreach (var item in lstKhachVip)
                    {
                        if (dicKhachQuen.ContainsKey(item.PhoneNumber))
                        {
                            dicKhachQuen[item.PhoneNumber] = item;
                        }
                        else
                        {
                            dicKhachQuen.TryAdd(item.PhoneNumber, item);
                        }
                        if (Global.IsDebug)
                            LogError.WriteLogInfo("KhoiTaoDanhBaOnMEM_KhachHang_GetLast:" + item.PhoneNumber + "-" + item.Address);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("KhoiTaoDanhBaOnMEM_KhachHang_GetLast.", ex);
            }
        }

        #endregion

        #region Load danh bạ đối tác
        
        private void KhoiTaoDanhBaOnMEM_DoiTac_GetLast(DateTime LastUpdate)
        {
            try
            {
                List<DanhBaEx> listDBMoiGioi = DanhBaEx.GetDanhBaMoiGioi_LastUpdate(LastUpdate);
                if (dicMoiGioi == null) dicMoiGioi = new ConcurrentDictionary<string, DanhBaEx>();
                foreach (DanhBaEx dbex in listDBMoiGioi)
                {
                    DanhBaEx dbexOut = new DanhBaEx();
                    if (!dicMoiGioi.ContainsKey(dbex.PhoneNumber))
                    {
                        if (dbex.IsActive)
                            dicMoiGioi.TryAdd(dbex.PhoneNumber, dbex);
                        else
                            dicMoiGioi.TryRemove(dbex.PhoneNumber, out dbexOut);
                    }
                    else
                    {
                        if (dbex.IsActive)
                            dicMoiGioi[dbex.PhoneNumber] = dbex;
                    }
                    if (Global.IsDebug)
                        LogError.WriteLogInfo("KhoiTaoDanhBaOnMEM_DoiTac_GetLast:" + dbex.PhoneNumber + "-" + dbex.Address);
                    
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("KhoiTaoDanhBaOnMEM_DoiTac_GetLast.", ex);
            }
        }
        #endregion

        #region Load Danh bạ công ty

        /// <summary>
        /// Load danh bạ công ty, khách ảo
        /// </summary>
        private void KhoiTaoDanhBaOnMEM()
        {
            try
            {
                List<DanhBaEx> listDBMoiGioi = DanhBaEx.GetDanhBaMoiGioi();
                if (dicMoiGioi == null) dicMoiGioi = new ConcurrentDictionary<string, DanhBaEx>();
                foreach (DanhBaEx dbex in listDBMoiGioi)
                {
                    if (!dicMoiGioi.ContainsKey(dbex.PhoneNumber))
                    {
                        dicMoiGioi.TryAdd(dbex.PhoneNumber, dbex);
                    }
                }

                List<DanhBaEx> listDBCongTy = new List<DanhBaEx>();
                listDBCongTy = DanhBaEx.GetDanhBaCongTy();
                foreach (DanhBaEx dbcty in listDBCongTy)
                {
                    if (!dicDanhBaCongTy.ContainsKey(dbcty.PhoneNumber))
                    {
                        dicDanhBaCongTy.TryAdd(dbcty.PhoneNumber, dbcty);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("KhoiTaoDanhBaOnMEM: ",ex);                
            }
        }
        private void KhoiTaoDanhBaOnMEM_CongTy_GetLast(DateTime LastUpdate)
        {
            try
            {
                List<DanhBaEx> listDBCongTy = new List<DanhBaEx>();
                listDBCongTy = DanhBaEx.GetDanhBaCONGTY_GetLast(LastUpdate);
                // thêm vào dic
                foreach (DanhBaEx dbcty in listDBCongTy)
                {
                    // chưa tồn tài thì thêm vào ds
                    if (!dicDanhBaCongTy.ContainsKey(dbcty.PhoneNumber))
                    {
                        dicDanhBaCongTy.TryAdd(dbcty.PhoneNumber, dbcty);
                    }
                    else
                    {
                        dicDanhBaCongTy[dbcty.PhoneNumber] = dbcty;
                    }
                    if (Global.IsDebug)
                        LogError.WriteLogInfo("KhoiTaoDanhBaOnMEM_CongTy_GetLast:" + dbcty.PhoneNumber + "-" + dbcty.Address);
                    
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("KhoiTaoDanhBaOnMEM_CongTy_GetLast.", ex);                
            }
        }
        #endregion

        #region Load Danh Bạ Bưu Điện
        private void bwSync_LoadDanhBaBuuDien_DoWork(object sender, DoWorkEventArgs e)
        {
            //if (IsLoadSuccess)
            {
                KhoiTaoDanhBaBuuDien1();
            }
            Thread.Sleep(1000);
            //if (IsLoadSuccess)
            {
                KhoiTaoDanhBaBuuDien2();
            }
            Thread.Sleep(1000);
            //if (IsLoadSuccess)
            {
                KhoiTaoDanhBaBuuDien3();
            }
            Thread.Sleep(1000);
            //if (IsLoadSuccess)
            {
                KhoiTaoDanhBaBuuDien4();
            }
            Thread.Sleep(1000);
            //if (IsLoadSuccess)
            {
                KhoiTaoDanhBaBuuDien5();
            }
        }

        private void KhoiTaoDanhBaBuuDien1()
        {
            lock (dicDanhBa_BuuDien)
            {
                // lấy ds danh ba buu dien
                List<DanhBaCongTy> listDBBuuDien = new List<DanhBaCongTy>();
                listDBBuuDien = DanhBa.GetDanhBa_BuuDien_1();
                // thêm vào dic
                foreach (DanhBaCongTy dbbd in listDBBuuDien)
                {
                    // chưa tồn tài thì thêm vào ds
                    if (!dicDanhBa_BuuDien.ContainsKey(dbbd.PhoneNumber))
                    {
                        dicDanhBa_BuuDien.TryAdd(dbbd.PhoneNumber, new DanhBaEx() { PhoneNumber = dbbd.PhoneNumber, Address = dbbd.Address, IsActive = true, Name = dbbd.Name, KieuDanhBa = KieuDanhBa.BuuDien });
                    }
                }
            }
        }

        private void KhoiTaoDanhBaBuuDien2()
        {
            lock (dicDanhBa_BuuDien)
            {
                // lấy ds danh ba buu dien
                List<DanhBaCongTy> listDBBuuDien = new List<DanhBaCongTy>();
                listDBBuuDien = DanhBa.GetDanhBa_BuuDien_2();
                // thêm vào dic
                foreach (DanhBaCongTy dbbd in listDBBuuDien)
                {
                    // chưa tồn tài thì thêm vào ds
                    if (!dicDanhBa_BuuDien.ContainsKey(dbbd.PhoneNumber))
                    {
                        dicDanhBa_BuuDien.TryAdd(dbbd.PhoneNumber, new DanhBaEx() { PhoneNumber = dbbd.PhoneNumber, Address = dbbd.Address, IsActive = true, Name = dbbd.Name, KieuDanhBa = KieuDanhBa.BuuDien });
                    }
                }
            }
        }

        private void KhoiTaoDanhBaBuuDien3()
        {
            lock (dicDanhBa_BuuDien)
            {
                // lấy ds danh ba buu dien
                List<DanhBaCongTy> listDBBuuDien = new List<DanhBaCongTy>();
                listDBBuuDien = DanhBa.GetDanhBa_BuuDien_3();
                // thêm vào dic
                foreach (DanhBaCongTy dbbd in listDBBuuDien)
                {
                    // chưa tồn tài thì thêm vào ds
                    if (!dicDanhBa_BuuDien.ContainsKey(dbbd.PhoneNumber))
                    {
                        dicDanhBa_BuuDien.TryAdd(dbbd.PhoneNumber, new DanhBaEx() { PhoneNumber = dbbd.PhoneNumber, Address = dbbd.Address, IsActive = true, Name = dbbd.Name, KieuDanhBa = KieuDanhBa.BuuDien });
                    }
                }
            }
        }

        private void KhoiTaoDanhBaBuuDien4()
        {
            lock (dicDanhBa_BuuDien)
            {
                // lấy ds danh ba buu dien
                List<DanhBaCongTy> listDBBuuDien = new List<DanhBaCongTy>();
                listDBBuuDien = DanhBa.GetDanhBa_BuuDien_4();
                // thêm vào dic
                foreach (DanhBaCongTy dbbd in listDBBuuDien)
                {
                    // chưa tồn tài thì thêm vào ds
                    if (!dicDanhBa_BuuDien.ContainsKey(dbbd.PhoneNumber))
                    {
                        dicDanhBa_BuuDien.TryAdd(dbbd.PhoneNumber, new DanhBaEx() { PhoneNumber = dbbd.PhoneNumber, Address = dbbd.Address, IsActive = true, Name = dbbd.Name, KieuDanhBa = KieuDanhBa.BuuDien });
                    }
                }
            }
        }

        private void KhoiTaoDanhBaBuuDien5()
        {
            lock (dicDanhBa_BuuDien)
            {
                // lấy ds danh ba buu dien
                List<DanhBaCongTy> listDBBuuDien = new List<DanhBaCongTy>();
                listDBBuuDien = DanhBa.GetDanhBa_BuuDien_5();
                // thêm vào dic
                foreach (DanhBaCongTy dbbd in listDBBuuDien)
                {
                    // chưa tồn tài thì thêm vào ds
                    if (!dicDanhBa_BuuDien.ContainsKey(dbbd.PhoneNumber))
                    {
                        dicDanhBa_BuuDien.TryAdd(dbbd.PhoneNumber, new DanhBaEx() { PhoneNumber = dbbd.PhoneNumber, Address = dbbd.Address, IsActive = true, Name = dbbd.Name, KieuDanhBa = KieuDanhBa.BuuDien });
                    }
                }
            }
        }
        #endregion

        #endregion

        #region Timer
        private int g_iCount_GetCuocGoi = 0;
        private int g_iCount_GetDanhBa = 0;
        void timerCapture_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                g_iCount_GetCuocGoi++;
                if (g_iCount_GetCuocGoi >= 60)
                {
                    KhoiTaoCuocKhachOnlineLenMEM();
                    g_iCount_GetCuocGoi = 0;
                }
                g_iCount_GetDanhBa++;
                if (g_iCount_GetDanhBa >= 300) // 5phut
                {
                    KhoiTaoDanhBaOnMEM_KhachHang_GetLast(g_ThoiDiemLayTruoc_KhachHang);
                    KhoiTaoDanhBaOnMEM_DoiTac_GetLast(g_ThoiDiemLayTruoc_DoiTac);
                    KhoiTaoDanhBaOnMEM_CongTy_GetLast(g_ThoiDiemLayTruoc_CongTy);

                    g_iCount_GetDanhBa = 0;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Loi trong timer.", ex);
            }
        }
        #endregion

        #region GetInfo
        public DanhBaEx GetGlobalContacsInfo(string phoneNumber)
        {
            DanhBaEx item = new DanhBaEx();
            try
            {
                 
                if (Global.IsDebug)
                    LogError.WriteLogInfo("GetGlobalContacsInfo:" + phoneNumber);


                if (dicMoiGioi.ContainsKey(phoneNumber))
                {
                    item = dicMoiGioi[phoneNumber];
                    if (Global.IsDebug)
                        LogError.WriteLogInfo("dicMoiGioi:" + phoneNumber + "-" + item.Address);
                    return item;
                }
                // lấy từ cuốc online 
                //lock (dicCuocOnline)
                //{
                    if (dicCuocOnline.ContainsKey(phoneNumber))
                    {
                        item = dicCuocOnline[phoneNumber];
                        if (Global.IsDebug)
                            LogError.WriteLogInfo("dicCuocOnline:" + dicCuocOnline.Count.ToString() + "-" + dicCuocOnline[phoneNumber].PhoneNumber + "-" + item.PhoneNumber + "-" + " - " + phoneNumber + item.Address);
                        return dicCuocOnline[phoneNumber];
                    }
                //}

                if (dicKhachQuen.ContainsKey(phoneNumber))
                {
                    item = dicKhachQuen[phoneNumber];
                    if (Global.IsDebug)
                        LogError.WriteLogInfo("dicKhachQuen:" + phoneNumber + "-" + item.Address);
                    return item;
                }

                // lấy theo danh bạ
                if (dicDanhBaCongTy.ContainsKey(phoneNumber))
                {
                    item = dicDanhBaCongTy[phoneNumber];
                    if (Global.IsDebug)
                        LogError.WriteLogInfo("dicDanhBaCongTy:" + phoneNumber + "-" + item.Address);
                    return item;
                }
                //if (soDienThoai.StartsWith("04"))
                //{
                //    //Nếu là số điện thoại bàn ở HN thì mới check trong danh mục Bưu Điện.
                //    if (dicDanhBa_BuuDien.ContainsKey(soDienThoai))
                //    {
                //        item = dicDanhBa_BuuDien[soDienThoai];
                //        diaChi = item.Address;
                //        if (item.Name != "")
                //            diaChi = string.Format("[{0}]{1}", item.Name, diaChi);

                //        kieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                //    }
                //}
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetGlobalContacsInfo.", ex);
                return item;
            }
            return item;
        }
        #endregion

    }
}
