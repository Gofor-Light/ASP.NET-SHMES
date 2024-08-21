<%@ Page Language="C#" MasterPageFile="~/teacher.master" AutoEventWireup="true" CodeFile="addhomework.aspx.cs"
    Inherits="teacher_addhomework" Title="发布作业页" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../js/admin.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
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
            布置作业
        </p>
    </div>
    <div>
        <span>这是第</span><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><span>次作业</span>
    </div>
    <div>
        <span>作业名</span><asp:TextBox ID="txt1" runat="server" CssClass="txt" Width="150px"></asp:TextBox>
    </div>
    <div>
        <span>作业内容</span><asp:FileUpload ID="FileUpload1" runat="server" CssClass="txt" Width="150px" />
    </div>
    <div>
        <span>作业备注</span><asp:TextBox ID="txt2" runat="server" Height="300px" CssClass="txtcon"
            TextMode="MultiLine" Width="300px"></asp:TextBox>
    </div>
    <div>
        <span>发布时间</span><asp:TextBox ID="txt3" runat="server" CssClass="txt"></asp:TextBox>
        <cc1:CalendarExtender ID="txt3_CalendarExtender" runat="server" 
            TargetControlID="txt3">
        </cc1:CalendarExtender>
        <span>截止时间</span><asp:TextBox ID="txt4" runat="server" CssClass="txt"></asp:TextBox>
        <cc1:CalendarExtender ID="txt4_CalendarExtender" runat="server" 
            TargetControlID="txt4">
        </cc1:CalendarExtender>
    </div>
    <div class="bt1">
        <asp:Button ID="Button1" runat="server" Text="确定"  Width="65px" 
            onclick="Button1_Click" />
    </div>
</asp:Content>
