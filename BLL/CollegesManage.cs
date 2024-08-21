using DAL;
using MODEL;
using System.Data;

namespace BLL
{
    public class CollegesManage
    {
        private CollegeDAO ndao = null;
        public CollegesManage()
        {
            ndao = new CollegeDAO ();
        }
        #region 新增学院
        /// <summary>
        /// 新增学院
        /// </summary>
        /// <param name="n">学院实体类</param>
        /// <returns></returns>
        public bool Insert(colleges n)
        {
            return ndao.Insert(n);
        }
        #endregion
        #region 查看全部学院
        /// <summary>
        /// 查看全部学院
        /// </summary>
        /// <returns></returns>
        public DataTable Select()
        {
            return ndao.Select();
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
            return ndao.Delete(n);
        }
        #endregion       
    }
}
