using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using Taxi.Controls.BaoCao;
using Taxi.Entity;
using MessageButton = Taxi.MessageBox.MessageBoxButtonsBA;
using MessageIcon = Taxi.MessageBox.MessageBoxIconBA;

namespace Taxi.Controls.DanhMuc
{
    [ReportInfo(Title = "Chi tiết lịch sử sửa địa chỉ đối tác")]
    public partial class frmLichSuSuaDiaChi : FrmReportBase
    {
        public frmLichSuSuaDiaChi()
        {
            InitializeComponent();

            this.gridViewLichSu.KeyDown += this.gridViewLichSu_KeyDown;
        }
        protected override void BeforeFind()
        {
            GridColumnSortInfo[] arrGroup = { new GridColumnSortInfo(gridViewLichSu.Columns[0], DevExpress.Data.ColumnSortOrder.Ascending) };
            gridViewLichSu.SortInfo.ClearAndAddRange(arrGroup, 1);
        }
        private void btnDuyet_Click(object sender, EventArgs e)
        {
            DuyetThongTinDiaChiMoi();
        }

        private void DuyetThongTinDiaChiMoi()
        {
            var row = gridViewLichSu.GetFocusedDataRow();
            if (row != null)
            {
                var msg = new MessageBox.MessageBoxBA().Show("Bạn có duyệt địa chỉ mới của đối tác này không?",
                    "Thông báo", MessageButton.YesNo, MessageIcon.Question);
                if (msg.ToLower() == "yes")
                {
                    long traceID = long.Parse(row["TraceID"].ToString());
                    string maDoiTac = row["MaDoiTac"].ToString();
                    string diaChiMoi = row["DiaChiDonKhachMoi"].ToString();
                    string daDuyet = row["DaDuyet"].ToString();
                    if (daDuyet == "1")
                    {
                        new MessageBox.MessageBoxBA().Show("Địa chỉ này đã được duyệt trước đó!", "Thông báo", MessageButton.OK, MessageIcon.Error);
                        return;
                    }
                    frmLuuDiaChiDoiTac frmLuu = new frmLuuDiaChiDoiTac();
                    frmLuu.MaDoiTac = maDoiTac;
                    frmLuu.TraceID = traceID;
                    frmLuu.DiaChiMoi = diaChiMoi;
                    frmLuu.ShowDialog();
                    if (frmLuu.IsSuccess)
                        this.ReLoadData();
                }
            }
            else
            {
                new MessageBox.MessageBoxBA().Show("Bạn vui lòng chọn dữ liệu trên lưới!", "Thông báo", MessageButton.OK, MessageIcon.Information);
            }
        }

        protected override object GetData()
        {
            return AddressTraceEntity.Inst.GetDataAddressTrace(this.FromDate.Value, this.ToDate.Value, txtMaDoiTac.Text, txtSDT.Text);
        }

        private void gridViewLichSu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                DuyetThongTinDiaChiMoi();
            }
        }

        private void gridViewLichSu_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                var row = (DataRowView)gridViewLichSu.GetRow(e.RowHandle);
                if (row!=null && row["DaDuyet"].ToString()=="1")
                {
                    e.Appearance.BackColor = Color.Ivory;
                }
            }
            catch
            {

            }
        }
    }
}
