namespace GMap.NET.WindowsForms.Markers{
    using System.Drawing;
    public class GMapMarkerVehice : GMapMarkerCustom
    {
        public GMapMarkerVehice(PointLatLng p, int trangThai)
            : base(p)
        {
            ShowIcon(trangThai, false);
           // Offset = new Point(-10, -34);
        }
        public GMapMarkerVehice(PointLatLng p, int trangThai,bool IsG5)
            : base(p)
        {
            ShowIcon(trangThai, IsG5);
            // Offset = new Point(-10, -34);
        }
        private void ShowIcon(int trangThai, bool IsG5)
        {
            if (IsG5)
            {
                if (trangThai == 1)
                    Icon = Taxi.Controls.Properties.Resources.ic_marker_carpoint_red_30;
                else if (trangThai == 0)
                    Icon = Taxi.Controls.Properties.Resources.ic_marker_carpoint_gray_30;
                else if (trangThai == 2)
                    Icon = Taxi.Controls.Properties.Resources.ic_marker_carpoint_blue_26x40;
                //Size = new Size(16, 16);
                
            }
            else
            {
                if (trangThai == 1)
                    Icon = Taxi.Controls.Properties.Resources.ic_marker_carpoint_red_30;
                else if (trangThai == 0)
                    Icon = Taxi.Controls.Properties.Resources.ic_marker_carpoint_gray_30;
                else if (trangThai == 2)
                    Icon = Taxi.Controls.Properties.Resources.ic_marker_carpoint_blue_26x40;
                Size = new Size(16, 16);
            }
        }

