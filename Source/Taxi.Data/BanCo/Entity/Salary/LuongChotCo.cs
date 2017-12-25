using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using Taxi.Utils;

namespace Taxi.Data.BanCo.Entity.Salary
{
    /// <summary>
    /// Luong_ChotCo
    /// </summary>
    /// <Modified>
    /// Name     Date         Comments
    /// PPM-HAUNV  9/16/2014   created
    /// </Modified>
    [TableInfo(TableName = "Luong_ChotCo")]
    public class LuongChotCo : TaxiOperationDbEntityBase<LuongChotCo>, ICloneable 
    {
        #region properties
        [Field(IsKey = true, IsIdentity = true)]
        [ValueField]
        public Int64 ID { get; set; }
        [Field]
        public string FK_LaiXeID { get; set; }
        [Field]
        public bool CheckCa { get; set; }

        public string TenLaiXe { get; set; }
        [Field]
        public string SoHieuXe { get; set; }
        [Field]
        public DateTime BatDauHoatDong { get; set; }
        [Field]
        public DateTime? KetThucHoatDong { get; set; }
        [Field]
        public DateTime NgayThuNgan { get; set; }
        [Field]
        public DateTime NgayKinhDoanh { get; set; }
        [Field]
        public decimal DongHoTienTruoc { get; set; }
        [Field]
        public int KmHDTruoc { get; set; }
        [Field]
        public int KmCoKhachTruoc { get; set; }

        /// <summary>
        /// Km có hàng = KmCoKhachSau - KmCoKhachTruoc
        /// </summary>
        public int KmCoHang
        {
            get
            {
                return KmCoKhachSau - KmCoKhachTruoc;
            }
        }

        [Field]
        public int KmRongTruoc { get; set; }
        [Field]
        public int SoCuocTruoc { get; set; }
        [Field]
        public decimal DongHoTienSau { get; set; }
        [Field]
        public int KmHoatDongSau { get; set; }
        [Field]
        public int KmCoKhachSau { get; set; }
        [Field]
        public int KmRongSau { get; set; }

        /// <summary>
        /// Km rỗng = km rỗng sau - km rỗng trước
        /// </summary>
        public int KmRong
        {
            get
            {
                return KmRongSau - KmRongTruoc;
            }
        }

        /// <summary>
        /// Km hoạt động
        /// </summary>
        public int KmHoatDong
        {
            get
            {
                return KmHoatDongSau - KmHDTruoc;
            }
        }

        /// <summary>
        /// Phần trăm km rỗng
        /// </summary>
        public double PhanTramKmRong
        {
            get
            {
                double phantram = ((double)KmRong / KmHoatDong) * 100;
                if (phantram % 1 == 0) return Math.Round(phantram, 0);
                return Math.Round(phantram, 2);
            }
        }

        [Field]
        public int SoCuocSau { get; set; }
        [Field]
        public int SoCuocSapCo { get; set; }
        [Field]
        public int SoCuocDuongNgan { get; set; }
        [Field]
        public int SoCuocDuongDai { get; set; }

        /// <summary>
        /// Số cuốc
        /// </summary>
        public int SoCuoc
        {
            get
            {
                return SoCuocDuongNgan + SoCuocDuongDai;
            }
        }

        [Field]
        public decimal ThuPhatSinh { get; set; }
        [Field]
        public decimal ChiPhatSinh { get; set; }
        [Field]
        public string LyDoChiPhatSinh { get; set; }
        [Field]
        public decimal DoanhThu { get; set; }
        [Field]
        public decimal KhachHangNo { get; set; }
        [Field]
        public decimal SoTienLaiXeNoCoLD { get; set; }
        [Field]
        public string GhiChuLaiXeNoCoLD { get; set; }
        [Field]
        public decimal SoTienLaiXeNoKhongLD { get; set; }
        [Field]
        public string GhiChuLaiXeNoKhongLD { get; set; }
        /// <summary>
        /// Lái xe nợ = SoTienLaiXeNoCoLD + SoTienLaiXeNoKhongLD;
        /// </summary>
        public decimal LaiXeNo
        {
            get
            {
                return SoTienLaiXeNoCoLD + SoTienLaiXeNoKhongLD;
            }
        }

