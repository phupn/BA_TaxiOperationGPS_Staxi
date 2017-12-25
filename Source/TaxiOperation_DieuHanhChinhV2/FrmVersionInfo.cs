using System;
using System.Collections.Generic;
using Taxi.Business.AutoUpdate;
using Taxi.Controls.Base;
using Taxi.Data.FastTaxi;
using Taxi.Utils;

namespace TaxiOperation_DieuHanhChinh
{
    public partial class FrmVersionInfo : FormBase
    {
        private AutoUpdate DienThoai { get; set; }
        private AutoUpdate TongDai { get; set; }
        private AutoUpdate DieuHanhChinh {get;set;}
        private List<SYS_VersionInfo> ListVer;
        private DateTime LastDate;
        private DateTime g_TimeServer;
        public FrmVersionInfo()
        {
            InitializeComponent();
        }

        private void FrmVersionInfo_Load(object sender, System.EventArgs e)
        {
            try
            {
                g_TimeServer = SYS_VersionInfo.Inst.GetTimeServer().Value;
                LastDate = g_TimeServer;
                ListVer = SYS_VersionInfo.GetList();
                DienThoai = AutoUpdate.GetVersionNew(EnumModule.G5_DienThoai);
                TongDai = AutoUpdate.GetVersionNew(EnumModule.G5_TongDai);
                DieuHanhChinh = AutoUpdate.GetVersionNew(EnumModule.DieuHanhChinh);
            }
            catch (Exception ex)
            { }
            #region Fill dữ liệu
            grdData.DataSource = ListVer;

            txt_DienThoai_PhienBan.Text = DienThoai.Version;
            txt_DienThoai_HanCapNhat.EditValue = DienThoai.UpdateDate;
            txt_DienThoai_MoTa.Text = DienThoai.Description;

            txt_TongDai_PhienBan.Text = TongDai.Version;
            txt_TongDai_HanCapNhat.EditValue = TongDai.UpdateDate;
            txt_TongDai_MoTa.Text = TongDai.Description;

            txt_DieuHanhChinh_PhienBan.Text = DieuHanhChinh.Version;
            txt_DieuHanhChinh_HanCapNhat.EditValue = DieuHanhChinh.UpdateDate;
            txt_DieuHanhChinh_MoTa.Text = DieuHanhChinh.Description;
            #endregion

        }

        private void btn_DienThoai_CapNhat_Click(object sender, EventArgs e)
        {
            DienThoai.Version=txt_DienThoai_PhienBan.Text;
            DienThoai.UpdateDate=txt_DienThoai_HanCapNhat.DateTime;
            DienThoai.Description=txt_DienThoai_MoTa.Text;
            if (DienThoai.Id <= 0)
            {
                DienThoai.UpdateFolder = EnumModule.G5_DienThoai.ToString();
                DienThoai.ModuleName = EnumModule.G5_DienThoai.ToString();
                DienThoai.Module = ((int)Module.DienThoaiVien).ToString();
            }
            DienThoai.Save();
        }

        private void btn_TongDai_CapNhat_Click(object sender, EventArgs e)
        {
            TongDai.Version = txt_TongDai_PhienBan.Text;
            TongDai.UpdateDate = txt_TongDai_HanCapNhat.DateTime;
            TongDai.Description = txt_TongDai_MoTa.Text;
            if (TongDai.Id <= 0)
            {
                TongDai.UpdateFolder = EnumModule.G5_TongDai.ToString();
                TongDai.ModuleName = EnumModule.G5_TongDai.ToString();
                TongDai.Module = ((int)Module.TongDaiVien).ToString();
            }
            TongDai.Save();
        }

        private void btn_DieuHanhChinh_CapNhat_Click(object sender, EventArgs e)
        {
            DieuHanhChinh.Version = txt_DieuHanhChinh_PhienBan.Text;
            DieuHanhChinh.UpdateDate = txt_DieuHanhChinh_HanCapNhat.DateTime;
            DieuHanhChinh.Description = txt_DieuHanhChinh_MoTa.Text;
            if (DieuHanhChinh.Id <= 0)
            {
                DieuHanhChinh.UpdateFolder = EnumModule.DieuHanhChinh.ToString();
                DieuHanhChinh.ModuleName = EnumModule.DieuHanhChinh.ToString();
                DieuHanhChinh.Module = ((int)Module.DieuHanhChinh).ToString();
            }
            DieuHanhChinh.Save();
        }

        private void TimeVersionInfo_Tick(object sender, EventArgs e)
        {
            try
            {
                g_TimeServer = g_TimeServer.AddSeconds(1);

                var lst = SYS_VersionInfo.GetLastUpdate(LastDate);
                if (lst!=null)
                {
                    foreach (var item in lst)
                    {
                        bool chk = true;
                        foreach (var item1 in ListVer)
                        {
                            if (item.Id == item1.Id)
                            {
                                chk = false;
                                item1.Status = item.Status;
                                item1.Username = item.Username;
                                item1.Version = item.Version;
                                item1.DateUpdate = item.DateUpdate;
                                break;
                            }
                        }
                        if (chk)
                        {
                            ListVer.Insert(0, item);
                        }
                    }

                    grdData.RefreshDataSource();
                }
            }
            catch (Exception ex) { }
        }

        private void reBtnKiemTraPhienBan_Click(object sender, EventArgs e)
        {
            var rowData= grvData.GetFocusedRow() as SYS_VersionInfo;
            if (rowData != null)
            {
                rowData.Status = "Đang kiểm tra";
                rowData.IsCheck = true;
                rowData.LastUpdate = g_TimeServer;
                rowData.Save();
                grdData.RefreshDataSource();
            }
        }

        private void reBtnBatBuocCapNhat_Click(object sender, EventArgs e)
        {
            var rowData = grvData.GetFocusedRow() as SYS_VersionInfo;
            if (rowData != null)
            {
                rowData.Status = "Bắt cập nhật";
                rowData.IsRequired = true;
                rowData.LastUpdate = g_TimeServer;
                rowData.Save();
                grdData.RefreshDataSource();
            }
        }
    }
}
