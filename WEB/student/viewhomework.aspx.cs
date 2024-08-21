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

public partial class student_viewhomework : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["studentId"] != null)
        {
            Button1.Visible = false;
        }
        if (!IsPostBack)
        {
            Label1.Text = Request.QueryString["times"];
            Label2.Text = Request.QueryString["name"];
            HyperLink1.NavigateUrl = Request.QueryString["content"];
            txt2.Text = Request.QueryString["remarks"];
            Label3.Text = Request.QueryString["publishTime"];
            Label4.Text = Request.QueryString["closeTime"];
            Label6.Text = Request.QueryString["classId"];
            ClassesManage cm = new ClassesManage();
            DataTable dt = cm.SelectClassByClassId(Convert.ToInt32(Request.QueryString["classId"]));
            Label7.Text = dt.Rows[0]["classname"].ToString();
            Label8.Text = dt.Rows[0]["term"].ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("edithomework.aspx?times=" + Label1.Text + "&name=" + Label2.Text + "&remarks=" + txt2.Text + "&publishTime=" + Label3.Text + "&closeTime=" + Label4.Text + "&classId=" + Label6.Text + "&classname=" + Label7.Text + "&term=" + Label8.Text);
    }
}
