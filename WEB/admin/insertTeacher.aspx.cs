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

public partial class admin_insertTeacher : System.Web.UI.Page
{
    TeachersManage tm = new TeachersManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminId"] != null)
        {
            drpBind();
        }
        else Response.Redirect("../login.aspx");
    }
    //dropdownlist学院列绑定
    private void drpBind()
    {
        CollegesManage cm = new CollegesManage();
        DropDownList2.DataSource = cm.Select();
        DropDownList2.DataTextField = "college";
        DropDownList2.DataBind();
    }
    //新增教师信息
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!tm.Check(txt1.Text.Trim()))
        {
            teachers n = new teachers();
            n.TeacherId = txt1.Text.Trim();
            n.Pwd = txt1.Text.Trim();
            n.Name = txt2.Text.Trim();
            n.Phone = txt3.Text.Trim();
            n.Email = txt4.Text.Trim();
            n.Post = DropDownList1.SelectedValue;
            n.College = DropDownList2.SelectedValue;
            n.Creater = Session["adminId"].ToString();
            tm.Insert(n);
            string path = Server.MapPath("~/upload/" + txt1.Text.Trim());
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "updateScript", "alert(\"新增成功\");", true);

        }
    }
    //检验新增加的教师账号是否已被注册过
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (tm.Check(args.Value))
        {
            args.IsValid = false;
        }
        else args.IsValid = true;
    }
}
