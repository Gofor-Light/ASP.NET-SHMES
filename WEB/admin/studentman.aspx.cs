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

public partial class admin_studentman : System.Web.UI.Page
{
    public StudentsManage sm = new StudentsManage ();
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
        GridView1.DataSource = sm.SelectAll();
        GridView1.DataBind();
    }
    //按条件查找老师信息
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        GridView1.DataSource = sm.SelectByValue(txtSea.Text.Trim());
        GridView1.DataBind();
    }
}
