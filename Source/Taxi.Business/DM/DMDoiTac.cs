using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Taxi.Utils;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Taxi.Business
{
    /// <summary>
    /// DM muc doi tac cua cong ty taxi
    /// </summary>
    /// <Modified>
    ///	Name		Date		 Comment 
    ///	Congnt		31/03/2008   Created
    ///	</Modified> 
    [Serializable]
    public class DoiTac 
    {        
        #region Fields

        private string mMaDoiTac;
        
        private string mName;
        private string mAddress;
        private string mPhones; // Khach hang su dung nhieu so dien thoai, luu lai tat ca cac so
        private string mFax;
        private string mEmail;
        private float mTiLeHoaHongNoiTinh;
        public float TiLeHoaHongNoiTinh
        {
            get { return mTiLeHoaHongNoiTinh; }
            set { mTiLeHoaHongNoiTinh = value; }
        }
        private float mTiLeHoaHongDuongDai;
        public float TiLeHoaHongDuongDai
        {
            get { return mTiLeHoaHongDuongDai; }
            set { mTiLeHoaHongDuongDai = value; }
        }
        private string mNotes;
        private bool mIsActive;

        public bool IsActive
        {
            get { return mIsActive; }
            set { mIsActive = value; }
        }
        private string mMaNhanVien;

        public string MaNhanVien
        {
            get { return mMaNhanVien; }
            set { mMaNhanVien = value; }
        }
        private string mTenNhanVien;

        public string TenNhanVien
        {
            get { return mTenNhanVien; }
            set { mTenNhanVien = value; }
        }
        private int mVung;

        public int Vung
        {
            get { return mVung; }
            set { mVung = value; }
        }

        private DateTime mNgayKyKet;

        public DateTime NgayKyKet
        {
            get { return mNgayKyKet; }
            set { mNgayKyKet = value; }
        }

        private DateTime mNgayKetThuc;

        public DateTime NgayKetThuc
        {
            get { return mNgayKetThuc; }
            set { mNgayKetThuc = value; }
        }


        private string _TenCongTy;

        public string TenCongTy
        {
            get { return _TenCongTy; }
            set { _TenCongTy = value; }
        }
        private int _CongTyID;

        public int CongTyID
        {
            get { return _CongTyID; }
            set { _CongTyID = value; }
        }
        private string mSoNha;
        public string SoNha
        {
            get { return mSoNha; }
            set { mSoNha = value; }
        }
        private string mTenDuong;
        public string TenDuong
        {
            get { return mTenDuong; }
            set { mTenDuong = value; }
        }

        private string mNguoiTao;

        public string NguoiTao
        {
            get { return mNguoiTao; }
            set { mNguoiTao = value; }
        }
        private DateTime mNgayTao;

        public DateTime NgayTao
        {
            get { return mNgayTao; }
            set { mNgayTao = value; }
        }
        private string mNguoiSua;

        public string NguoiSua
        {
            get { return mNguoiSua; }
            set { mNguoiSua = value; }
        }
        private DateTime mNgaySua;

        public DateTime NgaySua
        {
            get { return mNgaySua; }
            set { mNgaySua = value; }
        }

        private float gps_KinhDo;
        public float KinhDo
        {
            get { return gps_KinhDo; }
            set { gps_KinhDo = value; }
        }

        private float gps_ViDo;
        public float ViDo
        {
            get { return gps_ViDo; }
            set { gps_ViDo = value; }
        }
        public int LoaiDoiTacID { get; set; }

        public string TenLoaiDoiTac { get; set; }
        public int FK_Step { get; set; }
        #endregion Members

        #region Properties
        public string MaDoiTac
        {
            get { return mMaDoiTac; }
            set { mMaDoiTac = value; }
        }
        public string Name
        {
            set { mName = value; }
            get { return mName; }
        }

        public string Address
        {
            set { mAddress = value; }
            get { return mAddress; }
        }

        public string Phones
        {
            set { mPhones = value; }
            get { return mPhones; }
        }

        public string Fax
        {
            set { mFax = value; }
            get { return mFax; }
        }
        public string Email
        {
            set { mEmail = value; }
            get { return mEmail; }
        }

        public string Notes
        {
            set { mNotes = value; }
            get { return mNotes; }
        }
        public string VietTat { get; set; }
        #endregion Properties

        #region Constructors
        public DoiTac()
        {
            this.MaDoiTac = string.Empty;
            this.Name = string.Empty;
            this.Address = string.Empty;
            this.Phones = string.Empty;
            this.Fax = string.Empty;
            this.Email = string.Empty;
            this.TiLeHoaHongDuongDai = 0;
            this.TiLeHoaHongNoiTinh = 0;
            this.Notes = string.Empty;
            this.VietTat = string.Empty;
        }
        public DoiTac(string pMaDoiTac, string pName, string pAddress, string pPhones, string pFax, string Email, float pTiLeHoaHongNoiTinh, float pTiLeHoaHongDuongDai, string pNotes, bool pIsActive,string pMaNhanVien,string pTenNhanVien, int pCongTyID, string pTenCongTy,string pVietTat="")
        {
            this.MaDoiTac = pMaDoiTac;
            this.Name = pName;
            this.Address = pAddress;
            this.Phones = pPhones;
            this.Fax = string.Empty;
            this.Email = pFax;
            this.VietTat = pVietTat;

            this.TiLeHoaHongNoiTinh = pTiLeHoaHongNoiTinh;
            this.TiLeHoaHongDuongDai = pTiLeHoaHongDuongDai;
            this.Notes = pNotes;
            this.IsActive = pIsActive;
            this.MaNhanVien = pMaNhanVien;
            this.TenNhanVien = pTenNhanVien;
            this.CongTyID = pCongTyID;
            this.TenCongTy = pTenCongTy;
            this.VietTat = pVietTat;
        }

        #endregion Constructors

        #region Methods

        public List<DoiTac> GetListOfDoiTacs()
        {
            List<DoiTac> lstDoiTac = new List<DoiTac>();
            try
            {
                DataTable dt = new DataTable();
                dt = new Data.DM.DoiTac().GetCacDoiTacs(string.Empty);// lay tat ca
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstDoiTac.Add(GetDoiTacByRow(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetListOfDoiTacs: ", ex);                
            }
            return lstDoiTac;
        }
        
        public List<DoiTac> GetCacDoiTacs_LastUpdate(DateTime LastUpdate)
        {
            try
            {
                List<DoiTac> lstDoiTac = new List<DoiTac>();
                var dt = new DataTable();
                dt = new Data.DM.DoiTac().GetCacDoiTacs_LastUpdate(LastUpdate);// lay ta ca
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstDoiTac.Add(DoiTac.GetDoiTacByRow(dr));
                    }
                }

                return lstDoiTac;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetCacDoiTacs_LastUpdate: ",ex);
                return new List<DoiTac>();
            }
        }

        public List<DoiTac> GetListOfDoiTacs(bool isActive)
        {
            try
            {
                List<DoiTac> lstDoiTac = new List<DoiTac>();
                DataTable dt = new DataTable();

                dt = new Data.DM.DoiTac().GetDSDoiTacs(isActive);// lay ta ca
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstDoiTac.Add(DoiTac.GetDoiTacByRow(dr));
                    }
                }

                return lstDoiTac;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetListOfDoiTacs: ",ex);
                return new List<DoiTac>();
            }
        }

        /// <summary>
        /// fill to Combobox
        /// </summary>
        /// <returns>Tat ca doi tac (Ma_DoiTac + Name)</returns>
        public DataTable GetListOfDoiTacs_NAME()
        {
            return new Data.DM.DoiTac().GetCacDoiTacs_NAME(); 
        }

        public List<DoiTac> GetListOfDoiTacs_ByNhanVien(string MaNhanVien)
        {
            List<DoiTac> lstDoiTac = new List<DoiTac>();
            DataTable dt = new DataTable();

            dt = new Data.DM.DoiTac().GetListOfDoiTacs_ByNhanVien(MaNhanVien);// lay ta ca
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                { 
                    lstDoiTac.Add(DoiTac.GetDoiTacByRow(dr));
                }
            }

            return lstDoiTac;
        }

        public DoiTac GetDoiTacByMaDoiTac(string MaDoiTac)
        {
            DoiTac objDoiTac = new DoiTac();
            DataTable dt = new DataTable();

            dt = new Data.DM.DoiTac().GetCacDoiTacs(MaDoiTac);
            if (dt.Rows.Count == 1)
            {
                objDoiTac = DoiTac.GetDoiTacByRow(dt.Rows[0]);
            } 
            return objDoiTac;
        }

        /// <summary>
        /// Tra ve thong tin cua doi tac du vao so dien thoai        
        /// </summary>
        /// <param name="PhoneNumber">So dien thoai</param>
        /// <returns>Du lieu doi tac</returns>
        public static DoiTac GetDoiTacByOPhoneNumber(string PhoneNumber)
        {

            DoiTac objDoiTac = null;
            DataTable dt = new DataTable();

            dt = new Data.DM.DoiTac().GetDoiTacByOPhoneNumber(PhoneNumber);
            if (dt.Rows.Count >=1)
            {
                objDoiTac = DoiTac.GetDoiTacByRow(dt.Rows[0]);
            }
            dt.Dispose();
            return objDoiTac;
        }

        public static DoiTac GetDoiTacByOPhoneNumber_KhacMaMoiGioi(string MaMoiGioi,string PhoneNumber)
        {

            DoiTac objDoiTac = new DoiTac();
            DataTable dt = new DataTable();

            dt = new Data.DM.DoiTac().GetDoiTacByOPhoneNumber_KhongCungMa(MaMoiGioi,PhoneNumber);
            if (dt.Rows.Count >= 1)
            {
                objDoiTac = DoiTac.GetDoiTacByRow(dt.Rows[0]);
            }
            dt.Dispose();
            dt = null;
            return objDoiTac;
        }
        
        public static List<DoiTac> GetDoiTacs(string strSQL)
        {
            try
            {
                List<DoiTac> lstDoiTac = new List<DoiTac>();
                DataTable dt = new DataTable();
                dt = new Data.DM.DoiTac().GetDoiTacs(strSQL);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstDoiTac.Add(DoiTac.GetDoiTacByRow(dr));
                    }
                }
                dt.Dispose();
                dt = null;

                return lstDoiTac;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDoiTacs: ", ex);                
                return new List<DoiTac>();
            }
        }
        public static List<DoiTac> GetDoiTacs_V2(int KieuTimKiem, string ThongTinTimKiem)
        {
            try
            {
                List<DoiTac> lstDoiTac = new List<DoiTac>();
                DataTable dt = new DataTable();
                dt = new Data.DM.DoiTac().GetDoiTacs_V2(KieuTimKiem, ThongTinTimKiem);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        lstDoiTac.Add(DoiTac.GetDoiTacByRow(dr));
                    }
                }
                dt.Dispose();
                dt = null;
                return lstDoiTac;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDoiTacs_V2: ",ex);
                return new List<DoiTac>();
            }
        }

        /// <summary>
        /// Ham thuc hien tra ve mot doi tac tu du lieu cua mot DataRow 
        /// </summary>
        public static DoiTac GetDoiTacByRow(DataRow dr)
        {
            DoiTac objDoiTac = new DoiTac();
            try
            {
                

            objDoiTac.MaDoiTac = StringTools.TrimSpace(dr["Ma_DoiTac"].ToString());
            objDoiTac.Name = StringTools.TrimSpace(dr["Name"].ToString());
            objDoiTac.Address = StringTools.TrimSpace(dr["Address"].ToString());
            objDoiTac.Phones = StringTools.TrimSpace(dr["Phones"].ToString());
            objDoiTac.Fax = StringTools.TrimSpace(dr["Fax"].ToString());
            objDoiTac.Email = StringTools.TrimSpace(dr["Email"].ToString());
            if (dr.Table.Columns.Contains("LoaiDoiTacID")&& !string.IsNullOrEmpty(dr["LoaiDoiTacID"].ToString()))
            {
                objDoiTac.LoaiDoiTacID = int.Parse(dr["LoaiDoiTacID"].ToString());
                if (dr.Table.Columns.Contains("TenLoaiDoiTac")&&!string.IsNullOrEmpty(dr["TenLoaiDoiTac"].ToString()))
                {
                    objDoiTac.TenLoaiDoiTac = StringTools.TrimSpace(dr["TenLoaiDoiTac"].ToString());
                }
                else objDoiTac.TenLoaiDoiTac = "";
            }
            else
            {
                objDoiTac.LoaiDoiTacID = 0;
                objDoiTac.TenLoaiDoiTac = "";
            }
            
            if (StringTools.TrimSpace(dr["TiLeHoaHongNoiTinh"].ToString()).Length > 0)
                objDoiTac.TiLeHoaHongNoiTinh = float.Parse(StringTools.TrimSpace(dr["TiLeHoaHongNoiTinh"].ToString()));
            else
                objDoiTac.TiLeHoaHongNoiTinh = 0;


            if (StringTools.TrimSpace(dr["TiLeHoaHongNgoaiTinh"].ToString()).Length > 0)
                objDoiTac.TiLeHoaHongDuongDai = float.Parse(StringTools.TrimSpace(dr["TiLeHoaHongNgoaiTinh"].ToString()));
            else
                objDoiTac.TiLeHoaHongDuongDai = 0;

            objDoiTac.Notes = dr["Notes"].ToString();
            objDoiTac.IsActive = dr["IsActive"].ToString() == "1" ? true : false;

            objDoiTac.MaNhanVien = dr["FK_MaNhanVien"].ToString();
            objDoiTac.TenNhanVien = dr["TenNhanVien"].ToString();
            if (dr["Vung"] != null)
                objDoiTac.Vung = int.Parse(dr["Vung"].ToString().Length <= 0 ? "1" : dr["Vung"].ToString());
            else objDoiTac.Vung = 1;

            objDoiTac.NgayKyKet = DateTime.Parse(dr["NgayKyKet"].ToString().Length <= 0 ? "01-01-1900 01:01:01" : dr["NgayKyKet"].ToString());

            int step = 0;
            if (dr["FK_Step"] != null)
                int.TryParse(dr["FK_Step"].ToString(), out step);
            objDoiTac.FK_Step = step;
            objDoiTac.CongTyID = 0;// int.Parse(dr["CongTyID"].ToString());
            objDoiTac.TenCongTy = "";// dr["TenCongTy"].ToString();
            float kinhdo = 0;
            float vido = 0;
            float.TryParse(dr["KinhDo"].ToString(), out kinhdo);
            objDoiTac.KinhDo = kinhdo;//Convert.ToDecimal(dr["KinhDo"]); 
            float.TryParse(dr["ViDo"].ToString(), out vido);
            objDoiTac.ViDo = vido;
            try
            {
                objDoiTac.VietTat = dr["VietTat"].ToString();
            }
            catch
            {
                    
            }
            try
            {
                if (dr["NgayKetThuc"] == null) 
                    objDoiTac.NgayKetThuc = new DateTime(1900,1,1);
                else
                    objDoiTac.NgayKetThuc = DateTime.Parse(dr["NgayKetThuc"].ToString().Length <= 0 ? "01-01-1900 01:01:01" : dr["NgayKetThuc"].ToString());
            }
            catch (Exception ex)
            {
                objDoiTac.NgayKetThuc = new DateTime(1900,1,1);
            }
            //SoNha
            try
            {
                objDoiTac.SoNha = dr["SoNha"].ToString();
            }
            catch (Exception ex)
            {
                objDoiTac.SoNha = "";
            }
            // TenDuong
            try
            {
                objDoiTac.TenDuong = dr["TenDuong"].ToString();
            }
            catch (Exception ex)   {  objDoiTac.TenDuong = ""; }
            // NguoiTao
            try
            {
                objDoiTac.NguoiTao   = dr["CreatedBy"].ToString();
            }
            catch (Exception ex) { objDoiTac.NguoiTao   = ""; }
            // NgayTao
            try
            {
                objDoiTac.NgayTao   = DateTime .Parse(  dr["CreatedDate"].ToString());
            }
            catch (Exception ex) { objDoiTac.NgayTao   = new DateTime(1900,1,1); }
            // NguoiSua cuoi
            try
            {
                objDoiTac.NguoiSua  = dr["UpdatedBy"].ToString();
            }
            catch (Exception ex) { objDoiTac.NguoiSua   = ""; }
            // ngay sua cuoi cung
               try
            {
                objDoiTac.NgaySua  = DateTime.Parse(   dr["UpdatedDate"].ToString());
            }
            catch (Exception ex) { objDoiTac.NgaySua   = new DateTime(1900,1,1); }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDoiTacByRow", ex);
            }
            return objDoiTac;
        }
        
        public bool Insert()
        {
            return new Data.DM.DoiTac().Insert(this.MaDoiTac, this.Name, this.Address, this.Phones,
                this.Fax, this.Email, this.TiLeHoaHongNoiTinh, this.TiLeHoaHongDuongDai, this.Notes, this.IsActive, this.MaNhanVien, this.TenNhanVien, this.Vung, this.NgayKyKet, this.CongTyID,this.NguoiTao ,this.SoNha, this.TenDuong,this.KinhDo,this.ViDo  );
        }
        public bool Insert_V2()
        {
            return new Data.DM.DoiTac().Insert_V2(this.MaDoiTac, this.Name, this.Address, this.Phones,
                this.Fax, this.Email, this.TiLeHoaHongNoiTinh, this.TiLeHoaHongDuongDai, this.Notes, this.IsActive, this.MaNhanVien, this.TenNhanVien, this.Vung, 
                this.NgayKyKet, this.CongTyID, this.NguoiTao, this.SoNha, this.TenDuong, this.KinhDo, this.ViDo, this.LoaiDoiTacID,this.VietTat,this.FK_Step);
        }
        public bool Update(string Ma_DoiTac_Old)
        {
            return new Data.DM.DoiTac().Update(this.MaDoiTac, this.Name, this.Address, this.Phones,
    this.Fax, this.Email, this.TiLeHoaHongNoiTinh, this.TiLeHoaHongDuongDai, this.Notes, this.IsActive,
    this.MaNhanVien, this.TenNhanVien, this.Vung, this.NgayKyKet, this.NgayKetThuc, this.NguoiSua, this.SoNha, 
    this.TenDuong, Ma_DoiTac_Old, this.KinhDo, this.ViDo, this.VietTat);

        }

        public bool Update_V2(string Ma_DoiTac_Old)
        {
            return new Data.DM.DoiTac().Update_V2(this.MaDoiTac, this.Name, this.Address, this.Phones,
    this.Fax, this.Email, this.TiLeHoaHongNoiTinh, this.TiLeHoaHongDuongDai, this.Notes, this.IsActive,
    this.MaNhanVien, this.TenNhanVien, this.Vung, this.NgayKyKet, this.NgayKetThuc, this.NguoiSua, this.SoNha, this.TenDuong, Ma_DoiTac_Old, this.KinhDo, this.ViDo,
    this.LoaiDoiTacID, this.VietTat, this.FK_Step);

        }

        public bool Active(string MaDoiTac, bool isActive, string NguoiSua)
        {
            return new Data.DM.DoiTac().Active(MaDoiTac, isActive, NguoiSua);
        }

        public bool Delete(string MaDoiTac)
        {
            return new Data.DM.DoiTac().Delete(MaDoiTac);
        }

        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }
            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }

        }


        /// <summary>
        /// Ma doi tac bang rong thi se xoa toan bo T_DOITAC
        /// </summary>
        /// <returns></returns>
        //public bool DeleteAllDoiTac()
        //{
        //    return new Data.DM.DoiTac().Delete(string.Empty);
        //}
        /// <summary>
        /// Sinh ma doi tac, neuchua co thi gan la ID0001
        /// Neu co roi thi lay max + 1
        /// </summary>
        /// <returns>Ma tiep theo</returns>
        public static string GetNextMaDoiTac( int CongTyID)
        {
            try
            {
               string prefixCongTyID = "";
               if (CongTyID == 1) prefixCongTyID = "A";// HN
               else if (CongTyID == 2) prefixCongTyID = "B"; // CP
               else if (CongTyID == 3) prefixCongTyID = "C"; //Tou
               else if (CongTyID == 4) prefixCongTyID = "D";
               else if (CongTyID == 5) prefixCongTyID = "E";
               string strMaxKey = new Data.DM.DoiTac().GetNextMaDoiTac(CongTyID);  // 'D00001'

                string strNextKey = string.Empty;

                if (strMaxKey.Length >= 6)
                {
                    string sID = strMaxKey.Substring(1, 5);
                    long ID = long.Parse(sID);

                    ID += 1;

                    sID = ID.ToString();
                    while (sID.ToString().Length < 5)
                    {
                        sID = "0" + sID;
                    }
                    return prefixCongTyID  + sID;
                }
                else
                {
                    return  prefixCongTyID +  "00001"; // ma dau tien
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static string GetNextMaDoiTac_V3(string MaMG_Group)
        {
            try
            {
                string strMaxKey = new Data.DM.DoiTac().GetNextMaDoiTac_v3(MaMG_Group);

                if (strMaxKey.Length >= 6)
                {
                    string sID = strMaxKey.Substring(3, strMaxKey.Length-3);
                    long ID = long.Parse(sID);

                    ID += 1;

                    string sID_Temp = ID.ToString();
                    while (sID_Temp.Length < sID.Length)
                    {
                        sID_Temp = "0" + sID_Temp;
                    }
                    return MaMG_Group + sID_Temp;
                }
                else
                {
                    return MaMG_Group + "0001"; // ma dau tien
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        #endregion Methods

        /// <summary>
        /// hàm tra về dữ liệu của so chuyến của đối tác theo thang trong nam
        /// D0001  10  245  (Độ dài của xe đón - đổi ra số chuyến = 245+1/4
        /// D0001  11  245
        /// D0001  12  245
        /// SELECT :  MaDoiTac,  Thang,  TongDoDaiXeDon
        /// </summary>
        public static DataTable GetSoChuyenCuaDoiTacTrongThangCuaNam(int Year)
        {
           return new Data.DM.DoiTac().GetSoChuyenCuaDoiTacTrongThangCuaNam(Year); 
        }

        public static void CapNhatDuLieu()
        {
              new Data.DM.DoiTac().CapNhatDuLieu(); 
        }
    }
}
