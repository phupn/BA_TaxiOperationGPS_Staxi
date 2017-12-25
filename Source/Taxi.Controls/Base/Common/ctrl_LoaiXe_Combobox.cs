using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Taxi.Controls.Base.Inputs;
using Taxi.Data.BanCo.Entity.GiamSatXe;

namespace Taxi.Controls.Base.Common
{
    public partial class ctrl_LoaiXe_Combobox : UserControl, IShInput
    {
        private TuDien_LoaiXe _tuDienLoaiXe;

        public static int LoaiXeID;        
        public bool EnterMoveNextControl { get { return lueSoHieuXe.EnterMoveNextControl; } set { lueSoHieuXe.EnterMoveNextControl = value; } }
        public bool SelectItemFirst { get; set; }
        public bool NoneItemAll { get; set; }

        public delegate void EditValueChangedEventHandler(object sender, EventArgs e);
        public event EditValueChangedEventHandler OnUserControlEditValueChanged;

        public ctrl_LoaiXe_Combobox()
        {
            InitializeComponent();
            _tuDienLoaiXe = new TuDien_LoaiXe();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
                DataTable dtXe = new DataTable();
                dtXe = _tuDienLoaiXe.GetDanhSachXe();
                if (!NoneItemAll)
                {
                    DataRow dr = dtXe.NewRow();
                    dr["LoaiXeID"] = "-1";
                    dr["TenLoaiXe"] = "Tất cả";
                    dtXe.Rows.Add(dr);
                }
                lueSoHieuXe.Properties.DataSource = dtXe;
                lueSoHieuXe.Properties.DisplayMember = "TenLoaiXe";
                lueSoHieuXe.Properties.ValueMember = "LoaiXeID";
                if (dtXe.Rows.Count>0)
                {
                    lueSoHieuXe.EditValue = dtXe.Rows[0]["LoaiXeID"];
                }
            }
            catch 
            {
                
            }
        }

        private void lueSoHieuXe_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSoHieuXe.EditValue != null)
                LoaiXeID = int.Parse(lueSoHieuXe.EditValue.ToString()) == -1 ? 0 : int.Parse(lueSoHieuXe.EditValue.ToString());            
            if (OnUserControlEditValueChanged != null)
                OnUserControlEditValueChanged(this, e);
        }

        public void Clear()
        {
            lueSoHieuXe.EditValue = null;
        }

        public void SetValue(object value)
        {
            lueSoHieuXe.EditValue = value;
        }

        public object GetValue()
        {
            return lueSoHieuXe.EditValue;
        }
    }
}
