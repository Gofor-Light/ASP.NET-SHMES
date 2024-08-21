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

public partial class admin_teacherman : System.Web.UI.Page
{
    public TeachersManage tm = new TeachersManage();
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
        GridView1.DataSource = tm.SelectAll();
        GridView1.DataBind();
    }
    //触发gridview行的编辑事件
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;    //设置GridView控件的编辑项的索引为选择的当前索引
        gridviewBind();//数据绑定 为什么要放前面因为不绑定的话下面的gvr.FindControl("drppost")是为空的,也就是不重新绑定的话前台控件drppost是不会出现的
        GridViewRow gvr = GridView1.Rows[e.NewEditIndex];                       //实例化一行
        DropDownList drppost = (DropDownList)(gvr.FindControl("drppost"));
        CollegesManage cm = new CollegesManage();
        string n = GridView1.DataKeys[e.NewEditIndex].Value.ToString();  //获取当前行主键id
        TeachersManage tm = new TeachersManage();
        for (int i = 0; i < cm.Select().Rows.Count; i++)
        {
            string college = cm.Select().Rows[i]["college"].ToString();
            ListItem item = new ListItem(college);
            if (college == tm.SelectByValue(n).Rows[0]["college"].ToString ()) item.Selected = true;
            drppost.Items.Add(item);
        }
    }
    //触发gridview行的更新事件
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridView1.EditIndex = -1;
        teachers n = new teachers();
        GridViewRow gvr = GridView1.Rows[e.RowIndex];
        n.TeacherId = GridView1.DataKeys[e.RowIndex].Value.ToString();                                    //获取当前行主键id
        n.Name = ((TextBox)gvr.FindControl("txtname")).Text.Trim();
        n.Phone = ((TextBox)gvr.FindControl("txtphone")).Text.Trim();
        n.College = ((DropDownList)gvr.FindControl("drppost")).SelectedValue.ToString();
        n.Email = ((TextBox)gvr.FindControl("txtemail")).Text.Trim();
        n.Post = ((TextBox)gvr.FindControl("txtpost")).Text.Trim();
        n.Modifier = Session["adminId"].ToString();
        tm.Update(n);
        gridviewBind();

    }
    //触发gridview行的取消事件
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        gridviewBind();
    }
    //按条件查找老师信息
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        GridView1 .DataSource =tm.SelectByValue(txtSea.Text.Trim());
        GridView1.DataBind();
    }
}
