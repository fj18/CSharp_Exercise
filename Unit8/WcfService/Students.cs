using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WcfService
{
	public class Students
	{
		public Dictionary<int,Student> StudentList { get; set; }
		public Students()
		{
			StudentList = new Dictionary<int, Student>();
			StudentList.Add(13001, new Student { ID = 13001, Name = "张三", Score = 90 });
			StudentList.Add(13002, new Student { ID = 13002, Name = "李四", Score = 70 });
			StudentList.Add(13003, new Student { ID = 13003, Name = "王五", Score = 80 });
		}

		public void UpdateScore(Student student,int newScore)
		{
			if (StudentList.Keys.Contains(student.ID))
			{
				StudentList[student.ID].Score = newScore;
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			foreach (var s in StudentList.Values)
			{
				sb.AppendLine($"学号：{s.ID}姓名：{s.Name}成绩：{s.Score}其他：{s.OtherInfo}");
			}

			return sb.ToString();
		}
	}
}