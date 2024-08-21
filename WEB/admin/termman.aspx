<%@ Page Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="termman.aspx.cs" Inherits="admin_termman" Title="学期管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <p>
            学期列表</p>
    </div>
    <div class="gr1">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" Font-Size="14px" AllowPaging="True" PageSize="5" OnDataBound="NewPage"
            DataKeyNames="term" OnRowDeleting="GridView1_RowDeleting">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:TemplateField HeaderText="学期">
                    <ItemTemplate>
                        <asp:Label ID="Label14" runat="server" Text='<%# Eval("term") %>' Width="120px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="30px" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button2" CssClass="btn" runat="server" CommandName="delete" Text="删除" OnClientClick='return confirm("确定要删除")' />
                    </ItemTemplate>
                    <ControlStyle BackColor="#FFC0C0" />
                    <ItemStyle HorizontalAlign="Center" Height="30px" />
                </asp:TemplateField>
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
    <div>
        <p>
            新增学期</p>
    </div>
    <div>
        <span>学期</span><asp:TextBox ID="TextBox1" runat="server" CssClass="txt"></asp:TextBox>
        <div>
            <asp:Button ID="Button1" runat="server" Text="新增" CssClass="bt1" 
                onclick="Button1_Click" />
        </div>
</asp:Content>

