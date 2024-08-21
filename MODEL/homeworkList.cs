using System;
namespace MODEL
{
	public class homeworkList
	{
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
		private string name;
		public string Name
		{ 
			get { return name; } set { name = value; }
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
		private DateTime publishTime;
		public DateTime PublishTime
		{ 
			get { return publishTime; } set { publishTime = value; }
		} 
		private DateTime closeTime;
		public DateTime CloseTime
		{ 
			get { return closeTime; } set { closeTime = value; }
		} 
		private string referenceAnswer;
		public string ReferenceAnswer
		{ 
			get { return referenceAnswer; } set { referenceAnswer = value; }
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
