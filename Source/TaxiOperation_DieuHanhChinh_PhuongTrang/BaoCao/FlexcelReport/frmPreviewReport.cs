using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FlexCel.Render;
using FlexCel.Winforms;
using FlexCel.XlsAdapter;
using System.Diagnostics;
namespace Taxi.GUI 
{
    public partial class frmPreviewReport : Form
    {
        #region Declare & Constructor!

        private DataSet p_ds;
        private int p_rpType;
        private int _rowIndex;//Truong hop chi 1 row!

        private FlexCelPreview FlexCelPreview1;
        private FlexCelPreview thumbs;
        private FlexCelImgExport flexCelImgExport1;
        private FlexCelPrintDocument flexCelPrintDocument1;
        private XlsFile xls;

        //Luu tru du lieu tren mem!
        private MemoryStream _xlsMemoryStream;
        private FileStream _templateStream;
        private MemoryStream c_XlsStream;

        public frmPreviewReport(DataSet ds , int reportType,int index=0)
        {
            InitializeComponent();

            p_ds = ds;
            p_rpType = reportType;
            _rowIndex = index; 
        }

        #endregion

        #region Events
        private void frmPreviewReport_Load(object sender, EventArgs e)
        {
            LoadUC();
            LoadFile();
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            FlexCelPreview1.StartPage--;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            FlexCelPreview1.StartPage++;
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFiletoXls(c_XlsStream);
            this.Close();
        }

        #endregion

        #region Methods

