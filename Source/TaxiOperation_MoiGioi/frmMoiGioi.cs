using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using Taxi.Business;

namespace TaxiOperation_MoiGioi
{
    public partial class frmMoiGioi : Form
    {
        #region constructor
        public frmMoiGioi()
        {
            InitializeComponent();
            ConfigMap();

            //LoadMoiGioi();
            OpenFile();
        }
        #endregion
        
        #region Method

        private void LoadMoiGioi()
        {
            List<BangKe> lstMoiGioi = new BangKe().GetListOfDoiTac();
            if (lstMoiGioi != null && lstMoiGioi.Count > 0)
            {
                foreach (BangKe item in lstMoiGioi)
                {
                    MainMap.AddMarkerRedCircle(item.ViDo, item.KinhDo, item.TenDoiTac);
                }
            }
            gridMoiGioi.DataSource = lstMoiGioi;
        }

        private void SetMoiGioiToForm()
        {
            if (gridMoiGioi.SelectedItems != null && gridMoiGioi.SelectedItems.Count > 0 && gridMoiGioi.SelectedItems[0].RowType == Janus.Windows.GridEX.RowType.Record)
            {
                TDoiTac DoiTac = (TDoiTac)gridMoiGioi.SelectedItems[0].GetRow().DataRow;
                txtDiaChi.Text = DoiTac.Address;
                txtKinhDo.Text = DoiTac.KinhDo.ToString();
                txtMaMG.Text = DoiTac.Ma_DoiTac;
                txtTenMG.Text = DoiTac.Name;
                txtViDo.Text = DoiTac.ViDo.ToString();
                MainMap.AddMarkerBlueCircle(DoiTac.ViDo, DoiTac.KinhDo);
            }
        }


        public string GetGeobyAddressBA3(string address)
        {
            string result;
            try
            {
                using (BAGis.gisSoapClient BAgis = new BAGis.gisSoapClient())
                {
                    BAGis.GSAuthenticationHeader auth = new BAGis.GSAuthenticationHeader();
                    auth.Username = "gps";
                    auth.Password = "binhanh";
                    //BAgis.GSAuthenticationHeaderValue = auth;
                    BAGis.GSAddressResult rs = BAgis.GetGeoByName3(auth, address, "vn");
                    result = String.Format("{0} {1}", rs.Lat, rs.Lng);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return "*";
            }
        }
        #endregion

        #region Map Control
        // Toyota MyDinh Building
        private PointLatLng currentPoint = new PointLatLng(21.0298404693604, 105.830619812012);
        private GMapProvider _mapType;
        private MapModeEnum _mapMode;
        private int _mapZoom;
        //private object Object;

        // markers
        //GMapMarkerCustom centerMarker;
        GMapMarker currentMarker;
        private List<GMapMarker> _otherMarkers;
        // layers
        GMapOverlay top;
        GMapOverlay selected;

        bool isMouseDown;

        private void ConfigMap()
        {
            // config gmaps
            
            MainMap.Manager.Mode = AccessMode.ServerAndCache;
            MainMap.MapProvider = GMapProviders.GoogleMap;
            MainMap.CacheLocation = Application.StartupPath + "\\Map";
            MainMap.MaxZoom = 19;
            MainMap.MinZoom = 7;
            MainMap.Zoom = 15;

            MainMap.Position = currentPoint;
            MainMap.PolygonsEnabled = false;
            MainMap.AllowDrawPolygon = false;

            if (_mapMode == MapModeEnum.EditPoint)
            {
                MainMap.MouseMove += MainMap_MouseMove;
                MainMap.MouseDown += MainMap_MouseDown;
                MainMap.MouseUp += MainMap_MouseUp;
            }
            else
            {
                MainMap.MouseMove -= MainMap_MouseMove;
                MainMap.MouseDown -= MainMap_MouseDown;
                MainMap.MouseUp -= MainMap_MouseUp;
            }
            MainMap.MouseDoubleClick += MainMap_MouseDoubleClick;

            //// get zoom  
            //trackBarMap.Minimum = MainMap.MinZoom;
            //trackBarMap.Maximum = MainMap.MaxZoom;
            //trackBarMap.Value = Convert.ToInt32(MainMap.Zoom);

            // add custom layers  
            {
                top = new GMapOverlay("top");
                MainMap.Overlays.Add(top);

                selected = new GMapOverlay("selected");
                MainMap.Overlays.Add(selected);
            }
        }

        #region===================Map Events==================================

        private void MainMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MainMap.Zoom < MainMap.MaxZoom)
            {
                int zoom = (int)(MainMap.Zoom + 1);
                if (zoom > MainMap.MaxZoom)
                {
                    zoom = MainMap.MaxZoom;
                }
                MainMap.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
            }
        }

