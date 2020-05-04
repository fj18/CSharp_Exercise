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
using Client.ServiceReference2;

namespace Client.Unit8_ex
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

		private void btn1_Click(object sender, RoutedEventArgs e)
		{
			Service2Unit8Client client = new Service2Unit8Client();
			textBlock.Text = "原始数据：\n" + client.GetStudentsValue();
			
			client.Add(new Student {ID=13009,Name="刘龙",Score=100 });
			client.Remove(13001);
			textBlock.Text += "更新后的数据：\n" + client.GetStudentsValue();
		}
	}
}
