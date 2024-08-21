using MODEL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class TeacherDAO
    {
        private SQLHelper sqlhelper;
        public TeacherDAO()
        {
            sqlhelper = new SQLHelper();
        }
        #region 选择全部教师信息
        /// <summary>
        /// 选择全部教师信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAll()
        {
            return sqlhelper.ExecuteQuery("SELECT teacherId,pwd, name, post, college, phone, email FROM teachers", CommandType.Text);
        }
        #endregion
        #region 按条件选择教师信息
        /// <summary>
        /// 按条件选择教师信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectByValue( string n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@value",n ),
            };
            return sqlhelper.ExecuteQuery("SELECT teacherId,pwd, name, post, college, phone, email FROM teachers WHERE teacherId=@value or name like '%'+@value+'%'or college like '%'+@value+'%' or post like '%'+@value+'%'  ", paras, CommandType.Text);
        }
        #endregion
        #region 更新教师信息
        /// <summary>
        /// 更新教师信息
        /// </summary>
        /// <param name="n">教师信息实体类</param>
        public void Update(teachers n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter ("@name",n.Name),
                new SqlParameter ("@post",n.Post),  
                new SqlParameter ("@college",n.College), 
                new SqlParameter ("@phone",n.Phone ),
                new SqlParameter ("@email",n.Email),
                new SqlParameter ("@modifier",n.Modifier),
                new SqlParameter ("@teacherId",n.TeacherId),
            };
            sqlhelper.ExecuteQuery("UPDATE teachers SET name = @name,post = @post,college=@college,phone = @phone,email = @email,modifier = @modifier,lastmodify = getdate() where teacherId=@teacherId", paras, CommandType.Text);
        }
        #endregion
        #region 更改教师登录密码
        /// <summary>
        /// 更改教师登录密码
        /// </summary>
        /// <param name="n">教师信息实体类</param>
        public void UpdatePwd(teachers n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter ("@pwd",n.Pwd),
                new SqlParameter ("@modifier",n.Modifier),
                new SqlParameter ("@teacherId",n.TeacherId),
            };
            sqlhelper.ExecuteQuery("UPDATE teachers SET pwd = @pwd,modifier = @modifier,lastmodify = getdate() where teachers.teacherId=@teacherId", paras, CommandType.Text);
        }
        #endregion
        #region 增加新教师信息
        /// <summary>
        /// 增加新教师信息
        /// </summary>
        /// <param name="n">教师信息实体类</param>
        /// <returns></returns>
        public bool Insert(teachers n)
        {
            bool flag = false;
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@teacherId",n.TeacherId),
                new SqlParameter("@phone",n.Phone),
                new SqlParameter("@post",n.Post),
                new SqlParameter("@college",n.College),
                new SqlParameter("@creater",n.Creater ),
                new SqlParameter("@email",n.Email ),
                new SqlParameter("@modifier",n.Creater ),
                new SqlParameter("@name",n.Name ),
                new SqlParameter("@pwd",n.Pwd ),
            };
            int res = sqlhelper.ExecuteNonQuery("INSERT INTO teachers (teacherId, name, pwd, post, college, phone, email, creater, modifier) VALUES (@teacherId,@name,@pwd,@post,@college,@phone,@email,@creater,@creater)", paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion
        #region 教师登陆是否成功
        /// <summary>
        /// 教师登陆是否成功
        /// </summary>
        /// <param name="name">教师账号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public bool Login(string name, string pwd)
        {
            bool flag = false;
            string sql = "select * from teachers where teacherId='" + name + "'AND pwd='" + pwd + "'";
            DataTable dt = sqlhelper.ExecuteQuery(sql, CommandType.Text);
            if (dt.Rows.Count > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion
        #region 检验新增加的教师账号是否已被注册
        /// <summary>
        /// 检验新增加的教师账号是否已被注册
        /// </summary>
        /// <param name="teacherId">教师账号</param>
        /// <returns></returns>
        public bool Check(string teacherId)
        {
            bool flag = false;
            string sql = "select * from teachers where teacherId='" + teacherId + "'";
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
