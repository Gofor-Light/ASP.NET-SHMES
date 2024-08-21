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

public partial class teacher_edithomework : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label1.Text = Request.QueryString["times"];
            txt1.Text = Request.QueryString["name"];
            txt2.Text = Request.QueryString["remarks"];
            txt3.Text = Request.QueryString["publishTime"];
            txt4.Text = Request.QueryString["closeTime"];
            Label6.Text = Request.QueryString["classId"];
            Label7.Text = Request.QueryString["classname"];
            Label8.Text = Request.QueryString["term"];
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        HomeworkListManage hm = new HomeworkListManage();
        homeworkList n = new homeworkList();
        n.ClassId = Convert.ToInt32(Request.QueryString["classId"]);
        n.Name = txt1.Text.Trim();
        n.Remarks = txt2.Text.Trim();
        n.PublishTime = Convert.ToDateTime(txt3.Text.Trim());
        n.CloseTime = Convert.ToDateTime(txt4.Text.Trim());
        string path = Server.MapPath("~/upload/" + Session["teacherId"].ToString() + "/" + Request.QueryString["classname"] + Request.QueryString["classId"] + "/第" + Label1.Text + "次作业/");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        FileUpload1.SaveAs(path + FileUpload1.FileName);
        n.Content = "~/upload/" + Session["teacherId"].ToString() + "/" + Request.QueryString["classname"] + Request.QueryString["classId"] + "/第" + Label1.Text + "次作业/" + FileUpload1.FileName;
        n.Modifier = Session["teacherId"].ToString();
        n.Times = Convert.ToInt32(Label1.Text);
        hm.Update(n);
    }
}
