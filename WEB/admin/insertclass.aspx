<%@ Page Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="insertclass.aspx.cs"
    Inherits="admin_insertclass" Title="新增课程页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <p>新增课程</p>
    </div>
    <div>
        <span>课程名</span><asp:TextBox ID="txt1" runat="server" CssClass="txt"></asp:TextBox>
        <span>学期</span><asp:DropDownList ID="DropDownList1" CssClass="lbl " runat="server">
        </asp:DropDownList>
    </div>
    <div>
        <span>开课学院</span><asp:DropDownList ID="DropDownList2" CssClass="lbl " runat="server"
            AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
        </asp:DropDownList>
        <span>任课老师</span><asp:DropDownList ID="DropDownList3" CssClass="lbl " 
            runat="server" onselectedindexchanged="DropDownList3_SelectedIndexChanged" 
            AutoPostBack="True">
        </asp:DropDownList>
        <span>教师ID</span><asp:Label ID="lbl1" runat="server" CssClass ="lbl " Text="Label"></asp:Label>
    </div>
    <div class="wrong1 ">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="班级名不能为空"
            ControlToValidate="txt1" Display="None"></asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    <div class="bt1">
        <asp:Button ID="Button1" runat="server" Text="确定" Width="65px" 
            OnClick="Button1_Click" />
    </div>
</asp:Content>
