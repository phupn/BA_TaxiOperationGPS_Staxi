using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Taxi.Business
{
    public class Chatting
    {
        public bool Insert(string UserName, string IPAddress, string ToUserName,
                        string ToIPAddress, string Subject, string Contents, DateTime Date, int Priority, bool status,string ListToUserName)
        {
            return new Taxi.Data.Chatting().Insert(UserName, IPAddress, ToUserName,
                        ToIPAddress, Subject, Contents, Date, Priority, status, ListToUserName);
        }

        /// <summary>
        /// Gửi lại tin nhắn
        /// </summary>
        public bool Insert_Resend(int Id)
        {
            return new Taxi.Data.Chatting().Insert_Resend(Id);
        }

        /// <summary>
        /// Update trang thai tin nhan
        /// </summary>
        /// <returns></returns>
        public bool Update(int IDMessage, string UserName, string IPAddress)
        {
            return new Taxi.Data.Chatting().Update(IDMessage, UserName, IPAddress);
        }

        /// <summary>
        /// Update trang thai (Luon luon hien thi) cua tin nhan
        /// </summary>
        /// <returns></returns>
        public bool Update_Status(int IDMessage, bool Status)
        {
            return new Taxi.Data.Chatting().Update_Status(IDMessage, Status);
        }

        /// <summary>
        /// Select noi dung chat trong ngay hien tai
        /// </summary>
        /// <returns></returns>
        public DataTable SelectByUserName(string UserName,DateTime date,int isAdmin)
        {
            return new Taxi.Data.Chatting().SelectByUserName(UserName, date, isAdmin);
        }

        /// <summary>
        /// Select chi tiet noi dung chat
        /// </summary>
        /// <returns></returns>
        public DataTable SelectByUserName_Top_Detail(string UserName, int isAdmin)
        {
            return new Taxi.Data.Chatting().SelectByUserName_Top_Detail(UserName, isAdmin);
        }

        /// <summary>
        /// Kiem tra co tin nhan moi
        /// </summary>
        public int CheckNewMessage(string UserName)
        {
            return new Taxi.Data.Chatting().CheckNewMessage(UserName);
        }

        /// <summary>
        /// Lay noi dung tin nhan moi
        /// </summary>
        /// <returns></returns>
        public DataTable GetNewMessage(string UserName)
        {
            return new Taxi.Data.Chatting().GetNewMessage(UserName);
        }

        /// <summary>
        /// Select noi dung chat theo Id
        /// </summary>
        /// <returns></returns>
        public DataTable SelectByID(int Id)
        {
            return new Taxi.Data.Chatting().SelectByID(Id);
        }

        /// <summary>
        /// Select cac Tai khoan dang check in
        /// </summary>
        /// <returns></returns>
        public DataTable SelectListUser_CheckIn()
        {
            return new Taxi.Data.Chatting().SelectListUser_CheckIn();
        }

        /// <summary>
        /// Select danh sách cac Tai khoan và hoat động
        /// </summary>
        /// <returns>
        /// Trả về danh sách nhân viên của hệ thống + IP address
        /// + Thời điểm checkout, check in
        /// </returns>
        public DataTable SelectUserCheckIn()
        {
            return new Taxi.Data.Chatting().SelectUserCheckIn();
        }

        /// <summary>
        /// Select tất cả Vùng
        /// </summary>        
        public DataTable SelectVung()
        {
            return new Taxi.Data.Chatting().SelectVung();
        }

        /// <summary>
        /// Select tất cả Line
        /// </summary>
        public DataTable SelectLine()
        {
            return new Taxi.Data.Chatting().SelectLine();
        }

        /// <summary>
        /// select tat ca noi dung chat theo thang
        /// </summary>
        public DataTable SelectMultiByUserName_Month(string UserName, int Month, int Year)
        {
            return new Taxi.Data.Chatting().SelectMultiByUserName_Month(UserName, Month, Year);
        }

        /// <summary>
        /// select tat ca noi dung chat
        /// </summary>
        /// <returns></returns>
        public DataTable SelectMultiByUserName(string UserName)
        {
            return new Taxi.Data.Chatting().SelectMultiByUserName(UserName);
        }

        /// <summary>
        /// select Message Template
        /// </summary>
        /// <returns></returns>
        public DataTable SelectMessageTemplate()
        {
            return new Taxi.Data.Chatting().SelectMessageTemplate();
        }

        /// <summary>
        /// Insert Message Template
        /// </summary>
        /// <returns></returns>
        public bool Insert_MessageTemplate(string Subject, string Contents)
        {
            return new Taxi.Data.Chatting().Insert_MessageTemplate(Subject, Contents);
        }

        /// <summary>
        /// Update Message Template
        /// </summary>
        /// <returns></returns>
        public bool Update_MessageTemplate(int IDMessage, string Subject, string Contents)
        {
            return new Taxi.Data.Chatting().Update_MessageTemplate(IDMessage, Subject, Contents);
        }

        /// <summary>
        /// DELETE Message Template
        /// </summary>
        /// <returns></returns>
        public bool Delete_MessageTemplate(int IDMessage)
        {
            return new Taxi.Data.Chatting().Delete_MessageTemplate(IDMessage);
        }
    }
}
