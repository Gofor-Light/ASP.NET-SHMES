using MODEL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class StudentDAO
    {
         private SQLHelper sqlhelper;
         public StudentDAO()
        {
            sqlhelper = new SQLHelper();
        }
        #region 选择全部学生信息
        /// <summary>
         /// 选择全部学生信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAll()
        {
            return sqlhelper.ExecuteQuery("SELECT studentId, name, pwd, sex, subject, college, cellphone, email FROM students", CommandType.Text);
        }
        #endregion
        #region 按条件选择学生信息
        /// <summary>
        /// 按条件选择学生信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectByValue( string n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@value",n ),
            };
            return sqlhelper.ExecuteQuery("SELECT studentId, name, pwd, sex, subject, college, cellphone, email FROM students WHERE studentId=@value or name like '%'+@value+'%' ", paras, CommandType.Text);
        }
        #endregion
        #region 更新学生信息
        /// <summary>
        /// 更新学生信息
        /// </summary>
        /// <param name="n">学生信息实体类</param>
        public void Update(students  n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter ("@name",n.Name),
                new SqlParameter ("@sex",n.Sex),  
                new SqlParameter ("@subject",n.Subject),
                new SqlParameter ("@college",n.College), 
                new SqlParameter ("@cellphone",n.Cellphone ),
                new SqlParameter ("@email",n.Email),
                new SqlParameter ("@modifier",n.Modifier),
                new SqlParameter ("@studentId",n.StudentId),
            };
            sqlhelper.ExecuteQuery("UPDATE students SET name = @name,sex = @sex,subject=@subject,college=@college,cellphone = @cellphone,email = @email,modifier = @modifier,lastmodify = getdate() where studentId=@studentId", paras, CommandType.Text);
        }
        #endregion
        #region 更改学生登录密码
        /// <summary>
        /// 更改学生登录密码
        /// </summary>
        /// <param name="n">学生信息实体类</param>
        public void UpdatePwd(students n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter ("@pwd",n.Pwd),
                new SqlParameter ("@modifier",n.Modifier),
                new SqlParameter ("@studentId",n.StudentId),
            };
            sqlhelper.ExecuteQuery("UPDATE students SET pwd = @pwd,modifier = @modifier,lastmodify = getdate() where studentId=@studentId", paras, CommandType.Text);
        }
        #endregion
        #region 增加新学生信息
        /// <summary>
        /// 增加新学生信息
        /// </summary>
        /// <param name="n">学生信息实体类</param>
        /// <returns></returns>
        public bool Insert(students n)
        {
            bool flag = false;
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@studentId",n.StudentId),
                new SqlParameter("@cellphone",n.Cellphone),
                new SqlParameter("@sex",n.Sex),
                new SqlParameter("@subject",n.Subject),
                new SqlParameter("@college",n.College),
                new SqlParameter("@creater",n.Creater ),
                new SqlParameter("@email",n.Email ),
                new SqlParameter("@modifier",n.Creater ),
                new SqlParameter("@name",n.Name ),
                new SqlParameter("@pwd",n.Pwd ),
            };
            int res = sqlhelper.ExecuteNonQuery("INSERT INTO students (studentId, name, pwd, sex, college,subject, cellphone, email, creater, modifier) VALUES (@studentId,@name,@pwd,@sex,@college,@subject,@cellphone,@email,@creater,@creater)", paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion
        #region 学生登陆是否成功
        /// <summary>
        /// 学生登陆是否成功
        /// </summary>
        /// <param name="name">学生账号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public bool Login(string name, string pwd)
        {
            bool flag = false;
            string sql = "select * from students where studentId='" + name + "'AND pwd='" + pwd + "'";
            DataTable dt = sqlhelper.ExecuteQuery(sql, CommandType.Text);
            if (dt.Rows.Count > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion
        #region 检验新增加的学生账号是否已被注册
        /// <summary>
        /// 检验新增加的学生账号是否已被注册
        /// </summary>
        /// <param name="studentId">学生账号</param>
        /// <returns></returns>
        public bool Check(string studentId)
        {
            bool flag = false;
            string sql = "select * from students where studentId='" + studentId + "'";
            DataTable dt = sqlhelper.ExecuteQuery(sql, CommandType.Text);
            if (dt.Rows.Count > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion
    }
}
