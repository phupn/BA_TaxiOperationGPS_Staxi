using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Taxi.Utils;

namespace Taxi.Business
{

    public class DanhBaKhachQuen
    {
        #region Members
        //private int iMaKH;

        //public int IMaKH
        //{
        //    get { return iMaKH; }
        //    set { iMaKH = value; }
        //}

        private string _MaKH;
        public string MaKH
        {
            get { return _MaKH; }
            set { _MaKH = value; }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        private string _PhoneNumber;
        public string Phones
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }

        private string _Fax;
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private DateTime _BirthDay;
        public DateTime BirthDay
        {
            get { return _BirthDay; }
            set { _BirthDay = value; }
        }

        public string SinhNgay
        {
            get { return string.Format("{0}/{1}", StringTools.GeMonthString(_BirthDay.Month), StringTools.GeDayString(_BirthDay.Day)); }
        }

        public int SinhThang
        {
            get { return _BirthDay.Month; }
        }

        private string _Notes;
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }

        private bool _IsActive;
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        private int _Type;
        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private int _Rank;
        public int Rank
        {
            get { return _Rank; }
            set { _Rank = value; }
        }

        private string _TypeName;
        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value; }
        }

        private string _RankName;
        public string RankName
        {
            get { return _RankName; }
            set { _RankName = value; }
        }

        public float KinhDo { get; set; }
        public float ViDo { get; set; }
        #endregion

        #region Contructor
        public DanhBaKhachQuen()
        {
            _PhoneNumber = string.Empty;
            _Name = string.Empty;
            _Address = string.Empty;
            _BirthDay = new DateTime(2000, 01, 01);
            _Email = string.Empty;
            _Fax = string.Empty;
            _MaKH = string.Empty;
            _IsActive = false;
            _Notes = string.Empty;
            _Rank = 0;
            _Type = 0;
            KinhDo = 0;
            ViDo = 0;
        }
        public DanhBaKhachQuen(string phoneNumber
                                , string name
                                , string address
                                , DateTime birthday
                                , string email
                                , string fax
                                , string maKH
                                , bool isActive
                                , string notes
                                , int rank
                                , int type)
        {
            _PhoneNumber = phoneNumber;
            _Name = name;
            _Address = address;
            _BirthDay = birthday;
            _Email = email;
            _Fax = fax;
            _MaKH = maKH;
            _IsActive = isActive;
            _Notes = notes;
            _Rank = rank;
            _Type = type;
            KinhDo = 0;
            ViDo = 0;
        }
        #endregion Contructor

        #region Methods

        public bool Insert()
        {
            try
            {
                return new Data.DanhBaKhachQuen().Insert(this.MaKH, this.Phones, this.Name, this.Address, this.BirthDay,
                    this.Email, this.Fax, this.IsActive, this.Notes, this.Rank, this.Type);
            }
            catch (Exception ex) {
                LogError.WriteLogError("DanhBaKhachQuen.Insert",ex);
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                return new Data.DanhBaKhachQuen().Update(this.MaKH, this.Phones, this.Name, this.Address, this.BirthDay, this.Email, this.Fax, this.IsActive, this.Notes, this.Rank, this.Type);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("DanhBaKhachQuen.Insert", ex);
                return false;
            }
            
        }


        /// <summary>
        /// Tra ve dia chi cua so dien thoai 
        /// </summary>
        public static string GetAddress(string PhoneNumber)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = new Data.DanhBaKhachQuen().GetAddress_Phones(PhoneNumber);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["Address"].ToString();
                }
                dt.Dispose();
                dt = null;
                return string.Empty;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetAddress: ",ex);
                return string.Empty;
            }
        }

        public static DanhBaKhachQuen GetKhachQuen_Row(DataRow dr)
        {
            try
            {
                DanhBaKhachQuen objKhachQuen = new DanhBaKhachQuen();
                objKhachQuen.MaKH = dr.Table.Columns.Contains("MaKH") && dr["MaKH"] != DBNull.Value ? dr["MaKH"].ToString() : string.Empty;
                objKhachQuen.Phones = dr.Table.Columns.Contains("Phones") && dr["Phones"] != DBNull.Value ? dr["Phones"].ToString() : string.Empty; //dr["Phones"].ToString();
                objKhachQuen.Name = dr.Table.Columns.Contains("Name") && dr["Name"] != DBNull.Value ? dr["Name"].ToString() : string.Empty; //dr["Name"].ToString();
                objKhachQuen.Address = dr.Table.Columns.Contains("Address") && dr["Address"] != DBNull.Value ? dr["Address"].ToString() : string.Empty; //dr["Address"].ToString();
                objKhachQuen.BirthDay = !dr.Table.Columns.Contains("BirthDay")|| dr["BirthDay"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["BirthDay"]);
                objKhachQuen.Email = dr.Table.Columns.Contains("Email") && dr["Email"] != DBNull.Value ? dr["Email"].ToString() : string.Empty; //dr["Email"].ToString();
                objKhachQuen.Fax = dr.Table.Columns.Contains("Fax") && dr["Fax"] != DBNull.Value ? dr["Fax"].ToString() : string.Empty; //dr["Fax"].ToString();
                objKhachQuen.IsActive = dr.Table.Columns.Contains("IsActive") && dr["IsActive"] != DBNull.Value && Convert.ToBoolean(dr["IsActive"]);
                objKhachQuen.Notes = dr.Table.Columns.Contains("Notes") && dr["Notes"] != DBNull.Value ? dr["Notes"].ToString() : string.Empty; //dr["Notes"].ToString();
                objKhachQuen.Rank = !dr.Table.Columns.Contains("Rank") || dr["Rank"] == DBNull.Value ? 0 : Convert.ToInt16(dr["Rank"].ToString());
                objKhachQuen.Type = !dr.Table.Columns.Contains("Type") || dr["Type"] == DBNull.Value ? 0 : Convert.ToInt16(dr["Type"]);
                objKhachQuen.RankName = dr.Table.Columns.Contains("RankName") && dr["RankName"] != DBNull.Value ? dr["RankName"].ToString() : string.Empty; // dr["RankName"] == DBNull.Value ? string.Empty : dr["RankName"].ToString();
                objKhachQuen.TypeName = dr.Table.Columns.Contains("TypeName") && dr["TypeName"] != DBNull.Value ? dr["TypeName"].ToString() : string.Empty; // dr["TypeName"] == DBNull.Value ? string.Empty : dr["TypeName"].ToString();
                objKhachQuen.KinhDo = !dr.Table.Columns.Contains("KinhDo") || dr["KinhDo"] == DBNull.Value ? 0 : float.Parse(dr["KinhDo"].ToString());
                objKhachQuen.ViDo = !dr.Table.Columns.Contains("ViDo") || dr["ViDo"] == DBNull.Value ? 0 : float.Parse(dr["ViDo"].ToString());
                return objKhachQuen;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetKhachQuen_Row",ex);
                return new DanhBaKhachQuen();
            }

        }
        
        public static DanhBaEx GetDanhBaEx_Row(DataRow dr)
        {
            try
            {                
                DanhBaEx objKhachQuen = new DanhBaEx();
                objKhachQuen.MaDoiTac = dr["MaKH"].ToString();
                objKhachQuen.PhoneNumber = dr["Phones"].ToString();
                objKhachQuen.Name = dr["Name"].ToString();
                objKhachQuen.Address = dr["Address"].ToString();
                objKhachQuen.IsActive = Convert.ToBoolean(dr["IsActive"]);
                objKhachQuen.GhiChuTiepNhan = dr["Notes"].ToString();
                int Type = dr["Type"] == DBNull.Value ? 0 : Convert.ToInt16(dr["Type"]);
                if (Type == 1)
                    objKhachQuen.KieuKHGoiDen = KieuKhachHangGoiDen.KhachHangVIP;
                else if (Type == 2)
                    objKhachQuen.KieuKHGoiDen = KieuKhachHangGoiDen.KhachHangBinhThuong;
                else if (Type == 3)
                    objKhachQuen.KieuKHGoiDen = KieuKhachHangGoiDen.KhachHangBinhThuong;
                objKhachQuen.KieuDanhBa = KieuDanhBa.ThanThiet;
                objKhachQuen.GPS_KinhDo = dr["KinhDo"] == DBNull.Value ? 0 : (float)dr["KinhDo"];
                objKhachQuen.GPS_ViDo = dr["ViDo"] == DBNull.Value ? 0 : (float)dr["ViDo"];
                return objKhachQuen;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDanhBaEx_Row: ",ex);
                return null;
            }

        }

        public static DanhBaKhachQuenEx GetKhachQuenEx_Row(DataRow dr)
        {
            try
            {                
                DanhBaKhachQuenEx objKhachQuen = new DanhBaKhachQuenEx();

                objKhachQuen.MaKH = dr["MaKH"].ToString();
                objKhachQuen.Phones = dr["Phones"].ToString();
                objKhachQuen.Name = dr["Name"].ToString();
                objKhachQuen.Address = dr["Address"].ToString();
                objKhachQuen.BirthDay = dr["BirthDay"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["BirthDay"]);
                objKhachQuen.Email = dr["Email"].ToString();
                objKhachQuen.Fax = dr["Fax"].ToString();
                objKhachQuen.IsActive = Convert.ToBoolean(dr["IsActive"]);
                objKhachQuen.Notes = dr["Notes"].ToString();
                objKhachQuen.Rank = 0;// dr["Rank"] == DBNull.Value ? 0 : Convert.ToInt16(dr["Rank"].ToString());
                objKhachQuen.Type = 0; // dr["Type"] == DBNull.Value ? 0 : Convert.ToInt16(dr["Type"]);
                objKhachQuen.RankName = string.Empty; //dr["RankName"] == DBNull.Value ? string.Empty : dr["RankName"].ToString();
                objKhachQuen.TypeName = string.Empty;// dr["TypeName"] == DBNull.Value ? string.Empty : dr["TypeName"].ToString();
                objKhachQuen.TrangThaiGoi = dr["TrangThaiGoi"] == DBNull.Value ? (byte)0 : byte.Parse(dr["TrangThaiGoi"].ToString());
                objKhachQuen.ThoiDiemGoiGanDay = dr["ThoiDiemGoi"] == DBNull.Value ? new DateTime(2000, 1, 1, 0, 0, 0) : DateTime.Parse(dr["ThoiDiemGoi"].ToString());
                objKhachQuen.GhiChuGoi = dr["GhiChu"] == DBNull.Value ? string.Empty : dr["GhiChu"].ToString();
                objKhachQuen.ThangNam = dr["ThangNam"] == DBNull.Value ? string.Empty : dr["ThangNam"].ToString();
                objKhachQuen.SoLanGoiTrongThang = dr["SoLanGoi"] == DBNull.Value ? 0 : int.Parse(dr["SoLanGoi"].ToString());
                objKhachQuen.KinhDo = dr["KinhDo"] == DBNull.Value ? 0 : (float)dr["KinhDo"];
                objKhachQuen.ViDo = dr["ViDo"] == DBNull.Value ? 0 : (float)dr["ViDo"];

                return objKhachQuen;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetKhachQuenEx_Row: ",ex);
                return null;
            }

        }

        public static DanhBaKhachQuen GetKhachQuen_ID(string ID)
        {
            DanhBaKhachQuen objKhachQuen = new DanhBaKhachQuen();
            DataTable dt = new DataTable();

            dt = new Data.DanhBaKhachQuen().GetDanhBaKhachQuen_ID(ID);
            if (dt.Rows.Count > 0)
            {
                objKhachQuen = GetKhachQuen_Row(dt.Rows[0]);
            }
            dt.Dispose();
            dt = null;

            return objKhachQuen;
        }

        public static DanhBaKhachQuen GetKhachQuen_Phones(string Phones)
        {
            DanhBaKhachQuen objKhachQuen = new DanhBaKhachQuen();
            DataTable dt = new DataTable();

            dt = new Data.DanhBaKhachQuen().GetDanhBaKhachQuen_Phones(Phones);
            if (dt.Rows.Count > 0)
            {
                objKhachQuen = GetKhachQuen_Row(dt.Rows[0]);
            }
            dt.Dispose();
            dt = null;

            return objKhachQuen;
        }

        public static DanhBaKhachQuen GetKhachQuen_Phones_Search(string Phones)
        {
            DanhBaKhachQuen objKhachQuen = new DanhBaKhachQuen();
            DataTable dt = new DataTable();

            dt = new Data.DanhBaKhachQuen().GetDanhBaKhachQuen_Phones_Search(Phones);
            if (dt.Rows.Count > 0)
            {
                objKhachQuen = GetKhachQuen_Row(dt.Rows[0]);
            }
            dt.Dispose();
            dt = null;

            return objKhachQuen;
        }

        public static List<DanhBaKhachQuen> GetDanhSachKhachQuen()
        {
            try
            {
                List<DanhBaKhachQuen> listKhachQuen = new List<DanhBaKhachQuen>();
                DataTable dt = new DataTable();
                dt = new Data.DanhBaKhachQuen().GetDanhBaKhachQuen_ID("");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        listKhachQuen.Add(GetKhachQuen_Row(dr));
                    }
                }
                dt.Dispose();
                dt = null;

                return listKhachQuen;
            }
            catch 
            {
                return null;
            }
        }

        public static List<DanhBaKhachQuen> GetKhachQuens(string strSQL)
        {
            List<DanhBaKhachQuen> lstKhachQuen = new List<DanhBaKhachQuen>();
            DataTable dt = new DataTable();

            dt = new Data.DanhBaKhachQuen().GetKhachQuens(strSQL);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lstKhachQuen.Add(GetKhachQuen_Row(dr));
                }
            }
            dt.Dispose();
            dt = null;

            return lstKhachQuen;
        }

        public static List<DanhBaKhachQuen> GetKhachQuens_LastUpdate(DateTime LastUpdate)
        {
            try
            {
                List<DanhBaKhachQuen> lstKhachQuen = new List<DanhBaKhachQuen>();
                DataTable dt = new DataTable();

                dt = new Data.DanhBaKhachQuen().GetKhachQuens_LastUpdate(LastUpdate);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstKhachQuen.Add(GetKhachQuen_Row(dr));
                    }
                    dt.Dispose();
                    dt = null;
                }
                return lstKhachQuen;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetKhachQuens_LastUpdate",ex); 
                return new List<DanhBaKhachQuen>();
            }
        }

        public static List<DanhBaEx> GetAllKhachQuens_V2()
        {
            List<DanhBaEx> lstKhachQuen = new List<DanhBaEx>();
            DataTable dt = new DataTable();

            dt = new Data.DanhBaKhachQuen().GetAll();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DanhBaEx item = GetDanhBaEx_Row(dr);
                    if (item != null)
                    {
                        string[] arrDienThoai = item.PhoneNumber.Split(";".ToCharArray());
                        for (int i = 0; i < arrDienThoai.Length; i++)
                        {
                            item.PhoneNumber = arrDienThoai[i];
                            lstKhachQuen.Add(item);
                        }                        
                    }                    
                }
            }
            dt.Dispose();
            dt = null;

            return lstKhachQuen;
        }

        public static List<DanhBaEx> GetKhachQuens_LastUpdate_V2(DateTime LastUpdate)
        {
            List<DanhBaEx> lstKhachQuen = new List<DanhBaEx>();
            DataTable dt = new DataTable();

            dt = new Data.DanhBaKhachQuen().GetKhachQuens_LastUpdate(LastUpdate);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lstKhachQuen.Add(GetDanhBaEx_Row(dr));
                }
            }
            dt.Dispose();
            dt = null;

            return lstKhachQuen;
        }

        /// <summary>
        /// Lấy ds khách quên theo một khoảng thời gian.
        /// </summary>
        public static List<DanhBaKhachQuenEx> GetKhachQuens(DateTime tuNgay, DateTime denNgay)
        {
            List<DanhBaKhachQuenEx> lstKhachQuen = new List<DanhBaKhachQuenEx>();
            DataTable dt = new DataTable();

            dt = new Data.DanhBaKhachQuen().GetKhachQuens(tuNgay, denNgay);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lstKhachQuen.Add(GetKhachQuenEx_Row(dr));
                }
            }
            dt.Dispose();
            dt = null;

            return lstKhachQuen;
        }

        public static List<DanhBaKhachQuen> GetDanhBaKhachQuen_Search(string PhoneNumber, string TenKH, string DiaChi)
        {
            List<DanhBaKhachQuen> listKhachQuen = new List<DanhBaKhachQuen>();
            DataTable dt = new Data.DanhBaKhachQuen().GetDanhBaKhachQuen_Search(PhoneNumber, TenKH, DiaChi);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    listKhachQuen.Add(GetKhachQuen_Row(dr));
                }
            }
            dt.Dispose();
            dt = null;

            return listKhachQuen;
        }

        public bool Delete(string maKhachHang)
        {
            try
            {
                return new Data.DanhBaKhachQuen().Delete(maKhachHang);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("DanhBaKhachQuen.Delete",ex);
                return false;

            }
           
        }
        #endregion Methods

        /// <summary>
        /// hàm cập nhật thông tin gọi cho khách hàng
        /// </summary>        
        public static bool CapNhatTrangThaiGoiChoKhach(string maKhachHang, byte loaiKhachKhach, string ghiChu)
        {
            return new Data.DanhBaKhachQuen().CapNhatTrangThaiGoiChoKhach(maKhachHang, loaiKhachKhach, ghiChu);
        }

        public static int GetMaKH()
        {
            return new Data.DanhBaKhachQuen().GetMaKH();
        }
    }

    public class DanhBaKhachQuenEx : DanhBaKhachQuen
    {
        private DateTime thoiDiemGoiGanDay;

        public DateTime ThoiDiemGoiGanDay
        {
            get { return thoiDiemGoiGanDay; }
            set { thoiDiemGoiGanDay = value; }
        }

        private byte trangThaiGoi;

        public byte TrangThaiGoi
        {
            get { return trangThaiGoi; }
            set { trangThaiGoi = value; }
        }

        private string ghiChuGoi;

        public string GhiChuGoi
        {
            get { return ghiChuGoi; }
            set { ghiChuGoi = value; }
        }

        private string thangNam;

        public string ThangNam
        {
            get { return thangNam; }
            set { thangNam = value; }
        }

        private int soLanGoiTrongThang;

        public int SoLanGoiTrongThang
        {
            get { return soLanGoiTrongThang; }
            set { soLanGoiTrongThang = value; }
        }

    }

    public class DanhBaKhachQuen_Type
    {
        #region Members

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Type;
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private string _Notes;
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
        #endregion

        #region Contructor
        public DanhBaKhachQuen_Type()
        {
        }

        #endregion Contructor

        #region Methods
        public static DanhBaKhachQuen_Type GetKhachQuen_Type_Row(DataRow dr)
        {
            try
            {
                DanhBaKhachQuen_Type objKhachQuen_Type = new DanhBaKhachQuen_Type();
                objKhachQuen_Type.ID = Convert.ToInt16(dr["ID"]);
                objKhachQuen_Type.Notes = dr["Notes"].ToString();
                objKhachQuen_Type.Type = dr["Type"].ToString();
                return objKhachQuen_Type;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetKhachQuen_Type_Row: ",ex);
                return new DanhBaKhachQuen_Type();
            }
        }

        public static List<DanhBaKhachQuen_Type> GetDanhSachKhachQuen_Type()
        {
            try
            {
                List<DanhBaKhachQuen_Type> listKhachQuen_Type = new List<DanhBaKhachQuen_Type>();
                DataTable dt = new DataTable();
                dt = new Data.DanhBaKhachQuen().GetDanhBaKhachQuen_Type_ID("");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        listKhachQuen_Type.Add(GetKhachQuen_Type_Row(dr));
                    }
                }
                dt.Dispose();
                dt = null;

                return listKhachQuen_Type;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDanhSachKhachQuen_Type: ",ex);                
                return new List<DanhBaKhachQuen_Type>();
            }
        }

        #endregion Methods
    }

    public class DanhBaKhachQuen_Rank
    {
        #region Members

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Rank;
        public string Rank
        {
            get { return _Rank; }
            set { _Rank = value; }
        }

        private string _Notes;
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
        #endregion

        #region Contructor
        public DanhBaKhachQuen_Rank()
        {
        }

        #endregion Contructor

        #region Methods
        public static DanhBaKhachQuen_Rank GetKhachQuen_Rank_Row(DataRow dr)
        {
            try
            {
                DanhBaKhachQuen_Rank objKhachQuen_Rank = new DanhBaKhachQuen_Rank();

                objKhachQuen_Rank.ID = Convert.ToInt16(dr["ID"]);
                objKhachQuen_Rank.Notes = dr["Notes"].ToString();
                objKhachQuen_Rank.Rank = dr["Rank"].ToString();
                return objKhachQuen_Rank;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetKhachQuen_Rank_Row: ",ex);                
                return new DanhBaKhachQuen_Rank();
            }
        }

        public static List<DanhBaKhachQuen_Rank> GetDanhSachKhachQuen_Rank()
        {
            try
            {
                List<DanhBaKhachQuen_Rank> listKhachQuen_Rank = new List<DanhBaKhachQuen_Rank>();
                DataTable dt = new DataTable();
                dt = new Data.DanhBaKhachQuen().GetDanhBaKhachQuen_Rank_ID("");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        listKhachQuen_Rank.Add(GetKhachQuen_Rank_Row(dr));
                    }
                }
                dt.Dispose();
                dt = null;

                return listKhachQuen_Rank;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDanhSachKhachQuen_Rank: ",ex);                
                return new List<DanhBaKhachQuen_Rank>();
            }
        }

        #endregion Methods
    }
}
