using MODEL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class StuCourseDAO
    {
         private SQLHelper sqlhelper;
         public StuCourseDAO()
         {
             sqlhelper = new SQLHelper();
         }
         #region 查看单一学生所选全部班级
         /// <summary>
         /// 查看单一学生所选全部班级
         /// </summary>
         /// <param name="n">学生Id</param>
         /// <returns></returns>
         public DataTable SelectClassByStu(string n)
         {
             SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@value",n ),
            };
             return sqlhelper.ExecuteQuery("SELECT teachers.name AS teacherName , classes.classId, classes.name AS className, classes.term, classes.teacherId FROM classes INNER JOIN teachers ON classes.teacherId = teachers.teacherId INNER JOIN stuCourse ON classes.classId = stuCourse.classId WHERE  stuCourse.studentId=@value", paras, CommandType.Text);
         }
         #endregion
         #region 查看单一学生单一学期所选全部班级
         /// <summary>
         /// 查看单一学生单一学期所选全部班级
         /// </summary>
         /// <param name="n">学生Id</param>
         /// <param name="m">学期</param>
         /// <returns></returns>
         public DataTable SelectClassByStuTerm(string n,string m)
         {
             SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@studentId",n ),
                 new SqlParameter ("@term",m ),
            };
             return sqlhelper.ExecuteQuery("SELECT teachers.name AS teacherName , classes.classId, classes.name AS className, classes.teacherId FROM classes INNER JOIN teachers ON classes.teacherId = teachers.teacherId INNER JOIN stuCourse ON classes.classId = stuCourse.classId WHERE  stuCourse.studentId=@studentId AND classes.term=@term", paras, CommandType.Text);
         }
         #endregion
         #region 查看单一教师所教全部班级
         /// <summary>
         /// 查看单一教师所教全部班级
         /// </summary>
         /// <param name="n">教师Id</param>
         /// <returns></returns>
         public DataTable SelectClassByTea(string n)
         {
             SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@value",n ),
            };
             return sqlhelper.ExecuteQuery("SELECT classes.classId, classes.name AS className, classes.term FROM classes INNER JOIN teachers ON classes.teacherId = teachers.teacherId WHERE  classes.teacherId=@value", paras, CommandType.Text);
         }
         #endregion
         #region 查看单一教师单一学期所教全部班级
         /// <summary>
         /// 查看单一教师单一学期所教全部班级
         /// </summary>
         /// <param name="n">教师Id</param>
         /// <param name="m">学期</param>
         /// <returns></returns>
         public DataTable SelectClassByTeaTerm(string n,string m)
         {
             SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@teacherId",n ),
                 new SqlParameter ("@term",m ),
            };
             return sqlhelper.ExecuteQuery("SELECT classes.classId, classes.name AS className FROM classes INNER JOIN teachers ON classes.teacherId = teachers.teacherId WHERE  classes.teacherId=@teacherId AND classes.term=@term", paras, CommandType.Text);
         }
         #endregion
         #region 查看一个班所有学生成员
         /// <summary>
         /// 查看一个班的所有学生成员
         /// </summary>
         /// <param name="n">选课信息实体类</param>
         /// <returns></returns>
         public DataTable SelectAllStu(int n)
         {
             SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@classId",n ),
            };
             return sqlhelper.ExecuteQuery("SELECT stuCourse.studentId, stuCourse.classId, students.name, students.subject,students.cellphone,students.email, students.college FROM stuCourse INNER JOIN  students ON stuCourse.studentId = students.studentId WHERE stuCourse.classId=@classId", paras, CommandType.Text);
         }
         #endregion
         #region 根据班级Id查看老师Id
         /// <summary>
         /// 根据班级Id查看老师Id
         /// </summary>
         /// <param name="n">班级Id</param>
         /// <returns></returns>
         public DataTable SelectClassByClassId(int n)
         {
             SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@value",n ),
            };
             return sqlhelper.ExecuteQuery("SELECT name, teacherId, classId FROM   classes WHERE (classId = @value)", paras, CommandType.Text);
         }
         #endregion
         #region 为班级新增学生成员
         /// <summary>
         /// 为班级新增学生成员
         /// </summary>
         /// <param name="n">选课信息实体类</param>
         /// <returns></returns>
         public bool InsertStu(stuCourse n)
         {
             bool flag = false;
             SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@classId",n.ClassId),
                new SqlParameter("@studentId",n.StudentId),
                new SqlParameter("@creater",n.Creater ),
                new SqlParameter("@modifier",n.Creater ),
            };
             int res = sqlhelper.ExecuteNonQuery("INSERT INTO stuCourse (classId, studentId,  creater, modifier) VALUES (@classId,@studentId,@creater,@creater)", paras, CommandType.Text);
             if (res > 0)
             {
                 flag = true;
             }
             return flag;
         }
         #endregion
         #region 删除班级学生成员
         /// <summary>
         /// 删除班级学生成员
         /// </summary>
         /// <param name="n">选课信息实体类</param>
         /// <returns></returns>
         public bool DeleteStu(stuCourse n)
         {
             bool flag = false;
             SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@classId",n.ClassId),
                new SqlParameter("@studentId",n.StudentId),
            };
             int res = sqlhelper.ExecuteNonQuery("DELETE FROM stuCourse where classId=@classId AND studentId=@studentId", paras, CommandType.Text);
             if (res > 0)
             {
                 flag = true;
             }
             return flag;
         }
         #endregion
    }
}
