<%@ Page Language="C#" MasterPageFile="~/student.master" AutoEventWireup="true" CodeFile="stuDefault.aspx.cs" Inherits="student_stuDefault" Title="学生首页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../js/admin.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <p>基本信息</p>
    </div>
    <div>
        <span>账号</span><asp:Label ID="lbl1" runat="server" Text="Label" CssClass="lbl"></asp:Label>
        <span>姓名</span><asp:Label ID="lbl2" runat="server" Text="Label" CssClass="lbl"></asp:Label>
    </div>
    <div>
        <span>学院</span><asp:Label ID="Label1" runat="server" Text="Label" CssClass="lbl"></asp:Label>
        <span>专业</span><asp:Label ID="Label2" runat="server" Text="Label" CssClass="lbl"></asp:Label>
    </div>
    <div>
        <span>手机</span><asp:Label ID="lbl3" runat="server" Text="Label" CssClass="lbl"></asp:Label>
        <span>邮箱</span><asp:Label ID="lbl4" runat="server" Text="Label" CssClass="lbl"></asp:Label>
    </div>
    <div class="hide1">
        <span>手机</span><asp:TextBox ID="txt2" runat="server" CssClass="txt"></asp:TextBox>
        <span>邮箱</span><asp:TextBox ID="txt3" runat="server" CssClass="txt"></asp:TextBox>
    </div>
    <div class="wrong1">        
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt2"
            ErrorMessage="手机号不能为空" Display="None" ValidationGroup="mes"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="邮箱不能为空"
            ControlToValidate="txt3" Display="None" ValidationGroup="mes"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="邮箱格式不对"
            ControlToValidate="txt3" Display="None" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            ValidationGroup="mes"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="请输入有效的手机号"
            ControlToValidate="txt2" ValidationExpression="(\d){11}" Display="None" ValidationGroup="mes"></asp:RegularExpressionValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="mes" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="请输入原密码"
            ControlToValidate="txt4" Display="None" ValidationGroup="pwd"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="新密码不能为空"
            ControlToValidate="txt5" ValidationGroup="pwd" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="新密码不能为空"
            Display="None" ValidationGroup="pwd" ControlToValidate="txt6"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="输入的二次新密码不匹配"
            ControlToCompare="txt5" ControlToValidate="txt6" Display="None" ValidationGroup="pwd"></asp:CompareValidator>
        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txt4"
            Display="None" ErrorMessage="输入的原密码错误" OnServerValidate="CustomValidator1_ServerValidate"
            ValidationGroup="pwd"></asp:CustomValidator>        
    </div>
    <div class="bt1">
        <input id="btn1" type="button" value="修改信息" />
    </div>
    <div class="bt2">
        <asp:Button ID="btn3" runat="server" Text="确定" Width="77px" 
            ValidationGroup="mes" onclick="btn3_Click" />
        <input id="btn4" style="width: 77px;" type="button" value="取消" />
    </div>    
    <div>
        <p>
            修改密码</p>
    </div>
    <div class="hide2">
        <span>原密码</span><asp:TextBox ID="txt4" runat="server" CssClass="txt" ValidationGroup="pwd"
            TextMode="Password"></asp:TextBox>
    </div>
    <div class="hide2">
        <span>新密码</span><asp:TextBox ID="txt5" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox>
    </div>
    <div class="hide2">
        <span>新密码</span><asp:TextBox ID="txt6" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox>
    </div>
    <div class="wrong1">
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="pwd" />
    </div>
    <div class="bt3">
        <asp:Button ID="btn5" runat="server" Text="确定" Width="77px" 
            ValidationGroup="pwd" onclick="btn5_Click" />
        <input id="btn6" style="width: 77px;" type="button" value="取消" />
    </div>
    <div class="bt1">
        <input id="btn2" type="button" value="修改密码" /></div>
</asp:Content>

