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

public partial class teacher_countbystudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["teacherId"] != null)
        {
            if (!IsPostBack)
            {
                Label6.Text = Request.QueryString["classId"];
                Label7.Text = Request.QueryString["classname"];
                Label8.Text = Request.QueryString["term"];
                Label9.Text = Request.QueryString["name"];
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
        if (pagerRow != null)
        {
            DropDownList pageList = (DropDownList)(pagerRow.Cells[0].FindControl("myDropDownList"));
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
    }
    // gridView1 绑定
    public void gridviewBind()
    {
        StuCourseManage sm = new StuCourseManage();
        int n = Convert.ToInt32(Request.QueryString["classId"]);
        GridView1.DataSource = sm.SelectAllstu(n);
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "count")
        {            
            StuHomeworkManage sm=new StuHomeworkManage();
            GridViewRow row = (e.CommandSource as Control).NamingContainer as GridViewRow;
            Label5.Text = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
            Label10.Text = GridView1.DataKeys[row.RowIndex].Values[1].ToString();
            string studentId = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
            stuHomework n = new stuHomework();
            n.StudentId = studentId;
            n.ClassId = Convert.ToInt32(Label6.Text);
            DataTable dt = sm.SelectAllByStu(n);
            DataColumn dc = new DataColumn();
            dc.ColumnName = "add";
            dc.DataType = typeof(bool);
            dt.Columns.Add(dc);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["uptimes"].ToString() != "")
                {
                    dt.Rows[i]["add"] = true;
                }
                else dt.Rows[i]["add"] = false;
            }
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
    }
}
