using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
	// 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService3”。
	[ServiceContract (SessionMode = SessionMode.Required,CallbackContract = typeof(IService3Unit8Callback))]    //指定回调接口
																												//在服务协定中指定了本接口IService3Unit8IService3Unit8回调协定是IService3Unit8Callback
	public interface IService3Unit8
	{
		[OperationContract(IsOneWay = true)]
		void Login(string s);
	}

	//将来客户端要实现的接口，接口前不需要修饰了
	public interface IService3Unit8Callback
	{
		[OperationContract(IsOneWay = true)]
		void Receive(string response);
	}
}
