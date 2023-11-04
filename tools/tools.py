import argparse
from subprogram import updateLog, parameterFree, proxy

# 创建命令行解析器
parser = argparse.ArgumentParser(formatter_class=argparse.RawTextHelpFormatter)

# 添加命令行参数
parser.add_argument('command', nargs='?')

# 定义自定义帮助信息
custom_help = """
可用命令:
update-log       显示更新日志
"""

# 解析命令行参数
args = parser.parse_args()

# 检查是否存在命令参数
if args.command:
    # 根据解析结果执行相应操作
    if args.command == 'update-log':
        # 执行updateLog.update_log()的代码
        updateLog.update_log()
    if args.command == 'proxy':
        proxy.site()
    else:
        print('未知命令:', args.command)
        parameterFree.parameter_free_unknow()
else:
    # 执行无参数操作的代码
    parameterFree.parameter_free()