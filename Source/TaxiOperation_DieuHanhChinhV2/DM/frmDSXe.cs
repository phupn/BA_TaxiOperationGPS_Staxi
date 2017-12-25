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
    public partial class frmDSXe : Form
    {
        DataTable G_LoaiXe = new DataTable();
        DataTable G_Gara = new DataTable();
        public frmDSXe()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmDSXe_Load);
        }

        void frmDSXe_Load(object sender, EventArgs e)
        {
            LoadListXe();
            LoadDSGara();
            LoadLoaiXe();
        }

        private void LoadListXe()
        {
            List<Xe> lstXe = new List<Xe>();
            lstXe = new Xe().GetListXes();

            grdXe.DataMember = "ListOfXe";
            grdXe.SetDataBinding(lstXe, "ListOfXe");

        }

        private void LoadLoaiXe()
        {
            G_LoaiXe = new TinhTienTheoKm().GetAllLoaiXe();
        }

        private void LoadDSGara()
        {
            G_Gara = Gara.GetAllGara();
        }

        private void cmdAdd_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            //cmdNew cmdEdit cmdDelete cmdExit cmdHelp
            if (e.Command.Key == "cmdNew")
            {
                this.ThemXe();
            }
            else if (e.Command.Key == "cmdEdit")
            {
                this.SuaXe();
            }
            else if (e.Command.Key == "cmdDelete")
            {
                this.XoaXe();
            }
            else if (e.Command.Key == "cmdExit")
            {
                this.Close();
                this.Dispose();
            }
            else if (e.Command.Key == "cmdTimKiem")
            {
                frmTimKiemXe frm = new frmTimKiemXe();
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    if (frm.GetResultListOfXe().Count > 0)
                    {
                        grdXe.DataSource = null;
                        grdXe.DataMember = "ListOfXe";
                        grdXe.SetDataBinding(frm.GetResultListOfXe(), "ListOfXe");
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Không tìm thấy kết quả nào");
                        return;
                    }
                }
            }
        }


        ///// <summary>
        ///// Mo form DOiTac de edit
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void grdXe_DoubleClick(object sender, EventArgs e)
        {
            grdXe.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdXe.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)grdXe.SelectedItems[0]).GetRow();
                Xe objXe = (Xe)((GridEXSelectedItem)grdXe.SelectedItems[0]).GetRow().DataRow;
                frmXe frm = new frmXe(objXe, false, G_LoaiXe, G_Gara);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objXe = frm.GetXe();
                    frm.Dispose();
                    try
                    {
                         //Insert DataBase
                    if (!objXe.Update())
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi cập nhật thông tin xe");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListXe();
                    }
                    }
                    catch (Exception ex)
                    {
                        LogError.WriteLogError("DM Xe update", ex);

                        LoadListXe();
                    }
                   
                }
                else return;
            }
        }


        #region Add, Delete xe

        private void ThemXe()
        {

            // Khoi tao doi tuong DoiTac voi ma
            Xe objXe = new Xe();
            frmXe frm = new frmXe(objXe, true, G_LoaiXe, G_Gara);// them moi
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                objXe = frm.GetXe();
                frm.Dispose();
                //Insert DataBase
                if (!objXe.Insert())
                {
                    new MessageBox.MessageBoxBA().Show("Lỗi thêm mới xe taxi");
                    return;
                }
                else
                {
                    //Load lai grid
                    LoadListXe();
                }
            }
            else return;

        }

        private void SuaXe()
        {
            grdXe.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdXe.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)grdXe.SelectedItems[0]).GetRow();
                Xe objXe = (Xe)((GridEXSelectedItem)grdXe.SelectedItems[0]).GetRow().DataRow;
                frmXe frm = new frmXe(objXe, false, G_LoaiXe, G_Gara);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objXe = frm.GetXe();
                    frm.Dispose();
                    try
                    {
                        //Insert DataBase
                        if (!objXe.Update())
                        {
                            new MessageBox.MessageBoxBA().Show("Lỗi cập nhật thông tin xe");
                            return;
                        }
                        else
                        {
                            //Load lai grid
                            LoadListXe();
                        }
                    }
                    catch (Exception ex)
                    {
                        LogError.WriteLogError("DM Xe update", ex);

                        LoadListXe();
                    }
                }
                else return;
            }

        }

        private void XoaXe()
        {
            grdXe.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdXe.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)grdXe.SelectedItems[0]).GetRow();
                Xe objXe = (Xe)((GridEXSelectedItem)grdXe.SelectedItems[0]).GetRow().DataRow;
                MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA();

                if (msg.Show(this, "Bạn có xóa xe " + objXe.SoHieuXe + " không ?", "Xóa nhân viên", Taxi.MessageBox.MessageBoxButtonsBA.OKCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.OK.ToString())
                {
                    if (!objXe.Delete(objXe.SoHieuXe))
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi xóa thông tin xe");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListXe();
                    }
                }

            }
        }
        #endregion Add, Delete xe

        private void grdXe_FormattingRow(object sender, RowLoadEventArgs e)
        {
            //Xe  objXe= (Xe )e.Row.DataRow ;
            //if ((objXe.ThoiDiemGiaoCa == DateTime.MinValue) || (objXe.ThoiDiemGiaoCa== new DateTime (1900,01,01,01,01,01)))
            //{                 
            //     GridEXFormatStyle RowStyle = new GridEXFormatStyle();
            //     RowStyle.ForeColor = Color.White;
            //     e.Row.Cells["ThoiDiemGiaoCa"].FormatStyle = RowStyle;
            //}
        }

    }
}