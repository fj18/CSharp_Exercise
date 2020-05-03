using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace WcfService1
{
	[MessageContract]
	public class MyData2
	{
		[MessageHeader]
		public Header header { get; set; }
		[MessageBodyMember]
		public Body body { get; set; }
	}

	public class Header
	{
		public string Description { get; set; }
		public DateTime TransactionData { get; set; }
		public Header()
		{
			Description = "消息头";
			TransactionData = DateTime.Now;
		}
	}

	public class Body
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public string Telephone { get; set; }
		public Body()
		{
			Name = "张三";
			Age = 20;
			Telephone = "1234567";
		}
	}
}