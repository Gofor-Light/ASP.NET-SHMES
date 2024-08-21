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

public partial class student_addhomework : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["studentId"] != null)
        {
            if (!IsPostBack)
            {
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
    private void gridviewBind()
    {
        StuHomeworkManage sm = new StuHomeworkManage();
        StuCourseManage cm = new StuCourseManage();
        DataTable dt = cm.SelectClassByStu(Session["studentId"].ToString());
        DataColumn dc = new DataColumn();
        HomeworkListManage hm = new HomeworkListManage();
        dc.ColumnName = "noup";
        dc.DataType = typeof(int);
        dt.Columns.Add(dc);
        for (int i = 0; i < dt.Rows.Count; i++)
        { 
            int k;
            DataTable dd = hm.SelectTime(Convert.ToInt32(dt.Rows[i]["classId"]));
            stuHomework n = new stuHomework();
            n.StudentId = Session["studentId"].ToString();
            n.ClassId = Convert.ToInt32(dt.Rows[i]["classId"]);
            int t = Convert.ToInt32(dd.Rows[0][0]);
            if (sm.SelectCountByStu(n).Rows.Count==0)
            {
             k = 0;   
            }
            else k = Convert.ToInt32(sm.SelectCountByStu(n).Rows[0][0]);
            int y = t - k;
            dt.Rows[i]["noup"] = y;
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}
