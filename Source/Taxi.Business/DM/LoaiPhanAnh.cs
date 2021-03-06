using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Taxi.Business.DM
{
    public class LoaiPhanAnh
    {
        private int _mID;
        public int ID
        {
            get { return _mID ;}
            set { _mID = value; }
        }
        private string _mTenLoaiPhanAnh;
        public string TenLoaiPhanAnh
        {
            get { return _mTenLoaiPhanAnh; }
            set { _mTenLoaiPhanAnh = value;}
        }
        private string _mUser;
        public string User
        {
            get { return _mUser; }
            set { _mUser = value; }
        }       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenLoaiPhanAnh"></param>
        /// <param name="user"></param>
        public LoaiPhanAnh( string tenLoaiPhanAnh, string user)
        {
            this._mTenLoaiPhanAnh = tenLoaiPhanAnh;
            this._mUser = user;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenLoaiPhanAnh"></param>
        /// <param name="user"></param>
        public LoaiPhanAnh(int id, string tenLoaiPhanAnh, string user)
        {
            this._mID = id;
            this._mTenLoaiPhanAnh = tenLoaiPhanAnh;
            this._mUser = user;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenLoaiPhanAnh"></param>
        public LoaiPhanAnh(int id, string tenLoaiPhanAnh)
        {
            this._mID = id;
            this._mTenLoaiPhanAnh = tenLoaiPhanAnh;
        
        }
        /// <summary>
        /// 
        /// </summary>
        public LoaiPhanAnh()
        { 
        
        }
        /// <summary>
        /// Chèn một loại phản ánh vào bảng 
        /// </summary>       
        /// <modified>
        /// Name         date        comments
        /// hangtm       17/5/2011   created
        /// </modified>
        public bool Insert()
        {
            return new Taxi.Data.DM.LoaiPhanAnh().Insert(this.TenLoaiPhanAnh ,this.User);
        }
        /// <summary>
        /// Sửa tên loại phản ánh
        /// </summary>        
        /// <modified>
        /// name         date        comments
        /// hangtm       17/5/2011   created
        /// </modified>
        public bool Update()
        {
            return new Taxi.Data.DM.LoaiPhanAnh().Update(this.ID ,this.TenLoaiPhanAnh ,this.User);
        }
        /// <summary>
        /// xóa 1 loại phản ánh trong bảng
        /// và cập nhật lại thứ tự các loại phản ánh trong bảng
        /// </summary>       
        /// <modified>
        /// name         date        comments
        /// hangtm      17/5/2011    created
        /// </modified>
        public bool Delete()
        {
            return new Taxi.Data.DM.LoaiPhanAnh().Delete(this.ID );
        }
        /// <summary>
        /// lấy ra bản ghi theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <modified>
        /// name         date        comments
        /// hangtm       17/5/2011   created
        /// </modified>
        public DataTable GetByID(int id)
        {
            return new Taxi.Data.DM.LoaiPhanAnh().GetByID(id);
        }
        /// <summary>
        /// Lấy ra cả bảng Khách hàng Phản ánh
        /// </summary>       
        /// <modified>
        /// name         date        comments
        /// hangtm       17/5/2011   created
        /// </modified>
        public static DataTable SelectAll()
        {
            return new Taxi.Data.DM.LoaiPhanAnh().SelectAll();
        }
        /// <summary>
        /// kiểm tra xem đã có tên nào trùng vơi tên vừa nhập chưa
        /// </summary>
        /// <param name="tenLoaiPhanAnh"></param>
        /// <returns></returns>
        /// <modified>
        /// name         date        comments
        /// hangtm       17/5/2011   created
        /// </modified>
        public static bool CheckTen(string tenLoaiPhanAnh)
        {
            return new Taxi.Data.DM.LoaiPhanAnh().CheckTen(tenLoaiPhanAnh);
        }
        /// <summary>
        /// sắp xếp lại thứ tự các mục phản ánh theo ý người dùng
        /// </summary>
        /// <param name="currentID"></param>
        /// <param name="thuTu"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        /// <modified>
        /// name         date        comments
        /// hangtm       18/5/2011   created
        /// </modified>
        public bool SortDMPhanAnh(int currentID,int thuTu,int sort )
        {
            return new Taxi.Data.DM.LoaiPhanAnh().SortDMPhanAnh(currentID,thuTu,sort);
        }
    }
}
