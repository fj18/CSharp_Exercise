using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService1
{
	// 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service3”。
	// 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service3.svc 或 Service3.svc.cs，然后开始调试。
	public class Service3 : IService3
	{
		public MyData2 GetMessage()
		{
			MyData2 data = new MyData2();
			data.header = new Header();
			data.body = new Body();
			return data;
		}
	}
}
