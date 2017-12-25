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
using System.IO;
using System.Threading;

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
           
        }

        private void LoadListKhachQuen()
        {
            List<DanhBaKhachQuen> lstKhachAo = new List<DanhBaKhachQuen>();
            lstKhachAo = DanhBaKhachQuen.GetDanhSachKhachQuen();

            gridKhachAo.DataMember = "ListOfKhachHang";
            gridKhachAo.SetDataBinding(lstKhachAo, "ListOfKhachHang");
        }

        //private void LoadListKhachQuen_Type()
        //{
        //    G_lstKhachQuen_Type = new List<DanhBaKhachQuen_Type>();
        //    G_lstKhachQuen_Type = DanhBaKhachQuen_Type.GetDanhSachKhachQuen_Type();
        //}

        //private void LoadListKhachQuen_Rank()
        //{
        //    G_lstKhachQuen_Rank = new List<DanhBaKhachQuen_Rank>();
        //    G_lstKhachQuen_Rank = DanhBaKhachQuen_Rank.GetDanhSachKhachQuen_Rank();
        //}

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
            else if (e.Command.Key == "cmdExportExcel")
            {
                string FilenameDefault = "DSKhachHangThanThiet.xls";
                saveFileDialog1.FileName = FilenameDefault;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                    gridEXExporter1.Export((Stream)objFile);
                    Thread.Sleep(200);
                    objFile.Close(); 
                    new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
                    
                }
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
                if (objKhachQuen == null) return;
                frmKhachQuen frm = new frmKhachQuen(objKhachQuen, false);//,G_lstKhachQuen_Type,G_lstKhachQuen_Rank);
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
            frmKhachQuen frm = new frmKhachQuen(objKhachQuen, true) ;// them moi
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
                frmKhachQuen frm = new frmKhachQuen(objKhachQuen, false);//,G_lstKhachQuen_Type,G_lstKhachQuen_Rank);
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

        private void gridKhachAo_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }

    }
}