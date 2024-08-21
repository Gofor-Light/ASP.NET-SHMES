using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MODEL;
using System.Data;

namespace BLL
{
    public class DayiManage
    {
        private DayiDAO ndao = null;
        public DayiManage()
        {
            ndao = new DayiDAO();
        }
        #region 学生提交问题
        /// <summary>
        /// 学生提交问题
        /// </summary>
        /// <param name="n">答疑实体类</param>
        /// <returns></returns>
        public bool Insert(dayi n)
        {
            return ndao.Insert(n);
        }
        #endregion
        #region 学生更新问题
        /// <summary>
        /// 学生更新问题
        /// </summary>
        /// <param name="n">答疑实体类</param>
        /// <returns></returns>
        public void UpdateByStu(dayi n)
        {
            ndao.UpdateByStu(n);
        }
        #endregion
        #region 教师回答学生疑问
        /// <summary>
        /// 教师回答学生疑问
        /// </summary>
        /// <param name="n">答疑实体类</param>
        /// <returns></returns>
        public void Answer(dayi n)
        {
            ndao.Answer(n);
        }
        #endregion
        #region 学生查看已提交的全部问题
        /// <summary>
        /// 学生查看已提交的全部问题
        /// </summary>
        /// <param name="n">学生Id</param>
        /// <returns></returns>
        public DataTable SelectAllByStu(string n)
        {
            return ndao.SelectAllByStu(n);
        }
        #endregion
        #region 教师按学期查看全部有关问题
        /// <summary>
        /// 教师按学期查看全部有关问题
        /// </summary>
        /// <param name="n">教师Id</param>
        /// <param name="m">学期</param>
        /// <returns></returns>
        public DataTable SelectAllByTea(string n, string m)
        {
            return ndao.SelectAllByTea(n,m);
        }
        #endregion
        #region 查看单一问题的详细信息
        /// <summary>
        /// 查看单一问题的详细信息
        /// </summary>
        /// <param name="n">dayiId</param>
        /// <returns></returns>
        public DataTable Select(int n)
        {
            return ndao.Select(n);
        }
        #endregion
        #region 删除问题
        /// <summary>
        /// 删除问题
        /// </summary>
        /// <param name="n">答疑实体类</param>
        /// <returns></returns>
        public bool Delete(dayi n)
        {
            return ndao.Delete(n);
        }
        #endregion       
    }
}
