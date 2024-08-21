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
using System.ComponentModel;
using System.Data.OleDb;

public partial class admin_viewclass : System.Web.UI.Page
{
    private DataTable DataSource
    {
        get
        {
            if (ViewState["_dataSource"] == null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("studentId"));
                dt.Columns.Add(new DataColumn("name"));
                dt.Columns.Add(new DataColumn("subject"));
                dt.Columns.Add(new DataColumn("college"));
                dt.Columns.Add(new DataColumn("cellphone"));
                dt.Columns.Add(new DataColumn("email"));
                ViewState["_dataSource"] = dt;
            }
            return ViewState["_dataSource"] as DataTable;
        }
        set
        {
            ViewState["_dataSource"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminId"] != null)
        {
            if (!IsPostBack)
            {
                Label6.Text = Request.QueryString["classId"];
                Label7.Text = Request.QueryString["classname"];
                Label8.Text = Request.QueryString["term"];
                Label9.Text = Request.QueryString["name"];
                EntityDataSource();  
            }

        }
        else Response.Redirect("../login.aspx");
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
        if (pagerRow != null)
        {
            DropDownList pageList = (DropDownList)(pagerRow.Cells[0].FindControl("myDropDownList"));
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
    // gridView1 绑定
    public void gridviewBind1()
    {
        StuCourseManage sm = new StuCourseManage();
        int n = Convert.ToInt32(Request.QueryString["classId"]);
        DataSource = sm.SelectAllstu(n);
    }
    //触发gridview行的删除事件
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        stuCourse n = new stuCourse();
        StuCourseManage sm = new StuCourseManage();
        GridViewRow gvr = GridView1.Rows[e.RowIndex];
        n.StudentId = GridView1.DataKeys[e.RowIndex].Value.ToString();                    //获取当前行主键id
        n.ClassId = Convert.ToInt32(Label6.Text);
        sm.DeleteStu(n);
        gridviewBind1();
        gridviewBind();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        StudentsManage sm = new StudentsManage();
        DataTable dt = sm.SelectByValue(TextBox1.Text.Trim());
        if (dt.Rows.Count!=0)
        {
            Label11.Text = dt.Rows[0]["name"].ToString();
            Label12.Text = dt.Rows[0]["college"].ToString();
            Label13.Text = dt.Rows[0]["subject"].ToString();
        }
    }
    protected void btnmes_Click(object sender, EventArgs e)
    {
        StuCourseManage sm = new StuCourseManage();
        stuCourse n = new stuCourse();
        n.ClassId = Convert.ToInt32(Request.QueryString["classId"]);
        n.StudentId = TextBox1.Text.Trim();
        n.Creater = Session["adminId"].ToString();
        for (int i = 0; i <  sm.SelectAllstu(Convert.ToInt32(Request.QueryString["classId"])).Rows.Count; i++)
		{
            if (sm.SelectAllstu(Convert.ToInt32(Request.QueryString["classId"])).Rows[i]["studentId"].ToString()==TextBox1.Text.Trim())
            {
                return;  
            } 
		} 
        sm.InsertStu(n);
        gridviewBind1();
        gridviewBind();
    }
    /// <summary>
    /// 读取Excel数据
    /// </summary>
    /// <param name="filepath"></param>
    /// <returns></returns>
    public DataTable ExcelDataSource(string filepath, ref bool existsSheetname)
    {
        DataTable dt = null;
        string sheetname = "Sheet1$";
        string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=Excel 8.0;";
        OleDbConnection conn = new OleDbConnection(strConn);
        conn.Open();
        DataTable sheetNames = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
        conn.Close();

        // 获取第0个sheet
        if (sheetNames.Rows.Count > 0)
        {
            foreach (DataRow row in sheetNames.Rows)
            {
                if (row[2].ToString() == sheetname)
                {
                    existsSheetname = true;
                    break;
                }
            }
        }
        if (existsSheetname)
        {
            OleDbDataAdapter oada = new OleDbDataAdapter("select * from [" + sheetname + "]", strConn);
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("studentId"));
            dt.Columns.Add(new DataColumn("name"));
            dt.Columns.Add(new DataColumn("subject"));
            dt.Columns.Add(new DataColumn("college"));
            dt.Columns.Add(new DataColumn("cellphone"));
            dt.Columns.Add(new DataColumn("email"));
            oada.Fill(dt);
        }
        return dt;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        #region 验证文件
        if (string.IsNullOrEmpty(fudExcel.FileName))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "updateScript", "alert(\"请选择上传文件 \");", true);
            return;
        }
        string extension = fudExcel.FileName.Substring(fudExcel.FileName.LastIndexOf('.'));

