using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MODEL;
using System.Data;

namespace BLL
{
    public class StuHomeworkManage
    {
        private StuHomeworkDAO ndao = null;
        public StuHomeworkManage()
        {
            ndao = new StuHomeworkDAO();
        }
        #region 学生提交作业
        /// <summary>
        /// 学生提交作业
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        /// <returns></returns>
        public bool Insert(stuHomework n)
        {
            return ndao.Insert(n);
        }
        #endregion
        #region 查看单一班级单一次数已交作业列表
        /// <summary>
        /// 查看单一班级单一次数已交作业列表
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        /// <returns></returns>
        public DataTable SelectByClass(stuHomework n)
        {
            return ndao.SelectByClass(n);
        }
        #endregion
        #region 学生更新作业
        /// <summary>
        /// 学生更新作业
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        /// <returns></returns>
        public void UpdateByStu(stuHomework n)
        {
            ndao.UpdateByStu(n);
        }
        #endregion
        #region 教师更新作业
        /// <summary>
        /// 教师更新作业
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        /// <returns></returns>
        public void UpdateByTea(stuHomework n)
        {
            ndao.UpdateByTea(n);
        }
        #endregion
        #region 统计单一班级单一次数的全部作业成绩
        /// <summary>
        /// 统计单一班级单一次数的全部作业成绩
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        /// <returns></returns>
        public DataTable SelectAllByTimes(stuHomework n)
        {
            return ndao.SelectAllByTimes(n);
        }
        #endregion
        #region 统计单一班级单一学生的全部作业成绩
        /// <summary>
        /// 统计单一班级单一学生的全部作业成绩
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        /// <returns></returns>
        public DataTable SelectAllByStu(stuHomework n)
        {
            return ndao.SelectAllByStu(n);
        }
        #endregion
        #region 学生查看已交全部作业
        /// <summary>
        /// 学生查看已交全部作业
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        /// <returns></returns>
        public DataTable SelectAll(stuHomework n)
        {
            return ndao.SelectAll(n);
        }
        #endregion
        #region 学生查看某班已交全部作业
        /// <summary>
        /// 学生查看某班已交全部作业
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        /// <returns></returns>
        public DataTable SelectAllbyclass(stuHomework n)
        {
            return ndao.SelectAllbyclass(n);
        }
        #endregion
        #region 删除学生作业
        /// <summary>
        /// 删除学生作业
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        /// <returns></returns>
        public bool Delete(stuHomework  n)
        {
            return ndao.Delete(n);
        }
        #endregion
        #region 老师查看各班待批作业次数
        /// <summary>
        /// 老师查看各班待批作业次数
        /// </summary>
        /// <param name="n">教师ID</param>
        /// <returns></returns>
        public DataTable noreviews(string n)
        {
            return ndao.noreviews(n);
        }
        #endregion
        #region 老师查看某班各次作业待批作业次数
        /// <summary>
        /// 老师查看各班待批作业次数
        /// </summary>
        /// <param name="n">教师ID</param>
        /// <returns></returns>
        public DataTable noreviewsbyclass(int n)
        {
            return ndao.noreviewsbyclass(n);
        }
        #endregion
        #region 老师查看某班某次作业待批作业列表
        /// <summary>
        /// 老师查看某班某次作业待批作业列表
        /// </summary>
        /// <param name="n">班级实体表</param>
        /// <returns></returns>
        public DataTable noreviewsbyclasstimes(stuHomework n)
        {
            return ndao.noreviewsbyclasstimes(n);
        }
        #endregion
        #region 学生查看某一班级未交作业次数
        /// <summary>
        /// 学生查看某一班级未交作业次数
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        /// <returns></returns>
        public DataTable SelectCountByStu(stuHomework n)
        {
            return ndao.SelectCountByStu(n);
        }
        #endregion
        #region 查看某一班级某一学生某一次作业是否已交
        /// <summary>
        /// 查看某一班级某一学生某一次作业是否已交
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        /// <returns></returns>
        public DataTable Isexistence(stuHomework n)
        {
            return ndao.Isexistence(n);
        }
        #endregion
    }
}
