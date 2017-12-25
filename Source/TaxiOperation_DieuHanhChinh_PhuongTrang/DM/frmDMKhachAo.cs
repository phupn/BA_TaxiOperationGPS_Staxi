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
    public partial class frmDMKhachAo : Form
    {
        public frmDMKhachAo()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmDMKhachAo_Load);
        }

        void frmDMKhachAo_Load(object sender, EventArgs e)
        {
            LoadListKhachAo();
            
        }

        private void LoadListKhachAo()
        {
            List<DanhBaKhachAo> lstKhachAo = new List<DanhBaKhachAo>();
            lstKhachAo = DanhBaKhachAo.GetDanhSachKhachAo();

            gridKhachAo.DataMember = "ListOfKhachAo";
            gridKhachAo.SetDataBinding(lstKhachAo, "ListOfKhachAo"); 
 
        }

        private void cmdAdd_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            //cmdNew cmdEdit cmdDelete cmdExit cmdHelp
            if (e.Command.Key == "cmdNew")
            {
                this.ThemKhachAo();
            }
            else if (e.Command.Key == "cmdEdit")
            {
                this.SuaKhachAo();
            }
            else if (e.Command.Key == "cmdDelete")
            {
                this.XoaKhachAo();
            }
            else if (e.Command.Key == "cmdExit")
            {
                this.Close();
                this.Dispose();
            }
            else if (e.Command.Key == "cmdHelp")
            {
                frmKhachAoTimKiem frm = new frmKhachAoTimKiem();
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    if (frm.GetResultListOfKhachAo().Count > 0)
                    {
                        gridKhachAo.DataSource = null;
                        gridKhachAo.DataMember = "ListOfKhachAo";
                        gridKhachAo.SetDataBinding(frm.GetResultListOfKhachAo(), "ListOfKhachAo");
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
                DanhBaKhachAo objKhachAo = (DanhBaKhachAo)((GridEXSelectedItem)gridKhachAo.SelectedItems[0]).GetRow().DataRow;
                frmKhachAo frm = new frmKhachAo(objKhachAo, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objKhachAo = frm.GetKhachAo();
                    frm.Dispose();
                    //Insert DataBase
                    if (!objKhachAo.Update())
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới khách ảo");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListKhachAo();
                         
                    }
                }
                else return;
            }
        }


        #region Add, Delete KhachAo

        private void ThemKhachAo()
        {
            
                DanhBaKhachAo  objKhachAo = new DanhBaKhachAo( string.Empty, string.Empty, string.Empty); 
                frmKhachAo frm = new frmKhachAo(objKhachAo, true);// them moi
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objKhachAo = frm.GetKhachAo();
                    //Insert DataBase
                    if (StringTools.TrimSpace(objKhachAo.Name).Length <= 0) return;

                    if (StringTools.TrimSpace(objKhachAo.Address).Length <= 0) return;

                    if (StringTools.TrimSpace(objKhachAo.PhoneNumber).Length < 8) return;
                    if (!objKhachAo.Insert())
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới khách ảo");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListKhachAo();
                        
                    }

                }
                  
        }
        private void SuaKhachAo()
        {
            gridKhachAo.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridKhachAo.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)gridKhachAo.SelectedItems[0]).GetRow();
                DanhBaKhachAo objKhachAo = (DanhBaKhachAo)((GridEXSelectedItem)gridKhachAo.SelectedItems[0]).GetRow().DataRow;
                frmKhachAo frm = new frmKhachAo(objKhachAo, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objKhachAo = frm.GetKhachAo();
                    if (StringTools.TrimSpace(objKhachAo.Name).Length <= 0) return;

                    if (StringTools.TrimSpace(objKhachAo.Address).Length <= 0) return;

                    if (StringTools.TrimSpace(objKhachAo.PhoneNumber).Length < 8) return;
                    //Insert DataBase
                    if (!objKhachAo.Update())
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới khách ảo");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListKhachAo();
                        
                    }                
                
                }
            }
        }
        private void XoaKhachAo()
        {
            gridKhachAo.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridKhachAo.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)gridKhachAo.SelectedItems[0]).GetRow();
                DanhBaKhachAo objKhachAo = (DanhBaKhachAo)((GridEXSelectedItem)gridKhachAo.SelectedItems[0]).GetRow().DataRow;
                MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA();

                if (msg.Show(this, "Bạn có xóa khách ảo " + objKhachAo.Name + " không ?", "Xóa khách ảo", Taxi.MessageBox.MessageBoxButtonsBA.OKCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.OK.ToString())
                {
                    if (!objKhachAo.Delete(objKhachAo.PhoneNumber ))
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới khách ảo");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListKhachAo();
                    }
                }

            }
        }
        #endregion Add, Delete KhachAo

    }
}