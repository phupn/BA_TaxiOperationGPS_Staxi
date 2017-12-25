using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Common.Extender;
using Taxi.Controls.Base;
using Taxi.Controls.Base.Common;
using Taxi.Controls.Base.Extender;
using Taxi.Data.FastTaxi;

namespace Taxi.Controls.FastTaxis.TaxiChieuVe
{
    public partial class frmDanhSachDuongDai : FormBase
    {
        public frmDanhSachDuongDai()
        {
            InitializeComponent();
        }

        public List<XeDiDuongDai> dulieu;
        public DateTime _thoiGianTruocLayDuLieu;
        public void LoadFull()
        {
            dulieu = XeDiDuongDai.Inst.GetDataByDate(deNgayDon.EditValue.To<DateTime>());
            shGridControl1.DataSource = dulieu;
        }
        private void TimerLayDuLieu_Tick(object sender, System.EventArgs e)
        {
            var data = XeDiDuongDai.Inst.GetDataByDateTime(deNgayDon.EditValue.To<DateTime>(), _thoiGianTruocLayDuLieu);

            if (data!=null&&data.Count>0)
            {
                 _thoiGianTruocLayDuLieu = DieuHanhTaxi.GetTimeServer();
                
                data.Where(p => !p.isDelete).ToList().ForEach(p =>
                {
                    var val = dulieu.FirstOrDefault(p1 => p1.ID == p.ID);
                    if (val != null)
                    {
                      var i=  dulieu.IndexOf(val);
                        dulieu.Remove(val);
                        dulieu.Insert(i, p);
                    }
                    else dulieu.Add(p);
                });
                data.Where(p => p.isDelete).ToList().ForEach(p =>
                {
                    var v = dulieu.FirstOrDefault(p1 => p1.ID == p.ID);
                    if (v != null)
                        dulieu.Remove(v);
                });
                shGridControl1.RefreshDataSource();
            }
        }

        private void frmDanhSachDuongDai_Load(object sender, EventArgs e)
        {
            gridView1.Add<RepositoryItemEnum_TrangThaiXeBaoDiDuongDai>("TrangThai");
            try
            {
                panel1.BindShControl();
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBox().Show(ex.Message);
            }
            LoadFull();
            _thoiGianTruocLayDuLieu = DieuHanhTaxi.GetTimeServer();
            TimerLayDuLieu.Start();
        }

        private void deNgayDon_EditValueChanged(object sender, EventArgs e)
        {
            LoadFull();
            TimKiem();
        }

        private void inputLookUp_Province1_EditValueChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void inputText1_EditValueChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void TimKiem()
        {
            shGridControl1.DataSource =
               dulieu.Where(
                   p =>
                       (inputLookUp_Province1.EditValue == null || inputLookUp_Province1.EditValue.To<int>()<=0||p.FK_TinhThanhDenID == inputLookUp_Province1.EditValue.To<int>()) &&
                       (inputText1.EditValue == null || inputText1.EditValue.To<string>().Trim() == "" ||
                        p.FK_SoHieuXe == inputText1.EditValue.To<string>())).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                var frm = new frmXeBaoDiDuongDai();
                frm.SetModel(gridView1.GetFocusedRow().As<XeDiDuongDai>());
                frm.ShowDialog();
            }
           
        }

        private void gridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (gridView1.GetFocusedRow() != null)
                {
                    var frm = new frmXeBaoDiDuongDai();
                    frm.SetModel(gridView1.GetFocusedRow().As<XeDiDuongDai>());
                    frm.ShowDialog();
                }
            }
        }
    }
}
