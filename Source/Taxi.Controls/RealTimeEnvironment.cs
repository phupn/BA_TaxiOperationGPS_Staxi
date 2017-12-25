using Femiani.Forms.UI.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Business.QuanTri;
using Taxi.Entity;
using Taxi.Utils;
using Taxi.Common.Extender;
using Taxi.Data.G5.DanhMuc;
using Taxi.Business.DM;
using System.ComponentModel;
namespace Taxi.Controls
{
    /// <summary>
    /// Giúp tổ chức dữ liệu tập trung và có xử lý dữ liệu thời gian thực giúp cho hệ thống.
    /// </summary>
    public static class RealTimeEnvironment
    {

        static BackgroundWorker bw_LoadInitData = new BackgroundWorker();
        #region === RealTime === 
        private static int Step5 = 0;//5s
        private static int Step10 = 0;//10s
        private static int Step60 = 0;//60s
        private static Timer Timer_RealTime = new Timer();
        /// <summary>
        /// Khởi tạo dữ liệu cấu hình và timer để xử lý RealTime
        /// </summary>
        public static void IniRealTime()
        {
            try
            {
                Timer_RealTime.Tick += Timer_RealTime_Tick;
                Timer_RealTime.Interval = 1000;
                TimeServer = CommonBL.GetTimeServer();
                bw_LoadInitData.DoWork += bw_LoadInitData_DoWork;
                bw_LoadInitData.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("IniRealTime", ex);
            }
           
        }

        private static void LoadDataCommon()
        {
            Config_Common.LoadConfigCommon();
            ThongTinCauHinh.LayThongTinCauHinh();
            CommonBL.LoadDrivers_Active();
            CommonBL.LoadVehicles();
            
            //CommonBL.LoadStaxiLoaiXe();
            if (Config_Common.NhapTuyenDuongDai || Config_Common.App_DieuXeHopDong)
                CommonBL.LoadTuyenDuongDai();
            try
            {
                using (DataTable dt = QuanTriCauHinh.G5_GetLines_LoaiXeOfPCDienThoai(IpAddress))
                {
                    if (dt.Rows != null && dt.Rows.Count > 0)
                    {
                        LineVung = dt.Rows[0]["Line_Vung"].ToString();

                        if (Config_Common.DienThoai_DieuTuDong)
                        {
                            Config_Common.DienThoai_DieuTuDong = dt.Columns.Contains("G5_Type") &&
                                                                 dt.Rows[0]["G5_Type"].ToString() == "1";
                        }
                        Config_Common.G5_PinMap = dt.Columns.Contains("G5_PinMap") &&
                                                                 dt.Rows[0]["G5_PinMap"].ToString() == "1";

                        if (Config_Common.GopLine || ThongTinCauHinh.GopKenh_TrangThai)
                            LineGop = dt.Rows[0]["LineGop"] == DBNull.Value
                                ? LineVung
                                : dt.Rows[0]["LineGop"].ToString();
                        QuanTriCauHinh.MoHinh = dt.Columns.Contains("MoHinh") && dt.Rows[0]["MoHinh"] != DBNull.Value && (string)dt.Rows[0]["MoHinh"] != "" && (string)dt.Rows[0]["MoHinh"] != "0" ? (MoHinh)dt.Rows[0]["MoHinh"].To<int>() : MoHinh.TD_DT;
                    }
                    else
                    {
                        LineVung = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetLines_LoaiXeOfPCDienThoai", ex);
            }
        }

        static void bw_LoadInitData_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                LoadDataCommon();
                Timer_RealTime.Start();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("RealTimeEnvironment IniRealTime", ex);
            }
        }

