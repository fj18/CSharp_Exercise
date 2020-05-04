using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using Client.ServiceReference3;

namespace Client.Unit8_ex
{
	/// <summary>
	/// Page3.xaml 的交互逻辑
	/// </summary>
	public partial class Page3 : Page,IService3Unit8Callback
	{
		private Service3Unit8Client client;
		public Page3()
		{
			InitializeComponent();
		}

		private async void btn1_Click(object sender, RoutedEventArgs e)
		{
			InstanceContext context = new InstanceContext(this);
			client = new Service3Unit8Client(context);

			textBlock.Text += "\n等待接收";
			Task t1 = client.LoginAsync("张三");
			while(t1.IsCompleted == false)
			{
				textBlock.Text += ".";
				await Task.Delay(500);
			}		
			await t1;
		}

		public void Receive(string response)
		{
			textBlock.Text += "\n收到来自服务器的信息" + response;
		}
	}
}
