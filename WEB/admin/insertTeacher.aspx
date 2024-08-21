<%@ Page Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="insertTeacher.aspx.cs"
    Inherits="admin_insertTeacher" Title="新增教师页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <p>新增教师</p>
    </div>
    <div>
        <span>账号</span><asp:TextBox ID="txt1" runat="server" CssClass="txt"></asp:TextBox>
        <span>姓名</span><asp:TextBox ID="txt2" runat="server" CssClass="txt"></asp:TextBox>
        <span>手机</span><asp:TextBox ID="txt3" runat="server" CssClass="txt"></asp:TextBox>
    </div>
    <div>
        <span>职称</span><asp:DropDownList ID="DropDownList1" CssClass="lbl " runat="server">
            <asp:ListItem Selected="True">教授</asp:ListItem>
            <asp:ListItem>副教授</asp:ListItem>
            <asp:ListItem>讲师</asp:ListItem>
            <asp:ListItem>助教</asp:ListItem>
        </asp:DropDownList>
        <span>学院</span><asp:DropDownList ID="DropDownList2" CssClass="lbl " runat="server">
        </asp:DropDownList>
        <span>邮箱</span><asp:TextBox ID="txt4" runat="server" CssClass="txt"></asp:TextBox>
    </div>
    <div class="wrong1 ">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="账号不能为空"
            ControlToValidate="txt1" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="姓名不能为空"
            ControlToValidate="txt2" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="手机不能为空"
            ControlToValidate="txt3" Display="None"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator1" runat="server" 
            ControlToValidate="txt1" Display="None" ErrorMessage="注册失败,此账号已被注册过了" 
            onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    <div class ="bt1">
        <asp:Button ID="Button1" runat="server" Text="确定" onclick="Button1_Click" 
            Width="65px" />
    </div>
</asp:Content>
