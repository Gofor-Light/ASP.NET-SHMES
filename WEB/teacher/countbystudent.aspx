<%@ Page Language="C#" MasterPageFile="~/teacher.master" AutoEventWireup="true" CodeFile="countbystudent.aspx.cs"
    Inherits="teacher_countbystudent" Title="统计作业页" %>

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
            课程信息</p>
        <div>
            <span>课程ID</span><asp:Label ID="Label6" runat="server" Text="Label" CssClass="classmes1 "></asp:Label>
            <span>课程名</span><asp:Label ID="Label7" runat="server" Text="Label" CssClass="classmes2"></asp:Label>
            <span>学期</span><asp:Label ID="Label8" runat="server" Text="Label" CssClass="classmes3"></asp:Label>
            <span>任课老师</span><asp:Label ID="Label9" runat="server" Text="Label" CssClass="classmes4"></asp:Label>
        </div>
    </div>
    <div>
        <p>
            学生列表</p>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="gr1">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" Font-Size="14px" AllowPaging="True" PageSize="10" OnDataBound="NewPage"
                    DataKeyNames="studentId,name" OnRowCommand="GridView1_RowCommand">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField HeaderText="学生ID">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("studentId") %>' Width="80px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="姓名">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("name") %>' Width="60px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="专业">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("subject") %>' Width="75px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="学院">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("college") %>' Width="75px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="邮箱">
                            <ItemTemplate>
                                <asp:Label ID="a" runat="server" Text='<%# Eval("email") %>' Width="150px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="统计">
                            <ItemTemplate>
                                <asp:Button ID="Button1" runat="server" Text="统计" CommandName="count" />
                            </ItemTemplate>
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
                    统计信息</p>
            </div>
            <div>
                <span>学生ID:</span><asp:Label ID="Label5" runat="server" Text=""></asp:Label><span>姓名:</span><asp:Label
                    ID="Label10" runat="server" Text=""></asp:Label>
            </div>
            <hr style="width: 400px; position: relative; right: 98px" />
            <div class="gr1">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField HeaderText="作业次数">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("times") %>' Width="60px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="作业名">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("name") %>' Width="60px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="分数">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("results") %>' Width="75px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="是否已交">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" Checked='<%# Eval("add") %>' runat="server" Enabled="False"
                                    Font-Bold="False" BorderStyle="NotSet" />
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                        Font-Size="14px" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
