using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ClassesDAO
    {
        private SQLHelper sqlhelper;
        public ClassesDAO()
        {
            sqlhelper = new SQLHelper();
        }
        #region 选择全部班级信息
        /// <summary>
        /// 选择全部班级信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllClass()
        {
            return sqlhelper.ExecuteQuery("SELECT teachers.name, classes.classId, classes.name AS classname, classes.term, classes.teacherId FROM classes INNER JOIN teachers ON classes.teacherId = teachers.teacherId", CommandType.Text);
        }
        #endregion
        #region 按条件选择班级信息
        /// <summary>
        /// 按条件选择班级信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectClassByValue( string n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@value",n ),
            };
            return sqlhelper.ExecuteQuery("SELECT teachers.name, classes.classId, classes.name AS classname, classes.term, classes.teacherId FROM classes INNER JOIN teachers ON classes.teacherId = teachers.teacherId WHERE teachers.teacherId=@value   or classes.name like '%'+@value+'%' or teachers.name like '%'+@value+'%' order by term desc", paras, CommandType.Text);
        }
        #endregion
        #region 依班级ID查看班级信息
        /// <summary>
        /// 依班级ID查看班级信息
        /// </summary>
        /// <returns></returns>
        public DataTable SelectClassByClassId(int n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter ("@value",n ),
            };
            return sqlhelper.ExecuteQuery("SELECT teachers.name, classes.classId, classes.name AS classname, classes.term, classes.teacherId FROM classes INNER JOIN teachers ON classes.teacherId = teachers.teacherId WHERE classes.classId=@value", paras, CommandType.Text);
        }
        #endregion
        #region 更新班级信息
        /// <summary>
        /// 更新班级信息
        /// </summary>
        /// <param name="n">班级信息实体类</param>
        public void UpdateClass(classes n)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter ("@name",n.Name),
                new SqlParameter ("@term",n.Term),  
                new SqlParameter ("@teacherId",n.TeacherId),
                new SqlParameter ("@modifier",n.Modifier),
                new SqlParameter ("@classId",n.ClassId),
            };
            sqlhelper.ExecuteQuery("UPDATE classes SET name = @name,term = @term,teacherId=@teacherId,modifier = @modifier,lastmodify = getdate() where classId=@classId", paras, CommandType.Text);
        }
        #endregion
        #region 新增班级
        /// <summary>
        /// 新增班级
        /// </summary>
        /// <param name="n">班级信息实体类</param>
        /// <returns></returns>
        public bool InsertClass(classes n)
        {
            bool flag = false;
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@name",n.Name),
                new SqlParameter("@teacherId",n.TeacherId),
                new SqlParameter("@term",n.Term),
                new SqlParameter("@creater",n.Creater ),
                new SqlParameter("@modifier",n.Creater ),
            };
            int res = sqlhelper.ExecuteNonQuery("INSERT INTO classes (name, teacherId, term,  creater, modifier) VALUES (@name,@teacherId,@term,@creater,@creater)", paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion
        #region 删除班级
        /// <summary>
        /// 删除班级
        /// </summary>
        /// <param name="n">班级信息实体类</param>
        /// <returns></returns>
        public bool DeleteClass(classes n)
        {
            bool flag = false;
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@classId",n.ClassId),
            };
            int res = sqlhelper.ExecuteNonQuery("DELETE FROM classes where classId=@classId", paras, CommandType.Text);
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion             
    }
}
