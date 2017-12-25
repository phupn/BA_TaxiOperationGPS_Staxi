using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.Controls.Base;
using Taxi.Controls.Base.Common.RepositoryItems;
using Taxi.Data.FastTaxi;
using Taxi.Controls.Base.Extender;
using Taxi.Business;
namespace Taxi.Controls.FastTaxis.CuocAppKH
{
    public delegate void SoLuongCuoc(int sl);
    public partial class uc_CuocAppKH : UserControlBase
    {
        public event SoLuongCuoc EventSoLuongCuoc;
        public uc_CuocAppKH()
        {
            InitializeComponent();
        }
        private Timer timeXuLy;
        private DateTime DateMax;
        private int Tick_2s;
        private int Tick_5s;
        private int Tick_10s;
        private int RowIndex = 0;
        private int soluong = 0;
        public List<StaxiBook> listStaxiBook;
        
        public void Start()
        {
            try
            {
                grvDangXuLy.Add<RepositoryItemEnumLookupEdit_StaxiBookStatus>("Status");
                grvHoanThanh.Add<RepositoryItemEnumLookupEdit_StaxiBookStatus>("Status");
                listStaxiBook = StaxiBook.GetAll(ThongTinDangNhap.Line_Vung);
                grcDangXuLy.DataSource = listStaxiBook;
                grcDangXuLy.RefreshDataSource();
                Tick_2s = 0;
                Tick_5s = 0;
                Tick_10s = 0;
                timeXuLy = new Timer();
                DateMax = StaxiBook.Inst.GetTimeServer().Value;
                timeXuLy.Interval = 1000;
                timeXuLy.Tick += timeXuLy_Tick;
                timeXuLy.Start();
                soluong = listStaxiBook.Count;
                if (EventSoLuongCuoc != null)
                {
                    EventSoLuongCuoc(soluong);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void timeXuLy_Tick(object sender, EventArgs e)
        {
            try
            {


                bool HasThayDoiDuLieu = false;
                if (Tick_2s >= 2)
                {
                    var listUpdate = StaxiBook.LayDuLieuThayDoi(ThongTinDangNhap.Line_Vung, DateMax);
                    if (listUpdate != null && listUpdate.Count > 0)
                    {
                        HasThayDoiDuLieu = true;
                        foreach (var item in listUpdate)
                        {
                            if (DateMax < item.UpdateTime) DateMax = item.UpdateTime;
                            int Index = -1;
                            for (int i = 0; i < listStaxiBook.Count; i++)
                            {
                                if (item.Id == listStaxiBook[i].Id)
                                {
                                    Index = i;
                                    break;
                                }
                            }
                            if (Index == -1)
                            {
                                listStaxiBook.Insert(0, item);
                                RowIndex++;
                                soluong++;
                            }
                            else
                            {
                                var itemCopy = listStaxiBook[Index];
                                itemCopy.XeDenDiem = item.XeDenDiem;
                                itemCopy.XeDon = item.XeDenDiem;
                                itemCopy.XeDungDiem = item.XeDungDiem;
                                itemCopy.XeNhan = item.XeNhan;
                                itemCopy.XeTuChoi = item.XeTuChoi;
                                itemCopy.UpdateTime = item.UpdateTime;
                                itemCopy.Status = item.Status;
                                itemCopy.ServerCommand = item.ServerCommand;
                                itemCopy.DriverCommand = item.DriverCommand;
                                itemCopy.CancelType = item.CancelType;
                            }
                        }
                    }

                    Tick_2s = 0;
                }
                if (Tick_10s >= 10)
                {
                    StaxiBook.Timeout();
                    Tick_10s = 0;
                }
                if (Tick_5s >= 5)
                {
                    string Ids = "";
                    for (int i = 0; i < listStaxiBook.Count; i++)
                    {
                        Ids = Ids + "," + listStaxiBook[i].Id.ToString();
                    }
                    var lIds = StaxiBook.LayIDKetThuc(Ids);
                    if (lIds != null && lIds.Count > 0)
                    {
                        HasThayDoiDuLieu = true;
                        foreach (var item in lIds)
                        {
                            for (int index = 0; index < listStaxiBook.Count; index++)
                            {
                                if (item == listStaxiBook[index].Id)
                                {
                                    listStaxiBook.RemoveAt(index);
                                    if (RowIndex > index) RowIndex--;
                                    soluong--;
                                    break;
                                }
                            }
                        }
                    }


                    Tick_5s = 0;
                }
                Tick_2s++;
                Tick_5s++;
                Tick_10s++;
                
                if (HasThayDoiDuLieu)
                {
                    var RowIndex_Temp = RowIndex;
                    if (grcDangXuLy.DataSource == null)
                        grcDangXuLy.DataSource = listStaxiBook;
                    grcDangXuLy.RefreshDataSource();
                    grvDangXuLy.FocusedRowHandle = RowIndex_Temp;
                    if (EventSoLuongCuoc != null)
                    {
                        EventSoLuongCuoc(soluong);
                    }
                }
            }
            catch
            {

            }
        }

        private void tabCuocApp_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabCuocApp.SelectedTabPage == tabHoanThanh)
            {
                grcHoanThanh.DataSource = StaxiBook.LayBangTinKetThuc();
            }
        }

        private void grvDangXuLy_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            RowIndex = grvDangXuLy.FocusedRowHandle;
        }
    }
}
