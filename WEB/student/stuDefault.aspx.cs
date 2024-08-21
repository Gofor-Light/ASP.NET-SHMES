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

public partial class student_stuDefault : System.Web.UI.Page
{
    public StudentsManage tm = new StudentsManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["studentId"] != null)
        {

            if (!IsPostBack)
            {
                studentbind();

            }
        }
        else Response.Redirect("../login.aspx");
    }

    private void studentbind()
    {
        DataTable dt = new DataTable();
        lbl1.Text = Session["studentId"].ToString();
        dt = tm.SelectByValue(Session["studentId"].ToString());
        lbl2.Text = dt.Rows[0]["name"].ToString();
        Label1.Text = dt.Rows[0]["college"].ToString();
        Label2.Text = dt.Rows[0]["subject"].ToString();
        lbl3.Text = dt.Rows[0]["cellphone"].ToString();
        lbl4.Text = dt.Rows[0]["email"].ToString();
        txt2.Text = dt.Rows[0]["cellphone"].ToString();
        txt3.Text = dt.Rows[0]["email"].ToString();
    }
    // 验证输入原密码是否正确
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        DataTable dt = tm.SelectByValue(Session["studentId"].ToString());
        string oldPwd = dt.Rows[0]["pwd"].ToString();
        if (args.Value == oldPwd)
        {
            args.IsValid = true;
        }
        else args.IsValid = false;
    }

    protected void btn3_Click(object sender, EventArgs e)
    {
        students n = new students();
        n.Name = lbl2.Text;
        n.Subject = Label2.Text;
        n.College = Label1.Text;
        n.Cellphone = txt2.Text;
        n.Email = txt3.Text;
        n.Modifier = Session["studentId"].ToString();
        n.StudentId = Session["studentId"].ToString();
        n.Sex = tm.SelectByValue(Session["studentId"].ToString()).Rows[0]["sex"].ToString();
        tm.Update(n);
        studentbind();
    }
    protected void btn5_Click(object sender, EventArgs e)
    {
        DataTable dt = tm.SelectByValue(Session["studentId"].ToString());
        string oldPwd = dt.Rows[0]["pwd"].ToString();
        if (txt4.Text == oldPwd)
        {
            students n = new  students();
            n.StudentId= Session["studentId"].ToString();
            n.Modifier = Session["studentId"].ToString();
            n.Pwd = txt6.Text.Trim();
            tm.UpdatePwd(n);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "updateScript", "alert(\"修改成功\");", true);

        }
    }

}
