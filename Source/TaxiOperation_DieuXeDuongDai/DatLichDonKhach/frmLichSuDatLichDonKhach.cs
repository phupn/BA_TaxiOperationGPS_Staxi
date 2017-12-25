using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.DieuXeDuongDai;
using Taxi.Data.DM;

namespace TaxiOperation_DieuXeDuongDai
{
    public partial class frmLichSuDatLichDonKhach : FormBase
    {
        public frmLichSuDatLichDonKhach()
        {
            InitializeComponent();
        }

        public void SetID(long id)
        {
            var dt = new DataTable();
            dt.Columns.Add("TrangThai");
            dt.Columns.Add("GiaTri");
            dt.Rows.Add("Chờ xử lý", 1);
            dt.Rows.Add("Đón được", 2);
            dt.Rows.Add("Khách hủy", 3);
            dt.Rows.Add("Không xe", 4);
            dt.Rows.Add("Trượt", 5);
            dt.Rows.Add("Hoãn", 6);
            
            reTrangThai.DataSource = dt;
            reTrangThai.DisplayMember = "TrangThai";
            reTrangThai.ValueMember = "GiaTri";
            reLoaiXe.DataSource = new LoaiXe().GetAllLoaiXe();
            reLoaiXe.DisplayMember = "TenLoaiXe";
            reLoaiXe.ValueMember = "LoaiXeID";
            var db = new DUONGDAI_KHACHHEN().GetLichSu(id);
            shGridControl1.SetDataSource(db);
        }
    }
}