        if (extension == ".xlsx")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "updateScript", "alert(\"目前模板只支持Excel2003版文件，请转换后再导入！\");", true);

            return;
        }
        if (extension != ".xls")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "updateScript", "alert(\"上传文件扩展必须是(xls/xlsx)文件！\");", true);
            return;
        }
        #endregion
        string filepath = string.Empty;
        // 上传到服务器临时目录下
        string tempdir = Server.MapPath("../upload/");
        string filename = Guid.NewGuid() + extension;
        filepath = tempdir + filename;
        // 保存
        fudExcel.SaveAs(filepath);
        bool existsSheetname = false;
        // 读取到DataTable
        var data = ExcelDataSource(filepath, ref existsSheetname);
        if (!existsSheetname)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "updateScript", "alert(\"没有找到《模板工作表》工作表!\");", true);
            return;
        }

        // 删除临时文件
        System.IO.File.Delete(filepath);
        if (data == null)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "updateScript", "解析Excel失败，请检查Excel是否符合模板要求！\");", true);
            return;
        }

        foreach (DataRow row in data.Rows)
        {
            string id = row["studentId"].ToString();
            var arrRow = DataSource.Select("studentId='" + id + "'");
            if (arrRow != null && arrRow.Length > 0)
            {
            }
            else
            {
                DataRow newrow = DataSource.NewRow();
                newrow["studentId"] = row["studentId"];
                newrow["name"] = row["name"];
                newrow["subject"] = row["subject"];
                newrow["college"] = row["college"];

                StudentsManage sm = new StudentsManage();
                if (sm.SelectByValue(newrow["studentId"].ToString()).Rows.Count == 0)
                {
                    students n = new students();
                    n.StudentId = newrow["studentId"].ToString();
                    n.Name = newrow["name"].ToString();
                    n.Subject = newrow["subject"].ToString();
                    n.College = newrow["college"].ToString();
                    n.Cellphone = "";
                    n.Creater = Session["adminId"].ToString();
                    n.Pwd = newrow["studentId"].ToString();
                    n.Email = "";
                    n.Sex = "";
                    sm.Insert(n);
                }
                StuCourseManage scm = new StuCourseManage();
                stuCourse m = new stuCourse();
                m.ClassId = Convert.ToInt32(Request.QueryString["classId"]);
                m.StudentId = newrow["studentId"].ToString();
                m.Creater = Session["adminId"].ToString();
                scm.InsertStu(m);
            }

        }
        gridviewBind1();
        gridviewBind();

    }
    void gridviewBind()
    {
        GridView1.DataSource = DataSource;
        GridView1.DataBind();
    }
    void EntityDataSource()
    {
        StuCourseManage sm = new StuCourseManage();
        int n = Convert.ToInt32(Request.QueryString["classId"]);
        DataTable dt = sm.SelectAllstu(n);// 获取数据库中所有数据
        DataSource.Rows.Clear(); // 清除数据源 
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow row = DataSource.NewRow();
            row["studentId"] = dt.Rows[i]["studentId"];
            row["name"] = dt.Rows[i]["name"];
            row["subject"] = dt.Rows[i]["subject"];
            row["college"] = dt.Rows[i]["college"];
            DataSource.Rows.Add(row);
        }
        gridviewBind();
    }
}
