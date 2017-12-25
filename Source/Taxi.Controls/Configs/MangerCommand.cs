using System.Linq;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Data.BanCo.Entity.DM;
using Taxi.Utils;
using Taxi.Utils.Enums;

namespace Taxi.Controls.Configs
{
    /// <summary>
    /// Quản lý xử lý tập lệnh cấu hình
    /// </summary>
    /// <Modified>
    /// Name     Date         Comments
    /// HauNV  24/08/2015   created
    /// </Modified>
    public class MangerCommand
    {

        #region ===== Command =====
        /// <summary>
        /// Processes the command by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="cuocgoi">The cuocgoi.</param>
        /// <param name="IsCapNhat">if set to <c>true</c> [is cap nhat].</param>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  24/08/2015   created
        /// </Modified>
        //public static void ProcessCommandByKey(Keys key,ref CuocGoi cuocgoi, ref bool IsCapNhat)
        //{
        //    var cmd= CommonBL.Commands.FirstOrDefault(p => (Keys)p.Shortcuts == key);
        //    if (cmd != null)
        //    {
        //        if (cmd.FunctionUsing == (int)Enum_ChucNangNhiemVu.DienThoaiVien)
        //        {
        //            cuocgoi.LenhDienThoai = cmd.Command;
        //            cuocgoi.TrangThaiLenh = (TrangThaiLenhTaxi)cmd.Status;
        //            if (cmd.CallStatus > 0)
        //            {
        //                cuocgoi.TrangThaiCuocGoi = (TrangThaiCuocGoiTaxi)cmd.CallStatus;
        //            }
        //            IsCapNhat = true;
        //        }
        //        else if (cmd.FunctionUsing == (int)Enum_ChucNangNhiemVu.TongDaiVien)
        //        {
        //            cuocgoi.LenhTongDai = cmd.Command;
        //            cuocgoi.TrangThaiLenh = (TrangThaiLenhTaxi)cmd.Status;
        //            if (cmd.CallStatus > 0)
        //            {
        //                cuocgoi.TrangThaiCuocGoi = (TrangThaiCuocGoiTaxi)cmd.CallStatus;
        //            }
        //            IsCapNhat = true;
        //        }
        //        if (IsCapNhat && (Enum_SendDriver)cmd.SendDriver != Enum_SendDriver.None)
        //        {
        //            SendDriver((Enum_SendDriver)cmd.SendDriver, cuocgoi);
        //        }
        //    }
        //}


        /// <summary>
        /// Sends the driver.
        /// </summary>
        /// <param name="sendDriver">The send driver.</param>
        /// <param name="cuocgoi">The cuocgoi.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  24/08/2015   created
        /// </Modified>
        //public static void SendDriver(Enum_SendDriver sendDriver, CuocGoi cuocgoi)
        //{
        //    switch (sendDriver)
        //    {
        //        case Enum_SendDriver.InitTrip://Tạo cuốc mới
        //            break;
        //        case Enum_SendDriver.ACKInvite: // Mời khách                    
        //            break;
        //        case Enum_SendDriver.ACKGetPhone: //lấy sdt.
        //            break;
        //        case Enum_SendDriver.LogoutDriver: // Ép lái xe đăng xuất.
        //            break;
        //    }
        //}
        #endregion

