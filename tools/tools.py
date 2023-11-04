import argparse
from lib import updateLog as ul
from lib import package
from subprogram import proxy

# 创建命令行解析器
parser = argparse.ArgumentParser()

# 创建一个互斥的参数组
group = parser.add_mutually_exclusive_group(required=True)

# 添加命令行参数
group.add_argument("update_log", nargs='?', help="显示更新日志")
group.add_argument("proxy", nargs='?', help="修改启动代理")
group.add_argument("package-install", nargs='?', help="安装离线包")
group.add_argument("package-uninstall", nargs='?', help="卸载离线包")

# 解析命令行参数
args = parser.parse_args()

# 根据解析结果执行相应操作
if args.update_log:
    ul.update_log()
elif args.proxy:
    proxy.site()
elif args.package_install:
    package.install()
elif args.package_uninstall:
    package.uninstall()
else:
    print('未知命令')
    # 执行无参数操作的代码
    # pf.parameter_free()
    # pf.parameter_free_unknow()
    # 如果没有提供任何参数，则打印帮助信息
    parser.print_help()
