<%@ Page Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="studentman.aspx.cs"
    Inherits="admin_studentman" Title="学生管理页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="search">
        <div class="sc ">
            <span>查询</span><asp:TextBox ID="txtSea" runat="server" Width="100px" ToolTip="请输入学生ID或姓名"></asp:TextBox>
        </div>
        <div class="img ">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/search.png"
                OnClick="ImageButton1_Click" /></div>
    </div>
    <div>
        <p>学生列表</p>
    </div>
    <div class="gr1">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" Font-Size="14px" AllowPaging="True" PageSize="5" OnDataBound="NewPage"
            DataKeyNames="studentId">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:TemplateField HeaderText="学生ID">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("studentId") %>' Width="80px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="姓名">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("name") %>' Width="60px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="学院">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("college") %>' Width="90px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="专业">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("subject") %>' Width="130px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="性别">
                    <ItemTemplate>
                        <asp:Label  runat="server" Text='<%# Eval("sex") %>' Width="30px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField HeaderText="查看详情" DataNavigateUrlFields="studentId" 
                    DataNavigateUrlFormatString="viewstudent.aspx?studentId={0}" 
                    DataTextField="studentId" DataTextFormatString="查看或修改信息" >
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