        #region ===== Mobile Command ====
        /// <summary>
        /// Processes the mobile command by key.
        /// Thực hiện lệnh theo cấu hình.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="cuocgoi">The cuocgoi.</param>
        /// <param name="IsSend">if set to <c>true</c> [is send].</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  07/09/2015   created
        /// </Modified>
        public static bool ProcessMobileCommandByKey(Keys key, ref CuocGoi cuocgoi, ref bool IsSend)
        {
          
            int KeyValue=(int)key ;
            if (KeyValue >= ((int)Keys.NumPad0) && KeyValue <= ((int)Keys.NumPad9))
            { // numpad
                KeyValue = KeyValue - ((int)Keys.NumPad0) + ((int)Keys.D0);
            }           
            var cmd = CommonBL.MobileCommand.FirstOrDefault(p => p.PMDH_Shortcuts == KeyValue);
            if (cmd != null)
            {
                if (cmd.PMDH_RequireVehicle)
                {
                    if (!(CheckVehicle(cuocgoi.XeNhan)))
                    {
                        return true;
                    }
                }
                cuocgoi.TrangThaiLenh = (TrangThaiLenhTaxi)cmd.PMDH_Status;
                if (cmd.PMDH_CallStatus > 0)
                {
                    cuocgoi.TrangThaiCuocGoi = (TrangThaiCuocGoiTaxi)cmd.PMDH_CallStatus;
                }
                if (CommonBL.WorkflowId == (int)Enum_Workflow.DienThoaiVien)
                {
                    cuocgoi.LenhDienThoai = cmd.CommandName;
                } 
                else if (CommonBL.WorkflowId == (int)Enum_Workflow.TongDaiVien)
                {
                    cuocgoi.LenhTongDai = cmd.CommandName;
                }
                if (IsSend && (Enum_SendDriver)cmd.PMDH_SendDriver != Enum_SendDriver.None)
                {
                    //MobileCommandSendDriver((Enum_SendDriver)cmd.PMDH_SendDriver, cuocgoi);
                } 
                return true;
            }
            return false;            
            
        }
        /// <summary>
        /// Processes the mobile command format.
        /// Thay đổi màu nền màu chữ theo cấu hình.
        /// </summary>
        /// <param name="cg">The cg.</param>
        /// <param name="row">The row.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  10/09/2015   created
        /// </Modified>
        //public static void ProcessMobileCommandFormat(CuocGoi cg, GridEXRow row)
        //{
        //    try
        //    {
        //        var cmdDienThoai = CommonBL.MobileCommandAll.FirstOrDefault(p => p.CommandName == cg.LenhDienThoai && p.FK_WorkflowID == (int)Enum_Workflow.DienThoaiVien);
        //        if (cmdDienThoai != null)
        //        {
        //            GridEXFormatStyle rowStyle = new GridEXFormatStyle();
        //            rowStyle.BackColor = Color.FromArgb(cmdDienThoai.BackgroundColor);
        //            rowStyle.ForeColor = Color.FromArgb(cmdDienThoai.ForeColor);
        //            row.Cells["LenhDienThoai"].FormatStyle = rowStyle;
        //        }

        //        var cmdTongDai = CommonBL.MobileCommandAll.FirstOrDefault(p => p.CommandName == cg.LenhTongDai && p.FK_WorkflowID == (int)Enum_Workflow.TongDaiVien);
        //        if (cmdTongDai != null)
        //        {
        //            GridEXFormatStyle rowStyle = new GridEXFormatStyle();
        //            rowStyle.BackColor = Color.FromArgb(cmdTongDai.BackgroundColor);
        //            rowStyle.ForeColor = Color.FromArgb(cmdTongDai.ForeColor);
        //            row.Cells["LenhTongDai"].FormatStyle = rowStyle;
        //        }
        //        var cmdLaiXe = CommonBL.MobileCommandAll.FirstOrDefault(p => p.CommandName == cg.MH_LenhLaiXe && p.FK_WorkflowID == (int)Enum_Workflow.Mobile);
        //        if (cmdLaiXe != null)
        //        {
        //            GridEXFormatStyle rowStyle = new GridEXFormatStyle();
        //            rowStyle.BackColor = Color.FromArgb(cmdLaiXe.BackgroundColor);
        //            rowStyle.ForeColor = Color.FromArgb(cmdLaiXe.ForeColor);
        //            row.Cells["MH_LenhLaiXe"].FormatStyle = rowStyle;
        //        }  
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError.WriteLogError("ProcessMobileCommandFormat", ex);
        //    }
            
        //}
        //public static void MobileCommandSendDriver(Enum_SendDriver sendDriver, CuocGoi cuocgoi)
        //{
        //    switch (sendDriver)
        //    {
        //        case Enum_SendDriver.InitTrip://Tạo cuốc mới
        //            break;
        //        case Enum_SendDriver.ACKInvite: // Mời khách                    
        //            break;
        //        case Enum_SendDriver.ACKGetPhone: //lấy sdt.
        //            break;
        //        case Enum_SendDriver.LogoutDriver: // Ép lái xe đăng xuất.
        //            break;
        //    }
        //}
        /// <summary>
        /// Checks the vehicle.
        /// Kiểm tra tồn tại xe nhận
        /// </summary>
        /// <param name="Vehicle">The vehicle.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  07/09/2015   created
        /// </Modified>
        public static bool CheckVehicle(string Vehicle)
        {
            if(string.IsNullOrEmpty(Vehicle)||Vehicle.Trim()=="")
            {
                new MessageBox.MessageBoxBA().Show("Bạn chưa nhập xe nhận.");
                return false;
            }
            var vl=DMXe.Inst.CheckVehicle(Vehicle);
            if (vl != string.Empty)
            {
                new MessageBox.MessageBoxBA().Show("Xe " + vl + " không tồn tại trong hệ thống.");
                return false;
            }
            return true;
        }
        #endregion
    }
}
