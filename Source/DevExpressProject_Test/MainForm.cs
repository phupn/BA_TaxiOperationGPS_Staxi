using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevExpressProject_Test
{
    public partial class MainForm : Form
    {
        private List<KhachHenTest> _lstSample ;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //decimal test = inputSpin1.Value;
            //string test2 = inputDate1.DateTime.ToString();
            //string test3 = inputDate2.Text;
            //MessageBox.Show(test + test2 + test3);
            LoadSampleData();
            gridKhachHen.DataSource = _lstSample;
        }

        private void LoadSampleData()
        {
            _lstSample = new List<KhachHenTest>();
            _lstSample.Add(new KhachHenTest{ThoiDiem = "1",DiaChi = "abc",KhachHang = "aaa",SoDienThoai = "1111"});
            _lstSample.Add(new KhachHenTest { ThoiDiem = "2", DiaChi = "abc1", KhachHang = "aaa111", SoDienThoai = "1111222" });
            _lstSample.Add(new KhachHenTest { ThoiDiem = "3", DiaChi = "abc11", KhachHang = "aaa111", SoDienThoai = "1111333" });
            _lstSample.Add(new KhachHenTest { ThoiDiem = "4", DiaChi = "abc111", KhachHang = "aaa111", SoDienThoai = "1111444" });
        }

        private void shButton1_Click(object sender, EventArgs e)
        {
            KhachHenTest obj = _lstSample[0];
            obj.DiaChi = "agahrgh29381938";
            _lstSample.Add(new KhachHenTest { ThoiDiem = "4", DiaChi = "abc111", KhachHang = "aaa111", SoDienThoai = "1111444" });
            //gridKhachHen.DataSource = _lstSample;
            gridKhachHen.RefreshDataSource();

            Dictionary<string, string> dic = new Dictionary<string, string>();
            obj.DiaChi = null;
            if(!dic.ContainsKey(obj.DiaChi))
                dic.Add(obj.DiaChi,"skgskgh");

        }

        private void shButton2_Click(object sender, EventArgs e)
        {
            _lstSample.RemoveAt(0);
            gridKhachHen.RefreshDataSource();
        }

    }

    public class KhachHenTest
    {
        public string ThoiDiem { get; set; }
        public string KhachHang { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
    }
}
