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
    public partial class frmDMKhachVIP : Form
    {
        public frmDMKhachVIP()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmDMKhachVIP_Load);
        }

        void frmDMKhachVIP_Load(object sender, EventArgs e)
        {
            LoadListKhachVIP();
            
        }

        private void LoadListKhachVIP()
        {
            List<KhachVIP> lstKhachVIP = new List<KhachVIP>();
            lstKhachVIP = new KhachVIP().GetListOfKhachVIPs();

            grdKhachVIP.DataMember = "ListOfKhachVIP";
            grdKhachVIP.SetDataBinding(lstKhachVIP, "ListOfKhachVIP"); 
 
        }

        private void cmdAdd_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            //cmdNew cmdEdit cmdDelete cmdExit cmdHelp
            if (e.Command.Key == "cmdNew")
            {
                this.ThemKhachVIP();
            }
            else if (e.Command.Key == "cmdEdit")
            {
                this.SuaKhachVIP();
            }
            else if (e.Command.Key == "cmdDelete")
            {
                this.XoaKhachVIP();
            }
            else if (e.Command.Key == "cmdExit")
            {
                this.Close();
                this.Dispose();
            }
        }
        /// <summary>
        /// Mo form KhachVIP de edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdKhachVIP_DoubleClick(object sender, EventArgs e)
        {
            grdKhachVIP.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdKhachVIP.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)grdKhachVIP.SelectedItems[0]).GetRow();
                KhachVIP objKhachVIP = (KhachVIP)((GridEXSelectedItem)grdKhachVIP.SelectedItems[0]).GetRow().DataRow;
                frmKhachVIP frm = new frmKhachVIP(objKhachVIP, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objKhachVIP = frm.GetKhachVIP();
                    frm.Dispose();
                    //Insert DataBase
                    if (!objKhachVIP.Update())
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới khách VIP");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListKhachVIP();
                    }
                }
                else return;
            }
        }


        #region Add, Delete KhachVIP

        private void ThemKhachVIP()
        {
            // Khoi tao doi tuong KhachVIP voi ma
            string strMaKhachVIP = KhachVIP.GetNextMaKhachVIP();
            if (strMaKhachVIP.Length > 0)
            {
                KhachVIP objKhachVIP = new KhachVIP(strMaKhachVIP, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
                frmKhachVIP frm = new frmKhachVIP(objKhachVIP, true);// them moi
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objKhachVIP = frm.GetKhachVIP();
                    
                    //Insert DataBase
                    if (!objKhachVIP.Insert())
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới khách VIP");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListKhachVIP();
                    }
                }
                else return;

            }
            else
            {
                new MessageBox.MessageBoxBA().Show("Hết mã cho khách VIP, liên hệ với quản trị");
                return;
            }
        }
        
        private void SuaKhachVIP()
        {
            grdKhachVIP.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdKhachVIP.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)grdKhachVIP.SelectedItems[0]).GetRow();
                KhachVIP objKhachVIP = (KhachVIP)((GridEXSelectedItem)grdKhachVIP.SelectedItems[0]).GetRow().DataRow;
                frmKhachVIP frm = new frmKhachVIP(objKhachVIP, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objKhachVIP = frm.GetKhachVIP();
                    if (StringTools.TrimSpace(objKhachVIP.Name).Length <= 0) return;

                    if (StringTools.TrimSpace(objKhachVIP.Address).Length <= 0) return;

                    if (StringTools.TrimSpace(objKhachVIP.Phones).Length < 8) return;
                    //Insert DataBase
                    if (!objKhachVIP.Update())
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới khách VIP");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListKhachVIP();
                    }
                }
                else return;
            }
                
        }

        private void XoaKhachVIP()
        {
            grdKhachVIP.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdKhachVIP.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)grdKhachVIP.SelectedItems[0]).GetRow();
                KhachVIP objKhachVIP = (KhachVIP)((GridEXSelectedItem)grdKhachVIP.SelectedItems[0]).GetRow().DataRow;
                MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA();

                if (msg.Show(this, "Bạn có xóa khách VIP " + objKhachVIP.Name + " không ?", "Xóa khách VIP", Taxi.MessageBox.MessageBoxButtonsBA.OKCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.OK.ToString())
                {
                    if (!objKhachVIP.Delete(objKhachVIP.MaKhachVIP))
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới khách VIP");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListKhachVIP();
                    }
                }

            }
        }
        #endregion Add, Delete KhachVIP

    }
}