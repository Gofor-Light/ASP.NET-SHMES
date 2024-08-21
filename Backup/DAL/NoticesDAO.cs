using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class NoticesDAO
    {
        private SQLHelper sqlhelper;
        public NoticesDAO()
        {
            sqlhelper = new SQLHelper();
        }
        #region 新增公告
        /// <summary>
        /// 新增公告
        /// </summary>
        /// <param name="n">公告信息实体类</param>
        /// <returns></returns>
        public bool Insert(notices  n)
        {
            bool flag = false;
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@content",n.Content),
                new SqlParameter("@issuer",n.Issuer),
                new SqlParameter("@issueTime",n.IssueTime),
                new SqlParameter("@noticeName",n.NoticeName),
                new SqlParameter("@creater",n.Creater),
                new SqlParameter("@modifier",n.Creater),
            };
            int res = sqlhelper.ExecuteNonQuery("INSERT INTO notices ([content],issuer,issueTime,noticeName, creater, modifier) VALUES (@content,@issuer,@issueTime,@noticeName,@creater,@modifier)", paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion
        #region 更新公告信息
        /// <summary>
        /// 更新公告信息
        /// </summary>
        /// <param name="n">公告信息实体类</param>
        public void Update(notices  n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@content",n.Content),
                new SqlParameter("@issuer",n.Issuer),
                new SqlParameter("@issueTime",n.IssueTime),
                new SqlParameter("@noticeId",n.NoticeId),
                new SqlParameter("@noticeName",n.NoticeName),
                new SqlParameter("@modifier",n.Modifier),
            };
            sqlhelper.ExecuteQuery("UPDATE notices SET noticeName=@noticeName, modifier=@modifier,[content] = @content,issuer=@issuer, issueTime=@issueTime ,lastmodify = getdate() where noticeId=@noticeId ", paras, CommandType.Text);
        }
        #endregion
        #region 查看全部公告
        /// <summary>
        /// 查看全部公告
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAll()
        {
            return sqlhelper.ExecuteQuery("SELECT noticeId, noticeName, [content],  CONVERT(varchar(100), issueTime, 23) as issueTime, issuer FROM notices", CommandType.Text);
        }
        #endregion
        #region 按条件查看公告
        /// <summary>
        /// 按条件查看公告
        /// </summary>
        /// <returns></returns>
        public DataTable SelectByName(string n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@value",n ),
            };
            return sqlhelper.ExecuteQuery("SELECT noticeId, noticeName, [content],  CONVERT(varchar(100), issueTime, 23) as issueTime, issuer FROM notices WHERE noticeName like '%'+@value+'%' ", paras, CommandType.Text);
        }
        #endregion
        #region 查看最新5个公告
        /// <summary>
        /// 查看最新5个公告
        /// </summary>
        /// <returns></returns>
        public DataTable SelecTop()
        {
            return sqlhelper.ExecuteQuery("SELECT top(10) noticeId, noticeName, [content],  CONVERT(varchar(100), issueTime, 23) as issueTime, issuer FROM notices", CommandType.Text);
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
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@noticeId",n.NoticeId),
            };
            return sqlhelper.ExecuteQuery("SELECT noticeId, noticeName, [content], CONVERT(varchar(100), issueTime, 23) as issueTime, issuer FROM notices WHERE noticeId=@noticeId", paras, CommandType.Text);
        }
        #endregion
        #region 删除公告
        /// <summary>
        /// 删除公告
        /// </summary>
        /// <param name="n">公告信息实体类</param>
        /// <returns></returns>
        public bool Delete(notices n)
        {
            bool flag = false;
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@noticeId",n.NoticeId ),
            };
            int res = sqlhelper.ExecuteNonQuery("DELETE FROM notices where noticeId=@noticeId", paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion             
    }
}
