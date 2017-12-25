using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils.Enums;

namespace TaxiOperation_TongDai.FormFastTaxi
{
    public partial class frmLichSuCuocDieu : Form
    {
        public frmLichSuCuocDieu()
        {
            InitializeComponent();
        }

        public frmLichSuCuocDieu(CuocGoi cg)
        {
            InitializeComponent();
            ViewData(cg);}

        public void ViewData(CuocGoi cg)
        {
            var dt=CuocGoi.FT_GetHistoryByIdCuoc(cg.IDCuocGoi);
           dataGridView1.DataSource = dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var val = dt.Rows[i]["Status"];
                switch (int.Parse(val.ToString()))
                {
                    case (int)Enum_FastTaxi_Status.ChuyenSangDam:
                        val = "Chuyển sang đàm";
                        break;
                    case (int)Enum_FastTaxi_Status.Hoan:
                        val = "Hoãn";
                        break;

                    case (int)Enum_FastTaxi_Status.KhongXe:
                        val = "Không xe";
                        break;
                    case (int)Enum_FastTaxi_Status.MoiKhach:
                        val = "Mời khách";
                        break;
                    case (int)Enum_FastTaxi_Status.NhapXeDon:
                        val = "Nhập xe đón";
                        break;
                    case (int)Enum_FastTaxi_Status.NhapXeNhan:
                        val = "Nhập xe nhận";
                        break;
                    case (int)Enum_FastTaxi_Status.TiepNhanHuy:
                        val = "Tiếp nhận hủys";
                        break;
                    case (int)Enum_FastTaxi_Status.Truot:
                        val = "Trượt";
                        break;
                    //case (int)Enum_FastTaxi_Status.
                    //    val = "Chuyển sang đàm";
                    //    break;

                } 
                dt.Rows[i]["Status"] = val;
                dt.Rows[i].AcceptChanges();
            }
            txtDiaChiDon.Text = cg.DiaChiDonKhach;
            txtDiaChiTra.Text = cg.DiaChiTraKhach;
            txtLoaiXe.Text = cg.LoaiXe;
            txtSoLuong.Text = cg.SoLuong.ToString();
            txtTGDon.Text = string.Format("{0:HH:mm dd/MM/yyyy}", cg.FT_Date);
            txtDienThoai.Text = string.Format("[{0}] - {1} - {2:HH:mm dd/MM}", cg.Line, cg.PhoneNumber,cg.FT_SendDate);

        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
         
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
