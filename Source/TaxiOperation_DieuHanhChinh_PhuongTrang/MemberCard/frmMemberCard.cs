using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.DM;
using Janus.Windows.GridEX;

namespace DieuHanhChinh.DM
{
    public partial class frmMemberCard : Form
    {
        #region Properties
        private List<MemberCard> G_ListMemberCard = new List<MemberCard>();
        private MemberCard G_MemberCard = new MemberCard();
        /// <summary>
        /// 1 : Addnew
        /// 2 : Update
        /// 0 : Search
        /// </summary>
        private int G_Status = 1;
        #endregion
        
        #region FormLoad
        public frmMemberCard()
        {
            InitializeComponent();
        }

        private void frmMemberCard_Load(object sender, EventArgs e)
        {
            LoadData();
            RefreshForm();
        }

        private void LoadData()
        {
            G_ListMemberCard = MemberCard.GetAllMemberCard();
            SetDataSource();
        }

        /// <summary>
        /// fill data to gridview
        /// </summary>
        private void SetDataSource()
        {
            gridEX.DataMember = "ListMemberCard";
            gridEX.SetDataBinding(G_ListMemberCard, "ListMemberCard");
        }

        /// <summary>
        /// Làm mới form
        /// </summary>
        private void RefreshForm()
        {
            txtCode.Focus();
            cbType.SelectedIndex = 0;
            lblError.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtCode.Text = "";
            txtNote.Text = "";
            chkActive.Checked = false;
            txtCode.Enabled = true;
            G_MemberCard = null;
            txtAddress.BackColor = Color.White;
            txtCode.BackColor = Color.White;
            txtName.BackColor = Color.White;
            btnSave.Text = "Lưu";
            G_Status = 1;
        }

        /// <summary>
        /// Lay dữ liệu chọn từ lưới.
        /// </summary>
        private void FillDataToForm()
        {
            if (G_MemberCard != null)
            {
                cbType.Text = G_MemberCard.Type;
                txtName.Text = G_MemberCard.Name;
                txtAddress.Text = G_MemberCard.Address;
                txtCode.Text = G_MemberCard.Code;
                txtNote.Text = G_MemberCard.Note;
                date_DateOfIssue.Value = G_MemberCard.DateOfIssue;
                date_ExpireDate.Value = G_MemberCard.ExpireDate;
                chkActive.Checked = G_MemberCard.Active;
                txtCode.Enabled = false;
                G_Status = 2;
            }            
        }

        /// <summary>
        /// CHuyển sang chế độ tìm kiếm
        /// </summary>
        private void FindForm()
        {
            txtAddress.BackColor = Color.Yellow;
            txtCode.BackColor = Color.Yellow;
            txtName.BackColor = Color.Yellow;
            txtCode.Enabled = true;
            btnSave.Text = "Tìm kiếm";
            G_Status = 0;            
        }
        #endregion

        #region Validate
        private bool DoValidate()
        {
            if (G_MemberCard == null)
                G_MemberCard = new MemberCard();
            lblError.Text = "";
            G_MemberCard.Name = txtName.Text.Trim();
            G_MemberCard.Address = txtAddress.Text.Trim();
            G_MemberCard.Type = cbType.Text;
            G_MemberCard.Note = txtNote.Text.Trim();
            G_MemberCard.DateOfIssue = date_DateOfIssue.Value;
            G_MemberCard.ExpireDate = date_ExpireDate.Value;
            G_MemberCard.Active = chkActive.Checked;
            G_MemberCard.Code = txtCode.Text.Trim();
            if (string.IsNullOrEmpty(G_MemberCard.Code))
            {
                lblError.Text = "Vui lòng chọn mã thẻ";
                return false;
            }
            else if (string.IsNullOrEmpty(G_MemberCard.Name))
            {
                lblError.Text = "Vui lòng nhập tên chủ thẻ";
                return false;
            }
            else if (string.IsNullOrEmpty(G_MemberCard.Type))
            {
                lblError.Text = "Vui lòng chọn loại thẻ";
                return false;
            }
            
            return true;
        }
        #endregion

        #region Form Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (G_Status == 0)
            {
                G_ListMemberCard = MemberCard.GetAllMemberCard_BySearch(txtCode.Text.Trim(), txtName.Text.Trim(), txtAddress.Text.Trim());
                SetDataSource();
                RefreshForm();
            }
            else
            {
                if (DoValidate())
                {
                    if (G_MemberCard.ID > 0)
                    {
                        if (G_MemberCard.Update())
                        {
                            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            RefreshForm();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (G_MemberCard.Insert() > 0)
                        {
                            MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            RefreshForm();
                        }
                        else
                        {
                            MessageBox.Show("Thêm mới thất bại", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (G_MemberCard.Delete())
            {
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa thất bại", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
            RefreshForm();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                FindForm();
                return true;
            }
            else if (keyData == (Keys.Escape))
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region Grid Events
        private void gridEX1_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {

        }
        #endregion        

        private void gridEX_SelectionChanged(object sender, EventArgs e)
        {
            if (gridEX.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)gridEX.SelectedItems[0]).GetRow();
                G_MemberCard = (MemberCard)((GridEXSelectedItem)gridEX.SelectedItems[0]).GetRow().DataRow;
                FillDataToForm();
            }
        }
    }
}