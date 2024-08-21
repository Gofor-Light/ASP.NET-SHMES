using System;
namespace MODEL
{
	public class stuCourse
	{
		private int classId;
		public int ClassId
		{ 
			get { return classId; } set { classId = value; }
		} 
		private string studentId;
		public string StudentId
		{ 
			get { return studentId; } set { studentId = value; }
		} 
		private string creater;
		public string Creater
		{ 
			get { return creater; } set { creater = value; }
		} 
		private DateTime createtime;
		public DateTime Createtime
		{ 
			get { return createtime; } set { createtime = value; }
		} 
		private string modifier;
		public string Modifier
		{ 
			get { return modifier; } set { modifier = value; }
		} 
		private DateTime lastmodify;
		public DateTime Lastmodify
		{ 
			get { return lastmodify; } set { lastmodify = value; }
		} 
	}
}
