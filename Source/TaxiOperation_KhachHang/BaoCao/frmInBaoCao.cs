using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Taxi.Business;
using System.Collections;

namespace Taxi.GUI
{
    public partial class frmInBaoCao : Form
        {//Khai báo đối tượng report document chứa mẫu loại giấy phép muốn in
        ReportDocument mReportDocument = new ReportDocument();

        private string g_LogoPath;

        public frmInBaoCao()
        {
            InitializeComponent();
            g_LogoPath = Configuration.GetLogoImagePath();
        }
        
        public frmInBaoCao(string FullPathReport, DataTable dtDataSource, string TuNgay, string DenNgay)
        {
            InitializeComponent();
            InBaoCao(FullPathReport, dtDataSource,TuNgay ,DenNgay );
        }
        /// <summary>
        /// In cho doi Tac
        /// </summary>
        /// <param name="FullPathReport"></param>
        /// <param name="dtDataSource"></param>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        public frmInBaoCao( string FullPathReport, DataTable dtDataSource,DoiTac DoiTac, string TuNgay, string DenNgay)
        {
            InitializeComponent();
            InBaoCao(FullPathReport, dtDataSource,DoiTac, TuNgay, DenNgay);
        }
        
        public frmInBaoCao(string FullPathReport,DataTable dtDataSource,string DienThoaiSo,string TuNgay, string DenNgay)
        {
            InitializeComponent();
            InBaoCao(FullPathReport, dtDataSource, DienThoaiSo, TuNgay, DenNgay);
        }

        private void InBaoCao(string FullPathReport, DataTable dtDataSource,string DienThoaiSo,string TuNgay, 
string DenNgay)
    {

        //Load lên mẫu in của giấy phép vào đối tượng report document
        mReportDocument.Load(FullPathReport);
        //Thực hiện gán Datasource cho report document 
        mReportDocument.SetDataSource(dtDataSource);
        //Thực hiện view thông tin của giấy phép lên form in
        ParameterFields myParameterFields = new ParameterFields();

        ParameterField FieldTuNgay = new ParameterField();
        ParameterDiscreteValue DiscreteValueTuNgay = new ParameterDiscreteValue();

        ParameterField FieldDenNgay = new ParameterField();
        ParameterDiscreteValue DiscreteValueDenNgay = new ParameterDiscreteValue();
        //TuNgay
        FieldTuNgay.ParameterFieldName = "TuNgay";
        DiscreteValueTuNgay.Value = TuNgay;
        FieldTuNgay.CurrentValues.Add(DiscreteValueTuNgay);
        //DenNgay
        FieldDenNgay.ParameterFieldName = "DenNgay";
        DiscreteValueDenNgay.Value = DenNgay;
        FieldDenNgay.CurrentValues.Add(DiscreteValueDenNgay);

        ParameterField FieldSoDienThoai= new ParameterField();
        ParameterDiscreteValue DiscreteValueSoDienThoai = new ParameterDiscreteValue();
        //SoDienThoai
        FieldSoDienThoai.ParameterFieldName = "SoDienThoai";
        DiscreteValueSoDienThoai.Value = DienThoaiSo;
        FieldSoDienThoai.CurrentValues.Add(DiscreteValueSoDienThoai);

        myParameterFields.Add(FieldTuNgay);
        myParameterFields.Add(FieldDenNgay);
        myParameterFields.Add(FieldSoDienThoai);

       
        crGiayPhepViewer.ParameterFieldInfo = myParameterFields;
        crGiayPhepViewer.ReportSource = mReportDocument;
    }