        static void Timer_RealTime_Tick(object sender, EventArgs e)
        {
            try
            {
                TimeServer = TimeServer.AddSeconds(1);
                Step10++;
                Step60++;
                Step5++;
                if (Step5 > 5)
                {
                    Task.Factory.StartNew(() =>
                    {
                        //Viết các hàm xử lý vào đây.
                    });
                    Step5 = 0;
                }
                if (Step10 > 10)
                {
                    Task.Factory.StartNew(() =>
                    {
                        CommonBL.LoadDrivers_Active_LastUpdate();
                        CommonBL.LoadVehicles_Active_LastUpdate();
                        Config_Common.LoadConfigCommonByLastUpdate();
                    });
                    Step10 = 0;
                }
                if (Step60 > 60)
                {
                    Task.Factory.StartNew(() =>
                    {
                        //Viết các hàm xử lý vào đây.
                    });
                    Step60 = 0;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Timer_RealTime_Tick", ex);
            }
        }

        #endregion === RealTime ===
        
        /// <summary>
        /// Giúp kiểm soát tình trạng logout của hệ thống
        /// </summary>
        public static bool IsLogin { get; set; }
        private static string ipAddress;
        /// <summary>
        /// Lấy địa chỉ IP Trong mạng Lan.
        /// </summary>
        public static string IpAddress { get { if (string.IsNullOrEmpty(ipAddress)) { ipAddress = QuanTriCauHinh.GetIPPC(); } return ipAddress; }  }
        public static string LineVung { get; set; }
        /// <summary>
        /// LineGop Khi đến thời điểm Line Vùng Xe gộp thì sẽ xử lý
        /// </summary>
        public static string LineGop { get; set; }
        /// <summary>
        /// Thời gian của server.
        /// Được lấy lúc đầu và tăng 1s theo chu kỳ của timer.
        /// </summary>

        public static DateTime TimeServer = DateTime.Now;

        public static AutoCompleteEntryCollection listDataAutoComplete_HN;
        private static AutoCompleteEntryCollection listDataAutoComplete;
        public static AutoCompleteEntryCollection ListDataAutoComplete
        {
            get
            {
                if (listDataAutoComplete == null || listDataAutoComplete.Count==0)
                {
                    try
                    {
                        listDataAutoComplete_HN = new AutoCompleteEntryCollection();
                        listDataAutoComplete = new AutoCompleteEntryCollection();
                        string address = "";
                        string streetAbbr = "";
                        float kd = 0;
                        float vd = 0;

                        using (var dt = new DiaDanh().GetRoadData_Autocomplete())
                        {
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    address = row["Street"].ToString();
                                    streetAbbr = row["StreetAbbr"].ToString();
                                    kd = float.Parse(row["KinhDo"].ToString());
                                    vd = float.Parse(row["ViDo"].ToString());

                                    listDataAutoComplete.Add(new AutoCompleteEntry(address, kd, vd, streetAbbr));
                                    if (ThongTinCauHinh.GPS_TenTinh == "Hà Nội" || ThongTinCauHinh.GPS_TenTinh == "Ha Noi")
                                    {
                                        listDataAutoComplete_HN.Add(new AutoCompleteEntry(address + "," + ThongTinCauHinh.GPS_TenTinh, kd, vd, streetAbbr));
                                        
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogError.WriteLogError("ListDataAutoComplete", ex);
                    }
                    
                }

                return listDataAutoComplete;
            }
            set
            {
                listDataAutoComplete = value;
            }
        }
        private static List<DMVung_GPSEntity> _DMVung_GPS;
        public static List<DMVung_GPSEntity> DMVung_GPS
        {
            get
            {
                if (_DMVung_GPS == null || _DMVung_GPS.Count==0)
                {
                    _DMVung_GPS = new DMVung_GPS().GetAllDSVungKenh();
                }
                return _DMVung_GPS;
            }
        }

        private static Dictionary<int, List<KeyValuePair<float, float>>> vungToaDo;
        public static Dictionary<int, List<KeyValuePair<float, float>>> VungToaDo
        {
            get
            {
                if (vungToaDo == null)
                {
                    vungToaDo = new Dictionary<int, List<KeyValuePair<float, float>>>();
                    if (DMVung_GPS != null)
                    {
                        try
                        {
                            foreach (var item in DMVung_GPS)
                            {
                                vungToaDo.Add(item.KenhVung, item.ToaDoVung.Split('-').Select(p =>
                                {
                                    var pi = p.Split(';');
                                    float vd = 0;
                                    float kd = 0;
                                    if (
                                        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat
                                            .CurrencyDecimalSeparator == ",")
                                    {
                                        //Thay thế '.' => ','
                                        pi[0] = pi[0].Replace('.', '#');
                                        pi[0] = pi[0].Replace(',', '.');
                                        pi[0] = pi[0].Replace('#', ',');

                                        pi[1] = pi[1].Replace('.', '#');
                                        pi[1] = pi[1].Replace(',', '.');
                                        pi[1] = pi[1].Replace('#', ',');
                                    }
                                    float.TryParse(pi[0], out vd);
                                    float.TryParse(pi[1], out kd);
                                    return new KeyValuePair<float, float>(kd, vd);
                                }).ToList());
                            }
                        }
                        catch (Exception ex)
                        {
                            LogError.WriteLogError("RealTimeEnvironment.VungToaDo", ex);
                        }

                    }
                }
                return vungToaDo;
            }
        }
        
        private static List<G5Command> dicCommand;

        public static List<G5Command> DicCommand
        {
            get
            {
                if (dicCommand == null)
                    dicCommand = G5Command.GetAllToList().OrderBy(p=>p.OrderBy).ToList();
                return dicCommand;
            }
        }
        private static List<CommandModule> dicCommandModule;

        public static List<CommandModule> DicCommandModule
        {
            get
            {
                if (dicCommandModule == null)
                    dicCommandModule = CommandModule.Inst.GetCommandByModule((int)Global.Module); 
                return dicCommandModule;
            }
        }
        public static void ResetCommand()
        {
            dicCommandModule = null;
            dicCommand = null;
        }
        public static void ResetData()
        {
            listDataAutoComplete = null;
            _DMVung_GPS = null;
            vungToaDo = null;
            dicCommandModule = null;
            dicCommand = null;
        }
    }
}

