using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Controls;
using Taxi.Data.G5.DanhMuc;

namespace TaxiApplication
{
    public partial class FrmTestRealTimeGridView : Form
    {
        public FrmTestRealTimeGridView()
        {
            InitializeComponent();
        }

        private void FrmTestRealTimeGridView_Load(object sender, EventArgs e)
        {

            RealTimeEnvironment.IniRealTime();


            dienThoaiGridView1.FuncGetTimerServer = CommonBL.GetTimeServer;
            dienThoaiGridView1.FuncGetAll = CuocGoi.G5_DIENTHOAI_LayAllCuocGoi;
            dienThoaiGridView1.FuncGetNew = CuocGoi.G5_DIENTHOAI_LayDSCuocGoiMoi_FT;
            dienThoaiGridView1.FuncGetUpdate = CuocGoi.G5_DIENTHOAI_LayDSCuocGoiThayDoiByTongDai;
            dienThoaiGridView1.FuncGetDelete = (Line, LsKeys) => CuocGoi.G5_DIENTHOAI_LayCacIDCuocGoiKetThucByTongDai(LsKeys, Line);
            dienThoaiGridView1.LoadAll();
            dienThoaiGridView1.ActionPopUp += dienThoaiGridView1_ActionPopUp;
            dienThoaiGridView1.EventActionStep += dienThoaiGridView1_EventActionStep;
            dienThoaiGridView1.StartRealTime();

            dienThoaiGridView2.FuncGetTimerServer = CommonBL.GetTimeServer;
            dienThoaiGridView2.FuncGetAll = CuocGoi.G5_DIENTHOAI_LayAllCuocGoi;
            dienThoaiGridView2.FuncGetNew = CuocGoi.G5_DIENTHOAI_LayDSCuocGoiMoi_FT;
            dienThoaiGridView2.FuncGetUpdate = CuocGoi.G5_DIENTHOAI_LayDSCuocGoiThayDoiByTongDai;
            dienThoaiGridView2.FuncGetDelete = (Line, LsKeys) => CuocGoi.G5_DIENTHOAI_LayCacIDCuocGoiKetThucByTongDai(LsKeys, Line);
            dienThoaiGridView2.LoadAll();
            var testdb = RealTimeEnvironment.DicCommand;
            //for (int i = 0; i < 10; i++)
            //{
                #region===Gen label command===
                List<G5Command> lst = testdb;
                int rowCount = 4;
                if (lst.Count > 0)
                {

                    int mod = lst.Count % rowCount;
                    int indexCMD = 0;
                    int columnCount = mod == 0 ? lst.Count / rowCount : lst.Count / rowCount + 1;
                    DataTable dt = new DataTable();
                    for (int i = 0; i < columnCount; i++)
                    {
                        dt.Columns.Add(i.ToString(), typeof(string));
                    }
                    for (int i = 0; i < rowCount; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                    }
                    for (int j = 0; j < columnCount; j++)
                    {
                        for (int i = 0; i < rowCount; i++)
                        {
                            if (indexCMD + i > lst.Count)
                            {
                                break;
                            }
                            dt.Rows[i][j] = string.Format("Phím {0}\t: {1}", (char)lst[indexCMD].Shortcuts, lst[indexCMD].Command);
                            indexCMD++;
                            if (indexCMD >= lst.Count)
                            {
                                break;
                            }
                        }
                    }
                    grvCommand.DataSource = dt;

                    grvCommand.Visible = true;
                    grvCommand.Width = grvCommand.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
                    Screen scr = Screen.PrimaryScreen;
                    grvCommand.Left = (scr.WorkingArea.Width - this.Width) / 2 + this.Width - grvCommand.Width;
                    grvCommand.Top = (scr.WorkingArea.Height - this.Height) / 2 + this.Height - grvCommand.Height;
                    // grvCommand.Location = new Point(this.Width = grvCommand.Width,ribbonControl1.Width- grvCommand.Height);
                    grvCommand.Rows[0].Cells[0].Selected = false;

                }
                else
                {
                    grvCommand.Visible = false;
                }
                #endregion                
                var start = DateTime.Now;
                int row = 0;
                int col = 0;
                int height = 1;
                int with = 10;
                int withMax = 0;
                for (int i1 = 0; i1 < testdb.Count; i1++)
                {
                    if (row > 3)
                    {
                        row = 0;
                        col = col + 1;
                        with = with + withMax + 3;
                        withMax = 0;
                    }
                    var cmd = testdb[i1];
                    var lbl = new Label();
                    lbl.Text = string.Format("Phím {0}\t : {1}", cmd.Shortcuts, cmd.Command);
                    panelHelpCommand.Controls.Add(lbl);
                    lbl.Location = new Point(with, (lbl.Height + height) * row + height);
                    if (lbl.Width > withMax) withMax = lbl.Width;
                    row++;
                }
                panelHelpCommand.Width = with + withMax;
        }

        void dienThoaiGridView1_EventActionStep(Taxi.Controls.Base.Controls.Grids.Extends.RealTimeStep obj)
        {
            dienThoaiGridView2.ActionStep(obj);
        }

        void dienThoaiGridView1_ActionPopUp(CuocGoi obj)
        {
            this.Text = string.Format("Có địa chỉ mới:{0}-{1}",obj.PhoneNumber, obj.DiaChiDonKhach);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
