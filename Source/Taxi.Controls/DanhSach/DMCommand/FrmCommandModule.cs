using Taxi.Controls.Base;
using Taxi.Data.G5.DanhMuc;
using Taxi.Common.Extender;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using Taxi.Business;

namespace Taxi.Controls.DanhSach.DMCommand
{
    public partial class FrmCommandModule : FormBase
    {
        private List<CommandModule> _lstCmdByModule;
        private bool _IsSaveOrder = true;
        public bool IsChangeCommand = false;

        #region===Form events===
        public FrmCommandModule()
        {
            InitializeComponent();
        }
        private void FrmCommandModule_Load(object sender, EventArgs e)
        {
            lookupEdit_EnumCommand_Module1.Bind();
            btnLuu.Visible = false;
        }
        private void FrmCommandModule_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_IsSaveOrder)
            {
                MessageBox.MessageBoxBA msg = new MessageBox.MessageBoxBA();
                string res = msg.Show(this, "Bạn có muốn lưu lại thứ tự các lệnh không?", "Thông báo", MessageBox.MessageBoxButtonsBA.YesNo, MessageBox.MessageBoxIconBA.Question);
                if (res == "Yes")
                {
                    UpdateOrderBy();
                }
            }
        }

        #endregion

        #region=== Control events===
        private void btnToRight_Click(object sender, System.EventArgs e)
        {
            try
            {
                var lst = lstCommandNotUse.SelectedItems;
                if (lst.Count > 0)
                {
                    int moduleId = (int)lookupEdit_EnumCommand_Module1.GetValue();
                    string id = "";
                    foreach (G5Command item in lst)
                    {
                        id += item.Id + ";";
                    }
                    CommandModule.Inst.AddCommand(id, moduleId);
                    GetCommandByModule(moduleId);
                    IsChangeCommand = true;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError(" btnToRight_Click", ex);
            }
        }

        private void btnToLeft_Click(object sender, System.EventArgs e)
        {
            if (lstBoxUsed.SelectedIndex >= 0)
            {
                try
                {
                    var lst = lstBoxUsed.SelectedItems;
                    if (lst.Count > 0)
                    {
                        int moduleId = (int)lookupEdit_EnumCommand_Module1.GetValue();
                        string id = "";
                        foreach (CommandModule item in lst)
                        {
                            id += item.Id + ";";
                        }
                        CommandModule.Inst.DeleteCommand(id, moduleId);
                        GetCommandByModule(moduleId);
                        IsChangeCommand = true;
                    }
                }
                catch (Exception ex)
                {
                    LogError.WriteLogError(" btnToLeft_Click", ex);
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                lstBoxUsed.SelectionMode = SelectionMode.One;
                int rowIndex = lstBoxUsed.SelectedIndex;
                if (rowIndex == 0)
                {
                    return;
                }
                CommandModule item = lstBoxUsed.GetItem(rowIndex) as CommandModule;
                _lstCmdByModule.Remove(item);
                _lstCmdByModule.Insert(rowIndex - 1, item);
                lstBoxUsed.Refresh();
                lstBoxUsed.SelectedIndex = rowIndex - 1;
                btnLuu.Visible = true;
                _IsSaveOrder = false;
                lstBoxUsed.SelectionMode = SelectionMode.MultiExtended;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError(" btnUp_Click", ex);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                lstBoxUsed.SelectionMode = SelectionMode.One;
                int rowIndex = lstBoxUsed.SelectedIndex;
                if (rowIndex == lstBoxUsed.ItemCount - 1)
                {
                    return;
                }
                CommandModule item = lstBoxUsed.GetItem(rowIndex) as CommandModule;
                _lstCmdByModule.Remove(item);
                _lstCmdByModule.Insert(rowIndex + 1, item);
                lstBoxUsed.Refresh();
                lstBoxUsed.SelectedIndex = rowIndex + 1;
                btnLuu.Visible = true;
                _IsSaveOrder = false;
                lstBoxUsed.SelectionMode = SelectionMode.MultiExtended;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError(" btnDown_Click", ex);
            }
        }
        private void lookupEdit_EnumCommand_Module1_EditValueChanged(object sender, System.EventArgs e)
        {
            btnLuu.Visible = !btnLuu.Visible;
            int moduleId = (int)lookupEdit_EnumCommand_Module1.GetValue();
            GetCommandByModule(moduleId);
            if (lstBoxUsed.ItemCount <= 0)
            {
                btnDown.Visible = false;
                btnUp.Visible = false;
            }
            else
            {
                btnDown.Visible = true;
                btnUp.Visible = true;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            UpdateOrderBy();
            btnLuu.Visible = false;
        }
        #endregion

        #region=== Method ===

        /// <summary>
        /// Lấy danh sách lệnh theo module
        /// </summary>
        /// <param name="moduleId"></param>
        private void GetCommandByModule(int moduleId)
        {
            _lstCmdByModule = CommandModule.Inst.GetCommandByModule(moduleId);
            lstBoxUsed.DataSource = _lstCmdByModule;
            if (_lstCmdByModule!=null && _lstCmdByModule.Count>1)
            {
                btnUp.Visible = true;
                btnDown.Visible = true;
            }
            else
            {
                btnUp.Visible = false;
                btnDown.Visible = false;
            }
            lstCommandNotUse.DataSource = G5Command.Inst.GetCommandNotUse(moduleId);
        }
        /// <summary>
        /// Cập nhật lại orderby của các command sau khi xóa hoặc sắp xếp
        /// </summary>
        private void UpdateOrderBy()
        {
            for (int i = 0; i < _lstCmdByModule.Count; i++)
            {
                if (_lstCmdByModule[i].OrderBy != i + 1)
                {
                    _lstCmdByModule[i].OrderBy = i + 1;
                    _lstCmdByModule[i].Save();
                }
            }
            _IsSaveOrder = true;
            IsChangeCommand = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData ==(Keys.Control| Keys.A))
            {
                if (lstBoxUsed.Focused)
                {
                    lstBoxUsed.SelectAll();
                    lstCommandNotUse.UnSelectAll();
                }
                else if (lstCommandNotUse.Focused)
                {
                    lstCommandNotUse.SelectAll();
                    lstBoxUsed.UnSelectAll();
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

    }
}
