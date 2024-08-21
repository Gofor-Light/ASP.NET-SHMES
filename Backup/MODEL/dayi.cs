using System;
using System.Collections.Generic;
using System.Text;
namespace MODEL
{
	public class dayi
	{
		private int dayiId;
		public int DayiId
		{ 
			get { return dayiId; } set { dayiId = value; }
		} 
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
		private string dayiName;
		public string DayiName
		{ 
			get { return dayiName; } set { dayiName = value; }
		} 
		private string questionContent;
		public string QuestionContent
		{ 
			get { return questionContent; } set { questionContent = value; }
		} 
		private DateTime publishTime;
		public DateTime PublishTime
		{ 
			get { return publishTime; } set { publishTime = value; }
		} 
		private string answerContent;
		public string AnswerContent
		{ 
			get { return answerContent; } set { answerContent = value; }
		} 
		private DateTime answerTime;
		public DateTime AnswerTime
		{ 
			get { return answerTime; } set { answerTime = value; }
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
