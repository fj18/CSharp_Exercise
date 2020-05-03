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
using Client.ServiceReference1;

namespace Client.Unit8_ex
{
	/// <summary>
	/// Page1.xaml 的交互逻辑
	/// </summary>
	public partial class Page1 : Page
	{
		Service1Unit8Client client = new Service1Unit8Client();
		public Page1()
		{
			InitializeComponent();
			this.Unloaded += Page1_Unloaded;
		}

		private void Page1_Unloaded(object sender, RoutedEventArgs e)
		{
			client.Close();
		}

		private void btn1_Click(object sender, RoutedEventArgs e)
		{
			textBlock.Text += "\n客户端调用了服务端的Hello方法\n" + client.Hello("张三");
		}

		private void btn2_Click(object sender, RoutedEventArgs e)
		{
			textBlock.Text += "\n客户端调用了服务端的GetStudentsValue方法\n" +  client.GetStudentsValue();
		}
	}
}
