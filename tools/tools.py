"""
项目的核心代码
用于判断及调用模块来处理
处理代码已被拆分
"""
import ctypes
import arg_parser as ap
from lib import updateLog as ul
from lib import package as pk
from subprogram import proxy

# 创建命令行解析器
parser = ap.create_parser()

# 解析命令行参数
args = parser.parse_args()

# 根据解析结果执行相应操作
if args.update_log:
    ul.update_log() # 显示更新日志
elif args.proxy:
    proxy.site() # 修改启动站点
elif args.package_install:
    pk.install() # 安装离线包
elif args.package_uninstall:
    pk.uninstall() # 卸载离线包
elif args.download_config:
    # 加载动态链接库
    dc = ctypes.CDLL('./download_config.dll')
    dc.main()
else:
    print('未知命令')
    # 执行无参数操作的代码
    # pf.parameter_free()
    # pf.parameter_free_unknow()
    # 如果没有提供任何参数，则打印帮助信息
    parser.print_help()
