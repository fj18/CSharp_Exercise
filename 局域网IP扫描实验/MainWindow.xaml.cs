using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

namespace 局域网IP扫描实验
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            start.IsEnabled = false;
            results.Items.Clear();
            errorInfo.Height = 0;

            Thread t1 = new Thread(Scan);
            Thread t2 = new Thread(Scan);
            Thread t3 = new Thread(Scan);
            Thread t4 = new Thread(Scan);
            t1.Start(new IPInfo() {
                PreIP = preAdTextBox.Text,
                FirstIndex = firstAdTextBox.Text,
                LastIndex = lastAdTextBox.Text,
                ThreaNum = 0
            });
            t2.Start(new IPInfo()
            {
                PreIP = preAdTextBox.Text,
                FirstIndex = firstAdTextBox.Text,
                LastIndex = lastAdTextBox.Text,
                ThreaNum = 1
            });
            t3.Start(new IPInfo()
            {
                PreIP = preAdTextBox.Text,
                FirstIndex = firstAdTextBox.Text,
                LastIndex = lastAdTextBox.Text,
                ThreaNum = 2
            });
            t4.Start(new IPInfo()
            {
                PreIP = preAdTextBox.Text,
                FirstIndex = firstAdTextBox.Text,
                LastIndex = lastAdTextBox.Text,
                ThreaNum = 3
            });

            start.IsEnabled = true;
        }

        private void Scan(Object obj)
        {
            IPInfo iPInfo = obj as IPInfo; 
            string compIP = null;
            int s = 0;
            string hostName;
            IPAddress myscanip = null;

            for (s = int.Parse(iPInfo.FirstIndex) +iPInfo.ThreaNum ; s <= int.Parse(iPInfo.LastIndex); s += 4) //IP地址开始和结束

            {
                compIP = iPInfo.PreIP + s.ToString();
                  //转换IP地址
                if (Helps.IsRightIP(compIP) == true)
                {
                    myscanip = IPAddress.Parse(compIP);
                }
                else
                {

                    Dispatcher.Invoke(new Action(delegate
                    {
                        errorInfo.Height = 30;
                    }));

                    return;//地址错误，结束函数执行
                }

                try

                {
                    DateTime starTime = DateTime.Now;
                    hostName = Dns.GetHostEntry(myscanip).HostName;
                    DateTime stopTime = DateTime.Now;
                    if (hostName.Contains(compIP) == true)//
                    {
                        Dispatcher.Invoke(new Action(delegate
                        {
                            results.Items.Add("扫描地址：" + compIP + "  " + "扫描时间：" + (stopTime - starTime).Milliseconds.ToString() + "毫秒" + "  " + "主机名：(不在线)");
                        }));
                       
                    }
                    else
                    {
                        Dispatcher.Invoke(new Action(delegate
                        {
                            results.Items.Add("扫描地址：" + compIP + "  " + "扫描时间：" + (stopTime - starTime).Milliseconds.ToString() + "毫秒" + "  " + "主机名：" + hostName);
                        }));
                        
                    }
                }

                catch(Exception ex)

                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
