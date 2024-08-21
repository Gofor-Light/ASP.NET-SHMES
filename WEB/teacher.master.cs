using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using BLL;
using MODEL;

public partial class teacher : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 判断里否有已登录的session
        if (Session["adminId"] != null || Session["teacherId"] != null || Session["studentId"] != null)
        {
            // 已登陆
            if (!IsPostBack)
            {
                if (Session["teacherId"] != null)
                {
                    lbl2.Text = Session ["teacherId"].ToString();
                }
            }
        }
        else
        {
            // 未登陆
            Response.Redirect("../login.aspx");
        }
    }
    protected void btnEsc_Click(object sender, ImageClickEventArgs e)
    {
        Session.Clear();
        Response.Redirect("../login.aspx");
    }
}