        public void InBaoCaoBieuMau1(string FullPathReport, DataTable dtDataSource, DateTime Ngay, string PathBieuDo1, string PathBieuDo2)
        {
            //Load lên mẫu in của giấy phép vào đối tượng report document
            mReportDocument.Load(FullPathReport);
            //Thực hiện gán Datasource cho report document 
            mReportDocument.SetDataSource(dtDataSource);
            //Thực hiện view thông tin của giấy phép lên form in
            ParameterFields myParameterFields = new ParameterFields();

            ParameterField FieldNgay = new ParameterField();
            ParameterDiscreteValue DiscreteValueNgay = new ParameterDiscreteValue();
                        
            ParameterField FieldBieuDo1_Path = new ParameterField();
            ParameterDiscreteValue DiscreteValueBieuDo1 = new ParameterDiscreteValue();

            ParameterField FieldBieuDo2_Path = new ParameterField();
            ParameterDiscreteValue DiscreteValueBieuDo2 = new ParameterDiscreteValue();
            //TuNgay
            FieldNgay.ParameterFieldName = "TuNgay";
            DiscreteValueNgay.Value = string.Format("{0: dd/MM/yyyy}", Ngay);
            FieldNgay.CurrentValues.Add(DiscreteValueNgay);
            

            // duong dan bieu do 1
            FieldBieuDo1_Path.ParameterFieldName = "BieuDo1_Path";
            DiscreteValueBieuDo1.Value = PathBieuDo1;
            FieldBieuDo1_Path.CurrentValues.Add(DiscreteValueBieuDo1);

            // duong dan anh bieu do 2
            FieldBieuDo2_Path.ParameterFieldName = "BieuDo2_Path";
            DiscreteValueBieuDo2.Value = PathBieuDo2;
            FieldBieuDo2_Path.CurrentValues.Add(DiscreteValueBieuDo2);

            myParameterFields.Add(FieldNgay);
            myParameterFields.Add(FieldBieuDo1_Path);
            myParameterFields.Add(FieldBieuDo2_Path);

            //-- Duong dan logo ---
            ParameterField FieldLogo_Path = new ParameterField();
            ParameterDiscreteValue DiscreteValueLogo = new ParameterDiscreteValue();
            FieldLogo_Path.ParameterFieldName = "pLogoPath";
            DiscreteValueLogo.Value = g_LogoPath;
            FieldLogo_Path.CurrentValues.Add(DiscreteValueLogo);
            myParameterFields.Add(FieldLogo_Path);
            // ---------------------

            crGiayPhepViewer.ParameterFieldInfo = myParameterFields;
            crGiayPhepViewer.ReportSource = mReportDocument;

        }
        /// <summary>
        /// mau bao cao 2 - bao cao cuoc goi taxi theo ngay
        /// </summary>
        /// <param name="FullPathReport"></param>
        /// <param name="dtDataSource"></param>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <param name="PathBieuDo1"></param>
        /// <param name="PathBieuDo2"></param>
        public  void InBaoCaoBieuMau2(string FullPathReport, DataTable dtDataSource,DateTime TuNgay, DateTime DenNgay,string PathBieuDo1,string PathBieuDo2)
        {            
            //Load lên mẫu in của giấy phép vào đối tượng report document
            mReportDocument.Load(FullPathReport);
            //Thực hiện gán Datasource cho report document 
            mReportDocument.SetDataSource(dtDataSource);
            //Thực hiện view thông tin của giấy phép lên form in
            ParameterFields myParameterFields = new ParameterFields();

            ParameterField FieldTuNgay = new ParameterField();
            ParameterDiscreteValue DiscreteValueTuNgay = new ParameterDiscreteValue();

            ParameterField FieldDenNgay = new ParameterField();
            ParameterDiscreteValue DiscreteValueDenNgay = new ParameterDiscreteValue();

            ParameterField FieldBieuDo1_Path= new ParameterField();
            ParameterDiscreteValue DiscreteValueBieuDo1 = new ParameterDiscreteValue();

            ParameterField FieldBieuDo2_Path = new ParameterField();
            ParameterDiscreteValue DiscreteValueBieuDo2 = new ParameterDiscreteValue();
            //TuNgay
            FieldTuNgay.ParameterFieldName = "TuNgay";
            DiscreteValueTuNgay.Value = string.Format("{0: dd/MM/yyyy}",TuNgay );
            FieldTuNgay.CurrentValues.Add(DiscreteValueTuNgay);
            //DenNgay
            FieldDenNgay.ParameterFieldName = "DenNgay";
            DiscreteValueDenNgay.Value = string.Format("{0: dd/MM/yyyy}", DenNgay);
            FieldDenNgay.CurrentValues.Add(DiscreteValueDenNgay);

            // duong dan bieu do 1
            FieldBieuDo1_Path.ParameterFieldName = "BieuDo1_Path";
            DiscreteValueBieuDo1.Value = PathBieuDo1;
            FieldBieuDo1_Path.CurrentValues.Add(DiscreteValueBieuDo1);

            // duong dan anh bieu do 2
            FieldBieuDo2_Path.ParameterFieldName = "BieuDo2_Path";
            DiscreteValueBieuDo2.Value = PathBieuDo2;
            FieldBieuDo2_Path.CurrentValues.Add(DiscreteValueBieuDo2);

            myParameterFields.Add(FieldTuNgay);
            myParameterFields.Add(FieldDenNgay);
            myParameterFields.Add(FieldBieuDo1_Path);
            myParameterFields.Add(FieldBieuDo2_Path);
            //-- Duong dan logo ---
            ParameterField FieldLogo_Path = new ParameterField();
            ParameterDiscreteValue DiscreteValueLogo = new ParameterDiscreteValue();
            FieldLogo_Path.ParameterFieldName = "pLogoPath";
            DiscreteValueLogo.Value = g_LogoPath;
            FieldLogo_Path.CurrentValues.Add(DiscreteValueLogo);
            myParameterFields.Add(FieldLogo_Path);
            // ---------------------
            crGiayPhepViewer.ParameterFieldInfo = myParameterFields;
            crGiayPhepViewer.ReportSource = mReportDocument;

        }
        
        /// <summary>
        /// Bieu mau bao cao so 3
        ///  
        /// </summary>
        /// <param name="FullPathReport">duong dan toi file report</param>
        /// <param name="ListOfBCBM3"></param>
        /// <param name="TuNgayGio"></param>
        /// <param name="DenNgayGio"></param>
        /// <param name="LoaiCuocGoi">0,1,3,7,4,8,10,11</param>
        /// <param name="PhoneNumber"></param>
        /// <param name="SoChuong"></param>
        /// <param name="SoPhutDamThoai"></param>
       public  void InBaoCaoBieuMau3(string FullPathReport,List <BaoCaoBieuMau3> ListOfBCBM3 ,DateTime TuNgayGio, DateTime DenNgayGio,int LoaiCuocGoi, string PhoneNumber, string  SoChuong, string  SoPhutDamThoai )
        {
            try
            {
                //Load lên mẫu in của giấy phép vào đối tượng report document
                mReportDocument.Load(FullPathReport);
                //Thực hiện gán Datasource cho report document 
                mReportDocument.SetDataSource((IEnumerable)ListOfBCBM3);
                //Thực hiện view thông tin của giấy phép lên form in
                ParameterFields myParameterFields = new ParameterFields();

                //TuNgay
                ParameterField FieldTuNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueTuNgay = new ParameterDiscreteValue();                
                FieldTuNgay.ParameterFieldName = "pTuNgayGio";
                DiscreteValueTuNgay.Value = string.Format("{0:HH:mm:ss dd/MM/yyyy}", TuNgayGio);
                FieldTuNgay.CurrentValues.Add(DiscreteValueTuNgay);
                myParameterFields.Add(FieldTuNgay);
                //DenNgay
                ParameterField FieldDenNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueDenNgay = new ParameterDiscreteValue();
                FieldDenNgay.ParameterFieldName = "pDenNgayGio";
                DiscreteValueDenNgay.Value = string.Format("{0:HH:mm:ss dd/MM/yyyy}", DenNgayGio);
                FieldDenNgay.CurrentValues.Add(DiscreteValueDenNgay);
                myParameterFields.Add(FieldDenNgay);
                //Loại cuoc goi
                ParameterField FieldLoaiCuocGoi = new ParameterField();
                ParameterDiscreteValue DiscreteValueLoaiCuocGoi = new ParameterDiscreteValue();
                FieldLoaiCuocGoi.ParameterFieldName = "pLoaiCuocGoi";
                DiscreteValueLoaiCuocGoi.Value = LoaiCuocGoi;
                FieldLoaiCuocGoi.CurrentValues.Add(DiscreteValueLoaiCuocGoi);
                myParameterFields.Add(FieldLoaiCuocGoi);
                // PhoneNumber
                ParameterField FieldPhoneNumber = new ParameterField();
                ParameterDiscreteValue DiscreteValuePhoneNumber = new ParameterDiscreteValue();
                FieldPhoneNumber.ParameterFieldName = "pTuSoDienThoai";
                DiscreteValuePhoneNumber.Value = PhoneNumber;
                FieldPhoneNumber.CurrentValues.Add(DiscreteValuePhoneNumber);
                myParameterFields.Add(FieldPhoneNumber);
                //So Chuong
                ParameterField FieldSoChuong = new ParameterField();
                ParameterDiscreteValue DiscreteValueSoChuong = new ParameterDiscreteValue();
                FieldSoChuong.ParameterFieldName = "pNhacMaySauSoChuong";
                DiscreteValueSoChuong.Value = SoChuong;
                FieldSoChuong.CurrentValues.Add(DiscreteValueSoChuong);
                myParameterFields.Add(FieldSoChuong);
                //SoPhutDamThoai
                ParameterField FieldSoPhutDamThoai = new ParameterField();
                ParameterDiscreteValue DiscreteValueSoPhutDamThoai = new ParameterDiscreteValue();
                FieldSoPhutDamThoai.ParameterFieldName = "pDamThoaiTrenSoPhut";
                DiscreteValueSoPhutDamThoai.Value = SoPhutDamThoai;
                FieldSoPhutDamThoai.CurrentValues.Add(DiscreteValueSoPhutDamThoai);
                myParameterFields.Add(FieldSoPhutDamThoai);

                //-- Duong dan logo ---
                ParameterField FieldLogo_Path = new ParameterField();
                ParameterDiscreteValue DiscreteValueLogo = new ParameterDiscreteValue();
                FieldLogo_Path.ParameterFieldName = "pLogoPath";
                DiscreteValueLogo.Value = g_LogoPath;
                FieldLogo_Path.CurrentValues.Add(DiscreteValueLogo);
                myParameterFields.Add(FieldLogo_Path);
                // ---------------------

                crGiayPhepViewer.ParameterFieldInfo = myParameterFields;
                crGiayPhepViewer.ReportSource = mReportDocument;
            }
            catch (Exception ex)
            {
            }
        }
        
