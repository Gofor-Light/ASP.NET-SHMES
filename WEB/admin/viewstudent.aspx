<%@ Page Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="viewstudent.aspx.cs"
    Inherits="admin_viewstudent" Title="查看学生页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <p>
            学生详细信息</p>
    </div>
    <div>
        <span>账号</span><asp:Label ID="lbl1" runat="server" Text="Label" CssClass="lbl"></asp:Label>
        <span>密码</span><asp:Label ID="lbl2" runat="server" Text="Label" CssClass="lbl"></asp:Label>
    </div>
    <div>
        <span>姓名</span><asp:TextBox ID="txt1" runat="server" CssClass="txt" ReadOnly="True"></asp:TextBox>
        <span>学院</span><asp:DropDownList ID="DropDownList2" CssClass="lbl " runat="server"
            Enabled="False">
        </asp:DropDownList>
        <span>专业</span><asp:TextBox ID="txt2" runat="server" CssClass="txt" ReadOnly="True"></asp:TextBox>
    </div>
    <div>
        <span>性别</span><asp:DropDownList ID="DropDownList1" CssClass="lbl " runat="server"
            Enabled="False">
            <asp:ListItem Selected="True">男</asp:ListItem>
            <asp:ListItem>女</asp:ListItem>
        </asp:DropDownList>
        <span>手机</span><asp:TextBox ID="txt3" runat="server" CssClass="txt" ReadOnly="True"></asp:TextBox>
        <span>邮箱</span><asp:TextBox ID="txt4" runat="server" CssClass="txt" ReadOnly="True"></asp:TextBox>
    </div>
    <div class="bt1">
        <asp:Button ID="btn1" runat="server" Text="修改信息" Width="65px" OnClick="Button1_Click" />
        <asp:Button ID="btn3" runat="server" Text="确定" Width="77px" ValidationGroup="mes"
            OnClick="btn3_Click" Enabled="False" />
    </div>
</asp:Content>
