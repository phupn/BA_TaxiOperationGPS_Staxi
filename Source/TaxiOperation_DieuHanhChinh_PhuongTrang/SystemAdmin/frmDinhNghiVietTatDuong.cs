using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Taxi.Business.BanDoXe;
using Taxi.Entity;
using Janus.Windows.GridEX;
using Taxi.Business;
using System.Globalization;
using Taxi.Services.BAGPS;
namespace Taxi.GUI
{
    public partial class frmDinhNghiVietTatDuong : Form
    {
        #region declare varible 
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

      private void LoadAllRoad ( string MaCungXN , int ProvinceID) {
          try
          {
              clsRoad clsRoads = new clsRoad();
              List<RoadEntity> lstRoad = clsRoads.GetAllRoadbyMAXN_ProvinceID(MaCungXN, ProvinceID);
              #region Update All Kinh Do - Vi Do
              //gridBaoCaoBieuMau1.DataSource = lstRoad;
              //float viDo = 0;
              //float kinhDo = 0;
              //string toaDo = "";
              //foreach (clsRoadEntity item in lstRoad)
              //{
              //    if (item.KinhDo > 0 && item.ViDo > 0) continue;

              //    toaDo = GetGeobyAddressBA2(item.NameVN);
              //    if (toaDo != "*" && toaDo != string.Empty)
              //    {
              //        string[] arrString = toaDo.Split(' ');
              //        float.TryParse(arrString[0], NumberStyles.AllowDecimalPoint ,new CultureInfo("vi-VN", true), out viDo);
              //        float.TryParse(arrString[1], NumberStyles.AllowDecimalPoint, new CultureInfo("vi-VN", true), out kinhDo);
              //    }

              //    new clsRoad().Update_TenVietTat(item.ID, item.VietTat, item.NameVN, item.NameEN, kinhDo, viDo);
              //}
              #endregion

              gridVietTatTenDuong.SetDataBinding(lstRoad, "ListRoad");

              GridEXFilterCondition Filter = new GridEXFilterCondition(gridVietTatTenDuong.RootTable.Columns["NameVN"], ConditionOperator.Equal, G_NameVN);

              if (gridVietTatTenDuong.Find(Filter, -1, 1))
              {
                  GridEXRow row = ((GridEXSelectedItem)gridVietTatTenDuong.SelectedItems[0]).GetRow();

                  GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                  RowStyle.BackColor = System.Drawing.Color.DodgerBlue;
                  row.RowStyle = RowStyle;
                  //gridVietTatTenDuong.RootTable.ApplyFilter(ab);
              }
          }
          catch (Exception ex)
          {
              LogError.WriteLogError(this.Name, ex);
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
                //goi form sua viet tat
                NhapDuLieuVaoTruyenDi(false);
            }           
        }

        private void NhapDuLieuVaoTruyenDi(bool isAddnew)
        {
            if (isAddnew)
            {
                using (frmSuaVietTat frmSuaVietTat = new frmSuaVietTat())
                {
                    frmSuaVietTat.ShowDialog(this);
                    G_NameVN = frmSuaVietTat.G_NameVN;
                    if (G_NameVN != "")
                        LoadAllRoad("", 0);                    
                }
            }
            else
            {
                gridVietTatTenDuong.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (gridVietTatTenDuong.SelectedItems.Count > 0 && gridVietTatTenDuong.CurrentRow.RowIndex >= 0)
                {
                    RoadEntity objRoad = (RoadEntity)((GridEXSelectedItem)gridVietTatTenDuong.SelectedItems[0]).GetRow().DataRow;
                    using (frmSuaVietTat frmSuaVietTat = new frmSuaVietTat(objRoad))
                    {
                        if (frmSuaVietTat.ShowDialog(this) == DialogResult.OK)
                        {
                            G_NameVN = frmSuaVietTat.G_NameVN;
                            //objRoad = frmSuaVietTat.GetRoadEntity;
                            frmSuaVietTat.Close();
                            LoadAllRoad("", 0);
                        }
                    }
                }
            }
        }

        private void deleteRecord()
        {
            if (gridVietTatTenDuong.SelectedItems.Count > 0 && gridVietTatTenDuong.CurrentRow.RowIndex >= 0)
            {
                RoadEntity objRoad = (RoadEntity)((GridEXSelectedItem)gridVietTatTenDuong.SelectedItems[0]).GetRow().DataRow;
                int Id = objRoad.ID;
                string dialog = new MessageBox.MessageBoxBA().Show("Bạn có muốn xóa không ?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question);
                if (dialog == "Yes")
                {                    
                    clsRoad objTenDuong = new clsRoad();
                    if (objTenDuong.Delete_TenVietTat(Id))
                    {
                        LoadAllRoad("", 0);
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Xóa không thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }
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

        private void gridVietTatTenDuong_FilterApplied(object sender, EventArgs e)
        {
            GridEXFilterCondition a = gridVietTatTenDuong.RootTable.FilterApplied;
        }
    }
}