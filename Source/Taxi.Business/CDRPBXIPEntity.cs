using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi.Business
{
    /// <summary>
    /// lop thong tin chi tin cua cdr trong tong dai ip
    /// </summary>
    public class CDRPBXIPEntity
    {
        public DateTime callDate { set; get; }
        public string src { set; get; }            // so dien thoi doi vao
        public string dst { set; get; }            // lin 
        public int duration { set; get; }          // thoi luong goi
        public int bells { set; get; }             // so chuong
        public string disposition { set; get; }    // thong tin tra loi ANSWERED/NO ANSWER
        public string fileVoicePath { set; get; }  // duong dan file
        public bool isUsed { set; get; }        // đã dùng cái này

        public CDRPBXIPEntity()
        {
            this.isUsed = false;                // khởi tạo chưa dùng
        }
    }

}
