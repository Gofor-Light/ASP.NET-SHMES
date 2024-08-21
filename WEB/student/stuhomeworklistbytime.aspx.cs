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
using System.IO;
using Ionic.Zip;

public partial class student_stuhomeworklistbytime : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["studentId"] != null)
        {
            if (!IsPostBack)
            {
                Label2.Text = Request.QueryString["times"];
                Label4.Text = Request.QueryString["name"];
                Label6.Text = Request.QueryString["classId"];
                ClassesManage cm = new ClassesManage();
                DataTable dt = cm.SelectClassByClassId(Convert.ToInt32(Request.QueryString["classId"]));
                Label7.Text = dt.Rows[0]["classname"].ToString();
                Label8.Text = dt.Rows[0]["term"].ToString();
                gridviewBind();
                reviews.Visible = false;
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
        StuHomeworkManage sm = new StuHomeworkManage();
        stuHomework n = new stuHomework();
        n.ClassId = Convert.ToInt32(Request.QueryString["classId"]);
        n.Times = Convert.ToInt32(Request.QueryString["times"]);
        n.Modifier = Session["studentId"].ToString();
        DataTable dt = sm.noreviewsbyclasstimes(n);
        DataColumn dc = new DataColumn();
        dc.ColumnName = "reviews";
        dc.DataType = typeof(bool);
        dt.Columns.Add(dc);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["results"].ToString() != "0")
            {
                dt.Rows[i]["reviews"] = true;
            }
            else dt.Rows[i]["reviews"] = false;
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    // gridView 中单击按钮事件
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName=="reviews")
        {
            reviews.Visible = true;
            Panel1.Visible = true;
            Label5.Text = e.CommandArgument.ToString();
            GridViewRow row = (e.CommandSource as Control).NamingContainer as GridViewRow;
            Label9.Text = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
            TextBox1.Text = GridView1.DataKeys[row.RowIndex].Values[1].ToString();

        }
    }
    // gridView单击按钮更新学生作业（评价作业）事件
    protected void Button1_Click(object sender, EventArgs e)
    {
        reviews.Visible = false;
        Panel1.Visible = false;
        StuHomeworkManage sm = new StuHomeworkManage();
        stuHomework n = new stuHomework();
        n.ClassId = Convert.ToInt32(Label6.Text);
        n.Times = Convert.ToInt32(Label2.Text);
        n.StudentId = Label5.Text;
        n.Results = Convert.ToInt32(TextBox1.Text.Trim());
        n.Modifier = Session["studentId"].ToString();
        sm.UpdateResultByStu(n);                                      //更新互评表
        gridviewBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        reviews.Visible = false;
        Panel1.Visible = false;
    }
    protected void PackDown_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "application/zip";
        Response.AddHeader("content-disposition", "filename=Homework.zip");
        using (ZipFile zip = new ZipFile())//解决中文乱码问题
        {
            foreach (GridViewRow gvr in GridView1.Rows)
            {
                if (((CheckBox)gvr.Cells[0].Controls[1]).Checked)
                {
                    string m = Server.MapPath((gvr.Cells[3].Controls[1] as HyperLink).NavigateUrl);
                    zip.AddFile(m, "");
                }
            }

            zip.Save(Response.OutputStream);
        }

        //Response.End();
    }
}
