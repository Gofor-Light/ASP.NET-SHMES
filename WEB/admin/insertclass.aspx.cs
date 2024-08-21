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

public partial class admin_insertclass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["adminId"] != null)
            {
                drpBind();
            }
            else Response.Redirect("../login.aspx");
        }

    }
    //dropdownlist学院列绑定
    private void drpBind()
    {
        TermsManage tm = new TermsManage();
        CollegesManage cm = new CollegesManage();
        DropDownList1.DataSource = tm.Select();
        DropDownList1.DataTextField = "term";
        DropDownList1.DataBind();
        DropDownList2.DataSource = cm.Select();
        DropDownList2.DataTextField = "college";
        DropDownList2.DataBind();
        ddl3bind();
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl3bind();
    }

    private void ddl3bind()
    {
        TeachersManage tm = new TeachersManage();
        DropDownList3.DataSource = tm.SelectByValue(DropDownList2.SelectedValue);
        DropDownList3.DataTextField = "name";
        DropDownList3.DataValueField = "teacherId";
        DropDownList3.DataBind();
        lbl1.Text = DropDownList3.SelectedValue;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ClassesManage cm = new ClassesManage();
        classes n = new classes();
        n.Name = txt1.Text.Trim();
        n.Term = DropDownList1.SelectedValue;
        n.TeacherId = DropDownList3.SelectedValue;
        n.Creater = Session["adminId"].ToString();
        cm.InsertClass(n);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "updateScript", "alert(\"新增成功\");", true);
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl1.Text = DropDownList3.SelectedValue ;
    }
}
