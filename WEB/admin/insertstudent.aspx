<%@ Page Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="insertstudent.aspx.cs"
    Inherits="admin_insertstudent" Title="新增学生页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <p>新增学生</p>
    </div>
    <div>
        <span>账号</span><asp:TextBox ID="txt1" runat="server" CssClass="txt"></asp:TextBox>
        <span>姓名</span><asp:TextBox ID="txt2" runat="server" CssClass="txt"></asp:TextBox>
        <span>学院</span><asp:DropDownList ID="DropDownList2" CssClass="lbl " runat="server">
        </asp:DropDownList>
    </div>
    <div>
        <span>专业</span><asp:TextBox ID="txt3" runat="server" CssClass="txt"></asp:TextBox>
        <span>性别</span><asp:DropDownList ID="DropDownList1" CssClass="lbl " runat="server">
            <asp:ListItem Selected="True">男</asp:ListItem>
            <asp:ListItem>女</asp:ListItem>
        </asp:DropDownList>
        <span>手机</span><asp:TextBox ID="txt4" runat="server" CssClass="txt"></asp:TextBox>
    </div>
    <div>
        <span>邮箱</span><asp:TextBox ID="txt5" runat="server" CssClass="txt"></asp:TextBox>
    </div>
    <div class="wrong1 ">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="账号不能为空"
            ControlToValidate="txt1" Display="None" ValidationGroup="bt1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="姓名不能为空"
            ControlToValidate="txt2" Display="None" ValidationGroup="bt1"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txt1"
            Display="None" ErrorMessage="注册失败,此账号已被注册过了" 
            OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="bt1"></asp:CustomValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
            ValidationGroup="bt1" />
    </div>
    <div class="bt1">
        <asp:Button ID="Button1" runat="server" Text="确定" OnClick="Button1_Click" 
            Width="65px" ValidationGroup="bt1" />
    </div>
    <hr class="hr" />
    <div>
        <div>
            <span style="font-weight: bold">批量导入</span></div>
        <div>
            <span style="width: 100px">选择Excel文件</span><asp:FileUpload ID="fudExcel" runat="server" />
            <asp:Button ID="Button2" runat="server" Text="上传" onclick="Button2_Click" 
                ValidationGroup="bt2" />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/upload/学生信息导入模板.xls"
                Font-Size="XX-Small">下载导入模板</asp:HyperLink>
        </div>
    </div>
</asp:Content>
