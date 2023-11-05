"""
用于创建命令行解释器与命令行参数的模块
"""

import argparse

def create_parser():
    """
    用于创建命令行解释器与命令行参数的代码
    就这一点
    """
    # 创建命令行解析器
    parser = argparse.ArgumentParser()

    # 创建一个互斥的参数组
    group = parser.add_mutually_exclusive_group(required=True)

    # 添加命令行参数
    group.add_argument("update_log", nargs='?', help="显示更新日志")
    group.add_argument("proxy", nargs='?', help="修改启动代理")
    group.add_argument("package_install", nargs='?', help="安装离线包")
    group.add_argument("package_uninstall", nargs='?', help="卸载离线包")

    return parser
