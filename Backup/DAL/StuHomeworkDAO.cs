using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class StuHomeworkDAO
    {
        private SQLHelper sqlhelper;
        public StuHomeworkDAO()
        {
            sqlhelper = new SQLHelper();
        }
        #region 学生提交作业
        /// <summary>
        /// 学生提交作业
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        /// <returns></returns>
        public bool Insert(stuHomework n)
        {
            bool flag = false;
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@classId",n.ClassId),
                new SqlParameter("@content",n.Content),
                new SqlParameter("@creater",n.Creater),
                new SqlParameter("@modifier",n.Creater),
                new SqlParameter("@studentId",n.StudentId ),
                new SqlParameter("@times",n.Times ),
            };
            int res = sqlhelper.ExecuteNonQuery("INSERT INTO stuHomework (classId, [content], creater, modifier, studentId, times) VALUES (@classId,@content,@creater,@creater,@studentId,@times)", paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion
        #region 查看单一班级单一次数已交作业列表
        /// <summary>
        /// 查看单一班级单一次数已交作业列表
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        /// <returns></returns>
        public DataTable SelectByClass(stuHomework  n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@classId",n.ClassId ),
                 new SqlParameter ("@times",n.Times ),
            };
            return sqlhelper.ExecuteQuery("SELECT stuHomework.studentId, [content], remarks, results,comment, students.name, students.subject FROM stuHomework  JOIN students on stuHomework.studentId=students.studentId AND classId=@classId AND times=@times ", paras, CommandType.Text);
        }
        #endregion
        #region 学生更新学生作业
        /// <summary>
        /// 学生更新学生作业
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        public void UpdateByStu(stuHomework  n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@classId",n.ClassId),
                new SqlParameter("@content",n.Content),
                new SqlParameter("@modifier",n.Modifier),
                new SqlParameter("@remarks",n.Remarks ),
                new SqlParameter("@studentId",n.StudentId ),
                new SqlParameter("@times",n.Times ),
            };
            sqlhelper.ExecuteQuery("UPDATE stuHomework SET [content]=@content,modifier=@modifier,remarks = @remarks,lastmodify = getdate() where classId=@classId AND times=@times AND studentId=@studentId", paras, CommandType.Text);
        }
        #endregion
        #region 教师更新学生作业
        /// <summary>
        /// 教师更新学生作业
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        public void UpdateByTea(stuHomework  n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@classId",n.ClassId),
                new SqlParameter("@comment",n.Comment),
                new SqlParameter("@modifier",n.Modifier),
                new SqlParameter("@results",n.Results ),
                new SqlParameter("@studentId",n.StudentId ),
                new SqlParameter("@times",n.Times ),
            };
            sqlhelper.ExecuteQuery("UPDATE stuHomework SET comment = @comment,modifier=@modifier,results = @results,lastmodify = getdate() where classId=@classId AND times=@times AND studentId=@studentId", paras, CommandType.Text);
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
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@classId",n.ClassId ),
                 new SqlParameter ("@times",n.Times ),
            };
            return sqlhelper.ExecuteQuery("SELECT  a.classId, a.studentId, times,students.name,students.subject,results FROM (SELECT studentId,classId FROM stuCourse WHERE (classId = @classId)) a inner join students on a.studentId=students.studentId left JOIN stuHomework on a.classId=stuHomework.classId AND a.studentId=stuHomework.studentId AND times=@times order by times", paras, CommandType.Text);
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
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@classId",n.ClassId ),
                 new SqlParameter ("@studentId",n.StudentId ),
            };
            return sqlhelper.ExecuteQuery("	SELECT a.classId,a.times, a.name, a.[content], a.remarks, a.publishTime, a.closeTime,a.referenceAnswer ,stuHomework.times as uptimes,results,comment FROM (SELECT classId,times, name, [content], remarks,CONVERT(varchar(100), publishTime, 23) as publishTime,CONVERT(varchar(100), closeTime, 23) as closeTime,referenceAnswer FROM homeworkList WHERE (classId = @classId)) a left JOIN stuHomework on a.classId=stuHomework.classId AND a.times=stuHomework.times AND studentId=@studentId order by results", paras, CommandType.Text);
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
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@studentId",n.StudentId ),
            };
            return sqlhelper.ExecuteQuery("SELECT studentId, classId, times, results FROM stuHomework where studentId=@studentId", CommandType.Text);
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
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@studentId",n.StudentId ),
                 new SqlParameter ("@classId",n.ClassId ),
            };
            return sqlhelper.ExecuteQuery("SELECT studentId, classId, times, results FROM stuHomework where studentId='0711010098' AND classId=7", CommandType.Text);
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
            bool flag = false;
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@classId",n.ClassId),
                new SqlParameter("@times",n.Times),
                new SqlParameter("@studentId",n.StudentId ),
            };
            int res = sqlhelper.ExecuteNonQuery("DELETE FROM stuHomework where classId=@classId AND times=@times AND studentId=@studentId", paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion
        #region 老师查看各班待批作业次数
        /// <summary>
        /// 老师查看各班待批作业次数
        /// </summary>
        /// <param name="n">老师ID</param>
        /// <returns></returns>
        public DataTable noreviews(string n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@value",n),
            };
            return sqlhelper.ExecuteQuery("SELECT classes.classId, s.num, classes.name AS classname, classes.term, classes.teacherId FROM classes INNER JOIN teachers ON classes.teacherId = teachers.teacherId left join (SELECT TOP (100) PERCENT classId, num FROM (SELECT classId, COUNT(*) AS num FROM dbo.stuHomework WHERE (results IS NULL) GROUP BY classId) AS t ORDER BY num DESC)as s on classes.classId=s.classId where classes.teacherId=@value order by s.num desc", paras, CommandType.Text);
        }
        #endregion
        #region 老师查看某班各次作业待批作业次数
        /// <summary>
        /// 老师查看某班各次作业待批作业次数
        /// </summary>
        /// <param name="n">班级ID</param>
        /// <returns></returns>
        public DataTable noreviewsbyclass(int n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@value",n),
            };
            return sqlhelper.ExecuteQuery("select homeworkList.classId,homeworkList.times, s.num,name from  homeworkList left join (SELECT     times, classId, COUNT(*) AS num FROM dbo.stuHomework WHERE (results IS NULL) GROUP BY times, classId) as s  on s.classId=homeworkList.classId and s.times=homeworkList.times where homeworkList.classId=@value order by s.num desc", paras, CommandType.Text);
        }
        #endregion
        #region 老师查看某班某次作业待批作业列表
        /// <summary>
        /// 老师查看某班某次作业待批作业列表
        /// </summary>
        /// <param name="n">学生作业实体表</param>
        /// <returns></returns>
        public DataTable noreviewsbyclasstimes(stuHomework n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@classId",n.ClassId),
                 new SqlParameter ("@times",n.Times),
            };
            return sqlhelper.ExecuteQuery("SELECT stuHomework.studentId, stuHomework.classId, stuHomework.times, students.name, stuHomework.results, stuHomework.[content],stuHomework.comment FROM stuHomework INNER JOIN students ON stuHomework.studentId = students.studentId WHERE (stuHomework.classId = @classId) AND (stuHomework.times = @times) order by results", paras, CommandType.Text);
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
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@classId",n.ClassId ),
                 new SqlParameter ("@studentId",n.StudentId ),
            };
            return sqlhelper.ExecuteQuery("SELECT count(*) from stuHomework  WHERE (classId = @classId)  AND  studentId=@studentId group by studentId", paras, CommandType.Text);
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
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@classId",n.ClassId ),
                 new SqlParameter ("@studentId",n.StudentId ),
                 new SqlParameter ("@times",n.Times ),
            };
            return sqlhelper.ExecuteQuery("SELECT * from stuHomework  WHERE (classId = @classId)  AND  studentId=@studentId AND times=@times", paras, CommandType.Text);
        }
        #endregion
    }
}
