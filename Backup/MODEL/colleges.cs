using System;
using System.Collections.Generic;
using System.Text;
namespace MODEL
{
	public class colleges
	{
		private string college;
		public string College
		{ 
			get { return college; } set { college = value; }
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