        public void InBaoCaoBieuMau4(string FullPathReport, List<DieuHanhTaxi > ListOfBCBM4, DateTime TuNgayGio, DateTime DenNgayGio)
        {
            try
            {
                //Load lên mẫu in của giấy phép vào đối tượng report document
                mReportDocument.Load(FullPathReport);
                //Thực hiện gán Datasource cho report document 
                mReportDocument.SetDataSource((IEnumerable)ListOfBCBM4);
                //Thực hiện view thông tin của giấy phép lên form in
                ParameterFields myParameterFields = new ParameterFields();

                //TuNgay
                ParameterField FieldTuNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueTuNgay = new ParameterDiscreteValue();
                FieldTuNgay.ParameterFieldName = "pTuNgayGio";
                DiscreteValueTuNgay.Value = string.Format("{0:HH:mm:ss dd/MM/yyyy}", TuNgayGio);
                FieldTuNgay.CurrentValues.Add(DiscreteValueTuNgay);
                myParameterFields.Add(FieldTuNgay);
                //DenNgay
                ParameterField FieldDenNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueDenNgay = new ParameterDiscreteValue();
                FieldDenNgay.ParameterFieldName = "pDenNgayGio";
                DiscreteValueDenNgay.Value = string.Format("{0:HH:mm:ss dd/MM/yyyy}", DenNgayGio);
                FieldDenNgay.CurrentValues.Add(DiscreteValueDenNgay);
                myParameterFields.Add(FieldDenNgay);

                //-- Duong dan logo ---
                ParameterField FieldLogo_Path = new ParameterField();
                ParameterDiscreteValue DiscreteValueLogo = new ParameterDiscreteValue();
                FieldLogo_Path.ParameterFieldName = "pLogoPath";
                DiscreteValueLogo.Value = g_LogoPath;
                FieldLogo_Path.CurrentValues.Add(DiscreteValueLogo);
                myParameterFields.Add(FieldLogo_Path);
                // ---------------------
                crGiayPhepViewer.ParameterFieldInfo = myParameterFields;
                crGiayPhepViewer.ReportSource = mReportDocument;
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>       
        ///TuNgay
        ///DenNgay
        ///DienThoai
        ///ThoiDiemChuyenTongDai
        ///ThoiGianDieuXe
        ///ThoiGianDonKhach
        /// </summary>
        /// <param name="FullPathReport"></param>
        /// <param name="ListOfBCBM5"></param>
        /// <param name="TuNgayGio"></param>
        /// <param name="DenNgayGio"></param>
        /// <param name="?"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="SoChuong"></param>
        /// <param name="SoPhutDamThoai"></param>
        public void InBaoCaoBieuMau5(string FullPathReport, List<DieuHanhTaxi > ListOfBCBM5, DateTime TuNgayGio, DateTime DenNgayGio, string PhoneNumber,string ThoiDiemChuyenTongDai, string ThoiGianDieuxe, string ThoigianDonKhach, string MoiGioiVangLai )
        {
            try
            {
                //Load lên mẫu in của giấy phép vào đối tượng report document
                mReportDocument.Load(FullPathReport);
                //Thực hiện gán Datasource cho report document 
                mReportDocument.SetDataSource((IEnumerable)ListOfBCBM5);
                //Thực hiện view thông tin của giấy phép lên form in
                ParameterFields myParameterFields = new ParameterFields();

                //TuNgay
                ParameterField FieldTuNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueTuNgay = new ParameterDiscreteValue();
                FieldTuNgay.ParameterFieldName = "pTuNgayGio";
                DiscreteValueTuNgay.Value = string.Format("{0:HH:mm:ss dd/MM/yyyy}", TuNgayGio);
                FieldTuNgay.CurrentValues.Add(DiscreteValueTuNgay);
                myParameterFields.Add(FieldTuNgay);
                //DenNgay
                ParameterField FieldDenNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueDenNgay = new ParameterDiscreteValue();
                FieldDenNgay.ParameterFieldName = "pDenNgayGio";
                DiscreteValueDenNgay.Value = string.Format("{0:HH:mm:ss dd/MM/yyyy}", DenNgayGio);
                FieldDenNgay.CurrentValues.Add(DiscreteValueDenNgay);
                myParameterFields.Add(FieldDenNgay);
                // PhoneNumber
                ParameterField FieldPhoneNumber = new ParameterField();
                ParameterDiscreteValue DiscreteValuePhoneNumber = new ParameterDiscreteValue();
                FieldPhoneNumber.ParameterFieldName = "pTuSoDienThoai";
                DiscreteValuePhoneNumber.Value = PhoneNumber;
                FieldPhoneNumber.CurrentValues.Add(DiscreteValuePhoneNumber);
                myParameterFields.Add(FieldPhoneNumber);
                //vung - pVung
                ParameterField FieldVung = new ParameterField();
                ParameterDiscreteValue DiscreteValueVung = new ParameterDiscreteValue();
                FieldVung.ParameterFieldName = "pVung";
                DiscreteValueVung.Value = PhoneNumber;
                FieldVung.CurrentValues.Add(DiscreteValueVung);
                myParameterFields.Add(FieldVung);
                // thoidiem chuyen tong dai
                ParameterField FieldThoiDiemChuyenTongDai = new ParameterField();
                ParameterDiscreteValue DiscreteValueThoiDiemChuyenTongDai = new ParameterDiscreteValue();
                FieldThoiDiemChuyenTongDai.ParameterFieldName = "pThoiGianChuyenTongDai";
                DiscreteValueThoiDiemChuyenTongDai.Value = PhoneNumber;
                FieldThoiDiemChuyenTongDai.CurrentValues.Add(DiscreteValueThoiDiemChuyenTongDai);
                myParameterFields.Add(FieldThoiDiemChuyenTongDai);
                //ThoiGianDieuXe
                ParameterField FieldThoiGianDieuXe = new ParameterField();
                ParameterDiscreteValue DiscreteValueThoiGianDieuXe = new ParameterDiscreteValue();
                FieldThoiGianDieuXe.ParameterFieldName = "pThoiGianDieuXe";
                DiscreteValueThoiGianDieuXe.Value = PhoneNumber;
                FieldThoiGianDieuXe.CurrentValues.Add(DiscreteValueThoiGianDieuXe);
                myParameterFields.Add(FieldThoiGianDieuXe);
                //ThoiGianDonKhach
                ParameterField FieldThoiGianDonKhach = new ParameterField();
                ParameterDiscreteValue DiscreteValueThoiGianDonKhach = new ParameterDiscreteValue();
                FieldThoiGianDonKhach.ParameterFieldName = "pThoiGianDonKhach";
                DiscreteValueThoiGianDonKhach.Value = PhoneNumber;
                FieldThoiGianDonKhach.CurrentValues.Add(DiscreteValueThoiGianDonKhach);
                myParameterFields.Add(FieldThoiGianDonKhach);

                //-- Duong dan logo ---
                ParameterField FieldLogo_Path = new ParameterField();
                ParameterDiscreteValue DiscreteValueLogo = new ParameterDiscreteValue();
                FieldLogo_Path.ParameterFieldName = "pLogoPath";
                DiscreteValueLogo.Value = g_LogoPath;
                FieldLogo_Path.CurrentValues.Add(DiscreteValueLogo);
                myParameterFields.Add(FieldLogo_Path);
                // ---------------------
               /// CMS

                ParameterField FieldMoiGioiVangLai = new ParameterField();
                ParameterDiscreteValue DiscreteValueMoiGioiVangLai = new ParameterDiscreteValue();
                FieldMoiGioiVangLai.ParameterFieldName = "pLoaiKhachHang";
                DiscreteValueMoiGioiVangLai.Value = MoiGioiVangLai ;
                FieldMoiGioiVangLai.CurrentValues.Add(DiscreteValueMoiGioiVangLai);
                myParameterFields.Add(FieldMoiGioiVangLai);

                crGiayPhepViewer.ParameterFieldInfo = myParameterFields;
                crGiayPhepViewer.ReportSource = mReportDocument;
            }
            catch (Exception ex)
            {
            }
        }

        public void InBaoCaoBieuMau6(string FullPathReport, List<BaoCaoBieuMau3 > ListOfBCBM6, DateTime TuNgayGio, DateTime DenNgayGio,string Vung, string ThoiGianDieuXe, string LyDoKhongDonDuoc)
        {
            try
            {
                //Load lên mẫu in của giấy phép vào đối tượng report document
                mReportDocument.Load(FullPathReport);
                //Thực hiện gán Datasource cho report document 
                mReportDocument.SetDataSource((IEnumerable)ListOfBCBM6);
                //Thực hiện view thông tin của giấy phép lên form in
                ParameterFields myParameterFields = new ParameterFields();

                //TuNgay
                ParameterField FieldTuNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueTuNgay = new ParameterDiscreteValue();
                FieldTuNgay.ParameterFieldName = "pTuNgayGio";
                DiscreteValueTuNgay.Value = string.Format("{0:HH:mm:ss dd/MM/yyyy}", TuNgayGio);
                FieldTuNgay.CurrentValues.Add(DiscreteValueTuNgay);
                myParameterFields.Add(FieldTuNgay);
                //DenNgay
                ParameterField FieldDenNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueDenNgay = new ParameterDiscreteValue();
                FieldDenNgay.ParameterFieldName = "pDenNgayGio";
                DiscreteValueDenNgay.Value = string.Format("{0:HH:mm:ss dd/MM/yyyy}", DenNgayGio);
                FieldDenNgay.CurrentValues.Add(DiscreteValueDenNgay);
                myParameterFields.Add(FieldDenNgay);
                
                //vung - pVung
                ParameterField FieldVung = new ParameterField();
                ParameterDiscreteValue DiscreteValueVung = new ParameterDiscreteValue();
                FieldVung.ParameterFieldName = "pVung";
                DiscreteValueVung.Value = Vung ;
                FieldVung.CurrentValues.Add(DiscreteValueVung);
                myParameterFields.Add(FieldVung);             
                //ThoiGianDieuXe
                ParameterField FieldThoiGianDieuXe = new ParameterField();
                ParameterDiscreteValue DiscreteValueThoiGianDieuXe = new ParameterDiscreteValue();
                FieldThoiGianDieuXe.ParameterFieldName = "pThoiGianDieuXe";
                DiscreteValueThoiGianDieuXe.Value = ThoiGianDieuXe ;
                FieldThoiGianDieuXe.CurrentValues.Add(DiscreteValueThoiGianDieuXe);
                myParameterFields.Add(FieldThoiGianDieuXe);
                // ly do khong don duoc khach 
                ParameterField FieldLyDoKhongDonDuocKhach = new ParameterField();
                ParameterDiscreteValue DiscreteValueLyDoKhongDonDuocKhach = new ParameterDiscreteValue();
                FieldLyDoKhongDonDuocKhach.ParameterFieldName = "pLyDoKhongDonDuocKhach";
                DiscreteValueLyDoKhongDonDuocKhach.Value = LyDoKhongDonDuoc ;
                FieldLyDoKhongDonDuocKhach.CurrentValues.Add(DiscreteValueLyDoKhongDonDuocKhach);
                myParameterFields.Add(FieldLyDoKhongDonDuocKhach);
                //-- Duong dan logo ---
                ParameterField FieldLogo_Path = new ParameterField();
                ParameterDiscreteValue DiscreteValueLogo = new ParameterDiscreteValue();
                FieldLogo_Path.ParameterFieldName = "pLogoPath";
                DiscreteValueLogo.Value = g_LogoPath;
                FieldLogo_Path.CurrentValues.Add(DiscreteValueLogo);
                myParameterFields.Add(FieldLogo_Path);
                // ---------------------
                crGiayPhepViewer.ParameterFieldInfo = myParameterFields;
                crGiayPhepViewer.ReportSource = mReportDocument;
            }
            catch (Exception ex)
            {
            }
        }
        
        /// <summary>
        /// In bao cao bieu mau so 7 , bao cao cuoc goi moi gioi
        /// </summary>
        /// <param name="FullPathReport"></param>
        /// <param name="ListOfBCBM7"></param>
        /// <param name="TuNgayGio"></param>
        /// <param name="DenNgayGio"></param>
        /// <param name="TenNhanVien"></param>
        /// 
        public void InBaoCaoBieuMau7(string FullPathReport, List<BacCao_CuocGoiMoiGioi > ListOfBCBM7, DateTime TuNgayGio, DateTime DenNgayGio, string TenNhanVien)
        {
            try
            {
                //Load lên mẫu in của giấy phép vào đối tượng report document
                mReportDocument.Load(FullPathReport);
                //Thực hiện gán Datasource cho report document 
                mReportDocument.SetDataSource((IEnumerable)ListOfBCBM7);
                //Thực hiện view thông tin của giấy phép lên form in
                ParameterFields myParameterFields = new ParameterFields();

                //TuNgay
                ParameterField FieldTuNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueTuNgay = new ParameterDiscreteValue();
                FieldTuNgay.ParameterFieldName = "pTuNgay";
                DiscreteValueTuNgay.Value = string.Format("{0:HH:mm:ss dd/MM/yyyy}", TuNgayGio);
                FieldTuNgay.CurrentValues.Add(DiscreteValueTuNgay);
                myParameterFields.Add(FieldTuNgay);
                //DenNgay
                ParameterField FieldDenNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueDenNgay = new ParameterDiscreteValue();
                FieldDenNgay.ParameterFieldName = "pDenNgay";
                DiscreteValueDenNgay.Value = string.Format("{0:HH:mm:ss dd/MM/yyyy}", DenNgayGio);
                FieldDenNgay.CurrentValues.Add(DiscreteValueDenNgay);
                myParameterFields.Add(FieldDenNgay);
                // TenNhanVien
                ParameterField FieldTenNhanVien = new ParameterField();
                ParameterDiscreteValue DiscreteValueTenNhanVien = new ParameterDiscreteValue();
                FieldTenNhanVien.ParameterFieldName = "pNhanVien";
                DiscreteValueTenNhanVien.Value = TenNhanVien ;
                FieldTenNhanVien.CurrentValues.Add(DiscreteValueTenNhanVien);
                myParameterFields.Add(FieldTenNhanVien);
                //-- Duong dan logo ---
                ParameterField FieldLogo_Path = new ParameterField();
                ParameterDiscreteValue DiscreteValueLogo = new ParameterDiscreteValue();
                FieldLogo_Path.ParameterFieldName = "pLogoPath";
                DiscreteValueLogo.Value = g_LogoPath;
                FieldLogo_Path.CurrentValues.Add(DiscreteValueLogo);
                myParameterFields.Add(FieldLogo_Path);

                crGiayPhepViewer.ParameterFieldInfo = myParameterFields;
                crGiayPhepViewer.ReportSource = mReportDocument;
            }
            catch (Exception ex)
            {
            }
        }
      /// <summary>
      /// TuNgayGio
        //DenNgayGio
        //TenKhachHang 
        //DiaChi
        //DienThoai
        //NhanVien
      /// </summary>
      /// <param name="FullPathReport"></param>
      /// <param name="ListOfBCBM8"></param>
      /// <param name="TuNgayGio"></param>
      /// <param name="DenNgayGio"></param>
      /// <param name="TenNhanVien"></param>
        public void InBaoCaoBieuMau10(string FullPathReport, List<BaoCao_BieuMau8> ListOfBCBM8, DateTime TuNgayGio, DateTime DenNgayGio,string TenKhachHang,string DiaChi, string SoDienThoai, string TenNhanVien)
        {
            try
            {
                //Load lên mẫu in của giấy phép vào đối tượng report document
                mReportDocument.Load(FullPathReport);
                //Thực hiện gán Datasource cho report document 
                mReportDocument.SetDataSource((IEnumerable)ListOfBCBM8);
                //Thực hiện view thông tin của giấy phép lên form in
                ParameterFields myParameterFields = new ParameterFields();

                //TuNgay
                ParameterField FieldTuNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueTuNgay = new ParameterDiscreteValue();
                FieldTuNgay.ParameterFieldName = "pTuNgayGio";
                DiscreteValueTuNgay.Value = string.Format("{0:HH:mm:ss dd/MM/yyyy}", TuNgayGio);
                FieldTuNgay.CurrentValues.Add(DiscreteValueTuNgay);
                myParameterFields.Add(FieldTuNgay);
                //DenNgay
                ParameterField FieldDenNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueDenNgay = new ParameterDiscreteValue();
                FieldDenNgay.ParameterFieldName = "pDenNgayGio";
                DiscreteValueDenNgay.Value = string.Format("{0:HH:mm:ss dd/MM/yyyy}", DenNgayGio);
                FieldDenNgay.CurrentValues.Add(DiscreteValueDenNgay);
                myParameterFields.Add(FieldDenNgay);
               // TenKhachHang
                ParameterField FieldTenKhachHang = new ParameterField();
                ParameterDiscreteValue DiscreteValueTenKhachHang = new ParameterDiscreteValue();
                FieldTenKhachHang.ParameterFieldName = "pTenkhachhang";
                DiscreteValueTenKhachHang.Value = TenKhachHang ;
                FieldTenKhachHang.CurrentValues.Add(DiscreteValueTenKhachHang);
                myParameterFields.Add(FieldTenKhachHang);
                
                // DiaChiKhachHang
                ParameterField FieldDiaChiKhachHang = new ParameterField();
                ParameterDiscreteValue DiscreteValueDiaChiKhachHang = new ParameterDiscreteValue();
                FieldDiaChiKhachHang.ParameterFieldName = "pDiachikhachhang";
                DiscreteValueDiaChiKhachHang.Value = DiaChi ;
                FieldDiaChiKhachHang.CurrentValues.Add(DiscreteValueDiaChiKhachHang);
                myParameterFields.Add(FieldDiaChiKhachHang);

                // SoDienThoai
                ParameterField FieldSoDienThoai = new ParameterField();
                ParameterDiscreteValue DiscreteValueSoDienThoai = new ParameterDiscreteValue();
                FieldSoDienThoai.ParameterFieldName = "pDienthoaikhachhang";
                DiscreteValueSoDienThoai.Value = SoDienThoai ;
                FieldSoDienThoai.CurrentValues.Add(DiscreteValueSoDienThoai);
                myParameterFields.Add(FieldSoDienThoai);

                // TenNhanVien
                ParameterField FieldTenNhanVien = new ParameterField();
                ParameterDiscreteValue DiscreteValueTenNhanVien = new ParameterDiscreteValue();
                FieldTenNhanVien.ParameterFieldName = "pNhanVien";
                DiscreteValueTenNhanVien.Value = TenNhanVien;
                FieldTenNhanVien.CurrentValues.Add(DiscreteValueTenNhanVien);
                myParameterFields.Add(FieldTenNhanVien);
                //-- Duong dan logo ---
                ParameterField FieldLogo_Path = new ParameterField();
                ParameterDiscreteValue DiscreteValueLogo = new ParameterDiscreteValue();
                FieldLogo_Path.ParameterFieldName = "pLogoPath";
                DiscreteValueLogo.Value = g_LogoPath;
                FieldLogo_Path.CurrentValues.Add(DiscreteValueLogo);
                myParameterFields.Add(FieldLogo_Path);

                crGiayPhepViewer.ParameterFieldInfo = myParameterFields;
                crGiayPhepViewer.ReportSource = mReportDocument;
            }
            catch (Exception ex)
            {
            }
        }

        public void InBaoCaoBieuMau12(string FullPathReport, DataTable  dtBieuMau12, DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                //Load lên mẫu in của giấy phép vào đối tượng report document
                mReportDocument.Load(FullPathReport);
                //Thực hiện gán Datasource cho report document 
                mReportDocument.SetDataSource(dtBieuMau12);
                //Thực hiện view thông tin của giấy phép lên form in
                ParameterFields myParameterFields = new ParameterFields();

                //TuNgay
                ParameterField FieldTuNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueTuNgay = new ParameterDiscreteValue();
                FieldTuNgay.ParameterFieldName = "pTuNgay";
                DiscreteValueTuNgay.Value = string.Format("{0: dd/MM/yyyy}", TuNgay);
                FieldTuNgay.CurrentValues.Add(DiscreteValueTuNgay);
                myParameterFields.Add(FieldTuNgay);
                //DenNgay
                ParameterField FieldDenNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueDenNgay = new ParameterDiscreteValue();
                FieldDenNgay.ParameterFieldName = "pDenNgay";
                DiscreteValueDenNgay.Value = string.Format("{0: dd/MM/yyyy}", DenNgay);
                FieldDenNgay.CurrentValues.Add(DiscreteValueDenNgay);
                myParameterFields.Add(FieldDenNgay);
                //-- Duong dan logo ---
                ParameterField FieldLogo_Path = new ParameterField();
                ParameterDiscreteValue DiscreteValueLogo = new ParameterDiscreteValue();
                FieldLogo_Path.ParameterFieldName = "pLogoPath";
                DiscreteValueLogo.Value = g_LogoPath;
                FieldLogo_Path.CurrentValues.Add(DiscreteValueLogo);
                myParameterFields.Add(FieldLogo_Path);
                // ---------------------
                crGiayPhepViewer.ParameterFieldInfo = myParameterFields;
                crGiayPhepViewer.ReportSource = mReportDocument;
            }
            catch (Exception ex)
            {
            }
        }

        public void InBaoCaoBieuMau13(string FullPathReport, DataTable dtBieuMau13,string DoDaiCuocGoiTren, DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                //Load lên mẫu in của giấy phép vào đối tượng report document
                mReportDocument.Load(FullPathReport);
                //Thực hiện gán Datasource cho report document 
                mReportDocument.SetDataSource(dtBieuMau13);
                //Thực hiện view thông tin của giấy phép lên form in
                ParameterFields myParameterFields = new ParameterFields();

                //TuNgay
                ParameterField FieldTuNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueTuNgay = new ParameterDiscreteValue();
                FieldTuNgay.ParameterFieldName = "pTuNgay";
                DiscreteValueTuNgay.Value = string.Format("{0: dd/MM/yyyy}", TuNgay);
                FieldTuNgay.CurrentValues.Add(DiscreteValueTuNgay);
                myParameterFields.Add(FieldTuNgay);
                //DenNgay
                ParameterField FieldDenNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueDenNgay = new ParameterDiscreteValue();
                FieldDenNgay.ParameterFieldName = "pDenNgay";
                DiscreteValueDenNgay.Value = string.Format("{0: dd/MM/yyyy}", DenNgay);
                FieldDenNgay.CurrentValues.Add(DiscreteValueDenNgay);
                myParameterFields.Add(FieldDenNgay);

                ParameterField FieldDoDaiCuocGoi = new ParameterField();
                ParameterDiscreteValue DiscreteValueDoDaiCuocGoi = new ParameterDiscreteValue();
                FieldDoDaiCuocGoi.ParameterFieldName = "pThoiGianGoiTren";
                DiscreteValueDoDaiCuocGoi.Value = DoDaiCuocGoiTren; 
                FieldDoDaiCuocGoi.CurrentValues.Add(DiscreteValueDoDaiCuocGoi);
                myParameterFields.Add(FieldDoDaiCuocGoi);

                //-- Duong dan logo ---
                ParameterField FieldLogo_Path = new ParameterField();
                ParameterDiscreteValue DiscreteValueLogo = new ParameterDiscreteValue();
                FieldLogo_Path.ParameterFieldName = "pLogoPath";
                DiscreteValueLogo.Value = g_LogoPath;
                FieldLogo_Path.CurrentValues.Add(DiscreteValueLogo);
                myParameterFields.Add(FieldLogo_Path);
                // ---------------------
                crGiayPhepViewer.ParameterFieldInfo = myParameterFields;
                crGiayPhepViewer.ReportSource = mReportDocument;
            }
            catch (Exception ex)
            {
            }
        }

