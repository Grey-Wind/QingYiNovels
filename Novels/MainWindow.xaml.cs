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
            webBrowser.Address = "https://gw-novels.zeabur.app/";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            webBrowser.Address = "https://gw-novels.zeabur.app/";
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
            // NotMaking();

            string sourceDirectory = Directory.GetCurrentDirectory(); // 获取当前应用程序的工作目录

            string downloadUrl1 = "https://gw-novels.zeabur.app/site/index.zip";
            string downloadUrl2 = "https://gw-novels.zeabur.app/site/Font.zip";
            string downloadUrl3 = "https://gw-novels.zeabur.app/site/author.zip";
            string downloadUrl4 = "https://gw-novels.zeabur.app/site/excellent_author.zip";
            string downloadUrl5 = "https://gw-novels.zeabur.app/site/float-btn.zip";
            string downloadUrl6 = "https://gw-novels.zeabur.app/site/images.zip";
            string downloadUrl7 = "https://gw-novels.zeabur.app/site/novels.zip";
            string downloadUrl8 = "https://gw-novels.zeabur.app/site/type.zip";
            string downloadUrl9 = "https://gw-novels.zeabur.app/site/webfonts.zip";

            DownloadAndExtractFile(sourceDirectory, downloadUrl1, Path.Combine(sourceDirectory, "site"));
            DownloadAndExtractFile(sourceDirectory, downloadUrl2, Path.Combine(sourceDirectory, "site"));
            DownloadAndExtractFile(sourceDirectory, downloadUrl3, Path.Combine(sourceDirectory, "site"));
            DownloadAndExtractFile(sourceDirectory, downloadUrl4, Path.Combine(sourceDirectory, "site"));
            DownloadAndExtractFile(sourceDirectory, downloadUrl5, Path.Combine(sourceDirectory, "site"));
            DownloadAndExtractFile(sourceDirectory, downloadUrl6, Path.Combine(sourceDirectory, "site"));
            DownloadAndExtractFile(sourceDirectory, downloadUrl7, Path.Combine(sourceDirectory, "site"));
            DownloadAndExtractFile(sourceDirectory, downloadUrl8, Path.Combine(sourceDirectory, "site"));
            DownloadAndExtractFile(sourceDirectory, downloadUrl9, Path.Combine(sourceDirectory, "site"));
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

        static void DownloadAndExtractFile(string sourceDirectory, string downloadUrl, string extractPath)
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
    }
}
