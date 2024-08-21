using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MODEL;
using System.Data;

namespace BLL
{
    public class StuCourseManage
    {
        private StuCourseDAO ndao = null;
        public StuCourseManage()
        {
            ndao = new StuCourseDAO();
        }
        #region 查看单一学生所选全部班级
        /// <summary>
        /// 查看单一学生所选全部班级
        /// </summary>
        /// <param name="n">学生Id</param>
        /// <returns></returns>
        public DataTable SelectClassByStu(string n)
        {
            return ndao.SelectClassByStu(n);
        }
        #endregion
        #region 查看单一学生单一学期所选全部班级
        /// <summary>
        /// 查看单一学生单一学期所选全部班级
        /// </summary>
        /// <param name="n">学生Id</param>
        /// <param name="m">学期</param>
        /// <returns></returns>
        public DataTable SelectClassByStuTerm(string n, string m)
        {
            return ndao.SelectClassByStuTerm(n, m);
        }
        #endregion
        #region 查看单一教师所教全部班级
        /// <summary>
        /// 查看单一教师所教全部班级
        /// </summary>
        /// <param name="n">教师Id</param>
        /// <returns></returns>
        public DataTable SelectClassByTea(string n)
        {
            return ndao.SelectClassByTea(n);
        }
        #endregion
        #region 查看单一教师单一学期所教全部班级
        /// <summary>
        /// 查看单一教师单一学期所教全部班级
        /// </summary>
        /// <param name="n">教师Id</param>
        /// <param name="m">学期</param>
        /// <returns></returns>
        public DataTable SelectClassByTeaTerm(string n, string m)
        {
            return ndao.SelectClassByTeaTerm(n, m);
        }
        #endregion
        #region 查看一个班所有学生成员
        /// <summary>
        /// 查看一个班所有学生成员
        /// </summary>
        /// <param name="n">选课信息实体类</param>
        /// <returns></returns>
        public DataTable SelectAllstu(stuCourse n)
        {
            return ndao.SelectAllStu(n);
        }
        #endregion
        #region 根据班级Id查看老师Id
        /// <summary>
        /// 根据班级Id查看老师Id
        /// </summary>
        /// <param name="n">班级Id</param>
        /// <returns></returns>
        public DataTable SelectClassByClassId(int n)
        {
            return ndao.SelectClassByClassId(n);
        }
        #endregion
        #region 为班级新增学生成员
        /// <summary>
        /// 为班级新增学生成员
        /// </summary>
        /// <param name="n">选课信息实体类</param>
        /// <returns></returns>
        public bool InsertStu(stuCourse n)
        {
            return ndao.InsertStu(n);
        }
        #endregion
        #region 删除班级学生成员
        /// <summary>
        /// 删除班级学生成员
        /// </summary>
        /// <param name="n">选课信息实体类</param>
        /// <returns></returns>
        public bool DeleteStu(stuCourse n)
        {
            return ndao.DeleteStu(n);
        }
        #endregion
    }
}
