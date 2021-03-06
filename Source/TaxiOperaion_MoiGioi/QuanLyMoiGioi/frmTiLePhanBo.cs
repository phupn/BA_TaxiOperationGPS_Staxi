using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Business.DM;

namespace Taxi.GUI
{
    public partial class frmTiLePhanBo : Form
    {
        private bool mIsAdd = true;        

        public frmTiLePhanBo()
        {
            InitializeComponent();
        }

        private void frmTiLePhanBo_Load(object sender, EventArgs e)
        {
            DataTable dt = new BangKe().GetTiLePhanBo();
            if (dt.Rows.Count > 0)
            {
                SetTiLePhanBo(dt);
                mIsAdd = false;
            }
            else
            {
                mIsAdd = true;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                if (mIsAdd)
                {
                    if (new BangKe().Insert_TyLePhanBo(GetTiLePhanBo()))
                    {
                        new MessageBox.MessageBox().Show("Thêm tỉ lệ phân bổ thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);                        
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        new MessageBox.MessageBox().Show("Lỗi thêm tỉ lệ phân bổ", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (new BangKe().Update_TyLePhanBo(GetTiLePhanBo()))
                    {
                        new MessageBox.MessageBox().Show("Cập nhật tỉ lệ phân bổ thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);                        
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        new MessageBox.MessageBox().Show("Lỗi cập nhật tỉ lệ phân bổ", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private DataTable GetTiLePhanBo()
        {
            DataTable dtTiLePhanBo = new DataTable();
            dtTiLePhanBo.Columns.Add("FK_CongTyID", typeof(int));
            dtTiLePhanBo.Columns.Add("TiLePhanBo", typeof(double));

            dtTiLePhanBo.Rows.Add(1, Convert.ToDouble(txt3A.Text.ToString()));
            dtTiLePhanBo.Rows.Add(2, Convert.ToDouble(txtCP.Text.ToString()));
            dtTiLePhanBo.Rows.Add(3, Convert.ToDouble(txtHN.Text.ToString()));
            dtTiLePhanBo.Rows.Add(4, Convert.ToDouble(txtJAC.Text.ToString()));
            dtTiLePhanBo.Rows.Add(5, Convert.ToDouble(txtTOU.Text.ToString()));

            return dtTiLePhanBo;
        }

        private void SetTiLePhanBo(DataTable dtTiLePhanBo)
        {
            txtHN.Text = dtTiLePhanBo.Rows[0]["TiLePhanBo"].ToString(); 
            txtCP.Text = dtTiLePhanBo.Rows[1]["TiLePhanBo"].ToString();
            txtTOU.Text = dtTiLePhanBo.Rows[2]["TiLePhanBo"].ToString();
            txt3A.Text = dtTiLePhanBo.Rows[3]["TiLePhanBo"].ToString();
            txtJAC.Text = dtTiLePhanBo.Rows[4]["TiLePhanBo"].ToString();
        }

        private bool validate()
        {
            if (isDoubleRequired(txt3A,"Taxi 3A") == false ||
                isDoubleRequired(txtCP, "Taxi CP") == false ||
                isDoubleRequired(txtHN, "Taxi HN") == false ||
                isDoubleRequired(txtJAC, "Taxi JAC") == false ||
                isDoubleRequired(txtTOU, "Taxi Tourist") == false)
            {
                return false;
            }
            else
            {
                double AAA = Convert.ToDouble(txt3A.Text.ToString());
                double CP = Convert.ToDouble(txtCP.Text.ToString());
                double HN = Convert.ToDouble(txtHN.Text.ToString());
                double JAC = Convert.ToDouble(txtJAC.Text.ToString());
                double TOU = Convert.ToDouble(txtTOU.Text.ToString());
                if(!(AAA + CP + HN + JAC + TOU == 100))
                {
                    new MessageBox.MessageBox().Show("Tỉ lệ phân bổ không hợp lệ. Tổng phải bằng 100", "Thông báo",
                        Taxi.MessageBox.MessageBoxButtons.OK,
                        Taxi.MessageBox.MessageBoxIcon.Error);
                    return false;
                }

            }
            return true;
        }

        private bool isDoubleRequired(Janus.Windows.GridEX.EditControls.EditBox editBox, string editBoxName)
        {
            double dOutput = 0;
            string value = editBox.Text.Trim();
            if (string.IsNullOrEmpty(value))
            {
                new MessageBox.MessageBox().Show("Vui lòng nhập tỉ lệ phân bổ cho " + editBoxName, "Thông báo",
                    Taxi.MessageBox.MessageBoxButtons.OK,
                    Taxi.MessageBox.MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (!Double.TryParse(value, out dOutput))
                {
                    new MessageBox.MessageBox().Show(editBoxName + " không hợp lệ", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtons.OK,
                    Taxi.MessageBox.MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
    }
}