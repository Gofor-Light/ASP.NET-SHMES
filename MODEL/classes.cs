using System;
namespace MODEL
{
	public class classes
	{
		private int classId;
		public int ClassId
		{ 
			get { return classId; } set { classId = value; }
		} 
		private string name;
		public string Name
		{ 
			get { return name; } set { name = value; }
		} 
		private string term;
		public string Term
		{ 
			get { return term; } set { term = value; }
		} 
		private string teacherId;
		public string TeacherId
		{ 
			get { return teacherId; } set { teacherId = value; }
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
