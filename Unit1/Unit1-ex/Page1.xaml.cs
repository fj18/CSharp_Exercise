using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace Unit1.Unit1_ex
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("获取www.cctv.com的所有IP地址");
            try
            {
                IPAddress[] ips = Dns.GetHostAddresses("www.cctv.com");
                foreach (IPAddress ip in ips)
                {
                    sb.AppendLine(ip.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "获取失败");
                throw;
            }
            string s1 = Dns.GetHostName();
            IPHostEntry me = Dns.GetHostEntry(s1);
            sb.AppendLine("获取本地的所有IP地址");

            foreach(IPAddress iPAddress in me.AddressList)
            {
                if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
                    sb.AppendLine("IPV4：" + iPAddress.ToString());
                else
                    if (iPAddress.AddressFamily == AddressFamily.InterNetworkV6)
                    sb.AppendLine("IPV6：" + iPAddress.ToString());
                else
                    sb.AppendLine("其他：" + iPAddress.ToString());
            }

            sb.AppendLine("IPV6和IPV4的环回地址测试");
            IPAddress ip1 = IPAddress.Parse("::1");//ipv6
            IPAddress ip2 = IPAddress.Parse("127.0.0.1");//ipv4
            IPEndPoint iep1 = new IPEndPoint(ip1, 80);
            IPEndPoint iep2 = new IPEndPoint(ip2, 80);
           
            if (iep1.AddressFamily == AddressFamily.InterNetwork)
                sb.Append("IPV4的端点：" + ip1.ToString());
            else if(iep1.AddressFamily == AddressFamily.InterNetworkV6)
                sb.Append("IPV6的端点：" + ip1.ToString());
            sb.AppendLine(",端口：" + iep1.Port +",地址：" + iep1.Address + ",地址族：" + iep1.AddressFamily);

            if (iep1.AddressFamily == AddressFamily.InterNetwork)
                sb.Append("IPV4的端点：" + ip2.ToString());
            else if(iep1.AddressFamily == AddressFamily.InterNetworkV6)
                sb.Append("IPV4的端点：" + ip2.ToString());
            sb.AppendLine(",端口：" + iep2.Port + ",地址：" + iep2.Address + ",地址族：" + iep2.AddressFamily);


            text1.Text = sb.ToString();

        }

    }
}
