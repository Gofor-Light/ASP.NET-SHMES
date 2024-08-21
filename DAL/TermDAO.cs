using MODEL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class TermDAO
    {
        private SQLHelper sqlhelper;
        public TermDAO()
        {
            sqlhelper = new SQLHelper();
        }
        #region 新增学期
        /// <summary>
        /// 新增学期
        /// </summary>
        /// <param name="n">学期实体类</param>
        /// <returns></returns>
        public bool Insert(terms n)
        {
            bool flag = false;
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@term",n.Term),
                new SqlParameter("@creater",n.Creater),
                new SqlParameter("@modifier",n.Creater),
            };
            int res = sqlhelper.ExecuteNonQuery("INSERT INTO terms (term, creater, modifier) VALUES (@term,@creater,@modifier)", paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion
        #region 查看全部学期
        /// <summary>
        /// 查看全部学期
        /// </summary>
        /// <returns></returns>
        public DataTable Select()
        {
            return sqlhelper.ExecuteQuery("SELECT term FROM terms ", CommandType.Text);
        }
        #endregion
        #region 删除学期
        /// <summary>
        /// 删除学期
        /// </summary>
        /// <param name="n">学期实体类</param>
        /// <returns></returns>
        public bool Delete(terms n)
        {
            bool flag = false;
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@term",n.Term ),
            };
            int res = sqlhelper.ExecuteNonQuery("DELETE FROM terms where term=@term", paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion        
    }
}