        [Field]
        public decimal LaiXeTra { get; set; }
        [Field]
        public decimal LaiXeNop { get; set; }

        public string GhiChu
        {
            get;
            set;
        }

        [Field]
        public string CreatedByUser { get; set; }
        [Field]
        public DateTime CreatedDate { get; set; }
        [Field]
        public string UpdatedByUser { get; set; }
        [Field]
        public DateTime? UpdatedDate { get; set; }
        [Field]
        public string GiamSatID { get; set; }
        [Field]
        public bool IsGop { get; set; }
        [Field]
        public DateTime BatDauGop { get; set; }
        [Field]
        public DateTime KetThucGop { get; set; }
        
        public bool IsGPS { get; set; }
        public bool IsAdd { get; set; }

       

        #endregion
        #region List CuocKhach
        /// <summary>
        /// Lưu trữ thông tin của các cuốc khách
        /// </summary>
        public List<CuocKhach> LsCuocKhach;
        /// <summary>
        /// sử dụng khi lấy dữ liệu cuốc khách theo ngày kinh doanh
        /// </summary>
        public void LoadCuocKhach()
        {
            if (ID == 0)
            {
                // lấy dữ liệu khi xử lý thêm
                LsCuocKhach =
                    ExeStore("Luong_CuocKhach_GetListFromTruckEnd_v3", this.NgayKinhDoanh, this.NgayThuNgan,this.KetThucHoatDong,
                        this.FK_LaiXeID, SoHieuXe,this.CheckCa)
                        .ToList<CuocKhach>();
            }
            else
            {
                // Lấy dữ liệu khi có xem thông tin
                LsCuocKhach =
                    ExeStore("Luong_CuocKhach_GetListFromCuocKhach_v3", this.NgayKinhDoanh, this.NgayThuNgan, this.FK_LaiXeID, SoHieuXe, this.CheckCa,this.ID)
                        .ToList<CuocKhach>();
            }
            if (LsCuocKhach != null)
            {
              LsCuocKhach=LsCuocKhach.OrderBy(p => (p.MaLaiXe == this.FK_LaiXeID).To<int>()).ToList();
            }
        }
        /// <summary>
        /// Chỉ load khi trunkEnd
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        public void LoadCuocKhach(DateTime startDateTime,DateTime endDateTime)
        {
            // lấy dữ liệu khi xử lý thêm
             LsCuocKhach =
                ExeStore("Luong_CuocKhach_GetListFromTruckEndGopCuoc", startDateTime, endDateTime, this.BatDauHoatDong,
                    this.FK_LaiXeID, SoHieuXe)
                    .ToList<CuocKhach>();
            //if (LsCuocKhachGop != null)
            //{
            //    if (LsCuocKhach)
            //    LsCuocKhachGop.ForEach(p =>
            //    {
            //        if (LsCuocKhach.Any(pl => pl.CuocKhachID != p.CuocKhachID))
            //        {
            //            LsCuocKhach.Add(p);
            //        }
            //    });
            //}
        }
        /// <summary>
        /// Lấy chỉ số hôm trước của ngày hôm trước đó và lấy thời ra kinh doanh
        /// </summary>
        public void LoadChiSoTruoc()
        {
            var data =
                ExeStore("Luong_CuocKhach_GetChiSoTruoc", this.NgayKinhDoanh, this.NgayThuNgan, this.FK_LaiXeID,
                    SoHieuXe);
            if (data.Rows.Count == 1)
            {
                var dataRow = data.Rows[0];
                this.DongHoTienTruoc = dataRow["DongHoTienTruoc"].To<decimal>();
                this.KmHDTruoc = dataRow["KmHDTruoc"].To<int>();
                this.KmCoKhachTruoc = dataRow["KmCoKhachTruoc"].To<int>();
                this.KmRongTruoc = dataRow["KmRongTruoc"].To<int>();
                this.SoCuocTruoc = dataRow["SoCuocTruoc"].To<int>();
            }
           
        }
        #endregion
        #region Hàm thực hiện

