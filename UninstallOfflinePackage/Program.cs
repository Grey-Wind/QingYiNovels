using System;
using System.IO;

namespace UninstallOfflinePackage
{
    internal class Program
    {
        static void Main()
        {
            string folderName = "site";  // 要删除的文件夹名称
            string currentDirectory = Directory.GetCurrentDirectory();  // 获取当前目录
            string fullPath = Path.Combine(currentDirectory, folderName);  // 构造完整的文件夹路径

            try
            {
                // 检查文件夹是否存在
                if (Directory.Exists(fullPath))
                {
                    Console.WriteLine("开始删除旧版离线包");
                    Directory.Delete(fullPath, true); // 第二个参数为true表示递归删除
                    Console.WriteLine("旧版成功删除");
                }
                else
                {
                    Console.WriteLine("未安装离线包，现在开始安装");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("出错：" + ex.Message);
            }
        }
    }
}
