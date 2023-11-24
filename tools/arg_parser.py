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
    group.add_argument("--update_log", action="store_true", help="显示更新日志")
    group.add_argument("--proxy", action="store_true", help="修改启动代理")
    group.add_argument("--package_install", action="store_true", help="安装离线包")
    group.add_argument("--package_uninstall", action="store_true", help="卸载离线包")
    group.add_argument("--download_config", action="store_true", help="下载原始配置文件")

    return parser
