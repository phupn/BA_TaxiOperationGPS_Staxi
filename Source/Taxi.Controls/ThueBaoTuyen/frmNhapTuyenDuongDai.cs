using System;
using System.Data;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Common.Extender;
using Taxi.Controls.Base;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Data.BanCo.Entity.TuyenThueBao;
using LoaiXe = Taxi.Data.G5.DanhMuc.LoaiXe;
using MessageBoxButtons = Taxi.MessageBox.MessageBoxButtonsBA;
using MessageBoxIcon = Taxi.MessageBox.MessageBoxIconBA;

namespace Taxi.Controls.ThueBaoTuyen
{
    public partial class frmNhapTuyenDuongDai : FormRibbon
    {
        #region Properties & Constructor!
        private const string PHUTROI = "Phụ trội 8,500 đ/Km và 10,000 đ/Giờ !!";
        private bool _isLoading = false;        
        private float _giaPhuTroi = 0;
        public bool IsSuccess = false;        
        public CuocGoi CuocGoi;
        public string GhiChu_DuongDai { get; set; }
        public int IDLoaiXeStaxi;
        public string SMSMessage { get; set; }
        public string LoaiXeID { get; set; }    // Khớp trường STaxiType trong bảng T_Staxi_CarType với trường LoaiXeID_FastTaxi.
        public frmNhapTuyenDuongDai()
        {
            InitializeComponent();
            lblPhuTroi.Text = PHUTROI;
            ExitOnEscape = true;
        }

        #endregion

        #region Event!
        private void frmNhapTuyenDuongDai_Load(object sender, EventArgs e)
        {
            _isLoading = true;           
            LoadAllCombobox();
            LoadData();
            LoadLoaiXeByFastTaxi();
            _isLoading = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DatGiaTriCuocGoi(ref CuocGoi);
        }

        private void cboChieu_EditValueChanged(object sender, EventArgs e)
        {
            LoadAllTextBox();
            int loaxeID = cboLoaiXe.EditValue.To<int>();
            DisplayLabelPhuTroi(loaxeID);
        }

        private void cboChayTuyen_EditValueChanged(object sender, EventArgs e)
        {
            LoadAllTextBox();
        }

        private void cboLoaiXe_EditValueChanged(object sender, EventArgs e)
        {
            LoadAllTextBox();
            int loaxeID = cboLoaiXe.EditValue.To<int>();
            LoaiXe temp = cboLoaiXe.GetData.Find(a=>a.LoaiXeID==loaxeID);
            if (temp != null)
            {              
                IDLoaiXeStaxi =temp.LoaiXeID_FastTaxi;
            }
            DisplayLabelPhuTroi(loaxeID);
        }

