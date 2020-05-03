using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService
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
			Score = 90;
			OtherInfo = "无";
		}
		public override string ToString()
		{
			return string.Format($"学号：{ID}姓名：{Name}成绩：{Score}其他：{OtherInfo}");
		}
	}
}