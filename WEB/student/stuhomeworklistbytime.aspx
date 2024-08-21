<%@ Page Language="C#" MasterPageFile="~/student.master" AutoEventWireup="true" CodeFile="stuhomeworklistbytime.aspx.cs"
    Inherits="student_stuhomeworklistbytime" Title="学生作业页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../js/admin.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
        <span>这是第</span><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><span>次作业</span>
        <span>作业名</span><asp:Label ID="Label4" runat="server" Text="Label" CssClass="classmes2"></asp:Label>
    </div>
    <div>
        <p>
            作业列表</p>
    </div>
      <asp:Button ID="PackDown" runat="server" Text="打包下载" 
        onclick="PackDown_Click" Width="60px"  />
    <div class="gr1">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" Font-Size="14px" AllowPaging="True" PageSize="5" OnDataBound="NewPage"
            DataKeyNames="name,results,comment" OnRowCommand="GridView1_RowCommand">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:TemplateField HeaderText="&lt;input type='checkbox';/&gt;" InsertVisible="False">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="学号">
                    <ItemTemplate>
                        <asp:Label ID="Label0" runat="server" Text='<%# Eval("studentId") %>' Width="100px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="姓名">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("name") %>' Width="100px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="内容">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("content") %>'
                            Target="_blank">下载</asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="分数">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("results") %>' Width="100px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="是否已阅">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" Checked='<%# Eval("reviews") %>' runat="server" Enabled="False"
                            Font-Bold="False" BorderStyle="NotSet" />
                    </ItemTemplate>
                    <ItemStyle />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="评分">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CommandArgument='<%# Eval("studentId") %>'
                            Text="评分" CommandName="reviews" />
                    </ItemTemplate>
                    <ItemStyle />
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
    <div id="reviews" class="reviews" runat="server">
        <asp:Panel ID="Panel1" runat="server" Visible="False">
            <div>
                <span>学生ID</span><asp:Label ID="Label5" runat="server" Text="Label" CssClass="classmes1 "></asp:Label>
                <span>姓名</span><asp:Label ID="Label9" runat="server" Text="Label" CssClass="classmes2"></asp:Label>
            </div>
            <div>
                <span>分数</span><asp:TextBox ID="TextBox1" runat="server" Width="50px"></asp:TextBox>
            </div>
            <div class="bt1">
                <asp:Button ID="Button1" runat="server" Text="确定" Width="65px" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="取消" Width="65px" OnClick="Button2_Click" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
