using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
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
    /// Page2.xaml 的交互逻辑
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();

            StringBuilder sb = new StringBuilder();



            NetworkInterface[] adpters = NetworkInterface.GetAllNetworkInterfaces();
            sb.AppendLine("适配器个数：" + adpters.Length);
            int index = 0;
            foreach (NetworkInterface adpter in adpters)
            {
                index++;
                sb.AppendLine("----------------------------第" + index + "个适配器--------------------");
                sb.AppendLine("描述信息：" + adpter.Description);
                sb.AppendLine("姓名：" + adpter.Name);
                sb.AppendLine("速度：" + adpter.Speed/1000/1000 + "M");
                byte[] macBytes = adpter.GetPhysicalAddress().GetAddressBytes();
                sb.AppendLine("MAC:" + BitConverter.ToString(macBytes));

                IPInterfaceProperties ipp = adpter.GetIPProperties();
                IPAddressCollection dnsserver = ipp.DnsAddresses;
                if(dnsserver.Count > 0)
                    foreach (IPAddress dns in dnsserver)
                    {
                        sb.AppendLine("DNS服务器IP:" + dns);
                    }

            }


            text1.Text = sb.ToString();
        }
    }
}