        public List<LuongChotCo> GetListByDate(DateTime dateTime,bool check=false)
        {
            return this.ExeStore("Luong_ChotCo_GetListByDate", dateTime, check).ToList<LuongChotCo>();
        }

        /// <summary>
        /// Lấy ra danh sách Luong_ChotCo từ ngày, đến ngày, loại xe, lái xe và số xe
        /// </summary>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <param name="loaiXe"></param>
        /// <param name="laiXe"></param>
        /// <param name="soXe"></param>
        /// <returns></returns>
        public List<LuongChotCo> GetList(DateTime tuNgay, DateTime denNgay, int loaiXe, string laiXe, string soXe)
        {
            return ExeStore("Luong_ChotCo_SearchBaoCao", tuNgay, denNgay, loaiXe, laiXe, soXe).ToList<LuongChotCo>();
        }

        /// <summary>
        /// Lấy ra danh sách Luong_ChotCo từ ngày, đến ngày, loại xe và số xe
        /// </summary>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <param name="loaiXe"></param>
        /// <param name="soXe"></param>
        /// <returns></returns>
        public List<LuongChotCo> GetList(DateTime tuNgay, DateTime denNgay, int loaiXe, string soXe)
        {
            return ExeStore("Luong_ChotCo_SearchBaoCaoTheoXe", tuNgay, denNgay, loaiXe, soXe).ToList<LuongChotCo>();
        }

        public bool Check(DateTime dateTime,string laiXeId,string soHieuXe)
        {
            return int.Parse(this.ExeStore("Luong_ChotCo_Check", dateTime, laiXeId, soHieuXe).Rows[0][0].ToString()) > 0;
        }

        public DateTime? GetDateThuNgan()
        {
            return this.GetDateThuNgan(this.NgayKinhDoanh, this.BatDauHoatDong, this.SoHieuXe, this.FK_LaiXeID);
        }

        public BanCo_GiamSatXe GetLichHoatDongCaTruocChuaThuNgan()
        {
            var data = this.ExeStore("Luong_ChotCo_GetLichHoatDongCaTruocChuaThuNgan", this.NgayKinhDoanh, this.SoHieuXe);
            
            if (data == null || data.Rows.Count != 1)
            {
                return null;
            }
            var enti = new BanCo_GiamSatXe();
            enti.ParseFrom(data.Rows[0]);
            return enti;
        }

