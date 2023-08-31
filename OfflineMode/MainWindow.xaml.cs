using CefSharp;
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
        public MainWindow()
        {
            InitializeComponent();

            Loaded += WebPageLoader_Loaded;

            // 设置窗口标题
            string qingYiApp = "青衣小说网" + " - " + "桌面端" + " - " + "离线版";
            // this.Title = qingYiApp;

            // 获取当前窗口实例
            var currentWindow = Application.Current.MainWindow as MainWindow;

            // 设置窗口标题
            // Application.Current.MainWindow.Title = qingYiApp;
            currentWindow.Title = qingYiApp;
        }

        private void WebPageLoader_Loaded(object sender, RoutedEventArgs e)
        {
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
            }
            else
            {
                // Console.WriteLine("文件夹不存在");

                string title = "注意";
                string message = "你没有安装离线资源包，可以在在线页面点击安装\n离线资源包不包含绝大多数图片，仅有小说内容及基础页面显示\n离线包使用GitHub镜像站安装，如果无法正常安装请在GitHub联系作者\n作者会去解决的";
                MessageBox.Show(message, title);
                Environment.Exit(0);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            // 获取当前目录
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // 构建 HTML 文件路径
            string relativePath = @"site\index.html";
            string htmlFilePath = new Uri(new Uri(currentDirectory), relativePath).LocalPath;

            // 加载 HTML 文件
            webBrowser.Load(htmlFilePath);
        }

        private void ReloadBtn_Click(object sender, RoutedEventArgs e)
        {
            webBrowser.Reload();
        }

        private void OnlineModeBtn_Click(object sender, RoutedEventArgs e)
        {
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
                string msg = ex.Message + "\n" + "请将此窗口截图并发送给软件作者以修复 Bug";
                MessageBox.Show("错误" + msg);
            }
        }

        private void CheckUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/Grey-Wind/QingYiNovels/releases/latest"; // 要打开的网页地址
                                                                                      
            try
            {
                Process.Start(url); // 打开默认浏览器并访问指定网页\
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
    }
}
