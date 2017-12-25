using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.QuanTri;
using Taxi.Utils;
using Taxi.Business;

namespace Taxi.GUI
{
   
    public partial class frmThemMayTinhGoiRa : Form
    {
        private string g_IP;
        private string g_Line_Vung;
        private bool g_IsActive;
        private string g_KieuMayTinh;
        private bool g_IsAdd = false;
        private  class Item
        {
            private int _id;

            public int id
            {
                get { return _id; }
                set { _id = value; }
            }
            private string _Text;

            public string Text
            {
                get { return _Text; }
                set { _Text = value; }
            }

            public Item(int ID, string text)
            {
                this.id = ID;
                this.Text = text;
            }
        }
        //PHÂN LOẠI
        //0 : Điện thoại
        //1 : Tổng đài
        //2 : Mời khách
        //3 : Tin Giá
        //4 : Khách hàng
        //5 : Trưởng ca
        //9 : Khác
        // 0: Điện thoại, 1: Tổng đài, 2: Mới khách

       

        public frmThemMayTinhGoiRa()
        {
            InitializeComponent();
        }
        /// <summary>
        /// //0 : Điện thoại
        //1 : Tổng đài
        //2 : Mời khách
        //3 : Tin Giá
        //4 : Khách hàng
        //5 : Trưởng ca
        //9 : Khác
        /// </summary>
        private void InitPhanLoaiGoiRa()
        {

                //object  choices = new Dictionary<string, string>();

                //choices["A"] = "Arthur";
                //choices["F"] = "Ford";
                //choices["T"] = "Trillian";
                //choices["Z"] = "Zaphod";
                //comboBox1.DataSource = new BindingSource(choices, null);
                //comboBox1.DisplayMember = "Value";
                //comboBox1.ValueMember = "Key"; 


            List<Item> lstItem = new List<Item>();
            lstItem.Add(new Item (0,"Điện thoại"));
            lstItem.Add(new Item(1, "Tổng đài"));
            lstItem.Add(new Item(2, "Mời khách"));
            lstItem.Add(new Item(3, "Tin giá"));
            lstItem.Add(new Item(4, "Khách hàng"));
            lstItem.Add(new Item(5, "Trưởng ca"));
            lstItem.Add(new Item(9, "Khác"));

           
            cboPhanLoaiMay.DataSource =  new BindingSource(lstItem, null).DataSource;
            cboPhanLoaiMay.DisplayMember = "Text";
            cboPhanLoaiMay.ValueMember = "id";

            
             
        }
        public frmThemMayTinhGoiRa(string IP, string Line_Vung, bool IsActive, string KieuMayTinh, bool IsAdd)
        {
            InitializeComponent();
            InitPhanLoaiGoiRa();
            txtIP.Text = g_IP = IP;
            txtLine_Vung.Text = g_Line_Vung = Line_Vung;
            chkChoPhep.Checked= g_IsActive = IsActive;
            g_KieuMayTinh = KieuMayTinh;
            if(IsAdd)
                this.Text = "Thêm mới";
            else 
                this.Text = "Sửa đổi";
            g_IsAdd = IsAdd; 
            
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool bOK = false;
            MessageBox.MessageBoxBA msg = new MessageBox.MessageBoxBA();
            g_IP = StringTools.TrimSpace(txtIP.Text);
            g_Line_Vung = StringTools.TrimSpace(txtLine_Vung.Text);
            int line = 0;
            if (!int.TryParse(g_Line_Vung, out line))
            {
                line = 0;
                msg.Show("Bạn phải nhập lại line, mỗi line trên một dòng.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.Yes);
                return;
            }
            g_IsActive = true;
            bOK = LineGoiRa.Insert(g_IP, g_Line_Vung, cboPhanLoaiMay.SelectedValue.ToString(), g_IsActive);
            if (bOK)
            {
                new MessageBox.MessageBoxBA().Show("Tạo thông tin máy tính thành công");
                this.Close();
            }
            else
                new MessageBox.MessageBoxBA().Show("Lỗi tạo thông tin máy tính thành công");
        } 
    }
}