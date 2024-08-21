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

public partial class student_uphomework : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["studentId"] != null)
        {
            if (!IsPostBack)
            {
                Label1.Text = Request.QueryString["times"];
                lbl1.Text = Request.QueryString["name"];
                txt2.Text = Request.QueryString["remarks"];
                lbl2.Text = Request.QueryString["publishTime"];
                lbl3.Text = Request.QueryString["closeTime"];
            }
        }
        else Response.Redirect("../login.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        StuCourseManage sm = new StuCourseManage();
        StuHomeworkManage mm = new StuHomeworkManage();
        DataTable dt = sm.SelectClassByClassId(Convert.ToInt32(Request.QueryString["classId"]));
        stuHomework n = new stuHomework();
        n.StudentId = Session["studentId"].ToString();
        n.ClassId = Convert.ToInt32(Request.QueryString["classId"]);
        n.Times = Convert.ToInt32(Label1.Text);
        n.Creater = Session["studentId"].ToString();
        string path = Server.MapPath("~/upload/" + dt.Rows[0]["teacherId"].ToString() 
            + "/" + dt.Rows[0]["name"].ToString() + Request.QueryString["classId"] + "/第" + Label1.Text + "次作业/");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        if (mm.Isexistence(n).Rows.Count>0)
        {
            FileInfo fi1 = new FileInfo(Server.MapPath(mm.Isexistence(n).Rows[0]["content"].ToString()));
            fi1.Delete();
            mm.Delete(n);
            
        }
        FileUpload1.SaveAs(path + FileUpload1.FileName);
        n.Content = "~/upload/" + dt.Rows[0]["teacherId"].ToString() + "/" + dt.Rows[0]["name"].ToString() 
            + Request.QueryString["classId"] + "/第" + Label1.Text + "次作业/" + FileUpload1.FileName;
        mm.Insert(n);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "updateScript", "alert(\"上交成功\");", true);

    }

}
