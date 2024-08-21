using System;
using System.Linq;
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
        #region 学生提交作业后将互评数据插入互评表
        /// <summary>
        /// 学生提交作业后将互评数据插入互评表
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        /// <returns></returns>
        public void InsertMut_Eval_List(stuHomework n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@studentId",n.StudentId ),
                new SqlParameter("@classId",n.ClassId),
                new SqlParameter("@times",n.Times ),
                new SqlParameter("@modifier",n.Creater),
            };
            DataTable dt=sqlhelper.ExecuteQuery("SELECT teacherId FROM classes WHERE classId=@classId", paras, CommandType.Text);
            paras[3].Value= dt.Rows[0]["teacherId"].ToString();
            sqlhelper.ExecuteNonQuery("INSERT INTO Mut_Eval_List (studentId, classId, times, Eval_User_Id) VALUES (@studentId,@classId,@times,@modifier)", paras, CommandType.Text);

            DataTable dt2 = sqlhelper.ExecuteQuery("SELECT studentId FROM stuCourse WHERE classId=@classId", paras, CommandType.Text);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                paras[3].Value = dt2.Rows[i]["studentId"].ToString();
                sqlhelper.ExecuteNonQuery("INSERT INTO Mut_Eval_List (studentId, classId, times, Eval_User_Id) VALUES (@studentId,@classId,@times,@modifier)", paras, CommandType.Text);
            }
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
            return sqlhelper.ExecuteQuery("SELECT stuHomework.studentId, [content], remarks, results,comment, students.name, students.subject FROM stuHomework  JOIN students on stuHomework.studentId=students.studentId AND classId=@classId AND times=@times", paras, CommandType.Text);
        }
        #endregion
        #region 更新学生作业最终分数
        /// <summary>
        /// 更新学生作业最终分数
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        public void UpdateResult(stuHomework n)
        {

            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@classId",n.ClassId),
                new SqlParameter("@times",n.Times ),
                new SqlParameter("@studentId",n.StudentId ),
                new SqlParameter("@results",n.Results ),
            };
            DataTable ResultList = SelectResult(n);
            string[] IdArray = ResultList.AsEnumerable().Select(d => d.Field<string>("Eval_User_Id")).ToArray();
            int[] ResultArray = ResultList.AsEnumerable().Select(d => d.Field<int>("results")).ToArray();
            double[] WeightArray= new double[IdArray.Length];
            //提高教师权重
            WeightArray[0] = IdArray.Length;
            //计算中位数
            int[] copy = new int[ResultArray.Length];
            ResultArray.CopyTo(copy, 0);
            double med= Median(copy);
            //计算权重
            for (int i = 1; i < ResultArray.Length; i++)            
                if( -20 < med - ResultArray[i] && med - ResultArray[i] < 20)
                    WeightArray[i] = 1;
                else if(-60 < med - ResultArray[i] && med - ResultArray[i] < 60)
                    WeightArray[i] = 0.5;
                else WeightArray[i] = 0.25;
            //计算最终分数
            double x = ResultArray[0] * WeightArray[0];
            for (int i = 1; i < ResultArray.Length; i++)
                x = x + ResultArray[i] * WeightArray[i] + med * (1-WeightArray[i]);
            paras[3].Value=x / (2 * ResultArray.Length - 1);
            sqlhelper.ExecuteNonQuery("UPDATE stuHomework SET results = @results WHERE classId =@classId AND times=@times AND studentId =@studentId", paras, CommandType.Text);
        }
        #endregion
        #region 获得中位数
        /// <summary>
        /// 获得中位数
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        static double Median(int[] array)
        {
            Array.Sort(array);
            double med;
            int len = array.Length;
            if (len % 2 == 0)
                med = (array[len / 2] + array[len / 2 - 1]) / 2d;
            else
                med = array[len / 2];
            return med;
        }
        #endregion
        #region 查询学生作业互评结果
        /// <summary>
        /// 更新学生作业最终分数
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        public DataTable SelectResult(stuHomework n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@classId",n.ClassId),
                new SqlParameter("@times",n.Times ),
                new SqlParameter("@studentId",n.StudentId ),
                new SqlParameter("@results",n.Results ),
            };
            DataTable ResultList = sqlhelper.ExecuteQuery("SELECT Eval_User_Id,results FROM Mut_Eval_List WHERE classId =@classId AND times=@times AND studentId =@studentId order by Eval_User_Id", paras, CommandType.Text);
            return ResultList;
        }
        #endregion
        #region 教师更新学生作业互评分数
        /// <summary>
        /// 教师更新学生作业
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        public void UpdateResultByTea(stuHomework  n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@classId",n.ClassId),
                new SqlParameter("@comment",n.Comment),
                new SqlParameter("@Eval_User_Id",n.Modifier),
                new SqlParameter("@results",n.Results ),
                new SqlParameter("@studentId",n.StudentId ),
                new SqlParameter("@times",n.Times ),
            };
            sqlhelper.ExecuteNonQuery("UPDATE Mut_Eval_List SET results = @results where studentId=@studentId AND classId=@classId AND times=@times AND Eval_User_Id=@Eval_User_Id;UPDATE stuHomework SET comment = @comment,modifier=@Eval_User_Id,lastmodify = getdate() where classId=@classId AND times=@times AND studentId=@studentId", paras, CommandType.Text);
        }
        #endregion
        #region 学生更新互评分数
        /// <summary>
        /// 学生更新互评分数
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        public void UpdateResultByStu(stuHomework n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@studentId",n.StudentId ),
                new SqlParameter("@classId",n.ClassId),
                new SqlParameter("@times",n.Times ),
                new SqlParameter("@results",n.Results ),
                new SqlParameter("@Eval_User_Id",n.Modifier ),
            };
            sqlhelper.ExecuteNonQuery("UPDATE Mut_Eval_List SET results = @results where studentId=@studentId AND classId=@classId AND times=@times AND Eval_User_Id=@Eval_User_Id", paras, CommandType.Text);
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
            return sqlhelper.ExecuteQuery("SELECT  a.classId, a.studentId, times,students.name,students.subject,results FROM (SELECT studentId,classId FROM stuCourse WHERE (classId = @classId)) a inner join students on a.studentId=students.studentId left JOIN stuHomework on a.classId=stuHomework.classId AND a.studentId=stuHomework.studentId AND times=@times order by a.studentId", paras, CommandType.Text);
        }
        #endregion
        #region 统计单一班级单一次数的某个学生全部作业互评情况
        /// <summary>
        /// 统计单一班级单一次数的全部作业成绩
        /// </summary>
        /// <param name="n">学生作业实体类</param>
        /// <returns></returns>
        public DataTable SelectAllByTimesByStu(stuHomework n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@classId",n.ClassId ),
                 new SqlParameter ("@times",n.Times ),
                 new SqlParameter ("@studentId",n.StudentId ),
            };
            if(n.StudentId!=null) return sqlhelper.ExecuteQuery("SELECT  a.classId, a.studentId, times,students.name,students.subject,results FROM (SELECT studentId,classId FROM stuCourse WHERE (classId = @classId)) a inner join students on a.studentId=students.studentId left JOIN Mut_Eval_List on a.classId=Mut_Eval_List.classId AND a.studentId=Mut_Eval_List.studentId AND times=@times AND Mut_Eval_List.Eval_User_Id =@studentId order by times", paras, CommandType.Text);
            return null;
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
            return sqlhelper.ExecuteQuery("	SELECT a.classId,a.times, a.name, a.[content], a.remarks, a.publishTime, a.closeTime,a.referenceAnswer ,stuHomework.times as uptimes,results,comment FROM (SELECT classId,times, name, [content], remarks,CONVERT(varchar(100), publishTime, 23) as publishTime,CONVERT(varchar(100), closeTime, 23) as closeTime,referenceAnswer FROM homeworkList WHERE (classId = @classId)) a left JOIN stuHomework on a.classId=stuHomework.classId AND a.times=stuHomework.times AND studentId=@studentId order by a.times", paras, CommandType.Text);
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
            return sqlhelper.ExecuteQuery("SELECT studentId, classId, times, results FROM stuHomework where studentId=@studentId AND classId=@classId", CommandType.Text);
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
            return sqlhelper.ExecuteQuery("SELECT classes.classId, s.num, classes.name AS classname, classes.term, classes.teacherId FROM classes INNER JOIN teachers ON classes.teacherId = teachers.teacherId left join (SELECT TOP (100) PERCENT classId, num FROM (SELECT classId, COUNT(*) AS num FROM dbo.stuHomework WHERE (results IS NULL) GROUP BY classId) AS t ORDER BY num DESC)as s on classes.classId=s.classId where classes.teacherId=@value order by classes.classId desc", paras, CommandType.Text);
        }
        /// <summary>
        /// 学生查看各班待互评作业次数
        /// </summary>
        /// <param name="n">学生ID</param>
        /// <returns></returns>
        public DataTable no_eval_reviews(string n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@value",n),
            };
            return sqlhelper.ExecuteQuery("SELECT classes.classId,  classes.name AS classname , classes.term FROM stuCourse INNER JOIN classes ON stuCourse.classId=classes.classId WHERE studentId=@value", paras, CommandType.Text);
        }
        #endregion
        #region 查看某班各次作业待批作业次数
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
            return sqlhelper.ExecuteQuery("select homeworkList.classId,homeworkList.times, s.num,name from  homeworkList left join (SELECT     times, classId, COUNT(*) AS num FROM dbo.stuHomework WHERE (results IS NULL) GROUP BY times, classId) as s  on s.classId=homeworkList.classId and s.times=homeworkList.times where homeworkList.classId=@value order by homeworkList.classId desc", paras, CommandType.Text);
        }
        #endregion
        #region 查看某班某次作业待评价作业列表
        /// <summary>
        /// 老师查看某班某次作业待批作业列表
        /// </summary>
        /// <param name="n">学生作业实体表</param>
        /// <returns></returns>
        public DataTable noreviewsbyclasstimes(stuHomework n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@UserId",n.Modifier),
                 new SqlParameter ("@classId",n.ClassId),
                 new SqlParameter ("@times",n.Times),
            };
            return sqlhelper.ExecuteQuery("SELECT stuHomework.studentId,students.name, stuHomework.classId, Mut_Eval_List.results, stuHomework.[content],stuHomework.comment FROM(stuHomework INNER JOIN students ON stuHomework.studentId = students.studentId) INNER JOIN Mut_Eval_List ON  students.studentId = Mut_Eval_List.studentId AND Mut_Eval_List.classId = stuHomework.classId AND Mut_Eval_List.times = stuHomework.times WHERE(stuHomework.classId = @classId) AND(Mut_Eval_List.times = @times)AND(Eval_User_Id = @UserId) order by studentId", paras, CommandType.Text);
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
