using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BLL;
using MODEL;

public partial class admin_termman : System.Web.UI.Page
{
    public TermsManage tm = new TermsManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");//这行是gridview单元格数据过长自动换行
        if (Session["adminId"] != null)
        {
            if (!IsPostBack)
            {
                gridviewBind();
            }
        }
        else Response.Redirect("../login.aspx");
    }
    // gridView1分页事件
    public void ChangePage(object obj, EventArgs e)
    {
        GridViewRow pagerRow = GridView1.BottomPagerRow;
        DropDownList pageList = (DropDownList)(pagerRow.Cells[0].FindControl("myDropDownList"));
        if (obj is LinkButton)
        {
            switch (((LinkButton)obj).ID)
            {
                case "btnPrev":
                    if (pageList.SelectedIndex > 0) pageList.SelectedIndex--;
                    break;
                case "btnNext":
                    if (pageList.SelectedIndex < pageList.Items.Count - 1)
                        pageList.SelectedIndex++;
                    break;
            }
        }
        GridView1.PageIndex = pageList.SelectedIndex;
        gridviewBind();
    }
    // gridView 绑定后触发的事件(DataBound事件)
    public void NewPage(object sender, EventArgs e)
    {
        GridViewRow pagerRow = GridView1.BottomPagerRow;
        DropDownList pageList =
           (DropDownList)(pagerRow.Cells[0].FindControl("myDropDownList"));
        Label pageLabel = (Label)(pagerRow.Cells[0].FindControl("lblPageLabel"));
        for (int i = 0; i < GridView1.PageCount; i++)
        {
            int pageNumber = i + 1;
            ListItem item = new ListItem(pageNumber.ToString());
            if (i == GridView1.PageIndex) item.Selected = true;
            pageList.Items.Add(item);
        }

        int currentPage = GridView1.PageIndex + 1;
        pageLabel.Text = "Page " + currentPage.ToString() +
           " of " + GridView1.PageCount.ToString();
    }
    // gridview1绑定
    public void gridviewBind()
    {
        GridView1.DataSource = tm.Select();
        GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        terms n = new terms();
        GridViewRow gvr = GridView1.Rows[e.RowIndex];
        n.Term = GridView1.DataKeys[e.RowIndex].Value.ToString();         //获取当前行主键id
        tm.Delete(n);
        gridviewBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        terms n = new terms();
        n.Term = TextBox1.Text.Trim();
        n.Creater = Session["adminId"].ToString();
        tm.Insert(n);
        gridviewBind();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "updateScript", "alert(\"新增成功\");", true);

    }
}
