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

public partial class admin_viewstudent : System.Web.UI.Page
{
    StudentsManage sm = new StudentsManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminId"] != null)
        {
            if (!IsPostBack)
            {
                bind();
            }

        }
        else Response.Redirect("../login.aspx");
    }

    private void bind()
    {
        DataTable dt = sm.SelectByValue(Request.QueryString["studentId"].ToString());
        lbl1.Text = dt.Rows[0]["studentId"].ToString();
        lbl2.Text = dt.Rows[0]["pwd"].ToString();
        txt1.Text = dt.Rows[0]["name"].ToString();
        txt2.Text = dt.Rows[0]["subject"].ToString();
        txt3.Text = dt.Rows[0]["cellphone"].ToString();
        txt4.Text = dt.Rows[0]["email"].ToString();
        DropDownList1.SelectedValue = dt.Rows[0]["sex"].ToString();
        drpBind();
    }
    //DropDownList2学院 绑定
    private void drpBind()
    {
        DataTable dt = sm.SelectByValue(Request.QueryString["studentId"].ToString());
        CollegesManage cm = new CollegesManage();
        DropDownList2.DataSource = cm.Select();
        DropDownList2.DataTextField = "college";
        DropDownList2.SelectedValue = dt.Rows[0]["college"].ToString();
        DropDownList2.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        bind();
        txt1.ReadOnly = false;
        txt2.ReadOnly = false;
        txt3.ReadOnly = false;
        txt4.ReadOnly = false;
        DropDownList1.Enabled = true;
        DropDownList2.Enabled = true;
        btn3.Enabled = true;

    }
    protected void btn3_Click(object sender, EventArgs e)
    {
        students n = new students();
        n.StudentId = lbl1.Text;
        n.Name = txt1.Text.Trim();
        n.Subject = txt2.Text.Trim();
        n.Cellphone = txt3.Text.Trim();
        n.Email = txt4.Text.Trim();
        n.Sex = DropDownList1.SelectedValue;
        n.College = DropDownList2.SelectedValue;
        n.Modifier = Session["adminId"].ToString();
        sm.Update(n);
        bind();
        txt1.ReadOnly = true ;
        txt2.ReadOnly = true ;
        txt3.ReadOnly = true ;
        txt4.ReadOnly = true ;
        DropDownList1.Enabled = false ;
        DropDownList2.Enabled = false ;
        btn3.Enabled = false;
    }
}