        public void InBaoCaoBieuMau14(string FullPathReport, List<BaoCaoBieuMau14> ListBC14, DateTime ThoiDiemBao)
        {
            try
            {
                //Load lên mẫu in của giấy phép vào đối tượng report document
                mReportDocument.Load(FullPathReport);
                //Thực hiện gán Datasource cho report document 
                mReportDocument.SetDataSource(ListBC14);
                //Thực hiện view thông tin của giấy phép lên form in
                ParameterFields myParameterFields = new ParameterFields();

                //ThoiDiemBao
                ParameterField FieldTuNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueTuNgay = new ParameterDiscreteValue();
                FieldTuNgay.ParameterFieldName = "pThoiDiemBao";
                DiscreteValueTuNgay.Value = string.Format("{0: HH:mm dd/MM/yyyy}", ThoiDiemBao);
                FieldTuNgay.CurrentValues.Add(DiscreteValueTuNgay);
                myParameterFields.Add(FieldTuNgay);
                
                //-- Duong dan logo ---
                ParameterField FieldLogo_Path = new ParameterField();
                ParameterDiscreteValue DiscreteValueLogo = new ParameterDiscreteValue();
                FieldLogo_Path.ParameterFieldName = "pLogoPath";
                DiscreteValueLogo.Value = g_LogoPath;
                FieldLogo_Path.CurrentValues.Add(DiscreteValueLogo);
                myParameterFields.Add(FieldLogo_Path);
                // ---------------------
                crGiayPhepViewer.ParameterFieldInfo = myParameterFields;
                crGiayPhepViewer.ReportSource = mReportDocument;
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// báo cáo kết quả hoạt động của nhân viên
        /// </summary>
        /// <param name="FullPathReport"></param>
        /// <param name="dtBieuMau16"></param>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        public void InBaoCaoBieuMau16(string FullPathReport, DataTable dtBieuMau16_NVDienThoai, DataTable dtBieuMau16_NVTongDai, DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                //Load lên mẫu in của giấy phép vào đối tượng report document
                mReportDocument.Load(FullPathReport);
                //Thực hiện gán Datasource cho report document 
               // mReportDocument.SetDataSource(dtBieuMau16_NVDienThoai);
                mReportDocument.Subreports["DienThoai"].SetDataSource(dtBieuMau16_NVDienThoai);
                mReportDocument.Subreports["TongDai"].SetDataSource(dtBieuMau16_NVTongDai);
                //Thực hiện view thông tin của giấy phép lên form in
                ParameterFields myParameterFields = new ParameterFields();

                //TuNgay
                ParameterField FieldTuNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueTuNgay = new ParameterDiscreteValue();
                FieldTuNgay.ParameterFieldName = "pTuNgay";
                DiscreteValueTuNgay.Value = string.Format("{0: dd/MM/yyyy}", TuNgay);
                FieldTuNgay.CurrentValues.Add(DiscreteValueTuNgay);
                myParameterFields.Add(FieldTuNgay);
                //DenNgay
                ParameterField FieldDenNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueDenNgay = new ParameterDiscreteValue();
                FieldDenNgay.ParameterFieldName = "pDenNgay";
                DiscreteValueDenNgay.Value = string.Format("{0: dd/MM/yyyy}", DenNgay);
                FieldDenNgay.CurrentValues.Add(DiscreteValueDenNgay);
                myParameterFields.Add(FieldDenNgay);
                //-- Duong dan logo ---
                ParameterField FieldLogo_Path = new ParameterField();
                ParameterDiscreteValue DiscreteValueLogo = new ParameterDiscreteValue();
                FieldLogo_Path.ParameterFieldName = "pLogoPath";
                DiscreteValueLogo.Value = g_LogoPath;
                FieldLogo_Path.CurrentValues.Add(DiscreteValueLogo);
                myParameterFields.Add(FieldLogo_Path);
                // ---------------------
                crGiayPhepViewer.ParameterFieldInfo = myParameterFields;
                crGiayPhepViewer.ReportSource = mReportDocument;
            }
            catch (Exception ex)
            {
            }
        }