        public GMapMarkerVehice(PointLatLng p, int huong, int socho, int trangthai, int trangthaikhac)
            : base(p)
        {


            #region----Check xe mat tin hieu----
            if (socho == 4 & trangthaikhac == -2)
            {
                Icon = Taxi.Controls.Properties.Resources.Xe6401;
            }
            else if (socho == 7 & trangthaikhac == -2)
            {
                Icon = Taxi.Controls.Properties.Resources.Xe6701;
            }
            #endregion--------End--------------------

            #region-------------xe 4 cho co khach tat may---------
            //xe 4 cho co khach tat may
            else if (huong == 1 && socho == 4 && (trangthai & 3) > 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe143;
            else if (huong == 0 && socho == 4 && (trangthai & 3) > 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe143;
            else if (huong == 2 && socho == 4 && (trangthai & 3) > 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe243;
            else if (huong == 3 && socho == 4 && (trangthai & 3) > 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe343;
            else if (huong == 4 && socho == 4 && (trangthai & 3) > 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe443;
            else if (huong == 5 && socho == 4 && (trangthai & 3) > 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe543;
            else if (huong == 6 && socho == 4 && (trangthai & 3) > 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe643;
            else if (huong == 7 && socho == 4 && (trangthai & 3) > 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe743;
            else if (huong == 8 && socho == 4 && (trangthai & 3) > 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe843;
            #endregion-----------End---------------------------------

            #region----------xe 4 cho khong khach tat may----------------
            //xe 4 cho khong khach tat may
            else if (huong == 1 && socho == 4 && (trangthai & 3) <= 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe142;
            else if (huong == 0 && socho == 4 && (trangthai & 3) <= 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe142;
            else if (huong == 2 && socho == 4 && (trangthai & 3) <= 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe242;
            else if (huong == 3 && socho == 4 && (trangthai & 3) <= 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe342;
            else if (huong == 4 && socho == 4 && (trangthai & 3) <= 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe442;
            else if (huong == 5 && socho == 4 && (trangthai & 3) <= 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe542;
            else if (huong == 6 && socho == 4 && (trangthai & 3) <= 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe642;
            else if (huong == 7 && socho == 4 && (trangthai & 3) <= 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe742;
            else if (huong == 8 && socho == 4 && (trangthai & 3) <= 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe842;
            #endregion-------------End--------------------------------------------------

            #region-------xe 4 cho khong khach-----------
            //xe 4 cho khong khach
            else if (huong == 1 && socho == 4 && (trangthai & 3) <= 0)
                Icon = Taxi.Controls.Properties.Resources.Xe140;
            else if (huong == 0 && socho == 4 && (trangthai & 3) <= 0)
                Icon = Taxi.Controls.Properties.Resources.Xe140;
            else if (huong == 2 && socho == 4 && (trangthai & 3) <= 0)
                Icon = Taxi.Controls.Properties.Resources.Xe240;
            else if (huong == 3 && socho == 4 && (trangthai & 3) <= 0)
                Icon = Taxi.Controls.Properties.Resources.Xe340;
            else if (huong == 4 && socho == 4 && (trangthai & 3) <= 0)
                Icon = Taxi.Controls.Properties.Resources.Xe440;
            else if (huong == 5 && socho == 4 && (trangthai & 3) <= 0)
                Icon = Taxi.Controls.Properties.Resources.Xe540;
            else if (huong == 6 && socho == 4 && (trangthai & 3) <= 0)
                Icon = Taxi.Controls.Properties.Resources.Xe640;
            else if (huong == 7 && socho == 4 && (trangthai & 3) <= 0)
                Icon = Taxi.Controls.Properties.Resources.Xe740;
            else if (huong == 8 && socho == 4 && (trangthai & 3) <= 0)
                Icon = Taxi.Controls.Properties.Resources.Xe840;
            #endregion--------end of xe 4 cho khong khach------------


            #region-----xe 4 cho co khach---------
            //xe 4 cho co khach
            else if (huong == 1 && socho == 4 && (trangthai & 3) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe141;
            else if (huong == 0 && socho == 4 && (trangthai & 3) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe141;
            else if (huong == 2 && socho == 4 && (trangthai & 3) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe241;
            else if (huong == 3 && socho == 4 && (trangthai & 3) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe341;
            else if (huong == 4 && socho == 4 && (trangthai & 3) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe441;
            else if (huong == 5 && socho == 4 && (trangthai & 3) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe541;
            else if (huong == 6 && socho == 4 && (trangthai & 3) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe641;
            else if (huong == 7 && socho == 4 && (trangthai & 3) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe741;
            else if (huong == 8 && socho == 4 && (trangthai & 3) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe841;
            #endregion------End of xe 4 cho co khach-----------------------



            #region----------xe 7 cho khong khach tat may-----------

            else if (huong == 0 && socho == 7 && (trangthai & 3) <= 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe172;
            else if (huong == 1 && socho == 7 && (trangthai & 3) <= 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe172;
            else if (huong == 2 && socho == 7 && (trangthai & 3) <= 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe272;
            else if (huong == 3 && socho == 7 && (trangthai & 3) <= 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe372;
            else if (huong == 4 && socho == 7 && (trangthai & 3) <= 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe472;
            else if (huong == 5 && socho == 7 && (trangthai & 3) <= 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe572;
            else if (huong == 6 && socho == 7 && (trangthai & 3) <= 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe672;
            else if (huong == 7 && socho == 7 && (trangthai & 3) <= 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe772;
            else if (huong == 8 && socho == 7 && (trangthai & 3) <= 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe872;

            #endregion---------End----------------------------------

            #region----------xe 7 cho co khach tat may-----------

            else if (huong == 0 && socho == 7 && (trangthai & 3) > 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe173;
            else if (huong == 1 && socho == 7 && (trangthai & 3) > 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe173;
            else if (huong == 2 && socho == 7 && (trangthai & 3) > 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe273;
            else if (huong == 3 && socho == 7 && (trangthai & 3) > 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe373;
            else if (huong == 4 && socho == 7 && (trangthai & 3) > 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe473;
            else if (huong == 5 && socho == 7 && (trangthai & 3) > 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe573;
            else if (huong == 6 && socho == 7 && (trangthai & 3) <= 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe673;
            else if (huong == 7 && socho == 7 && (trangthai & 3) > 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe773;
            else if (huong == 8 && socho == 7 && (trangthai & 3) > 0 && (trangthai & 8) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe873;

            #endregion---------End----------------------------------

            #region---------xe 7 cho khong khach-------------
            //xe 7 cho khong khach
            else if (huong == 0 && socho == 7 && (trangthai & 3) <= 0)
                Icon = Taxi.Controls.Properties.Resources.Xe170;
            else if (huong == 1 && socho == 7 && (trangthai & 3) <= 0)
                Icon = Taxi.Controls.Properties.Resources.Xe170;
            else if (huong == 2 && socho == 7 && (trangthai & 3) <= 0)
                Icon = Taxi.Controls.Properties.Resources.Xe270;
            else if (huong == 3 && socho == 7 && (trangthai & 3) <= 0)
                Icon = Taxi.Controls.Properties.Resources.Xe370;
            else if (huong == 4 && socho == 7 && (trangthai & 3) <= 0)
                Icon = Taxi.Controls.Properties.Resources.Xe470;
            else if (huong == 5 && socho == 7 && (trangthai & 3) <= 0)
                Icon = Taxi.Controls.Properties.Resources.Xe570;
            else if (huong == 6 && socho == 7 && (trangthai & 3) <= 0)
                Icon = Taxi.Controls.Properties.Resources.Xe670;
            else if (huong == 7 && socho == 7 && (trangthai & 3) <= 0)
                Icon = Taxi.Controls.Properties.Resources.Xe770;
            else if (huong == 8 && socho == 7 && (trangthai & 3) <= 0)
                Icon = Taxi.Controls.Properties.Resources.Xe870;
            #endregion----------End-------------------------------------


            #region----------xe 7 cho co khach-----------
            //xe 7 cho co khach
            else if (huong == 0 && socho == 7 && (trangthai & 3) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe171;
            else if (huong == 1 && socho == 7 && (trangthai & 3) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe171;
            else if (huong == 2 && socho == 7 && (trangthai & 3) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe271;
            else if (huong == 3 && socho == 7 && (trangthai & 3) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe371;
            else if (huong == 4 && socho == 7 && (trangthai & 3) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe471;
            else if (huong == 5 && socho == 7 && (trangthai & 3) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe571;
            else if (huong == 6 && socho == 7 && (trangthai & 3) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe671;
            else if (huong == 7 && socho == 7 && (trangthai & 3) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe771;
            else if (huong == 8 && socho == 7 && (trangthai & 3) > 0)
                Icon = Taxi.Controls.Properties.Resources.Xe871;
            #endregion------------End----------------------------------
        }
    }
}