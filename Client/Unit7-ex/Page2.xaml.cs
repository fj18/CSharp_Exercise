using Client.ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client.Unit7_ex
{
	/// <summary>
	/// Page2.xaml 的交互逻辑
	/// </summary>
	public partial class Page2 : Page
	{
		public Page2()
		{
			InitializeComponent();
		}
		private void btn1_Click(object sender,RoutedEventArgs e)
		{
			StringBuilder sb = new StringBuilder();

			MyData1 data = new MyData1();
			sb.AppendLine("直接创建对象:");
			sb.AppendLine("myName2:" + data.MyName2);
			sb.AppendLine("myNmae3:" + data.myName3);        //myName3是private，无法获取
			sb.AppendLine("Telephone:" + data.Telephone);
			Service2Client client = new Service2Client();
			MyData1 data1 = client.GetMyData1();
			sb.AppendLine("通过服务获取对象：");
			sb.AppendLine("myName2:" + data1.MyName2);
			sb.AppendLine("myNmae3:" + data1.myName3);        //myName3是private，无法获取
			sb.AppendLine("Telephone:" + data1.Telephone);
			textBlock.Text = sb.ToString();
		}
	}
}
