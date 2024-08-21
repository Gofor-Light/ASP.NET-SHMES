<%@ Page Language="C#" MasterPageFile="~/teacher.master" AutoEventWireup="true" CodeFile="viewhomework.aspx.cs" Inherits="teacher_viewhomework" Title="查看作业页" %>

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
            课程信息
        </p>
    </div>
    <div>
        <span>课程ID</span><asp:Label ID="Label6" runat="server" Text="Label" CssClass="classmes1 "></asp:Label>
        <span>课程名</span><asp:Label ID="Label7" runat="server" Text="Label" CssClass="classmes2"></asp:Label>
        <span>学期</span><asp:Label ID="Label8" runat="server" Text="Label" CssClass="classmes3"></asp:Label>
    </div> 
    <div>
        <p>
            作业信息
        </p>
    </div>
    <div>
        <span>这是第</span><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><span>次作业</span>
    </div>
    <div>
        <span>作业名</span><asp:Label ID="Label2" runat="server" Text="Label" 
            Width="150px"></asp:Label>
    </div>
    <div>
        <span>作业内容</span><asp:HyperLink ID="HyperLink1" runat="server" Font-Size="14px">下载</asp:HyperLink>
    </div>
    <div>
        <span>作业备注</span><asp:TextBox ID="txt2" runat="server" Height="300px" CssClass="txtcon"
            TextMode="MultiLine" Width="300px" ReadOnly="True"></asp:TextBox>
    </div>
    <div>
        <span>发布时间</span><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <span>截止时间</span><asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    </div>
    <div class="bt1">
        <asp:Button ID="Button1" runat="server" Text="修改"  Width="65px" 
            onclick="Button1_Click" />
    </div>
</asp:Content>

