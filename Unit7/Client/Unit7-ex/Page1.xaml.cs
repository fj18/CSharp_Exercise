using Client.ServiceReference1;
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
	/// Page1.xaml 的交互逻辑
	/// </summary>
	public partial class Page1 : Page
	{
		public Page1()
		{
			InitializeComponent();
		}

		private void sayHelloBtn_Click(object sender, RoutedEventArgs e)
		{
			Service1Client client = new Service1Client();
			string s = client.SayHello("欢迎学习WCF");
			client.Close();
			textBlock.Text += s;
			
		}

		private void allServicesBtn_Click(object sender, RoutedEventArgs e)
		{
			Service1Client client = new Service1Client();
			string s = client.SayHello(client.Endpoint.Address.ToString());
			double r1 = client.Add(10, 20);
			double r2 = client.Divide(10, 20);
			client.Close();
			textBlock.Text += s + $"10+20={r1}\n" + $"10/20={r2}\n";
		}
	}
}
