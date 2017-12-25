using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi.Entity
{
    public  class OnlineCarEntity
    {

        private string _MaXN;

        public string MaXN
        {
            get { return _MaXN; }
            set { _MaXN = value; }
        }

        private string _BienSoXe;

        public string BienSoXe
        {
            get { return _BienSoXe; }
            set { _BienSoXe = value; }
        }

        private DateTime _ThoidiemGui;

        public DateTime ThoidiemGui
        {
            get { return _ThoidiemGui; }
            set { _ThoidiemGui = value; }
        }

        private DateTime _ThoidiemchenDLServer;

        public DateTime ThoidiemchenDLServer
        {
            get { return _ThoidiemchenDLServer; }
            set { _ThoidiemchenDLServer = value; }
        }

        private DateTime _ThoidiemChenDL;

        public DateTime ThoidiemChenDL
        {
            get { return _ThoidiemChenDL; }
            set { _ThoidiemChenDL = value; }
        }


        private float _KinhDo;

        public float KinhDo
        {
            get { return _KinhDo; }
            set { _KinhDo = value; }
        }

        private float _ViDo;

        public float ViDo
        {
            get { return _ViDo; }
            set { _ViDo = value; }
        }

        private int _Vantocco;

        public int Vantocco
        {
            get { return _Vantocco; }
            set { _Vantocco = value; }
        }

        private int _VantocPGS;

        public int VantocPGS
        {
            get { return _VantocPGS; }
            set { _VantocPGS = value; }
        }

        private int _Trangthai;

        public int Trangthai
        {
            get { return _Trangthai; }
            set { _Trangthai = value; }
        }

        private string _SoHieuXe;

        public string SoHieuXe
        {
            get { return _SoHieuXe; }
            set { _SoHieuXe = value; }
        }

        private int _Huong;

        public int Huong
        {
            get { return _Huong; }
            set { _Huong = value; }
        }

        private int _SoChoNgoi;

        public int SoChoNgoi
        {
            get { return _SoChoNgoi; }
            set { _SoChoNgoi = value; }
        }

        private int _disTance;

        public int disTance
        {
            get { return _disTance; }
            set { _disTance = value; }
        }
    }
}
