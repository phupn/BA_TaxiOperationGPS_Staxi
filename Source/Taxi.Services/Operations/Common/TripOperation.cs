using System;
using System.Collections.Generic;
using Taxi.Utils;

namespace Taxi.Services.Operations
{
    public class TripOperation
    {
        public long IdCuocKhach { get; set; }
        public string DiaChiDon { get; set; }
        public LatLngOperation ToaDoDon { get; set; }
        public string DiaChiTra { get; set; }
        public LatLngOperation ToaDoTra { get; set; }
        public string Note { get; set; }
        public byte Quantity { get; set; }
        public string CarType { get; set; }
        public byte CustomerType { get; set; }
        public string Phone { get; set; }
        public LatLngOperation CurrentLatLng { get; set; }
        public int SoLuongCuocSaoChep { get; set; }
        public bool IsCopy { get; set; }
        public Guid? BookId { get; set; }
        public List<Vehicle> XeDieuChiDinh { get; set; }
        /// <summary>
        /// Em đi ngủ chút rùi.dậy gửi thư nhé.
        /// </summary>
        public int SleepCuoc { get; set; }
        /// <summary>
        /// Danh sách xe từ chối
        /// </summary>
        public string[] VehiclesDeny { get; set; }
        public int Money { get; set; }
    }
}
