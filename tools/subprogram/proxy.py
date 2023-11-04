import json, os, subprocess
import time
from termcolor import colored

def site():
    # 读取site.json文件
    with open('site.json') as file:
        data = json.load(file)

    # 获取输入的站点名称
    input_site = input("请输入站点名称: ")

    # 查找匹配的站点
    matching_site = None
    for site in data.values():
        if site['name'] == input_site:
            matching_site = site
            break

    if matching_site:
        # 获取匹配站点的url属性值
        url_value = matching_site["url"]

        # 将url属性值写入到load.prop文件中
        with open('load.prop', 'w') as load_prop_file:
            load_prop_file.write(f"url={url_value}")
    else:
        print(colored("未在内置站点列表中查询出该站点", "red"))
        print("站点可用列表：")
        site_list()
    
    # 输出load.prop内容
    url_prop_get()

    # 重启软件
    restart()

def site_list():
    # 读取site.json文件
    with open('site.json') as file:
        data = json.load(file)

    # 输出名称
    for site in data.values():
        print(site['name'])

def url_prop_get():
    # 读取load.prop文件
    with open('load.prop') as file:
        load_prop_content = file.read()

    # 解析load.prop内容，提取url属性值
    url_value = None
    lines = load_prop_content.split('\n')
    for line in lines:
        if line.startswith('url='):
            url_value = line.split('=')[1]
            break

    # 打印url属性值
    print("加载站点已经修改为："+url_value)

def restart():
    # 获取当前目录路径
    dir_path = os.path.dirname(os.path.realpath(__file__))

    # 构造 taskkill 命令
    kill_cmd = f"taskkill /f /im Novels.exe /t"

    # 使用 subprocess 模块执行命令
    subprocess.run(kill_cmd, cwd=dir_path)

    # 等待 0.25 秒
    time.sleep(0.25)

    # 构造启动命令
    start_cmd = "./Novels.exe"

    # 使用 subprocess 模块执行启动命令
    subprocess.Popen(start_cmd)