using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using Taxi.Common.Extender;
using Taxi.Common.DbBase.Attributes;
using Taxi.Controls.Base.Controls;
using Taxi.Controls.Base.Inputs;
using Taxi.Utils;
using Aspose.Cells;
using Taxi.Controls.BaoCao.ExcelBinders;
using Taxi.Controls.BaoCao.ExcelBinders.GridBinderProviders;
using DevExpress.XtraGrid;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using Taxi.Controls.Base;
using Taxi.Controls.Base.BaoCao;
using Taxi.Controls.Base.Extender;
using Taxi.Utils.Validators;
using DevExpress.XtraPrinting;
using Taxi.Business;
namespace Taxi.Controls.BaoCao
{
    public partial class FrmReportBase : FormBase
    {
        public bool RemoveTitle { get; set; }

        public bool IsFormat = true;
        public bool IsLastDate { get; set; }

        #region Properties
        [Field(Name = "Từ ngày")]
        [Taxi.Common.Attributes.Validator.ValidatorRequire]
        public DateTime? FromDate { set; get; }

        [Field(Name = "Đến ngày")]
        [Taxi.Common.Attributes.Validator.ValidatorRequire]
        [Taxi.Common.Attributes.Validator.ValidatorDateGreater("FromDate")]
        public DateTime? ToDate { set; get; }

        private ReportInfoAttribute reportInfo = null;
        /// <summary>
        /// Thông tin về báo cáo
        /// </summary>
        public ReportInfoAttribute ReportInfo
        {
            get
            {
                if (reportInfo == null)
                    reportInfo = this.GetType().GetAttribute<ReportInfoAttribute>();
                return reportInfo;
            }
        }

        private IReportData reportData = null;
        /// <summary>
        /// Tìm IReportData
        /// </summary>
        protected IReportData ReportData
        {
            get
            {
                if (reportData == null)
                {
                    if (ReportInfo.TypeReportData != null)
                        reportData = ReportInfo.TypeReportData.CreateInstance<IReportData>();
                }
                return reportData;
            }
        }

        public int? startRowEx = null;
        #endregion

        #region Private method
        /// <summary>
        /// Thực hiện xử lý lấy dữ liệu đầu vào cho báo cáo và thực hiện validate
        /// </summary>
        private void DoProcess()
        {
            try
            {
                lbMessage.Text = string.Empty;
                if (ReportData == null) pnInputs.ParseTo(this);
                else pnInputs.ParseTo(ReportData);
                DoValidate();
                if (IsLastDate)
                {
                    // Lấy đến cuối ngày
                    if (ReportData == null)
                    {
                        if (ToDate != null) ToDate = ToDate.Value.Date.AddDays(1).AddSeconds(-1);
                    }
                    else
                    {
                        if (ReportData.ToDate != null) ReportData.ToDate = ReportData.ToDate.Value.Date.AddDays(1).AddSeconds(-1);
                    }
                }
                // Trước khi thực hiện tìm kiếm
                BeforeFind();
                if (IsLastDate)
                {
                    // 
                    if (ReportData != null)
                    {
                        FromDate = ReportData.FromDate;
                        ToDate = ReportData.ToDate;
                    }
                }
            }
            catch 
            {

            }
        }

        /// <summary>
        /// Bind dữ liệu
        /// </summary>
        private void BindData(object data)
        {
            JoinDataSourceWithIShReportControl(data, (c, o) => c.SetDataSource(o));
        }

        /// <summary>
        /// Kết nối giữa source dữ liệu với control hiển thị báo cáo
        /// </summary>
        private void JoinDataSourceWithIShReportControl(object data, Action<IShReportControl, object> action)
        {
            //if (!(data is DataReportCollection)) data = new DataReportCollection(data);
            //pnOutput.FindAllChildrenByType<IShReportControl>().OrderBy(d => d.TabIndex).Select((d, i) => new { d, i }).SLeftJoin(data.As<DataReportCollection>().Data.Select((s, i) => new { s, i }), T1 => T1.i, T2 => T2.i, (T1, T2) =>
            //{
            //    T1.d.SetDataSource(T2.s);
            //},
            //(T1) =>
            //{
            //    T1.d.SetDataSource(null);// không map được thì set Null
            //});
            //Frame EnVang!
            if (!(data is DataReportCollection)) data = new DataReportCollection(data);
            data.As<DataReportCollection>().Data.Select((s, i) => new { s, i }).Join(pnOutput.FindAllChildrenByType<IShReportControl>().OrderBy(d => d.TabIndex).Select((d, i) => new { d, i }),
            dr => dr.i, sc => sc.i, (dr, sc) =>
            {
                action(sc.d, dr.s);
                return false;
            }).Count();
        }

