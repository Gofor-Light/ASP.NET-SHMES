using DAL;
using MODEL;
using System.Data;

namespace BLL
{
    public class TeachersManage
    {        
        private TeacherDAO ndao = null;
        public TeachersManage()
        {
            ndao = new TeacherDAO();
        }
        #region 选择全部教师信息
        /// <summary>
        /// 选择全部教师信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAll()
        {
            return ndao.SelectAll();
        }
        #endregion
        #region 按条件选择教师信息
        /// <summary>
        /// 按条件选择教师信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectByValue(string n)
        {
            return ndao.SelectByValue(n);
        }
        #endregion
        #region 更新教师信息
        /// <summary>
        /// 更新教师信息
        /// </summary>
        /// <param name="n">教师信息实体类</param>
        /// <returns></returns>
        public void Update(teachers n)
        {
            ndao.Update(n);
        }
        #endregion
        #region 更改教师登录密码
        /// <summary>
        /// 更改教师登录密码
        /// </summary>
        /// <param name="n">教师信息实体类</param>
        /// <returns></returns>
        public void UpdatePwd(teachers n)
        {
            ndao.UpdatePwd(n);
        }
        #endregion
        #region 添加新教师信息
        /// <summary>
        /// 添加新教师信息
        /// </summary>
        /// <param name="n">教师信息实体类</param>
        /// <returns></returns>
        public bool Insert(teachers  n)
        {
            return ndao.Insert(n);
        }
        #endregion
        #region 教师登陆是否成功
        /// <summary>
        /// 教师登陆是否成功
        /// </summary>
        /// <param name="name">账号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public bool Login(string name, string pwd)
        {
            return ndao.Login(name, pwd);
        }
        #endregion
        #region 检验新增加的教师账号是否已被注册
        /// <summary>
        /// 检验新增加的教师账号是否已被注册
        /// </summary>
        /// <param name="teacherId">账号</param>
        /// <returns></returns>
        public bool Check(string teacherId)
        {
            return ndao.Check(teacherId );
        }
        #endregion
    }
}
