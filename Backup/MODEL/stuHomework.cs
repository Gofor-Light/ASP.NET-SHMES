using System;
using System.Collections.Generic;
using System.Text;
namespace MODEL
{
	public class stuHomework
	{
		private string studentId;
		public string StudentId
		{ 
			get { return studentId; } set { studentId = value; }
		} 
		private int classId;
		public int ClassId
		{ 
			get { return classId; } set { classId = value; }
		} 
		private int times;
		public int Times
		{ 
			get { return times; } set { times = value; }
		} 
		private string content;
		public string Content
		{ 
			get { return content; } set { content = value; }
		} 
		private string remarks;
		public string Remarks
		{ 
			get { return remarks; } set { remarks = value; }
		} 
		private int results;
		public int Results
		{ 
			get { return results; } set { results = value; }
		} 
		private string comment;
		public string Comment
		{ 
			get { return comment; } set { comment = value; }
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
