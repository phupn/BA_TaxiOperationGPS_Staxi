using System;
using System.Data;
using System.IO;
using System.Reflection;

namespace Taxi.GUI 
{
    public class Common
    {
        #region MinhND kết xuất excel dung Flexcel!
        //Cac tham so cau hinh
        public const string ExcelDesignFilePath = "Report//";

        #region FlexCelReport
        public static void SetValueExportByDataTable(ref FlexCel.Report.FlexCelReport flcReport, DataSet v_ds)
        {
            try
            {
                flcReport.AddTable(v_ds);
            }
            catch
            {

            }
        }

        public static void SetValueExportByString(ref FlexCel.Report.FlexCelReport flcReport, string _ParamName, object _value)
        {
            try
            {
                flcReport.SetValue(_ParamName, _value);
            }
            catch (Exception ex)
            {

            }
        }

        public static void ExportExcel(FlexCel.Report.FlexCelReport flcReport, string pathFile, System.Windows.Forms.SaveFileDialog saveReport)
        {
            FileStream _templateStream = null;
            try
            {
                flcReport.DeleteEmptyRanges = false; string _path = "";
                string exepath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "");
                MemoryStream _xlsMemoryStream = new MemoryStream();

                #region Luu file xls len memory stream
                _path = exepath + "\\" + pathFile.Replace("//", "\\");
                bool ckFileIsNotOpen = true;
                //check xem file co ton tai trong duong dan ko?
                if (!File.Exists(exepath + "\\" + pathFile.Replace("//", "\\")))
                {
                    //bao loi ko ton tai file;
                    //NoteBox.Show("File excel thiết kế không tồn tại trong thư mục Run/report. Kết xuất không thành công.", "Thông báo", NoteBoxLevel.Note);
                }
                else
                {
                    //check file co dang mo hay ko
                    try
                    {
                        var stream = new FileStream(_path, FileMode.Open, FileAccess.Read);
                        stream.Close();
                    }
                    catch
                    {
                        //NoteBox.Show("File mẫu đang mở hoặc bị process khác sử dụng, bạn phải đóng file đó mới có thể kết xuất", "Error", NoteBoxLevel.Error);
                        ckFileIsNotOpen = false;
                    }

                    if (ckFileIsNotOpen == true)
                    {
                        _templateStream = new System.IO.FileStream(_path, System.IO.FileMode.Open);
                        flcReport.Run(_templateStream, _xlsMemoryStream);

                        //luu file 
                        _xlsMemoryStream.Position = 0;
                        byte[] bytes = new byte[_xlsMemoryStream.Length];
                        _xlsMemoryStream.Read(bytes, 0, (int)_xlsMemoryStream.Length);

                        try
                        {
                            FileStream OutStream;

                            OutStream = new FileStream(saveReport.FileName, FileMode.Create);

                            OutStream.Write(bytes, 0, bytes.Length);
                            OutStream.Close();
                            _xlsMemoryStream.Close();
                            _templateStream.Close();


                            //Neu chon mo file da luu
                            //MessageBoxResult result = NoteBox.Show("Bạn có muốn mở file vừa chọn kết xuất không?", "Thông báo", NoteBoxLevel.Question);
                            //if (result == MessageBoxResult.Yes)
                            //{
                            //    Process.Start(saveReport.FileName);
                            //}
                        }
                        catch (Exception)
                        {
                            _templateStream.Close();
                            //NoteBox.Show("File mẫu đang mở hoặc bị process khác sử dụng, bạn phải đóng file đó mới có thể kết xuất", "Error", NoteBoxLevel.Error);
                            //Mouse.OverrideCursor = null;
                            return;
                        }
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {

                _templateStream.Close();
                //NoteBox.Show("Kết xuất file excel không thành công", "Thông báo", NoteBoxLevel.Error);
            }

        }

        #endregion

        #endregion
    }
}
