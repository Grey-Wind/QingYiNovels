﻿using CefSharp;
using Serilog;
using System.Diagnostics;
using System;
using System.Windows;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Net;
using System.Threading;

namespace Novels
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly string qingYi = "青衣小说网";
        readonly string createLogFileEnd = "创建 log 文件结束";
        readonly string prepareLoadQingYi = "准备加载青衣小说网";
        readonly string loadQingYiComplete = "青衣小说网加载完成";
        readonly string prepareBackQingYiIndex = "准备回到青衣小说网主页";
        readonly string backQingYiIndexComplete = "成功回到青衣小说网主页";
        readonly string prepareReload = "准备刷新网页";
        readonly string reloadComplete = "成功刷新网页";
        readonly string prepareStartOfflineMode = "准备启动离线模式";
        readonly string startOfflineModeComplete = "启动离线模式成功";
        readonly string prepareDownloadOfflinePackage = "准备下载离线包";
        readonly string downloadOfflinePackageComplete = "下载离线包结束";
        readonly string startTryingOpenUpdateWebsite = "开始尝试打开更新站";
        readonly string prepareOpenUpdateWebsite = "准备打开更新网址";
        readonly string openUpdateWebsiteComplete = "打开更新网址成功";
        readonly string prepareAddErrorFolder = "准备添加错误文件夹";
        readonly string addErrorFolderComplete = "添加错误文件夹成功";
        readonly string prepareAddErrorLogFile = "准备添加错误日志文件";
        readonly string prepareWriteErrorLog = "准备写入错误日志";
        readonly string ErrorLog = "错误日志：";
        readonly string writeErrorLogComplete = "写入错误日志成功";
        readonly string prepareOpenMessageBox = "准备打开未制作信息框";
        readonly string openMessageBoxComplete = "打开未制作信息框成功";
        // string xxx = "";
        // Log.Information();

        public MainWindow()
        {
            InitializeComponent();

            Loaded += WebPageLoader_Loaded;

            // 创建适用于 RoutedEventHandler 的方法，并在其中调用 LogRecord() 方法
            Loaded += new RoutedEventHandler(LogRecord);

            // 设置窗口标题
            string qingYiApp = qingYi + " - " + "桌面端" + " - " + "在线版";
            // this.Title = qingYi + "桌面端";
            // this.Title = qingYiApp;

            // 获取当前窗口实例
            var currentWindow = Application.Current.MainWindow as MainWindow;

            // 设置窗口标题
            // Application.Current.MainWindow.Title = qingYiApp;
            currentWindow.Title = qingYiApp;
        }

        private void LogRecord(object sender, RoutedEventArgs e)
        {
            // 获取当前日期和时间
            DateTime now = DateTime.Now;

            // 格式化为精确到分钟的文件名
            string fileName = $"log_{now:yyyy-MM-dd_HHmm}.txt";

            // 指定日志文件路径
            string filePath = Path.Combine("log", fileName);

            // 确保日志文件夹存在
            Directory.CreateDirectory("log");

            // 配置日志输出到文件
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(filePath)
                .CreateLogger();

            Log.Information(createLogFileEnd);
            Log.CloseAndFlush();
        }

        private void WebPageLoader_Loaded(object sender, RoutedEventArgs e)
        {
            Log.Information(prepareLoadQingYi);
            webBrowser.Address = "https://gw-novels.zeabur.app/";
            Log.Information(loadQingYiComplete);
            Log.CloseAndFlush();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Log.Information(prepareBackQingYiIndex);
            webBrowser.Address = "https://gw-novels.zeabur.app/";
            Log.Information(backQingYiIndexComplete);
            Log.CloseAndFlush();
        }

        private void ReloadBtn_Click(object sender, RoutedEventArgs e)
        {
            Log.Information(prepareReload);
            webBrowser.Reload();
            Log.Information(reloadComplete);
            Log.CloseAndFlush();
        }

        private void OfflineModeBtn_Click(object sender, RoutedEventArgs e)
        {
            Log.Information(prepareStartOfflineMode);

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
                Log.Information($"{ex.Message}");
            }

            Log.Information(startOfflineModeComplete);
            Log.CloseAndFlush();
        }

        private void DownloadOfflinePackageBtn_Click(object sender, RoutedEventArgs e)
        {
            Log.Information(prepareDownloadOfflinePackage);

            // NotMaking();

            string sourceDirectory = Directory.GetCurrentDirectory(); // 获取当前应用程序的工作目录
            string downloadUrl1 = "https://hub.ggo.icu/Grey-Wind/Novels/raw/main/site/index.zip";
            string downloadUrl2 = "https://hub.ggo.icu/Grey-Wind/Novels/raw/main/site/Font.zip";
            string downloadUrl3 = "https://hub.ggo.icu/Grey-Wind/Novels/raw/main/site/author.zip";
            string downloadUrl4 = "https://hub.ggo.icu/Grey-Wind/Novels/raw/main/site/excellent_author.zip";
            string downloadUrl5 = "https://hub.ggo.icu/Grey-Wind/Novels/raw/main/site/float-btn.zip";
            string downloadUrl6 = "https://hub.ggo.icu/Grey-Wind/Novels/raw/main/site/images.zip";
            string downloadUrl7 = "https://hub.ggo.icu/Grey-Wind/Novels/raw/main/site/novels.zip";
            string downloadUrl8 = "https://hub.ggo.icu/Grey-Wind/Novels/raw/main/site/type.zip";
            string downloadUrl9 = "https://hub.ggo.icu/Grey-Wind/Novels/raw/main/site/webfonts.zip";

            DownloadAndExtractFile(sourceDirectory, downloadUrl1, Path.Combine(sourceDirectory, "site"));
            DownloadAndExtractFile(sourceDirectory, downloadUrl2, Path.Combine(sourceDirectory, "site"));
            DownloadAndExtractFile(sourceDirectory, downloadUrl3, Path.Combine(sourceDirectory, "site"));
            DownloadAndExtractFile(sourceDirectory, downloadUrl4, Path.Combine(sourceDirectory, "site"));
            DownloadAndExtractFile(sourceDirectory, downloadUrl5, Path.Combine(sourceDirectory, "site"));
            DownloadAndExtractFile(sourceDirectory, downloadUrl6, Path.Combine(sourceDirectory, "site"));
            DownloadAndExtractFile(sourceDirectory, downloadUrl7, Path.Combine(sourceDirectory, "site"));
            DownloadAndExtractFile(sourceDirectory, downloadUrl8, Path.Combine(sourceDirectory, "site"));
            DownloadAndExtractFile(sourceDirectory, downloadUrl9, Path.Combine(sourceDirectory, "site"));

            Log.Information(downloadOfflinePackageComplete);
            Log.CloseAndFlush();
        }

        private void CheckUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/Grey-Wind/QingYiNovels/releases/latest"; // 要打开的网页地址
            
            Log.Information(startTryingOpenUpdateWebsite);

            try
            {
                Log.Information(prepareOpenUpdateWebsite);
                Process.Start(url); // 打开默认浏览器并访问指定网页
                Log.Information(openUpdateWebsiteComplete);
            }
            catch (Exception ex)
            {
                // Console.WriteLine("发生错误: " + ex.Message);

                string errorMessage = ex.Message;

                Log.Information(prepareAddErrorFolder);

                // 创建文件夹路径（如果不存在）
                string folderPath = "error";
                Directory.CreateDirectory(folderPath);

                Log.Information(addErrorFolderComplete);

                Log.Information(prepareAddErrorLogFile);

                // 创建文件名
                string fileName = $"error_{DateTime.Now:yyyy-M-d_H-mm}.txt";
                string filePath = Path.Combine(folderPath, fileName);

                Log.Information(prepareWriteErrorLog);
                
                // 写入异常消息到文件
                File.WriteAllText(filePath, errorMessage);

                Log.Information(ErrorLog);
                Log.Information(errorMessage);
                Log.Information(writeErrorLogComplete);
            }
            Log.CloseAndFlush();
        }

        private void NotMaking() // 未制作的提示框显示
        {
            string title = "注意";
            string message = "本功能在该版本暂时没有做，可以点击检查更新查看是否有新版本\n如果没有，就是还在做";

            Log.Information(prepareOpenMessageBox);
            
            MessageBox.Show(message, title);

            Log.Information(openMessageBoxComplete);
            Log.CloseAndFlush();
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
