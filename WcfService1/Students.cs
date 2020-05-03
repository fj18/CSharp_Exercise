using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1
{
	public class Student
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int Score { get; set; }
		public string OtherInfo { get; set; }
		
		public Student()
		{
			ID = 0;
			Name = "张三";
			Score = 50;
			OtherInfo = "无其他信息";
		}

		public override string ToString()
		{
			return string.Format(
				"学号：{0},姓名：{1},成绩：{2}，{3}", ID, Name, Score, OtherInfo);
		}
	}
}