        public List<BanCo_GiamSatXe> GetLichHoatDongCaTruocChuaThuNgan2()
        {
            return this.ExeStore("Luong_ChotCo_GetLichHoatDongCaTruocChuaThuNgan_V1", this.NgayKinhDoanh, this.SoHieuXe).ToList<BanCo_GiamSatXe>(); 
        }
        /// <summary>
        /// Lấy danh sách lịch từ ngày đến ngày
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<BanCo_GiamSatXe> GetLichHoatDongGopNgay(DateTime start,DateTime end)
        {
            return this.ExeStore("Luong_ChotCo_GetLichHoatDongGopNgay", start, end, this.FK_LaiXeID, this.SoHieuXe).ToList<BanCo_GiamSatXe>(); 
        }
        /// <summary>
        /// Cập nhật trạng thái Gộp của lịch hoạt động
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void UpdateGiamSatXeGopLich(DateTime start, DateTime end)
        {
            this.ExeStoreNoneQuery("Luong_ChotCo_UpdateGiamSatXeGopLich", start, end, this.FK_LaiXeID, this.SoHieuXe, this.BatDauHoatDong);
        }
        public bool CheckCuocKhach(DateTime BatDau, DateTime KetThuc, string SoXe)
        {
            var data = this.ExeStore("Luong_ChotCo_CheckCuocKhach", BatDau,KetThuc, SoXe);

            if (data == null || data.Rows.Count != 1)
            {
                return false;
            }
            return data.Rows[0][0].To<int>()>0;
        }
        public DateTime? GetDateThuNgan(DateTime? ngayKinhDoanh, DateTime? ngayThuNgan, string soHieuXe, string maLaiXe)
        {
            try
            {
                var data = this.ExeStore("Luong_ChotCo_GetDateThuNgan_V2", ngayKinhDoanh, ngayThuNgan, soHieuXe, maLaiXe);
                if (data == null || data.Rows.Count != 1)
                {
                    return null;
                }
                return data.Rows[0][0].To<DateTime>();
            }
            catch (Exception)
            {
                return null;
            }
         
        }
        public bool Check()
        {
            return this.Check(this.NgayKinhDoanh, this.FK_LaiXeID,this.SoHieuXe);
        }

