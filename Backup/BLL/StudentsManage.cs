using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MODEL;
using System.Data;

namespace BLL
{
    public class StudentsManage
    {        
        private StudentsDAO ndao = null;
        public StudentsManage()
        {
            ndao = new StudentsDAO ();
        }
        #region 选择全部学生信息
        /// <summary>
        /// 选择全部学生信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAll()
        {
            return ndao.SelectAll();
        }
        #endregion
        #region 按条件选择学生信息
        /// <summary>
        /// 按条件选择学生信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectByValue(string n)
        {
            return ndao.SelectByValue(n);
        }
        #endregion
        #region 更新学生信息
        /// <summary>
        /// 更新学生信息
        /// </summary>
        /// <param name="n">学生信息实体类</param>
        /// <returns></returns>
        public void Update(students n)
        {
            ndao.Update(n);
        }
        #endregion
        #region 更改学生登录密码
        /// <summary>
        /// 更改学生登录密码
        /// </summary>
        /// <param name="n">学生信息实体类</param>
        /// <returns></returns>
        public void UpdatePwd(students n)
        {
            ndao.UpdatePwd(n);
        }
        #endregion
        #region 添加新学生信息
        /// <summary>
        /// 添加新学生信息
        /// </summary>
        /// <param name="n">学生信息实体类</param>
        /// <returns></returns>
        public bool Insert(students n)
        {
            return ndao.Insert(n);
        }
        #endregion
        #region 学生登陆是否成功
        /// <summary>
        /// 学生登陆是否成功
        /// </summary>
        /// <param name="name">账号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public bool Login(string name, string pwd)
        {
            return ndao.Login(name, pwd);
        }
        #endregion
        #region 检验新增加的学生账号是否已被注册
        /// <summary>
        /// 检验新增加的学生账号是否已被注册
        /// </summary>
        /// <param name="studentId">账号</param>
        /// <returns></returns>
        public bool Check(string studentId)
        {
            return ndao.Check(studentId );
        }
        #endregion
    }
}
