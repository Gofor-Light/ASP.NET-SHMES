using System;
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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (DropDownList1.SelectedValue == "admin")
        {
            AdminManage am = new AdminManage();
            bool n = am.Login(txtName.Text.Trim(), txtPwd.Text.Trim());
            if (n)
            {
                Session["adminId"] = txtName.Text.Trim();
                Response.Redirect("admin/adminDefault.aspx");
            }
        }
        if (DropDownList1.SelectedValue == "teacher")
        {
            TeachersManage tm = new TeachersManage();
            bool n = tm.Login(txtName.Text.Trim(), txtPwd.Text.Trim());
            if (n)
            {
                Session["teacherId"] = txtName.Text.Trim();
                Response.Redirect("teacher/teaDefault.aspx");
            }
        }
        if (DropDownList1.SelectedValue == "student")
        {
            StudentsManage sm = new StudentsManage();
            bool n = sm.Login(txtName.Text.Trim(), txtPwd.Text.Trim());
            if (n)
            {
                Session["studentId"] = txtName.Text.Trim();
                Response.Redirect("student/stuDefault.aspx");
            }
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('登陆失败，用户名或者密码错误！');</script>");
    }
}