        #region Ham quan trong
        private void LoadUC()
        {
            try
            {
                #region add control de view du lieu tu stream
              
                FlexCelPreview1 = new FlexCel.Winforms.FlexCelPreview();
                //new System.EventHandler(this.exitToolStripMenuItem_Cli ck);
                FlexCelPreview1.StartPageChanged += new System.EventHandler(this.FlexCelPreview1_StartPageChanged);
                FlexCelPreview1.ZoomChanged += new System.EventHandler(this.FlexCelPreview1_ZoomChanged);

                //System.EventHandler FlexCelPreview1_StartPageChanged = new System.EventHandler(this.FlexCelPreview1_StartPageChanged);
                flexCelImgExport1 = new FlexCel.Render.FlexCelImgExport();
                FlexCelPreview1.Document = flexCelImgExport1;
                FlexCelPreview1.Dock = DockStyle.Fill;
                FlexCelPreview1.MaximumSize = new System.Drawing.Size(1000,600);
                previewPanel.Controls.Add(FlexCelPreview1);

                #endregion

                #region add control hien thi cac trang cua bao cao thu nho
                
                thumbs = new FlexCel.Winforms.FlexCelPreview();
                thumbs.Document = flexCelImgExport1;
                thumbs.ThumbnailLarge = FlexCelPreview1;
                #endregion

                flexCelPrintDocument1 = new FlexCel.Render.FlexCelPrintDocument();
                flexCelPrintDocument1.AllVisibleSheets = false;
            }

            catch (Exception ex)
            {
                //ErrorLog.log.Error(ex.ToString());
            }
        }
        private void LoadFile()
        {
            try
            {
                //Khai bao bien
                FlexCel.Report.FlexCelReport flcReport = new FlexCel.Report.FlexCelReport();
                string path = "";

                //Xac dinh ten file mau theo loai bao cao
                path = GetXlsFileDesign();

                //Add du lieu tu ds, bien vao Flexcel report
                if (p_rpType<30)
                    flcReport.AddTable(p_ds);       // Gan du lieu vao ds
                SetValueFlexcel(ref flcReport);     // Thiet lap gt cho cac bien object

                #region Luu file xls len memory stream
                //FlexCelPreview1.CenteredPreview = true; 
                //_templateStream.Flush();
                try
                {
                    _templateStream = new FileStream(path, FileMode.Open);
                }
                catch
                {

                }

                _xlsMemoryStream = new MemoryStream();
                flcReport.Run(_templateStream, _xlsMemoryStream);//Chet o day???????????????????????
                #endregion

                #region View file tren mem len FlexCelPreview1
                xls = new FlexCel.XlsAdapter.XlsFile();
                _xlsMemoryStream.Position = 0;
                xls.Open(_xlsMemoryStream);
                //
                SetValuePageSize(ref flexCelImgExport1);

                flexCelImgExport1.Workbook = xls;
                FlexCelPreview1.InvalidatePreview();
                #endregion

                //Hien thi so trag, zoom cua page
                txtPage.Text = String.Format("{0} / {1}", FlexCelPreview1.StartPage, FlexCelPreview1.TotalPages);
                //UpdateZoom();

                //Gan gia tri stream cho bien toan cuc cua form
                c_XlsStream = _xlsMemoryStream;
                _templateStream.Dispose();
            }
            catch (Exception ex)
            {
                //Neu loi ko Kiet xuat dc
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Xảy ra lỗi trong quá trình lấy dữ liệu và tạo báo cáo!", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                //this.Close();
            }
        }
        //Lay cac template Excel trong thu muc report!
        private string GetXlsFileDesign()
        {
            try
            {
                string _fileExcelName = "";
                string _path = Common.ExcelDesignFilePath;

                #region Xac dinh ten file mau theo loai bao cao lay trong ConstParam!

                if (p_rpType == ConstParam.TongHopPhanAnh)//Phan loai bao cao trong he thong!
                {
                    _fileExcelName = "BaoCaoTest.xls";
                }
                if (p_rpType == ConstParam.GiaiQuyetPhanAnh)
                {
                    _fileExcelName = "GiaiQuyetPhanAnh.xls";
                }

                #endregion

                //Check xem file thiet ke co ton tai trong Thu muc ko 
                _path += _fileExcelName;
                //Khac phuc loi ko ket xuat duoc bao cao nhieu lan
                string exepath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "");
                _path = exepath + "\\" + _path.Replace("//", "\\");
                if (!File.Exists(_path))
                {
                    MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                    msgDialog.Show(this, "File excel thiết kế không tồn tại trong thư mục /report", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    return "";
                }

                return _path;
            }
            catch (Exception)
            {
                return "";
            }
        }
        private void SetValueFlexcel(ref FlexCel.Report.FlexCelReport flcReport)
        {
            try
            {
                Common.SetValueExportByString(ref flcReport, "ngayht", DateTime.Now);
                Common.SetValueExportByString(ref flcReport, "TuNgay", DateTime.Now);
                Common.SetValueExportByString(ref flcReport, "DenNgay", DateTime.Now);

                if (p_rpType == ConstParam.TongHopPhanAnh)
                {
                    Common.SetValueExportByString(ref flcReport, "KhachHang", p_ds.Tables[0].Rows[_rowIndex][0]);
                    Common.SetValueExportByString(ref flcReport, "SDT", p_ds.Tables[0].Rows[_rowIndex][1]);
                    Common.SetValueExportByString(ref flcReport, "NhanVien", p_ds.Tables[0].Rows[_rowIndex][2]);
                    Common.SetValueExportByString(ref flcReport, "ThoiGianNhan", p_ds.Tables[0].Rows[_rowIndex][3]);
                    Common.SetValueExportByString(ref flcReport, "ThoiGianXuong", p_ds.Tables[0].Rows[_rowIndex][4]);
                    Common.SetValueExportByString(ref flcReport, "LoTrinh", p_ds.Tables[0].Rows[_rowIndex]["Tong"].ToString());
                }
                if (p_rpType == ConstParam.GiaiQuyetPhanAnh)
                {
                    string strDot = ConstParam.DotLine; 
                    Common.SetValueExportByString(ref flcReport, "TenKhachHang", p_ds.Tables[0].Rows[_rowIndex]["TenKH"]);
                    Common.SetValueExportByString(ref flcReport, "LoaiPhanAnh", p_ds.Tables[0].Rows[_rowIndex]["LoaiPA"]);
                    Common.SetValueExportByString(ref flcReport, "SoDienThoai", p_ds.Tables[0].Rows[_rowIndex]["SoDT"] );
                    Common.SetValueExportByString(ref flcReport, "TenDayDu", p_ds.Tables[0].Rows[_rowIndex]["TenDayDu"]);
                    Common.SetValueExportByString(ref flcReport, "ThoiGianPhanAnh", ((DateTime)p_ds.Tables[0].Rows[_rowIndex]["TGPA"]).ToString("HH:MM - dd/MM/yyyy ") );
                    Common.SetValueExportByString(ref flcReport, "ThoiGianPS", ((DateTime)p_ds.Tables[0].Rows[_rowIndex]["TGPS"]).ToString("HH:MM - dd/MM/yyyy "));
                    Common.SetValueExportByString(ref flcReport, "LoTrinhDi", p_ds.Tables[0].Rows[_rowIndex]["LTTu"]);
                    Common.SetValueExportByString(ref flcReport, "LoTrinhDen", p_ds.Tables[0].Rows[_rowIndex]["LTDen"]);
                    Common.SetValueExportByString(ref flcReport, "TienDH", p_ds.Tables[0].Rows[_rowIndex]["DHT"]);
                    Common.SetValueExportByString(ref flcReport, "DacDiem", p_ds.Tables[0].Rows[_rowIndex]["DacDiem"]);
                    Common.SetValueExportByString(ref flcReport, "DoiTuong", p_ds.Tables[0].Rows[_rowIndex]["DoiTuong"]);
                    Common.SetValueExportByString(ref flcReport, "GiaiQuyet", p_ds.Tables[0].Rows[_rowIndex]["GQ_KQGQ"]);
                    Common.SetValueExportByString(ref flcReport, "GiaiQuyetYKKH", p_ds.Tables[0].Rows[_rowIndex]["GQ_YKKH"]);
                    Common.SetValueExportByString(ref flcReport, "NoiDungKN", p_ds.Tables[0].Rows[_rowIndex]["NoiDung"]);
                    Common.SetValueExportByString(ref flcReport, "DotLine", strDot);
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.log.Error(ex.ToString());
            }
        }

        #endregion
        //Thiet lap che do A4 theo loai bao cao
        private void SetValuePageSize(ref FlexCel.Render.FlexCelImgExport flexCelImgExport)
        {

            if (flexCelImgExport != null)
            {
                //Mac dinh la A4 xoay ngang
                FlexCel.Core.TPaperDimensions _TPaperSize_A4 = new FlexCel.Core.TPaperDimensions(FlexCel.Core.TPaperSize.A4);
                FlexCel.Core.TPaperDimensions _TPaperSize_A4Rotated = new FlexCel.Core.TPaperDimensions(FlexCel.Core.TPaperSize.A4Rotated);
                flexCelImgExport1.PageSize = _TPaperSize_A4;

                //T.Hop dac biet xoay doc Portrait!
                //if ((int)p_rpType == (int)Common.ConstPara.ReportTypeEnum.ConnectionInformation || (int)p_rpType == (int)Common.ConstPara.ReportTypeEnum.SpeedMsgIn_N_Seconds_ByDays
                //    || (int)p_rpType == (int)Common.ConstPara.ReportTypeEnum.SpeedMsgIn_N_Seconds_InDay || (int)p_rpType == (int)Common.ConstPara.ReportTypeEnum.MemberHaveOrder
                //    || (int)p_rpType == (int)Common.ConstPara.ReportTypeEnum.MemberHaveNotOrder
                //    || (int)p_rpType == (int)Common.ConstPara.ReportTypeEnum.TotalConnect_ByMonth || (int)p_rpType == (int)Common.ConstPara.ReportTypeEnum.TotalConnect_ByDay)
                //{
                //    flexCelImgExport1.PageSize = _TPaperSize_A4;
                //}
            }
        }

        private void SaveFiletoXls(MemoryStream _test)
        {
            try
            {
                if (flexCelImgExport1.Workbook == null)
                {
                    //NoteBox.Show("Không có file nào được mở", "", NoteBoxLevel.Error);
                    return;
                }

                System.Windows.Forms.SaveFileDialog saveReport = new System.Windows.Forms.SaveFileDialog();
                saveReport.Filter = "Excel files (*.xls)|*.xls";

                if (saveReport.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _test.Position = 0;
                    byte[] bytes = new byte[_test.Length];
                    _test.Read(bytes, 0, (int)_test.Length);

                    FileStream OutStream = new FileStream(saveReport.FileName, FileMode.Create);
                    OutStream.Write(bytes, 0, bytes.Length);
                    OutStream.Close();

                    MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                    string result = msgDialog.Show(this, "Bạn có muốn mở file vừa kết xuất không?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OKCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString();
                    if (result == DialogResult.OK.ToString())
                    {
                        Process.Start(saveReport.FileName);
                    }
                }
            }
            catch
            {

            }
        }

        #region Ham xu ly Page & Zoom
        private void FlexCelPreview1_ZoomChanged(object sender, System.EventArgs e)
        {
            UpdateZoom();
        }

        private void FlexCelPreview1_StartPageChanged(object sender, System.EventArgs e)
        {
            UpdatePages();
        }
        private void UpdatePages()
        {
            try
            {
                txtPage.Text = String.Format("{0} / {1}", FlexCelPreview1.StartPage, FlexCelPreview1.TotalPages);
            }
            catch (Exception ex)
            {
                //ErrorLog.log.Error(ex.ToString());
            }
        }

        private void ChangePages()
        {
            try
            {
                string s = txtPage.Text.Trim();
                int pos = 0;
                while (pos < s.Length && s[pos] >= '0' && s[pos] <= '9') pos++;
                if (pos > 0)
                {
                    int page = FlexCelPreview1.StartPage;
                    try
                    {
                        page = Convert.ToInt32(s.Substring(0, pos));
                    }
                    catch (Exception)
                    {
                    }

                    FlexCelPreview1.StartPage = page;
                }
                UpdatePages();
            }
            catch (Exception ex)
            {
                //ErrorLog.log.Error(ex.ToString());
            }
        }

        private void UpdateZoom()
        {
            try
            {
                //edZoom.Text = String.Format("{0}%", (int)Math.Round(FlexCelPreview1.Zoom * 100));
            }
            catch (Exception ex)
            {
                //ErrorLog.log.Error(ex.ToString());
            }
        }

        private void ChangeZoom()
        {
            try
            {
                //string s = edZoom.Text.Trim();
                //int pos = 0;
                //while (pos < s.Length && s[pos] >= '0' && s[pos] <= '9') pos++;
                //if (pos > 0)
                //{
                //    int zoom = (int)Math.Round(FlexCelPreview1.Zoom * 100);
                //    try
                //    {
                //        zoom = Convert.ToInt32(s.Substring(0, pos));
                //    }
                //    catch (Exception)
                //    {
                //    }

                //    FlexCelPreview1.Zoom = zoom / 100f;
                //}
                //UpdateZoom();
            }
            catch (Exception ex)
            {
                //ErrorLog.log.Error(ex.ToString());
            }
        }

        #endregion

        #endregion

    }
}
