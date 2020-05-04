using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
	// 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service2”。
	// 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service2.svc 或 Service2.svc.cs，然后开始调试。
	public class Service2Unit8 : IService2Unit8
	{
		private Students students = new Students();
		public void Add(Student student)
		{
			students.StudentList.Add(student.ID,student);
		}

		public void Remove(int n)
		{
			if (students.StudentList.Keys.Contains(n))
				students.StudentList.Remove(n);
		}

		public string GetStudentsValue()
		{
			return students.ToString();
		}
	}
}