        /// <summary>
        /// Hiển thị thông báo
        /// </summary>
        private void ShowMessage(Exception ex)
        {
            ShowMessage(ex is IOException ? "Vui lòng kiểm tra file bạn muốn lưu" : ex.Message);

            // Nếu là lỗi do input chưa có dữ liệu đúng như validate thì thực hiện focus
            if (ex is ValidatorException)
            {
                var iperror = pnInputs.FindIShInput().FirstOrDefault(ip => (ip as Control).Tag.ToString().Equals((ex as ValidatorException).ValidatorMessage.FieldName));
                (iperror as Control).Focus();
            }
        }

        /// <summary>
        /// Hiển thị thông báo
        /// </summary>
        private void ShowMessage(string msg)
        {
            lbMessage.Text = msg;
            lbMessage.Location = new Point((pnButtons.Width - lbMessage.Width) / 2, lbMessage.Location.Y);
        }
        #endregion

        #region Vitural
        /// <summary>
        /// Tiêu đề báo cáo
        /// </summary>
        protected virtual string GetReportTitle()
        {
            return ReportInfo.Title;
        }

        /// <summary>
        /// Thiết lập lại ngày giờ cần tìm kiếm
        /// </summary>
        protected virtual void ResetDate()
        {
            try
            {
                ipToDate.SetValue(DateTime.Now);
                //ipFromDate.SetValue(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1));
                ipFromDate.SetValue(DateTime.Today);
            }
            catch 
            {
            }

        }

        /// <summary>
        /// Thực hiện Format data trước khi xuất exel
        /// </summary>
        protected virtual void FormatDataForReport(object data) { }

        /// <summary>
        /// Thực hiện lấy dữ liệu cho báo cáo
        /// </summary>
        protected virtual object GetData()
        {
            if (ReportData != null) return ReportData.GetData();
            return null;
        }

        /// <summary>
        /// Thực hiện validate dữ liệu đầu vào cho báo cáo
        /// Đây là hàm validate mở rộng
        /// Mặc định Form sẽ tự động validate đầu vào với thư viện cơ bản trước
        /// </summary>
        protected virtual void DoValidate() { }

        protected virtual void BeforeFind() { }

        /// <summary>
        /// Sau khi tìm kiếm xong dữ liệu
        /// </summary>
        protected virtual void AfterFind() { }

        /// <summary>
        /// Sau khi tải form
        /// </summary>
        protected virtual void AfterLoad() { }


        /// <summary>
        /// Thiết lập enable button
        /// </summary>
        protected virtual void SetEnableButtonFind(bool enable)
        {
            btnExportExcel.Enabled = !(btnTim.Enabled = enable);

            if (enable) lbMessage.Text = string.Empty;
        }

        /// <summary>
        /// Thực hiện fill dữ liệu vào Excel
        /// </summary>
        ExcelBinderBase _binder = null;
        protected virtual void FillExel(Workbook workbook, object data)
        {
            // Row bắt đầu fill dữ liệu
            int? startRow = startRowEx;

            JoinDataSourceWithIShReportControl(data, (c, o) =>
            {
                // Lựa chọn BinderType

                switch (ReportInfo.BinderType)
                {
                    case ExcelBinderType.Grid: _binder = new GridBinder(); break;
                    case ExcelBinderType.GridGroup: _binder = new GridGroupBinder(); break;
                }

                // Nếu như có thiết lập là thực hiện binder dữ liệu vào Excel theo provider nào
                // Thì thiết lập các thông số chung nhất cho binder và thực hiện binder excel
                // Ở đây thông số chung nhất cho các binder là Target => đang thực hiện binder trên form nào
                if (_binder != null)
                {
                    if (_binder is GridBinder) _binder.As<GridBinder>().Grid = c.As<GridControl>();

                    // Nếu như xác định được row bắt đầu fill dữ liệu
                    if (startRow != null) _binder.RowBegin = startRow.Value;

                    // Thực hiện bind lên workbook, đồng thời lấy startRow cho lần bind sau
                    _binder.Target = this;
                    startRow = _binder.Bind(workbook, o);
                }
            });
        }

