import json
from termcolor import colored

def site():
    user_input = input("请输入文本: ")
    
    with open('site.json', 'r') as file:
        data = json.load(file)
        
        for item in data:
            if item['name'] == user_input:
                print(colored("成功更新站点", "green"))
                
                # 更新load.prop文件
                with open('load.prop', 'w') as prop_file:
                    prop_file.write(f"url={item['url']}\n")
                break
        else:
            print(colored("未在内置站点列表中查询出该站点", "red"))
            print("站点可用列表：\n1.default\n2.zeabur\n3.vercel\n4.github-gw\n5.github-qy\n6.dev\n注意：dev可能及其不稳定，不建议使用！")