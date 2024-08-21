using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MODEL;
using System.Data;

namespace BLL
{
    public class NoticesManage
    {
        private NoticesDAO ndao = null;
        public NoticesManage()
        {
            ndao = new NoticesDAO();
        }
        #region 新增公告
        /// <summary>
        /// 新增公告
        /// </summary>
        /// <param name="n">公告信息实体类</param>
        /// <returns></returns>
        public bool Insert(notices  n)
        {
            return ndao.Insert(n);
        }
        #endregion
        #region 更新公告信息
        /// <summary>
        /// 更新公告信息
        /// </summary>
        /// <param name="n">公告信息实体类</param>
        /// <returns></returns>
        public void Update(notices n)
        {
            ndao.Update(n);
        }
        #endregion
        #region 查看全部公告
        /// <summary>
        /// 查看全部公告
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAll()
        {
            return ndao.SelectAll();
        }
        #endregion
        #region 查看最近5条公告
        /// <summary>
        /// 查看最近5条公告
        /// </summary>
        /// <returns></returns>
        public DataTable SelecTop()
        {
            return ndao.SelecTop();
        }
        #endregion
        #region 按公告名查看公告
        /// <summary>
        /// 按公告名查看公告
        /// </summary>
        /// <returns></returns>
        public DataTable SelectByName(string n)
        {
            return ndao.SelectByName(n);
        }
        #endregion
        #region 查看单一公告详细信息
        /// <summary>
        /// 查看单一公告详细信息
        /// </summary>
        /// <param name="n">公告信息实体类</param>
        /// <returns></returns>
        public DataTable Select(notices n)
        {
            return ndao.Select(n);
        }
        #endregion
        #region 删除公告
        /// <summary>
        /// 删除公告
        /// </summary>
        /// <param name="n">公告信息实体类</param>
        /// <returns></returns>
        public bool Delete(notices  n)
        {
            return ndao.Delete(n);
        }
        #endregion
    }
}
