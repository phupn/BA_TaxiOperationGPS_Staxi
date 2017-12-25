using System;
using System.Collections.Generic;
using System.Web;

namespace APIServices.Entities
{
    /// <summary>
    /// Congnt
    /// Class : thoong tin xe online, lay tu bang online phu vu xu ly du lieu tren client
    /// </summary>
    public class XeOnlineEntity
    {
        #region Properties

        private string bienSoXe;

        public string BienSoXe
        {
            get { return bienSoXe; }
            set { bienSoXe = value; }
        }

        private string soHieuXe;

        public string SoHieuXe
        {
            get { return soHieuXe; }
            set { soHieuXe = value; }
        }

        private float kinhDo;

        public float KinhDo
        {
            get { return kinhDo; }
            set { kinhDo = value; }
        }
        private float viDo;

        public float ViDo
        {
            get { return viDo; }
            set { viDo = value; }
        }
        private int trangThai;

        public int TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }
        #endregion Properties

        public XeOnlineEntity()
        {
        }

        public XeOnlineEntity(string bienSoXe,string soHieuXe, float kinhDo, float viDo, int trangThai)
        {
            this.BienSoXe = bienSoXe;
            this.SoHieuXe = soHieuXe;
            this.kinhDo = kinhDo;
            this.viDo = viDo;
            this.trangThai = trangThai;
        }
    }

    /// <summary>
    /// thong tin tham so dau vao cho thong tin lay xe toi diem 
    /// </summary>
    public class ThamSoXeToiDiem
    {
        private long idCuocGoi;

        public long IdCuocGoi
        {
            get { return idCuocGoi; }
            set { idCuocGoi = value; }
        }
        private float kinhDo;

        public float KinhDo
        {
            get { return kinhDo; }
            set { kinhDo = value; }
        }
        private float viDo;

        public float ViDo
        {
            get { return viDo; }
            set { viDo = value; }
        }
        private List<string> xeNhans = new List<string> ();

        public List<string> XeNhans
        {
            get { return xeNhans; }
            set { xeNhans = value; }
        }

        /// <summary>
        /// khoi tao voi thong tin 
        /// DS cac cuoc goi : IDCuocGoi;KinhDo;ViDo;DSXeNhan
        ///           Vi du : 190;105.010254;21.902343;4320.9890.4578      
        /// <param name="dsCuocGoiCanXeToiDiem"></param>
        public ThamSoXeToiDiem(string cuocGoiCanXeToiDiem)
        {
            string[] arr1 = cuocGoiCanXeToiDiem.Split(";".ToCharArray());

            IdCuocGoi   = long.Parse(arr1[0]);
            KinhDo = float.Parse(arr1[1]);
            ViDo = float.Parse(arr1[2]);

            string[] arr2 = arr1[3].Split(".".ToCharArray());
            if (arr2 != null && arr2.Length > 0)
            {
                if(XeNhans == null) 
                    XeNhans = new List<string>();
                for (int i = 0; i < arr2.Length; i++)
                {
                    xeNhans.Add(arr2[i]);
                }
            } 
        }
    }
}
