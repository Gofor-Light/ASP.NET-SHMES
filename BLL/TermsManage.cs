using DAL;
using MODEL;
using System.Data;

namespace BLL
{
    public class TermsManage
    {
        private TermDAO ndao = null;
        public TermsManage()
        {
            ndao = new TermDAO ();
        }
        #region 新增学期
        /// <summary>
        /// 新增学期
        /// </summary>
        /// <param name="n">学期实体类</param>
        /// <returns></returns>
        public bool Insert(terms n)
        {
            return ndao.Insert(n);
        }
        #endregion
        #region 查看全部学期
        /// <summary>
        /// 查看全部学期
        /// </summary>
        /// <returns></returns>
        public DataTable Select()
        {
            return ndao.Select();
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
            return ndao.Delete(n);
        }
        #endregion       
    }
}