        private void DisplayLabelPhuTroi(int pLoaiXeID)
        {
            VuotGioQuyDinh temp = CommonBL.ListDanhMucVuotGio.Find(a=>a.FK_LoaiXeID==pLoaiXeID);
            if (temp != null)
            {
                int chieuID = cboChieu.EditValue.To<int>();
                if (chieuID==1)
                {
                    lblPhuTroi.Text = "Phụ trội " + temp.GiaDinhMucVuot1KmMotChieu.ToString("###,##0.##") + " đ/Km và " + temp.GiaDinhMucVuot1GioMotChieu.ToString("###,##0.##") + " đ/Giờ.";   //"Phụ trội 8,500 đ/Km và 10,000 đ/Giờ."
                    _giaPhuTroi = temp.GiaDinhMucVuot1KmMotChieu;
                }
                else
                {
                    lblPhuTroi.Text = "Phụ trội " + temp.GiaDinhMucVuot1KmHaiChieu.ToString("###,##0.##") + " đ/Km và " + temp.GiaDinhMucVuot1GioHaiChieu.ToString("###,##0.##") + " đ/Giờ.";   //"Phụ trội 8,500 đ/Km và 10,000 đ/Giờ."
                    _giaPhuTroi = temp.GiaDinhMucVuot1KmHaiChieu;
                }
            }
            else
            {
                lblPhuTroi.Text = PHUTROI;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F2:
                    btnSave_Click(null, null);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Methods!
        private void LoadLoaiXeByFastTaxi()
        {
            try
            {
                DataTable data = new TuDien_LoaiXe().LayDanhSachXeTheoIDFastTaxi(LoaiXeID);
                if (data.Rows.Count > 0 && CuocGoi.Long_LoaiXeID.To<int>() == 0)
                {
                    cboLoaiXe.EditValue = data.Rows[0]["LoaiXeID"].To<int>();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadLoaiXeByFastTaxi: ",ex);                
            }
        }

        private void LoadData()
        {
            try
            {
                if (CuocGoi.Long_TuyenID.Length>1)
                {
                    cboChayTuyen.EditValue = CuocGoi.Long_TuyenID;
                    cboChieu.EditValue = CuocGoi.Long_ChieuID;
                    cboLoaiXe.EditValue = CuocGoi.Long_LoaiXeID.To<int>();
                    txtGia.Text = CuocGoi.Long_GiaTien.ToString("###,##0.##");
                    txtKm.Text = CuocGoi.Long_Km.ToString("####,##0.##");
                    txtThoiGian.Text = CuocGoi.Long_ThoiGian.ToString();
                }
            }
            catch 
            {
                new MessageBox.MessageBoxBA().Show("Lỗi khi lấy dữ liệu trên giao diện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadAllCombobox()
        {
            try
            {
                cboChayTuyen.Properties.DataSource = new DMTuyenThueBao().getAllTuyenDuong();
                cboChayTuyen.Properties.ValueMember = "TuyenDuongID";
                cboChayTuyen.Properties.DisplayMember = "TenTuyenDuong";
                cboChayTuyen.ItemIndex = 0;

                cboChieu.Properties.DataSource = new DMTuyenThueBao().getAllKieuTuyen();
                cboChieu.Properties.ValueMember = "Id";
                cboChieu.Properties.DisplayMember = "TypeName";
                cboChieu.ItemIndex = 0;

                cboLoaiXe.Bind();
                cboLoaiXe.ItemIndex = 1;
            }
            catch
            {
                new MessageBox.MessageBoxBA().Show("Lỗi khi lấy dữ liệu trên giao diện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
     
        private void DatGiaTriCuocGoi(ref CuocGoi pCuocGoi)
        {
            if (CheckValidate())
            {
                pCuocGoi.Long_LoaiXeID = cboLoaiXe.EditValue.ToString();
                pCuocGoi.Long_TuyenID = cboChayTuyen.EditValue.ToString();
                pCuocGoi.Long_ChieuID = cboChieu.EditValue.To<int>();
                pCuocGoi.Long_GiaTien = txtGia.Text.Replace(",","").To<int>();
                pCuocGoi.Long_Km = txtKm.Text.Replace(",", "").To<int>();
                pCuocGoi.Long_ThoiGian = txtThoiGian.Text.Replace(",", "").To<int>();
                SetSMSMessage();
                pCuocGoi.SMSDuongDai = SMSMessage;
                GhiChu_DuongDai = string.Format("{0}{1}", cboChayTuyen.Text, cboChieu.Text);
                IsSuccess = true;               
                this.Close();
            }
        }

        private void SetSMSMessage()
        {
            int chieu = cboChieu.EditValue.To<int>();
            if ( chieu== 1)
            {
                SMSMessage = string.Format("Taxi Ba Sao : Xe {0} han hanh phuc vu quy khach. Lo trinh 1 chieu {1} km, gia tien tam tinh: {2} d, phu troi: {3} d/Km, phi cau duong trong chuyen di qui khach vui long thanh toan. Chuc quy khach thuong lo binh an!",cboLoaiXe.Text, txtKm.Text,txtGia.Text,_giaPhuTroi) ;
            }
            else if(chieu ==2)
            {
                SMSMessage = string.Format("Taxi Ba Sao : Xe {0} han hanh phuc vu quy khach. Lo trinh 2 chieu {1} km, gia tien tam tinh: {2} d, phu troi: {3} d/Km, phi cau duong trong chuyen di qui khach vui long thanh toan. Chuc quy khach thuong lo binh an!",cboLoaiXe.Text, txtKm.Text, txtGia.Text, _giaPhuTroi);
            }            
        }

        private bool CheckValidate()
        {
            if (cboChayTuyen.EditValue == null||cboChayTuyen.EditValue.To<int>()==0)
            {
                new MessageBox.MessageBoxBA().Show("Bạn chưa chọn tuyến đường!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                cboChayTuyen.Focus();
                return false;
            }
            if (cboLoaiXe.EditValue == null || cboLoaiXe.EditValue.To<int>()==0)
            {
                new MessageBox.MessageBoxBA().Show("Bạn chưa chọn loại xe!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboLoaiXe.Focus();
                return false;
            }            
            if (string.IsNullOrEmpty(txtGia.Text))
            {
                new MessageBox.MessageBoxBA().Show("Bạn chưa nhập giá tiền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGia.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtKm.Text))
            {
                new MessageBox.MessageBoxBA().Show("Bạn chưa nhập số Km!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKm.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtThoiGian.Text))
            {
                new MessageBox.MessageBoxBA().Show("Bạn chưa nhập số giờ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtThoiGian.Focus();
                return false;
            }
            return true;
        }
        
        private void LoadAllTextBox()
        {
            try
            {
                if(_isLoading)return;
                if (cboChayTuyen.EditValue != null && cboChieu.EditValue != null && cboLoaiXe.EditValue != null)
                {
                    DataTable data= new BangGiaCuoc().LayGiaTheoTuyen((string) cboChayTuyen.EditValue,(int)cboChieu.EditValue,(int)cboLoaiXe.EditValue,1);
                    if (data.Rows.Count > 0)
                    {
                        txtGia.Text = data.Rows[0]["GiaTien"].ToString();
                        txtKm.Text = data.Rows[0]["Km"].ToString();
                        txtThoiGian.Text = data.Rows[0]["ThoiGian"].ToString();
                    }
                    else
                    {
                        txtGia.Text = string.Empty;
                        txtKm.Text = string.Empty;
                        txtThoiGian.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {                
                LogError.WriteLogError("LoadAllTextBox: " ,ex);
            }
        }

        #endregion
    }
}
