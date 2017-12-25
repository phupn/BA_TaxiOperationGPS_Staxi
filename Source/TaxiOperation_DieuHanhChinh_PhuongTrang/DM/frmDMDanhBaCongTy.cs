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

namespace Taxi.GUI
{
    public partial class frmDMDanhBaCongTy : Form
    {
        public frmDMDanhBaCongTy()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmDMDanhBaCongTy_Load);
        }

        void frmDMDanhBaCongTy_Load(object sender, EventArgs e)
        {
            LoadListDanhBaCongTy();
            
        }

        private void LoadListDanhBaCongTy()
        {
            List<DanhBaCongTy> lstDanhBaCongTy = new List<DanhBaCongTy>();
            lstDanhBaCongTy = DanhBaCongTy.GetDanhSachDanhBaCongTy();

            gridDMDanhBaCongTy.DataMember = "ListOfDBCongty";
            gridDMDanhBaCongTy.SetDataBinding(lstDanhBaCongTy, "ListOfDBCongty"); 
 
        }

        private void cmdAdd_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            //cmdNew cmdEdit cmdDelete cmdExit cmdHelp
            if (e.Command.Key == "cmdNew")
            {
                this.ThemDanhBaCongTy();
            }
            else if (e.Command.Key == "cmdEdit")
            {
                this.SuaDanhBaCongTy();
            }
            else if (e.Command.Key == "cmdDelete")
            {
                this.XoaDanhBaCongTy();
            }
            else if (e.Command.Key == "cmdExit")
            {
                this.Close();
                this.Dispose();
            }
            else if (e.Command.Key == "cmdHelp")
            {
                frmDanhBaCongTyTimKiem frm = new frmDanhBaCongTyTimKiem();
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    if (frm.GetResultListOfDanhBaCongTy().Count > 0)
                    {
                        gridDMDanhBaCongTy.DataSource = null;
                        gridDMDanhBaCongTy.DataMember = "ListOfDanhBaCongTy";
                        gridDMDanhBaCongTy.SetDataBinding(frm.GetResultListOfDanhBaCongTy(), "ListOfDanhBaCongTy");
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
        /// Mo form DanhBaCongTy de edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridDanhBaCongTy_DoubleClick(object sender, EventArgs e)
        {
            gridDMDanhBaCongTy.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridDMDanhBaCongTy.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)gridDMDanhBaCongTy.SelectedItems[0]).GetRow();
                DanhBaCongTy objDanhBaCongTy = (DanhBaCongTy)((GridEXSelectedItem)gridDMDanhBaCongTy.SelectedItems[0]).GetRow().DataRow;
                frmDanhBaCongTy frm = new frmDanhBaCongTy(objDanhBaCongTy, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objDanhBaCongTy = frm.GetDanhBaCongTy ();
                    frm.Dispose();
                    //Insert DataBase
                    if (!objDanhBaCongTy.Update())
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới danh bạ công ty");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListDanhBaCongTy();
                         
                    }
                }
                else return;
            }
        }


        #region Add, Delete DanhBaCongTy

        private void ThemDanhBaCongTy()
        {

            DanhBaCongTy objDanhBaCongTy = new DanhBaCongTy(string.Empty, string.Empty, string.Empty);
            frmDanhBaCongTy frm = new frmDanhBaCongTy(objDanhBaCongTy, true);// them moi
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objDanhBaCongTy = frm.GetDanhBaCongTy();
                    //Insert DataBase
                    if (StringTools.TrimSpace(objDanhBaCongTy.Name).Length <= 0) return;

                    if (StringTools.TrimSpace(objDanhBaCongTy.Address).Length <= 0) return;

                    if (StringTools.TrimSpace(objDanhBaCongTy.PhoneNumber).Length < 8) return;
                    if (!objDanhBaCongTy.Insert())
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới vào danh bạ công ty");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListDanhBaCongTy();
                        
                    }

                }
                  
        }
        private void SuaDanhBaCongTy()
        {
            gridDMDanhBaCongTy.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridDMDanhBaCongTy.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)gridDMDanhBaCongTy.SelectedItems[0]).GetRow();
                DanhBaCongTy objDanhBaCongTy = (DanhBaCongTy)((GridEXSelectedItem)gridDMDanhBaCongTy.SelectedItems[0]).GetRow().DataRow;
                frmDanhBaCongTy frm = new frmDanhBaCongTy(objDanhBaCongTy, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objDanhBaCongTy = frm.GetDanhBaCongTy();
                    if (StringTools.TrimSpace(objDanhBaCongTy.Name).Length <= 0) return;

                    if (StringTools.TrimSpace(objDanhBaCongTy.Address).Length <= 0) return;

                    if (StringTools.TrimSpace(objDanhBaCongTy.PhoneNumber).Length < 8) return;
                    //Insert DataBase
                    if (!objDanhBaCongTy.Update())
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới khách ảo");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListDanhBaCongTy();
                        
                    }                
                
                }
            }
        }
        private void XoaDanhBaCongTy()
        {
            gridDMDanhBaCongTy.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridDMDanhBaCongTy.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)gridDMDanhBaCongTy.SelectedItems[0]).GetRow();
                DanhBaCongTy objDanhBaCongTy = (DanhBaCongTy)((GridEXSelectedItem)gridDMDanhBaCongTy.SelectedItems[0]).GetRow().DataRow;
                MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA();

                if (msg.Show(this, "Bạn có xóa khách ảo " + objDanhBaCongTy.Name + " không ?", "Xóa khách ảo", Taxi.MessageBox.MessageBoxButtonsBA.OKCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.OK.ToString())
                {
                    if (!objDanhBaCongTy.Delete(objDanhBaCongTy.PhoneNumber ))
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới khách ảo");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListDanhBaCongTy();
                    }
                }

            }
        }
        #endregion Add, Delete DanhBaCongTy

    }
}