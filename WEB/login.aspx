<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学生作业互评系统</title>
    <link href="css/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="login">
        <div id="type">
            <asp:Label ID="lbl1" runat="server" Text="用户类型" CssClass="lb" Width="68px"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="120px">
                <asp:ListItem Value="admin">管理员</asp:ListItem>
                <asp:ListItem Value="teacher">教师</asp:ListItem>
                <asp:ListItem Selected="True" Value="student">学生</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="row">
            <asp:Label ID="lbl2" runat="server" Text="账号" CssClass="lb" Width="68px"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" Height="18px" Width="117px"></asp:TextBox>
        </div>
        <div class="row">
            <asp:Label ID="lbl3" runat="server" Text="密码" CssClass="lb" Width="68px"></asp:Label>
            <asp:TextBox ID="txtPwd" runat="server" Height="18px" Width="117px" 
                TextMode="Password"></asp:TextBox>
        </div>
        <div id="go">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/go.jpg" OnClick="ImageButton1_Click" />
        </div>
    </div>
    </form>
</body>
</html>
