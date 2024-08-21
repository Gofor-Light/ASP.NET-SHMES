using MODEL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class AdminDAO
    {
        private SQLHelper sqlhelper;
        public AdminDAO()
        {
            sqlhelper = new SQLHelper();
        }
        #region 选择全部管理员信息
        /// <summary>
        /// 选择全部管理员信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAll()
        {
            return sqlhelper.ExecuteQuery("SELECT adminId,name,cellphone,email FROM admins", CommandType.Text);
        }
        #endregion
        #region 查看单个管理员信息
        /// <summary>
        /// 查看单个管理员信息
        /// </summary>
        /// <param name="n">管理员Id</param>
        /// <returns></returns>
        public DataTable Select(string  n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@adminId",n ),
            };
            return sqlhelper.ExecuteQuery("SELECT adminId,pwd,name,cellphone,email FROM admins where adminId=@adminId",paras , CommandType.Text);
        }
        #endregion
        #region 更新管理员信息
        /// <summary>
        /// 更新管理员信息
        /// </summary>
        /// <param name="n">管理员信息实体类</param>
        public void Update(admins n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter ("@name",n.Name),  
                new SqlParameter ("@cellphone",n.Cellphone ),
                new SqlParameter ("@email",n.Email),
                new SqlParameter ("@modifier",n.Modifier),
                new SqlParameter ("@adminId",n.AdminId),
            };
            sqlhelper.ExecuteQuery("UPDATE admins SET name = @name,cellphone = @cellphone,email = @email,modifier = @modifier,lastmodify = getdate() where admins.adminId=@adminId", paras, CommandType.Text);
        }
        #endregion
        #region 更新管理员密码
        /// <summary>
        /// 更新管理员密码
        /// </summary>
        /// <param name="n">管理员信息实体类</param>
        public void UpdatePwd(admins n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter ("@pwd",n.Pwd),  
                new SqlParameter ("@modifier",n.Modifier),
                new SqlParameter ("@adminId",n.AdminId),
            };
            sqlhelper.ExecuteQuery("UPDATE admins SET pwd = @pwd,modifier = @modifier,lastmodify = getdate() where admins.adminId=@adminId", paras, CommandType.Text);
        }
        #endregion
        #region 增加新管理员信息
        /// <summary>
        /// 增加新管理员信息
        /// </summary>
        /// <param name="n">管理员信息实体类</param>
        /// <returns></returns>
        public bool Insert(admins  n)
        {
            bool flag = false;
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@adminId",n.AdminId),
                new SqlParameter("@cellphone",n.Cellphone),
                new SqlParameter("@creater",n.Creater ),
                new SqlParameter("@email",n.Email ),
                new SqlParameter("@modifier",n.Creater ),
                new SqlParameter("@name",n.Name ),
                new SqlParameter("@pwd",n.Pwd ),
            };
            int res = sqlhelper.ExecuteNonQuery("INSERT INTO admins (adminId, name, pwd, cellphone, email, creater, modifier) VALUES (@adminId,@name,@pwd,@cellphone,@email,@creater,@creater)", paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion
        #region 管理员登陆是否成功
        /// <summary>
        /// 管理员登陆是否成功
        /// </summary>
        /// <param name="name">管理员账号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public  bool Login(string name, string pwd)
        {
            bool flag = false;
            string sql = "select * from admins where adminId='" + name + "'AND pwd='" + pwd + "'";
            DataTable dt = sqlhelper.ExecuteQuery(sql, CommandType.Text);
            if (dt.Rows.Count > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion
        #region 检验新增加的管理员账号是否已被注册
        /// <summary>
        /// 检验新增加的管理员账号是否已被注册
        /// </summary>
        /// <param name="adminId">管理员账号</param>
        /// <returns></returns>
        public bool Check(string adminId)
        {
            bool flag = false;
            string sql = "select * from admins where adminId='" + adminId + "'";
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
