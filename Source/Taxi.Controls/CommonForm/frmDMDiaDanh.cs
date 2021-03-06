﻿using System;
using System.Data;
using System.Windows.Forms;
using Taxi.Business.DM;
using Taxi.Business;
using Taxi.Utils;

namespace Taxi.Controls.CommonForm
{
    public partial class frmDMDiaDanh : Form
    {
        private int g_LoaiDiaDanhID = -1;
        private bool bFirstLoadTree = false;
        public frmDMDiaDanh()
        {
            InitializeComponent();
        }

        private void frmDMDiaDanh_Load(object sender, EventArgs e)
        {
            LoadDSLoaiDiaDanh();
            LoadDSDiaDanh();
            txtTimKiem.Focus();
        }

        /// <summary>
        /// lay thong tin  loai dia danh va tao cay
        /// </summary>
        public void LoadDSLoaiDiaDanh()
        {
            DataTable dt;
            trvLoaiDiaDanh.Nodes.Clear();
            dt = new TuDienLoaiDiaDanh().LayDanhSach();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                TreeNode node;
                node = trvLoaiDiaDanh.Nodes.Add("Loại địa danh");
                node.Tag = new object();
                node.Tag = "-1";
                foreach (DataRow dr in dt.Rows)
                {
                    TreeNode nodeChild = new TreeNode();
                    nodeChild.Text = dr["TenLoaiDiaDanh"].ToString();
                    nodeChild.Tag = new object();
                    nodeChild.Tag = (string)dr["PK_LoaiDiaDanh"].ToString();
                    node.Nodes.Add(nodeChild);
                }
            }
            trvLoaiDiaDanh.ExpandAll();
        }

        public void LoadDSDiaDanh()
        {
            grcDiaDanh.DataSource = DiaDanh.GetDSDiaDanh();
        }
        public void LoadDSDiaDanh(int LoaiDiaDanhID)
        {
            grcDiaDanh.DataSource = DiaDanh.GetDSDiaDanh_ByLoaiDiaDanh(LoaiDiaDanhID);
        }
        private void lnkThemMoi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //new DMLoaiDiaDanh().ShowDialog();
            //LoadDSLoaiDiaDanh();
        }



        private void trvLoaiDiaDanh_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // new MessageBox.MessageBox().Show(e.Node.Tag.ToString ());
            if (!e.Node.Tag.ToString().Contains("-1"))
            {
                // load nhung dia danh tuong loai dia danh tuong ung
                g_LoaiDiaDanhID = int.Parse(e.Node.Tag.ToString());
            }
            else
            {
                if (!bFirstLoadTree) bFirstLoadTree = true;
                g_LoaiDiaDanhID = -1; // all
            }
            if (bFirstLoadTree)
            {
                LoadDSDiaDanh(g_LoaiDiaDanhID);
            }
        }

        private void lnkThemDiaDanh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // frmDiaDanh frm =  new frmDiaDanh();
            //if (frm.ShowDialog( this) == DialogResult.OK)
            //    {
            //       DiaDanh objDiaDanh = new DiaDanh ();
            //       objDiaDanh = frm.GetDiaDanh ();
            //        if ( objDiaDanh.TenDiaDanh .Length <= 0) return;

            //        if ( objDiaDanh.DiaChi .Length <= 0) return;


            //        if (!objDiaDanh.Insert())
            //        {
            //            new MessageBox.MessageBox().Show("Lỗi thêm mới địa danh");
            //            return;
            //        }
            //        else
            //        {
            //            //Load lai grid
            //            LoadDSDiaDanh(g_LoaiDiaDanhID);
            //            new MessageBox.MessageBox().Show("Thêm mới địa danh thành công");
            //        }

            //    }
        }

        private void lnkSuaDiaDanh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ////lay du lieu tu luoi
            //DiaDanh objDiaDanh = new DiaDanh ();
            //if (gridDiaDanh.SelectedItems.Count > 0)
            //{
            //    GridEXRow row = ((GridEXSelectedItem)gridDiaDanh.SelectedItems[0]).GetRow();
            //    objDiaDanh.DiaDanhID = int.Parse(row.Cells["PK_DiaDanh"].Value.ToString());
            //    objDiaDanh.TenDiaDanh = row.Cells["TenDiaDanh"].Value.ToString();
            //    objDiaDanh.DiaChi = row.Cells["DiaChi"].Value.ToString();
            //    objDiaDanh.DienThoai = row.Cells["DienThoai"].Value.ToString();
            //    objDiaDanh.GhiChu = row.Cells["MoTa"].Value.ToString();
            //    objDiaDanh.LoaiDiaDanhID = int.Parse(row.Cells["FK_LoaiDiaDanh"].Value.ToString());
            //}
            //else return ;

            //frmDiaDanh frm = new frmDiaDanh(objDiaDanh,false );
            // if (frm.ShowDialog(this) == DialogResult.OK)
            // {

            //     objDiaDanh = frm.GetDiaDanh();
            //    if (objDiaDanh.TenDiaDanh.Length <= 0) return;

            //    if (objDiaDanh.DiaChi.Length <= 0) return;


            //    if (!objDiaDanh.Update())
            //    {
            //        new MessageBox.MessageBox().Show("Lỗi cập nhật địa danh");
            //        return;
            //    }
            //    else
            //    {

            //        //Load lai grid
            //        LoadDSDiaDanh(g_LoaiDiaDanhID);
            //        new MessageBox.MessageBox().Show("Cập nhật địa danh thành công");

            //    }

            //} 
        }

        private void lnkXoaDiaDanh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //lay du lieu tu luoi
            DiaDanh objDiaDanh = new DiaDanh();
            if (grvDiaDanh.RowCount > 0)
            {
                DataRow row = grvDiaDanh.GetDataRow(grvDiaDanh.FocusedRowHandle);
                objDiaDanh.DiaDanhID = int.Parse(row["PK_DiaDanh"].ToString());
                objDiaDanh.TenDiaDanh = row["TenDiaDanh"].ToString();
                objDiaDanh.DiaChi = row["DiaChi"].ToString();
                objDiaDanh.DienThoai = row["DienThoai"].ToString();
                objDiaDanh.GhiChu = row["MoTa"].ToString();
                objDiaDanh.LoaiDiaDanhID = int.Parse(row["FK_LoaiDiaDanh"].ToString());
            }
            else return;
            MessageBox.MessageBoxBA msg = new MessageBox.MessageBoxBA();
            if (msg.Show("Bạn có đồng ý xóa địa danh này ?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.Yes.ToString())
            {
                if (objDiaDanh.Delete())
                {
                    //Load lai grid
                    LoadDSDiaDanh(g_LoaiDiaDanhID);
                    new MessageBox.MessageBoxBA().Show("Xóa địa danh thành công");
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Search();
        }
        /// <summary>
        /// tim kiếm thông tin địa danh
        /// </summary>
        private void Search()
        {
            string strSearch = StringTools.TrimSpace(txtTimKiem.Text);
            if (strSearch.Length > 0)
            {
                if (rdoDiaChi.Checked)
                {
                    grcDiaDanh.DataSource = DiaDanh.GetDSDiaDanh_ByDiaChi(strSearch);
                }
                else
                {
                    grcDiaDanh.DataSource = DiaDanh.GetDSDiaDanh_ByTenDiaDanh(strSearch);
                }
            }
            else
                LoadDSDiaDanh();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}