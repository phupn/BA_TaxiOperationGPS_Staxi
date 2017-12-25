using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Controls.Base;
using Taxi.Data.CanhBaoDieuApp;

namespace TaxiOperation_TongDai.CanhBaoSanBay
{
    public partial class frmCanhBaoSanBay : FormBase
    {
        private List<CanhBaoCuocSanBay> _lstCanhBao;
        private int _timeAutoDelete;
        private Dictionary<string, string> _dicRemoveCuocSanBay;//Chứa các cảnh báo đã xóa trong phiên làm việc!
        public delegate void DelegateOnClick(DateTime pTime);
        public DelegateOnClick OnClickCuocSanBay { get; set; }
        #region ===Form events ===
        public frmCanhBaoSanBay()
        {
            InitializeComponent();
            _lstCanhBao = new List<CanhBaoCuocSanBay>();
            _dicRemoveCuocSanBay = new Dictionary<string, string>();
        }
        private void frmCanhBaoSanBay_Load(object sender, EventArgs e)
        {
            
            timerCanhBao.Start();
            var wa = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(wa.Right - this.Width, wa.Bottom - this.Height);
        }
        private void frmCanhBaoSanBay_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
        private void grvCanhBaoSanBay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (grvCanhBaoSanBay.RowCount > 0)
                {
                    var item = grvCanhBaoSanBay.GetFocusedRow() as CanhBaoCuocSanBay;
                    if (item != null && MessageBox.Show("Bạn muốn xóa cảnh báo SĐT: " + item.SoDienThoai + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        item.IsDisplay = false;
                        _dicRemoveCuocSanBay.Add(item.ThoiGianNhan+item.NoiDung,"0");
                        grcCanhBaoSanBay.DataSource = _lstCanhBao.Where(s => s.IsDisplay && !_dicRemoveCuocSanBay.ContainsKey(s.ThoiGianNhan+s.NoiDung)).ToList();
                        grcCanhBaoSanBay.RefreshDataSource();
                        if (_lstCanhBao.Count <= 0)
                        {
                            this.Hide();
                        }
                    }
                }
            }
        }
        private void grvCanhBaoSanBay_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == grvCanhBaoSanBay.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Green;
                if (e.Column.FieldName != "NoiDung")
                {
                    e.Appearance.ForeColor = Color.White;
                }
                else
                {
                    e.Appearance.ForeColor = Color.Beige;
                }
                e.Appearance.Font = new Font(Font.FontFamily, 8, FontStyle.Bold);
            }
        }

        #endregion

        #region === Methods ===
        public void SetCanhBao(List<CanhBaoCuocSanBay> lst)
        {
            if (lst != null && lst.Count > 0)
            {
                if (grvCanhBaoSanBay.RowCount <= 0)
                {
                    lst = lst.Where(s => (!_dicRemoveCuocSanBay.ContainsKey(s.ThoiGianNhan+s.NoiDung))).ToList();
                    grcCanhBaoSanBay.DataSource = lst;
                    _lstCanhBao.AddRange(lst);
                    if(lst.Count>0)
                        this.Show();
                }
                else
                {
                    _lstCanhBao = lst;                                                                    
                    if (_lstCanhBao.Count > 0)
                    {
                        _lstCanhBao = _lstCanhBao.Where(s => s.IsDisplay && !_dicRemoveCuocSanBay.ContainsKey(s.ThoiGianNhan+s.NoiDung) ).ToList();
                        grcCanhBaoSanBay.DataSource = _lstCanhBao;
                        if(_lstCanhBao.Count>0)
                            this.Show();
                    }

                }
            }
            else
            {
                grcCanhBaoSanBay.DataSource = null;
            }
        }
        #endregion
         
        private void timerCanhBao_Tick(object sender, EventArgs e)
        {
            _timeAutoDelete++;
            if (_timeAutoDelete >= 30)
            {
                if (grvCanhBaoSanBay.RowCount > 0)
                {
                    List<CanhBaoCuocSanBay> lst = grvCanhBaoSanBay.DataSource as List<CanhBaoCuocSanBay>;
                    if (lst != null)
                    {
                        var lstObj = lst.Where(x => (CommonBL.GetTimeServer() - x.ThoiGianNhan).TotalMinutes >= 15).ToList();
                        foreach (var item in lstObj)
                        {
                            lst.Remove(item);
                        }
                    }
                    grcCanhBaoSanBay.RefreshDataSource();
                    if (grvCanhBaoSanBay.RowCount == 0)
                    {
                        this.Hide();
                    }
                }
                _timeAutoDelete = 0;
            }
        }

        private void grcCanhBaoSanBay_DoubleClick(object sender, EventArgs e)
        {
            if (grvCanhBaoSanBay.RowCount > 0)
            {
                var item = grvCanhBaoSanBay.GetFocusedRow() as CanhBaoCuocSanBay;
                if (item != null)
                {
                    DateTime pTime = item.ThoiGianNhan;
                    if (OnClickCuocSanBay != null)
                        OnClickCuocSanBay(pTime);
                }
            }
        }
    }
}
