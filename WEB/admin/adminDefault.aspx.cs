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

public partial class admin_adminDefault : System.Web.UI.Page
{
    public AdminManage am = new AdminManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminId"] != null)
        {
            if (!IsPostBack)
            {
                messsageBind();
                gridviewBind();
            }
        }
        else Response.Redirect("../login.aspx");
    }
    // 修改管理员基本信息
    protected void btn3_Click(object sender, EventArgs e)
    {
        admins ad = new admins();
        ad.AdminId = Session["adminId"].ToString();
        ad.Modifier = Session["adminId"].ToString();
        ad.Cellphone = txt2.Text.Trim();
        ad.Name = txt1.Text.Trim();
        ad.Email = txt3.Text.Trim();
        am.Update(ad);
        messsageBind();
    }
    // 绑定管理员基本信息
    public void messsageBind()
    {
        DataTable dt = am.Select(Session["adminId"].ToString());
        txt1.Text = dt.Rows[0]["name"].ToString();
        txt2.Text = dt.Rows[0]["cellphone"].ToString();
        txt3.Text = dt.Rows[0]["email"].ToString();
        lbl1.Text = Session["adminId"].ToString();
        lbl2.Text = dt.Rows[0]["name"].ToString();
        lbl3.Text = dt.Rows[0]["cellphone"].ToString();
        lbl4.Text = dt.Rows[0]["email"].ToString();
        string oldPwd = dt.Rows[0]["pwd"].ToString();
    }
    //  修改管理员个人密码
    protected void btn5_Click(object sender, EventArgs e)
    {
        DataTable dt = am.Select(Session["adminId"].ToString());
        string oldPwd = dt.Rows[0]["pwd"].ToString();
        if (txt4.Text == oldPwd)
        {
            admins ad = new admins();
            ad.AdminId = Session["adminId"].ToString();
            ad.Modifier = Session["adminId"].ToString();
            ad.Pwd = txt6.Text.Trim();
            am.UpdatePwd(ad);
            messsageBind();
        }

    }
    // 绑定管理员列表
    public void gridviewBind()
    {
        DataTable gd = am.SelectAll();
        GridView1.DataSource = gd;
        GridView1.DataBind();
    }
    // 验证输入原密码是否正确
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        DataTable dt = am.Select(Session["adminId"].ToString());
        string oldPwd = dt.Rows[0]["pwd"].ToString();
        if (args.Value == oldPwd)
        {
            args.IsValid = true;
        }
        else args.IsValid = false;
    }
    // gridView1分页事件
    public void ChangePage(object obj, EventArgs e)
    {
        GridViewRow pagerRow = GridView1.BottomPagerRow;
        DropDownList pageList = (DropDownList)(pagerRow.Cells[0].FindControl("myDropDownList"));
        if (obj is LinkButton)
        {
            switch (((LinkButton)obj).ID)
            {
                case "btnPrev":
                    if (pageList.SelectedIndex > 0) pageList.SelectedIndex--;
                    break;
                case "btnNext":
                    if (pageList.SelectedIndex < pageList.Items.Count - 1)
                        pageList.SelectedIndex++;
                    break;
            }
        }
        GridView1.PageIndex = pageList.SelectedIndex;
        gridviewBind();
    }
    // gridView 绑定后触发的事件
    public void NewPage(object sender, EventArgs e)
    {
        GridViewRow pagerRow = GridView1.BottomPagerRow;
        DropDownList pageList =
           (DropDownList)(pagerRow.Cells[0].FindControl("myDropDownList"));
        Label pageLabel = (Label)(pagerRow.Cells[0].FindControl("lblPageLabel"));

        int i;
        for (i = 0; i < GridView1.PageCount; i++)
        {
            int pageNumber = i + 1;
            ListItem item = new ListItem(pageNumber.ToString());
            if (i == GridView1.PageIndex) item.Selected = true;
            pageList.Items.Add(item);
        }

        int currentPage = GridView1.PageIndex + 1;
        pageLabel.Text = "Page " + currentPage.ToString() +
           " of " + GridView1.PageCount.ToString();
    }
    // 新增管理员账号
    protected void btn8_Click(object sender, EventArgs e)
    {
        if (!am.Check(txt7.Text.Trim()))
        {
            admins ad = new admins();
            ad.AdminId = txt7.Text.Trim();
            ad.Pwd = txt8.Text.Trim();
            ad.Name = txt10.Text.Trim();
            ad.Cellphone = txt11.Text.Trim();
            ad.Email = txt12.Text.Trim();
            ad.Creater = Session["adminId"].ToString();
            am.Insert(ad);
            gridviewBind();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "updateScript", "alert(\"新增成功\");", true);

        }
    }
    // 验证管理员注册时账号是否已被注册
    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (am.Check(args.Value))
        {
            args.IsValid = false;
        }
        else args.IsValid = true;
    }

}
