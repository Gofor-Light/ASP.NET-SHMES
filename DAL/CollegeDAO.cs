using MODEL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class CollegeDAO
    {
        private SQLHelper sqlhelper;
        public CollegeDAO()
        {
            sqlhelper = new SQLHelper();
        }
        #region 新增学院
        /// <summary>
        /// 新增学院
        /// </summary>
        /// <param name="n">学院实体类</param>
        /// <returns></returns>
        public bool Insert(colleges n)
        {
            bool flag = false;
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@college",n.College),
                new SqlParameter("@creater",n.Creater),
                new SqlParameter("@modifier",n.Creater),
            };
            int res = sqlhelper.ExecuteNonQuery("INSERT INTO colleges (college, creater, modifier) VALUES (@college,@creater,@modifier)", paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion
        #region 查看全部学院
        /// <summary>
        /// 查看全部学院
        /// </summary>
        /// <returns></returns>
        public DataTable Select()
        {
            return sqlhelper.ExecuteQuery("SELECT college FROM colleges ", CommandType.Text);
        }
        #endregion
        #region 删除学院
        /// <summary>
        /// 删除学院
        /// </summary>
        /// <param name="n">学院实体类</param>
        /// <returns></returns>
        public bool Delete(colleges n)
        {
            bool flag = false;
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@college",n.College ),
            };
            int res = sqlhelper.ExecuteNonQuery("DELETE FROM colleges where college=@college", paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion             
    }
}
