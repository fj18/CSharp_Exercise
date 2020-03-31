using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
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
using Unit2.Unit2_ex;

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
            Helps.ChangeState(btnStart, true, btnStop, false);
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            Helps.ChangeState(btnStart, false, btnStop, true);
            MyClass.IsStop = false;
            textBlock1.Text = "";
            MyClass c = new MyClass(textBlock1);

            MyDate stat = new MyDate
            {
                Message = "a",
                info = "\n线程1已终止"
            };
            Thread thread1 = new Thread(c.MyMethod);
            thread1.IsBackground = true;
            thread1.Start(stat);

             stat = new MyDate
            {
                Message = "b",
                info = "\n线程2已终止"
            };
            Thread thread2 = new Thread(c.MyMethod);
            thread2.IsBackground = true;
            thread2.Start(stat);

            stat = new MyDate { Message = "c", info = "\n线程3已终止" };
            ThreadPool.QueueUserWorkItem(new WaitCallback(c.MyMethod), stat);

            stat = new MyDate { Message = "d", info = "\n线程4已终止" };
            ThreadPool.QueueUserWorkItem(new WaitCallback(c.MyMethod), stat);
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            Helps.ChangeState(btnStart, true, btnStop, false);
            MyClass.IsStop = true;
        }
    }
    public class MyClass
    {
        public static volatile bool IsStop;
        TextBlock textBlock1;
        public MyClass(TextBlock textBlock1)
        {
            this.textBlock1 = textBlock1;
        }

        public void MyMethod(object obj)
        {
            MyDate state = obj as MyDate;
            while(IsStop == false)
            {
                AddMessage(state.Message);
                Thread.Sleep(10);
            }
            AddMessage(state.info);
        }

        private void AddMessage(string message)
        {
            textBlock1.Dispatcher.Invoke(()=>{ textBlock1.Text += message; }); 
        }
    }


public class MyDate
    {
        public string info { get; set; }
        public string Message { get; set; }

    }
}
