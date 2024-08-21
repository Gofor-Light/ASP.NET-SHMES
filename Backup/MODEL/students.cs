using System;
using System.Collections.Generic;
using System.Text;
namespace MODEL
{
	public class students
	{
		private string studentId;
		public string StudentId
		{ 
			get { return studentId; } set { studentId = value; }
		} 
		private string name;
		public string Name
		{ 
			get { return name; } set { name = value; }
		} 
		private string pwd;
		public string Pwd
		{ 
			get { return pwd; } set { pwd = value; }
		}
        private string sex;
        public string Sex
        {
            get { return sex; } set { sex = value; }
        } 
		private string subject;
		public string Subject
		{ 
			get { return subject; } set { subject = value; }
		} 
		private string college;
		public string College
		{ 
			get { return college; } set { college = value; }
		} 
		private string cellphone;
		public string Cellphone
		{ 
			get { return cellphone; } set { cellphone = value; }
		} 
		private string email;
		public string Email
		{ 
			get { return email; } set { email = value; }
		} 
		private string creater;
		public string Creater
		{ 
			get { return creater; } set { creater = value; }
		} 
		private DateTime creatertime;
		public DateTime Creatertime
		{ 
			get { return creatertime; } set { creatertime = value; }
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
