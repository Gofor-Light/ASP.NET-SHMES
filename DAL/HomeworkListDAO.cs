using MODEL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class HomeworkListDAO
    {
        private SQLHelper sqlhelper;
        public HomeworkListDAO()
        {
            sqlhelper = new SQLHelper();
        }
        #region 新增学生作业
        /// <summary>
        /// 新增学生作业
        /// </summary>
        /// <param name="n">作业列表实体类</param>
        /// <returns></returns>
        public bool Insert(homeworkList  n)
        {
            bool flag = false;
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@classId",n.ClassId),
                new SqlParameter("@closeTime",n.CloseTime),
                new SqlParameter("@content",n.Content),
                new SqlParameter("@name",n.Name),
                new SqlParameter("@publishTime",n.PublishTime),
                new SqlParameter("@creater",n.Creater ),
                //new SqlParameter("@referenceAnswer",n.ReferenceAnswer ),
                new SqlParameter("@modifier",n.Creater ),
                new SqlParameter("@remarks",n.Remarks ),
                new SqlParameter("@times",n.Times ),
            };
            int res = sqlhelper.ExecuteNonQuery("INSERT INTO homeworkList (classId, closeTime, [content], name, publishTime,creater,  modifier, remarks, times) VALUES (@classId,@closeTime,@content,@name,@publishTime,@creater,@creater,@remarks,@times)", paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion
        #region 更新学生作业
        /// <summary>
        /// 更新学生作业
        /// </summary>
        /// <param name="n">作业列表实体类</param>
        public void Update(homeworkList  n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@classId",n.ClassId),
                new SqlParameter("@closeTime",n.CloseTime),
                new SqlParameter("@content",n.Content),
                new SqlParameter("@name",n.Name),
                new SqlParameter("@publishTime",n.PublishTime),
                //new SqlParameter("@referenceAnswer",n.ReferenceAnswer ),
                new SqlParameter("@modifier",n.Modifier ),
                new SqlParameter("@remarks",n.Remarks ),
                new SqlParameter("@times",n.Times ),
            };
            sqlhelper.ExecuteQuery("UPDATE homeworkList SET closeTime = @closeTime,[content]=@content,name=@name,publishTime = @publishTime,modifier = @modifier,remarks=@remarks,lastmodify = getdate() where classId=@classId AND times=@times", paras, CommandType.Text);
        }
        #endregion
        #region 删除作业
        /// <summary>
        /// 删除作业
        /// </summary>
        /// <param name="n">作业列表实体类</param>
        /// <returns></returns>
        public bool DeleteHomework(homeworkList n)
        {
            bool flag = false;
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@classId",n.ClassId),
                new SqlParameter("@times",n.Times),
            };
            int res = sqlhelper.ExecuteNonQuery("DELETE FROM homeworkList where classId=@classId AND times=@times", paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
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
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@classId",n ),
            };
            return sqlhelper.ExecuteQuery("SELECT classId,times, name, [content], remarks,CONVERT(varchar(100), publishTime, 23) as publishTime,CONVERT(varchar(100), closeTime, 23) as closeTime,referenceAnswer FROM homeworkList WHERE classId=@classId order by times ", paras, CommandType.Text);
        }
        #endregion
        #region 查看某一班级已布置到最高作业的次数
        /// <summary>
        /// 查看某一班级已布置到最高作业的次数
        /// </summary>
        /// <param name="n">班级ID</param>
        /// <returns></returns>
        public DataTable SelectTime(int n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@classId",n ),
            };
            return sqlhelper.ExecuteQuery("SELECT top(1) times FROM homeworkList WHERE classId=@classId order by times DESC ", paras, CommandType.Text);
        }
        #endregion

    }
}
