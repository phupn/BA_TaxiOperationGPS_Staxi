using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi.ManHinhDieuXe
{
    public class ControlCommand
    {
        /// <summary>
        /// Object ID của đối tượng truyền từ server, đồng bộ với các 
        /// object sinh từ server
        /// </summary>
        private long _Oid;

        public long Oid
        {
            get { return _Oid; }
            set { _Oid = value; }
        }
        private string _MessageFromCallCenter;
        /// <summary>
        /// Lệnh thông báo từ tổng đài, độ dài tối đa 96 byte.
        /// Ví dụ: đón khách tại 123 xuân thủy, tổng đài gõ các thông
        /// tin của khách vào phần này
        /// </summary>        
        public string MessageFromCallCenter
        {
            set { _MessageFromCallCenter = value; }
            get { return _MessageFromCallCenter; }
        }


        private DateTime _ReceiveTime;
        /// <summary>
        /// Thời gian nhận thông báo từ tổng đài
        /// </summary>
        public DateTime ReceiveTime 
        { 
            set { _ReceiveTime = value; }
            get { return _ReceiveTime; }
        }
        private byte _NumberOfCarReceived; 
        /// <summary>
        /// Số xe nhận được lệnh điều
        /// </summary>
        public byte NumberOfCarReceived
        {
            get { return _NumberOfCarReceived; }
            set { _NumberOfCarReceived = value; }
        }

        private int _ShortestDistance;
        /// <summary>
        /// Khoảng cách ngắn nhất của xe đến vị trí khách
        /// </summary>
        public int ShortestDistance
        {
            get { return _ShortestDistance; }
            set { _ShortestDistance = value; }
        }
        
        /// <summary>
        /// Vị trí của khách
        /// </summary>
        private float _PassengerLongitude;

        public float PassengerLongitude
        {
            get { return _PassengerLongitude; }
            set { _PassengerLongitude = value; }
        }
        private float _PassengerLatitude;

        public float PassengerLatitude
        {
            get { return _PassengerLatitude; }
            set { _PassengerLatitude = value; }
        } 
        /// <summary>
        /// Danh sách các xe nhận lệnh
        /// </summary>
        public List<ActiveCarPosition> lstActiveCar = new List<ActiveCarPosition>();
    }

    public class ActiveCarPosition
    {
        /// <summary>
        /// Số hiện xe, tối đa 8 ký tự
        /// </summary>
        private string _VehicleName;

        public string VehicleName
        {
          get { return _VehicleName; }
          set { _VehicleName = value; }
        }
       
        private float _VehicleLongitude;

        public float VehicleLongitude
        {
          get { return _VehicleLongitude; }
          set { _VehicleLongitude = value; }
        }

        private float _VehicleLatitude;

        public float VehicleLatitude
        {
            get { return _VehicleLatitude; }
            set { _VehicleLatitude = value; }
        }
     
        
    }


}
