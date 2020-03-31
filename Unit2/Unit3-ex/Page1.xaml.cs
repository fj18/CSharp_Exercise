using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace Unit1.Unit1_ex
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : Page
    {
        int fileIndex;
        string fileName = "Notepad";
        List<Data> list = new List<Data>();
        public Page1()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender,RoutedEventArgs e)
        {
            string argument = Environment.CurrentDirectory + "\\myfile" + (fileIndex++) + ".txt";
            if (File.Exists(argument) == false)
                File.CreateText(argument);
            Process p = new Process();
            p.StartInfo.FileName = fileName;
            p.StartInfo.Arguments = argument;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.Start();
            p.WaitForInputIdle();
            Refresh();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            Process[] ps = Process.GetProcessesByName(fileName);
            foreach (Process p in ps)
            {
                using (p)
                {
                    p.CloseMainWindow();
                    Thread.Sleep(1000);
                    p.WaitForExit();
                }
            }
            fileIndex = 0;
            Refresh();

                this.Cursor = Cursors.Arrow;
        }

        private void Refresh()
        {
            dataGrid1.ItemsSource = null;
            list.Clear();
            Process[] ps = Process.GetProcessesByName(fileName);
            foreach (Process p in ps)
            {
                list.Add(new Data()
                {
                    Id = p.Id,
                    ProcessName = p.ProcessName,
                    TotalMemory = string.Format("{0}KB", p.WorkingSet64 / 1024),
                    StartTime = p.StartTime.ToString(),
                    FileName = p.MainModule.FileName
                });
                

            }
            dataGrid1.ItemsSource = list;
        }
    }
    public class Data
    {
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public string TotalMemory { get; set; }
        public string StartTime { get; set; }
        public string FileName { get; set; }

    }
}
