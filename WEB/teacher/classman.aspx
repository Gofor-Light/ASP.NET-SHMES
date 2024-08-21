<%@ Page Language="C#" MasterPageFile="~/teacher.master" AutoEventWireup="true" CodeFile="classman.aspx.cs" Inherits="teacher_classman" Title="班级页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <p>
            课程列表</p>
    </div>
    <div class="gr1">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" Font-Size="14px" AllowPaging="True" PageSize="5" OnDataBound="NewPage"
            DataKeyNames="classId">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:TemplateField HeaderText="课程ID">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("classId") %>' Width="65px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="课程名称">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("classname") %>' Width="130px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="学期">
                    <ItemTemplate>
                        <asp:Label ID="Label0" runat="server" Text='<%# Eval("term") %>' Width="100px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle />
                </asp:TemplateField>
                <asp:HyperLinkField HeaderText="查看详情" DataNavigateUrlFields="classId,classname,term,name"
                    DataNavigateUrlFormatString="viewclass.aspx?classId={0}&amp;classname={1}&amp;term={2}&amp;name={3}"
                    DataTextField="classId" DataTextFormatString="查看班级成员">
                    <ItemStyle Font-Size="12px" />
                </asp:HyperLinkField>
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
</asp:Content>


