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

public partial class teacher_addhomework : System.Web.UI.Page
{
    public HomeworkListManage hm = new HomeworkListManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["teacherId"] != null)
        {
            if (!IsPostBack)
            {
                Label6.Text = Request.QueryString["classId"];
                Label7.Text = Request.QueryString["classname"];
                Label8.Text = Request.QueryString["term"];
            }
            DataTable dt = hm.SelectTime(Convert.ToInt32(Request.QueryString["classId"]));
            if (dt.Rows.Count > 0)
            {
                Label1.Text = (Convert.ToUInt32(dt.Rows[0]["times"].ToString()) + 1).ToString();
            }
            else Label1.Text = "1";
        }
        else Response.Redirect("../login.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        homeworkList n = new homeworkList();
        n.ClassId = Convert.ToInt32(Request.QueryString["classId"]);
        n.Times = Convert.ToInt32(Label1.Text);
        n.Name = txt1.Text.Trim();
        n.Remarks = txt2.Text;
        n.PublishTime = Convert.ToDateTime(txt3.Text.Trim());
        n.CloseTime = Convert.ToDateTime(txt4.Text.Trim());
        n.Creater = Session["teacherId"].ToString();
        string path = Server.MapPath("~/upload/" + Session["teacherId"].ToString() + "/" + Request.QueryString["classname"] + Request.QueryString["classId"] + "/第" + Label1.Text + "次作业/");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        FileUpload1.SaveAs(path + FileUpload1.FileName);
        n.Content = "~/upload/" + Session["teacherId"].ToString() + "/" + Request.QueryString["classname"] + Request.QueryString["classId"] + "/第" + Label1.Text + "次作业/" + FileUpload1.FileName;
        hm.Insert(n);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "updateScript", "alert(\"新增成功\");", true);

    }
}
