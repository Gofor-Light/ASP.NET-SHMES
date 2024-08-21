using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DayiDAO
    {
        private SQLHelper sqlhelper;
        public DayiDAO()
        {
            sqlhelper = new SQLHelper();
        }
        #region 学生提交问题
        /// <summary>
        /// 学生提交问题
        /// </summary>
        /// <param name="n">答疑实体类</param>
        /// <returns></returns>
        public bool Insert(dayi n)
        {
            bool flag = false;
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@classId",n.ClassId),
                new SqlParameter("@creater",n.Creater),
                new SqlParameter("@modifier",n.Creater),
                new SqlParameter("@dayiName",n.DayiName),
                new SqlParameter("@publishTime",n.PublishTime ),
                new SqlParameter("@questionContent",n.QuestionContent ),
                new SqlParameter("@studentId",n.StudentId ),
            };
            int res = sqlhelper.ExecuteNonQuery("INSERT INTO dayi (classId, creater, modifier, dayiName,publishTime, questionContent, studentId) VALUES (@classId,@creater,@creater,@dayiName,@publishTime,@questionContent,@studentId)", paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion
        #region 学生更新问题
        /// <summary>
        /// 学生更新问题
        /// </summary>
        /// <param name="n">答疑实体类</param>
        public void UpdateByStu(dayi n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@classId",n.ClassId),
                new SqlParameter("@modifier",n.Modifier),
                new SqlParameter("@dayiName",n.DayiName),
                new SqlParameter("@publishTime",n.PublishTime ),
                new SqlParameter("@questionContent",n.QuestionContent ),
                new SqlParameter("@dayiId",n.DayiId ),
            };
            sqlhelper.ExecuteQuery("UPDATE dayi SET modifier=@modifier,dayiName = @dayiName,publishTime=@publishTime, questionContent=@questionContent ,lastmodify = getdate() where dayiId=@dayiId ", paras, CommandType.Text);
        }
        #endregion
        #region 教师回答学生疑问
        /// <summary>
        /// 教师回答学生疑问
        /// </summary>
        /// <param name="n">答疑实体类</param>
        public void Answer(dayi n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@answerContent",n.AnswerContent),
                new SqlParameter("@answerTime",n.AnswerTime),
                new SqlParameter("@modifier",n.Modifier),
                new SqlParameter("@dayiId",n.DayiId ),
            };
            sqlhelper.ExecuteQuery("UPDATE dayi SET answerContent = @answerContent,modifier=@modifier,answerTime = @answerTime,lastmodify = getdate() where dayiId=@dayiId", paras, CommandType.Text);
        }
        #endregion
        #region 学生查看已提交的全部问题
        /// <summary>
        /// 学生查看已提交的全部问题
        /// </summary>
        /// <param name="n">学生Id</param>
        /// <returns></returns>
        public DataTable SelectAllByStu(string n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@studentId",n ),
            };
            return sqlhelper.ExecuteQuery("SELECT dayiId, dayiName, questionContent, answerContent FROM dayi where studentId=@studentId", paras,CommandType.Text);
        }
        #endregion
        #region 教师按学期查看全部有关问题
        /// <summary>
        /// 教师按学期查看全部有关问题
        /// </summary>
        /// <param name="n">教师Id</param>
        /// <param name="m">学期</param>
        /// <returns></returns>
        public DataTable SelectAllByTea(string n,string m)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@teacherId",n ),
                 new SqlParameter ("@term",m ),
            };
            return sqlhelper.ExecuteQuery("SELECT dayi.dayiId, classes.name, students.name AS stuName, dayi.dayiName, dayi.questionContent, dayi.publishTime, dayi.answerContent FROM dayi INNER JOIN classes ON dayi.classId = classes.classId INNER JOIN students ON dayi.studentId = students.studentId WHERE classes.term = @term AND classes.teacherId = @teacherId", paras, CommandType.Text);
        }
        #endregion
        #region 查看单一问题的详细信息
        /// <summary>
        /// 查看单一问题的详细信息
        /// </summary>
        /// <param name="n">dayiId</param>
        /// <returns></returns>
        public DataTable Select(int n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@dayiId",n ),
            };
            return sqlhelper.ExecuteQuery("SELECT dayi.dayiId, dayi.studentId, dayi.dayiName, dayi.questionContent, dayi.publishTime, dayi.answerContent, dayi.answerTime, students.name,students.subject, classes.name AS className, classes.term, teachers.name AS teaName FROM dayi INNER JOIN classes ON dayi.classId = classes.classId INNER JOIN teachers ON classes.teacherId = teachers.teacherId INNER JOIN students ON dayi.studentId = students.studentId WHERE dayi.dayiId = @dayiId", paras, CommandType.Text);
        }
        #endregion
        #region 删除问题
        /// <summary>
        /// 删除问题
        /// </summary>
        /// <param name="n">答疑实体类</param>
        /// <returns></returns>
        public bool Delete(dayi n)
        {
            bool flag = false;
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@dayiId",n.DayiId ),
            };
            int res = sqlhelper.ExecuteNonQuery("DELETE FROM dayi where dayiId=@dayiId", paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion             
    }
}
