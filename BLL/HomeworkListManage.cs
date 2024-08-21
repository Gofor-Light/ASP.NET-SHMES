using DAL;
using MODEL;
using System.Data;

namespace BLL
{
    public class HomeworkListManage
    {
        private HomeworkListDAO ndao = null;
        public HomeworkListManage()
        {
            ndao = new HomeworkListDAO ();
        }
        #region 新增学生作业
        /// <summary>
        /// 新增学生作业
        /// </summary>
        /// <param name="n">作业列表实体类</param>
        /// <returns></returns>
        public bool Insert(homeworkList  n)
        {
            return ndao.Insert(n);
        }
        #endregion
        #region 更新学生作业
        /// <summary>
        /// 更新学生作业
        /// </summary>
        /// <param name="n">作业列表实体类</param>
        /// <returns></returns>
        public void Update(homeworkList   n)
        {
            ndao.Update(n);
        }
        #endregion
        #region 删除作业
        /// <summary>
        /// 删除作业
        /// </summary>
        /// <param name="n">作业列表实体类</param>
        /// <returns></returns>
        public bool DeleteHomework(homeworkList  n)
        {
            return ndao.DeleteHomework(n);
        }
        #endregion       
        #region 查看单一班级所有作业
        /// <summary>
        /// 查看单一班级所有作业
        /// </summary>
        /// <param name="n">班级Id</param>
        /// <returns></returns>
        public DataTable SelectByClass(int n)
        {
            return ndao.SelectByClass(n);
        }
        #endregion
        #region 查看某一班级已布置到最高作业的次数
        /// <summary>
        /// 查看某一班级已布置到最高作业的次数
        /// </summary>
        /// <param name="n">班级Id</param>
        /// <returns></returns>
        public DataTable SelectTime(int n)
        {
            return ndao.SelectTime(n);
        }
        #endregion
    }
}