        public  void InBaoCao(string FullPathReport, DataTable dtDataSource,string TuNgay, string DenNgay)
        {

            //Load lên mẫu in của giấy phép vào đối tượng report document
            mReportDocument.Load(FullPathReport);            
            //Thực hiện gán Datasource cho report document 
            mReportDocument.SetDataSource(dtDataSource);
            //Thực hiện view thông tin của giấy phép lên form in
            ParameterFields myParameterFields = new ParameterFields ();
            
            ParameterField FieldTuNgay = new ParameterField ();            
            ParameterDiscreteValue DiscreteValueTuNgay = new ParameterDiscreteValue ();

            ParameterField FieldDenNgay = new ParameterField();
            ParameterDiscreteValue DiscreteValueDenNgay = new ParameterDiscreteValue();
            //TuNgay
            FieldTuNgay.ParameterFieldName = "pTuNgay";
            DiscreteValueTuNgay.Value = TuNgay;
            FieldTuNgay.CurrentValues.Add(DiscreteValueTuNgay);
            //DenNgay
            FieldDenNgay.ParameterFieldName = "pDenNgay";
            DiscreteValueDenNgay.Value = DenNgay;
            FieldDenNgay.CurrentValues.Add(DiscreteValueDenNgay);
 
            myParameterFields.Add(FieldTuNgay);
            myParameterFields.Add(FieldDenNgay );

            crGiayPhepViewer.ParameterFieldInfo = myParameterFields;
            crGiayPhepViewer.ReportSource = mReportDocument;


            
        }

