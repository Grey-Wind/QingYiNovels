def update_log():
    with open('update-log.txt', 'r', encoding='utf-8') as file:
        content = file.read()
        print(content)
        input()