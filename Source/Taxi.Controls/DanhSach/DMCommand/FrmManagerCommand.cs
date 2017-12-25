using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Controls.Base;
using Taxi.Controls.Base.Common.Enums.RepositoryItemLookUpEdit;
using Taxi.Data.G5.DanhMuc;
using Taxi.Controls.Base.Extender;
using Taxi.Controls.Base.Common.RepositoryItems;
namespace Taxi.Controls.DanhSach.DMCommand
{
    public partial class FrmManagerCommand : FormManager
    {
        private List<G5Command> _lstCommand;
        private bool IsChangeOrder;
        public FrmManagerCommand()
        {
            InitializeComponent();
            panelButton.Size = new Size(483, 31);
        }
        public override object GetData()
        {
            _lstCommand = G5Command.GetAllToList().OrderBy(x=>x.OrderBy).ToList();
            return _lstCommand;
        }
        public override Taxi.Common.DbBase.ModelBase ModelCurrent
        {
            get
            {
                return grvCommand.GetFocusedRow() as G5Command;
            }
        }
        public override FormUpdate FormUpdate
        {
            get
            {
                return new FrmUpdateCommand();
            }
        }
        private void FrmManagerCommand_FormClosed(object sender, FormClosedEventArgs e)
        {
            RealTimeEnvironment.ResetCommand();
            if (IsChangeOrder)
            {
                this.DialogResult = DialogResult.Yes;
            }
        }
        public override void AfterLoad()
        {
            grvCommand.Add<RepositoryItemLookUpEdit_TrangThaiCG>("CallStatus");
            grvCommand.Add<RepositoryItemLookUpEdit_TrangThaiLenh>("Status");
            grvCommand.Add<RepositoryItemLookUpEdit_PhimTat>("Shortcuts");
            grvCommand.Add<RepositoryItemLookUpEdit_KieuCuocGoi>("CallType");
            grvCommand.Add<RepositoryItemLookUpEdit_ServerFunction>("CmdServer");
            grvCommand.Add<RepositoryItemLookUpEdit_Bool>("IsColorRow", "IsColorAll", "RequireTaxi", "RequireApp", "RequireVehicle", "RequireVehicleCancel", "IsRequited");
            grvCommand.Add<RepositoryItem_G5CommandCmd>("CmdId");
        }

        #region === Change order command ===
        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = grvCommand.FocusedRowHandle;
                if (rowIndex == 0)
                {
                    return;
                }
                var item = grvCommand.GetFocusedRow() as G5Command;
                _lstCommand.Remove(item);
                _lstCommand.Insert(rowIndex - 1, item);
                grvCommand.RefreshData();
                grvCommand.FocusedRowHandle = rowIndex - 1;
                IsChangeOrder = true;
            }
            catch (Exception)
            {
                IsChangeOrder = false;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = grvCommand.FocusedRowHandle;
                if (rowIndex == grvCommand.RowCount-1)
                {
                    return;
                }
                var item = grvCommand.GetFocusedRow() as G5Command;
                _lstCommand.Remove(item);
                _lstCommand.Insert(rowIndex + 1, item);
                grvCommand.RefreshData();
                grvCommand.FocusedRowHandle = rowIndex + 1;
                IsChangeOrder = true;
            }
            catch (Exception)
            {
                IsChangeOrder = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panOrder.Visible = false;
            btnLamMoi.PerformClick();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (grvCommand.RowCount>0)
            {
                panOrder.Visible = !panOrder.Visible;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveOrderCommand();
        }
        private void FrmManagerCommand_Resize(object sender, EventArgs e)
        {
            panbuttonChangeOrder.Location = new Point((this.Width- panbuttonChangeOrder.Width)/2, panOrder.Top);
        }
        protected override void Delete()
        {
            base.Delete();
            SaveOrderCommand();
        }
        private void SaveOrderCommand()
        {
            for (int i = 0; i < _lstCommand.Count; i++)
            {
                if (_lstCommand[i].OrderBy != i + 1)
                {
                    _lstCommand[i].OrderBy = i + 1;
                    _lstCommand[i].Save();
                }
            }
            btnLamMoi.PerformClick();
            panOrder.Visible = false;
        }
        #endregion
    }
}