        private void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isMouseDown = false;
            }
        }

        private void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    if (currentMarker != null)
            //    {
            //        isMouseDown = true;
            //        if (currentMarker.IsVisible)
            //            currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
            //    }
            //    else
            //    {
            //        MainMap.addMarkerCustomer(MainMap.FromLocalToLatLng(e.X, e.Y), "");
            //        currentMarker = MainMap.MarkerCustomer;
            //        //currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
            //    }
            //    initConfigGPS();
            //}
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && isMouseDown)
            {
                if (currentMarker.IsVisible)
                {
                    currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                }

            }
            MainMap.Refresh(); // force instant invalidation
        }
        #endregion=============================================================        
        #endregion

        #region Events
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.O:
                    OpenFile();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void gridMoiGioi_Click(object sender, EventArgs e)
        {
            SetMoiGioiToForm();
        }

        private void gridMoiGioi_SelectionChanged(object sender, EventArgs e)
        {
            SetMoiGioiToForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string strDiaChi = txtDiaChi.Text.Trim();
                string strKinhDo = txtKinhDo.Text.Trim();
                string strViDo = txtViDo.Text.Trim();
                if (string.IsNullOrEmpty(strDiaChi))
                {
                    if (string.IsNullOrEmpty(strKinhDo) && string.IsNullOrEmpty(strViDo))
                    {
                        MainMap.AddMarkerBlueCircle(double.Parse(strViDo), double.Parse(strKinhDo));
                    }
                }
                else
                {
                    string toaDo = GetGeobyAddressBA3(strDiaChi);
                    if (toaDo != "*" && toaDo != string.Empty)
                    {
                        string[] arrString = toaDo.Split(' ');
                        MainMap.AddMarkerBlueCircle(Convert.ToDouble(arrString[0]), Convert.ToDouble(arrString[1]));
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tọa độ");
                    }
                }

            }
            catch (Exception)
            {
                return;
            }
        }
        #endregion

        #region Read From Excel
        #region Variable Declarations

        /// <summary>
        /// Current message from the client
        /// </summary>
        string m_CurrentMessage = "";

        /// <summary>
        /// Connects to the source excel workbook
        /// </summary>
        OleDbConnection m_ConnectionToExcelBook;

        /// <summary>
        /// Reads the data from the document to a System.Data object
        /// </summary>
        OleDbDataAdapter m_AdapterForExcelBook;

        #endregion

        #region Properties

        /// <summary>
        /// Gets he current messages from the client
        /// </summary>
        public string CurrentMessage
        {

            get
            {
                return this.m_CurrentMessage;
            }

        }
        #endregion

        private DataTable ReadExcel()
        {
            try
            {
                string iQuery = "select * from [Sheet1$]";
                DataTable returnDataObject = new DataTable();

                OleDbCommand selectCommand = new OleDbCommand(iQuery);
                selectCommand.Connection = this.m_ConnectionToExcelBook;

                this.m_AdapterForExcelBook = new OleDbDataAdapter();

                this.m_AdapterForExcelBook.SelectCommand = selectCommand;
                this.m_AdapterForExcelBook.Fill(returnDataObject);

                this.m_CurrentMessage = String.Format("SUCCESS - {0} Records Loaded ", returnDataObject.Rows.Count);

                return returnDataObject;
            }
            catch (Exception ex)
            {
                this.m_CurrentMessage = "ERROR " + ex.Message;
                MessageBox.Show(ex.Message, "Error Reading Source", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void OpenFile()
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    MainMap.ClearAllMarkers();
                    openConnection(openFileDialog.FileName);
                    DataTable result = ReadExcel();
                    string kinhDo = "";
                    string viDo = "";
                    if (result != null)
                    {
                        List<TDoiTac> lstDoiTac = new List<TDoiTac>();
                        foreach (DataRow item in result.Rows)
                        {
                            if (item["Kinh độ"] == null || item["Vĩ độ"] == null || item["Tên môi giới"] == null || string.IsNullOrEmpty(item["Mã MG"].ToString()))
                            {
                                break;
                            }
                            lstDoiTac.Add(TDoiTac.getDoiTac(item));

                            kinhDo = item["Kinh độ"].ToString();
                            viDo = item["Vĩ độ"].ToString();
                            if (!string.IsNullOrEmpty(kinhDo) && !string.IsNullOrEmpty(viDo))
                                MainMap.AddMarkerRedCircle(double.Parse(viDo), double.Parse(kinhDo), item["Tên môi giới"].ToString());
                        }
                        gridMoiGioi.DataSource = lstDoiTac;
                    }
                    else
                    {
                        gridMoiGioi.DataSource = null;
                    }
                    this.Text = openFileDialog.FileName;
                    closeConnection();
                }
                else
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Opens the connection to the source excel document
        /// </summary>
        /// <returns></returns>
        public bool openConnection(string m_SourceFileName)
        {
            try
            {
                this.m_ConnectionToExcelBook = new OleDbConnection(String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0;", m_SourceFileName));

                this.m_ConnectionToExcelBook.Open();
                this.m_CurrentMessage = "SUCCESS - Connection to Source Established";
            }
            catch (Exception ex)
            {
                this.m_CurrentMessage = "ERROR " + ex.Message;
                MessageBox.Show(ex.Message, "Error Opening Source", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }

        /// <summary>
        /// Closes the connection to the source excel document
        /// </summary>
        /// <returns></returns>
        public bool closeConnection()
        {
            try
            {
                this.m_ConnectionToExcelBook.Close();
                this.m_CurrentMessage = "SUCCESS - Connection to Source Closed";
            }
            catch (Exception ex)
            {
                this.m_CurrentMessage = "ERROR " + ex.Message;
                MessageBox.Show(ex.Message, "Error Closing Source", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        
    }

    public enum MapModeEnum
    {
        EditPoint = 0,
        EditArea,
        ReadOnly
    }
}
