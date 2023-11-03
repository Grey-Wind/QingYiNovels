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
            DeleteOldSite();

            string sourceDirectory = Directory.GetCurrentDirectory(); // 获取当前应用程序的工作目录

            string author = "https://qingyi-novels.zeabur.app/site/author.zip";
            string download = "https://qingyi-novels.zeabur.app/site/download.zip";
            string excellent_author = "https://qingyi-novels.zeabur.app/site/excellent_author.zip";
            string float_btn = "https://qingyi-novels.zeabur.app/site/float-btn.zip";
            string font = "https://qingyi-novels.zeabur.app/site/Font.zip";
            string images = "https://qingyi-novels.zeabur.app/site/images.zip";
            string index = "https://qingyi-novels.zeabur.app/site/index.zip";
            string type = "https://qingyi-novels.zeabur.app/site/type.zip";
            string webfonts = "https://qingyi-novels.zeabur.app/site/webfonts.zip";

            Install(sourceDirectory, author, Path.Combine(sourceDirectory, "site"));
            Install(sourceDirectory, download, Path.Combine(sourceDirectory, "site"));
            Install(sourceDirectory, excellent_author, Path.Combine(sourceDirectory, "site"));
            Install(sourceDirectory, float_btn, Path.Combine(sourceDirectory, "site"));
            Install(sourceDirectory, font, Path.Combine(sourceDirectory, "site"));
            Install(sourceDirectory, images, Path.Combine(sourceDirectory, "site"));
            Install(sourceDirectory, index, Path.Combine(sourceDirectory, "site"));
            Install(sourceDirectory, type, Path.Combine(sourceDirectory, "site"));
            Install(sourceDirectory, webfonts, Path.Combine(sourceDirectory, "site"));

            Novel();
        }

        private void DeleteOldSite()
        {
            string sourceDirectory = Directory.GetCurrentDirectory(); // 获取当前应用程序的工作目录
            string folderPath = Path.Combine(sourceDirectory, "site");
            Directory.Delete(folderPath, true);
        }

        private void Novel()
        {
            string sourceDirectory = Directory.GetCurrentDirectory(); // 获取当前应用程序的工作目

            string xnwy = "https://qingyi-novels.zeabur.app/site/novels/%E8%99%9A%E6%8B%9F%E7%BD%91%E6%B8%B8.zip"; // 虚拟网游
            string yq = "https://qingyi-novels.zeabur.app/site/novels/%E8%A8%80%E6%83%85.zip"; // 言情
            string cy = "https://qingyi-novels.zeabur.app/site/novels/%E7%A9%BF%E8%B6%8A.zip"; // 穿越
            string dp = "https://qingyi-novels.zeabur.app/site/novels/%E7%9F%AD%E7%AF%87.zip"; // 短篇
            string hlbt = "https://qingyi-novels.zeabur.app/site/novels/%E5%93%88%E5%88%A9%E6%B3%A2%E7%89%B9.zip"; // 哈利波特
            string rw = "https://qingyi-novels.zeabur.app/site/novels/%E8%82%89%E6%96%87.zip"; // 肉文

            Install(sourceDirectory, xnwy, Path.Combine(sourceDirectory, "site/novels"));
            Install(sourceDirectory, yq, Path.Combine(sourceDirectory, "site/novels"));
            Install(sourceDirectory, cy, Path.Combine(sourceDirectory, "site/novels"));
            Install(sourceDirectory, dp, Path.Combine(sourceDirectory, "site/novels"));
            Install(sourceDirectory, hlbt, Path.Combine(sourceDirectory, "site/novels"));
            Install(sourceDirectory, rw, Path.Combine(sourceDirectory, "site/novels"));
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

        static void Install(string sourceDirectory, string downloadUrl, string extractPath)
        {
            string fileName = Path.GetFileName(downloadUrl);
            string filePath = Path.Combine(sourceDirectory, fileName);

            using (var client = new WebClient())
            {
                Console.WriteLine($"正在下载文件：{fileName}...");
                client.DownloadFile(downloadUrl, filePath);
            }

            Thread.Sleep(TimeSpan.FromMilliseconds(250));

            Console.WriteLine($"正在解压文件：{fileName}...");
            ZipFile.ExtractToDirectory(filePath, extractPath);
            File.Delete(filePath);
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
