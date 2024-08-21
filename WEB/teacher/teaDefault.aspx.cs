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

public partial class teacher_teaDefault : System.Web.UI.Page
{
    public TeachersManage tm = new TeachersManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["teacherId"] != null)
        {
            
            if (!IsPostBack)
            {
                teacherbind();
            }
        }
        else Response.Redirect("../login.aspx");
    }

    private void teacherbind()
    {
        DataTable dt = new DataTable();
        lbl1.Text = Session["teacherId"].ToString();
        dt = tm.SelectByValue(Session["teacherId"].ToString());
        lbl2.Text = dt.Rows[0]["name"].ToString();
        Label1.Text = dt.Rows[0]["college"].ToString();
        Label2.Text = dt.Rows[0]["post"].ToString();
        lbl3.Text = dt.Rows[0]["phone"].ToString();
        lbl4.Text = dt.Rows[0]["email"].ToString();
        txt2.Text = dt.Rows[0]["phone"].ToString();
        txt3.Text = dt.Rows[0]["email"].ToString();
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        DataTable dt = tm.SelectByValue(Session["teacherId"].ToString());
        string oldPwd = dt.Rows[0]["pwd"].ToString();
        if (args.Value == oldPwd)
        {
            args.IsValid = true;
        }
        else args.IsValid = false;
    }

    protected void btn3_Click(object sender, EventArgs e)
    {
        TeachersManage tm = new TeachersManage();
        teachers n = new teachers();
        n.Name = lbl2.Text;
        n.Post = Label2.Text;
        n.College = Label1.Text;
        n.Phone = txt2.Text;
        n.Email = txt3.Text;
        n.Modifier = Session["teacherId"].ToString();
        n.TeacherId = Session["teacherId"].ToString();
        tm.Update(n);
        teacherbind();
    }
    protected void btn5_Click(object sender, EventArgs e)
    {
        DataTable dt = tm.SelectByValue(Session["teacherId"].ToString());
        string oldPwd = dt.Rows[0]["pwd"].ToString();
        if (txt4.Text == oldPwd)
        {
            teachers n = new teachers();
            n.TeacherId = Session["teacherId"].ToString();
            n.Modifier = Session["teacherId"].ToString();
            n.Pwd = txt6.Text.Trim();
            tm.UpdatePwd(n);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "updateScript", "alert(\"修改成功\");", true);

        }
    }

}