        /// <summary>
        /// Lấy ra nhãn thời gian của báo cáo
        /// </summary>
        protected virtual string GetReportDateTitle()
        {
            // Tạo tiêu đề thời gian của báo cáo
            string titleDate;

            // Nếu như chỉ sử dụng thời gian từ ngày
            if (ipFromDate.Visible && !ipToDate.Visible) titleDate = "Ngày " + string.Format("{0:dd/MM/yyyy}", FromDate);

            // Chỉ sử dụng thời gian đến ngày
            else if (!ipFromDate.Visible && ipToDate.Visible) titleDate = "Ngày " + string.Format("{0:dd/MM/yyyy}", ToDate);

            // Nếu như là thời gian của một ngày
            else if (FromDate.Value.Date == ToDate.Value.Date && FromDate.Value.Date.AddDays(1) == ToDate.Value.AddSeconds(1))
                titleDate = "Ngày " + string.Format("{0:dd}", FromDate) + " tháng " + string.Format("{0:MM}", FromDate) + " năm " + string.Format("{0:yyyy}", FromDate);

            // Nếu như là thời gian trong ngày
            else if (FromDate.Value.Date == ToDate.Value.Date)
                titleDate = "Ngày: " + string.Format("{0:dd/MM/yyyy}", FromDate) + " Thời gian từ: " + string.Format("{0:HH:mm}", FromDate) + " đến: " + string.Format("{0:HH:mm}", ToDate);

            // Sử dụng từ ngày đến ngày
            else // if (FromDate.Value.Month == ToDate.Value.Month && FromDate.Value.Year == ToDate.Value.Year)
            {
                // Nếu từ ngày đến ngày là đầu tháng đến cuối tháng
                if (FromDate.Value.Day == 1 && FromDate.Value.AddMonths(1).AddSeconds(-1).Day == ToDate.Value.Day)
                    titleDate = "Báo cáo tháng " + FromDate.Value.Month + " năm " + FromDate.Value.Year;
                else
                    titleDate = "Từ ngày: " + string.Format("{0:dd/MM/yyyy}", FromDate) + " đến ngày: " + string.Format("{0:dd/MM/yyyy}", ToDate);
            }

            return titleDate;
        }
        #endregion

        #region Events in form
        /// <summary>
        /// Lựa chọn ngày thay đổi
        /// </summary>
        private void ipFromDate_EditValueChanged(object sender, EventArgs e)
        {
            //ipToDate_EditValueChanged(sender, e);

            //// Từ ngày mà thay đổi thì tự động đến ngày về ngày cuối của tháng
            //var value = (sender as InputDate).EditValue;
            //if (value == null) return;

            //var date = Convert.ToDateTime(value).Date;
            //ipToDate.SetValue(new DateTime(date.Year, date.Month, 1).AddMonths(1).AddSeconds(-1));
        }

        private void ipToDate_EditValueChanged(object sender, EventArgs e)
        {
            //var value = (sender as InputDate).EditValue;
            //if (value == null) return;

            //if (Convert.ToDateTime(value) > DateTime.Today)
            //(sender as InputDate).SetValue(DateTime.Now);
        }

        /// <summary>
        /// Tải Form
        /// </summary>
        private void FrmReportBase_Load(object sender, EventArgs e)
        {
            if (DesignTimeHelper.IsInDesignMode || this.DesignMode) return;

            // Thiết lập sự kiện cho các input. Nếu như các input nào mà focus thì clear lại message
            pnInputs.FindAllChildrenByType<IShInput>().Cast<Control>().ToList().ForEach(c => c.GotFocus += (s, ea) => SetEnableButtonFind(true));
            pnInputs.FindAllChildrenByType<IShInput>().Cast<Control>().ToList().ForEach(c => c.TextChanged += (s, ea) => SetEnableButtonFind(true));

            try
            {
                // Thực hiện bind dữ liệu cho các input
                pnInputs.FindAllChildrenByType<IShControl>().ToList().ForEach(c => c.Bind());
            }
            catch (Exception ex)
            {
                LogError.WriteLogError(string.Format("{0}.Bind", this.Text), ex);
            }

            // Thiết lập giá trị cho input từ ngày đến ngày
            ResetDate();

            // 
            if (ReportInfo == null || ReportInfo.Title == null)
            {
                lblTitle.Text = this.Text;
            }
            else
                lblTitle.Text = Text = ReportInfo.Title.ToUpper();
            lblTitle.Location = new Point((pnTitle.Width - lblTitle.Width) / 2, lblTitle.Location.Y);
            // Tìm các GridView và thiết lập không cho chỉnh sửa
            //pnOutput.FindAllChildrenByType<ShGridControl>().ToList().ForEach(sc =>
            //{
            //    sc.MainView.As<GridView>().OptionsBehavior.Editable = false;
            //    sc.MainView.As<GridView>().OptionsCustomization.AllowFilter = false;
            //    sc.MainView.As<GridView>().OptionsCustomization.AllowSort = false;
            //    sc.MainView.As<GridView>().OptionsMenu.EnableColumnMenu = false;
            //});
            // Sự kiện sau khi tải Form
            AfterLoad();

        }