        /// <summary>
        /// Inserts the ex.
        /// phần mở rộng của thêm chôt cơ.
        /// Giúp thực hiện thêm dữ liệu đc bảo toàn giữa cuốc khách và chốt cơ.
        /// </summary>
        /// <param name="listCuocKhach">The list cuoc khach.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// PPM-HAUNV  9/20/2014   created
        /// </Modified>
        public bool InsertEx(List<CuocKhach> listCuocKhach)
        {
            var strCon = CommonUtils.ConnectionString;

            var db = new SqlConnection(strCon);
                db.Open();
            var transaction = db.BeginTransaction();
            this.DataBaseService.BeginTransaction();
            try
            {
                this.Insert();
                SqlCommand cmd;
                if (listCuocKhach != null)
                {
                    var id = this.ID;
                    var idCuocKhach = "0";
                    foreach (var cuocKhach in listCuocKhach)
                    {
                        #region Cmd
                     
                        cmd = new SqlCommand
                        {
                            Connection = db,
                            Transaction = transaction,
                            CommandType = CommandType.Text,
                            CommandText = @"INSERT INTO [dbo].[Luong_CuocKhach]
                           ([FK_TaxiOperationId],
                            [ChotCoID]
                           ,[TGTiepNhan]
                           ,[FK_DiemDo]
                           ,[DiaChiDon]
                           ,[SoXe]
                           ,[ChiSoDi]
                           ,[TGGap]
                           ,[DiaChiTra]
                           ,[TuyenDuong]
                           ,[Chieu]
                           ,[GiaThueBao]
                           ,[TGTra]
                           ,[ChiSoVe]
                           ,[KmCoDH]
                           ,[KmThucDi]
                           ,[TienDH]
                           ,[PhatSinh]
                           ,[TienTroiKM]
                           ,[TienTroiPhut]
                           ,[GiaGoc]
                           ,[ThanhTien]
                           ,[CuocKhachID]
                           ,[MaLaiXe]
                           ,[ChayTuyen]
                           ,[CuocDuongDai]
                           ,[CungDuong]
                           ,[PhuTroi]
                           ,[KmVuot]
                           ,[PhutVuot]
                           ,[CuocGoi]
                           ,[BuXang_Don]
                           ,[BuXang_Truot]
                           ,[LoaiCuocHang]
                           ,[KieuCuocHang]
                            ,[KetQua]
                            ,[BazemKm]
                            ,[BazemKm2]
                           ,[Luong_TienXangDauDinhMuc]
                           ,[Luong_TienLaiXeHuongDinhMuc]
                           ,[Luong_TienHuongDuongDai]
                           ,[Luong_TienHuongKmVuot]
                           ,[Luong_TienHuongGioVuot]
                           ,[CreatedByUser]
                           ,[CreatedDate],
                            [IsCaBa],
                            [TGDieuXe])
                            VALUES
                            (@FK_TaxiOperationId
                            ,@ChotCoID
                           ,@TGTiepNhan
                           ,@FK_DiemDo
                           ,@DiaChiDon
                           ,@SoXe
                           ,@ChiSoDi
                           ,@TGGap
                           ,@DiaChiTra
                           ,@TuyenDuong
                           ,@Chieu
                           ,@GiaThueBao
                           ,@TGTra
                           ,@ChiSoVe
                           ,@KmCoDH
                           ,@KmThucDi
                           ,@TienDH
                           ,@PhatSinh
                           ,@TienTroiKM
                           ,@TienTroiPhut
                           ,@GiaGoc
                           ,@ThanhTien
                           ,@CuocKhachID
                           ,@MaLaiXe
                           ,@ChayTuyen
                           ,@CuocDuongDai
                           ,@CungDuong
                           ,@PhuTroi
                           ,@KmVuot
                           ,@PhutVuot
                           ,@CuocGoi
                           ,@BuXang_Don
                           ,@BuXang_Truot
                           ,@LoaiCuocHang
                           ,@KieuCuocHang
                            ,@KetQua
                            ,@BazemKm,@BazemKm2
                           ,@Luong_TienXangDauDinhMuc
                           ,@Luong_TienLaiXeHuongDinhMuc
                           ,@Luong_TienHuongDuongDai
                           ,@Luong_TienHuongKmVuot
                           ,@Luong_TienHuongGioVuot
                           ,@CreatedByUser
                           ,@CreatedDate,
                            @IsCaBa,
                            @TGDieuXe
                            )"
                        };
                        
                        cmd.Parameters.AddWithValue("@FK_TaxiOperationId", cuocKhach.FK_TaxiOperationId.ForDB());
                        cmd.Parameters.AddWithValue("@ChotCoID",id);
                        cmd.Parameters.AddWithValue("@TGTiepNhan", cuocKhach.TGTiepNhan.ForDB());
                        //if (cuocKhach.TGTiepNhan==null)
                        //    tgTiepNhan.Value = DBNull.Value;
                        cmd.Parameters.AddWithValue("@FK_DiemDo", cuocKhach.FK_DiemDo.ForDB());
                        cmd.Parameters.AddWithValue("@DiaChiDon", cuocKhach.DiaChiDon.ForDB());
                        cmd.Parameters.AddWithValue("@SoXe", cuocKhach.SoXe.ForDB());
                        cmd.Parameters.AddWithValue("@ChiSoDi", cuocKhach.ChiSoDi.ForDB());
                        var tgGap = cmd.Parameters.AddWithValue("@TGGap", cuocKhach.TGGap.ForDB());
                        if (cuocKhach.TGGap.IsNull)
                            tgGap.Value = DBNull.Value;
                        cmd.Parameters.AddWithValue("@DiaChiTra", cuocKhach.DiaChiTra.ForDB());
                        cmd.Parameters.AddWithValue("@TuyenDuong", cuocKhach.TuyenDuong.ForDB());
                        cmd.Parameters.AddWithValue("@Chieu", cuocKhach.Chieu.ForDB());
                        cmd.Parameters.AddWithValue("@GiaThueBao", cuocKhach.GiaThueBao.ForDB());
                        var tgTra = cmd.Parameters.AddWithValue("@TGTra", cuocKhach.TGTra.ForDB());
                        if (cuocKhach.TGTra.IsNull)
                            tgTra.Value = DBNull.Value;
                        cmd.Parameters.AddWithValue("@ChiSoVe", cuocKhach.ChiSoVe.ForDB());
                        cmd.Parameters.AddWithValue("@KmCoDH", cuocKhach.KmCoDH.ForDB());
                        cmd.Parameters.AddWithValue("@KmThucDi", cuocKhach.KmThucDi.ForDB());
                        cmd.Parameters.AddWithValue("@TienDH", cuocKhach.TienDH.ForDB());
                        cmd.Parameters.AddWithValue("@PhatSinh", cuocKhach.PhatSinh.ForDB());
                        cmd.Parameters.AddWithValue("@TienTroiKM", cuocKhach.TienTroiKM.ForDB());
                        cmd.Parameters.AddWithValue("@TienTroiPhut", cuocKhach.TienTroiPhut.ForDB());
                        cmd.Parameters.AddWithValue("@GiaGoc", cuocKhach.GiaGoc.ForDB());
                        cmd.Parameters.AddWithValue("@ThanhTien", cuocKhach.ThanhTien.ForDB());
                        cmd.Parameters.AddWithValue("@CuocKhachID", cuocKhach.CuocKhachID.ForDB());
                        cmd.Parameters.AddWithValue("@MaLaiXe", cuocKhach.MaLaiXe.ForDB());
                        cmd.Parameters.AddWithValue("@ChayTuyen", cuocKhach.ChayTuyen.ForDB());
                        cmd.Parameters.AddWithValue("@CuocDuongDai", cuocKhach.CuocDuongDai.ForDB());
                        cmd.Parameters.AddWithValue("@CungDuong", cuocKhach.CungDuong.ForDB());
                        cmd.Parameters.AddWithValue("@PhuTroi", cuocKhach.PhuTroi.ForDB());
                        cmd.Parameters.AddWithValue("@KmVuot", cuocKhach.KmVuot.ForDB());
                        cmd.Parameters.AddWithValue("@PhutVuot", cuocKhach.PhutVuot.ForDB());
                        cmd.Parameters.AddWithValue("@CuocGoi", cuocKhach.CuocGoi.ForDB());
                        cmd.Parameters.AddWithValue("@BuXang_Don", cuocKhach.BuXang_Don.ForDB());
                        cmd.Parameters.AddWithValue("@BuXang_Truot", cuocKhach.BuXang_Truot.ForDB());
                        cmd.Parameters.AddWithValue("@LoaiCuocHang", cuocKhach.LoaiCuocHang.ForDB());
                        cmd.Parameters.AddWithValue("@KieuCuocHang", cuocKhach.KieuCuocHang.ForDB());
                        cmd.Parameters.AddWithValue("@KetQua", cuocKhach.KetQua.ForDB());
                        cmd.Parameters.AddWithValue("@BazemKm", cuocKhach.BazemKm.ForDB());
                        cmd.Parameters.AddWithValue("@BazemKm2", cuocKhach.BazemKm2.ForDB());

                        cmd.Parameters.AddWithValue("@Luong_TienXangDauDinhMuc", cuocKhach.Luong_TienXangDauDinhMuc.ForDB());
                        cmd.Parameters.AddWithValue("@Luong_TienLaiXeHuongDinhMuc", cuocKhach.Luong_TienLaiXeHuongDinhMuc.ForDB());
                        cmd.Parameters.AddWithValue("@Luong_TienHuongDuongDai", cuocKhach.Luong_TienHuongDuongDai.ForDB());
                        cmd.Parameters.AddWithValue("@Luong_TienHuongKmVuot", cuocKhach.Luong_TienHuongKmVuot.ForDB());
                        cmd.Parameters.AddWithValue("@Luong_TienHuongGioVuot", cuocKhach.Luong_TienHuongGioVuot);
                        cmd.Parameters.AddWithValue("@CreatedByUser", this.CreatedByUser.ForDB());
                        cmd.Parameters.AddWithValue("@CreatedDate", this.CreatedDate.ForDB());
                        cmd.Parameters.AddWithValue("@IsCaBa", cuocKhach.IsCaBa);
                        cmd.Parameters.AddWithValue("@TGDieuXe", cuocKhach.TGDieuXe.ForDB());
                       
                        cmd.ExecuteNonQuery();
                        //Lấy những id của TruckEnd để thực hiện cập nhật trạng thái đã thu ngân.
                        if (cuocKhach.FK_TaxiOperationId > 0)
                            idCuocKhach += "," + cuocKhach.FK_TaxiOperationId;
                         
                        #endregion
                    }
                    //Cập nhật trạng thái cho TruckEnd IsCash=1 đã thu ngân.
                    cmd = new SqlCommand()
                    {
                        Connection = db,
                        Transaction = transaction,
                        CommandType = CommandType.Text,
                        CommandText = string.Format("UPDATE [dbo].[T_TAXIOPERATION_TRUCK_END] SET [IsCash] =1 WHERE [ID] in ({0})", idCuocKhach)
                    };
                    cmd.ExecuteNonQuery();
                }
                if (!string.IsNullOrEmpty(this.GiamSatID))
                {
                    //,GhiChu=GhiChu+N'Gộp thu ngân cho ngày {1}'
                    cmd = new SqlCommand()
                    {
                        Connection = db,
                        Transaction = transaction,
                        CommandType = CommandType.Text,
                        CommandText = string.Format("UPDATE [dbo].[BanCo_GiamSatXe] SET [IsGop] =1  WHERE [ID] in ({0})", this.GiamSatID,this.NgayKinhDoanh.ToString("dd/MM/yyyy"))
                    };
                    cmd.ExecuteNonQuery();
                }
            
                this.DataBaseService.Commit(true);
                transaction.Commit();
                db.Close();
                return true;
            }
            catch (SqlException sqlError)
            {
                transaction.Rollback();
                this.DataBaseService.Commit(false);
                db.Close();
                return false;
            }
        }

