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
using Client.ServiceReference3;
namespace Client.Unit7_ex
{
	/// <summary>
	/// Page3.xaml 的交互逻辑
	/// </summary>
	public partial class Page3 : Page
	{
		public Page3()
		{
			InitializeComponent();
		}

		private void btn1_Click(object sender, RoutedEventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			Service3Client client = new Service3Client();
			Body body;
			Header header = client.GetMessage(out body);
			sb.AppendLine("header:");
			sb.AppendFormat("{0},{1:HH:mm}", header.Description, header.TransactionData);
			sb.AppendLine();
			sb.AppendLine("body:");
			sb.AppendFormat("{0},{1},{2}", body.Name, body.Age, body.Telephone);

			textBlock.Text = sb.ToString();


		}
	}
}
