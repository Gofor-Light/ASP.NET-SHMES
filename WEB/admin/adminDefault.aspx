<%@ Page Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="adminDefault.aspx.cs"
    Inherits="admin_adminDefault" Title="管理员首页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../js/admin.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <p>
            基本信息</p>
    </div>
    <div>
        <span>账号</span><asp:Label ID="lbl1" runat="server" Text="Label" CssClass="lbl"></asp:Label>
        <span>姓名</span><asp:Label ID="lbl2" runat="server" Text="Label" CssClass="lbl"></asp:Label>
    </div>
    <div class="hide1">
        <span style="color: White">空</span><asp:Label ID="Label1" runat="server" Text="f"
            CssClass="lbl" ForeColor="White"></asp:Label>
        <span>姓名</span><asp:TextBox ID="txt1" runat="server" CssClass="txt"></asp:TextBox>
    </div>
    <div>
        <span>手机</span><asp:Label ID="lbl3" runat="server" Text="Label" CssClass="lbl"></asp:Label>
        <span>邮箱</span><asp:Label ID="lbl4" runat="server" Text="Label" CssClass="lbl"></asp:Label>
    </div>
    <div class="hide1">
        <span>手机</span><asp:TextBox ID="txt2" runat="server" CssClass="txt"></asp:TextBox>
        <span>邮箱</span><asp:TextBox ID="txt3" runat="server" CssClass="txt"></asp:TextBox>
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
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt1"
            ErrorMessage="姓名不能为空" Display="None" ValidationGroup="mes"></asp:RequiredFieldValidator>
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
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="pwd" />
    </div>
    <div class="bt1">
        <input id="btn1" type="button" value="修改信息" />
        <input id="btn2" type="button" value="修改密码" />
    </div>
    <div class="bt2">
        <asp:Button ID="btn3" runat="server" Text="确定" Width="77px" ValidationGroup="mes"
            OnClick="btn3_Click" />
        <input id="btn4" style="width: 77px;" type="button" value="取消" />
    </div>
    <div class="bt3">
        <asp:Button ID="btn5" runat="server" Text="确定" Width="77px" ValidationGroup="pwd"
            OnClick="btn5_Click" />
        <input id="btn6" style="width: 77px;" type="button" value="取消" />
    </div>
    <div>
        <p>
            管理员列表</p>
    </div>
    <div class="gr">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" Font-Size="14px" AllowPaging="True" PageSize="5"
            OnDataBound="NewPage">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:BoundField DataField="adminId" HeaderText="管理员ID">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="name" HeaderText="姓名">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="cellphone" HeaderText="手机号">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                </asp:BoundField>
                <asp:BoundField DataField="email" HeaderText="邮箱">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                </asp:BoundField>
            </Columns>
            <PagerTemplate>
                <asp:Table ID="Table1" Width="100%" runat="server">
                    <asp:TableRow>
                        <asp:TableCell Width="200px">
                            <asp:Label ID="lblMessage" ForeColor="Blue" Text="请选择页码:" runat="server" CssClass="bottom" />
                            <asp:DropDownList ID="myDropDownList" AutoPostBack="true" OnSelectedIndexChanged="ChangePage"
                                runat="server" />
                            <asp:LinkButton ID="btnPrev" Style="text-decoration: none" OnClick="ChangePage" runat="server"
                                Text="上一页">
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnNext" Style="text-decoration: none" OnClick="ChangePage" runat="server"
                                Text="下一页">
                            </asp:LinkButton>
                        </asp:TableCell>
                        <asp:TableCell Width="200px" HorizontalAlign="right">
                            <asp:Label ID="lblPageLabel" ForeColor="Blue" runat="server" Width="200px" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </PagerTemplate>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
    <div class="bt4">
        <input id="btn7" type="button" value="增加管理员" />
    </div>
    <div class="hide3">
        <p>
            新增管理员</p>
    </div>
    <div class="hide3">
        <span>账号</span><asp:TextBox ID="txt7" runat="server" CssClass="txt"></asp:TextBox>
        <span>密码</span><asp:TextBox ID="txt8" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox>
        <span>确定密码</span><asp:TextBox ID="txt9" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox>
    </div>
    <div class="hide3">
        <span>姓名</span><asp:TextBox ID="txt10" runat="server" CssClass="txt"></asp:TextBox>
        <span>手机</span><asp:TextBox ID="txt11" runat="server" CssClass="txt"></asp:TextBox>
        <span>邮箱</span><asp:TextBox ID="txt12" runat="server" CssClass="txt"></asp:TextBox>
    </div>
    <div class="wrong2">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="账号不能空"
            Display="None" ControlToValidate="txt7" ValidationGroup="insert"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt8"
            Display="None" ErrorMessage="密码不能为空" ValidationGroup="insert"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="密码不能为空"
            ControlToValidate="txt9" Display="None" ValidationGroup="insert"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="姓名不能为空"
            ControlToValidate="txt10" Display="None" ValidationGroup="insert"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="手机不能为空"
            ControlToValidate="txt11" Display="None" ValidationGroup="insert"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txt12"
            Display="None" ErrorMessage="邮箱不能为空" ValidationGroup="insert"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="txt8"
            ControlToValidate="txt9" Display="None" ErrorMessage="二次输入的密码不匹配" ValidationGroup="insert"></asp:CompareValidator>
        <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txt7"
            Display="None" ErrorMessage="此账号已被其它人注册过了" OnServerValidate="CustomValidator2_ServerValidate"
            ValidationGroup="insert"></asp:CustomValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt11"
            Display="None" ErrorMessage="请输入有效的手机号" ValidationExpression="(\d){11}" ValidationGroup="insert"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt12"
            Display="None" ErrorMessage="请输入有效的邮箱" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            ValidationGroup="insert"></asp:RegularExpressionValidator>
        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="insert" />
    </div>
    <div class="bt5">
        <asp:Button ID="btn8" runat="server" Text="确定" Width="77px" ValidationGroup="insert"
            OnClick="btn8_Click" />
        <input id="btn9" style="width: 77px;" type="button" value="取消" />
    </div>
</asp:Content>