        /// <summary>
        /// Tin bao cao cho doi tac
        /// </summary>
        /// <param name="FullPathReport"></param>
        /// <param name="dtDataSource"></param>
        /// <param name="DoiTac"></param>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        private void InBaoCao(string FullPathReport, DataTable dtDataSource, DoiTac DoiTac, string TuNgay, string DenNgay)
        {

            //Load lên mẫu in của giấy phép vào đối tượng report document
            mReportDocument.Load(FullPathReport);
            //Thực hiện gán Datasource cho report document 
            mReportDocument.SetDataSource(dtDataSource);
            //Thực hiện view thông tin của giấy phép lên form in
            ParameterFields myParameterFields = new ParameterFields();

            ParameterField FieldTuNgay = new ParameterField();
            ParameterDiscreteValue DiscreteValueTuNgay = new ParameterDiscreteValue();

            ParameterField FieldDenNgay = new ParameterField();
            ParameterDiscreteValue DiscreteValueDenNgay = new ParameterDiscreteValue();
            //TuNgay
            FieldTuNgay.ParameterFieldName = "TuNgay";
            DiscreteValueTuNgay.Value = TuNgay;
            FieldTuNgay.CurrentValues.Add(DiscreteValueTuNgay);
            //DenNgay
            FieldDenNgay.ParameterFieldName = "DenNgay";
            DiscreteValueDenNgay.Value = DenNgay;
            FieldDenNgay.CurrentValues.Add(DiscreteValueDenNgay);

            #region Cho DoiTAc
            //Name
            ParameterField FieldTenDoiTac = new ParameterField();
            ParameterDiscreteValue DiscreteValueTenDoiTac = new ParameterDiscreteValue();
            
            FieldTenDoiTac.ParameterFieldName = "TenDoiTac";
            DiscreteValueTenDoiTac.Value = DoiTac.Name ;
            FieldTenDoiTac.CurrentValues.Add(DiscreteValueTenDoiTac);
            //DiaChi
            ParameterField FieldDiaChiDoiTac = new ParameterField();
            ParameterDiscreteValue DiscreteValueDiaChiDoiTac = new ParameterDiscreteValue();

            FieldDiaChiDoiTac.ParameterFieldName = "DiaChiDoiTac";
            DiscreteValueDiaChiDoiTac.Value = DoiTac.Address;
            FieldDiaChiDoiTac.CurrentValues.Add(DiscreteValueDiaChiDoiTac);

            //DienThoai
            ParameterField FieldDienThoaiDoiTac = new ParameterField();
            ParameterDiscreteValue DiscreteValueDienThoaiDoiTac = new ParameterDiscreteValue();

            FieldDienThoaiDoiTac.ParameterFieldName = "DienThoaiDoiTac";
            DiscreteValueDienThoaiDoiTac.Value = DoiTac.Phones;
            FieldDienThoaiDoiTac.CurrentValues.Add(DiscreteValueDienThoaiDoiTac);
            #endregion Cho DoiTAc

            myParameterFields.Add(FieldTuNgay);
            myParameterFields.Add(FieldDenNgay);
            //DoiTac
            myParameterFields.Add(FieldTenDoiTac);
            myParameterFields.Add(FieldDienThoaiDoiTac );
            myParameterFields.Add(FieldDiaChiDoiTac );



            crGiayPhepViewer.ParameterFieldInfo = myParameterFields;

            crGiayPhepViewer.ReportSource = mReportDocument;
        }


