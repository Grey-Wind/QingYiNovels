using CefSharp;
using Serilog;
using System.Diagnostics;
using System;
using System.Windows;
using System.IO;

namespace OfflineMode
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
        readonly string prepareStartOfflineMode = "准备启动在线模式";
        readonly string startOnlineModeComplete = "启动在线模式成功";
        readonly string startTryingOpenUpdateWebsite = "开始尝试打开更新站";
        readonly string prepareOpenUpdateWebsite = "准备打开更新网址";
        readonly string openUpdateWebsiteComplete = "打开更新网址成功";
        readonly string prepareAddErrorFolder = "准备添加错误文件夹";
        readonly string addErrorFolderComplete = "添加错误文件夹成功";
        readonly string prepareAddErrorLogFile = "准备添加错误日志文件";
        readonly string prepareWriteErrorLog = "准备写入错误日志";
        readonly string ErrorLog = "错误日志：";
        readonly string writeErrorLogComplete = "写入错误日志成功";
        // string xxx = "";
        // Log.Information();

        public MainWindow()
        {
            InitializeComponent();

            Loaded += WebPageLoader_Loaded;

            // 创建适用于 RoutedEventHandler 的方法，并在其中调用 LogRecord() 方法
            Loaded += new RoutedEventHandler(LogRecord);

            // 设置窗口标题
            string qingYiApp = qingYi + " - " + "桌面端" + " - " + "离线版";
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

            string folderPath = "site";  // 相对路径

            string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderPath);

            if (Directory.Exists(absolutePath))
            {
                // 获取当前目录
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // 构建 HTML 文件路径
                string relativePath = @"site\index.html";
                string htmlFilePath = new Uri(new Uri(currentDirectory), relativePath).LocalPath;

                // 加载 HTML 文件
                webBrowser.Load(htmlFilePath);

                Log.Information(loadQingYiComplete);
            }
            else
            {
                // Console.WriteLine("文件夹不存在");

                string title = "注意";
                string message = "你没有安装离线资源包，可以在在线页面点击安装\n离线资源包不包含绝大多数图片，仅有小说内容及基础页面显示\n离线包使用GitHub镜像站安装，如果无法正常安装请在GitHub联系作者\n作者会去解决的";
                MessageBox.Show(message, title);
                Environment.Exit(0);
            }

            Log.CloseAndFlush();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Log.Information(prepareBackQingYiIndex);

            // 获取当前目录
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // 构建 HTML 文件路径
            string relativePath = @"site\index.html";
            string htmlFilePath = new Uri(new Uri(currentDirectory), relativePath).LocalPath;

            // 加载 HTML 文件
            webBrowser.Load(htmlFilePath);

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

        private void OnlineModeBtn_Click(object sender, RoutedEventArgs e)
        {
            Log.Information(prepareStartOfflineMode);

            try
            {
                // 获取当前工作目录
                string currentDirectory = Directory.GetCurrentDirectory();

                // 拼接相对路径和文件名
                string relativePath = @"./Novels.exe";
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

            Log.Information(startOnlineModeComplete);
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
    }
}
