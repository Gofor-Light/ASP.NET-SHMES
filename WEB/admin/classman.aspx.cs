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

public partial class admin_classman : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gridviewBind();
        }
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
    // gridView 绑定后触发的事件(DataBound事件)
    public void NewPage(object sender, EventArgs e)
    {
        GridViewRow pagerRow = GridView1.BottomPagerRow;
        if (pagerRow!=null)
        {
            DropDownList pageList =
              (DropDownList)(pagerRow.Cells[0].FindControl("myDropDownList"));
            Label pageLabel = (Label)(pagerRow.Cells[0].FindControl("lblPageLabel"));
            for (int i = 0; i < GridView1.PageCount; i++)
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
        
    }
    private void gridviewBind()
    {
        ClassesManage cm = new ClassesManage ();
        GridView1.DataSource = cm.SelectAllClass ();
        GridView1.DataBind();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ClassesManage cm = new ClassesManage();
        GridView1.DataSource = cm.SelectClassByValue(txtSea.Text.Trim());
        GridView1.DataBind();
    }
}