        #region BAO CAO MOI - TaxiGroup

        public void InBaoCao_5_3_HanhTrinhXe(string FullPathReport, DataTable dtSource, DateTime TuNgayGio, DateTime DenNgayGio,string soHieuXe)
        {
            try
            {
                //Load lên mẫu in của giấy phép vào đối tượng report document
                mReportDocument.Load(FullPathReport);
                //Thực hiện gán Datasource cho report document 
                mReportDocument.SetDataSource( dtSource);
                //Thực hiện view thông tin của giấy phép lên form in
                ParameterFields myParameterFields = new ParameterFields();

                //TuNgay
                ParameterField FieldTuNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueTuNgay = new ParameterDiscreteValue();
                FieldTuNgay.ParameterFieldName = "pTuNgay";
                DiscreteValueTuNgay.Value = string.Format("{0:HH:mm:ss dd/MM/yyyy}", TuNgayGio);
                FieldTuNgay.CurrentValues.Add(DiscreteValueTuNgay);
                myParameterFields.Add(FieldTuNgay);
                //DenNgay
                ParameterField FieldDenNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueDenNgay = new ParameterDiscreteValue();
                FieldDenNgay.ParameterFieldName = "pDenNgay";
                DiscreteValueDenNgay.Value = string.Format("{0:HH:mm:ss dd/MM/yyyy}", DenNgayGio);
                FieldDenNgay.CurrentValues.Add(DiscreteValueDenNgay);
                myParameterFields.Add(FieldDenNgay);
                //So hieu xe
                ParameterField FieldLoaiCuocGoi = new ParameterField();
                ParameterDiscreteValue DiscreteValueLoaiCuocGoi = new ParameterDiscreteValue();
                FieldLoaiCuocGoi.ParameterFieldName = "pSoHieuXe";
                DiscreteValueLoaiCuocGoi.Value = soHieuXe;
                FieldLoaiCuocGoi.CurrentValues.Add(DiscreteValueLoaiCuocGoi);
                myParameterFields.Add(FieldLoaiCuocGoi);
                 
                crGiayPhepViewer.ParameterFieldInfo = myParameterFields;
                crGiayPhepViewer.ReportSource = mReportDocument;
            }
            catch (Exception ex)
            {
            }
        }

