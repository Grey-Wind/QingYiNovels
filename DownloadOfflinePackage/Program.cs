using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;

namespace DownloadOfflinePackage
{
    internal class Program
    {
        static void Main()
        {
            DeleteOldPackage();

            Console.WriteLine("正在删除中...");

            Thread.Sleep(500); // 等待0.5秒

            MainPage();
            Novels();
        }

        private static void Novels()
        {
            string sourceDirectory = Directory.GetCurrentDirectory(); // 获取当前应用程序的工作目录

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

        private static void MainPage()
        {
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
        }

        private static void DeleteOldPackage()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "uop.exe"; // 获取当前程序的路径，并拼接上uop.exe
            try
            {
                Process.Start(startInfo); // 启动uop.exe
            }
            catch (Exception e)
            {
                Console.WriteLine("错误: " + e.Message); // 如果出错，打印错误信息
            }
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
    }
}
