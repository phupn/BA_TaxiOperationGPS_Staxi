<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatXe.aspx.cs" Inherits="TaxiOperation_WebTest.DatXe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 215px;
        }
        .auto-style2 {
            width: 215px;
            height: 40px;
        }
        .auto-style3 {
            width: 215px;
            height: 42px;
        }
        .auto-style6 {
            text-align: center;
        }
        .auto-style7 {
        }
        .auto-style8 {
            width: 180px;
            height: 26px;
        }
        .auto-style9 {
            width: 215px;
            height: 26px;
        }
        .auto-style10 {
            height: 23px;
        }
    </style>
    <link rel="stylesheet" href="http://localhost:62324/code.jquery.com/ui/1.11.3/themes/smoothness/jquery-ui.css"/>
    <link rel="stylesheet" type="text/css" href="/Scripts/jquery.datetimepicker.css"/>
  <script src="//code.jquery.com/jquery-1.10.2.js"></script>
  <script src="//code.jquery.com/ui/1.11.3/jquery-ui.js"></script>
    <script src="/Scripts/jquery.mask.js"></script>
    <script src="/Scripts/jquery.datetimepicker.js"></script>
   
 
    <script>
        $(function () {
            $("#txtGioDon").datetimepicker();
            $('#txtGioDon').mask('0000/00/00 00:00');
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="text-align: center"> <h2>Form Đặt xe</h2></div>
    <table align="center" style="height: 304px; width: 701px">
        <tr>
            <td class="auto-style7">Tên khách hàng</td> <td class="auto-style2">
            <asp:TextBox ID="txtTenKhachHang" runat="server" Width="397px" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
             <td class="auto-style7">Địa chỉ đón</td> <td class="auto-style3">
             <asp:TextBox ID="txtDiaChiDon" runat="server" Width="397px" MaxLength="100"></asp:TextBox>
             </td>
        </tr>
        <tr>
            <td class="auto-style7">Địa chỉ trả khách</td> <td class="auto-style3">
            <asp:TextBox ID="txtDiaChiTraKhach" runat="server" Width="397px" MaxLength="100"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Số điện thoại</td> <td class="auto-style1">
            <asp:TextBox ID="txtSoDienThoai" runat="server" Width="397px" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">Email</td> <td class="auto-style9">
            <asp:TextBox ID="txtEmail" runat="server" Width="397px" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">Giờ đón</td> <td class="auto-style9">
            <asp:TextBox ID="txtGioDon" runat="server" Width="397px"  data-mask="00/00/0000"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">Ghi chú</td> <td class="auto-style9">
            <asp:TextBox ID="txtGhiChu" runat="server" Width="397px" Height="97px" MaxLength="256" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Loại xe</td> <td class="auto-style1">
            <asp:TextBox ID="txtLoaiXe" runat="server" Width="397px" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Số lượng xe</td> <td class="auto-style1">
            <asp:TextBox ID="txtSoLuong" runat="server" Width="397px" MaxLength="2"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10" colspan="2">
                <asp:Label ID="lblMsg" runat="server" style="text-align: center"></asp:Label>
            </td> 
        </tr>
        <tr>
            <td class="auto-style6" colspan="2">
                <asp:Button ID="btnDatXe" runat="server" Text="Đặt xe" OnClick="btnDatXe_Click" />
&nbsp;&nbsp;
                <asp:Button ID="btnDatXe0" runat="server" Text="Làm mới" />
            </td> 
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
