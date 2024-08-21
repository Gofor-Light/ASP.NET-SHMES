using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MODEL;
using System.Data;

namespace BLL
{
    public class AdminsManage
    {
        private AdminsDAO ndao = null;
        public AdminsManage()
        {
            ndao = new AdminsDAO();
        }
        #region 选择管理员信息
        /// <summary>
        /// 选择管理员信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAll()
        {
            return ndao.SelectAll();
        }
        #endregion
        #region 查看单个管理员信息
        /// <summary>
        /// 查看单个管理员信息
        /// </summary>
        /// <param name="n">管理员Id</param>
        /// <returns></returns>
        public DataTable Select(string n)
        {
            return ndao.Select(n);
        }
        #endregion
        #region 更新管理员信息
        /// <summary>
        /// 更新管理员信息
        /// </summary>
        /// <param name="n">管理员信息实体类</param>
        /// <returns></returns>
        public void Update(admins n)
        {
            ndao.Update(n);
        }
        #endregion
        #region 更新管理员密码
        /// <summary>
        /// 更新管理员密码
        /// </summary>
        /// <param name="n">管理员信息实体类</param>
        /// <returns></returns>
        public void UpdatePwd(admins n)
        {
            ndao.UpdatePwd(n);
        }
        #endregion
        #region 添加新管理员信息
        /// <summary>
        /// 添加新管理员信息
        /// </summary>
        /// <param name="n">管理员信息实体类</param>
        /// <returns></returns>
        public bool Insert(admins  n)
        {
            return ndao.Insert(n);
        }
        #endregion
        #region 管理员登陆是否成功
        /// <summary>
        /// 管理员登陆是否成功
        /// </summary>
        /// <param name="name">账号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public bool Login(string name,string pwd)
        {
            return ndao.Login(name,pwd);
        }
        #endregion
        #region 检验新增加的管理员账号是否已被注册
        /// <summary>
        /// 检验新增加的管理员账号是否已被注册
        /// </summary>
        /// <param name="adminId">账号</param>
        /// <returns></returns>
        public bool Check(string adminId)
        {
            return ndao.Check(adminId);
        }
        #endregion
    }
}