        public bool InsertEx()
        {
            return this.InsertEx(this.LsCuocKhach);
        }

        public bool DeleteEx()
        {
             this.ExeStoreNoneQuery("Luong_CuocKhach_delete_By_ThuNgan",this.NgayKinhDoanh,this.FK_LaiXeID,this.SoHieuXe,this.ID);
            return true;
            //var strCon = CommonUtils.ConnectionString;

            //var db = new SqlConnection(strCon);
            //db.Open();
            //var transaction = db.BeginTransaction();
            //try
            //{
            //    var cmd = new SqlCommand("Luong_CuocKhach_delete_By_ThuNgan", db, transaction);
            //    this.ExeStoreNoneQuery("Luong_CuocKhach_delete_By_ThuNgan");
            //    cmd.CommandType=CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("LaiXeId", this.FK_LaiXeID);
            //    cmd.Parameters.AddWithValue("NgayKinhDoanh", this.NgayKinhDoanh);
            //    cmd.Parameters.AddWithValue("SoHieuXe", this.SoHieuXe);
            //    cmd.ExecuteNonQuery();
            //    this.Delete();
            //    transaction.Commit();
            //    return true;
            //}
            //catch
            //{
            //    transaction.Rollback();
            //    return false;
            //}
        }
        public bool CheckLichHoatDong(DateTime? start, DateTime? end, string laixeid, string sohieuxe)
        {
            return int.Parse(ExeStore("LuongChotCo_CheckLichHoatDong",start,end,laixeid,sohieuxe).Rows[0][0].ToString()) > 0;
        }

        public bool CheckLichHoatDong()
        {
         return   CheckLichHoatDong(this.BatDauHoatDong, this.KetThucHoatDong, FK_LaiXeID, SoHieuXe);
        }
        #endregion
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public static class Ex
    {
        public static object ForDB(this object o)
        {
            if (o==null||(o is string && o.ToString() == "")||(o is DateTime && o.To<DateTime>()<=DateTime.MinValue))
                return DBNull.Value;
            return o;
        }
    }
}
