<%@ Page Language="C#" MasterPageFile="~/student.master" AutoEventWireup="true" CodeFile="uphomework.aspx.cs"
    Inherits="student_uphomework" Title="上交作业页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../js/admin.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <p>
            作业信息</p>
    </div>
    <div>
        <span>这是第</span><asp:Label ID="Label1" runat="server" Text="Label" Width="40px"></asp:Label><span>次作业</span>
    </div>
    <div>
        <span>作业名</span><asp:Label ID="lbl1" runat="server" Text="Label" CssClass="txt" Width="150px"></asp:Label>
    </div>
    <div>
        <span>作业备注</span><asp:TextBox ID="txt2" runat="server" Height="300px" CssClass="txtcon"
            TextMode="MultiLine" Width="300px"></asp:TextBox>
    </div>
    <div>
        <span>发布时间</span><asp:Label ID="lbl2" runat="server" CssClass="txt"></asp:Label>
        <span>截止时间</span><asp:Label ID="lbl3" runat="server" CssClass="txt"></asp:Label>
    </div>
    <div>
        <p>
            上交作业
        </p>
    </div>
    <div>
        <span>作业内容</span><asp:FileUpload ID="FileUpload1" runat="server" CssClass="txt" Width="150px" />
    </div>
    <div class="bt1">
        <asp:Button ID="Button1" runat="server" Text="确定" Width="65px" 
            onclick="Button1_Click" />
    </div>
</asp:Content>