        /// <summary>
        /// Thực hiện xem báo cáo
        /// </summary>
        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                DoProcess();
                var data = GetData();
                if (data != null && data is DataReportCollection)
                {
                    var totalNull = 0;
                    data.As<DataReportCollection>().Data.ForEach(d => { if (d == null || d.CastToList().Count == 0) totalNull++; });
                    if (totalNull == data.As<DataReportCollection>().Data.Count) throw new Exception("Không tìm thấy dữ liệu");
                }
                else if (data == null || data.CastToList().Count == 0)
                {
                    throw new Exception("Không tìm thấy dữ liệu");
                }

                BindData(data);
                SetEnableButtonFind(false);
            }
            catch (Exception ex)
            {

                BindData(null);
                ShowMessage(ex);
            }
            finally
            {
                AfterFind();
            }
        }


        /// <summary>
        /// Thực hiện xuất Exel
        /// </summary>
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //// Load file exel template
                //var workbook = new Workbook();
                //workbook.Worksheets.Clear();
                //workbook.Worksheets.Add("Báo cáo");
                var svd = new SaveFileDialog();
                svd.Title = "Chọn nơi lưu file...";
                svd.Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls";
                svd.FileName = string.Format(ReportInfo.Title.UnicodeFormat() + "_{0}", DateTime.Now.ToString("ddMMyyyy_HH_mm"));
                svd.OverwritePrompt = true;
                if (svd.ShowDialog() == DialogResult.Cancel) { return; }

                // Khi xuất thì không cần DoProcess lại nữa
                DoProcess();
                var lstGridControl = pnOutput.FindAllChildrenByType<GridControl>().OrderBy(p => p.TabIndex).ToList();

                if (svd.FileName.EndsWith("xlsx"))
                {
                    if (lstGridControl.Count() == 1)
                    {
                        lstGridControl.First().MainView.As<GridView>().OptionsPrint.AutoWidth = false;

                        lstGridControl.First().ExportToXlsx(svd.FileName, new XlsxExportOptions { TextExportMode = TextExportMode.Text, ExportMode = XlsxExportMode.SingleFile });
                    }
                    else
                    {
                        lstGridControl.ForEach(p => p.ExportToXlsx(string.Format("{1}-{0}.xlsx", p.TabIndex, svd.FileName.Replace(".xlsx", "")), new XlsxExportOptions { TextExportMode = TextExportMode.Text, ExportMode = XlsxExportMode.SingleFile }));
                    }
                }
                else
                {
                    if (lstGridControl.Count() == 1)
                    {
                        lstGridControl.First().MainView.As<GridView>().OptionsPrint.AutoWidth = false;

                        lstGridControl.First().ExportToXls(svd.FileName, new XlsExportOptions { TextExportMode = TextExportMode.Text, ExportMode = XlsExportMode.SingleFile });
                    }
                    else
                    {
                        lstGridControl.ForEach(p => p.ExportToXls(string.Format("{1}-{0}.xls", p.TabIndex, svd.FileName.Replace(".xls", "")), new XlsExportOptions { TextExportMode = TextExportMode.Text, ExportMode = XlsExportMode.SingleFile, ShowGridLines = true }));
                    }
                }

                //  Tiêu đề báo cáo
                //  var tieuDe = new Style();
                //  tieuDe.Font.Name = "Times New Roman";
                //  tieuDe.Font.Size = 18;
                //  tieuDe.Font.IsBold = true;
                //  tieuDe.VerticalAlignment = TextAlignmentType.Center;
                //  tieuDe.HorizontalAlignment = TextAlignmentType.Center;
                //  workbook.Worksheets[0].Cells[4, 0].PutValue(GetReportTitle().ToUpper());               
                //  workbook.Worksheets[0].Cells[4, 0].SetStyle(tieuDe);
                //  // Tiêu đề thời gian của báo cáo
                //  tieuDe.Font.Size = 14;
                //  workbook.Worksheets[0].Cells[6, 0].PutValue(GetReportDateTitle());
                //  workbook.Worksheets[0].Cells[6, 0].SetStyle(tieuDe);
                //  // Thực hiện lấy dữ liệu và format cho báo cáo excel
                //  var data = pnOutput.FindAllChildrenByType<ShGridControl>().First().GetDataView(); FormatDataForReport(data);
                ////  data=data.CastToList().OrderBy(new CriteriaToExpressionConverter())
                //  // Điền dữ liệu vào exel
                //  FillExel(workbook, data);
                // // RemoveTitle=true;
                //  //Chỉnh độ rộng của tiêu đề và ảnh tiêu đề theo lưới.
                //  if (RemoveTitle)
                //  {
                //      //workbook.Worksheets[0].Pictures[0].Width = 0;
                //      //workbook.Worksheets[0].Pictures[0].Height = 0;
                //      for (var i = 0; i < 8; i++)
                //      {
                //          workbook.Worksheets[0].Cells.DeleteRow(0);
                //      }

                //  }
                //  else
                //  {
                //      var biner = (GridBinder)_binder;
                //      if (biner != null)
                //      {
                //          var cont = biner.AllColumns.Count(p => p.Visible);
                //          var width = biner.AllColumns.Where(p => p.Visible).Sum(p => p.Width);
                //          cont +=
                //              biner.AllColumns.Count(
                //                  p =>
                //                      !p.Visible && biner.ListReportColumnInfo.Any(p1 => p1.Column.Equals(p.FieldName)) &&
                //                      biner.ListReportColumnInfo.First(p1 => p1.Column.Equals(p.FieldName)).CellSpan ==
                //                      CellSpan.Row);
                //          width +=
                //              biner.AllColumns.Where(
                //                  p =>
                //                      !p.Visible && biner.ListReportColumnInfo.Any(p1 => p1.Column.Equals(p.FieldName)) &&
                //                      biner.ListReportColumnInfo.First(p1 => p1.Column.Equals(p.FieldName)).CellSpan ==
                //                      CellSpan.Row).Sum(p => p.Width);
                //          if (workbook.Worksheets[0].Pictures.Count > 0)
                //          {
                //              var image = workbook.Worksheets[0].Pictures[0];
                //              image.Width = width;
                //          }

                //          workbook.Worksheets[0].Cells.Merge(0, 0, 4, cont);
                //          workbook.Worksheets[0].Cells.Merge(4, 0, 1, cont);
                //          workbook.Worksheets[0].Cells.Merge(5, 0, 1, cont);
                //          workbook.Worksheets[0].Cells.Merge(6, 0, 1, cont);
                //      }
                //  }
                //  workbook.Worksheets[0].Zoom = 90;
                //  // Lưu file và hiển thị
                //  workbook.Save(svd.FileName);
                if (lstGridControl.Count() == 1)
                    Process.Start(svd.FileName);
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }
            finally
            {
                AfterFind();
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void ReLoadData()
        {
            try
            {
                DoProcess();

                var data = GetData();

                if (data != null && data is DataReportCollection)
                {
                    var totalNull = 0;
                    data.As<DataReportCollection>().Data.ForEach(d => { if (d == null || d.CastToList().Count == 0) totalNull++; });
                    if (totalNull == data.As<DataReportCollection>().Data.Count) throw new Exception("Không tìm thấy dữ liệu");
                }
                else if (data == null || data.CastToList().Count == 0)
                    throw new Exception("Không tìm thấy dữ liệu");

                BindData(data);
                SetEnableButtonFind(false);
            }
            catch (Exception ex)
            {

                BindData(null);
                ShowMessage(ex);
            }
            finally
            {
                AfterFind();
            }
        }
        #endregion

    }
}
