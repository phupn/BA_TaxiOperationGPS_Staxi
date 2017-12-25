using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Janus.Windows.GridEX;
using Taxi.Business.DM;

namespace Taxi.GUI
{
    public partial class frmDSNhanVien : Form
    {
        public frmDSNhanVien()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmDSNhanVien_Load);
        }

        void frmDSNhanVien_Load(object sender, EventArgs e)
        {
            LoadListNhanVien();
            
        }

        private void LoadListNhanVien()
        {
            List<NhanVien> lstNhanVien = new List<NhanVien>();
            lstNhanVien = new NhanVien().GetListNhanViens(); 

            grdNhanVien.DataMember = "ListOfNhanVien";
            grdNhanVien.SetDataBinding(lstNhanVien, "ListOfNhanVien"); 
 
        }

        private void cmdAdd_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            //cmdNew cmdEdit cmdDelete cmdExit cmdHelp
            if (e.Command.Key == "cmdNew")
            {
                this.ThemNhanVien();
            }
            else if (e.Command.Key == "cmdEdit")
            {
                this.SuaNhanVien();
            }
            else if (e.Command.Key == "cmdDelete")
            {
                this.XoaNhanVien();
            }
            else if (e.Command.Key == "cmdExit")
            {
                this.Close();
                this.Dispose();
            }
            else if (e.Command.Key == "cmdTimKiem")
            {
                frmNhanVienTimKiem frm = new frmNhanVienTimKiem();
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    if ((frm.GetResultListOfNhanVien()!=null) && (frm.GetResultListOfNhanVien().Count > 0))
                    {
                        grdNhanVien .DataSource = null;
                        grdNhanVien.DataMember = "ListOfDoiTac";
                        grdNhanVien.SetDataBinding(frm.GetResultListOfNhanVien(), "ListOfNhanVien");
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
        /// Mo form DOiTac de edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdDoiTac_DoubleClick(object sender, EventArgs e)
        {
            grdNhanVien.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdNhanVien.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)grdNhanVien.SelectedItems[0]).GetRow();
                NhanVien objNhanVien = (NhanVien)((GridEXSelectedItem)grdNhanVien.SelectedItems[0]).GetRow().DataRow;
                frmNhanVien frm = new frmNhanVien(objNhanVien, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objNhanVien = frm.GetNhanVien();
                    frm.Dispose();
                    //Insert DataBase
                    if (!objNhanVien.Update())
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới lái xe");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListNhanVien();
                    }
                }
                else return;
            }
        }


        #region Add, Delete NHANVIEN

        private void ThemNhanVien()
        {           
        
            // Khoi tao doi tuong nhan vien voi ma tu dong 
            string strMaNhanVien = NhanVien.GetNextMaNhanVien();
            if (strMaNhanVien.Length > 0)
            {
                NhanVien objNhanVien = new NhanVien(strMaNhanVien, string.Empty, DateTime.Now,true, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, 0, string.Empty,"");
                frmNhanVien frm = new frmNhanVien(objNhanVien, true);// them moi
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objNhanVien = frm.GetNhanVien();
                    frm.Dispose();
                     
                    //Insert DataBase
                    if (!objNhanVien.Insert())
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới lái xe");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListNhanVien();
                    }
                }
                else return;

            }
            else
            {
                new MessageBox.MessageBoxBA().Show("Lỗi cấp mã cho lái xe, liên hệ với quản trị");
                return;
            }
        }
        
        private void SuaNhanVien()
        {
            grdNhanVien.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdNhanVien.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)grdNhanVien.SelectedItems[0]).GetRow();
                NhanVien objNhanVien = (NhanVien)((GridEXSelectedItem)grdNhanVien.SelectedItems[0]).GetRow().DataRow;
                frmNhanVien frm = new frmNhanVien(objNhanVien, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objNhanVien = frm.GetNhanVien ();
                    frm.Dispose();
                    if (!objNhanVien.Update())
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi cập nhật lái xe");
                        return;
                    }
                    else
                    {
                        LoadListNhanVien();
                    }
                }
                else return;
            }
                
        }

        private void XoaNhanVien()
        {
            grdNhanVien.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdNhanVien.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)grdNhanVien.SelectedItems[0]).GetRow();
                NhanVien objNhanVien = (NhanVien)((GridEXSelectedItem)grdNhanVien.SelectedItems[0]).GetRow().DataRow;
                MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA();

                if (msg.Show(this, "Bạn có xóa lái xe " + objNhanVien.TenNhanVien  + " không ?", "Xóa lái xe", Taxi.MessageBox.MessageBoxButtonsBA.OKCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.OK.ToString())
                {
                    if (!objNhanVien.Delete(objNhanVien.MaNhanVien))
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi xóa lái xe");
                        return;
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Xóa lái xe thành công");
                        LoadListNhanVien();
                    }
                }

            }
        }
        #endregion Add, Delete DOITAC

    }
}