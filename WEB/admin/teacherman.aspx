<%@ Page Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="teacherman.aspx.cs"
    Inherits="admin_teacherman" Title="教师管理页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class ="search">
        <div class="sc ">
            <span>查询</span><asp:TextBox ID="txtSea" runat="server" Width="100px" ToolTip="支持教师ID,姓名,学院查询"></asp:TextBox>
        </div>
        <div class="img ">
            <asp:ImageButton ID="ImageButton1" runat="server" 
                ImageUrl="~/images/search.png" onclick="ImageButton1_Click" /></div>
    </div>
    <div>
        <p>
            教师列表</p>
    </div>
    <div class="gr1">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" Font-Size="14px" AllowPaging="True" PageSize="5" OnDataBound="NewPage"
            OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowUpdating="GridView1_RowUpdating" DataKeyNames="teacherId">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:TemplateField HeaderText="教师ID">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("teacherId") %>' Width="60px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="30px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="姓名">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("name") %>' Width="60px"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtname" CssClass="txtname" runat="server" Text='<%# Eval("name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle Height="30px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="职务">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("post") %>' Width="60px"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtpost" CssClass="txtpost" runat="server" Text='<%# Eval("post") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle Height="30px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="学院">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("college") %>' Width="75px"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="drppost" CssClass="txtcollege" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemStyle Height="30px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="手机号">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("phone") %>' Width="80px"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtphone" CssClass="txtphone" runat="server" Text='<%# Eval("phone") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle Height="30px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="邮箱">
                    <ItemTemplate>
                        <asp:Label ID="a" runat="server" Text='<%# Eval("email") %>' Width="150px"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtemail" CssClass="txtemail" runat="server" Text='<%# Eval("email") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle Height="30px" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button1" CssClass="btn" runat="server" CommandName="edit" Text="编辑" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="Button1" CssClass="btn" runat="server" CommandName="Update" Text="更新" />&nbsp;<asp:Button
                            ID="Button2" CssClass="btn" runat="server" CommandName="Cancel" Text="取消" />
                    </EditItemTemplate>
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
</asp:Content>
