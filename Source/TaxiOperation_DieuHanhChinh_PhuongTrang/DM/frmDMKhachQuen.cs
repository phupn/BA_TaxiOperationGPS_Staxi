using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Janus.Windows.GridEX;
using Taxi.Utils;
using System.Data.OleDb;

namespace Taxi.GUI
{
    public partial class frmDMKhachQuen : Form
    {
        #region ==========================Init=================================
        private List<DanhBaKhachQuen_Type> G_lstKhachQuen_Type;
        private List<DanhBaKhachQuen_Rank> G_lstKhachQuen_Rank;
        #endregion

        #region =======================Constructor=============================
        public frmDMKhachQuen()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmDMKhachAo_Load);
        }
        #endregion

        #region ========================Load Form==============================
        void frmDMKhachAo_Load(object sender, EventArgs e)
        {
            LoadListKhachQuen();
            LoadListKhachQuen_Type();
            LoadListKhachQuen_Rank();
        }

        private void LoadListKhachQuen()
        {
            List<DanhBaKhachQuen> lstKhachAo = new List<DanhBaKhachQuen>();
            lstKhachAo = DanhBaKhachQuen.GetDanhSachKhachQuen();

            gridKhachAo.DataMember = "ListOfKhachHang";
            gridKhachAo.SetDataBinding(lstKhachAo, "ListOfKhachHang");
        }

        private void LoadListKhachQuen_Type()
        {
            G_lstKhachQuen_Type = new List<DanhBaKhachQuen_Type>();
            G_lstKhachQuen_Type = DanhBaKhachQuen_Type.GetDanhSachKhachQuen_Type();
        }

        private void LoadListKhachQuen_Rank()
        {
            G_lstKhachQuen_Rank = new List<DanhBaKhachQuen_Rank>();
            G_lstKhachQuen_Rank = DanhBaKhachQuen_Rank.GetDanhSachKhachQuen_Rank();
        }

        #endregion

        #region =========================Get Data==============================
        
        #endregion

        #region ======================Validation Form==========================

        #endregion

        #region ========================Form Events============================
        private void cmdAdd_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            //cmdNew cmdEdit cmdDelete cmdExit cmdHelp
            if (e.Command.Key == "cmdNew")
            {
                this.ThemKhachQuen();
            }
            else if (e.Command.Key == "cmdEdit")
            {
                this.SuaKhachQuen();
            }
            else if (e.Command.Key == "cmdDelete")
            {
                this.XoaKhachQuen();
            }
            else if (e.Command.Key == "cmdExit")
            {
                this.Close();
                this.Dispose();
            }
            else if (e.Command.Key == "cmdHelp")
            {
                frmKhachQuenTimKiem frm = new frmKhachQuenTimKiem();
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    if (frm.GetResultListOfKhachQuen().Count > 0)
                    {
                        gridKhachAo.DataSource = null;
                        gridKhachAo.DataMember = "ListOfKhachAo";
                        gridKhachAo.SetDataBinding(frm.GetResultListOfKhachQuen(), "ListOfKhachAo");
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Không tìm thấy kết quả nào");
                        return;
                    }
                }
            }
            else if(e.Command.Key == "cmdInportExcel")
            {
                OpenFile();
            }
             
        }
        /// <summary>
        /// Mo form KhachAo de edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridKhachAo_DoubleClick(object sender, EventArgs e)
        {
            gridKhachAo.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridKhachAo.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)gridKhachAo.SelectedItems[0]).GetRow();
                DanhBaKhachQuen objKhachQuen = (DanhBaKhachQuen)((GridEXSelectedItem)gridKhachAo.SelectedItems[0]).GetRow().DataRow;
                frmKhachQuen frm = new frmKhachQuen(objKhachQuen, false,G_lstKhachQuen_Type,G_lstKhachQuen_Rank);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objKhachQuen = frm.GetKhachQuen();
                    frm.Dispose();
                    //Insert DataBase
                    if (!objKhachQuen.Update())
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới khách quen");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListKhachQuen(); 
                    }
                }
                else return;
            }
        }
        #endregion

        #region ========================Grid Events============================
        #endregion

        #region =======================Method Process==========================

        private void ThemKhachQuen()
        {
            DanhBaKhachQuen objKhachQuen = new DanhBaKhachQuen();
            frmKhachQuen frm = new frmKhachQuen(objKhachQuen, true, G_lstKhachQuen_Type,G_lstKhachQuen_Rank);// them moi
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objKhachQuen = frm.GetKhachQuen();
                    //Insert DataBase
                    if (!objKhachQuen.Insert())
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới khách quen");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListKhachQuen();
                        
                    }

                }
                  
        }

        private void SuaKhachQuen()
        {
            gridKhachAo.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridKhachAo.SelectedItems != null && gridKhachAo.SelectedItems.Count > 0 && gridKhachAo.SelectedItems[0].RowType == RowType.Record)
            {
                GridEXRow row = ((GridEXSelectedItem)gridKhachAo.SelectedItems[0]).GetRow();
                DanhBaKhachQuen objKhachQuen = (DanhBaKhachQuen)((GridEXSelectedItem)gridKhachAo.SelectedItems[0]).GetRow().DataRow;
                frmKhachQuen frm = new frmKhachQuen(objKhachQuen, false,G_lstKhachQuen_Type,G_lstKhachQuen_Rank);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objKhachQuen = frm.GetKhachQuen();
                    if (StringTools.TrimSpace(objKhachQuen.Name).Length <= 0) return;

                    if (StringTools.TrimSpace(objKhachQuen.Address).Length <= 0) return;

                    if (StringTools.TrimSpace(objKhachQuen.Phones).Length < 8) return;
                    //Insert DataBase
                    if (!objKhachQuen.Update())
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới khách quen");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListKhachQuen();
                        
                    }                
                
                }
            }
        }

        private void XoaKhachQuen()
        {
            gridKhachAo.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridKhachAo.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)gridKhachAo.SelectedItems[0]).GetRow();
                DanhBaKhachQuen objKhachQuen = (DanhBaKhachQuen)((GridEXSelectedItem)gridKhachAo.SelectedItems[0]).GetRow().DataRow;
                MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA();

                if (msg.Show(this, "Bạn có xóa khách quen " + objKhachQuen.Name + " không ?", "Xóa khách quen", Taxi.MessageBox.MessageBoxButtonsBA.OKCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.OK.ToString())
                {
                    if (!objKhachQuen.Delete(objKhachQuen.MaKH ))
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới khách quen");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListKhachQuen();
                    }
                }

            }
        }
        #endregion

        #region Import Excel
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
        private void OpenFile()
        {
            //try
            //{
            //    if (openImportExcel.ShowDialog() == DialogResult.OK)
            //    {
            //        openConnection(openImportExcel.FileName);
            //        using (DataTable result = ReadExcel())
            //        {
            //            if (result != null)
            //            {
            //                foreach (DataRow item in result.Rows)
            //                {
            //                    try
            //                    {
            //                        if (item[1].ToString() == "" || item[1].ToString() == "Số xe") continue;

            //                        //if (item["Số xe"] == null || item["Biển số"] == null || item["Tên gara"] == null || item["Tên loại xe"] == null || item["Tên nhóm"] == null)
            //                        //{
            //                        //    break;
            //                        //}
            //                        if (G_LstXe != null && G_LstXe.Exists(delegate(Xe shx)
            //                        {
            //                            return shx.SoHieuXe == item[1].ToString().Substring(0, 4);
            //                        }) == true)
            //                        {
            //                            Xe objXe = Xe.getXe_New(item, G_DSGara, G_LoaiXe);
            //                            //objXe.getXe(item, G_DSGara);
            //                            if (objXe != null && objXe.SoHieuXe != "")
            //                            {
            //                                objXe.Update();
            //                            }
            //                        }
            //                        else
            //                        {
            //                            Xe objXe = Xe.getXe_New(item, G_DSGara, G_LoaiXe);
            //                            //objXe.getXe(item, G_DSGara);
            //                            if (objXe != null && objXe.SoHieuXe != "")
            //                            {
            //                                objXe.Insert();
            //                            }
            //                        }
            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        continue;
            //                    }
            //                }
            //                LoadListXe();
            //                LoadData();
            //                new MessageBox.MessageBox().Show("Import thành công");
            //            }
            //        }
            //        closeConnection();
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }

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
                new MessageBox.MessageBoxBA().Show(ex.Message, "Error Reading Source", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                return null;
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
                //string conn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + m_SourceFileName + ";Extended Properties=Excel 12.0;";
                this.m_ConnectionToExcelBook = new OleDbConnection(String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0;", m_SourceFileName));

                this.m_ConnectionToExcelBook.Open();
                this.m_CurrentMessage = "SUCCESS - Connection to Source Established";
            }
            catch (Exception ex)
            {
                this.m_CurrentMessage = "ERROR " + ex.Message;
                new MessageBox.MessageBoxBA().Show(ex.Message, "Error Opening Source", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
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
                new MessageBox.MessageBoxBA().Show(ex.Message, "Error Closing Source", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                return false;
            }
            return true;
        }

        #endregion

        private void gridKhachAo_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }

    }
}