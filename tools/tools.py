import argparse
from lib import updateLog as ul
from lib import parameterFree as pf
from lib import package
from subprogram import proxy

# 创建命令行解析器
parser = argparse.ArgumentParser()

# 添加命令行参数
parser.add_argument('command', nargs='?')
# parser.add_argument("update-log", type=str, help="显示更新日志")
# parser.add_argument("proxy", type=str, help="修改启动代理")

# 定义自定义帮助信息
# custom_help = """
# 可用命令:
# update-log       显示更新日志
# proxy            修改启动代理
# """

# 解析命令行参数
args = parser.parse_args()

# 检查是否存在命令参数
if args.command:
    # 根据解析结果执行相应操作
    if args.command == 'update-log':
        ul.update_log()
    if args.command == 'proxy':
        proxy.site()
    if args.command == 'package-install':
        package.install()
    if args.command == 'package-uninstall':
        package.uninstall()
    else:
        print('未知命令:', args.command)
        pf.parameter_free_unknow()
else:
    # 执行无参数操作的代码
    # pf.parameter_free()
    # 如果没有提供任何参数，则打印帮助信息
    parser.print_help()