        public void InBaoCao_6_4_TongHopMoiGioiGoiQuaTrungTam(string FullPathReport, DataTable dtSource,DataTable dtSourceSubReport, DateTime TuNgayGio, DateTime DenNgayGio) 
        {
            try
            {
                //Load lên mẫu in của giấy phép vào đối tượng report document
                mReportDocument.Load(FullPathReport);
                //Thực hiện gán Datasource cho report document 
                mReportDocument.SetDataSource(dtSource);
                if(mReportDocument.Subreports[0]!=null)
                    mReportDocument.Subreports[0].SetDataSource(dtSourceSubReport);
                //Thực hiện view thông tin của giấy phép lên form in
                ParameterFields myParameterFields = new ParameterFields();

                //TuNgay
                ParameterField FieldTuNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueTuNgay = new ParameterDiscreteValue();
                FieldTuNgay.ParameterFieldName = "pTuNgay";
                DiscreteValueTuNgay.Value = string.Format("{0:HH:mm:ss dd/MM/yyyy}", TuNgayGio);
                FieldTuNgay.CurrentValues.Add(DiscreteValueTuNgay);
                myParameterFields.Add(FieldTuNgay);
                //DenNgay
                ParameterField FieldDenNgay = new ParameterField();
                ParameterDiscreteValue DiscreteValueDenNgay = new ParameterDiscreteValue();
                FieldDenNgay.ParameterFieldName = "pDenNgay";
                DiscreteValueDenNgay.Value = string.Format("{0:HH:mm:ss dd/MM/yyyy}", DenNgayGio);
                FieldDenNgay.CurrentValues.Add(DiscreteValueDenNgay);
                myParameterFields.Add(FieldDenNgay);
                 

                crGiayPhepViewer.ParameterFieldInfo = myParameterFields;
                crGiayPhepViewer.ReportSource = mReportDocument;
            }
            catch (Exception ex)
            {
            }
        }
      
        #endregion
    }
}