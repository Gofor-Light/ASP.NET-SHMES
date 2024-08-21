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

public partial class admin_insertstudent : System.Web.UI.Page
{
    StudentsManage sm = new StudentsManage();
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
    //新增学生信息
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!sm.Check(txt1.Text.Trim()))
        {
            students n = new students();
            n.StudentId = txt1.Text.Trim();
            n.Pwd = txt1.Text.Trim();
            n.Name = txt2.Text.Trim();
            n.Subject = txt3.Text.Trim();
            n.Cellphone = txt4.Text.Trim();
            n.Email = txt5.Text.Trim();
            n.Sex = DropDownList1.SelectedValue;
            n.College = DropDownList2.SelectedValue;
            n.Creater = Session["adminId"].ToString();
            sm.Insert(n);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "updateScript", "alert(\"新增成功\");", true);
        }
    }
    //检验新增加的学生账号是否已被注册过
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (sm.Check(args.Value))
        {
            args.IsValid = false;
        }
        else args.IsValid = true;
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "updateScript", "alert(\"解析Excel失败，请检查Excel是否符合模板要求！\");", true);
            return;
        }

        foreach (DataRow row in data.Rows)
        {
            StudentsManage sm = new StudentsManage();
            string id = row["studentId"].ToString();
            DataTable DataSource = sm.SelectAll();
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
            }

        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "updateScript", "alert(\"导入成功\");", true);
    }
}
