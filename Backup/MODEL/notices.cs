using System;
using System.Collections.Generic;
using System.Text;
namespace MODEL
{
	public class notices
	{
		private int noticeId;
		public int NoticeId
		{ 
			get { return noticeId; } set { noticeId = value; }
		} 
		private string noticeName;
		public string NoticeName
		{ 
			get { return noticeName; } set { noticeName = value; }
		} 
		private string content;
		public string Content
		{ 
			get { return content; } set { content = value; }
		} 
		private string issuer;
		public string Issuer
		{ 
			get { return issuer; } set { issuer = value; }
		} 
		private DateTime issueTime;
		public DateTime IssueTime
		{ 
			get { return issueTime; } set { issueTime = value; }
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
