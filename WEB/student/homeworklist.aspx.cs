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

public partial class student_homeworklist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["studentId"] != null)
        {
            if (!IsPostBack)
            {
                Label6.Text = Request.QueryString["classId"];
                Label7.Text = Request.QueryString["className"];
                Label8.Text = Request.QueryString["term"];
                Label5.Text = Request.QueryString["teacherName"];
                gridviewBind();
            }
        }
        else
            Response.Redirect("../login.aspx");

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
    }
    private void gridviewBind()
    {
        StuHomeworkManage cm = new StuHomeworkManage();
        stuHomework n = new stuHomework();
        n.ClassId = Convert.ToInt32(Request.QueryString["classId"]);
        n.StudentId = Session["studentId"].ToString();
        DataTable dt = cm.SelectAllByStu(n);
        DataColumn dc = new DataColumn();
        dc.ColumnName = "add";
        dc.DataType = typeof(bool);
        dt.Columns.Add(dc);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            n.Times = Convert.ToInt32(dt.Rows[i]["times"]);
            if (cm.Isexistence(n).Rows.Count!=0)
            {
                dt.Rows[i]["add"] = true;
            }
            else dt.Rows[i]["add"] = false;
        }
        //StuHomeworkManage cm = new StuHomeworkManage();
        //stuHomework n = new stuHomework();
        //n.ClassId = Convert.ToInt32(Request.QueryString["classId"]);
        //n.StudentId = Session["studentId"].ToString();
        //stuHomework m = new stuHomework();
        //m.ClassId = Convert.ToInt32(Request.QueryString["classId"]);
        //m.StudentId = Session["studentId"].ToString();
        //DataTable dt = cm.SelectAllByStu(n);
        //DataTable dm = cm.SelectAllbyclass(m);
        //DataColumn dc = new DataColumn();
        //dc.ColumnName = "add";
        //dc.DataType = typeof(bool);
        //dt.Columns.Add(dc);
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    for (int j = 0; j < dm.Rows.Count; j++)
        //    {
        //        if (Convert.ToInt32( dt.Rows[i]["times"])==Convert.ToInt32( dm.Rows[j]["times"]))
        //        {
        //            dt.Rows[i]["add"] = true;
        //        }
        //        else dt.Rows[i]["add"] = false;
        //    }
        //}
        GridView1.DataSource = dt;
        GridView1.DataBind();
        //GridView1.DataSource = cm.SelectAllByStu(n);
        //GridView1.DataBind();
    }
    // gridView 中单击按钮事件
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "reviews")
        {
            StudentsManage sm = new StudentsManage();
            DataTable dt = sm.SelectByValue(Session["studentId"].ToString());
            Label9.Text = dt.Rows[0]["name"].ToString();
            reviews.Visible = true;
            Panel1.Visible = true;
            Label2.Text = Session["studentId"].ToString();
            GridViewRow row = (e.CommandSource as Control).NamingContainer as GridViewRow;
            TextBox1.Text = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
            TextBox2.Text = GridView1.DataKeys[row.RowIndex].Values[1].ToString();

        }
    }
    // gridView单击按钮老师更新学生作业（批阅作业）事件
    protected void Button1_Click(object sender, EventArgs e)
    {
        reviews.Visible = false;
        Panel1.Visible = false;
    }

}
