using System;
using System.Data.OleDb;
using System.Data;

namespace Taxi.Utils
{
    public class ExcelDataAccess
    {
        private static string _sourceFile = null;
        
        public static string SourceFile
        {
            get { return _sourceFile; }
            set 
            { 
                _sourceFile = value;
                _connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source =" + _sourceFile + @";Extended Properties=""Excel 12.0;" + @"HDR=Yes;IMEX=1"";";
                //connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source =" + sourceFile  + @";Extended Properties=""Excel 8.0;" + @"HDR=Yes;IMEX=1"";";
            }
        }
        private static string _connectionString = null;//chuoi ket noi.
        private static OleDbConnection _dbConnect = null;
        //Phuong thuc mo ket noi toi file Excel.
        public static void OpenConnectionExcel()
        {
            _dbConnect = new OleDbConnection(_connectionString );
            try
            {
                _dbConnect.Open();
            }
            catch
            {
                throw new Exception("Loi mo file Excel.");
            }
        }
        //Phuong thuc dong ket noi toi file Excel.
        public static void CloseConnectionExcel()
        {
            _dbConnect.Close();
        }

        //Phuong thuc Fill du lieu tu file Excel vao DataSet.
        public static DataSet GetDataSet(string queryToExcel)
        {
            DataSet ds = new DataSet();
            try
            {
                OpenConnectionExcel();
                OleDbCommand cmd = new OleDbCommand(queryToExcel, _dbConnect);
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                ds = new DataSet();
                throw new Exception("Lỗi lấy dữ liệu từ file Excel: ", ex);
            }
            finally
            {
                CloseConnectionExcel();
            }
            return ds;
        }
    }
}
