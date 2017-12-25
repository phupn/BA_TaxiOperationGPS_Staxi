using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using VScrollBar = DevExpress.XtraEditors.VScrollBar;

namespace Taxi.Controls.BanCo
{
    public class MyPanelControl : PanelControl
    {
        private MyDgv _dgv;
        private VScrollBar _vScroll;

        public MyPanelControl()
        {
             _vScroll = new VScrollBar
            {
                Dock = DockStyle.Right,
                Size = new Size(0, 0),
                Visible = true,
                Maximum = 100,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };
            _vScroll.Scroll += v_Scroll;
            _vScroll.ValueChanged += vScroll_ValueChanged;
            this.Controls.Add(_vScroll);
            _dgv= new MyDgv();
        }

        private void vScroll_ValueChanged(object sender, EventArgs e)
        {
            _vScroll.Maximum = _dgv.RowCount;
            if (_vScroll.Value > 0 && _vScroll.Value < _vScroll.Maximum)
                _dgv.FirstDisplayedScrollingRowIndex = _vScroll.Value - 1;
        }

        public void AddControl(MyDgv dgv)
        {
            this._dgv = dgv;
            _dgv.Dock = DockStyle.Fill;
            _dgv.ScrollBars=ScrollBars.None;
            _dgv.CellValueChanged += _dgv_CellValueChanged;
            _dgv.SizeChanged += _dgv_SizeChanged;
            _dgv.MouseWheel += _dgv_MouseWheel;
            this.Controls.Add(this._dgv);
        }

        private void _dgv_SizeChanged(object sender, EventArgs e)
        {
            _vScroll.Maximum = _dgv.RowCount;
        }
        private void _dgv_MouseWheel(object sender, MouseEventArgs e)
        {
            
            if (_vScroll.Visible == false) return;
            if (e.Delta <= 0)
            {
                if (_vScroll.Value <= _vScroll.Maximum)
                    _vScroll.Value += 1;
            }
            else
            {
                if (_vScroll.Value  >= _vScroll.Minimum)
                    _vScroll.Value -= 1;

            }
        }
        private void _dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _vScroll.Maximum = _dgv.RowCount;
        }
        private void v_Scroll(object sender, ScrollEventArgs e)
        {
            //if (e.NewValue > 0 && e.NewValue < vScroll.Maximum)
            //    _dgv.FirstDisplayedScrollingRowIndex = e.NewValue - 1;
        }

    }

}
