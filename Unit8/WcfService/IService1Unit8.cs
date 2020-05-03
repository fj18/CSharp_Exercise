using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{

	[ServiceContract]
	public interface IService1Unit8
	{
		[OperationContract]
		string Hello(string name);
		[OperationContract]
		string GetStudentsValue();
		
	}

}
