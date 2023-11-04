using CefSharp;
using System.Diagnostics;
using System;
using System.Windows;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;

namespace Novels
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += WebPageLoader_Loaded;

            // 设置窗口标题
            string qingYiApp = "青衣小说网" + " - " + "桌面端" + " - " + "在线版";
            // this.Title = qingYiApp;

            // 获取当前窗口实例
            var currentWindow = Application.Current.MainWindow as MainWindow;

            // 设置窗口标题
            // Application.Current.MainWindow.Title = qingYiApp;
            currentWindow.Title = qingYiApp;
        }

        private void WebPageLoader_Loaded(object sender, RoutedEventArgs e)
        {
            // webBrowser.Address = "https://qingyi-novels.zeabur.app/";
            setLink();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            // webBrowser.Address = "https://qingyi-novels.zeabur.app/";
            setLink();
        }

        private void ReloadBtn_Click(object sender, RoutedEventArgs e)
        {
            webBrowser.Reload();
        }

        private void OfflineModeBtn_Click(object sender, RoutedEventArgs e)
        {
            // NotMaking();

            try
            {
                // 获取当前工作目录
                string currentDirectory = Directory.GetCurrentDirectory();

                // 拼接相对路径和文件名
                string relativePath = @"./OfflineMode.exe";
                string exePath = Path.Combine(currentDirectory, relativePath);

                // 创建进程对象
                Process process = new Process();

                // 指定要启动的可执行文件的路径
                process.StartInfo.FileName = exePath;

                // 启动外部可执行文件
                process.Start();

                // 关闭
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                // Console.WriteLine("发生错误: " + ex.Message);
                string msg = ex.Message + "\n" + "请将此窗口截图并发送给软件作者以修复 Bug";
                MessageBox.Show("错误" + msg);
            }
        }

        private void DownloadOfflinePackageBtn_Click(object sender, RoutedEventArgs e)
        {
            Process process = new Process();

            // 设置process启动信息
            process.StartInfo.FileName = "cmd.exe";  // 使用cmd命令行
            process.StartInfo.RedirectStandardInput = true; // 允许重定向输入
            process.StartInfo.RedirectStandardOutput = true; // 允许重定向输出
            process.StartInfo.CreateNoWindow = true; // 不创建新窗口
            process.StartInfo.UseShellExecute = false; // 不使用shell执行

            process.Start(); // 启动进程

            // 输入你的命令
            // process.StandardInput.WriteLine("cd ./"); // 切换到你的tools目录
            process.StandardInput.WriteLine("tools package-install"); // 执行package-install命令
            process.StandardInput.WriteLine("exit"); // 退出cmd

            string output = process.StandardOutput.ReadToEnd(); // 读取输出

            process.WaitForExit(); // 等待进程结束
            process.Close(); // 关闭进程

            Console.WriteLine(output); // 输出结果
        }

        private void CheckUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/Grey-Wind/QingYiNovels/releases/latest"; // 要打开的网页地址

            try
            {
                Process.Start(url); // 打开默认浏览器并访问指定网页
            }
            catch (Exception ex)
            {
                // Console.WriteLine("发生错误: " + ex.Message);

                string errorMessage = ex.Message;

                // 创建文件夹路径（如果不存在）
                string folderPath = "error";
                Directory.CreateDirectory(folderPath);

                // 创建文件名
                string fileName = $"error_{DateTime.Now:yyyy-M-d_H-mm}.txt";
                string filePath = Path.Combine(folderPath, fileName);

                // 写入异常消息到文件
                File.WriteAllText(filePath, errorMessage);
            }
        }

        private void NotMaking() // 未制作的提示框显示
        {
            string title = "注意";
            string message = "本功能在该版本暂时没有做，可以点击检查更新查看是否有新版本\n如果没有，就是还在做";

            MessageBox.Show(message, title);
        }

        private void setLink()
        {
            var loadPropPath = "load.prop"; // load.prop文件路径
            var currentDirectory = Directory.GetCurrentDirectory(); // 当前目录路径
            var loadPropFullPath = Path.Combine(currentDirectory, loadPropPath); // load.prop文件完整路径
            var url = ""; // 定义一个空字符串变量来保存url属性值
            foreach (var line in File.ReadAllLines(loadPropPath))
            {
                if (line.StartsWith("url="))
                {
                    url = line.Substring(4); // 获取url属性值
                    break; // 找到后立即退出循环
                }
            }
            webBrowser.Address = url;
        }
    }
}
