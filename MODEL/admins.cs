using System;
namespace MODEL
{
	public class admins
	{
		private string adminId;
		public string AdminId
		{ 
			get { return adminId; } set { adminId = value; }
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
		private DateTime createTime;
		public DateTime CreateTime
		{ 
			get { return createTime; } set { createTime = value; }
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
