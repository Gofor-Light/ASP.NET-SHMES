using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MODEL;
using System.Data;

namespace BLL
{
    public class ClassesManage
    {
         private ClassesDAO ndao = null;
         public ClassesManage()
        {
            ndao = new ClassesDAO ();
        }
        #region 选择全部班级信息
        /// <summary>
         /// 选择全部班级信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllClass()
        {
            return ndao.SelectAllClass();
        }
        #endregion
        #region 按条件选择班级信息
        /// <summary>
        /// 按条件选择班级信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectClassByValue(string n)
        {
            return ndao.SelectClassByValue(n);
        }
        #endregion
        #region 依班级Id查看班级信息
        /// <summary>
        /// 依班级Id查看班级信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectClassByClassId(int n)
        {
            return ndao.SelectClassByClassId(n);
        }
        #endregion
        #region 更新班级信息
        /// <summary>
        /// 更新班级信息
        /// </summary>
        /// <param name="n">班级信息实体类</param>
        /// <returns></returns>
        public void UpdateClass(classes n)
        {
            ndao.UpdateClass(n);
        }
        #endregion
        #region 新增班级
        /// <summary>
        /// 新增班级
        /// </summary>
        /// <param name="n">班级信息实体类</param>
        /// <returns></returns>
        public bool InsertClass(classes  n)
        {
            return ndao.InsertClass(n);
        }
        #endregion
        #region 删除班级
        /// <summary>
        /// 删除班级
        /// </summary>
        /// <param name="n">班级信息实体类</param>
        /// <returns></returns>
        public bool DeleteClass(classes n)
        {
            return ndao.DeleteClass(n);
        }
        #endregion       
    }
}
