using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Business.BanDoXe;
using Taxi.Entity;
using Janus.Windows.GridEX;

namespace Taxi.GUI
{
    public partial class frmDinhNghiVietTatDuong : Form
    {
        #region Declare varible 
        private string G_NameVN = "";
        private frmSuaVietTat mSuaVietTat = new frmSuaVietTat();
        public frmSuaVietTat SuaVietTat
        {
            get
            {
                return mSuaVietTat;
            }
            //  set { mDieuHanhTaxi = value; }
        }
        #endregion 
        public frmDinhNghiVietTatDuong()
        {
            InitializeComponent();           
        }

        private void LoadAllRoad(string MaCungXN, int ProvinceID)
        {
            try
            {
                clsRoad clsRoads = new clsRoad();
                List<RoadEntity> lstRoad = clsRoads.GetAllRoadbyMAXN_ProvinceID(MaCungXN, ProvinceID);
                gridVietTatTenDuong.SetDataBinding(lstRoad, "ListRoad");
                GridEXFilterCondition Filter = new GridEXFilterCondition(gridVietTatTenDuong.RootTable.Columns["NameVN"], ConditionOperator.Equal, G_NameVN);

                if (gridVietTatTenDuong.Find(Filter, -1, 1))
                {
                    GridEXRow row = (gridVietTatTenDuong.SelectedItems[0]).GetRow();
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = System.Drawing.Color.DodgerBlue;
                    row.RowStyle = RowStyle;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadAllRoad: ", ex);
            }
        }
        private void frmDinhNghiVietTatDuong_Load(object sender, EventArgs e)
        {            
            LoadAllRoad("329", 0);            
        }

        private void gridBaoCaoBieuMau1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NhapDuLieuVaoTruyenDi(false);
            }           
        }

        private void NhapDuLieuVaoTruyenDi(bool isAddnew)
        {
            try
            {
                if (isAddnew)
                {
                    frmSuaVietTat frmSuaVietTat = new frmSuaVietTat();
                    frmSuaVietTat.ShowDialog(this);
                    G_NameVN = frmSuaVietTat.G_NameVN;
                    if (G_NameVN != "")
                        LoadAllRoad("", 0);
                }
                else
                {
                    gridVietTatTenDuong.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                    if (gridVietTatTenDuong.SelectedItems.Count > 0 && gridVietTatTenDuong.CurrentRow.RowIndex >= 0)
                    {
                        RoadEntity objRoad = (RoadEntity)(gridVietTatTenDuong.SelectedItems[0]).GetRow().DataRow;
                        using (frmSuaVietTat frmSuaVietTat = new frmSuaVietTat(objRoad))
                        {
                            if (frmSuaVietTat.ShowDialog(this) == DialogResult.OK)
                            {
                                G_NameVN = frmSuaVietTat.G_NameVN;
                                frmSuaVietTat.Close();
                            }
                        }
                        LoadAllRoad("", 0);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("NhapDuLieuVaoTruyenDi: ", ex);                
            }
        }

        private void deleteRecord()
        {
            try
            {
                if (gridVietTatTenDuong.SelectedItems.Count > 0 && gridVietTatTenDuong.CurrentRow.RowIndex >= 0)
                {
                    RoadEntity objRoad = (RoadEntity)(gridVietTatTenDuong.SelectedItems[0]).GetRow().DataRow;
                    int Id = objRoad.ID;
                    string dialog = new MessageBox.MessageBoxBA().Show("Bạn có muốn xóa không ?", "Thông báo", MessageBox.MessageBoxButtonsBA.YesNo, MessageBox.MessageBoxIconBA.Question);
                    if (dialog == "Yes")
                    {
                        clsRoad objTenDuong = new clsRoad();
                        if (objTenDuong.Delete_TenVietTat(Id))
                        {
                            LoadAllRoad("", 0);
                        }
                        else
                        {
                            new MessageBox.MessageBoxBA().Show("Xóa không thành công", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("deleteRecord: ", ex);                
            }
        }

        #region Xử lý hot key

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            else if (keyData == Keys.Delete)
            {
                this.deleteRecord();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.N))
            {
                NhapDuLieuVaoTruyenDi(true);
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        #endregion

        private void gridBaoCaoBieuMau1_DoubleClick(object sender, EventArgs e)
        {
            NhapDuLieuVaoTruyenDi(false);
        }
    }
}